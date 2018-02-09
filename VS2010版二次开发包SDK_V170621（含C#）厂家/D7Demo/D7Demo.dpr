program D7Demo;

uses
  Forms,
  uMain in 'uMain.pas' {frmMain},
  LEDAPI in 'LEDAPI.pas',
  uTestThread in 'uTestThread.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.
