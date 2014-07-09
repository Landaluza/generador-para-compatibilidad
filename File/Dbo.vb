Imports System.IO

Public Class Dbo
    Inherits GeneratorFile
    Implements Writable

    Public Sub New(ByVal ruta As String, ByVal arrEstructura As Generic.List(Of RegCampo), clase As String)
        MyBase.new(ruta, arrEstructura, clase)
    End Sub

    Public Sub generateFile() Implements Writable.generateFile

        If File.Exists(m_ruta & "DBO_" & clase & ".vb") Then
            File.Delete(m_ruta & "DBO_" & clase & ".vb")
        End If

        FileOpen(libre, m_ruta & "DBO_" & clase & ".vb", OpenMode.Output)
        PrintLine(libre, "Public Class DBO_" & clase)
        PrintLine(libre, "Inherits BasesParaCompatibilidad.DataBussines")
        PrintLine(libre, "")
        declareAtributes()
        PrintLine(libre, "")
        newSub()
        PrintLine(libre, "")
        declareProperties()
        'PrintLine(libre, "")
        setCollection()
        PrintLine(libre, "End Class")
        FileClose(libre)
    End Sub

    Private Sub newSub()
        Dim reg As New RegCampo

        PrintLine(libre, TAB(4), "Public Sub New()")
        PrintLine(libre, TAB(8), "MyBase.New()")        
        PrintLine(libre, TAB(8), "m_Id = New BasesParaCompatibilidad.DataBussinesParameter(""@" & MyBase.key.nombre & """,""" & MyBase.key.nombre & """)")

        For Each reg In MyBase.m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And reg.nombre <> MyBase.key.nombre Then
                PrintLine(libre, TAB(8), "m_" & reg.nombre & "= New BasesParaCompatibilidad.DataBussinesParameter(""@" & reg.nombre & """,""" & reg.nombre & """)")
            End If
        Next

        PrintLine(libre, TAB(8), "MyBase.primaryKey = m_Id")
        PrintLine(libre, TAB(8), "añadirParametros()")
        PrintLine(libre, TAB(4), "End Sub")
    End Sub

    Private Sub declareAtributes()
        Dim reg As New RegCampo
        PrintLine(MyBase.libre, TAB(4), "Private m_Id As BasesParaCompatibilidad.DataBussinesParameter")

        For Each reg In MyBase.m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And reg.nombre <> MyBase.key.nombre Then
                PrintLine(libre, TAB(4), "Private m_" & reg.nombre & " As BasesParaCompatibilidad.DataBussinesParameter")
            End If
        Next
    End Sub

    Private Sub setCollection()
        Dim reg As New RegCampo

        PrintLine(libre, TAB(4), "Private Sub añadirParametros()")
        PrintLine(libre, TAB(8), "MyBase.atributos.Add(m_Id, m_Id.sqlName)")

        For Each reg In MyBase.m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And reg.nombre <> MyBase.key.nombre Then
                PrintLine(libre, TAB(8), "MyBase.atributos.Add(m_" & reg.nombre & ", m_" & reg.nombre & ".sqlName)")
            End If
        Next

        PrintLine(libre, TAB(4), "End Sub")
    End Sub

    Private Sub declareProperties()
        Dim reg As New RegCampo
        'PrintLine(libre, TAB(0), "'<Tag=[Two][Start]> -- please do not remove this line")
        declareProperty(MyBase.key, True)

        For Each reg In MyBase.m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And reg.nombre <> MyBase.key.nombre Then
                declareProperty(reg, False)
            End If
        Next
        'PrintLine(libre, TAB(0), "'<Tag=[Two][End]> -- please do not remove this line")
    End Sub

    Private Sub declareProperty(ByVal reg As RegCampo, ByVal key As Boolean)

        If key Then
            PrintLine(libre, TAB(4), "Public Property ID() As " & GetDotNetDataType(reg.tipo))
        Else
            PrintLine(libre, TAB(4), "Public Property " & reg.nombre & "() As " & GetDotNetDataType(reg.tipo))
        End If

        'PrintLine(libre, TAB(4), "Public Property " & reg.nombre & "() As " & GetDotNetDataType(reg.tipo))
        PrintLine(libre, TAB(8), "Get")

        Select Case LCase(reg.tipo)
            Case "integer"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return 0")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,integer)")
            Case "int32"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return 0")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,integer)")

                'PrintLine(libre, TAB(12), "Return If(isdbnull(m_" & If(key, "id", reg.nombre) & ".value), Nothing, m_" & If(key, "id", reg.nombre) & ".value)")
            Case "string"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return string.empty")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,string)")
                'PrintLine(libre, TAB(12), "Return If(isdbnull(m_" & If(key, "id", reg.nombre) & ".value), String.empty, m_" & If(key, "id", reg.nombre) & ".value)")
            Case "boolean"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return false")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,boolean)")

                'PrintLine(libre, TAB(12), "Return If(isdbnull(m_" & If(key, "id", reg.nombre) & ".value), false, m_" & If(key, "id", reg.nombre) & ".value)")
            Case "single"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return 0")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,Double)")

                'PrintLine(libre, TAB(12), "Return If(isdbnull(m_" & If(key, "id", reg.nombre) & ".value), Nothing, m_" & If(key, "id", reg.nombre) & ".value)")
            Case "decimal"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return 0")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,Double)")

                'PrintLine(libre, TAB(12), "Return If(isdbnull(m_" & If(key, "id", reg.nombre) & ".value), Nothing, m_" & If(key, "id", reg.nombre) & ".value)")
            Case "date"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return today.date")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,date)")

            Case "timespan"
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return Today.TimeOfDay ")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return ctype(m_" & If(key, "id", reg.nombre) & ".value,timespan)")
                'PrintLine(libre, TAB(12), "Return If(isdbnull(m_" & If(key, "id", reg.nombre) & ".value), today.date,m_" & If(key, "id", reg.nombre) & ".value)")
            Case Else
                PrintLine(libre, TAB(12), "if m_" & If(key, "id", reg.nombre) & ".value is convert.dbnull then")
                PrintLine(libre, TAB(14), "Return nothing ")
                PrintLine(libre, TAB(12), "End if")
                PrintLine(libre, TAB(12), "Return m_" & If(key, "id", reg.nombre) & ".value")
        End Select

        ' PrintLine(libre, TAB(12), "Return m_" & reg.nombre & ".value")
        PrintLine(libre, TAB(8), "End Get")
        PrintLine(libre, TAB(8), "Set(ByVal value As " & GetDotNetDataType(reg.tipo) & ")")
        If key Then PrintLine(libre, TAB(12), "Me.primaryKey.value = value")
        PrintLine(libre, TAB(12), "m_" & If(key, "id", reg.nombre) & ".value = value")
        PrintLine(libre, TAB(8), "End Set")
        PrintLine(libre, TAB(4), "End Property")
        PrintLine(libre, "")
    End Sub


End Class
