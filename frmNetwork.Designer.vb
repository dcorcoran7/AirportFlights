<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNetwork
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
        Me.btnAllPairsSP = New System.Windows.Forms.Button()
        Me.lstPath = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboRadius = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.trvNetwork = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTransPaths = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAllPairsSP
        '
        Me.btnAllPairsSP.Location = New System.Drawing.Point(246, 11)
        Me.btnAllPairsSP.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnAllPairsSP.Name = "btnAllPairsSP"
        Me.btnAllPairsSP.Size = New System.Drawing.Size(122, 37)
        Me.btnAllPairsSP.TabIndex = 9
        Me.btnAllPairsSP.Text = "All Pairs Shortest Path"
        Me.btnAllPairsSP.UseVisualStyleBackColor = True
        '
        'lstPath
        '
        Me.lstPath.FormattingEnabled = True
        Me.lstPath.Location = New System.Drawing.Point(23, 313)
        Me.lstPath.Name = "lstPath"
        Me.lstPath.Size = New System.Drawing.Size(345, 121)
        Me.lstPath.TabIndex = 8
        Me.lstPath.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Shortest Path"
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(280, 459)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 37)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboRadius
        '
        Me.cboRadius.FormattingEnabled = True
        Me.cboRadius.Location = New System.Drawing.Point(77, 19)
        Me.cboRadius.Name = "cboRadius"
        Me.cboRadius.Size = New System.Drawing.Size(122, 21)
        Me.cboRadius.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Radius"
        '
        'trvNetwork
        '
        Me.trvNetwork.Location = New System.Drawing.Point(23, 74)
        Me.trvNetwork.Name = "trvNetwork"
        Me.trvNetwork.Size = New System.Drawing.Size(345, 196)
        Me.trvNetwork.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Network"
        '
        'btnTransPaths
        '
        Me.btnTransPaths.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTransPaths.Location = New System.Drawing.Point(23, 459)
        Me.btnTransPaths.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnTransPaths.Name = "btnTransPaths"
        Me.btnTransPaths.Size = New System.Drawing.Size(88, 37)
        Me.btnTransPaths.TabIndex = 13
        Me.btnTransPaths.Text = "Trans Paths"
        Me.btnTransPaths.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(400, 508)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 15
        '
        'frmNetwork
        '
        Me.AcceptButton = Me.btnAllPairsSP
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(411, 525)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnTransPaths)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trvNetwork)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboRadius)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstPath)
        Me.Controls.Add(Me.btnAllPairsSP)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmNetwork"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Network"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAllPairsSP As Button
    Friend WithEvents lstPath As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents cboRadius As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents trvNetwork As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnTransPaths As Button
    Friend WithEvents Label2 As Label
End Class
