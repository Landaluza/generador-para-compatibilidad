Public Class login
    Private drm As GUI
    Private DatabaseConfig As DatabaseConfig
    Public Sub New()
        InitializeComponent()

        DatabaseConfig = New DatabaseConfig
        Try
            DatabaseConfig = DatabaseConfig.load
        Catch ex As Exception
            DatabaseConfig = New DatabaseConfig
        End Try

        drm = New GUI(False, Me.DatabaseConfig)

    End Sub
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        acceder()
    End Sub

    Private Sub login_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            acceder()
        End If
    End Sub

    Private Sub acceder()
        If Me.txtuser.Text = "mam" And Me.txtpass.Text = "trucha0121" Then
            drm.Show()
            Me.Hide()
        Else
                MessageBox.Show("Datos incorrectos", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class