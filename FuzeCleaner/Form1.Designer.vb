<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        ShaderCache = New CheckBox()
        Benchmark = New CheckBox()
        SecurityPatch = New CheckBox()
        SecurityPatchNew = New CheckBox()
        ConfigProfile = New CheckBox()
        Clean = New Button()
        About = New Label()
        FirewallRules = New CheckBox()
        SuspendLayout()
        ' 
        ' ShaderCache
        ' 
        ShaderCache.AutoSize = True
        ShaderCache.Location = New Point(12, 12)
        ShaderCache.Name = "ShaderCache"
        ShaderCache.Size = New Size(284, 29)
        ShaderCache.TabIndex = 0
        ShaderCache.Text = "[扫描中]着色器缓存（仅Vulkan）"
        ShaderCache.UseVisualStyleBackColor = True
        ' 
        ' Benchmark
        ' 
        Benchmark.AutoSize = True
        Benchmark.Checked = True
        Benchmark.CheckState = CheckState.Checked
        Benchmark.Location = New Point(12, 47)
        Benchmark.Name = "Benchmark"
        Benchmark.Size = New Size(213, 29)
        Benchmark.TabIndex = 1
        Benchmark.Text = "[扫描中]性能测试数据"
        Benchmark.UseVisualStyleBackColor = True
        ' 
        ' SecurityPatch
        ' 
        SecurityPatch.AutoSize = True
        SecurityPatch.Checked = True
        SecurityPatch.CheckState = CheckState.Checked
        SecurityPatch.Location = New Point(12, 82)
        SecurityPatch.Name = "SecurityPatch"
        SecurityPatch.Size = New Size(231, 29)
        SecurityPatch.TabIndex = 2
        SecurityPatch.Text = "[扫描中]过时的安全措施"
        SecurityPatch.UseVisualStyleBackColor = True
        ' 
        ' SecurityPatchNew
        ' 
        SecurityPatchNew.AutoSize = True
        SecurityPatchNew.Location = New Point(12, 117)
        SecurityPatchNew.Name = "SecurityPatchNew"
        SecurityPatchNew.Size = New Size(448, 29)
        SecurityPatchNew.TabIndex = 3
        SecurityPatchNew.Text = "[扫描中]最新的安全措施（下次进入游戏会重新下载）"
        SecurityPatchNew.UseVisualStyleBackColor = True
        ' 
        ' ConfigProfile
        ' 
        ConfigProfile.AutoSize = True
        ConfigProfile.Enabled = False
        ConfigProfile.Location = New Point(12, 152)
        ConfigProfile.Name = "ConfigProfile"
        ConfigProfile.Size = New Size(266, 29)
        ConfigProfile.TabIndex = 4
        ConfigProfile.Text = "[开发中]配置文件（谨慎操作）"
        ConfigProfile.UseVisualStyleBackColor = True
        ' 
        ' Clean
        ' 
        Clean.Location = New Point(12, 222)
        Clean.Name = "Clean"
        Clean.Size = New Size(112, 34)
        Clean.TabIndex = 7
        Clean.Text = "清理"
        Clean.UseVisualStyleBackColor = True
        ' 
        ' About
        ' 
        About.AutoSize = True
        About.Location = New Point(130, 227)
        About.Name = "About"
        About.Size = New Size(164, 25)
        About.TabIndex = 8
        About.Text = "版本：1.1.0   琴梨梨"
        ' 
        ' FirewallRules
        ' 
        FirewallRules.AutoSize = True
        FirewallRules.Location = New Point(12, 187)
        FirewallRules.Name = "FirewallRules"
        FirewallRules.Size = New Size(196, 29)
        FirewallRules.TabIndex = 9
        FirewallRules.Text = "[扫描中]防火墙规则"
        FirewallRules.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = Color.White
        ClientSize = New Size(544, 344)
        Controls.Add(FirewallRules)
        Controls.Add(About)
        Controls.Add(Clean)
        Controls.Add(ConfigProfile)
        Controls.Add(SecurityPatchNew)
        Controls.Add(SecurityPatch)
        Controls.Add(Benchmark)
        Controls.Add(ShaderCache)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Form1"
        Text = "FuzeCleaner"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ShaderCache As CheckBox
    Friend WithEvents Benchmark As CheckBox
    Friend WithEvents SecurityPatch As CheckBox
    Friend WithEvents SecurityPatchNew As CheckBox
    Friend WithEvents ConfigProfile As CheckBox
    Friend WithEvents Clean As Button
    Friend WithEvents About As Label
    Friend WithEvents FirewallRules As CheckBox
End Class
