<Serializable()> Public Class DatabaseConfig
    Public DatabaseName As String
    Public Server As String
    Public DatabaseUser As String
    Public DatabasePassword As String
    Public AuthIntegrated As Boolean
    Private SavePath As String


    Public Sub New()
        Me.SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\genconfig.obj"
    End Sub

    Public Sub save()
        Dim ser As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        Using fs As New IO.StreamWriter(SavePath, False)
            ser.Serialize(fs.BaseStream, Me)
        End Using
    End Sub

    Public Function load() As DatabaseConfig
        Dim ser As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim obj As DatabaseConfig = Nothing

        Using fs As New IO.StreamReader(SavePath)
            obj = ser.Deserialize(fs.BaseStream)
        End Using

        Return obj
    End Function
End Class
