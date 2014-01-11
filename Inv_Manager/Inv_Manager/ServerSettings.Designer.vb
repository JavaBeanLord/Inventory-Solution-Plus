<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServerSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.serverhost = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.serveruser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.serverpassword = New System.Windows.Forms.TextBox()
        Me.serversavebtn = New System.Windows.Forms.Button()
        Me.serverstatus = New System.Windows.Forms.Label()
        Me.userstatus = New System.Windows.Forms.Label()
        Me.passwordstatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Host"
        '
        'serverhost
        '
        Me.serverhost.Location = New System.Drawing.Point(28, 29)
        Me.serverhost.Name = "serverhost"
        Me.serverhost.Size = New System.Drawing.Size(267, 20)
        Me.serverhost.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Server UserName"
        '
        'serveruser
        '
        Me.serveruser.Location = New System.Drawing.Point(28, 86)
        Me.serveruser.Name = "serveruser"
        Me.serveruser.Size = New System.Drawing.Size(267, 20)
        Me.serveruser.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Server PassWord"
        '
        'serverpassword
        '
        Me.serverpassword.Location = New System.Drawing.Point(28, 139)
        Me.serverpassword.Name = "serverpassword"
        Me.serverpassword.Size = New System.Drawing.Size(267, 20)
        Me.serverpassword.TabIndex = 5
        '
        'serversavebtn
        '
        Me.serversavebtn.Location = New System.Drawing.Point(220, 177)
        Me.serversavebtn.Name = "serversavebtn"
        Me.serversavebtn.Size = New System.Drawing.Size(75, 23)
        Me.serversavebtn.TabIndex = 6
        Me.serversavebtn.Text = "Save"
        Me.serversavebtn.UseVisualStyleBackColor = True
        '
        'serverstatus
        '
        Me.serverstatus.AutoSize = True
        Me.serverstatus.Location = New System.Drawing.Point(2, 170)
        Me.serverstatus.Name = "serverstatus"
        Me.serverstatus.Size = New System.Drawing.Size(40, 13)
        Me.serverstatus.TabIndex = 7
        Me.serverstatus.Text = "Status:"
        '
        'userstatus
        '
        Me.userstatus.AutoSize = True
        Me.userstatus.Location = New System.Drawing.Point(2, 185)
        Me.userstatus.Name = "userstatus"
        Me.userstatus.Size = New System.Drawing.Size(40, 13)
        Me.userstatus.TabIndex = 8
        Me.userstatus.Text = "Status:"
        '
        'passwordstatus
        '
        Me.passwordstatus.AutoSize = True
        Me.passwordstatus.Location = New System.Drawing.Point(2, 200)
        Me.passwordstatus.Name = "passwordstatus"
        Me.passwordstatus.Size = New System.Drawing.Size(40, 13)
        Me.passwordstatus.TabIndex = 9
        Me.passwordstatus.Text = "Status:"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'ServerSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(312, 214)
        Me.Controls.Add(Me.passwordstatus)
        Me.Controls.Add(Me.userstatus)
        Me.Controls.Add(Me.serverstatus)
        Me.Controls.Add(Me.serversavebtn)
        Me.Controls.Add(Me.serverpassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.serveruser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.serverhost)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(328, 248)
        Me.MinimumSize = New System.Drawing.Size(328, 248)
        Me.Name = "ServerSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ServerSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents serverhost As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents serveruser As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents serverpassword As System.Windows.Forms.TextBox
    Friend WithEvents serversavebtn As System.Windows.Forms.Button
    Friend WithEvents serverstatus As System.Windows.Forms.Label
    Friend WithEvents userstatus As System.Windows.Forms.Label
    Friend WithEvents passwordstatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
