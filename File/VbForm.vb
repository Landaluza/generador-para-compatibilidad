Imports System.IO

Public Class VbForm
    Inherits GeneratorFile
    Implements Writable
    Private m_filtro As String
    Private m_maestro As Boolean
    Private filtroMaestro As String


    Public Sub New(ByVal ruta As String, ByRef estructura As Generic.List(Of RegCampo), ByVal clase As String, ByVal filtro As String, ByVal maestro As Boolean, ByVal filtroMaestro As String)
        MyBase.New(ruta, estructura, clase)
        m_filtro = filtro
        m_maestro = maestro
        Me.filtroMaestro = filtroMaestro
    End Sub

    Public Property filtro As String
        Get
            Return m_filtro
        End Get
        Set(ByVal value As String)
            m_filtro = value
        End Set
    End Property

    Public Property maestro As Boolean
        Get
            Return m_maestro
        End Get
        Set(ByVal value As Boolean)
            m_maestro = value
        End Set
    End Property

    Public Sub frm_vb()
        ' txtRuta.Text 'cboFilter.Text
        Dim reg As RegCampo
        Dim strKey As String = Nothing

        '----------------------------------------- CREAR ARCHIVO FORMULARIO ---------------------------------------------
        Dim grilla As String = "dgvGeneral"
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, ruta & "frm" & clase & ".vb", OpenMode.Output)
        PrintLine(libre, "Imports BasesParaCompatibilidad.DataGridViewExtension")
        PrintLine(libre, "Public Class frm" & clase)
        PrintLine(libre, TAB(4), "Inherits BasesParaCompatibilidad.gridsimpleform")
        PrintLine(libre, TAB(4), "Implements BasesParaCompatibilidad.Queriable")
        PrintLine(libre, "")
        'PrintLine(libre, TAB(4), "Dim Titulo As String = """ &clase & """")        
        'PrintLine(libre, TAB(4), "private m_MaestroID As Integer")
        'PrintLine(libre, TAB(4), "private sp" & clase & " As sp" & clase)
        PrintLine(libre, TAB(4), "private dbo" & clase & " As DBO_" & clase)
        'PrintLine(libre, TAB(4), "Dim m_VerID As Boolean = True")
        PrintLine(libre, TAB(8), "")
        PrintLine(libre, TAB(4), "Public Sub New(Optional ByVal MaestroID As Integer = 0)")
        PrintLine(libre, TAB(8), "MyBase.new(new sp" & clase & "(),MaestroID.ToString)")
        PrintLine(libre, TAB(8), "InitializeComponent()")
        'PrintLine(libre, TAB(8), "sp" & clase & " = new sp" & clase)
        ' PrintLine(libre, TAB(8), "MyBase.sp = ctype(sp" & clase & ", storedProcedure)")
        PrintLine(libre, TAB(8), "dbo" & clase & " = new DBO_" & clase)
        ' PrintLine(libre, TAB(8), "m_MaestroID = MaestroID")
        'PrintLine(libre, TAB(8), "If(m_MaestroID = 0 ) then")
        'PrintLine(libre, TAB(12), "sp" & clase & ".DataGridViewStoredProcedure = sp" & clase & ".DataGridViewStoredProcedureForSelect")
        'PrintLine(libre, TAB(8), "Else")
        ' PrintLine(libre, TAB(12), "sp" & clase & ".DataGridViewStoredProcedure = sp" & clase & ".DataGridViewStoredProcedureForFilteredSelect & ""'"" & Me.m_MaestroID & ""'""")
        'PrintLine(libre, TAB(8), "End if")
        PrintLine(libre, TAB(8), "MyBase.newRegForm = ctype(New frmEnt" & clase & "(BasesParaCompatibilidad.GridSimpleForm.ACCION_INSERTAR, ctype(sp, sp" & clase & ")), BasesParaCompatibilidad.DetailedSimpleForm)")
        'PrintLine(libre, TAB(8), "m_VerID = False")
        PrintLine(libre, TAB(4), "End Sub")
        PrintLine(libre, "")


        ''--------------------- LOAD -----------------------
        'PrintLine(libre, TAB(4), "Private Sub frm" & clase & "_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'PrintLine(libre, TAB(8), "butExcel.Visible = True")

        'PrintLine(libre, TAB(4), "End Sub")
        'PrintLine(libre, "")
        '----------------------EVENTOS--------------------------

        PrintLine(libre, TAB(4), "Private Sub Insert_Before() Handles MyBase.BeforeInsert")
        If maestro = True Then
            If filtro <> "" Then
                PrintLine(libre, TAB(12), "MyBase.newRegForm = ctype(New frmEnt" & clase & "(BasesParaCompatibilidad.GridSimpleForm.ACCION_INSERTAR), BasesParaCompatibilidad.DetailedSimpleForm)")

                PrintLine(libre, TAB(12), "dbo" & clase & "." & filtroMaestro & " = m_MaestroID")
            End If
        End If
        PrintLine(libre, TAB(8), "newRegForm.SetDataBussinesObject(ctype(Me.dbo" & clase & ", BasesParaCompatibilidad.databussines))")
        PrintLine(libre, TAB(4), "End Sub")
        PrintLine(libre, "")

        PrintLine(libre, TAB(4), "Private Sub modify_Before() Handles MyBase.BeforeModify")
        
        PrintLine(libre, TAB(8), "dbo" & clase & " =ctype(sp, sp" & clase & ").Select_Record(ctype(dgvGeneral.CurrentRow.Cells(""Id"").Value, integer))")
        PrintLine(libre, TAB(8), "If Not dbo" & clase & " Is Nothing Then")
        If maestro = True Then
            If filtro <> "" Then
                PrintLine(libre, TAB(12), "MyBase.newRegForm = ctype(New frmEnt" & clase & "(BasesParaCompatibilidad.GridSimpleForm.ACCION_MODIFICAR), BasesParaCompatibilidad.DetailedSimpleForm)")
            End If
        End If
        PrintLine(libre, TAB(12), "newRegForm.SetDataBussinesObject(ctype(Me.dbo" & clase & ",BasesParaCompatibilidad.databussines))")
        PrintLine(libre, TAB(8), "Else")
        PrintLine(libre, TAB(12), "MyBase.EventHandeld = True")
        PrintLine(libre, TAB(12), "Messagebox.show(""No se pudo recuperar los datos"",  ""Atención"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)")
        PrintLine(libre, TAB(8), "End If")
        PrintLine(libre, TAB(4), "End Sub")
        PrintLine(libre, "")



        PrintLine(libre, TAB(4), "Protected Overrides Sub BindDataSource() Implements BasesParaCompatibilidad.Queriable.dataGridViewFill")
        PrintLine(libre, TAB(8), "'dim dt as datatable = DataTableFill(Me.sp" & clase & ".DataGridViewStoredProcedure)")
        PrintLine(libre, "")
        PrintLine(libre, TAB(8), "If not datasource Is Nothing Then")
        PrintLine(libre, TAB(8), "GeneralBindingSource.DataSource = datasource")
        PrintLine(libre, TAB(16), "With dgvGeneral")
        PrintLine(libre, TAB(20), ".DataSource = GeneralBindingSource")

        Dim i1 As Integer = 0
        For Each reg In arrEstructura
            If reg.MostrarEnGrilla Then
                If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                    If reg.IsKey = True Then
                        'PrintLine(libre, TAB(16), ".Columns(""" & reg.nombre & """).Visible = False")
                        PrintLine(libre, TAB(16), ".Columns(""Id"").Visible = False")
                    Else

                        If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                            Select Case LCase(reg.tipo)
                                Case "integer"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.Miles, 50)")
                                Case "int32"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.Miles, 50)")
                                Case "string"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.Izquierda, true)")
                                Case "boolean"
                                Case "single"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.Decimal2, 50)")
                                Case "decimal"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.Decimal2, 50)")
                                Case "datetime"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.FechaCorta, 80)")
                                Case "date"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.FechaCorta, 80)")
                                Case "timespan"
                                    PrintLine(libre, TAB(20), ".FormatoColumna(""" & reg.nombre & """, BasesParaCompatibilidad.TiposColumna.Hora, 80)")

                                Case Else
                            End Select
                        ElseIf reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                            If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                                PrintLine(libre, TAB(16), ".FormatoColumna(""" & reg.CampoForaneo & """, BasesParaCompatibilidad.TiposColumna.Izquierda, true)")
                            End If
                        End If
                    End If
                End If
            End If
            i1 = i1 + 1
        Next


        PrintLine(libre, TAB(16), "End With")
        PrintLine(libre, TAB(8), "End If")
        PrintLine(libre, "")
        PrintLine(libre, TAB(4), "End Sub")
        PrintLine(libre, "")

        '--------------------- Grilla Doble Click -----------------------
        'Este SUB ya esta incluido en frmAHeredar
        'PrintLine(libre, TAB(4), "Private Sub " & grilla & "_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles " & grilla & ".MouseDoubleClick")
        'PrintLine(libre, TAB(8), "Modificar()")
        'PrintLine(libre, TAB(4), "End Sub")
        'PrintLine(libre, "")

        '--------------------- Grilla Cambia -----------------------
        'Este SUB ya esta incluido en frmAHeredar
        'PrintLine(libre, TAB(4), "Private Sub " & grilla & "_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles " & grilla & ".RowStateChanged")
        'PrintLine(libre, TAB(8), "dgvGrilla.FormatoGeneral()")
        'PrintLine(libre, TAB(4), "End Sub")
        'PrintLine(libre, "")


        PrintLine(libre, "End Class")
        FileClose(libre)
    End Sub

    Public Sub frmEnt_vb()
        Dim reg As RegCampo
        Dim strKey As String = Nothing

        '----------------------------------------- CREAR ARCHIVO FORMULARIO ENTRADA ---------------------------------------------
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        If Not File.Exists(m_ruta & "frmEnt" & clase & ".vb") Then
            FileOpen(libre, m_ruta & "frmEnt" & clase & ".vb", OpenMode.Output)
            PrintLine(libre, "Public Class frmEnt" & clase)
            PrintLine(libre, TAB(4), "Inherits BasesParaCompatibilidad.DetailedSimpleForm")
            PrintLine(libre, TAB(4), "Implements BasesParaCompatibilidad.Savable")
            PrintLine(libre, TAB(4), "Public Shadows Event afterSave(sender As Object, args As EventArgs) Implements BasesParaCompatibilidad.Savable.afterSave")
            'PrintLine(libre, "")
            'PrintLine(libre, TAB(4), "Private m_Pos As Integer")
            PrintLine(libre, TAB(4), "Private m_DBO_" & clase & " As DBO_" & clase & "")
            'PrintLine(libre, TAB(4), "private sp" &clase & " As sp" &clase)
            'PrintLine(libre, TAB(4), "Dim m_VerID As Boolean = False")
            PrintLine(libre, "")
            'PrintLine(libre, TAB(4), "Public Sub New(ByRef " & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & " As DBO_" &clase & ", ByVal Pos As Integer, ByVal VerID As Boolean)")
            PrintLine(libre, TAB(4), "Public Sub New(ByVal modoDeApertura As String, Optional ByRef v_sp As sp" & clase & " = Nothing, Optional ByRef v_dbo As DBO_" & clase & " = Nothing)")
            PrintLine(libre, TAB(8), "MyBase.new(modoDeApertura, v_sp, ctype(v_dbo, BasesParaCompatibilidad.databussines))")
            PrintLine(libre, TAB(8), "InitializeComponent()")
            PrintLine(libre, TAB(8), "If v_sp Is Nothing then")
            PrintLine(libre, TAB(8), "sp = ctype( New sp" & clase & ",BasesParaCompatibilidad.StoredProcedure)")
            PrintLine(libre, TAB(8), "else")
            PrintLine(libre, TAB(8), "sp = v_sp")
            PrintLine(libre, TAB(8), "End if")
            PrintLine(libre, TAB(8), "m_DBO_" & clase & " = If(v_dbo Is Nothing, New DBO_" & clase & ", v_dbo)")
            PrintLine(libre, TAB(8), "dbo = m_DBO_" & clase)
            'PrintLine(libre, TAB(8), "m_Pos = Pos")
            'PrintLine(libre, TAB(8), "m_VerID = VerID")
            PrintLine(libre, TAB(4), "End Sub")
            PrintLine(libre, "")

            If filtroMaestro = "" Then
                PrintLine(libre, TAB(4), "Public Sub New()")
                PrintLine(libre, TAB(8), "MyBase.new(BasesParaCompatibilidad.GridSimpleForm.ACCION_INSERTAR, ctype(new sp" & clase & ",BasesParaCompatibilidad.storedprocedure), ctype(new DBO_" & clase & ", BasesParaCompatibilidad.databussines))")
                PrintLine(libre, TAB(8), "InitializeComponent()")
                PrintLine(libre, TAB(4), "End Sub")
                PrintLine(libre, "")
            End If

            '--------------------- LOAD -----------------------
            PrintLine(libre, TAB(4), "Private Sub frmEnt" & clase & "_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
            Dim decla As Boolean = False
            Dim cont As Integer = 0

            For Each reg In arrEstructura
                If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        If Not reg.IsKey Then
                            'If Not decla Then
                            PrintLine(libre, TAB(8), "dim s" & cont & " as new sp" & reg.TablaForanea)
                            'decla = True
                            'End If

                            If reg.TablaForanea = "Empleados" Then
                                'PrintLine(libre, TAB(8), "Me.cbo" & reg.nombre & ".mam_DataSource(DataTableFill(""" & "EmpleadosSelect" & "Cbo""), False)")
                                PrintLine(libre, TAB(8), "s" & cont & ".cargar_empleados(Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ")")
                            Else
                                'PrintLine(libre, TAB(8), "Me.cbo" & reg.nombre & ".mam_DataSource(DataTableFill(""" & reg.TablaForanea & "Cbo""), False)")
                                PrintLine(libre, TAB(8), "s" & cont & ".cargar_" & reg.TablaForanea & "(Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ")")
                            End If

                            cont = cont + 1
                        End If
                    End If
                End If
            Next

            PrintLine(libre, TAB(8), "If (me.mododeapertura = VISION) Then")
            For Each reg In arrEstructura
                If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        If Not reg.IsKey Then
                            PrintLine(libre, TAB(12), "Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".enabled = False")
                            PrintLine(libre, TAB(12), "Me.lbl" & reg.nombre & ".enabled = False")
                            PrintLine(libre, TAB(12), "")
                        End If
                    End If
                End If
            Next

            PrintLine(libre, TAB(8), "End If")
            'PrintLine(libre, TAB(8), "ModificarBindingNavigator(""" &clase & "SelectAll"", m_Pos)")
            'PrintLine(libre, TAB(8), " If (Me.Text.Substring(0, 3) = ""Ver"") Then OcultarBindingNavigator()")
            PrintLine(libre, TAB(8), "If Config.userType <> 4 and Config.userType <> 9 Then")
            For Each reg In arrEstructura
                If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        If Not reg.IsKey Then
                            If reg.Add = True Then
                                PrintLine(libre, TAB(4), "butAdd" & reg.nombre & ".enabled = false")
                                PrintLine(libre, TAB(4), "butVer" & reg.nombre & ".enabled = false")
                            End If
                        End If
                    End If
                End If
            Next
            PrintLine(libre, TAB(8), "End If")

            PrintLine(libre, "")

            strKey = Nothing
            For Each reg In arrEstructura
                If reg.IsKey = True Then
                    'If Mid(reg.nombre, (Len(reg.nombre) - 1)) = "ID" Then
                    '    strKey = Mid(reg.nombre, 1, (Len(reg.nombre) - 2))
                    'Else
                    strKey = reg.nombre
                    'End If
                    Exit For
                End If
            Next

            'PrintLine(libre, TAB(8), "SetValores(m_DBO_" & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & "." & strKey & ", False)")
            'PrintLine(libre, TAB(8), "SetValores()")

            For Each reg In arrEstructura
                If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                    If Mid(reg.nombre, 1, 4) = "Ruta" Then
                        PrintLine(libre, TAB(8), "butVer.Visible = True")
                    End If
                End If
            Next

            PrintLine(libre, TAB(4), "End Sub")
            PrintLine(libre, "")

            '--------------------- SetValores -----------------------
            'PrintLine(libre, TAB(4), "Overrides Sub SetValores(ByVal m_ID As Integer, ByVal m_SelectRecord As Boolean)")
            PrintLine(libre, TAB(4), "Overrides Sub SetValores() Implements BasesParaCompatibilidad.Savable.setValores")
            'PrintLine(libre, TAB(8), "'TO DO: comprobar esta linea")
            If filtroMaestro = "" Then
                PrintLine(libre, TAB(8), "If (Me.modoDeApertura = INSERCION) Then")
                PrintLine(libre, TAB(8), "Me.m_DBO_" & clase & " = new dbo_" & clase)
                PrintLine(libre, TAB(8), "Else")
                PrintLine(libre, TAB(8), "Me.m_DBO_" & clase & " = ctype(dbo, DBO_" & clase & ")")
                'PrintLine(libre, TAB(8), "If m_SelectRecord Then m_DBO_" & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & " = sp" &clase & ".Select_Record(m_ID)")
                'PrintLine(libre, TAB(8), "If m_ID > 0 Then")            
                'PrintLine(libre, TAB(8), "End If")
                PrintLine(libre, TAB(8), "End If")
            Else
                PrintLine(libre, TAB(8), "Me.m_DBO_" & clase & " = ctype(dbo, DBO_" & clase & ")")
            End If

            PrintLine(libre, "")
            frmEnt_setValores(clase, libre)

            PrintLine(libre, TAB(4), "End Sub")
            PrintLine(libre, "")

            '--------------------- GetValores -----------------------
            PrintLine(libre, TAB(4), "Protected Overrides Function GetValores() as boolean Implements BasesParaCompatibilidad.Savable.getValores")
            PrintLine(libre, TAB(9), "Dim errores as String = string.empty")
            frmEnt_GetValores(clase, libre)
            PrintLine(libre, TAB(8), "If (errores = String.empty) then")
            PrintLine(libre, TAB(10), "Dbo = ctype(m_DBO_" & clase & ", BasesParaCompatibilidad.databussines)")
            PrintLine(libre, TAB(10), "return true")
            PrintLine(libre, TAB(8), "Else")
            PrintLine(libre, TAB(10), "MessageBox.Show(""Rellene correctamente el formulario, se han encontrado os siguientes errores:"" & Environment.NewLine() & Environment.NewLine() & errores,""Error"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)")
            PrintLine(libre, TAB(10), "return false")
            PrintLine(libre, TAB(9), "End IF")
            PrintLine(libre, TAB(4), "End Function")
            PrintLine(libre, "")

            '--------------------- GUARDAR -----------------------
            Dim Tabfor As String = ""
            PrintLine(libre, TAB(4), "Public Overrides Sub Guardar(Optional ByRef trans As SqlClient.SqlTransaction = nothing) Implements BasesParaCompatibilidad.Savable.Guardar")
            PrintLine(libre, TAB(8), "MyBase.Guardar(trans)")
            PrintLine(libre, TAB(4), "End Sub")
            PrintLine(libre, "")

            For Each reg In arrEstructura
                If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                    If Mid(reg.nombre, 1, 4) = "Ruta" Then
                        PrintLine(libre, TAB(4), "Private Sub but" & reg.nombre & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but" & reg.nombre & ".Click")
                        PrintLine(libre, TAB(8), "Dim arch As String")
                        'Si no se colocan las comillas vacias antes de la ruta, no se abre la carpeta requerida.
                        PrintLine(libre, TAB(8), "'Cambiar ""C:\"" por la ruta adecuada")
                        PrintLine(libre, TAB(8), "arch =  File.Elegir_archivo(""C:\"")")
                        'PrintLine(libre, TAB(8), "arch = SeleccionarArchivo(Me.Text, txt" & reg.nombre & ".Text, """", ""C:\"") ")
                        PrintLine(libre, "")
                        PrintLine(libre, TAB(8), "If (Me.Text.Substring(0, 3) <> ""Ver"") Then")
                        PrintLine(libre, TAB(12), "txt" & reg.nombre & ".Text = arch")
                        PrintLine(libre, TAB(8), "End If ")
                        PrintLine(libre, TAB(4), "End Sub")
                        PrintLine(libre, "")
                        PrintLine(libre, TAB(4), "Public Overrides Sub Ver()")
                        PrintLine(libre, TAB(8), "Try")
                        PrintLine(libre, TAB(12), "Dim psi As New ProcessStartInfo()")
                        PrintLine(libre, TAB(12), "psi.UseShellExecute = True")
                        PrintLine(libre, TAB(12), "psi.FileName = txt" & reg.nombre & ".Text")
                        PrintLine(libre, TAB(12), "Process.Start(psi)")
                        PrintLine(libre, TAB(8), "Catch ex As Exception")
                        PrintLine(libre, TAB(12), "messagebox.show(ex.message, ""Error"", MessageBoxButtons.OK, MessageBoxIcon.Error)")
                        PrintLine(libre, TAB(8), "End Try")
                        PrintLine(libre, TAB(4), "End Sub")
                        PrintLine(libre, "")
                    End If
                End If
            Next

            For Each reg In arrEstructura
                If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        If Not reg.IsKey Then
                            If reg.Ver = True Then
                                PrintLine(libre, TAB(4), "Private Sub butVer" & reg.nombre & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butVer" & reg.nombre & ".Click")
                                PrintLine(libre, TAB(8), "Dim frmEnt As New frm" & reg.TablaForanea & "()")
                                PrintLine(libre, TAB(8), "guiMain.añadirPestaña(frmEnt)")
                                PrintLine(libre, TAB(4), "End Sub")
                                PrintLine(libre, "")
                            End If
                            If reg.Add = True Then
                                PrintLine(libre, TAB(4), "Private Sub butAdd" & reg.nombre & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd" & reg.nombre & ".Click")
                                PrintLine(libre, TAB(8), "Dim DBO_" & reg.TablaForanea & " As New DBO_" & reg.TablaForanea & "")
                                PrintLine(libre, TAB(8), "Dim frmEnt As New frmEnt" & reg.TablaForanea & "(BasesParaCompatibilidad.GridSimpleForm.ACCION_INSERTAR, new sp" & reg.TablaForanea & ",DBO_" & reg.TablaForanea & ")")
                                PrintLine(libre, TAB(8), "frmEnt.ShowDialog()")

                                PrintLine(libre, TAB(8), "dim s as new sp" & reg.TablaForanea)

                                If reg.TablaForanea = "Empleados" Then
                                    'PrintLine(libre, TAB(8), If(Generador.guest, "'", "") & "Me.cbo" & reg.nombre & ".mam_DataSource(""" & "EmpleadosSelect" & "Cbo"", False)")
                                    PrintLine(libre, TAB(8), "s.cargar_empleados(Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ")")
                                Else
                                    'PrintLine(libre, TAB(8), If(Generador.guest, "'", "") & "Me.cbo" & reg.nombre & ".mam_DataSource(""" & reg.TablaForanea & "Cbo"", False)")
                                    PrintLine(libre, TAB(8), "s.cargar_" & reg.TablaForanea & "(Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ")")
                                End If
                                PrintLine(libre, TAB(4), "End Sub")
                                PrintLine(libre, "")
                            End If
                        End If
                    End If
                End If
            Next

            PrintLine(libre, TAB(4), "Private Sub frmEnt" & clase & "_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown")
            PrintLine(libre, TAB(8), "BasesParaCompatibilidad.DetailedSimpleForm.centerIn(ctype(Me.tlpMiddle, Control), Me)")
            PrintLine(libre, TAB(4), "End Sub")
            PrintLine(libre, "End Class")
            FileClose(libre)
        ElseIf File.Exists(m_ruta & "frmEnt" & clase & ".vb") Then
            File.Move(m_ruta & "frmEnt" & clase & ".vb", m_ruta & "frmEnt" & clase & ".old")

            FileOpen(10, m_ruta & "frmEnt" & clase & ".old", OpenMode.Input)
            FileOpen(libre, m_ruta & "frmEnt" & clase & ".vb", OpenMode.Output)

            Dim oldLine As String = Nothing
            Dim skipLine As Boolean = False
            While Not EOF(10)
                oldLine = LineInput(10)
                If InStr(oldLine, "<Tag=[One][Start]>") > 0 Then
                    skipLine = True
                    frmEnt_setValores(clase, libre)
                ElseIf InStr(oldLine, "<Tag=[One][End]>") > 0 Then
                    skipLine = False
                ElseIf InStr(oldLine, "<Tag=[Two][Start]>") > 0 Then
                    skipLine = True
                    frmEnt_GetValores(clase, libre)
                ElseIf InStr(oldLine, "<Tag=[Two][End]>") > 0 Then
                    skipLine = False
                Else
                    If skipLine = False Then
                        PrintLine(libre, oldLine)
                    End If
                End If
            End While

            FileClose(10)
            FileClose(libre)
            File.Delete(m_ruta & "frmEnt" & clase & ".old")
        End If
    End Sub

    Private Sub frmEnt_setValores(ByVal clase As String, ByVal libre As Integer)
        Dim reg As RegCampo
        'PrintLine(libre, TAB(0), "'<Tag=[One][Start]> -- please do not remove this line")
        For Each reg In arrEstructura
            Dim campo As String = clase & "." & reg.nombre 'If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & "." & reg.nombre

            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                    Select Case reg.tipo
                        Case "Boolean"
                            PrintLine(libre, TAB(12), "chb" & reg.nombre & ".Checked = m_DBO_" & campo)
                        Case "Date"
                            PrintLine(libre, TAB(12), "dtp" & reg.nombre & ".Value = m_DBO_" & campo & "")
                        Case "DateTime"
                            PrintLine(libre, TAB(12), "dtp" & reg.nombre & ".Value = m_DBO_" & campo & "")
                        Case "TimeSpan"
                            PrintLine(libre, TAB(12), "dtp" & reg.nombre & ".Value = today.date.add(m_DBO_" & campo & ")")
                        Case Else
                            PrintLine(libre, TAB(12), "txt" & reg.nombre & ".Text = m_DBO_" & campo)
                    End Select
                ElseIf reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        PrintLine(libre, TAB(12), "cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".SelectedValue = m_DBO_" & campo)
                    End If
                End If
            End If
        Next
        'PrintLine(libre, TAB(0), "'<Tag=[One][End]> -- please do not remove this line")
    End Sub

    Private Sub frmEnt_GetValores(ByVal clase As String, ByVal libre As Integer)
        Dim reg As RegCampo
        PrintLine(libre, "")
        'PrintLine(libre, TAB(0), "'<Tag=[Two][Start]> -- please do not remove this line")

        For Each reg In arrEstructura
            Dim nombre As String = clase 'If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase)
            Dim tipo As String = ConvertToDotNetDataType(reg.tipo)

            If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                If reg.IsIdentity = False Then
                    If reg.nombre <> "UsuarioModificacion" And reg.nombre <> "FechaModificacion" Then
                        If Not reg.IsNullable Then
                            Select Case reg.tipo
                                Case "Boolean"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = chb" & reg.nombre & ".Checked")
                                Case "DateTime"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = dtp" & reg.nombre & ".value")
                                    'ElseIf reg.nombre = "FechaModificacion" Then
                                    '    PrintLine(libre, TAB(8), "m_DBO_" & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & "." & reg.nombre & " = System.DateTime.Now")
                                    PrintLine(libre, "")
                                Case "Date"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = dtp" & reg.nombre & ".value.date")
                                    PrintLine(libre, "")
                                Case "TimeSpan"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = New TimeSpan(dtp" & reg.nombre & ".Value.Hour, dtp" & reg.nombre & ".Value.Minute, 0)")
                                    PrintLine(libre, "")
                                Case "Int32"
                                    PrintLine(libre, TAB(8), "If not isNumeric(" & "txt" & reg.nombre & ".Text" & ") then")
                                    PrintLine(libre, TAB(12), "If errores = """" Then txt" & reg.nombre & ".Focus()")
                                    PrintLine(libre, TAB(12), "errores = errores & ""El campo " & reg.nombre & " debe ser numérico."" & Environment.NewLine()")
                                    PrintLine(libre, TAB(8), "Else")
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = " & tipo & "(txt" & reg.nombre & ".Text)")
                                    PrintLine(libre, TAB(8), "End If")
                                    PrintLine(libre, "")
                                    'ElseIf reg.nombre = "UsuarioModificacion" Then
                                    '    PrintLine(libre, TAB(8), "m_DBO_" & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & "." & reg.nombre & " = gUsuarioID")
                                Case "String"
                                    PrintLine(libre, TAB(8), "If " & "txt" & reg.nombre & ".Text" & "= """" then")
                                    PrintLine(libre, TAB(12), "If errores = """" Then txt" & reg.nombre & ".Focus()")
                                    PrintLine(libre, TAB(12), "errores = errores & ""El campo " & reg.nombre & " no puede estar vacío."" & Environment.NewLine()")
                                    PrintLine(libre, TAB(8), "Else")
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = txt" & reg.nombre & ".Text")
                                    PrintLine(libre, TAB(8), "End If")
                                    PrintLine(libre, "")
                                    PrintLine(libre, "")
                                    'ElseIf reg.nombre = "UsuarioModificacion" Then
                                    '    PrintLine(libre, TAB(8), "m_DBO_" & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & "." & reg.nombre & " = gUsuarioID")
                                Case Else

                                    PrintLine(libre, TAB(8), "If " & "txt" & reg.nombre & ".Text" & "= """" then")
                                    PrintLine(libre, TAB(12), "If errores = """" Then txt" & reg.nombre & ".Focus()")
                                    PrintLine(libre, TAB(12), "errores = errores & ""El campo " & reg.nombre & " no puede estar vacío."" & Environment.NewLine()")
                                    PrintLine(libre, TAB(8), "Else")
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = " & tipo & "(txt" & reg.nombre & ".Text)")
                                    PrintLine(libre, TAB(8), "End If")
                                    PrintLine(libre, "")
                                    'ElseIf reg.nombre = "UsuarioModificacion" Then
                                    '    PrintLine(libre, TAB(8), "m_DBO_" & If(Mid(clase, Len(clase), 1) = "s", Mid(clase, 1, (Len(clase) - 1)),clase) & "." & reg.nombre & " = gUsuarioID")
                            End Select
                        Else
                            Select Case reg.tipo
                                Case "Boolean"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = chb" & reg.nombre & ".Checked")
                                Case "DateTime"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = dtp" & reg.nombre & ".value")
                                    PrintLine(libre, "")
                                Case "Date"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = dtp" & reg.nombre & ".value.date")
                                    PrintLine(libre, "")
                                Case "TimeSpan"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = New TimeSpan(dtp" & reg.nombre & ".Value.Hour, dtp" & reg.nombre & ".Value.Minute, 0)")
                                    PrintLine(libre, "")
                                Case "Int32"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = " & tipo & "( txt" & reg.nombre & ".Text)")
                                    PrintLine(libre, "")
                                Case "String"
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = txt" & reg.nombre & ".Text")
                                    PrintLine(libre, "")
                                Case Else
                                    PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = " & tipo & "(txt" & reg.nombre & ".Text)")
                                    PrintLine(libre, "")
                            End Select
                        End If
                    End If
                End If

                PrintLine(libre, "")
            Else
                'If reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                    If Not reg.IsNullable Then
                        PrintLine(libre, TAB(8), "If " & "cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".selectedvalue = nothing then")
                        PrintLine(libre, TAB(12), "If errores = """" Then cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".Focus()")
                        PrintLine(libre, TAB(12), "errores = errores & ""No seleccionó un valor para " & reg.nombre & "."" & Environment.NewLine()")
                        PrintLine(libre, TAB(8), "Else")
                        PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = " & tipo & "(cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".SelectedValue)")
                        PrintLine(libre, TAB(8), "End If")
                    End If
                    'PrintLine(libre, TAB(8), "m_DBO_" & nombre & "." & reg.nombre & " = " & tipo & "(cbo" & reg.nombre & ".SelectedValue)")
                End If
            End If
        Next
        'PrintLine(libre, TAB(0), "'<Tag=[Two][End]> -- please do not remove this line")
    End Sub

    Public Sub generateFile() Implements Writable.generateFile
        frm_vb()
        frmEnt_vb()
    End Sub
End Class
