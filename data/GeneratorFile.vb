Public Class GeneratorFile
    Protected m_ruta As String
    Protected m_arrEstructura As Generic.List(Of RegCampo)
    Protected key As RegCampo
    Protected libre As Integer
    Protected m_clase As String

    Public Sub New(ByVal ruta As String, ByVal arrEstructura As Generic.List(Of RegCampo), ByVal clase As String)
        m_ruta = ruta
        m_arrEstructura = arrEstructura
        m_clase = clase
        libre = FreeFile()
        findKey()
    End Sub

    Protected Sub findKey()
        Dim reg As New RegCampo

        For Each reg In m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                If reg.IsIdentity Then
                    Me.key = reg
                    Exit For
                End If
            End If
        Next
    End Sub

    Public Property arrEstructura As Generic.List(Of RegCampo)
        Get
            Return m_arrEstructura
        End Get
        Set(ByVal value As Generic.List(Of RegCampo))
            m_arrEstructura = value
        End Set
    End Property

    Public Property clase As String
        Get
            Return m_clase
        End Get
        Set(ByVal value As String)
            m_clase = value
        End Set
    End Property

    Public Property ruta As String
        Get
            Return m_ruta
        End Get
        Set(ByVal value As String)
            m_ruta = value
        End Set
    End Property
End Class
