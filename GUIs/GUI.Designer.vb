<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
    Inherits System.Windows.Forms.Form

    ''Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI))
        Me.chbCrearCampos = New System.Windows.Forms.CheckBox()
        Me.chbVersion = New System.Windows.Forms.CheckBox()
        Me.dgvCampos = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblPostfix = New System.Windows.Forms.Label()
        Me.butGenerar = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grpInformacionclase = New System.Windows.Forms.GroupBox()
        Me.cbSQL = New System.Windows.Forms.CheckBox()
        Me.cbSp = New System.Windows.Forms.CheckBox()
        Me.cbDbo = New System.Windows.Forms.CheckBox()
        Me.cbFrm = New System.Windows.Forms.CheckBox()
        Me.cbfrmEnt = New System.Windows.Forms.CheckBox()
        Me.cboTabla = New System.Windows.Forms.ComboBox()
        Me.lblTabla = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnRuta = New System.Windows.Forms.Button()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.chbMD = New System.Windows.Forms.CheckBox()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.cboSeraForanea = New System.Windows.Forms.ComboBox()
        Me.chbSeraForanea = New System.Windows.Forms.CheckBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnMostrarOpciones = New System.Windows.Forms.Button()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.chbRunProcedures = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnConexion = New System.Windows.Forms.Button()
        Me.btnCerrarOpciones = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lConexionMessage = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbCrearcampos = New System.Windows.Forms.CheckBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chbNuevoNombre = New System.Windows.Forms.CheckBox()
        Me.txtNuevoNombre = New System.Windows.Forms.TextBox()
        CType(Me.dgvCampos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.grpInformacionclase.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbCrearCampos
        '
        Me.chbCrearCampos.AutoSize = True
        Me.chbCrearCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbCrearCampos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbCrearCampos.Location = New System.Drawing.Point(11, 104)
        Me.chbCrearCampos.Name = "chbCrearCampos"
        Me.chbCrearCampos.Size = New System.Drawing.Size(300, 17)
        Me.chbCrearCampos.TabIndex = 1000000035
        Me.chbCrearCampos.Text = "Crear los campos usuario y fecha de modificación"
        Me.chbCrearCampos.UseVisualStyleBackColor = True
        '
        'chbVersion
        '
        Me.chbVersion.AutoSize = True
        Me.chbVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbVersion.Location = New System.Drawing.Point(11, 41)
        Me.chbVersion.Name = "chbVersion"
        Me.chbVersion.Size = New System.Drawing.Size(12, 11)
        Me.chbVersion.TabIndex = 16
        Me.chbVersion.UseVisualStyleBackColor = True
        '
        'dgvCampos
        '
        Me.dgvCampos.AllowUserToAddRows = False
        Me.dgvCampos.AllowUserToDeleteRows = False
        Me.dgvCampos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCampos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCampos.Location = New System.Drawing.Point(0, 0)
        Me.dgvCampos.Name = "dgvCampos"
        Me.dgvCampos.RowHeadersVisible = False
        Me.dgvCampos.RowTemplate.Height = 24
        Me.dgvCampos.Size = New System.Drawing.Size(593, 501)
        Me.dgvCampos.TabIndex = 9
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(935, 10)
        Me.Panel6.TabIndex = 19
        '
        'lblPostfix
        '
        Me.lblPostfix.AutoSize = True
        Me.lblPostfix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostfix.Location = New System.Drawing.Point(32, 40)
        Me.lblPostfix.Name = "lblPostfix"
        Me.lblPostfix.Size = New System.Drawing.Size(95, 13)
        Me.lblPostfix.TabIndex = 18
        Me.lblPostfix.Text = "Numero versión"
        '
        'butGenerar
        '
        Me.butGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butGenerar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.butGenerar.Enabled = False
        Me.butGenerar.FlatAppearance.BorderSize = 0
        Me.butGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butGenerar.Image = CType(resources.GetObject("butGenerar.Image"), System.Drawing.Image)
        Me.butGenerar.Location = New System.Drawing.Point(3, 417)
        Me.butGenerar.Name = "butGenerar"
        Me.butGenerar.Size = New System.Drawing.Size(319, 49)
        Me.butGenerar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.butGenerar, "Generar")
        Me.butGenerar.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grpInformacionclase)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(325, 501)
        Me.Panel5.TabIndex = 16
        '
        'grpInformacionclase
        '
        Me.grpInformacionclase.Controls.Add(Me.cbSQL)
        Me.grpInformacionclase.Controls.Add(Me.cbSp)
        Me.grpInformacionclase.Controls.Add(Me.cbDbo)
        Me.grpInformacionclase.Controls.Add(Me.cbFrm)
        Me.grpInformacionclase.Controls.Add(Me.cbfrmEnt)
        Me.grpInformacionclase.Controls.Add(Me.cboTabla)
        Me.grpInformacionclase.Controls.Add(Me.lblTabla)
        Me.grpInformacionclase.Controls.Add(Me.Panel4)
        Me.grpInformacionclase.Controls.Add(Me.txtRuta)
        Me.grpInformacionclase.Controls.Add(Me.butGenerar)
        Me.grpInformacionclase.Controls.Add(Me.chbMD)
        Me.grpInformacionclase.Controls.Add(Me.cboFilter)
        Me.grpInformacionclase.Controls.Add(Me.cboSeraForanea)
        Me.grpInformacionclase.Controls.Add(Me.chbSeraForanea)
        Me.grpInformacionclase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpInformacionclase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInformacionclase.Location = New System.Drawing.Point(0, 32)
        Me.grpInformacionclase.Name = "grpInformacionclase"
        Me.grpInformacionclase.Size = New System.Drawing.Size(325, 469)
        Me.grpInformacionclase.TabIndex = 1
        Me.grpInformacionclase.TabStop = False
        '
        'cbSQL
        '
        Me.cbSQL.AutoSize = True
        Me.cbSQL.Checked = True
        Me.cbSQL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSQL.Location = New System.Drawing.Point(5, 268)
        Me.cbSQL.Margin = New System.Windows.Forms.Padding(2)
        Me.cbSQL.Name = "cbSQL"
        Me.cbSQL.Size = New System.Drawing.Size(157, 17)
        Me.cbSQL.TabIndex = 1000000034
        Me.cbSQL.Text = "Generar procedimientos"
        Me.cbSQL.UseVisualStyleBackColor = True
        '
        'cbSp
        '
        Me.cbSp.AutoSize = True
        Me.cbSp.Checked = True
        Me.cbSp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSp.Location = New System.Drawing.Point(5, 246)
        Me.cbSp.Margin = New System.Windows.Forms.Padding(2)
        Me.cbSp.Name = "cbSp"
        Me.cbSp.Size = New System.Drawing.Size(88, 17)
        Me.cbSp.TabIndex = 1000000033
        Me.cbSp.Text = "Generar SP"
        Me.cbSp.UseVisualStyleBackColor = True
        '
        'cbDbo
        '
        Me.cbDbo.AutoSize = True
        Me.cbDbo.Checked = True
        Me.cbDbo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbDbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbDbo.Location = New System.Drawing.Point(5, 224)
        Me.cbDbo.Margin = New System.Windows.Forms.Padding(2)
        Me.cbDbo.Name = "cbDbo"
        Me.cbDbo.Size = New System.Drawing.Size(98, 17)
        Me.cbDbo.TabIndex = 1000000032
        Me.cbDbo.Text = "Generar DBO"
        Me.cbDbo.UseVisualStyleBackColor = True
        '
        'cbFrm
        '
        Me.cbFrm.AutoSize = True
        Me.cbFrm.Checked = True
        Me.cbFrm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbFrm.Location = New System.Drawing.Point(5, 202)
        Me.cbFrm.Margin = New System.Windows.Forms.Padding(2)
        Me.cbFrm.Name = "cbFrm"
        Me.cbFrm.Size = New System.Drawing.Size(197, 17)
        Me.cbFrm.TabIndex = 1000000031
        Me.cbFrm.Text = "Generar formulario de consulta"
        Me.cbFrm.UseVisualStyleBackColor = True
        '
        'cbfrmEnt
        '
        Me.cbfrmEnt.AutoSize = True
        Me.cbfrmEnt.Checked = True
        Me.cbfrmEnt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbfrmEnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbfrmEnt.Location = New System.Drawing.Point(5, 180)
        Me.cbfrmEnt.Margin = New System.Windows.Forms.Padding(2)
        Me.cbfrmEnt.Name = "cbfrmEnt"
        Me.cbfrmEnt.Size = New System.Drawing.Size(192, 17)
        Me.cbfrmEnt.TabIndex = 1000000030
        Me.cbfrmEnt.Text = "Generar formulario de entrada"
        Me.cbfrmEnt.UseVisualStyleBackColor = True
        '
        'cboTabla
        '
        Me.cboTabla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTabla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTabla.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTabla.FormattingEnabled = True
        Me.cboTabla.Location = New System.Drawing.Point(3, 29)
        Me.cboTabla.Name = "cboTabla"
        Me.cboTabla.Size = New System.Drawing.Size(319, 21)
        Me.cboTabla.TabIndex = 3
        '
        'lblTabla
        '
        Me.lblTabla.AutoSize = True
        Me.lblTabla.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTabla.Location = New System.Drawing.Point(3, 16)
        Me.lblTabla.Name = "lblTabla"
        Me.lblTabla.Size = New System.Drawing.Size(39, 13)
        Me.lblTabla.TabIndex = 1
        Me.lblTabla.Text = "Tabla"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnRuta)
        Me.Panel4.Controls.Add(Me.lblRuta)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 356)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(319, 20)
        Me.Panel4.TabIndex = 1000000029
        '
        'btnRuta
        '
        Me.btnRuta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRuta.FlatAppearance.BorderSize = 0
        Me.btnRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRuta.Image = CType(resources.GetObject("btnRuta.Image"), System.Drawing.Image)
        Me.btnRuta.Location = New System.Drawing.Point(42, 3)
        Me.btnRuta.Name = "btnRuta"
        Me.btnRuta.Size = New System.Drawing.Size(25, 15)
        Me.btnRuta.TabIndex = 5
        Me.btnRuta.UseVisualStyleBackColor = True
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(2, 3)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 1000000020
        Me.lblRuta.Text = "Ruta"
        '
        'txtRuta
        '
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuta.Location = New System.Drawing.Point(3, 376)
        Me.txtRuta.MaxLength = 250
        Me.txtRuta.Multiline = True
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(319, 41)
        Me.txtRuta.TabIndex = 12
        Me.txtRuta.Text = "Seleccionar ruta del codigo"
        '
        'chbMD
        '
        Me.chbMD.AutoSize = True
        Me.chbMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbMD.Location = New System.Drawing.Point(6, 61)
        Me.chbMD.Name = "chbMD"
        Me.chbMD.Size = New System.Drawing.Size(231, 17)
        Me.chbMD.TabIndex = 1000000027
        Me.chbMD.Text = "Consulta Maestro-Detalle. Filtrar por:"
        Me.chbMD.UseVisualStyleBackColor = True
        '
        'cboFilter
        '
        Me.cboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Location = New System.Drawing.Point(6, 84)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(313, 21)
        Me.cboFilter.TabIndex = 1000000028
        '
        'cboSeraForanea
        '
        Me.cboSeraForanea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSeraForanea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSeraForanea.FormattingEnabled = True
        Me.cboSeraForanea.Location = New System.Drawing.Point(7, 143)
        Me.cboSeraForanea.Name = "cboSeraForanea"
        Me.cboSeraForanea.Size = New System.Drawing.Size(312, 21)
        Me.cboSeraForanea.TabIndex = 1000000026
        '
        'chbSeraForanea
        '
        Me.chbSeraForanea.AutoSize = True
        Me.chbSeraForanea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbSeraForanea.Location = New System.Drawing.Point(7, 119)
        Me.chbSeraForanea.Name = "chbSeraForanea"
        Me.chbSeraForanea.Size = New System.Drawing.Size(217, 17)
        Me.chbSeraForanea.TabIndex = 1000000023
        Me.chbSeraForanea.Text = "Consulta para comboBox. Mostrar:"
        Me.chbSeraForanea.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnMostrarOpciones)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(325, 32)
        Me.Panel7.TabIndex = 2
        '
        'btnMostrarOpciones
        '
        Me.btnMostrarOpciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarOpciones.FlatAppearance.BorderSize = 0
        Me.btnMostrarOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMostrarOpciones.Image = CType(resources.GetObject("btnMostrarOpciones.Image"), System.Drawing.Image)
        Me.btnMostrarOpciones.Location = New System.Drawing.Point(292, 0)
        Me.btnMostrarOpciones.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMostrarOpciones.Name = "btnMostrarOpciones"
        Me.btnMostrarOpciones.Size = New System.Drawing.Size(33, 32)
        Me.btnMostrarOpciones.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnMostrarOpciones, "Ver panel de opciones")
        Me.btnMostrarOpciones.UseVisualStyleBackColor = True
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(226, 37)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(47, 20)
        Me.txtVersion.TabIndex = 17
        '
        'chbRunProcedures
        '
        Me.chbRunProcedures.AutoSize = True
        Me.chbRunProcedures.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbRunProcedures.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbRunProcedures.Location = New System.Drawing.Point(11, 82)
        Me.chbRunProcedures.Name = "chbRunProcedures"
        Me.chbRunProcedures.Size = New System.Drawing.Size(286, 17)
        Me.chbRunProcedures.TabIndex = 1000000033
        Me.chbRunProcedures.Text = "Ejecutar los procedimientos creados al generar"
        Me.chbRunProcedures.UseVisualStyleBackColor = True
        '
        'btnConexion
        '
        Me.btnConexion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConexion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConexion.FlatAppearance.BorderSize = 0
        Me.btnConexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConexion.Image = Global.Generador.My.Resources.Resources.network_offline_2
        Me.btnConexion.Location = New System.Drawing.Point(14, 6)
        Me.btnConexion.Name = "btnConexion"
        Me.btnConexion.Size = New System.Drawing.Size(26, 20)
        Me.btnConexion.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.btnConexion, "Cambiar conexion")
        Me.btnConexion.UseVisualStyleBackColor = True
        '
        'btnCerrarOpciones
        '
        Me.btnCerrarOpciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrarOpciones.FlatAppearance.BorderSize = 0
        Me.btnCerrarOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarOpciones.Image = CType(resources.GetObject("btnCerrarOpciones.Image"), System.Drawing.Image)
        Me.btnCerrarOpciones.Location = New System.Drawing.Point(373, 0)
        Me.btnCerrarOpciones.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCerrarOpciones.Name = "btnCerrarOpciones"
        Me.btnCerrarOpciones.Size = New System.Drawing.Size(33, 31)
        Me.btnCerrarOpciones.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnCerrarOpciones, "Cerrar panel de opciones")
        Me.btnCerrarOpciones.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 10)
        Me.Panel3.MaximumSize = New System.Drawing.Size(42, 0)
        Me.Panel3.MinimumSize = New System.Drawing.Size(0, 528)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(14, 528)
        Me.Panel3.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(935, 0)
        Me.Panel2.MaximumSize = New System.Drawing.Size(42, 0)
        Me.Panel2.MinimumSize = New System.Drawing.Size(0, 585)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(14, 585)
        Me.Panel2.TabIndex = 31
        '
        'lConexionMessage
        '
        Me.lConexionMessage.AutoSize = True
        Me.lConexionMessage.Location = New System.Drawing.Point(45, 9)
        Me.lConexionMessage.Name = "lConexionMessage"
        Me.lConexionMessage.Size = New System.Drawing.Size(0, 13)
        Me.lConexionMessage.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbCrearcampos)
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 511)
        Me.Panel1.MaximumSize = New System.Drawing.Size(0, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(949, 29)
        Me.Panel1.TabIndex = 30
        '
        'cbCrearcampos
        '
        Me.cbCrearcampos.AutoSize = True
        Me.cbCrearcampos.Checked = True
        Me.cbCrearcampos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCrearcampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCrearcampos.Location = New System.Drawing.Point(345, 5)
        Me.cbCrearcampos.Margin = New System.Windows.Forms.Padding(2)
        Me.cbCrearcampos.Name = "cbCrearcampos"
        Me.cbCrearcampos.Size = New System.Drawing.Size(135, 17)
        Me.cbCrearcampos.TabIndex = 1000000035
        Me.cbCrearcampos.Text = "Generar procedimientos"
        Me.cbCrearcampos.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.lConexionMessage)
        Me.Panel11.Controls.Add(Me.btnConexion)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(340, 29)
        Me.Panel11.TabIndex = 19
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(14, 10)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(921, 501)
        Me.SplitContainer1.SplitterDistance = 325
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 21
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel8)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chbCrearCampos)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chbNuevoNombre)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chbRunProcedures)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtNuevoNombre)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblPostfix)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chbVersion)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtVersion)
        Me.SplitContainer2.Panel1Collapsed = True
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvCampos)
        Me.SplitContainer2.Size = New System.Drawing.Size(593, 501)
        Me.SplitContainer2.SplitterDistance = 406
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 33
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btnCerrarOpciones)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(406, 31)
        Me.Panel8.TabIndex = 1000000036
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Reemplazar el nombre"
        '
        'chbNuevoNombre
        '
        Me.chbNuevoNombre.AutoSize = True
        Me.chbNuevoNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbNuevoNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbNuevoNombre.Location = New System.Drawing.Point(11, 62)
        Me.chbNuevoNombre.Name = "chbNuevoNombre"
        Me.chbNuevoNombre.Size = New System.Drawing.Size(12, 11)
        Me.chbNuevoNombre.TabIndex = 19
        Me.chbNuevoNombre.UseVisualStyleBackColor = True
        '
        'txtNuevoNombre
        '
        Me.txtNuevoNombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNuevoNombre.Location = New System.Drawing.Point(166, 59)
        Me.txtNuevoNombre.Name = "txtNuevoNombre"
        Me.txtNuevoNombre.Size = New System.Drawing.Size(108, 13)
        Me.txtNuevoNombre.TabIndex = 20
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 540)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Name = "GUI"
        Me.Text = "Generador"
        CType(Me.dgvCampos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.grpInformacionclase.ResumeLayout(False)
        Me.grpInformacionclase.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chbCrearCampos As System.Windows.Forms.CheckBox
    Friend WithEvents chbVersion As System.Windows.Forms.CheckBox
    Friend WithEvents dgvCampos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents chbRunProcedures As System.Windows.Forms.CheckBox
    Friend WithEvents chbMD As System.Windows.Forms.CheckBox
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents cboSeraForanea As System.Windows.Forms.ComboBox
    Friend WithEvents chbSeraForanea As System.Windows.Forms.CheckBox
    Friend WithEvents cboTabla As System.Windows.Forms.ComboBox
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents btnConexion As System.Windows.Forms.Button
    Private WithEvents lConexionMessage As System.Windows.Forms.Label
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Private WithEvents btnRuta As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblPostfix As System.Windows.Forms.Label
    Private WithEvents lblTabla As System.Windows.Forms.Label
    Private WithEvents btnMostrarOpciones As System.Windows.Forms.Button
    Private WithEvents btnCerrarOpciones As System.Windows.Forms.Button
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Panel7 As System.Windows.Forms.Panel
    Private WithEvents Panel8 As System.Windows.Forms.Panel
    Private WithEvents Panel6 As System.Windows.Forms.Panel
    Private WithEvents grpInformacionclase As System.Windows.Forms.GroupBox
    Private WithEvents lblRuta As System.Windows.Forms.Label
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Panel11 As System.Windows.Forms.Panel
    Private WithEvents butGenerar As System.Windows.Forms.Button
    Private WithEvents txtRuta As System.Windows.Forms.TextBox
    Private WithEvents chbNuevoNombre As System.Windows.Forms.CheckBox
    Private WithEvents txtNuevoNombre As System.Windows.Forms.TextBox
    Private WithEvents cbSp As System.Windows.Forms.CheckBox
    Private WithEvents cbDbo As System.Windows.Forms.CheckBox
    Private WithEvents cbFrm As System.Windows.Forms.CheckBox
    Private WithEvents cbfrmEnt As System.Windows.Forms.CheckBox
    Private WithEvents cbSQL As System.Windows.Forms.CheckBox
    Private WithEvents cbCrearcampos As System.Windows.Forms.CheckBox
End Class
