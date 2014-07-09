Public Class RegCampo
    Public nombre As String 'Number
    Public tipo As String 'Type
    Public EsLlave As Boolean '
    Public EsObligatorio As Boolean
    Public EsUnico As Boolean
    Public CaracterMaximo As Integer
    Public CaracterMinimo As Integer
    Public Fecha As Boolean
    Public EsObligatorioPorUsuario As Boolean

    Public TablaForanea As String
    Public CampoIDForaneo As String
    Public CampoForaneo As String

    Public MostrarEnGrilla As Boolean
    Public IsNullable As Boolean
    Public IsKey As Boolean
    Public IsIdentity As Boolean
    Public SQLType As String
    Public Precision As Integer
    Public Scale As Integer

    Public Ver As Boolean
    Public Add As Boolean
    Public fechaCreacion As Date
End Class
