Imports System.IO

Public Class StoredProcedure
    Inherits GeneratorFile
    Implements Writable

    Private m_org_clase As String
    Private combo As String
    Private tabla As String

    Public Sub New(ByVal tabla As String, ByVal m_ruta As String, ByVal arrEstructura As Generic.List(Of RegCampo), ByVal m_clase As String, ByVal m_org_clase As String, Optional ByVal combo As String = "")
        MyBase.New(m_ruta, arrEstructura, m_clase)
        Me.m_org_clase = m_org_clase
        Me.combo = combo
        Me.tabla = tabla
    End Sub

    Public Property org_clase As String
        Get
            Return m_org_clase
        End Get
        Set(ByVal value As String)
            m_org_clase = value
        End Set
    End Property

    Public Function crear_batch() As Boolean
        Try
            Dim name As String = m_ruta & m_clase & "Batch" & ".sql"
            Dim strFileSize As String = ""
            Dim di As New IO.DirectoryInfo(m_ruta)
            Dim aryFi As IO.FileInfo() = di.GetFiles("*.sql")
            Dim fi As IO.FileInfo

            FileOpen(libre, name, OpenMode.Output)

            For Each fi In aryFi
                Dim value As String = File.ReadAllText(fi.FullName)
                PrintLine(libre, value)
                PrintLine(libre, "GO")
            Next

            FileClose(libre)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub SelectDgvBy_sql(ByVal filtro As String, ByVal maestro As Boolean, ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------SELECT-Filter stored procedure--------------------------------------------------------------------------
        If maestro = True And filtro <> "" Then
            Dim jLoop As Integer = 0
            Dim jKey As Integer = 0
            Dim jIdentity As Integer = 0
            DataBase.DeleteSP(m_clase & "SelectDgvBy", DataBase.CadenaConexion)
            FileOpen(libre, m_ruta & m_clase & "SelectDgvBy.sql", OpenMode.Output)
            PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "SelectDgvBy]")
            For Each reg In m_arrEstructura
                If reg.nombre = filtro Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
            Next

            PrintLine(libre, "AS ")
            PrintLine(libre, "BEGIN")
            PrintLine(libre, "SELECT")
            jLoop = 0

            For Each reg In m_arrEstructura
                If reg.nombre <> "UsuarioModificacion" And reg.nombre <> "FechaModificacion" And reg.nombre <> filtro Then
                    If reg.CampoForaneo <> "" Then
                        If jLoop = 0 Then
                            If Mid(reg.nombre, (Len(reg.nombre) - 1)) = "ID" Then
                                PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & Mid(reg.nombre, 1, (Len(reg.nombre) - 2)))
                            Else
                                PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & reg.nombre)
                            End If
                        Else
                            If Mid(reg.nombre, (Len(reg.nombre) - 1)) = "ID" Then
                                PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & Mid(reg.nombre, 1, (Len(reg.nombre) - 2)))
                            Else
                                PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & reg.nombre)
                            End If
                        End If
                    Else
                        If jLoop = 0 Then
                            PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "]")
                        Else
                            PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "]")
                        End If
                    End If
                    jLoop = jLoop + 1
                End If
            Next

            PrintLine(libre, "FROM")
            PrintLine(libre, "     [dbo].[" & tabla & "]")

            For Each reg In m_arrEstructura
                If reg.CampoForaneo <> "" Then
                    PrintLine(libre, "     INNER JOIN [dbo].[" & reg.TablaForanea & "] ON [dbo].[" & m_org_clase & "].[" & reg.nombre & "] = [dbo].[" & reg.TablaForanea & "].[" & reg.CampoIDForaneo & "]")
                End If
            Next

            PrintLine(libre, "WHERE")
            PrintLine(libre, "     [dbo].[" & tabla & "].[" & filtro & "] = @" & filtro & "")
            PrintLine(libre, "End")
            FileClose(libre)

            If run Then DataBase.ExecuteSP(m_ruta & m_clase & "SelectDgvBy.sql", DataBase.CadenaConexion)

            FileOpen(libre, m_ruta & m_clase & "SelectDgvBy.sql", OpenMode.Output)
            PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & m_clase & "SelectDgvBy]') AND type in (N'P', N'PC'))")
            PrintLine(libre, "DROP PROCEDURE [dbo].[" & m_clase & "SelectDgvBy]")
            PrintLine(libre, "GO")
            PrintLine(libre, "SET ANSI_NULLS ON")
            PrintLine(libre, "GO")
            PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
            PrintLine(libre, "GO")
            PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "SelectDgvBy]")

            For Each reg In m_arrEstructura
                If reg.nombre = filtro Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
            Next

            PrintLine(libre, "AS ")
            PrintLine(libre, "BEGIN")
            PrintLine(libre, "SELECT")
            jLoop = 0

            For Each reg In m_arrEstructura
                If reg.nombre <> "UsuarioModificacion" And reg.nombre <> "FechaModificacion" And reg.nombre <> filtro Then
                    If reg.CampoForaneo <> "" Then
                        If jLoop = 0 Then
                            If Mid(reg.nombre, (Len(reg.nombre) - 1)) = "ID" Then
                                PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & Mid(reg.nombre, 1, (Len(reg.nombre) - 2)))
                            Else
                                PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & reg.nombre)
                            End If
                        Else
                            If Mid(reg.nombre, (Len(reg.nombre) - 1)) = "ID" Then
                                PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & Mid(reg.nombre, 1, (Len(reg.nombre) - 2)))
                            Else
                                PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "] AS " & reg.nombre)
                            End If
                        End If
                    Else
                        If jLoop = 0 Then
                            PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "]")
                        Else
                            PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "]")
                        End If
                    End If
                    jLoop = jLoop + 1
                End If
            Next

            PrintLine(libre, "FROM")
            PrintLine(libre, "     [dbo].[" & tabla & "]")

            For Each reg In m_arrEstructura
                If reg.CampoForaneo <> "" Then
                    PrintLine(libre, "     INNER JOIN [dbo].[" & reg.TablaForanea & "] ON [dbo].[" & m_org_clase & "].[" & reg.nombre & "] = [dbo].[" & reg.TablaForanea & "].[" & reg.CampoIDForaneo & "]")
                End If
            Next

            PrintLine(libre, "WHERE")
            PrintLine(libre, "     [dbo].[" & tabla & "].[" & filtro & "] = @" & filtro & "")
            PrintLine(libre, "")
            PrintLine(libre, "End")
            FileClose(libre)
            'My.Computer.FileSystem.DeleteFile(m_ruta & m_clase & "SelectDgvBy.sql")
        End If
    End Sub

    Public Sub SelectAll_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------SELECT-ALL stored procedure--------------------------------------------------------------------------
        Dim iLoop As Integer = 0
        DataBase.DeleteSP(m_clase & "SelectAll", DataBase.CadenaConexion)
        FileOpen(libre, m_ruta & m_clase & "SelectAll.sql", OpenMode.Output)
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "SelectAll]")
        PrintLine(libre, "AS ")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "SELECT")
        iLoop = 0
        For Each reg In m_arrEstructura
            If reg.CampoForaneo <> "" Then
                If iLoop = 0 Then
                    PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                Else
                    PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                End If
            Else
                If iLoop = 0 Then
                    PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "]")
                Else
                    PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "]")
                End If
            End If
            iLoop = iLoop + 1
        Next

        PrintLine(libre, "FROM")
        PrintLine(libre, "     [dbo].[" & tabla & "]")

        For Each reg In m_arrEstructura
            If reg.CampoForaneo <> "" Then
                PrintLine(libre, "     INNER JOIN [dbo].[" & reg.TablaForanea & "] ON [dbo].[" & m_org_clase & "].[" & reg.nombre & "] = [dbo].[" & reg.TablaForanea & "].[" & reg.CampoIDForaneo & "]")
            End If
        Next

        PrintLine(libre, "End")
        FileClose(libre)
        If run Then DataBase.ExecuteSP(m_ruta & m_clase & "SelectAll.sql", DataBase.CadenaConexion)


        FileOpen(libre, m_ruta & m_clase & "SelectAll.sql", OpenMode.Output)
        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & m_clase & "SelectAll]') AND type in (N'P', N'PC'))")
        PrintLine(libre, "DROP PROCEDURE [dbo].[" & m_clase & "SelectAll]")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET ANSI_NULLS ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "SelectAll]")
        PrintLine(libre, "AS ")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "SELECT")
        iLoop = 0
        For Each reg In m_arrEstructura
            If reg.CampoForaneo <> "" Then
                If iLoop = 0 Then
                    PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                Else
                    PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                End If
            Else
                If iLoop = 0 Then
                    PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "]")
                Else
                    PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "]")
                End If
            End If
            iLoop = iLoop + 1
        Next

        PrintLine(libre, "FROM")
        PrintLine(libre, "     [dbo].[" & tabla & "]")

        For Each reg In m_arrEstructura
            If reg.CampoForaneo <> "" Then
                PrintLine(libre, "     INNER JOIN [dbo].[" & reg.TablaForanea & "] ON [dbo].[" & m_org_clase & "].[" & reg.nombre & "] = [dbo].[" & reg.TablaForanea & "].[" & reg.CampoIDForaneo & "]")
            End If
        Next

        PrintLine(libre, "End")
        FileClose(libre)
        'My.Computer.FileSystem.DeleteFile(m_ruta & m_clase & "SelectAll.sql")
    End Sub

    Public Sub Select_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------SELECT stored procedure--------------------------------------------------------------------------
        Dim iLoop As Integer = 0
        Dim iKey As Integer = 0
        Dim iIdentity As Integer = 0
        For Each reg In m_arrEstructura
            If reg.IsKey = True Then
                iKey = iKey + 1
            End If
            If reg.IsIdentity = True Then
                iIdentity = iIdentity + 1
            End If
        Next
        DataBase.DeleteSP(m_clase & "Select", DataBase.CadenaConexion)
        FileOpen(libre, m_ruta & m_clase & "Select.sql", OpenMode.Output)
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "Select]")
        iLoop = 0
        For Each reg In m_arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                Else
                    If reg.tipo = "String" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In m_arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                If reg.tipo = "String" Then
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In m_arrEstructura
                If reg.tipo = "String" Then
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            Next
        End If

        PrintLine(libre, "AS ")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "SELECT")
        iLoop = 0

        For Each reg In m_arrEstructura
            If iLoop = 0 Then
                PrintLine(libre, "      " & reg.nombre & "")
            Else
                PrintLine(libre, "     ," & reg.nombre & "")
            End If
            iLoop = iLoop + 1
        Next

        PrintLine(libre, "FROM")
        PrintLine(libre, "     [dbo].[" & tabla & "]")
        PrintLine(libre, "WHERE")

        iLoop = 0
        For Each reg In m_arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Else
                    PrintLine(libre, "AND [" & reg.nombre & "] = @" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In m_arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In m_arrEstructura
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "End")
        FileClose(libre)
        If run Then DataBase.ExecuteSP(m_ruta & m_clase & "Select.sql", DataBase.CadenaConexion)

        FileOpen(libre, m_ruta & m_clase & "Select.sql", OpenMode.Output)
        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & m_clase & "Select]') AND type in (N'P', N'PC'))")
        PrintLine(libre, "DROP PROCEDURE [dbo].[" & m_clase & "Select]")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET ANSI_NULLS ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "Select]")

        iLoop = 0
        For Each reg In m_arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                Else
                    If reg.tipo = "String" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In m_arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                If reg.tipo = "String" Then
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In m_arrEstructura
                If reg.tipo = "String" Then
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            Next
        End If

        PrintLine(libre, "AS ")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "SELECT")

        iLoop = 0
        For Each reg In m_arrEstructura
            If iLoop = 0 Then
                PrintLine(libre, "      " & reg.nombre & "")
            Else
                PrintLine(libre, "     ," & reg.nombre & "")
            End If
            iLoop = iLoop + 1
        Next

        PrintLine(libre, "FROM")
        PrintLine(libre, "     [dbo].[" & tabla & "]")
        PrintLine(libre, "WHERE")

        iLoop = 0
        For Each reg In m_arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Else
                    PrintLine(libre, "AND [" & reg.nombre & "] = @" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In m_arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In m_arrEstructura
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "End")
        FileClose(libre)
        'My.Computer.FileSystem.DeleteFile(m_ruta & m_clase & "Select.sql")
    End Sub

    Public Sub SelectDgv_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------SELECT-ALL 'Dgv' stored procedure--------------------------------------------------------------------------
        Dim iLoop As Integer = 0
        DataBase.DeleteSP(m_clase & "SelectDgv", DataBase.CadenaConexion)
        FileOpen(libre, m_ruta & m_clase & "SelectDgv.sql", OpenMode.Output)
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "SelectDgv]")
        PrintLine(libre, "AS ")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "SELECT")
        iLoop = 0

        For Each reg In m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                If reg.MostrarEnGrilla = True Then
                    If reg.CampoForaneo <> "" Then
                        If iLoop = 0 Then
                            PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                        Else
                            PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                        End If
                    Else
                        If reg.IsKey Then
                            If iLoop = 0 Then
                                PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "] Id")
                            Else
                                PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "] Id")
                            End If
                        Else
                            If iLoop = 0 Then
                                PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "]")
                            Else
                                PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "]")
                            End If
                        End If
                    End If
                        iLoop = iLoop + 1
                End If
            End If
        Next
        PrintLine(libre, "FROM")
        PrintLine(libre, "     [dbo].[" & tabla & "]")
        For Each reg In m_arrEstructura
            If reg.MostrarEnGrilla = True Then
                If reg.CampoForaneo <> "" And Not reg.IsKey Then
                    PrintLine(libre, "     INNER JOIN [dbo].[" & reg.TablaForanea & "] ON [dbo].[" & tabla & "].[" & reg.nombre & "] = [dbo].[" & reg.TablaForanea & "].[" & reg.CampoIDForaneo & "]")
                End If
            End If
        Next
        PrintLine(libre, "End")
        FileClose(libre)
        If run Then DataBase.ExecuteSP(m_ruta & m_clase & "SelectDgv.sql", DataBase.CadenaConexion)

        FileOpen(libre, m_ruta & m_clase & "SelectDgv.sql", OpenMode.Output)
        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & m_clase & "SelectDgv]') AND type in (N'P', N'PC'))")
        PrintLine(libre, "DROP PROCEDURE [dbo].[" & m_clase & "SelectDgv]")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET ANSI_NULLS ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & m_clase & "SelectDgv]")
        PrintLine(libre, "AS ")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "SELECT")
        iLoop = 0

        For Each reg In m_arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                If reg.MostrarEnGrilla = True Then
                    If reg.CampoForaneo <> "" Then
                        If iLoop = 0 Then
                            PrintLine(libre, "      [dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                        Else
                            PrintLine(libre, "     ,[dbo].[" & reg.TablaForanea & "].[" & reg.CampoForaneo & "]")
                        End If
                    Else
                        If reg.IsKey Then
                            If iLoop = 0 Then
                                PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "] Id")
                            Else
                                PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "] Id")
                            End If
                        Else
                            If iLoop = 0 Then
                                PrintLine(libre, "      [dbo].[" & tabla & "].[" & reg.nombre & "]")
                            Else
                                PrintLine(libre, "     ,[dbo].[" & tabla & "].[" & reg.nombre & "]")
                            End If
                        End If
                    End If
                    iLoop = iLoop + 1
                End If
            End If
        Next

        PrintLine(libre, "FROM")
        PrintLine(libre, "     [dbo].[" & tabla & "]")

        For Each reg In m_arrEstructura
            If reg.MostrarEnGrilla = True Then
                If reg.CampoForaneo <> "" And Not reg.IsKey Then
                    PrintLine(libre, "     INNER JOIN [dbo].[" & reg.TablaForanea & "] ON [dbo].[" & tabla & "].[" & reg.nombre & "] = [dbo].[" & reg.TablaForanea & "].[" & reg.CampoIDForaneo & "]")
                End If
            End If
        Next

        PrintLine(libre, "End")
        FileClose(libre)
        'My.Computer.FileSystem.DeleteFile(m_ruta & m_clase & "SelectDgv.sql")
    End Sub

    Public Sub Insert_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------INSERT stored procedure--------------------------------------------------------------------------
        Dim iLoop As Integer = 0
        DataBase.DeleteSP(clase & "Insert", DataBase.CadenaConexion)
        FileOpen(libre, m_ruta & clase & "Insert.sql", OpenMode.Output)
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Insert]")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If iLoop = 0 Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    ElseIf reg.tipo = "Decimal" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                Else
                    If reg.tipo = "String" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    ElseIf reg.tipo = "Decimal" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                    Else
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
                iLoop = iLoop + 1
            End If
        Next

        PrintLine(libre, "     ,@UsuarioModificacion int")
        PrintLine(libre, "     ,@FechaModificacion datetime")
        PrintLine(libre, "AS")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "")
        PrintLine(libre, "SET NOCOUNT ON")
        PrintLine(libre, "")
        PrintLine(libre, "INSERT INTO [dbo].[" & tabla & "]")
        PrintLine(libre, "     (")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If iLoop = 0 Then
                    PrintLine(libre, "      " & reg.nombre & "")
                Else
                    PrintLine(libre, "     ," & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        'PrintLine(libre, ",UsuarioModificacion, FechaModificacion     )")
        PrintLine(libre, "     ,UsuarioModificacion")
        PrintLine(libre, "     ,FechaModificacion")
        PrintLine(libre, "     )")


        PrintLine(libre, "VALUES")
        PrintLine(libre, "     (")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If iLoop = 0 Then
                    PrintLine(libre, "      @" & reg.nombre & "")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        'PrintLine(libre, ",@UsuarioModificacion, @FechaModificacion     )")
        PrintLine(libre, "     ,@UsuarioModificacion")
        PrintLine(libre, "     ,@FechaModificacion")
        PrintLine(libre, "     )")

        PrintLine(libre, "")
        PrintLine(libre, "END")
        FileClose(libre)
        If run Then DataBase.ExecuteSP(m_ruta & clase & "Insert.sql", DataBase.CadenaConexion)


        FileOpen(libre, m_ruta & clase & "Insert.sql", OpenMode.Output)
        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & clase & "Insert]') AND type in (N'P', N'PC'))")
        PrintLine(libre, "DROP PROCEDURE [dbo].[" & clase & "Insert]")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET ANSI_NULLS ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Insert]")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If iLoop = 0 Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    ElseIf reg.tipo = "Decimal" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                Else
                    If reg.tipo = "String" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    ElseIf reg.tipo = "Decimal" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                    Else
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
                iLoop = iLoop + 1
            End If
        Next

        PrintLine(libre, "     ,@UsuarioModificacion int")
        PrintLine(libre, "     ,@FechaModificacion datetime")
        PrintLine(libre, "AS")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "")
        PrintLine(libre, "SET NOCOUNT ON")
        PrintLine(libre, "")
        PrintLine(libre, "INSERT INTO [dbo].[" & tabla & "]")
        PrintLine(libre, "     (")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If iLoop = 0 Then
                    PrintLine(libre, "      " & reg.nombre & "")
                Else
                    PrintLine(libre, "     ," & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        'PrintLine(libre, ",UsuarioModificacion, FechaModificacion     )")
        PrintLine(libre, "     ,UsuarioModificacion")
        PrintLine(libre, "     ,FechaModificacion")
        PrintLine(libre, "     )")

        PrintLine(libre, "VALUES")
        PrintLine(libre, "     (")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If iLoop = 0 Then
                    PrintLine(libre, "      @" & reg.nombre & "")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        'PrintLine(libre, ",@UsuarioModificacion, @FechaModificacion     )")
        PrintLine(libre, "     ,@UsuarioModificacion")
        PrintLine(libre, "     ,@FechaModificacion")
        PrintLine(libre, "     )")

        PrintLine(libre, "")
        PrintLine(libre, "END")
        FileClose(libre)
        'My.Computer.FileSystem.DeleteFile(m_ruta &clase & "Insert.sql")
    End Sub

    Public Sub Update_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------UPDATE stored procedure--------------------------------------------------------------------------
        Dim iLoop As Integer = 0
        Dim iKey As Integer = 0
        Dim iIdentity As Integer = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                iKey = iKey + 1
            End If
            If reg.IsIdentity = True Then
                iIdentity = iIdentity + 1
            End If
        Next
        DataBase.DeleteSP(clase & "Update", DataBase.CadenaConexion)
        FileOpen(libre, m_ruta & clase & "Update.sql", OpenMode.Output)
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Update] ")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If reg.IsKey = False Then
                    If iLoop = 0 Then
                        If reg.tipo = "String" Then
                            PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                        ElseIf reg.tipo = "Decimal" Then
                            PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                        Else
                            PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                        End If
                    Else
                        If reg.tipo = "String" Then
                            PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                        ElseIf reg.tipo = "Decimal" Then
                            PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                        Else
                            PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                        End If
                    End If
                    iLoop = iLoop + 1
                End If
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If reg.tipo = "String" Then
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                End If
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                If reg.tipo = "String" Then
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                If reg.tipo = "String" Then
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            Next
        End If

        PrintLine(libre, "     ,@UsuarioModificacion int")
        PrintLine(libre, "     ,@FechaModificacion datetime")
        PrintLine(libre, "AS")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "")
        PrintLine(libre, "SET NOCOUNT ON")
        PrintLine(libre, "")
        PrintLine(libre, "UPDATE [dbo].[" & tabla & "]")
        PrintLine(libre, "SET")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If reg.IsKey = False Then
                    If iLoop = 0 Then
                        PrintLine(libre, "      [" & reg.nombre & "] = @" & reg.nombre & "")
                    Else
                        PrintLine(libre, "     ,[" & reg.nombre & "] = @" & reg.nombre & "")
                    End If
                    iLoop = iLoop + 1
                End If
            End If
        Next

        PrintLine(libre, "     ,UsuarioModificacion = @UsuarioModificacion")
        PrintLine(libre, "     ,Fechamodificacion = @FechaModificacion")

        PrintLine(libre, "WHERE")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Else
                    PrintLine(libre, "AND [" & reg.nombre & "] = @" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "")
        PrintLine(libre, "END")
        FileClose(libre)
        If run Then DataBase.ExecuteSP(m_ruta & clase & "Update.sql", DataBase.CadenaConexion)



        FileOpen(libre, m_ruta & clase & "Update.sql", OpenMode.Output)
        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & clase & "Update]') AND type in (N'P', N'PC'))")
        PrintLine(libre, "DROP PROCEDURE [dbo].[" & clase & "Update]")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET ANSI_NULLS ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Update] ")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If reg.IsKey = False Then
                    If iLoop = 0 Then
                        If reg.tipo = "String" Then
                            PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                        ElseIf reg.tipo = "Decimal" Then
                            PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                        Else
                            PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                        End If
                    Else
                        If reg.tipo = "String" Then
                            PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                        ElseIf reg.tipo = "Decimal" Then
                            PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.Precision & "," & reg.Scale & ")")
                        Else
                            PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                        End If
                    End If
                    iLoop = iLoop + 1
                End If
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If reg.tipo = "String" Then
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                End If
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                If reg.tipo = "String" Then
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                If reg.tipo = "String" Then
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                Else
                    PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                End If
                Exit For
            Next
        End If

        PrintLine(libre, "     ,@UsuarioModificacion int")
        PrintLine(libre, "     ,@FechaModificacion datetime")
        PrintLine(libre, "AS")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "")
        PrintLine(libre, "SET NOCOUNT ON")
        PrintLine(libre, "")
        PrintLine(libre, "UPDATE [dbo].[" & tabla & "]")

        PrintLine(libre, "SET")
        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsIdentity = False Then
                If reg.IsKey = False Then
                    If iLoop = 0 Then
                        PrintLine(libre, "      [" & reg.nombre & "] = @" & reg.nombre & "")
                    Else
                        PrintLine(libre, "     ,[" & reg.nombre & "] = @" & reg.nombre & "")
                    End If
                    iLoop = iLoop + 1
                End If
            End If
        Next

        PrintLine(libre, "     ,UsuarioModificacion = @UsuarioModificacion")
        PrintLine(libre, "     ,Fechamodificacion = @FechaModificacion")

        PrintLine(libre, "WHERE")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Else
                    PrintLine(libre, "AND [" & reg.nombre & "] = @" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "")
        PrintLine(libre, "END")
        FileClose(libre)
        'My.Computer.FileSystem.DeleteFile(m_ruta &clase & "Update.sql")
    End Sub

    Public Sub Delete_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        '-------------------------------------------------DELETE stored procedure--------------------------------------------------------------------------
        Dim iLoop As Integer = 0
        Dim iKey As Integer = 0
        Dim iIdentity As Integer = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                iKey = iKey + 1
            End If
            If reg.IsIdentity = True Then
                iIdentity = iIdentity + 1
            End If
        Next
        DataBase.DeleteSP(clase & "Delete", DataBase.CadenaConexion)
        FileOpen(libre, m_ruta & clase & "Delete.sql", OpenMode.Output)
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Delete] ")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                Else
                    If reg.tipo = "String" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "      @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                PrintLine(libre, "      @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "AS")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "")
        PrintLine(libre, "SET NOCOUNT ON")
        PrintLine(libre, "")
        PrintLine(libre, "")
        PrintLine(libre, "DELETE FROM [dbo].[" & tabla & "]")
        PrintLine(libre, "WHERE")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Else
                    PrintLine(libre, "AND [" & reg.nombre & "] = @" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "")
        PrintLine(libre, "")
        PrintLine(libre, "END")
        FileClose(libre)
        If run Then DataBase.ExecuteSP(m_ruta & clase & "Delete.sql", DataBase.CadenaConexion)



        FileOpen(libre, m_ruta & clase & "Delete.sql", OpenMode.Output)
        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & clase & "Delete]') AND type in (N'P', N'PC'))")
        PrintLine(libre, "DROP PROCEDURE [dbo].[" & clase & "Delete]")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET ANSI_NULLS ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
        PrintLine(libre, "GO")
        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Delete] ")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    If reg.tipo = "String" Then
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "      @" & reg.nombre & " " & reg.SQLType & "")
                    End If
                Else
                    If reg.tipo = "String" Then
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "(" & reg.CaracterMaximo & ")")
                    Else
                        PrintLine(libre, "     ,@" & reg.nombre & " " & reg.SQLType & "")
                    End If
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "      @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                PrintLine(libre, "      @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "AS")
        PrintLine(libre, "BEGIN")
        PrintLine(libre, "")
        PrintLine(libre, "SET NOCOUNT ON")
        PrintLine(libre, "")
        PrintLine(libre, "")
        PrintLine(libre, "DELETE FROM [dbo].[" & tabla & "]")
        PrintLine(libre, "WHERE")

        iLoop = 0
        For Each reg In arrEstructura
            If reg.IsKey = True Then
                If iLoop = 0 Then
                    PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Else
                    PrintLine(libre, "AND [" & reg.nombre & "] = @" & reg.nombre & "")
                End If
                iLoop = iLoop + 1
            End If
        Next

        For Each reg In arrEstructura
            If reg.IsKey = False And reg.IsIdentity = True Then
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            End If
        Next

        If iKey = 0 And iIdentity = 0 Then
            For Each reg In arrEstructura
                PrintLine(libre, "    [" & reg.nombre & "] = @" & reg.nombre & "")
                Exit For
            Next
        End If

        PrintLine(libre, "")
        PrintLine(libre, "END")
        FileClose(libre)
        'My.Computer.FileSystem.DeleteFile(m_ruta &clase & "Delete.sql")
    End Sub

    Public Sub Cbo_sql(ByVal seraForanea As Boolean, ByVal foranea As String, ByVal run As Boolean)
        Dim reg As RegCampo

        If seraForanea Then
            If foranea <> "" Then
                For Each reg In arrEstructura
                    If reg.IsKey = True Then
                        DataBase.DeleteSP(clase & "Cbo", DataBase.CadenaConexion)
                        FileOpen(libre, m_ruta & clase & "Cbo.sql", OpenMode.Output)
                        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Cbo]")
                        PrintLine(libre, "AS ")
                        PrintLine(libre, "BEGIN")
                        PrintLine(libre, "SELECT")
                        PrintLine(libre, "      " & reg.nombre & "")
                        PrintLine(libre, "     ," & foranea & "")
                        PrintLine(libre, "FROM")
                        PrintLine(libre, "     [dbo].[" & tabla & "]")
                        PrintLine(libre, "End")
                        FileClose(libre)
                        If run Then DataBase.ExecuteSP(m_ruta & clase & "Cbo.sql", DataBase.CadenaConexion)
                        '''''''
                        FileOpen(libre, m_ruta & clase & "Cbo.sql", OpenMode.Output)
                        PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & clase & "Cbo]') AND type in (N'P', N'PC'))")
                        PrintLine(libre, "DROP PROCEDURE [dbo].[" & clase & "Cbo]")
                        PrintLine(libre, "GO")
                        PrintLine(libre, "SET ANSI_NULLS ON")
                        PrintLine(libre, "GO")
                        PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
                        PrintLine(libre, "GO")
                        PrintLine(libre, "CREATE PROCEDURE [dbo].[" & clase & "Cbo]")
                        PrintLine(libre, "AS ")
                        PrintLine(libre, "BEGIN")
                        PrintLine(libre, "SELECT")
                        PrintLine(libre, "      " & reg.nombre & "")
                        PrintLine(libre, "     ," & foranea & "")
                        PrintLine(libre, "FROM")
                        PrintLine(libre, "     [dbo].[" & tabla & "]")
                        PrintLine(libre, "End")
                        FileClose(libre)
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub Foraneo_Cbo_sql(ByVal run As Boolean)
        Dim reg As RegCampo

        For Each reg In arrEstructura
            If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                If reg.TablaForanea <> "Empleados" Then
                    DataBase.DeleteSP(reg.TablaForanea & "Cbo", DataBase.CadenaConexion)
                    FileOpen(libre, m_ruta & reg.TablaForanea & "Cbo.sql", OpenMode.Output)
                    PrintLine(libre, "CREATE PROCEDURE [dbo].[" & reg.TablaForanea & "Cbo]")
                    PrintLine(libre, "AS ")
                    PrintLine(libre, "BEGIN")
                    PrintLine(libre, "SELECT")
                    PrintLine(libre, "      " & reg.CampoIDForaneo & "")
                    If reg.CampoIDForaneo = reg.CampoForaneo Then
                        PrintLine(libre, "     ," & reg.CampoIDForaneo & " As " & reg.CampoIDForaneo & "1")
                    Else
                        PrintLine(libre, "     ," & reg.CampoForaneo & "")
                    End If
                    PrintLine(libre, "FROM")
                    PrintLine(libre, "     [dbo].[" & reg.TablaForanea & "]")
                    PrintLine(libre, "ORDER BY")
                    PrintLine(libre, "     " & reg.CampoForaneo & "")
                    PrintLine(libre, "End")
                    FileClose(libre)
                    If run Then DataBase.ExecuteSP(m_ruta & reg.TablaForanea & "Cbo.sql", DataBase.CadenaConexion)
                    '''''''
                    FileOpen(libre, m_ruta & reg.TablaForanea & "Cbo.sql", OpenMode.Output)
                    PrintLine(libre, "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" & reg.TablaForanea & "Cbo]') AND type in (N'P', N'PC'))")
                    PrintLine(libre, "DROP PROCEDURE [dbo].[" & reg.TablaForanea & "Cbo]")
                    PrintLine(libre, "GO")
                    PrintLine(libre, "SET ANSI_NULLS ON")
                    PrintLine(libre, "GO")
                    PrintLine(libre, "SET QUOTED_IDENTIFIER ON")
                    PrintLine(libre, "GO")
                    PrintLine(libre, "CREATE PROCEDURE [dbo].[" & reg.TablaForanea & "Cbo]")
                    PrintLine(libre, "AS ")
                    PrintLine(libre, "BEGIN")
                    PrintLine(libre, "SELECT")
                    PrintLine(libre, "      " & reg.CampoIDForaneo & "")
                    If reg.CampoIDForaneo = reg.CampoForaneo Then
                        PrintLine(libre, "     ," & reg.CampoIDForaneo & " As " & reg.CampoIDForaneo & "1")
                    Else
                        PrintLine(libre, "     ," & reg.CampoForaneo & "")
                    End If
                    PrintLine(libre, "FROM")
                    PrintLine(libre, "     [dbo].[" & reg.TablaForanea & "]")
                    PrintLine(libre, "ORDER BY")
                    PrintLine(libre, "     " & reg.CampoForaneo & "")
                    PrintLine(libre, "End")
                    FileClose(libre)
                End If
            End If
        Next
    End Sub

    Public Sub generateSqlFile(ByVal filtro As String, ByVal maestro As Boolean, ByVal seraForanea As Boolean, ByVal foranea As String, ByVal runProcedures As Boolean)
        SelectDgvBy_sql(filtro, maestro, runProcedures)
        'SelectAll_sql(runProcedures)
        SelectDgv_sql(runProcedures)
        Select_sql(runProcedures)
        Insert_sql(runProcedures)
        Update_sql(runProcedures)
        Delete_sql(runProcedures)
        If Me.combo <> "" Then Cbo_sql(seraForanea, foranea, runProcedures)
        'Foraneo_Cbo_sql(runProcedures)
        crear_batch()
    End Sub

    Public Sub generateFile() Implements Writable.generateFile
        Dim reg As RegCampo = MyBase.key
        Dim strKey As String = Nothing

        If File.Exists(Me.m_ruta & "sp" & clase & ".vb") Then File.Delete(Me.m_ruta & "sp" & clase & ".vb")
        FileOpen(libre, Me.m_ruta & "sp" & clase & ".vb", OpenMode.Output)

        'PrintLine(libre, "Imports System.Data.SqlClient")
        If Me.combo <> "" Then
            PrintLine(libre, "Imports BasesParaCompatibilidad.ComboBoxExtension ")
        End If
        PrintLine(libre, "")
        PrintLine(libre, "Public Class sp" & clase)
        PrintLine(libre, "Inherits BasesParaCompatibilidad.StoredProcedure")
        PrintLine(libre, "")
        '''''''

        strKey = strKey & "ByVal " & key.nombre & " As " & GetDotNetDataType(key.tipo) & ", "


        If strKey.Length > 0 Then
            strKey = Trim(strKey)
            strKey = Mid(strKey, 1, (Len(strKey) - 1))
        End If

        PrintLine(libre, TAB(4), "Public Sub new()")
        PrintLine(libre, TAB(8), "MyBase.New( ""[dbo].[" & clase & "Select]"",  _")
        PrintLine(libre, TAB(8), "              ""[dbo].[" & clase & "Insert]"",  _")
        PrintLine(libre, TAB(8), "              ""[dbo].[" & clase & "Update]"",  _")
        PrintLine(libre, TAB(8), "              ""[dbo].[" & clase & "Delete]"",  _")
        PrintLine(libre, TAB(8), "              ""[dbo].[" & clase & "SelectDgv]"",  _")
        PrintLine(libre, TAB(8), "              ""[dbo].[" & clase & "SelectDgvBy]"")")
        PrintLine(libre, TAB(4), "End Sub")
        PrintLine(libre, "")

        PrintLine(libre, TAB(4), "Public Overloads Function Select_Record(" & strKey & ", ByRef  dtb As BasesParaCompatibilidad.DataBase) As DBO_" & clase)
        PrintLine(libre, TAB(8), "Dim dbo As New DBO_" & clase)
        PrintLine(libre, TAB(8), "dbo.searchKey = dbo.item(""" & reg.nombre & """)")
        PrintLine(libre, TAB(8), "dbo.searchKey.value = " & reg.nombre)
        PrintLine(libre, TAB(8), "MyBase.Select_Record(ctype(dbo, BasesParaCompatibilidad.Databussines), dtb)")
        PrintLine(libre, TAB(8), "Return dbo")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, "")

        PrintLine(libre, TAB(4), "Public Overrides Function Delete(" & strKey & ", ByRef  dtb As BasesParaCompatibilidad.DataBase) As Boolean")
        PrintLine(libre, TAB(8), "Dim dbo As New DBO_" & clase)
        PrintLine(libre, TAB(8), "dbo.searchKey = dbo.item(""" & reg.nombre & """)")
        PrintLine(libre, TAB(8), "dbo.searchKey.value = " & reg.nombre)
        PrintLine(libre, TAB(8), "return MyBase.DeleteProcedure(ctype(dbo, BasesParaCompatibilidad.Databussines), dtb)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, "")

        If Me.combo <> "" Then
            PrintLine(libre, TAB(4), "Public Sub cargar_" & clase & "(ByRef cbo As ComboBox)")
            PrintLine(libre, TAB(8), "cbo.mam_DataSource(""" & clase & "Cbo"", False)")
            PrintLine(libre, TAB(4), "End Sub")
            PrintLine(libre, "")
        End If

        'For Each reg In arrEstructura
        '    If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
        '        If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then

        '            PrintLine(libre, TAB(4), "Public Sub cargar_" & reg.TablaForanea & "(ByRef cbo As ComboBox)")

        '            If reg.TablaForanea = "Empleados" Then
        '                'PrintLine(libre, TAB(8), If(Generador.guest, "'", "") & "Me.cbo" & reg.nombre & ".mam_DataSource(""" & "EmpleadosSelect" & "Cbo"", False)")
        '                'PrintLine(libre, TAB(8), "s.cargar_empleados")
        '                PrintLine(libre, TAB(8), "cbo.mam_DataSource(""EmpleadosSelectCbo"", False)")
        '            Else
        '                'PrintLine(libre, TAB(8), If(Generador.guest, "'", "") & "Me.cbo" & reg.nombre & ".mam_DataSource(""" & reg.TablaForanea & "Cbo"", False)")
        '                'PrintLine(libre, TAB(8), "s.cargar_" & reg.TablaForanea)
        '                PrintLine(libre, TAB(8), "cbo.mam_DataSource(""" & reg.TablaForanea & "Cbo"", False)")
        '            End If
        '            PrintLine(libre, TAB(4), "End Sub")
        '            PrintLine(libre, "")
        '        End If
        '    End If
        'Next
        'PrintLine(libre, TAB(4), "Public Function Grabar" &clase & "(ByVal dbo_" &clase & " As DBO_" &clase & ",, Optional ByRef trans As SqlTransaction = Nothing) as boolean")


        'PrintLine(libre, TAB(8), "If dbo_" &clase & "." & key.nombre & " = 0 Then")


        'PrintLine(libre, TAB(12), "return MyBase.InsertProcedure(dbo_" &clase & ", ""[dbo].[" &clase & "Insert]"", trans)")
        'PrintLine(libre, TAB(8), "Else")
        'PrintLine(libre, TAB(12), "return MyBase.UpdateProcedure(dbo_" &clase & ", ""[dbo].[" &clase & "Insert]"", trans)")
        'PrintLine(libre, TAB(8), "End If")
        'PrintLine(libre, TAB(4), "End Function")
        'PrintLine(libre, "")

        PrintLine(libre, "End Class")
        FileClose(libre)

    End Sub

End Class
