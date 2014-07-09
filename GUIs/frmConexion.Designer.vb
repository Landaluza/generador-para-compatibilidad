<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexion
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
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.rbAuthIntegrada = New System.Windows.Forms.RadioButton()
        Me.rbAuthSql = New System.Windows.Forms.RadioButton()
        Me.gbSql = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBd = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbSql.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtusuario
        '
        Me.txtusuario.Location = New System.Drawing.Point(109, 41)
        Me.txtusuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(207, 22)
        Me.txtusuario.TabIndex = 0
        Me.txtusuario.Text = "ssa"
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(109, 69)
        Me.txtContrasena.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtContrasena.Size = New System.Drawing.Size(207, 22)
        Me.txtContrasena.TabIndex = 1
        Me.txtContrasena.Text = "Trucha0122"
        '
        'rbAuthIntegrada
        '
        Me.rbAuthIntegrada.AutoSize = True
        Me.rbAuthIntegrada.Location = New System.Drawing.Point(64, 117)
        Me.rbAuthIntegrada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbAuthIntegrada.Name = "rbAuthIntegrada"
        Me.rbAuthIntegrada.Size = New System.Drawing.Size(213, 21)
        Me.rbAuthIntegrada.TabIndex = 3
        Me.rbAuthIntegrada.Text = "   Autentificación de Windows"
        Me.rbAuthIntegrada.UseVisualStyleBackColor = True
        '
        'rbAuthSql
        '
        Me.rbAuthSql.AutoSize = True
        Me.rbAuthSql.Checked = True
        Me.rbAuthSql.Location = New System.Drawing.Point(64, 166)
        Me.rbAuthSql.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbAuthSql.Name = "rbAuthSql"
        Me.rbAuthSql.Size = New System.Drawing.Size(17, 16)
        Me.rbAuthSql.TabIndex = 4
        Me.rbAuthSql.TabStop = True
        Me.rbAuthSql.UseVisualStyleBackColor = True
        '
        'gbSql
        '
        Me.gbSql.Controls.Add(Me.Label2)
        Me.gbSql.Controls.Add(Me.Label1)
        Me.gbSql.Controls.Add(Me.txtusuario)
        Me.gbSql.Controls.Add(Me.txtContrasena)
        Me.gbSql.Location = New System.Drawing.Point(87, 162)
        Me.gbSql.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSql.Name = "gbSql"
        Me.gbSql.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSql.Size = New System.Drawing.Size(348, 122)
        Me.gbSql.TabIndex = 5
        Me.gbSql.TabStop = False
        Me.gbSql.Text = "Autentificación de SQL Server"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuario"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(128, 48)
        Me.txtServidor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(276, 22)
        Me.txtServidor.TabIndex = 4
        Me.txtServidor.Text = "192.168.1.130\SQLEXPRESS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Servidor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "BD"
        '
        'txtBd
        '
        Me.txtBd.Location = New System.Drawing.Point(128, 76)
        Me.txtBd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBd.Name = "txtBd"
        Me.txtBd.Size = New System.Drawing.Size(276, 22)
        Me.txtBd.TabIndex = 6
        Me.txtBd.Text = "LA"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Generador.My.Resources.Resources.dialog_apply
        Me.btnAceptar.Location = New System.Drawing.Point(337, 331)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(131, 63)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aplicar"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Generador.My.Resources.Resources.dialog_cancel_3
        Me.btnCancelar.Location = New System.Drawing.Point(25, 331)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(131, 63)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 4.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(61, 301)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(326, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "* Esta configuración se usará por defecto la proxima vez que inicie la aplicación" & _
    ""
        '
        'frmConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 417)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.gbSql)
        Me.Controls.Add(Me.rbAuthSql)
        Me.Controls.Add(Me.rbAuthIntegrada)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmConexion"
        Me.Text = "frmConexion"
        Me.gbSql.ResumeLayout(False)
        Me.gbSql.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtusuario As System.Windows.Forms.TextBox
    Private WithEvents txtContrasena As System.Windows.Forms.TextBox
    Private WithEvents rbAuthIntegrada As System.Windows.Forms.RadioButton
    Private WithEvents rbAuthSql As System.Windows.Forms.RadioButton
    Private WithEvents gbSql As System.Windows.Forms.GroupBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtServidor As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtBd As System.Windows.Forms.TextBox
    Private WithEvents btnAceptar As System.Windows.Forms.Button
    Private WithEvents btnCancelar As System.Windows.Forms.Button
    Private WithEvents Label5 As System.Windows.Forms.Label
End Class
