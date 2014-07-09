Public Class Designer
    Inherits GeneratorFile
    Implements Writable


    Private but, but1, but2, holdMod, tabCount As Integer

    Public Sub New(ByVal ruta As String, ByRef estructura As Generic.List(Of RegCampo), ByVal clase As String)
        MyBase.New(ruta, estructura, clase)
    End Sub


    Private Sub InitBut_But1_But2(ByVal mSize As Integer)
        but = but + mSize + 6
        '''''
        holdMod = tabCount Mod 2
        If holdMod = 0 Then 'left column
            but1 = but1 + mSize + 6
        Else
            but2 = but2 + mSize + 6
        End If
        If but2 > but1 Then
            but1 = but2
        End If
    End Sub

    Public Sub frm_resx()

        '-------------------------------------------------frmTemplate.resx--------------------------------------------------------------------------
        FileOpen(libre, m_ruta & "frm" &clase & ".resx", OpenMode.Output)
        PrintLine(libre, "<?xml version=""1.0"" encoding=""utf-8""?>")
        PrintLine(libre, "<root>")
        PrintLine(libre, "  <!-- ")
        PrintLine(libre, "    Microsoft ResX Schema ")
        PrintLine(libre, "    ")
        PrintLine(libre, "    Version 2.0")
        PrintLine(libre, "    ")
        PrintLine(libre, "    The primary goals of this format is to allow a simple XML format ")
        PrintLine(libre, "    that is mostly human readable. The generation and parsing of the ")
        PrintLine(libre, "    various data types are done through the TypeConverter classes ")
        PrintLine(libre, "    associated with the data types.")
        PrintLine(libre, "    ")
        PrintLine(libre, "    Example:")
        PrintLine(libre, "    ")
        PrintLine(libre, "    .. ado.net/XML headers & schema ..")
        PrintLine(libre, "    <resheader name=""resmimetype"">text/microsoft-resx</resheader>")
        PrintLine(libre, "    <resheader name=""version"">2.0</resheader>")
        PrintLine(libre, "    <resheader name=""reader"">System.Resources.ResXResourceReader, System.Windows.Forms, ..</resheader>")
        PrintLine(libre, "    <resheader name=""writer"">System.Resources.ResXResourceWriter, System.Windows.Forms, ..</resheader>")
        PrintLine(libre, "    <data name=""Name1""><value>this is my long string</value><comment>this is a comment</comment></data>")
        PrintLine(libre, "    <data name=""Color1"" type=""System.Drawing.Color, System.Drawing"">Blue</data>")
        PrintLine(libre, "    <data name=""Bitmap1"" mimetype=""application/x-microsoft.net.object.binary.base64"">")
        PrintLine(libre, "        <value>[base64 mime encoded serialized .NET Framework object]</value>")
        PrintLine(libre, "    </data>")
        PrintLine(libre, "    <data name=""Icon1"" type=""System.Drawing.Icon, System.Drawing"" mimetype=""application/x-microsoft.net.object.bytearray.base64"">")
        PrintLine(libre, "        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>")
        PrintLine(libre, "        <comment>This is a comment</comment>")
        PrintLine(libre, "    </data>")
        PrintLine(libre, "                ")
        PrintLine(libre, "    There are any number of ""resheader"" rows that contain simple ")
        PrintLine(libre, "    name/value pairs.")
        PrintLine(libre, "    ")
        PrintLine(libre, "    Each data row contains a name, and value. The row also contains a ")
        PrintLine(libre, "    type or mimetype. Type corresponds to a .NET class that support ")
        PrintLine(libre, "    text/value conversion through the TypeConverter architecture. ")
        PrintLine(libre, "    Classes that don't support this are serialized and stored with the ")
        PrintLine(libre, "    mimetype set.")
        PrintLine(libre, "    ")
        PrintLine(libre, "    The mimetype is used for serialized objects, and tells the ")
        PrintLine(libre, "    ResXResourceReader how to depersist the object. This is currently not ")
        PrintLine(libre, "    extensible. For a given mimetype the value must be set accordingly:")
        PrintLine(libre, "    ")
        PrintLine(libre, "    Note - application/x-microsoft.net.object.binary.base64 is the format ")
        PrintLine(libre, "    that the ResXResourceWriter will generate, however the reader can ")
        PrintLine(libre, "    read any of the formats listed below.")
        PrintLine(libre, "    ")
        PrintLine(libre, "    mimetype: application/x-microsoft.net.object.binary.base64")
        PrintLine(libre, "    value   : The object must be serialized with ")
        PrintLine(libre, "            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter")
        PrintLine(libre, "            : and then encoded with base64 encoding.")
        PrintLine(libre, "    ")
        PrintLine(libre, "    mimetype: application/x-microsoft.net.object.soap.base64")
        PrintLine(libre, "    value   : The object must be serialized with ")
        PrintLine(libre, "            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter")
        PrintLine(libre, "            : and then encoded with base64 encoding.")
        PrintLine(libre, "")
        PrintLine(libre, "    mimetype: application/x-microsoft.net.object.bytearray.base64")
        PrintLine(libre, "    value   : The object must be serialized into a byte array ")
        PrintLine(libre, "            : using a System.ComponentModel.TypeConverter")
        PrintLine(libre, "            : and then encoded with base64 encoding.")
        PrintLine(libre, "    -->")
        PrintLine(libre, "  <xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">")
        PrintLine(libre, "    <xsd:import namespace=""http://www.w3.org/XML/1998/namespace"" />")
        PrintLine(libre, "    <xsd:element name=""root"" msdata:IsDataSet=""true"">")
        PrintLine(libre, "      <xsd:complexType>")
        PrintLine(libre, "        <xsd:choice maxOccurs=""unbounded"">")
        PrintLine(libre, "          <xsd:element name=""metadata"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:sequence>")
        PrintLine(libre, "                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" />")
        PrintLine(libre, "              </xsd:sequence>")
        PrintLine(libre, "              <xsd:attribute name=""name"" use=""required"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute name=""type"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute name=""mimetype"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute ref=""xml:space"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "          <xsd:element name=""assembly"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:attribute name=""alias"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute name=""name"" type=""xsd:string"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "          <xsd:element name=""data"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:sequence>")
        PrintLine(libre, "                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />")
        PrintLine(libre, "                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />")
        PrintLine(libre, "              </xsd:sequence>")
        PrintLine(libre, "              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" msdata:Ordinal=""1"" />")
        PrintLine(libre, "              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""3"" />")
        PrintLine(libre, "              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""4"" />")
        PrintLine(libre, "              <xsd:attribute ref=""xml:space"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "          <xsd:element name=""resheader"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:sequence>")
        PrintLine(libre, "                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />")
        PrintLine(libre, "              </xsd:sequence>")
        PrintLine(libre, "              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "        </xsd:choice>")
        PrintLine(libre, "      </xsd:complexType>")
        PrintLine(libre, "    </xsd:element>")
        PrintLine(libre, "  </xsd:schema>")
        PrintLine(libre, "  <resheader name=""resmimetype"">")
        PrintLine(libre, "    <value>text/microsoft-resx</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <resheader name=""version"">")
        PrintLine(libre, "    <value>2.0</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <resheader name=""reader"">")
        PrintLine(libre, "    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <resheader name=""writer"">")
        PrintLine(libre, "    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <metadata name=""GeneralBindingSource.TrayLocation"" type=""System.Drawing.Point, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"">")
        PrintLine(libre, "    <value>132, 17</value>")
        PrintLine(libre, "  </metadata>")
        PrintLine(libre, "</root>")
        FileClose(libre)
    End Sub

    Public Sub frm_Designer_vb()

        '-------------------------------------------------frmTemplate.Designer.vb--------------------------------------------------------------------------
        FileOpen(libre, m_ruta & "frm" &clase & ".Designer.vb", OpenMode.Output)
        PrintLine(libre, "<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _")
        PrintLine(libre, "Partial Class frm" &clase & "")
        PrintLine(libre, "    Inherits BasesParaCompatibilidad.gridsimpleform")
        PrintLine(libre, "")
        PrintLine(libre, "    'Form invalida a Dispose para limpiar la lista de componentes.")
        PrintLine(libre, "    <System.Diagnostics.DebuggerNonUserCode()> _")
        PrintLine(libre, "    Protected Overrides Sub Dispose(ByVal disposing As Boolean)")
        PrintLine(libre, "        If disposing AndAlso components IsNot Nothing Then")
        PrintLine(libre, "            components.Dispose()")
        PrintLine(libre, "        End If")
        PrintLine(libre, "        MyBase.Dispose(disposing)")
        PrintLine(libre, "    End Sub")
        PrintLine(libre, "")
        PrintLine(libre, "    'Requerido por el Diseñador de Windows Forms")
        PrintLine(libre, "    Private components As System.ComponentModel.IContainer")
        PrintLine(libre, "")
        PrintLine(libre, "    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento")
        PrintLine(libre, "    'Se puede modificar usando el Diseñador de Windows Forms.  ")
        PrintLine(libre, "    'No lo modifique con el editor de código.")
        PrintLine(libre, "    <System.Diagnostics.DebuggerStepThrough()> _")
        PrintLine(libre, "    Private Sub InitializeComponent()")
        PrintLine(libre, "        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle")
        PrintLine(libre, "        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle")
        PrintLine(libre, "        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle")
        PrintLine(libre, "        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()")
        PrintLine(libre, "        Me.SuspendLayout()")
        PrintLine(libre, "        'frm" &clase & "")
        PrintLine(libre, "        '")
        PrintLine(libre, "        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)")
        PrintLine(libre, "        Me.ClientSize = New System.Drawing.Size(835, 461)")
        PrintLine(libre, "        Me.DoubleBuffered = True")
        PrintLine(libre, "        Me.MinimumSize = New System.Drawing.Size(400, 400)")
        PrintLine(libre, "        Me.Name = ""frm" &clase & """")
        PrintLine(libre, "        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent")
        PrintLine(libre, "        Me.Text = """ & System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(clase) & "")        
        PrintLine(libre, "        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()")
        PrintLine(libre, "        Me.ResumeLayout(False)")
        PrintLine(libre, "        Me.PerformLayout()")
        PrintLine(libre, "")
        PrintLine(libre, "    End Sub")
        PrintLine(libre, "")
        PrintLine(libre, "End Class")
        FileClose(libre)
    End Sub

    Public Sub frmEnt_Designer_vb()
        Dim reg As RegCampo

        '-------------------------------------------------frmEntTemplate.Designer.vb--------------------------------------------------------------------------
        FileOpen(libre, m_ruta & "frmEnt" &clase & ".Designer.vb", OpenMode.Output)
        PrintLine(libre, "<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _ ")
        PrintLine(libre, "Partial Class frmEnt" &clase)
        PrintLine(libre, "    Inherits BasesParaCompatibilidad.DetailedSimpleForm")
        PrintLine(libre, "")
        PrintLine(libre, "    'Form overrides dispose to clean up the component list.")
        PrintLine(libre, "    <System.Diagnostics.DebuggerNonUserCode()> _")
        PrintLine(libre, "    Protected Overrides Sub Dispose(ByVal disposing As Boolean)")
        PrintLine(libre, "        Try")
        PrintLine(libre, "            If disposing AndAlso components IsNot Nothing Then")
        PrintLine(libre, "                components.Dispose()")
        PrintLine(libre, "            End If")
        PrintLine(libre, "        Finally")
        PrintLine(libre, "            MyBase.Dispose(disposing)")
        PrintLine(libre, "        End Try")
        PrintLine(libre, "    End Sub")
        PrintLine(libre, "")
        PrintLine(libre, "    'Required by the Windows Form Designer")
        PrintLine(libre, "    Private components As System.ComponentModel.IContainer")
        PrintLine(libre, "")
        PrintLine(libre, "    'NOTE: The following procedure is required by the Windows Form Designer")
        PrintLine(libre, "    'It can be modified using the Windows Form Designer.  ")
        PrintLine(libre, "    'Do not modify it using the code editor.")
        PrintLine(libre, "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()")

        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                    Select Case reg.tipo
                        Case "Integer"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "Int32"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "Long"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "Double"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "Single"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "Decimal"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "DateTime"
                            PrintLine(libre, "        Me.dtp" & reg.nombre & " = New System.Windows.Forms.DateTimePicker()")
                        Case "Date"
                            PrintLine(libre, "        Me.dtp" & reg.nombre & " = New System.Windows.Forms.DateTimePicker()")
                        Case "TimeSpan"
                            PrintLine(libre, "        Me.dtp" & reg.nombre & " = New System.Windows.Forms.DateTimePicker()")
                        Case "String"
                            PrintLine(libre, "        Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox()")
                        Case "Boolean"
                            PrintLine(libre, "        Me.chb" & reg.nombre & " = New System.Windows.Forms.CheckBox()")
                        Case Else
                    End Select
                ElseIf reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & " = New System.Windows.Forms.ComboBox()")
                        If reg.Ver = True Then
                            PrintLine(libre, "        Me.butVer" & reg.nombre & " = New System.Windows.Forms.Button()")
                        End If
                        If reg.Add = True Then
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & " = New System.Windows.Forms.Button()")
                        End If
                    End If
                End If
                If Mid(reg.nombre, 1, 4) = "Ruta" Then
                    PrintLine(libre, "        Me.but" & reg.nombre & " = New System.Windows.Forms.Button()")
                    'PrintLine(libre, "        Me.butVer" & reg.nombre & " = New System.Windows.Forms.Button()")
                End If
            End If
        Next

        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                PrintLine(libre, "        Me.lbl" & reg.nombre & " = New System.Windows.Forms.Label")
            End If
        Next

        PrintLine(libre, "        Me.tlpMiddle = New System.Windows.Forms.TableLayoutPanel")
        'PrintLine(libre, "        Me.tlpTop = New System.Windows.Forms.TableLayoutPanel")
        PrintLine(libre, "        Me.tlpMiddle.SuspendLayout()")
        PrintLine(libre, "        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()")
        PrintLine(libre, "        Me.SuspendLayout()")

        Dim max0 As Integer = 0
        Dim max1 As Integer = 0

        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                max0 = CalcWidth(reg.nombre.Trim)
                If max0 > max1 Then
                    max1 = max0
                End If
            End If
        Next

        Dim lax0 As Integer = 0
        Dim lax1 As Integer = 0
        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" Then
                If reg.CampoForaneo <> "" Then 'combo 150(size)/9(font) = 16.66
                    'lax0 = 16
                    lax0 = 200
                Else
                    lax0 = reg.CaracterMaximo
                End If
                If Mid(reg.nombre, 1, 4) = "Ruta" Or reg.nombre = "Observaciones" Then
                    lax0 = 280
                End If
                If lax0 > lax1 Then
                    lax1 = lax0
                End If
            End If
        Next

        Dim fldW As Integer = 200
        lax1 = If(lax1 * 9 > 280, 280, lax1 * 9)  ' 9 is Font Size
        Dim frmW As Integer = 20 + max1 + 10 + lax1 + 20
        If frmW < 260 Then '260=length of Apply + space + Cancel + space + Close
            frmW = 10 + 260 + 10
        End If

        Dim ptW As Integer = fldW
        Dim txtptH As Integer = 21
        Dim lptX As Integer = 20
        Dim lptY As Integer = 40
        Dim rptY As Integer = 20 + max1 + 10
        Dim txtmptY As Integer = lptY
        but = 0
        but1 = 0
        but2 = 0

        Dim iTabIndex As Integer = 0
        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                    Select Case reg.tipo
                        Case "Boolean"
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        'chb" & reg.nombre & "")
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.Fill")
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".Name = ""chb" & reg.nombre & "")
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".TabIndex = " & iTabIndex)
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".FlatStyle = System.Windows.Forms.FlatStyle.Flat")
                            '
                        Case "DateTime"
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        'dtp" & reg.nombre & "")
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.None")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Name = ""dtp" & reg.nombre & "")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".TabIndex = " & iTabIndex)
                        Case "Date"
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        'dtp" & reg.nombre & "")
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.None")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Name = ""dtp" & reg.nombre & "")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".TabIndex = " & iTabIndex)
                        Case "TimeSpan"
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        'dtp" & reg.nombre & "")
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.None")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".ShowUpDown = True")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Name = ""dtp" & reg.nombre & "")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".TabIndex = " & iTabIndex)
                        Case Else
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        'txt" & reg.nombre & "")
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.Fill")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Name = ""txt" & reg.nombre & "")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".TabIndex = " & iTabIndex)
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle")
                            If Mid(reg.nombre, (Len(reg.nombre) - 1)) = "ID" Or reg.EsLlave Or reg.IsIdentity Or reg.IsKey Then
                                PrintLine(libre, "        Me.txt" & reg.nombre & ".Visible = False")
                            End If
                    End Select
                End If
                'OBLIGATORIO
                'If reg.IsNullable = False Then
                '    If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                '        If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                '            PrintLine(libre, "        Me.txt" & reg.nombre & ".Obligatorio = True")
                '        End If
                '    End If
                'End If
                If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                    Select Case reg.tipo
                        Case "Integer"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".MaxLength = 9")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".TextAlign = System.Windows.Forms.HorizontalAlignment.Right")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(" & (reg.CaracterMaximo * 9) + 20 & "," & txtptH & ")")
                        Case "Int32"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".MaxLength = 9")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".TextAlign = System.Windows.Forms.HorizontalAlignment.Right")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(" & (reg.CaracterMaximo * 9) + 20 & "," & txtptH & ")")
                        Case "Single"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".MaxLength = 9")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".TextAlign = System.Windows.Forms.HorizontalAlignment.Right")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(" & (reg.CaracterMaximo * 9) + 20 & "," & txtptH & ")")
                        Case "Decimal"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            'PrintLine(libre, "        Me.txt" & reg.nombre & ".Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".TextAlign = System.Windows.Forms.HorizontalAlignment.Right")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(" & (reg.CaracterMaximo * 9) + 20 & "," & txtptH & ")")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".Numerico_NumeroDecimales = " & reg.Scale)
                        Case "DateTime"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            If Mid(reg.nombre, 1, 4) = "Hora" Then
                                PrintLine(libre, "        Me.dtp" & reg.nombre & ".Format = System.Windows.Forms.DateTimePickerFormat.Time")
                                PrintLine(libre, "        Me.dtp" & reg.nombre & ".ShowUpDown = True")
                            Else
                                PrintLine(libre, "        Me.dtp" & reg.nombre & ".Format = System.Windows.Forms.DateTimePickerFormat.[Short]")
                            End If
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Size = New System.Drawing.Size(95," & txtptH & ")")
                        Case "Date"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                                PrintLine(libre, "        Me.dtp" & reg.nombre & ".Format = System.Windows.Forms.DateTimePickerFormat.[Short]")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Size = New System.Drawing.Size(95," & txtptH & ")")
                        Case "TimeSpan"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Format = System.Windows.Forms.DateTimePickerFormat.Time")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".ShowUpDown = True")
                            PrintLine(libre, "        Me.dtp" & reg.nombre & ".Size = New System.Drawing.Size(95," & txtptH & ")")
                        Case "String"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Window")
                            PrintLine(libre, "        Me.txt" & reg.nombre & ".MaxLength = " & reg.CaracterMaximo)
                            If Mid(reg.nombre, 1, 4) = "Ruta" Or reg.nombre = "Observaciones" Then
                                PrintLine(libre, "        Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(280," & txtptH * 2 & ")")
                                PrintLine(libre, "        Me.tlpMiddle.SetColumnSpan(Me.txt" & reg.nombre & ", 4)")
                            Else
                                PrintLine(libre, "        Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(" & ptW & "," & txtptH * 2 & ")")
                            End If
                        Case "Boolean"
                            InitBut_But1_But2(21)
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".BackColor = System.Drawing.SystemColors.Control")
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".UseVisualStyleBackColor = False")
                            PrintLine(libre, "        Me.chb" & reg.nombre & ".Size = New System.Drawing.Size(" & 16 & "," & txtptH & ")")
                        Case Else
                    End Select
                ElseIf reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then 'ComboBox
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        PrintLine(libre, "        '")
                        PrintLine(libre, "        'cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & "")
                        PrintLine(libre, "        '")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".Dock = System.Windows.Forms.DockStyle.Fill")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".Name = ""cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & "")
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".TabIndex = " & iTabIndex)
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".FlatStyle = System.Windows.Forms.FlatStyle.Flat")                        
                        InitBut_But1_But2(23)
                        PrintLine(libre, "        Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ".Size = New System.Drawing.Size(200," & txtptH & ")")
                        PrintLine(libre, "        '")
                        If reg.Ver = True Then
                            PrintLine(libre, "        'butVer" & reg.nombre & "")
                            PrintLine(libre, "        '")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.Fill")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".FlatAppearance.BorderSize = 0")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".FlatStyle = System.Windows.Forms.FlatStyle.Flat")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".Cursor = System.Windows.Forms.Cursors.Hand")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".Name = ""butVer" & reg.nombre & "")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".Image = Global.La_Andaluza.My.Resources.Resources.agenda")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".TabStop = False")
                            PrintLine(libre, "        Me.butVer" & reg.nombre & ".Size = New System.Drawing.Size(20, 20)")
                            PrintLine(libre, "        'butAdd" & reg.nombre & "")
                            PrintLine(libre, "        '")
                        End If
                        If reg.Add = True Then
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.Fill")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".FlatAppearance.BorderSize = 0")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".FlatStyle = System.Windows.Forms.FlatStyle.Flat")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".Cursor = System.Windows.Forms.Cursors.Hand")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".Image = Global.La_Andaluza.My.Resources.edit_add_2")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".Name = ""butAdd" & reg.nombre & "")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".TabStop = False")
                            PrintLine(libre, "        Me.butAdd" & reg.nombre & ".Size = New System.Drawing.Size(20, 20)")
                            PrintLine(libre, "        '")
                        End If
                    End If
                End If
                If Mid(reg.nombre, 1, 4) = "Ruta" Then
                    PrintLine(libre, "        '")
                    PrintLine(libre, "        'but" & reg.nombre & "")
                    PrintLine(libre, "        '")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.Fill")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Name = ""but" & reg.nombre & "")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".TabStop = False")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Cursor = System.Windows.Forms.Cursors.Hand")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".FlatAppearance.BorderSize = 0")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".FlatStyle = System.Windows.Forms.FlatStyle.Flat")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Size = New System.Drawing.Size(20, 20)")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Text = """"")
                    PrintLine(libre, "        Me.but" & reg.nombre & ".Image = Global.La_Andaluza.My.Resources.folder_magnify")      
                End If
                iTabIndex = iTabIndex + 1
            End If
            'End If
        Next
        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                PrintLine(libre, "        '")
                PrintLine(libre, "        'lbl" & reg.nombre & "")
                PrintLine(libre, "        '")
                PrintLine(libre, "        Me.lbl" & reg.nombre & ".Dock = System.Windows.Forms.DockStyle.Fill")
                PrintLine(libre, "        Me.lbl" & reg.nombre & ".Name = ""lbl" & reg.nombre & "")
                PrintLine(libre, "        Me.lbl" & reg.nombre & ".Text = """ & System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Replace(Replace(LCase(reg.nombre), "id_", ""), "id", "")) & "")
                PrintLine(libre, "        Me.lbl" & reg.nombre & ".TextAlign = System.Drawing.ContentAlignment.MiddleLeft")
                PrintLine(libre, "        Me.lbl" & reg.nombre & ".Size = New System.Drawing.Size(" & max1 & ",21)")
                PrintLine(libre, "        Me.lbl" & reg.nombre & ".Location = New System.Drawing.Point(" & lptX & "," & lptY & ")")
                If reg.nombre = "ID" Then
                    PrintLine(libre, "        Me.lbl" & reg.nombre & ".Visible = False")
                End If
            End If
        Next

        If but1 > but2 Then
            but = but1
        Else
            but = but2
        End If
        PrintLine(libre, "        '")
        PrintLine(libre, "        'tlpMiddle")
        PrintLine(libre, "        '")
        PrintLine(libre, "        Me.tlpMiddle.ColumnCount = 8")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())")
        PrintLine(libre, "        Me.tlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))")
        Dim iRow As Integer = 0

        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                    Select Case reg.tipo
                        Case "Boolean"
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.lbl" & reg.nombre & ", 1, " & iRow & ")")
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.chb" & reg.nombre & ", 2, " & iRow & ")")
                        Case "DateTime"
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.lbl" & reg.nombre & ", 1, " & iRow & ")")
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.dtp" & reg.nombre & ", 2, " & iRow & ")")
                        Case "Date"
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.lbl" & reg.nombre & ", 1, " & iRow & ")")
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.dtp" & reg.nombre & ", 2, " & iRow & ")")
                        Case "TimeSpan"
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.lbl" & reg.nombre & ", 1, " & iRow & ")")
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.dtp" & reg.nombre & ", 2, " & iRow & ")")
                        Case Else
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.lbl" & reg.nombre & ", 1, " & iRow & ")")
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.txt" & reg.nombre & ", 2, " & iRow & ")")
                    End Select
                ElseIf reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" Then 'ComboBox
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.lbl" & reg.nombre & ", 1, " & iRow & ")")
                        PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & ", 2, " & iRow & ")")
                        If reg.Ver = True Then
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.butVer" & reg.nombre & ", 3, " & iRow & ")")
                        End If
                        If reg.Add = True Then
                            PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.butAdd" & reg.nombre & ", 4, " & iRow & ")")
                        End If
                    End If
                End If
                If Mid(reg.nombre, 1, 4) = "Ruta" Then
                    PrintLine(libre, "        Me.tlpMiddle.Controls.Add(Me.but" & reg.nombre & ", 6, " & iRow & ")")
                End If
                iRow = iRow + 1
            End If
        Next

        PrintLine(libre, "        Me.tlpMiddle.Location = New System.Drawing.Point(0, 25)")
        PrintLine(libre, "        Me.tlpMiddle.Name = ""tlpMiddle""")
        PrintLine(libre, "        Me.tlpMiddle.RowCount = " & iRow + 1 & "")
        PrintLine(libre, "        Me.tlpMiddle.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)")

        For iR As Integer = 0 To iRow - 1
            PrintLine(libre, "        Me.tlpMiddle.RowStyles.Add(New System.Windows.Forms.RowStyle)")
        Next

        PrintLine(libre, "        Me.tlpMiddle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))")

        Dim isExists As Boolean = False
        For Each reg In arrEstructura
            If Mid(reg.nombre, 1, 4) = "Ruta" Or reg.nombre = "Observaciones" Then
                isExists = True
            End If
        Next
        If isExists = True Then
            PrintLine(libre, "        Me.tlpMiddle.Size = New System.Drawing.Size(" & frmW + 27 + 2 & ", " & but & ")")
        Else
            PrintLine(libre, "        Me.tlpMiddle.Size = New System.Drawing.Size(" & frmW & ", " & but & ")")
        End If

        PrintLine(libre, "        '")
        'PrintLine(libre, "        'tlpTop")
        'PrintLine(libre, "        '")
        ' PrintLine(libre, "        Me.tlpTop.Location = New System.Drawing.Point(0, 0)")
        ' PrintLine(libre, "        Me.tlpTop.Name = ""tlpTop""")
        ' PrintLine(libre, "        Me.tlpTop.Size = New System.Drawing.Size(200, 100)")
        'PrintLine(libre, "        Me.tlpTop.TabIndex = 0")
        PrintLine(libre, "        '")
        PrintLine(libre, "        'frmEnt" &clase)
        PrintLine(libre, "        '")
        PrintLine(libre, "        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)")
        PrintLine(libre, "        Me.Controls.Add(Me.tlpMiddle)")
        If isExists = True Then
            PrintLine(libre, "        Me.ClientSize = New System.Drawing.Size(" & frmW + 27 + 2 & ", " & 32 + 8 + but + 8 + 32 + 0 & ")")
            PrintLine(libre, "        Me.MinimumSize = New System.Drawing.Size(" & frmW + 27 + 2 & ", " & 32 + 8 + but + 8 + 32 + 0 & ")")
        Else
            PrintLine(libre, "        Me.ClientSize = New System.Drawing.Size(" & frmW & ", " & 32 + 8 + but + 8 + 32 + 0 & ")")
            PrintLine(libre, "        Me.MinimumSize = New System.Drawing.Size(" & frmW & ", " & 32 + 8 + but + 8 + 32 + 0 & ")")
        End If
        PrintLine(libre, "        Me.Name = ""frmEnt" &clase & "")
        PrintLine(libre, "        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent")
        PrintLine(libre, "        Me.Text = """ &clase & """")
        PrintLine(libre, "        Me.Controls.SetChildIndex(Me.tlpMiddle, 0)")
        PrintLine(libre, "        Me.tlpMiddle.ResumeLayout(False)")
        PrintLine(libre, "        Me.tlpMiddle.Dock = System.Windows.Forms.DockStyle.None")
        PrintLine(libre, "        Me.tlpMiddle.Autosize = True")
        PrintLine(libre, "        Me.Size = new Size(" & frmW & "," & but * (arrEstructura.Count + 3) & ")")
        PrintLine(libre, "        Me.tlpMiddle.PerformLayout()")
        PrintLine(libre, "        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()")
        PrintLine(libre, "        Me.ResumeLayout(False)")
        PrintLine(libre, "")
        PrintLine(libre, TAB(8), "End Sub")
        PrintLine(libre, "")

        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                If reg.TablaForanea = "" Or reg.CampoIDForaneo = "" Or reg.CampoForaneo = "" Then
                    Select Case reg.tipo
                        Case "Integer"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "Int32"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "Long"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "Double"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "Single"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "Decimal"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "DateTime"
                            PrintLine(libre, "    Private WithEvents dtp" & reg.nombre & " As System.Windows.Forms.DateTimePicker")
                        Case "Date"
                            PrintLine(libre, "    Private WithEvents dtp" & reg.nombre & " As System.Windows.Forms.DateTimePicker")
                        Case "TimeSpan"
                            PrintLine(libre, "    Private WithEvents dtp" & reg.nombre & " As System.Windows.Forms.DateTimePicker")
                        Case "String"
                            PrintLine(libre, "    Private WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
                        Case "Boolean"
                            PrintLine(libre, "    Private WithEvents chb" & reg.nombre & " As System.Windows.Forms.CheckBox")
                        Case Else
                    End Select
                ElseIf reg.TablaForanea <> "" And reg.CampoIDForaneo <> "" And reg.CampoForaneo <> "" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                    If reg.tipo <> "DateTime" And reg.tipo <> "Boolean" Then
                        PrintLine(libre, "    Private WithEvents cbo" & Replace(Replace(reg.nombre, "Id_", ""), "ID", "") & " As System.Windows.Forms.ComboBox")
                        If reg.Ver = True Then
                            PrintLine(libre, "    Private WithEvents butVer" & reg.nombre & " As System.Windows.Forms.Button")
                        End If
                        If reg.Add = True Then
                            PrintLine(libre, "    Private WithEvents butAdd" & reg.nombre & " As System.Windows.Forms.Button")
                        End If
                    End If
                End If
                If Mid(reg.nombre, 1, 4) = "Ruta" Then
                    PrintLine(libre, "    Private WithEvents but" & reg.nombre & " As System.Windows.Forms.Button")
                    'PrintLine(libre, "    Private WithEvents butVer" & reg.nombre & " As System.Windows.Forms.Button")
                End If
            End If
        Next

        For Each reg In arrEstructura
            If reg.nombre <> "FechaModificacion" And reg.nombre <> "UsuarioModificacion" And Not reg.EsLlave And Not reg.IsIdentity And Not reg.IsKey Then
                PrintLine(libre, "    Private WithEvents lbl" & reg.nombre & " As System.Windows.Forms.Label")
            End If
        Next

        PrintLine(libre, "    Private WithEvents tlpMiddle As System.Windows.Forms.TableLayoutPanel")
        'PrintLine(libre, "    Private WithEvents tlpTop As System.Windows.Forms.TableLayoutPanel")
        PrintLine(libre, "End Class")
        FileClose(libre)
    End Sub



    Public Sub frmEnt_resx()
        '-------------------------------------------------frmEntTemplate.resx--------------------------------------------------------------------------
        FileOpen(libre, m_ruta & "frmEnt" &clase & ".resx", OpenMode.Output)
        PrintLine(libre, "<?xml version=""1.0"" encoding=""utf-8""?>")
        PrintLine(libre, "<root>")
        PrintLine(libre, "  <!-- ")
        PrintLine(libre, "    Microsoft ResX Schema ")
        PrintLine(libre, "")
        PrintLine(libre, "    Version 2.0")
        PrintLine(libre, "")
        PrintLine(libre, "    The primary goals of this format is to allow a simple XML format ")
        PrintLine(libre, "    that is mostly human readable. The generation and parsing of the ")
        PrintLine(libre, "    various data types are done through the TypeConverter classes ")
        PrintLine(libre, "    associated with the data types.")
        PrintLine(libre, "")
        PrintLine(libre, "    Example:")
        PrintLine(libre, "")
        PrintLine(libre, "    .. ado.net/XML headers & schema ..")
        PrintLine(libre, "    <resheader name=""resmimetype"">text/microsoft-resx</resheader>")
        PrintLine(libre, "    <resheader name=""version"">2.0</resheader>")
        PrintLine(libre, "    <resheader name=""reader"">System.Resources.ResXResourceReader, System.Windows.Forms, ..</resheader>")
        PrintLine(libre, "    <resheader name=""writer"">System.Resources.ResXResourceWriter, System.Windows.Forms, ..</resheader>")
        PrintLine(libre, "    <data name=""Name1""><value>this is my long string</value><comment>this is a comment</comment></data>")
        PrintLine(libre, "    <data name=""Color1"" type=""System.Drawing.Color, System.Drawing"">Blue</data>")
        PrintLine(libre, "    <data name=""Bitmap1"" mimetype=""application/x-microsoft.net.object.binary.base64"">")
        PrintLine(libre, "        <value>[base64 mime encoded serialized .NET Framework object]</value>")
        PrintLine(libre, "    </data>")
        PrintLine(libre, "    <data name=""Icon1"" type=""System.Drawing.Icon, System.Drawing"" mimetype=""application/x-microsoft.net.object.bytearray.base64"">")
        PrintLine(libre, "        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>")
        PrintLine(libre, "        <comment>This is a comment</comment>")
        PrintLine(libre, "    </data>")
        PrintLine(libre, "")
        PrintLine(libre, "    There are any number of ""resheader"" rows that contain simple ")
        PrintLine(libre, "    name/value pairs.")
        PrintLine(libre, "")
        PrintLine(libre, "    Each data row contains a name, and value. The row also contains a ")
        PrintLine(libre, "    type or mimetype. Type corresponds to a .NET class that support ")
        PrintLine(libre, "    text/value conversion through the TypeConverter architecture. ")
        PrintLine(libre, "    Classes that don't support this are serialized and stored with the ")
        PrintLine(libre, "    mimetype set.")
        PrintLine(libre, "")
        PrintLine(libre, "    The mimetype is used for serialized objects, and tells the ")
        PrintLine(libre, "    ResXResourceReader how to depersist the object. This is currently not ")
        PrintLine(libre, "    extensible. For a given mimetype the value must be set accordingly:")
        PrintLine(libre, "")
        PrintLine(libre, "    Note - application/x-microsoft.net.object.binary.base64 is the format ")
        PrintLine(libre, "    that the ResXResourceWriter will generate, however the reader can ")
        PrintLine(libre, "    read any of the formats listed below.")
        PrintLine(libre, "")
        PrintLine(libre, "    mimetype: application/x-microsoft.net.object.binary.base64")
        PrintLine(libre, "    value   : The object must be serialized with ")
        PrintLine(libre, "            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter")
        PrintLine(libre, "            : and then encoded with base64 encoding.")
        PrintLine(libre, "")
        PrintLine(libre, "    mimetype: application/x-microsoft.net.object.soap.base64")
        PrintLine(libre, "    value   : The object must be serialized with ")
        PrintLine(libre, "            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter")
        PrintLine(libre, "            : and then encoded with base64 encoding.")
        PrintLine(libre, "")
        PrintLine(libre, "    mimetype: application/x-microsoft.net.object.bytearray.base64")
        PrintLine(libre, "    value   : The object must be serialized into a byte array ")
        PrintLine(libre, "            : using a System.ComponentModel.TypeConverter")
        PrintLine(libre, "            : and then encoded with base64 encoding.")
        PrintLine(libre, "    -->")
        PrintLine(libre, "  <xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">")
        PrintLine(libre, "    <xsd:import namespace=""http://www.w3.org/XML/1998/namespace"" />")
        PrintLine(libre, "    <xsd:element name=""root"" msdata:IsDataSet=""true"">")
        PrintLine(libre, "      <xsd:complexType>")
        PrintLine(libre, "        <xsd:choice maxOccurs=""unbounded"">")
        PrintLine(libre, "          <xsd:element name=""metadata"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:sequence>")
        PrintLine(libre, "                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" />")
        PrintLine(libre, "              </xsd:sequence>")
        PrintLine(libre, "              <xsd:attribute name=""name"" use=""required"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute name=""type"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute name=""mimetype"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute ref=""xml:space"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "          <xsd:element name=""assembly"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:attribute name=""alias"" type=""xsd:string"" />")
        PrintLine(libre, "              <xsd:attribute name=""name"" type=""xsd:string"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "          <xsd:element name=""data"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:sequence>")
        PrintLine(libre, "                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />")
        PrintLine(libre, "                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />")
        PrintLine(libre, "              </xsd:sequence>")
        PrintLine(libre, "              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" msdata:Ordinal=""1"" />")
        PrintLine(libre, "              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""3"" />")
        PrintLine(libre, "              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""4"" />")
        PrintLine(libre, "              <xsd:attribute ref=""xml:space"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "          <xsd:element name=""resheader"">")
        PrintLine(libre, "            <xsd:complexType>")
        PrintLine(libre, "              <xsd:sequence>")
        PrintLine(libre, "                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />")
        PrintLine(libre, "              </xsd:sequence>")
        PrintLine(libre, "              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />")
        PrintLine(libre, "            </xsd:complexType>")
        PrintLine(libre, "          </xsd:element>")
        PrintLine(libre, "        </xsd:choice>")
        PrintLine(libre, "      </xsd:complexType>")
        PrintLine(libre, "    </xsd:element>")
        PrintLine(libre, "  </xsd:schema>")
        PrintLine(libre, "  <resheader name=""resmimetype"">")
        PrintLine(libre, "    <value>text/microsoft-resx</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <resheader name=""version"">")
        PrintLine(libre, "    <value>2.0</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <resheader name=""reader"">")
        PrintLine(libre, "    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <resheader name=""writer"">")
        PrintLine(libre, "    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, "  </resheader>")
        PrintLine(libre, "  <metadata name=""GeneralBindingSource.TrayLocation"" type=""System.Drawing.Point, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"">")
        PrintLine(libre, "    <value>125, 17</value>")
        PrintLine(libre, "  </metadata>")
        PrintLine(libre, "  <metadata name=""$this.TrayHeight"" type=""System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"">")
        PrintLine(libre, "    <value>48</value>")
        PrintLine(libre, "  </metadata>")
        PrintLine(libre, "</root>")
        FileClose(libre)
    End Sub


    Public Sub generateFile() Implements Writable.generateFile
        generate_frm()
        generate_frmEnt()
    End Sub

    Public Sub generate_frm()
        frm_resx()
        frm_Designer_vb()
    End Sub

    Public Sub generate_frmEnt()
        frmEnt_resx()
        frmEnt_Designer_vb()
    End Sub
End Class
