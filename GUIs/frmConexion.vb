Public Class frmConexion
    Private BD As DataBase
    Private DatabaseConfig As DatabaseConfig

    Public ReadOnly Property configuracion As DatabaseConfig
        Get
            Return Me.DatabaseConfig
        End Get
    End Property

    Public Sub New()

        InitializeComponent()

        DatabaseConfig = New DatabaseConfig
        Me.BD = New DataBase()
    End Sub

    Private Sub getvalores()
        DatabaseConfig.AuthIntegrated = Me.rbAuthIntegrada.Checked
        DatabaseConfig.Server = Me.txtServidor.Text
        DatabaseConfig.DatabaseName = Me.txtBd.Text

        If Not DatabaseConfig.AuthIntegrated Then
            DatabaseConfig.DatabasePassword = Me.txtContrasena.Text
            DatabaseConfig.DatabaseUser = Me.txtusuario.Text
        End If
    End Sub

    Private Sub rbAuthIntegrada_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAuthIntegrada.CheckedChanged, rbAuthSql.CheckedChanged
        gbSql.Enabled = rbAuthSql.Checked
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.Cursor = Cursors.WaitCursor

        If Me.BD.testDatabase(txtBd.Text, txtServidor.Text, rbAuthIntegrada.Checked, txtusuario.Text, txtContrasena.Text) Then
            getvalores()

            Me.Cursor = Cursors.Default
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No se pudo conextar con la base de datos, compruebe la conexion", "Imposible conectar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class