

<Serializable()> Public Class Options
    Public Ruta As String
    Private SavePath As String
    Public Tabla As String
    Public Ejecutar As Boolean
    Public Combo As Boolean
    Public Versionar As Boolean
    Public Version As String

    Public Sub New()
        Me.SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\genoptions.obj"
    End Sub

    Public Sub save()
        Dim ser As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        Using fs As New IO.StreamWriter(SavePath, False)
            ser.Serialize(fs.BaseStream, Me)
        End Using
    End Sub

    Public Function load() As Options
        Dim ser As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim obj As Options = Nothing

        If System.IO.File.Exists(SavePath) Then
            Using fs As New IO.StreamReader(SavePath)
                Try
                    obj = ser.Deserialize(fs.BaseStream)
                Catch ex As Exception
                    obj = New Options
                End Try
            End Using
        Else
            obj = New Options
        End If

        Return obj
    End Function
End Class
