Public Class GUI
    Private Options As Options
    Private FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Public generador As Generador
    Private c As DataGridViewCheckBoxColumn

    Public Sub New(ByVal guest As Boolean, ByVal ConfiguracionBd As DatabaseConfig)
        InitializeComponent()

        Me.generador = New Generador(ConfiguracionBd)
        c = New DataGridViewCheckBoxColumn
        c.HeaderText = "Obligatorio"
        c.Name = "obligatorio"
        Me.Text = "10.11.2.009  Generador para LA. " & String.Format("Version {0}", NumeroVersion())

        lblPostfix.Enabled = False
        txtVersion.Enabled = False
        chbMD.Checked = False
        cboFilter.Enabled = False

        dgvCampos.DataSource = generador.dtsCam
        dgvCampos.Columns("Obligatorio").Visible = False
        dgvCampos.Columns("EsUnico").Visible = False
        dgvCampos.Columns.Remove("Tipo")

        FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Options = New Options
        Me.Options = Options.load


    End Sub

    Private Sub formGenerador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generador.AddComboBoxColumns(dgvCampos)

        cboTabla.Visible = True
        dgvCampos.Columns(1).Visible = False
        dgvCampos.Columns(2).Visible = False
        dgvCampos.Columns(5).Visible = False
        dgvCampos.Columns(6).Visible = False
        dgvCampos.Columns(7).Visible = False
        dgvCampos.Columns(9).Visible = False

        If generador.database.ArmarCadenaConexion() Then
            lConexionMessage.Text = generador.database.Server & ":" & generador.database.BDName
            btnConexion.Image = My.Resources.network_transmit
            If generador.database.get_Tablas(cboTabla) Then
                'txtRuta.Text = "Seleccionar ruta del codigo"
                butGenerar.Enabled = True
                dgvCampos.DataSource = Nothing
            End If
        Else
            butGenerar.Enabled = False
            lConexionMessage.Text = "Sin conexión"
            btnConexion.Image = My.Resources.network_offline_2
        End If

        Me.txtRuta.Text = Options.Ruta
        If Me.Options.Ruta <> "" Then
            FolderBrowserDialog1.SelectedPath = Me.Options.Ruta
        Else
            FolderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End If

        If Not Options.Tabla Is Nothing Then Me.cboTabla.SelectedValue = Options.Tabla
        Me.chbRunProcedures.Checked = Options.Ejecutar
        Me.chbCrearCampos.Checked = Options.Combo
        If Options.Versionar Then
            Me.chbVersion.Checked = True
            Me.txtVersion.Text = Options.Version
        End If
    End Sub

    Private Sub butRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRuta.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtRuta.Text = FolderBrowserDialog1.SelectedPath.ToString
            Me.ToolTip1.SetToolTip(txtRuta, txtRuta.Text)
        End If
    End Sub

    Private Sub cboTabla_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTabla.SelectedValueChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboTabla.SelectedValue.ToString <> "System.Data.DataRowView" Then
                If Not cboTabla.SelectedValue Is Nothing Then
                    'AddFields(DataBase.CadenaConexion, cboTabla.Text)

                    generador.arrEstructura = generador.database.CargarDesdeBD(DataBase.CadenaConexion, cboTabla.Text)
                    If Not generador.arrEstructura Is Nothing Then generador.hacer(dgvCampos, cboSeraForanea, cboFilter)

                    PonerValoresGrilla()
                    generador.AddComboBoxColumnsTablas(dgvCampos, cboTabla)


                    dgvCampos.Columns(1).Visible = False
                    dgvCampos.Columns(2).Visible = False
                    dgvCampos.Columns(5).Visible = False
                    dgvCampos.Columns(6).Visible = False
                    dgvCampos.Columns(7).Visible = False
                    dgvCampos.Columns(9).Visible = False

                    generador.database.GetComboFields(DataBase.CadenaConexion, cboTabla.Text, dgvCampos)

                    For Each reg As RegCampo In generador.arrEstructura
                        If reg.IsKey Then
                            For i As Integer = 0 To dgvCampos.RowCount - 1
                                If dgvCampos.Item("Nombre", i).Value.ToString = reg.nombre Then
                                    If Not dgvCampos.Item(8, i) Is Nothing Then
                                        dgvCampos.Item(8, i).ReadOnly = True
                                        dgvCampos.Item(8, i).Style.BackColor = Color.LightGray
                                    End If
                                    If Not dgvCampos.Item(9, i) Is Nothing Then
                                        dgvCampos.Item(9, i).ReadOnly = True
                                        dgvCampos.Item(9, i).Style.BackColor = Color.LightGray
                                    End If
                                    If Not dgvCampos.Item(10, i) Is Nothing Then
                                        dgvCampos.Item(10, i).ReadOnly = True
                                        dgvCampos.Item(10, i).Style.BackColor = Color.LightGray
                                    End If
                                    If Not dgvCampos.Item(11, i) Is Nothing Then
                                        dgvCampos.Item(11, i).ReadOnly = True
                                        'dgvCampos.Item(11, i).Value = False
                                        dgvCampos.Item(11, i).Style.BackColor = Color.LightGray
                                    End If


                                End If
                            Next
                        End If
                    Next
                    '''''

                    For Each rown As DataGridViewRow In dgvCampos.Rows
                        If Not rown.Cells(8) Is Nothing And Not rown.Cells(9) Is Nothing And Not rown.Cells(10) Is Nothing Then
                            If rown.Cells(8).Value.ToString = "" And rown.Cells(9).Value.ToString = "" And rown.Cells(10).Value.ToString = "" Then
                                If rown.Cells.Count > 12 Then
                                    rown.Cells(12).ReadOnly = True
                                    rown.Cells(12).Style.BackColor = Color.LightGray
                                    rown.Cells(12).Value = False

                                    If rown.Cells.Count > 13 Then
                                        rown.Cells(13).ReadOnly = True
                                        rown.Cells(13).Style.BackColor = Color.LightGray
                                        rown.Cells(13).Value = False
                                    End If
                                End If
                            End If
                        End If
                    Next
                    ''''''
                    Clipboard.SetText(cboTabla.Text)
                End If
            End If
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Sub PonerValoresGrilla()
        RemoveHandler dgvCampos.CellValueChanged, AddressOf dgvCampos_CellValueChanged

        Dim row As DataGridViewRow
        For Each row In dgvCampos.Rows
            Try
                If row.Cells(0).Value.ToString.ToLower.Trim = "descripcion" Then
                    row.Cells(1).Value = "String"
                    row.Cells(5).Value = 50
                ElseIf row.Cells(0).Value.ToString.ToLower.Trim.Substring(0, 4) = "ruta" Then
                    row.Cells(1).Value = "String"
                    row.Cells(5).Value = 250
                ElseIf row.Cells(0).Value.ToString.ToLower.Trim.Substring(row.Cells(0).Value.ToString.Length - 2, 2) = "id" Then
                    row.Cells(1).Value = "Int32" '"Integer"
                ElseIf row.Cells(0).Value.ToString.ToLower.Trim.Substring(0, 5) = "fecha" Then
                    row.Cells(1).Value = "DateTime"
                    row.Cells(7).Value = True
                End If
            Catch ex As Exception
            End Try
        Next

        AddHandler dgvCampos.CellValueChanged, AddressOf dgvCampos_CellValueChanged
    End Sub

    Private Sub dgvCampos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCampos.CellValueChanged
        Try
            If e.ColumnIndex = 1 Then
                If dgvCampos.Item(1, e.RowIndex).Value = "String" Then
                    If dgvCampos.Item(0, e.RowIndex).Value.ToString.ToLower.Trim = "descripcion" Then
                        dgvCampos.Item(5, e.RowIndex).Value = 50
                    End If
                    Try
                        If dgvCampos.Item(0, e.RowIndex).Value.ToString.ToLower.Trim.Substring(0, 4) = "ruta" Then
                            dgvCampos.Item(5, e.RowIndex).Value = 250
                        End If
                    Catch ex As Exception

                    End Try
                End If

                If dgvCampos.Item(1, e.RowIndex).Value = "DateTime" Then
                    If dgvCampos.Item(0, e.RowIndex).Value.ToString.ToLower.Trim.Substring(0, 5) = "fecha" Then
                        dgvCampos.Item(7, e.RowIndex).Value = True
                    ElseIf dgvCampos.Item(0, e.RowIndex).Value.ToString.ToLower.Trim.Substring(0, 4) = "hora" Then
                        dgvCampos.Item(7, e.RowIndex).Value = False
                    Else
                        dgvCampos.Item(7, e.RowIndex).Value = True
                    End If
                End If
            ElseIf e.ColumnIndex = 2 Then
                If dgvCampos.Item(2, e.RowIndex).Value = True Then
                    dgvCampos.Item(3, e.RowIndex).Value = True
                    dgvCampos.Item(4, e.RowIndex).Value = True
                    dgvCampos.Item(11, e.RowIndex).Value = False
                Else
                    dgvCampos.Item(3, e.RowIndex).Value = False
                    dgvCampos.Item(4, e.RowIndex).Value = False
                End If
            ElseIf e.ColumnIndex = 8 Then
                If dgvCampos.Item(8, e.RowIndex).Value.ToString = "" Then
                    dgvCampos.Item(9, e.RowIndex).Value = ""
                    dgvCampos.Item(10, e.RowIndex).Value = ""
                Else
                    dgvCampos = generador.database.GetPrimaryKey(DataBase.CadenaConexion, dgvCampos.Item(8, e.RowIndex).Value.ToString, dgvCampos)
                End If
            ElseIf e.ColumnIndex = 10 Then
                If dgvCampos.Item(8, e.RowIndex).Value.ToString <> "" And _
                    dgvCampos.Item(9, e.RowIndex).Value.ToString <> "" And _
                    dgvCampos.Item(10, e.RowIndex).Value.ToString <> "" Then
                    If dgvCampos.Columns.Count > 12 Then
                        dgvCampos.Item(12, e.RowIndex).ReadOnly = False
                        dgvCampos.Item(12, e.RowIndex).Style.BackColor = Color.White
                        dgvCampos.Item(12, e.RowIndex).Value = True
                    End If
                    If dgvCampos.Columns.Count > 13 Then
                        dgvCampos.Item(13, e.RowIndex).ReadOnly = False
                        dgvCampos.Item(13, e.RowIndex).Style.BackColor = Color.White
                        dgvCampos.Item(13, e.RowIndex).Value = True
                    End If

                ElseIf dgvCampos.Item(10, e.RowIndex).Value.ToString = "" Then
                    If dgvCampos.Columns.Count > 12 Then
                        dgvCampos.Item(12, e.RowIndex).ReadOnly = True
                        dgvCampos.Item(12, e.RowIndex).Style.BackColor = Color.LightGray
                        dgvCampos.Item(12, e.RowIndex).Value = False
                        dgvCampos.Item(13, e.RowIndex).ReadOnly = True
                        dgvCampos.Item(13, e.RowIndex).Style.BackColor = Color.LightGray
                        dgvCampos.Item(13, e.RowIndex).Value = False
                    End If
                End If
            End If

            dgvCampos.UpdateCellValue(e.ColumnIndex, e.RowIndex)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvCampos_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvCampos.CellBeginEdit
        If e.ColumnIndex = 8 Then
            dgvCampos.Item(9, e.RowIndex).Value = ""
            dgvCampos.Item(10, e.RowIndex).Value = ""
        ElseIf e.ColumnIndex = 10 Then
            Try
                If dgvCampos.Item(8, e.RowIndex).Value.ToString <> "" Then
                    Dim dgcb As New DataGridViewComboBoxCell
                    generador.HacerColumnComboboxconFiltro(dgvCampos.Item(8, e.RowIndex).Value.ToString, generador.arrEstructura2, dgcb)
                    dgvCampos.Item(e.ColumnIndex, e.RowIndex) = dgcb
                End If
            Catch
                Dim dgtf As New DataGridViewTextBoxCell
                dgtf.Value = dgvCampos.Item(8, e.RowIndex).Value
                dgvCampos.Item(e.ColumnIndex, e.RowIndex) = dgtf
            End Try
        End If
    End Sub

    Public Sub tableCombo_selectedValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 8 Then
            dgvCampos.Item(9, e.RowIndex).Value = ""
            dgvCampos.Item(10, e.RowIndex).Value = ""
        ElseIf e.ColumnIndex = 10 Then
            Try
                If dgvCampos.Item(8, e.RowIndex).Value.ToString <> "" Then
                    Dim dgcb As New DataGridViewComboBoxCell
                    dgcb = generador.HacerColumnComboboxconFiltro(dgvCampos.Item(8, e.RowIndex).Value.ToString, generador.arrEstructura2, dgcb)
                    dgvCampos.Item(e.ColumnIndex, e.RowIndex) = dgcb
                End If
            Catch
            End Try
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGenerar.Click
        If Not System.IO.Directory.Exists(txtRuta.Text) Then
            MessageBox.Show("Ruta incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If chbSeraForanea.Checked And cboSeraForanea.Text.Length = 0 Then
            MessageBox.Show("Por favor especificar el campo a mostrar")
            Exit Sub
        ElseIf generador.database.ArmarCadenaConexion() Then
            If Me.chbCrearCampos.Checked Then
                If Not generador.database.ExisteCampoUsuarioModificacion(DataBase.CadenaConexion) Then
                    If Not generador.database.CrearCamposUsuarioModificacion(cboTabla.Text, DataBase.CadenaConexion) Then
                        MessageBox.Show("Error al crear los campos UsuarioModificacion y FechaModificacion", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                If Not generador.database.ExisteCampoFechaModificacion(DataBase.CadenaConexion) Then
                    If Not generador.database.CrearCamposFechaModificacion(cboTabla.Text, DataBase.CadenaConexion) Then
                        MessageBox.Show("Error al crear los campos UsuarioModificacion y FechaModificacion", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If

            '  Dim i As Integer = 0
            Dim reg As RegCampo
            Dim ConLlave As Boolean = False

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Try
                
                Dim tope As Integer = generador.arrEstructura.Count - 1
                Dim j As Integer = 0
                For i As Integer = 0 To tope
                    reg = generador.arrEstructura(j)

                    If IsDBNull(generador.dtsCam.Item(i).Tipo) Or generador.dtsCam.Item(i).Tipo.ToString = "" Then
                        MessageBox.Show("Especifique el tipo de dato en la fila " & i + 1)
                        Exit Sub
                    End If






                    reg.tipo = generador.dtsCam.Item(i).Tipo
                    reg.nombre = generador.dtsCam.Item(i).Nombre
                    reg.EsLlave = generador.dtsCam.Item(i).EsLlave
                    reg.EsUnico = generador.dtsCam.Item(i).EsUnico
                    reg.CaracterMinimo = generador.dtsCam.Item(i).CaracteresMinimos
                    reg.CaracterMaximo = generador.dtsCam.Item(i).CaracteresMaximos
                    reg.EsObligatorio = generador.dtsCam.Item(i).Obligatorio
                    reg.TablaForanea = dgvCampos.Item(8, i).Value.ToString
                    reg.CampoIDForaneo = If(dgvCampos.Item(9, i).Value.ToString = "", generador.database.recuperarClave(DataBase.CadenaConexion, reg.TablaForanea), dgvCampos.Item(9, i).Value.ToString)
                    reg.CampoForaneo = dgvCampos.Item(10, i).Value.ToString
                    reg.MostrarEnGrilla = generador.dtsCam.Item(i).MostrarEnGrilla
                    'arrEstructura(i).Ver = generador.dtsCam.Item(i).Ver
                    'arrEstructura(i).Add = generador.dtsCam.Item(i).Add
                    reg.Fecha = generador.dtsCam.Item(i).TipoFecha

                    If generador.dtsCam.Item(i).EsLlave Then
                        ConLlave = True
                    End If

                    'If Not reg.IsNullable Then
                    '    reg.EsObligatorioPorUsuario = dgvCampos.Rows(i).Cells("obligatorio").Value
                    'End If

                    If generador.dtsCam.Item(i).Tipo = "String" Then
                        If generador.dtsCam.Item(i).CaracteresMaximos.ToString.Length = 0 Or generador.dtsCam.Item(i).CaracteresMaximos <= 0 Then
                            MessageBox.Show("Introduzca valor para Caracter Maximo en la fila " & i + 1)
                            Exit Sub
                        End If
                    End If

                    If Me.cbCrearcampos.Checked Then
                        If Not generador.dtsCam.Item(i).MostrarEnGrilla Then
                            generador.arrEstructura.Remove(reg)
                        Else
                            j = j + 1
                        End If
                    Else
                        j = j + 1
                    End If

                    'i = i + 1

                Next

              
                generador.ruta = Me.txtRuta.Text
                Dim clase As String

                If Me.chbNuevoNombre.Checked Then
                    clase = Me.txtNuevoNombre.Text
                Else
                    clase = cboTabla.Text.Replace(" ", "")
                End If

                If chbVersion.Checked Then
                    clase = clase & txtVersion.Text
                End If

                generador.DBO = Me.cbDbo.Checked
                generador.SQL = Me.cbSQL.Checked
                generador.formulario_consulta = Me.cbFrm.Checked
                generador.formulario_entrada = Me.cbfrmEnt.Checked
                generador.stored_procedure = Me.cbSp.Checked

                If generador.GenerarArchivos(cboTabla.Text.Replace(" ", ""), cboFilter.Text, _
                                             chbMD.Checked, clase, _
                                             txtVersion.Text.Trim.Replace(" ", ""), _
                                             chbSeraForanea.Checked, cboSeraForanea.Text, _
                                             chbRunProcedures.Checked, cboFilter.Text) Then
                    MessageBox.Show("Se ha generado el codigo basándose en la tabla '" & cboTabla.Text & "'." & Chr(13) & ". Los archivos resultantes se han grabado en " & txtRuta.Text & Chr(13) & vbNewLine & "Arrancar LA si no lo esta. Refrescar el explorador de Soluciones e Incluir la carpeta que hemos creado", "Generación declases", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    gNombreTabla = cboTabla.Text
                End If
            Catch ex As Exception
                MessageBox.Show("Error al generar los archivos. Detalles: " & vbLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                Me.Cursor = Cursors.Default
                Me.Enabled = True
            End Try
        End If
    End Sub

    Private Sub chkPostfix_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbVersion.CheckedChanged
        lblPostfix.Enabled = chbVersion.Checked
        txtVersion.Enabled = chbVersion.Checked
    End Sub

    Private Sub chbMD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbMD.CheckedChanged
        If chbMD.Checked = True Then
            cboFilter.Enabled = True
        Else
            cboFilter.SelectedIndex = -1
            cboFilter.Enabled = False
        End If
    End Sub

    Private Sub dgvCampos_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCampos.DataError
        'messagebox.show(e.Exception.Message)
    End Sub

    Private Sub dgvCampos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCampos.CellEndEdit
        dgvCampos.UpdateCellValue(e.ColumnIndex, e.RowIndex)
    End Sub

    Private Sub cbLocal_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If generador.database.ArmarCadenaConexion() Then
            If generador.database.get_Tablas(cboTabla) Then
                'txtRuta.Text = "Seleccionar ruta del codigo"
                butGenerar.Enabled = True
                dgvCampos.DataSource = Nothing
            End If
        Else
            butGenerar.Enabled = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmGenerador_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub

    Private Sub btnConexion_Click(sender As System.Object, e As System.EventArgs) Handles btnConexion.Click
        Dim frm As New frmConexion
        Dim dlg As DialogResult = frm.ShowDialog()
        If dlg = Windows.Forms.DialogResult.OK Then
            generador.database.configuracion = frm.configuracion
            generador.database.guardar()

            Me.Cursor = Cursors.WaitCursor
            lConexionMessage.Text = frm.configuracion.Server & ":" & frm.configuracion.DatabaseName
            btnConexion.Image = My.Resources.network_transmit
            If generador.database.ArmarCadenaConexion() Then
                If generador.database.get_Tablas(cboTabla) Then
                    'txtRuta.Text = "Seleccionar ruta del codigo"
                    butGenerar.Enabled = True
                    dgvCampos.DataSource = Nothing
                End If
            Else
                butGenerar.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Else
            lConexionMessage.Text = "Sin conexión"
            btnConexion.Image = My.Resources.network_offline_2
        End If


    End Sub

    Private Sub GUI_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Me.Options.Ruta = txtRuta.Text
            Me.Options.Tabla = Me.cboTabla.SelectedValue
            Me.Options.Ejecutar = Me.chbRunProcedures.Checked
            Me.Options.Combo = Me.chbCrearCampos.Checked
            Options.Versionar = Me.chbVersion.Checked
            Options.version = txtVersion.Text
            Me.Options.save()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnMostrarOpciones_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarOpciones.Click
        If SplitContainer2.Panel1Collapsed Then
            SplitContainer2.Panel1Collapsed = False
        Else
            SplitContainer2.Panel1Collapsed = True
        End If
    End Sub

    Private Sub btnCerrarOpciones_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarOpciones.Click
        SplitContainer2.Panel1Collapsed = True
    End Sub
End Class

