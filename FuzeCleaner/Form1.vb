Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices

Public Module MyExtensions
    <Extension()>
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub
End Module
Public Class Form1
    ReadOnly ShaderCachePath = Environment.GetEnvironmentVariable("LOCALAPPDATA") + "\Ubisoft\Rainbow Six - Siege"
    ReadOnly BenchmarkPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\My Games\Rainbow Six - Siege\Benchmark"
    ReadOnly SecurityPath = Environment.GetEnvironmentVariable("LOCALAPPDATA") + "\Ubisoft\r6siege"

    Dim LatestPatch As DirectoryInfo = Nothing
    Dim OldPatch As DirectoryInfo() = {}
    Private Function FolderSize(strFolder As String) As Long
        Dim size As Long = (From strFile In My.Computer.FileSystem.GetFiles(strFolder,
              FileIO.SearchOption.SearchAllSubDirectories)
                            Select New FileInfo(strFile).Length).Sum()
        Return size
    End Function
    Private Sub About_Click(sender As Object, e As EventArgs) Handles About.Click
        Dim startInfo As New ProcessStartInfo("https://qinlili.bid") With {
            .UseShellExecute = True
        }
        Process.Start(startInfo)
    End Sub

    Dim DoubleBytes As Double
    Public Function FormatBytes(BytesCaller As ULong) As String
        Try
            Select Case BytesCaller
                Case Is >= 1099511627776
                    DoubleBytes = BytesCaller / 1099511627776 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = BytesCaller / 1073741824 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = BytesCaller / 1048576 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = BytesCaller / 1024 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = BytesCaller ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Private Sub Clean_Click(sender As Object, e As EventArgs) Handles Clean.Click
        If ShaderCache.Checked Then
            Directory.Delete(ShaderCachePath, True)
        End If
        If Benchmark.Checked Then
            Directory.Delete(BenchmarkPath, True)
        End If
        If SecurityPatch.Checked Then
            For Each di In OldPatch
                Directory.Delete(di.FullName, True)
            Next
        End If
        If SecurityPatchNew.Checked Then
            Directory.Delete(LatestPatch.FullName, True)
        End If
        LatestPatch = Nothing
        OldPatch = {}
        Scan()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Scan()
    End Sub
    Private Sub Scan()
        Try
            ShaderCache.Text = "[" + FormatBytes(FolderSize(ShaderCachePath)) + "]着色器缓存（仅Vulkan）"
        Catch
            ShaderCache.Text = "[未找到]着色器缓存（仅Vulkan）"
            ShaderCache.Checked = False
            ShaderCache.Enabled = False
        End Try
        Try
            Benchmark.Text = "[" + FormatBytes(FolderSize(BenchmarkPath)) + "]性能测试数据"
        Catch
            Benchmark.Text = "[未找到]性能测试数据"
            Benchmark.Checked = False
            Benchmark.Enabled = False
        End Try
        Dim di = New DirectoryInfo(SecurityPath)
        Try
            Dim LatestTime As New DateTime(1)
            For Each fi In di.GetDirectories()
                If fi.CreationTime > LatestTime Then
                    LatestTime = fi.CreationTime
                    If LatestPatch IsNot Nothing Then
                        OldPatch.Add(LatestPatch)
                    End If
                    LatestPatch = fi
                Else
                    OldPatch.Add(fi)
                End If
            Next
            If LatestPatch Is Nothing Then
                SecurityPatchNew.Text = "[未找到]最新的安全措施（下次进入游戏会重新下载）"
                SecurityPatchNew.Checked = False
                SecurityPatchNew.Enabled = False
            Else
                SecurityPatchNew.Text = "[" + FormatBytes(FolderSize(LatestPatch.FullName)) + "]最新的安全措施（下次进入游戏会重新下载）"
            End If
            If OldPatch.Length > 0 Then
                Dim TotalSize As Long = 0
                For Each fi In OldPatch
                    TotalSize += FolderSize(fi.FullName)
                Next
                SecurityPatch.Text = "[" + FormatBytes(TotalSize) + "]过时的安全措施"
            Else
                SecurityPatch.Text = "[未找到]过时的安全措施"
                SecurityPatch.Checked = False
                SecurityPatch.Enabled = False
            End If
        Catch
            SecurityPatchNew.Text = "[未找到]最新的安全措施（下次进入游戏会重新下载）"
            SecurityPatchNew.Checked = False
            SecurityPatchNew.Enabled = False
            SecurityPatch.Text = "[未找到]过时的安全措施"
            SecurityPatch.Checked = False
            SecurityPatch.Enabled = False
        End Try
    End Sub
End Class
