<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.DropDownCheckedListBox1 = New camocontrol.DropDownCheckedListBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MyCustomerInfoUserControl1 = New camocontrol.MyCustomerInfoUserControl()
        Me.SuspendLayout()
        '
        'DropDownCheckedListBox1
        '
        Me.DropDownCheckedListBox1.DisplayListSize = 6
        Me.DropDownCheckedListBox1.Items = New String() {"ingrid", "carol", "andres", "sara", "gabriela"}
        Me.DropDownCheckedListBox1.Location = New System.Drawing.Point(293, 66)
        Me.DropDownCheckedListBox1.Name = "DropDownCheckedListBox1"
        Me.DropDownCheckedListBox1.Size = New System.Drawing.Size(150, 98)
        Me.DropDownCheckedListBox1.TabIndex = 0
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"asd", "sdsd", "sdgdf", "fghfgh", "vvnvb", "dfgd", "cvbc", "etrsdfsd"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(559, 99)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(120, 94)
        Me.CheckedListBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(218, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MyCustomerInfoUserControl1
        '
        Me.MyCustomerInfoUserControl1.Location = New System.Drawing.Point(392, 222)
        Me.MyCustomerInfoUserControl1.Name = "MyCustomerInfoUserControl1"
        Me.MyCustomerInfoUserControl1.Size = New System.Drawing.Size(375, 150)
        Me.MyCustomerInfoUserControl1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MyCustomerInfoUserControl1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.DropDownCheckedListBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DropDownCheckedListBox1 As DropDownCheckedListBox
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents MyCustomerInfoUserControl1 As MyCustomerInfoUserControl
End Class
