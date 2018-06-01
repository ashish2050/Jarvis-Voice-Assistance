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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BunifuThinButton1 = New WindowsFormsControlLibrary1.BunifuThinButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuThinButton1
        '
        Me.BunifuThinButton1.BackgroundImage = CType(resources.GetObject("BunifuThinButton1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuThinButton1.ButtonText = "SPEAK"
        Me.BunifuThinButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton1.ForeColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton1.ForeColorHoverState = System.Drawing.Color.White
        Me.BunifuThinButton1.Iconimage = Nothing
        Me.BunifuThinButton1.IconVisible = True
        Me.BunifuThinButton1.IconZoom = 90.0R
        Me.BunifuThinButton1.ImageIconOverlay = False
        Me.BunifuThinButton1.Location = New System.Drawing.Point(20, 562)
        Me.BunifuThinButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton1.Name = "BunifuThinButton1"
        Me.BunifuThinButton1.Size = New System.Drawing.Size(348, 75)
        Me.BunifuThinButton1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-47, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(629, 470)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(543, 466)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BunifuThinButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Opacity = 0.85R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BunifuThinButton1 As WindowsFormsControlLibrary1.BunifuThinButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
