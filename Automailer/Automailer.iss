; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Automailer"
#define MyAppVersion "1.13"
#define MyAppPublisher "Mateusz Zawrocki"
#define MyAppExeName "Automailer.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F8382B35-7670-4850-97C8-96A16EDFFC17}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputBaseFilename=AutomailerSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\Automailer.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Data.Desktop.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Data.Desktop.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Data.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Data.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Images.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Office.v20.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Office.v20.1.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Pdf.v20.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Pdf.v20.1.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Pdf.v20.1.Drawing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Pdf.v20.1.Drawing.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Printing.v20.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Printing.v20.1.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.RichEdit.v20.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.RichEdit.v20.1.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Sparkline.v20.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Sparkline.v20.1.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Utils.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.Utils.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraBars.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraBars.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraEditors.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraEditors.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraGrid.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraGrid.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraLayout.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraLayout.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraPrinting.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraPrinting.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraRichEdit.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraRichEdit.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraTreeList.v20.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\DevExpress.XtraTreeList.v20.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\EPPlus.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\EPPlus.Interfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\EPPlus.System.Drawing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\EPPlus.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\zawro\source\repos\Automailer\Automailer\bin\Release\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

