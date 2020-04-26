const
  Ini_Sec_Options = '_Options';
  SW_HIDE = 0;
  maxint = 65535;
  
var
  FOldTopic:string;
  FTidyExe:string;
  
procedure ApplyColorScheme;
var
  backColor,
  backColorTo,
  borderColor,
  fontColor:TColor;
  fontName:string;
  fontSize:integer;
begin
  GetColorScheme(backColor,backColorTo,borderColor, fontColor, fontName, fontSize);
  Self.Color:=backColor;
  Self.Font.Color:=fontColor;
  Self.Font.Name:=fontName;
  Self.Font.Size:=fontSize;
  lbDlgTitle.Font.Style:=[fsBold];
  lbTitle.Font.Style:=[fsBold];
end;

procedure Self_OnClose(Sender: TObject; var Action: TCloseAction);
var
  Ini:TMemIniFile;
begin
  Ini := TMemIniFile.Create(ScriptVars.Values['EXT_INI']);
  try
    Ini.WriteString(Ini_Sec_Options,'LastAction',edAction.text);
    Ini.UpdateFile;
  finally    
    Ini.free;
  end;
  if (FOldTopic<>'') and fileexists(FOldTopic) then
  try
    deletefile(FOldTopic);
  except
  end;
  
end;

procedure sbNext_OnClick(Sender: TObject);
var
  prms:string;
  ec:cardinal;
  tmp: String;   
begin
  if edAction.Text<>'' then
  begin   
    tmp:=IncludeTrailingPathDelimiter(ExpandMacro('%APPTEMP%'))+'tidy.log';
    if ForceDirectories(extractfilepath(tmp)) then
    begin
      // backup the old file
      if FOldTopic='' then
      begin
        FOldTopic:=extractfilepath(tmp)+'~'+ ExtractFileName(lbFile.Caption);
        CopyFileAs(lbFile.Caption,FOldTopic,True);
      end;
      prms:=edParams.text+ ' -f "'+tmp+'" "'+lbFile.Caption+'"';
      if ShellExecAndWaitWithExitCode(FTidyExe, ec, prms, '', SW_HIDE, '') then
      begin
        mReport.Lines.loadfromfile(tmp);
        if (pos(' -m ',prms)>0) or (pos(' -modify ',prms)>0) or (pos('-m ',prms)=1) or (pos('-modify ',prms)=1) then
        begin 
          ReloadTopic;         
          sbUndo.Visible:=true;           
        end;
        sbNext.Default:=False;
        sbClose.Default:=True;
        try
          deletefile(tmp);
        except
        end;
      end
      else
      begin
        mReport.Lines.Text := 'Cannot execute HTML Tidy!';
      end;
    end;
      
    lbReport.Visible:=true;
    mReport.Visible:=true;
    if mReport.CanFocus then
      mReport.SetFocus;
  end;    
end;

procedure sbUndo_OnClick(Sender: TObject);
begin
  if (FOldTopic<>'') and fileexists(FOldTopic) then
  begin
    if forcedirectories(extractfilepath(lbFile.Caption)) then
    begin
      CopyFileAs(FOldTopic,lbFile.Caption,True);
      ReloadTopic;
    end;
  end;
end;

procedure miAction_OnClick(Sender: TObject);
begin
  sbClose.Default:=False;
  sbNext.Default:=True;
  if Sender=nil then
  begin
    edAction.Text:='';
    edParams.Text:='';
    edAction.Tag:=-1;
  end
  else
  begin
    edAction.Text:=TMenuItem(Sender).Caption;
    edParams.Text:=TMenuItem(Sender).Hint;
    edAction.Tag:=TMenuItem(Sender).MenuIndex;
  end;
  if sbSave.Visible then
  begin
    if edAction.CanFocus then
      edAction.SetFocus;    
    edAction.ReadOnly:=true;
    edParams.Visible:=False;
    lbParams.Visible:=False;
    sbSave.Visible:=False;
    sbCancelEdit.Visible:=False;
    sbNext.Enabled:=true;           
    sbSave.Default:=False;
    sbNext.Default:=true;
    sbCancelEdit.Cancel:=False;
    sbClose.Cancel:=true;     
  end;
end;

procedure miAdd_OnClick(Sender: TObject);
begin  
  edAction.Text:='';
  edParams.Text:='';
  edAction.Tag:=-1;
  edAction.ReadOnly:=False;
  edParams.Visible:=true;
  lbParams.Visible:=true;
  sbSave.Visible:=true;
  sbCancelEdit.Visible:=True;  
  if edAction.CanFocus then
    edAction.SetFocus;
  sbNext.Enabled:=False;
  sbNext.Default:=False;   
  sbSave.Default:=true;
  sbClose.Cancel:=False;
  sbCancelEdit.Cancel:=true;       
end;

procedure miEdit_OnClick(Sender: TObject);
begin
  if edAction.Tag>=0 then
  begin
    if pumOptions.Items.Items[edAction.Tag].Tag=0 then
    begin 
      edAction.ReadOnly:=False;
      edParams.Visible:=true;
      lbParams.Visible:=true;
      sbSave.Visible:=true;
      sbCancelEdit.Visible:=true;      
      if edAction.CanFocus then
        edAction.SetFocus;
      sbNext.Enabled:=False;
      sbNext.Default:=False;   
      sbSave.Default:=true;
      sbClose.Cancel:=False;
      sbCancelEdit.Cancel:=true;       
    end;
  end;   
end;

procedure sbSave_OnClick(Sender: TObject);
var
  Ini: TMemIniFile;
  MI:TMenuItem;
begin
  if edAction.Text<>'' then
  begin
    MI:=nil;
    try    
      Ini := TMemIniFile.Create(ScriptVars.Values['EXT_INI']);
      try
        if edAction.Tag>=0 then
        begin
          MI:=pumOptions.Items.Items[edAction.Tag];
          if MI.Tag=0 then
            Ini.EraseSection(MI.Caption)
        end
        else
        begin
          MI:=TMenuItem.create(Self);
          MI.Tag:=0;
          MI.OnClick:=@miAction_OnClick;
          pumOptions.Items.Insert(NSep.MenuIndex,MI);
          edAction.Tag:=MI.MenuIndex;                   
        end;
        if MI.Tag=0 then
        begin
          MI.Caption:=edAction.Text;
          MI.Hint:=edParams.Text;
          Ini.WriteString(MI.Caption,'CmdLinePrms',MI.Hint);
          Ini.UpdateFile;
        end;
      finally    
        Ini.free;
      end;
      if edAction.CanFocus then
        edAction.SetFocus;    
      edAction.ReadOnly:=true;
      edParams.Visible:=False;
      lbParams.Visible:=False;
      sbSave.Visible:=False;
      sbCancelEdit.Visible:=False;
      sbNext.Enabled:=true;           
      sbSave.Default:=False;
      sbNext.Default:=true;
      sbCancelEdit.Cancel:=False;
      sbClose.Cancel:=true;           
    except
    end;   
  end;
end;

procedure sbCancelEdit_OnClick(Sender: TObject);
begin
  if edAction.CanFocus then
    edAction.SetFocus;    
  edAction.ReadOnly:=true;
  edParams.Visible:=False;
  lbParams.Visible:=False;
  sbSave.Visible:=False;
  sbCancelEdit.Visible:=False;
  sbNext.Enabled:=true;           
  sbSave.Default:=False;
  sbNext.Default:=true;
  sbCancelEdit.Cancel:=False;
  sbClose.Cancel:=true;     
end;

procedure miDelete_OnClick(Sender: TObject);
var
  i:integer;
  MI:TMenuItem;
  Ini:TMemIniFile;
begin
  i:=edAction.Tag;
  if i>=0 then
  begin
    MI:=pumOptions.Items.Items[i];
    if MI.Tag=0 then
    begin
      if MessageDlgLM(Self.Caption,mStrConst.Lines.Values['str_delete'],mtConfirmation,[mbYes,mbNo],0)=mrYes then
      begin       
        Ini := TMemIniFile.Create(ScriptVars.Values['EXT_INI']);
        try
          Ini.EraseSection(MI.Caption);
          Ini.UpdateFile;
        finally    
          Ini.free;
        end;
        MI.free;
        
        if i>=NSep.MenuIndex then
          i:=NSep.MenuIndex-1;
        if i>=0 then
          miAction_OnClick(pumOptions.Items.Items[i])
        else
          miAction_OnClick(nil);
      end;
    end;
  end;
end;

procedure LoadExtensionOptions;
var
  i:integer;
  sec:string;
  dfn:string;
  lastact:string;
  FMI,SMI,MI:TMenuItem;
  DIni,Ini: TMemIniFile;  
  SL:TStringList;
begin
  SMI:=nil; FMI:=nil;
  SL:=TStringList.create;
  dfn:=ScriptVars.Values['EXT_INI'];
  Ini := TMemIniFile.Create(dfn);
  dfn:=ExtractFilePath(dfn)+'TidyActions.'+ScriptVars.Values['LANGCODE'];
  if not fileexists(dfn) then
    dfn:=ExtractFilePath(dfn)+'TidyActions.en';   
  DIni:=TMemIniFile.Create(dfn);
  try
    edAction.Tag:=-1;
    for i:=NSep.MenuIndex-1 downto 0 do
      pumOptions.Items.Items[i].Free;
    lastact:=Ini.ReadString(Ini_Sec_Options,'LastAction','');
    Ini.ReadSections(SL);
    SL.Sort;
    for i:=0 to SL.Count-1 do
    begin
      sec:=SL[i];
      if AnsiLowerCase(sec)<>AnsiLowerCase(Ini_Sec_Options) then
      begin
        MI:=TMenuItem.create(Self);
        MI.Caption:=sec;
        MI.Hint:=Ini.ReadString(sec,'CmdLinePrms','');
        MI.Tag:=0; // user defined action
        MI.OnClick:=@miAction_OnClick;
        pumOptions.Items.Insert(NSep.MenuIndex,MI);
        if FMI=nil then
          FMI:=MI;
        if (SMI=nil) and (MI.Caption=lastact) then
          SMI:=MI;
      end;
    end;
    
    SL.clear;
    DIni.ReadSections(SL);
    SL.Sort;
    for i:=0 to SL.Count-1 do
    begin
      sec:=SL[i];
      if AnsiLowerCase(sec)<>AnsiLowerCase(Ini_Sec_Options) then
      begin
        MI:=TMenuItem.create(Self);
        MI.Caption:=sec;
        MI.Hint:=DIni.ReadString(sec,'CmdLinePrms','');
        MI.Tag:=1; // pre-defined action
        MI.OnClick:=@miAction_OnClick;
        pumOptions.Items.Insert(NSep.MenuIndex,MI);
        if FMI=nil then
          FMI:=MI;
        if (SMI=nil) and (MI.Caption=lastact) then
          SMI:=MI;
      end;
    end;

    if (SMI=nil) and (FMI<>nil) then
      SMI:=FMI; 
    if SMI<>nil then
      miAction_OnClick(SMI)
    else 
      miAction_OnClick(nil);
  finally    
    SL.free;
    Ini.free;
    DIni.free;
  end;
end;

procedure Init;
begin
  // read project information
  LoadExtensionOptions;
  lbFile.Caption := QueryAppInterface(PHC_TOPIC_FILE);
  if lbFile.Caption='' then
  begin
    lbTitle.Caption := mStrConst.Lines.Values['str_notopic'];
    sbNext.Enabled := False;    
  end
  else
  begin
    lbFile.Caption:=ExpandFileNameEx(QueryAppInterface(PHC_FILENAME),lbFile.Caption);
    lbFile.Hint := lbFile.Caption;
    lbTitle.Caption := QueryAppInterface(PHC_TOPIC_TITLE);
    if lbTitle.Caption='' then
      lbTitle.Caption := ExtractFileName(lbFile.Caption);
      
    FTidyExe := IncludeTrailingPathDelimiter(ExpandMacro('%APPEXTRAS%'))+'tidy\tidy.exe';
    if (FTidyExe='') or (not fileexists(FTidyExe)) then
    begin
      lbReport.Visible:=true;
      lbReport.Caption:=mStrConst.Lines.Values['str_tidy_not_found']+#13#10'('+FTidyExe+')';
      sbNext.Enabled := False;          
    end;       
  end;
end;

procedure sbOptions_OnClick(Sender: TObject);
var
  p:TPoint;
begin
  p.x:=0; p.y:=sbOptions.Height;
  p:=sbOptions.ClientToScreen(p);
  pumOptions.Popup(p.x,p.y);
end;

procedure pumOptions_OnPopup(Sender: TObject);
var
  ea:boolean;
begin
  ea:=true;
  if edAction.Tag>=0 then
    if pumOptions.Items.Items[edAction.Tag].Tag<>0 then
      ea:=false;
  miEdit.Enabled:=ea;
  miDelete.Enabled:=ea;
end;

procedure AssignEvents;
begin
  sbNext.OnClick := @sbNext_OnClick;
  Self.OnClose := @Self_OnClose;
  sbOptions.OnClick := @sbOptions_OnClick;
  sbSave.OnClick := @sbSave_OnClick;
  miEdit.OnClick := @miEdit_OnClick;
  miDelete.OnClick := @miDelete_OnClick;
  miAdd.OnClick := @miAdd_OnClick;
  sbCancelEdit.OnClick := @sbCancelEdit_OnClick;
  pumOptions.OnPopup := @pumOptions_OnPopup;
  sbUndo.OnClick := @sbUndo_OnClick;
end;

begin
  // access the custom form properties by Self identifier
  FOldTopic:='';
  Self.Position:=poScreenCenter;
  ApplyColorScheme;
  Init;
  AssignEvents; 
  ScriptResult:=SCRIPT_OK;
  if QueryAppInterface3(PHC_TOPIC_MODIFIED) then
    SaveTopic;
  Self.ShowModal;  
end.