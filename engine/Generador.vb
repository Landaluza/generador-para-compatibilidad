Imports System.Data.SqlClient

Public Class Generador
    Public Shared bandera As Boolean = False
    Public Shared dtsCam As New dtsCampos.CamposDataTable
    Public Shared database As DataBase    
    Public m_ruta As String
    'Public estructura() As RegCampo    
    Private estructura As Generic.List(Of RegCampo)
    Private estructura2 As Generic.List(Of RegCampo)
    Private genfrmEnt As Boolean
    Private genfrm As Boolean
    Private gensql As Boolean
    Private gensp As Boolean
    Private gendbo As Boolean

    Public WriteOnly Property DBO As Boolean
        Set(value As Boolean)
            gendbo = value
        End Set
    End Property

    Public WriteOnly Property stored_procedure As Boolean
        Set(value As Boolean)
            gensp = value
        End Set
    End Property

    Public WriteOnly Property SQL As Boolean
        Set(value As Boolean)
            gensql = value
        End Set
    End Property

    Public WriteOnly Property formulario_consulta As Boolean
        Set(value As Boolean)
            genfrm = value
        End Set
    End Property

    Public WriteOnly Property formulario_entrada As Boolean
        Set(value As Boolean)
            genfrmEnt = value
        End Set
    End Property

    Public Sub New(ByVal configuracionBD As DatabaseConfig)
        database = New DataBase(configuracionBD)
        estructura = New Generic.List(Of RegCampo)
        estructura2 = New Generic.List(Of RegCampo)
        'guest = False
    End Sub

    Public Property ruta As String
        Get
            Return m_ruta
        End Get
        Set(ByVal value As String)
            m_ruta = value
        End Set
    End Property

    Public Property arrEstructura As Generic.List(Of RegCampo)
        Get
            Return estructura
        End Get
        Set(ByVal value As Generic.List(Of RegCampo))
            estructura = value
        End Set
    End Property

    Public Property arrEstructura2 As Generic.List(Of RegCampo)
        Get
            Return estructura2
        End Get
        Set(ByVal value As Generic.List(Of RegCampo))
            estructura2 = value
        End Set
    End Property

#Region "mover a una libreria oclase que se encargue de cambios esteticos del form"
    ''Solo se usa en el load, revisar si son necesarios
    Public Sub AddComboBoxColumns(ByRef dgvCampos As DataGridView)
        Dim comboboxColumn As New DataGridViewComboBoxColumn
        With comboboxColumn
            .DataPropertyName = "Tipo"
            .HeaderText = "Tipo"
            '.DropDownWidth = 160
            '.Width = 90
            .MaxDropDownItems = 100
            .FlatStyle = FlatStyle.Flat
        End With

        'comboboxColumn.Items.AddRange("Int32", "Integer", "Single", "Decimal", "Boolean", "String", "DateTime")
        comboboxColumn.Items.AddRange("Int32", "Integer", "Single", "Boolean", "String", "DateTime", "Date")
        dgvCampos.Columns.Insert(1, comboboxColumn)

        dgvCampos.Columns.Remove("CampoIDForaneo")
        comboboxColumn = New DataGridViewComboBoxColumn
        With comboboxColumn
            .Name = "CampoIDForaneo"
            .DataPropertyName = "CampoIDForaneo"
            .HeaderText = "CampoIDForaneo"
            .DropDownWidth = 180
            '.Width = 90
            .MaxDropDownItems = 100
            .FlatStyle = FlatStyle.Flat
        End With
        comboboxColumn.Items.Clear()
        comboboxColumn.Items.Add("")
        dgvCampos.Columns.Insert(9, comboboxColumn)


        dgvCampos.Columns.Remove("CampoForaneo")
        comboboxColumn = New DataGridViewComboBoxColumn
        With comboboxColumn
            .Name = "CampoForaneo"
            .DataPropertyName = "CampoForaneo"
            .HeaderText = "CampoForaneo"
            .DropDownWidth = 180
            '.Width = 90
            .MaxDropDownItems = 100
            .FlatStyle = FlatStyle.Flat
        End With
        comboboxColumn.Items.Clear()
        comboboxColumn.Items.Add("")
        dgvCampos.Columns.Insert(10, comboboxColumn)
    End Sub

    Public Sub AddComboBoxColumnsTablas(ByRef dgvCampos As DataGridView, ByRef cboTabla As System.Windows.Forms.ComboBox)
        Dim auxColumn As New DataGridViewColumn
        auxColumn.Name = "TablaForanea"

        If dgvCampos.Columns("TablaForanea").Index > -1 Then dgvCampos.Columns.Remove("TablaForanea")


        auxColumn.Name = "CampoIDForaneo"

        If dgvCampos.Columns("CampoIDForaneo").Index > -1 Then dgvCampos.Columns.Remove("CampoIDForaneo")

        auxColumn.Name = "CampoForaneo"
        If dgvCampos.Columns("CampoForaneo").Index > -1 Then dgvCampos.Columns.Remove("CampoForaneo")

        Dim comboboxColumn As New DataGridViewComboBoxColumn
        Dim comboboxColumn2, comboboxColumn3 As New DataGridViewTextBoxColumn
        With comboboxColumn
            .Name = "TablaForanea"
            .DataPropertyName = "TablaForanea"
            .HeaderText = "TablaForanea"
            .DropDownWidth = 180
            '.Width = 90            
            .MaxDropDownItems = 8
            .AutoComplete = True
            .FlatStyle = FlatStyle.Flat
        End With
        With comboboxColumn2
            .Name = "CampoIDForaneo"
            .DataPropertyName = "CampoIDForaneo"
            .HeaderText = "CampoIDForaneo"
            '.DropDownWidth = 180
            '.Width = 90            
            '.MaxDropDownItems = 100
            '.FlatStyle = FlatStyle.Flat
        End With
        With comboboxColumn3
            .Name = "CampoForaneo"
            .DataPropertyName = "CampoForaneo"
            .HeaderText = "CampoForaneo"
            '.DropDownWidth = 180
            '.Width = 90            
            '.MaxDropDownItems = 100
            '.FlatStyle = FlatStyle.Flat
        End With

        Dim i As Integer = 0
        'comboboxColumn.DataSource = cboTabla.DataSource
        'comboboxColumn.Items.Add("")
        ''comboboxColumn2.Items.Add("")
        ''comboboxColumn3.Items.Add("")
        Dim row As DataRowView
        While i < cboTabla.Items.Count
            row = CType(cboTabla.Items.Item(i), DataRowView)
            comboboxColumn.Items.Add(row.Item(0))
            i = i + 1
        End While
        dgvCampos.Columns.Insert(8, comboboxColumn)
        dgvCampos.Columns.Insert(9, comboboxColumn2)
        dgvCampos.Columns.Insert(10, comboboxColumn3)
    End Sub

    Function HacerColumnComboboxconFiltro(ByVal TablaFiltro As String, ByVal arrEstructura2 As Generic.List(Of RegCampo), ByRef comboboxColumn As DataGridViewComboBoxCell) As DataGridViewComboBoxCell
        'Dim comboboxColumn As New DataGridViewComboBoxCell
        With comboboxColumn
            .DropDownWidth = 180

            .AutoComplete = False
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            .MaxDropDownItems = 7

            '.Width = 90
            '.MaxDropDownItems = 15
            .FlatStyle = FlatStyle.Flat
        End With

        comboboxColumn.Items.Clear()
        Generador.database.get_Campos(TablaFiltro, arrEstructura2)
        Dim i As Integer = 0

        Dim reg As New RegCampo
        For Each reg In arrEstructura2
            comboboxColumn.Items.Add(reg.nombre)
            i = i + 1
        Next
        Return comboboxColumn
    End Function
#End Region

    Public Sub hacer(ByRef dgvCampos As DataGridView, ByRef cboSeraForanea As Windows.Forms.ComboBox, ByRef cboFilter As Windows.Forms.ComboBox)
        Try
            Dim i As Integer = 1
            Generador.dtsCam.Clear()
            Dim regCam As dtsCampos.CamposRow
            Dim regAux As RegCampo
            regCam = Nothing
            Dim mensaje As String = ""
            cboSeraForanea.Items.Clear()
            cboFilter.Items.Clear()
            cboSeraForanea.Text = ""
            For Each regAux In Me.arrEstructura
                'regCam = New Generador.dtsCam.NewCamposRow
                regCam = dtsCam.NewCamposRow
                regCam.Nombre = regAux.nombre
                cboSeraForanea.Items.Add(regAux.nombre)
                cboFilter.Items.Add(regAux.nombre)
                regCam.EsLlave = regAux.EsLlave
                regCam.EsUnico = regAux.EsUnico
                regCam.CaracteresMinimos = regAux.CaracterMinimo
                regCam.CaracteresMaximos = regAux.CaracterMaximo
                regCam.Obligatorio = regAux.EsObligatorio
                regCam.Tipo = GetDotNetDataType(regAux.tipo)
                regCam.TipoFecha = regAux.Fecha

                Generador.dtsCam.AddCamposRow(regCam)
                regCam = Nothing
                i = i + 1
            Next

            dgvCampos.DataSource = Generador.dtsCam

            ''''
            i = 1
            While i < database.TamanoTotal
                If arrEstructura(i).nombre = "FechaModificacion" Or arrEstructura(i).nombre = "UsuarioModificacion" Then
                    dgvCampos.Rows(i).Visible = False
                End If
                i = i + 1
            End While
            dgvCampos.Columns("Obligatorio").Visible = False
            dgvCampos.Columns("EsUnico").Visible = False
            ''''

            If mensaje <> "" Then
                messagebox.show("Tipo de " & mensaje)
            End If
        Catch ex As Exception
            messagebox.show(ex.Message)
        End Try
    End Sub

    ' Este procedimiento genera un archivo de texto con extensión .VB con la definición de unaclase correspondiente a una tabla de una base de datos.
    ' Al basarse enteramente en la estructura de una tabla de SQL Server, las propiedades de laclases son el mismo tipo que en la tabla "física", por
    ' ejemplo en lugar de tener propiedades tipo Integer va a tener propiedades de tipo Int32, en lugar de Short van a ser Int16, etc.
    ' Esto no genera ningún problema, ya que VB.NET convierte en forma automática los datos (ya que lasclase toma los datos "oficiales" de .NET).

    Public Function GenerarArchivos(ByVal nombreTabla As String, ByVal filtro As String, ByVal maestro As Boolean, ByVal orgclase As String, ByVal CP As String, _
                                     ByVal seraForanea As Boolean, ByVal foranea As String, ByVal runProcedures As Boolean, ByVal filtroMaestro As String) As Boolean
        

        'Dim clase As String = orgclase

        ' Doy formato al nombre del archivo
        If Me.ruta.Substring(ruta.Length - 1, 1) <> "\" Then
            Me.ruta = Me.ruta & "\"
        End If

        'If Generador.guest Then
        '    '"Z:\Desarrollo\AppGenerador\extrafiles"
        '    Dim rutazip As String = "\\servidor\datos\desarrollo\AppGenerador\extrafiles\"
        '    My.Computer.FileSystem.CopyDirectory(rutazip, ruta)
        '    Me.ruta = Me.ruta & "La Andaluza\nuevoModulo\"
        'End If
        Dim dbo As New Dbo(Me.ruta, arrEstructura, orgclase)
        Dim designer As New Designer(Me.ruta, arrEstructura, orgclase)
        Dim vbForm As New VbForm(ruta, arrEstructura, orgclase, filtro, maestro, filtroMaestro)
        Dim storedProcedure As New StoredProcedure(nombreTabla, Me.ruta, arrEstructura, orgclase, orgclase, If(seraForanea, foranea, ""))


        If Me.gendbo Then
            dbo.generateFile()
        End If

        If Me.genfrm Then
            vbForm.frm_vb()
            designer.generate_frm()
        End If

        If Me.genfrmEnt Then
            vbForm.frmEnt_vb()
            designer.generate_frmEnt()
        End If

        If Me.gensp Then
            storedProcedure.generateFile()
        End If

        If Me.gensql Then
            storedProcedure.generateSqlFile(filtro, maestro, seraForanea, foranea, runProcedures)
        End If
        

        'dbo.generateFile()
        'storedProcedure.generateFile()
        'vbForm.generateFile()
        'designer.generateFile()
        'storedProcedure.generateSqlFile(filtro, maestro, seraForanea, foranea, runProcedures)
        Return True

    End Function

    'NO SE USA
    'Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer

    'Private Function AbrirArchivo(ByVal arch As String) As Short
    '    Dim hay_error As Short
    '    hay_error = ShellExecute(123456, "Open", arch, "", "", 3)
    '    Return hay_error
    'End Function
End Class
