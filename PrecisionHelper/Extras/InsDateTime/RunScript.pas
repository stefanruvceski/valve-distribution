begin
  ScriptResult:=SCRIPT_OK;
  InvokeAppCommand(PHC_EDITOR_SELTEXT,FormatDateTime(optDateTimeFormat,Now));
end.