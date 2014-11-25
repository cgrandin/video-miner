; -- VideoMiner32Bit.iss --
; Installation of VideoMiner built for the x86 (32-bit)
; architecture. It must be 32 bit because the Vlc.DotNet assembly
; is only 32-bit.

[Setup]
AppName=VideoMiner
AppVersion=3.1.0.0
DefaultDirName={pf}\VideoMiner
DefaultGroupName=VideoMiner
UninstallDisplayIcon={app}\VideoMiner.exe
Compression=lzma2
SolidCompression=yes
OutputDir=userdocs:Inno Setup Examples Output

[Files]
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\VideoMiner.exe"; DestDir: "{app}"; DestName: "VideoMiner.exe"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\VideoMiner_TemplateDatabase_Version_3_1_0_0.mdb"; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Config\VideoMinerConfigurationDetails.xml"; DestDir: "{app}\Config"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\AxInterop.WMPLib.DLL" ; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Interop.ADODB.DLL" ; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Interop.ADOX.DLL" ; DestDir: "{app}" 
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Interop.WMPLib.DLL" ; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Vlc.DotNet.Core.dll" ; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Vlc.DotNet.Core.Interops.dll" ; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Vlc.DotNet.Forms.dll" ; DestDir: "{app}"
Source: "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Vlc.DotNet.Wpf.dll" ; DestDir: "{app}"

[Icons]
Name: "{group}\VideoMiner"; Filename: "{app}\VideoMiner.exe"
