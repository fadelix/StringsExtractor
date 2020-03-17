Imports System.IO
Imports System.Text
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("fill data", vbInformation, "error")
            Exit Sub
        End If
        Dim path As String = "run.bat"
        Dim fs As FileStream = File.Create(path)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("ren strings.sys strings.exe&&strings.exe " & TextBox1.Text & " > " & TextBox2.Text & "&&ren strings.exe strings.sys&&del run.bat")
        fs.Write(info, 0, info.Length)
        fs.Close()
        Process.Start("run.bat")
        MsgBox("String extracted to " & TextBox2.Text, vbInformation, "done")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()


        fd.Title = "Open File Dialog"
        fd.InitialDirectory = My.Application.Info.DirectoryPath
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            If My.Application.Info.DirectoryPath <> Path.GetDirectoryName(fd.FileName) Then
                MsgBox("Input File must in current directory")
                Exit Sub
            End If
            TextBox1.Text = fd.SafeFileName

            End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            If My.Application.Info.DirectoryPath <> Path.GetDirectoryName(saveFileDialog1.FileName) Then
                MsgBox("output File must in current directory")
                Exit Sub
            End If
            TextBox2.Text = Path.GetFileName(saveFileDialog1.FileName)
        End If
    End Sub
End Class
