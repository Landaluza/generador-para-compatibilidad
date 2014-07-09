Module modulo1
    Public gnombre As String
    Public gtipo As String
    Public gEsLlave As Boolean
    Public gEsObligatorio As Boolean
    Public gEsUnico As Boolean
    Public gCaracterMaximo As Integer
    Public gCaracterMinimo As Integer
    Public gFecha As Boolean
    Public gGenerar As Boolean = False
    Public gCancelarTodo As Boolean = False
    Public gNombreTabla As String
    Public gNombreTablaEspacios As String
    Public gNombreServidor As String
    Public gNombreDatabase As String

    Public Function NumeroVersion() As String
        Dim ourVersion As String

        '//if running the deployed application, you can get the version from the ApplicationDeployment information. If you try
        '//to access this when you are running in Visual Studio, it will not work.

        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            ourVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        Else
            ourVersion = My.Application.Info.Version.ToString 'Si estamos en Visual Basic se muestra el numero <Assembly: AssemblyFileVersion("1.0.0.19")> del fichero AssemblyInfo.vb
        End If

        Return ourVersion
    End Function

End Module
