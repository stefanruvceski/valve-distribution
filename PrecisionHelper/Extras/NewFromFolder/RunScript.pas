program PHExtension;

const
  maxint = 65535;
  Ini_Sec_Options = 'Options';
  hhp_sec_Options = 'OPTIONS';
  hhp_sec_Files = 'FILES';
  hhp_sec_Windows = 'WINDOWS';

var
  FProjectCreated:boolean;
  
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
  lbPage.Font.Style:=[fsBold];
end;

procedure TabSheet_OnShow(Sender: TObject);
begin
  lbPage.Caption:=TTabSheet(Sender).Caption;
  lbPageInfo.Caption:=TTabSheet(Sender).Hint;
  if Sender=tsFinished then
    sbNext.Caption:='Finish'
  else
    sbNext.Caption:='Next >';
end;

procedure HideWizardTabs;
var
  i:integer;
begin
  pcWizard.ActivePageIndex:=-1;
  for i:=pcWizard.PageCount-1 downto 0 do
  begin
    pcWizard.Pages[i].TabVisible := False;
    pcWizard.Pages[i].OnShow := @TabSheet_OnShow;  
  end;
  pcWizard.ActivePageIndex:=0;  
end;

procedure DoTheJob;
var
  i,c:integer;
  pfn,pf:string;
  pfl:integer;
  tmp,fn,tfn,tt:string;
  SL,EL:TStringList;
  IniHHP:TMemIniFile;
  dfn:string;
  hhc,hhk:string;
begin
  pcWizard.ActivePage:=tsProgress;
  lbStatus.Caption:='';
  mReport.Lines.Text:='';
  Application.ProcessMessages;
  
  pfn:=edProject.Text;
  if length(pfn)=0 then
    mReport.Lines.Add('No project file specified!')
  else
  begin
    pf:=extractfilepath(pfn);
    if pos(ansilowercase(pf),ansilowercase(edFolder.Text))<>1 then
    begin
      mReport.Lines.Add('Error: Project must be located in the topic files folder or above!');
      mReport.Lines.Add('Topics folder: '+edFolder.Text);      
      mReport.Lines.Add('Project file: '+pfn);
    end
    else
    if not forcedirectories(pf) then
    begin
      mReport.Lines.Add('Cannot create project folder!');
      mReport.Lines.Add(pf);
    end
    else
    begin      
      SL:=TStringList.create;
      EL:=TStringList.create;
      IniHHP:=TMemIniFile.Create(pfn);
      try
        mReport.Lines.Add('Project successfully created.');
        mReport.Lines.Add(pfn);
        mReport.Lines.Add('');
        // read topic files list
        EL.CommaText:=ReplaceStr(ReplaceStr(edExt.Text,';',','),', ',',');
        if EL.Count=0 then
          EL.CommaText:='htm,html';
        for i:=0 to EL.Count-1 do
          if pos(EL[i],'.')<>1 then
            EL[i]:='.'+EL[i];
        for i:=0 to EL.Count-1 do
          GetFilesByMaskTree(edFolder.Text,SL,'*'+EL[i]);

        // create file list
        pfl:=length(pf);
        EL.Clear;   
        dfn:='';
        hhc:=''; // container for TOC items
        hhk:=''; // container for IDX items
          
        c:=SL.Count;
        SL.Sort;
        for i:=0 to c-1 do
        begin
          fn:=SL[i];
          tt := GetTitleOfTopicFile(fn,true);
          tfn:=copy(fn,pfl+1,maxint);
          EL.Add(tfn);
          mReport.Lines.Add(tfn);
          if i mod 10=0 then
          begin
            lbStatus.Caption:=inttostr(round(i*100/c))+'%  '+tfn+' ...';
            Application.ProcessMessages;
          end;
          if length(dfn)=0 then
          begin
            tmp:=AnsiLowerCase(changefileext(changefileext(extractfilename(fn),''),''));
            if (tmp='default') or (tmp='index') or (tmp='home') or (tmp='welcome') then
              dfn:=tfn;
          end;
          hhc:=hhc+#13#10+
            '<LI><OBJECT type="text/sitemap">'#13#10+
            '  <param name="Name" value="'+tt+'">'#13#10+
            '  <param name="Local" value="'+tfn+'">'#13#10+
            '</OBJECT>';
          hhk:=hhk+#13#10+
            '<LI><OBJECT type="text/sitemap">'#13#10+
            '  <param name="Name" value="'+tt+'">'#13#10+
            '  <param name="Local" value="'+tfn+'">'#13#10+
            '</OBJECT>';                                 
        end;
        
        // create project file
        SL.Clear;
        SL.AddStrings(mHHPTemplate.Lines);
        SL.Add('');
        SL.Add('['+hhp_sec_Files+']');
        SL.AddStrings(EL);
        if (length(dfn)=0) and (EL.Count>0) then
          dfn:=EL[0];
          
        IniHHP.SetStrings(SL);
        IniHHP.WriteString(hhp_sec_Options,'Title',ChangeFileExt(ExtractFileName(pfn),''));
        IniHHP.WriteString(hhp_sec_Options,'Compiled file',ChangeFileExt(ExtractFileName(pfn),'.chm'));
        IniHHP.WriteString(hhp_sec_Options,'Default topic',dfn);
        tmp:=IniHHP.ReadString(hhp_sec_Windows,'main','');
        if length(tmp)>0 then
        begin
          tmp:=ReplaceText(tmp,'$HHC','Contents.hhc');
          tmp:=ReplaceText(tmp,'$HHK','Index.hhk');
          tmp:=ReplaceText(tmp,'$DEF',dfn);
          IniHHP.WriteString(hhp_sec_Windows,'main',tmp);
        end;
        
        // create HHC file
        tmp:=ReplaceText(mHHCTemplate.Lines.Text,'$TOC',hhc);
        SaveStrToFile(tmp,pf+'Contents.hhc');             

        // create HHK file
        tmp:=ReplaceText(mHHKTemplate.Lines.Text,'$IDX',hhk);
        SaveStrToFile(tmp,pf+'Index.hhk');             

        IniHHP.UpdateFile;
        FProjectCreated:=true;
      finally
        IniHHP.free;
        EL.free;
        SL.free;
      end;
    end;
  end;
  pcWizard.ActivePage:=tsFinished;
end;

procedure LoadOptions;
var
  Ini:TMemIniFile;
begin
  // save last options
  Ini:=TMemIniFile.create(ScriptVars.Values['EXT_INI']);
  try
    edFolder.Text:=Ini.ReadString(Ini_Sec_Options,'Folder',edFolder.Text);
    edProject.Text:=Ini.ReadString(Ini_Sec_Options,'Project',edProject.Text);
    edExt.Text:=Ini.ReadString(Ini_Sec_Options,'Extensions',edExt.Text);
  finally
    Ini.free;
  end;
end;

procedure SaveOptions;
var
  Ini:TMemIniFile;
begin
  // save last options
  Ini:=TMemIniFile.create(ScriptVars.Values['EXT_INI']);
  try
    Ini.WriteString(Ini_Sec_Options,'Folder',edFolder.Text);
    Ini.WriteString(Ini_Sec_Options,'Project',edProject.Text);
    Ini.WriteString(Ini_Sec_Options,'Extensions',edExt.Text);
    Ini.UpdateFile;
  finally
    Ini.free;
  end;
end;

procedure sbClose_OnClick(Sender: TObject);
begin
  SaveOptions;
  Self.Close;
  // open new project
  if FProjectCreated and (edProject.Text<>'') and FileExists(edProject.Text) then
    project_Load(edProject.Text);  
end;

procedure sbBack_OnClick(Sender: TObject);
begin
  if pcWizard.ActivePage=tsOptions then
    sbClose_OnClick(nil)
  else
  if pcWizard.ActivePage=tsFinished then
    pcWizard.ActivePage:=tsOptions;
end;

procedure sbNext_OnClick(Sender: TObject);
begin
  if pcWizard.ActivePage=tsFinished then
    sbClose_OnClick(nil)
  else
  if pcWizard.ActivePage=tsOptions then
    DoTheJob
end;

procedure Self_OnShow(Sender: TObject);
begin
  if edFolder.CanFocus then
    edFolder.SetFocus;
end;

procedure sbFolder_OnClick(Sender: TObject);
var
  d:string;
  p:TPoint;
begin
  d:=edFolder.Text;
  if not DirectoryExists(d) then
    d := GetCurrentDir;
  p.x:=0; p.y:=sbFolder.Height;
  p:=sbFolder.ClientToScreen(p);
  if BrowseForFolder(lbFolder.Caption,d,d,p) then
    edFolder.Text:=d;
end;

procedure sbProject_OnClick(Sender: TObject);
var
  d:string;
begin
  d := edProject.Text;
  if d='' then
  begin
    d:='New project.hhp'; 
    if edFolder.Text<>'' then
      d := IncludeTrailingPathDelimiter(edFolder.Text)+d;
  end;
  if SelectFileToSave(d,'MS Html Help project files (*.hhp)|*.hhp|All files (*.*)|*.*') then
  begin
    if pos('.',extractfilename(d))=0 then
      d:=d+'.hhp';
    edProject.Text:=d;
  end;
end;

procedure AssignEvents;
begin  
  sbClose.OnClick := @sbClose_OnClick;
  sbBack.OnClick := @sbBack_OnClick;
  sbNext.OnClick := @sbNext_OnClick;
  Self.OnShow := @Self_OnShow;
  sbFolder.OnClick := @sbFolder_OnClick;
  sbProject.OnClick := @sbProject_OnClick;
end;

begin
  Self.Position:=poScreenCenter;
  ApplyColorScheme;
  AssignEvents;
  HideWizardTabs;  
  LoadOptions;
  FProjectCreated:=False;
  ScriptResult := SCRIPT_OK;  
  Self.ShowModal;
end.