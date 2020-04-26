var
  str_noproject:string;
  
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
  lbTitle.Font.Style:=[fsBold];
end;

procedure ApplyTranslation;
begin
  if ScriptVars.Values['LANGCODE']='cs' then
  begin
    Self.Caption:='Statistiky projektu';
    sbCancel.Caption:='Storno';
    lbTopicsCap.Caption:='Témata:';
    lbIndexCap.Caption:='Klíèová slova:';
    lbContextCap.Caption:='Kontextové ID:';
    lbIncludedCap.Caption:='Soubory:';
    lbMergedCap.Caption:='Vložené soubory:';
    lbLastUpdCap.Caption:='Posl. zmìna:';
    str_noproject:='Není otevøen žádný projekt';       
  end
  else
    str_noproject:='No project opened';
end;

function GetTreeNodesCount(aTree:TObject):integer;
var
  N:Integer;
begin
  Result := 0;
  N := Tree_GetFirstNode(aTree);
  while N<>0 do
  begin
    Result:=Result+1;
    N := Tree_GetNext(aTree,N);
  end;
end;

begin
  // access the custom form properties by Self identifier
  Self.Position:=poScreenCenter;
  ApplyColorScheme;
  ApplyTranslation;

  // read project information
  lbFile.Caption := QueryAppInterface(PHC_FILENAME);
  if length(lbFile.Caption)=0 then
    lbTitle.Caption := str_noproject
  else
    lbTitle.Caption := QueryAppInterface(PHC_TITLE);
  lbFile.Hint := lbFile.Caption;
  lbTopics.Caption := IntToStr(GetTreeNodesCount(TOCTree));
  lbIndex.Caption := IntToStr(GetTreeNodesCount(IDXTree));
  lbContext.Caption := inttostr(QueryAppInterface2(PHC_CONTEXTIDS));
  lbIncluded.Caption := inttostr(QueryAppInterface2(PHC_FILES));
  lbMerged.Caption := inttostr(QueryAppInterface2(PHC_MERGEFILES));
  lbLastUpdate.Caption := ReplaceStr(QueryAppInterface(PHC_PROJECT_LASTUPDATE),'T',' ');  

  Self.ShowModal;
  ScriptResult:=SCRIPT_OK;
end.