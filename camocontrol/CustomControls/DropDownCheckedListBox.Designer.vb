<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DropDownCheckedListBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txt = New System.Windows.Forms.TextBox()
        Me.btnDropdown = New System.Windows.Forms.Button()
        Me.chkListBox = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'txt
        '
        Me.txt.Location = New System.Drawing.Point(3, 3)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(100, 20)
        Me.txt.TabIndex = 0
        '
        'btnDropdown
        '
        Me.btnDropdown.Location = New System.Drawing.Point(114, 5)
        Me.btnDropdown.Name = "btnDropdown"
        Me.btnDropdown.Size = New System.Drawing.Size(26, 18)
        Me.btnDropdown.TabIndex = 1
        Me.btnDropdown.Text = "D"
        Me.btnDropdown.UseVisualStyleBackColor = True
        '
        'chkListBox
        '
        Me.chkListBox.FormattingEnabled = True
        Me.chkListBox.Location = New System.Drawing.Point(4, 29)
        Me.chkListBox.Name = "chkListBox"
        Me.chkListBox.Size = New System.Drawing.Size(135, 94)
        Me.chkListBox.TabIndex = 2
        '
        'DropDownCheckedListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkListBox)
        Me.Controls.Add(Me.btnDropdown)
        Me.Controls.Add(Me.txt)
        Me.Name = "DropDownCheckedListBox"
        Me.Size = New System.Drawing.Size(150, 156)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt As TextBox
    Friend WithEvents btnDropdown As Button
    Friend WithEvents chkListBox As CheckedListBox
End Class
