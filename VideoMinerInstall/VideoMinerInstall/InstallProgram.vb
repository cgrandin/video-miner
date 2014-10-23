Imports System.IO

Public Class InstallProgram

    Overloads Shared Sub Main(ByVal args() As String)

        Console.WriteLine()
        Console.WriteLine("Selecting Video Miner Application Folder")
        Console.WriteLine()

        Dim path As String
        Dim strExecPath As String
        strExecPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        If (strExecPath.StartsWith("file:\")) Then
            strExecPath = strExecPath.Substring(6)    ' Remove unnecessary substring
        End If

        Dim opnDlg As System.Windows.Forms.FolderBrowserDialog

        opnDlg = New System.Windows.Forms.FolderBrowserDialog
        opnDlg.Description = "Select a folder location for Video Miner files (Please do not select a folder within Program Files)"
        opnDlg.ShowDialog()
        path = opnDlg.SelectedPath
        If path = "" Then
            Exit Sub
        End If

        If Not System.IO.Directory.Exists(path & "\" & "VideoMinerAppFiles_Version_3_0_8") Then
            System.IO.Directory.CreateDirectory(path & "\" & "VideoMinerAppFiles_Version_3_0_8")
        End If
        path = path & "\" & "VideoMinerAppFiles_Version_3_0_8"
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\VideoMiner", "FilePath", Nothing) Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("VideoMiner")
        End If
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\VideoMiner", "FilePath", path)
        'MsgBox(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\VideoMiner", "FilePath", Nothing))

        Console.WriteLine()
        Console.WriteLine("Installing Video Miner Application")
        Console.WriteLine()

        Using sCreateMSIFile As New FileStream(path & "\VideoMinerSetup.msi", FileMode.Create)
            sCreateMSIFile.Write(My.Resources.VideoMinerSetup, 0, My.Resources.VideoMinerSetup.Length)
        End Using
        Using sCreateMSIFile As New FileStream(path & "\setup.exe", FileMode.Create)
            sCreateMSIFile.Write(My.Resources.setup, 0, My.Resources.setup.Length)
        End Using
        System.IO.File.WriteAllBytes(path & "\VideoMiner_TemplateDatabase_Version_3_0_8.mdb", My.Resources.VideoMiner_TemplateDatabase_Version_3_0_8)
        'Using sCreateMSIFile As New FileStream(path & "\VideoMiner_TemplateDatabase_Version_3_0_6.mdb", FileMode.Create)
        '    sCreateMSIFile.Write(My.Resources.VideoMiner_TemplateDatabase_Version_3_0_6, 0, My.Resources.setup.Length)
        'End Using
        Dim strConfigData As String = My.Resources.VideoMinerConfigurationDetails
        If Not System.IO.Directory.Exists(path & "\" & "Config") Then
            System.IO.Directory.CreateDirectory(path & "\" & "Config")
        End If
        My.Computer.FileSystem.WriteAllText(path & "\Config\VideoMinerConfigurationDetails.xml", strConfigData, False)

        Dim myProcess As New Process
        myProcess = Process.Start(path & "\VideoMinerSetup.msi")
        myProcess.WaitForExit()

        'My.Computer.FileSystem.CopyDirectory(strExecPath & "\FilesToInstall", path, True)



        'Dim procInfo As ProcessStartInfo = New ProcessStartInfo

        'procInfo.UseShellExecute = False
        'procInfo.LoadUserProfile = True

        'procInfo.FileName = "msiexec"
        'procInfo.Arguments = "/i " & path & "\VideoMinerSetup.msi"

        '' Create and run a new process from the process info
        ''Dim myProcess As New Process
        'myProcess = Process.Start(procInfo)
        'myProcess.WaitForExit()     ' Wait for installation to complete
    End Sub

End Class
