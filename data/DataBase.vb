Imports System.Data.SqlClient

Public Class DataBase
    Public Shared TamanoTotal As Integer
    Public Shared CadenaConexion As String
    'Public Shared BD As String
    Private DatabaseConfig As DatabaseConfig

    Public ReadOnly Property Server As String
        Get
            Return Me.DatabaseConfig.server
        End Get
    End Property

    Public ReadOnly Property BDName As String
        Get
            Return Me.DatabaseConfig.DatabaseName
        End Get
    End Property

    Public WriteOnly Property configuracion As DatabaseConfig
        Set(value As DatabaseConfig)
            Me.DatabaseConfig = value
        End Set
    End Property

    Public Sub New()
        Me.DatabaseConfig = New DatabaseConfig
    End Sub

    Public Sub New(ByVal DatabaseConfig As DatabaseConfig)
        Me.DatabaseConfig = DatabaseConfig
    End Sub

    Public Function testDatabase(ByVal bdname As String, ByVal server As String, ByVal integratedsecurity As Boolean, Optional user As String = "", Optional pass As String = "") As Boolean
        Dim Cadena As String = ""       
        
        Cadena = "Data Source=" & server & ";"
       
        Cadena = Cadena & "Initial Catalog = " & bdname & ";"
        If integratedsecurity Then
            Cadena = Cadena & "Trusted_Connection=False"
        Else
            Cadena = Cadena & "User ID=" & user & ";Password=" & pass & ";Trusted_Connection=False"
        End If

        Dim myConnection As New SqlConnection(Cadena)
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataReader

        Try
            Dim strOwner As String = "dbo"            
            Dim mySelectQuery As String _
                    = " SELECT i1.TABLE_NAME, i2.COLUMN_NAME " _
                    & " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 " _
                    & " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME " _
                    & " WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY' "

            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()
            If myReader.Read() Then
                myReader.Close()
                myConnection.Close()

                Return True
            End If

        Catch ex As Exception
            Return False
        End Try
                
    End Function

    Public Function GetPrimaryKey(ByVal conexion As String, ByVal tabla As String, ByVal dgvCampos As DataGridView) As DataGridView
        Dim myConnection As New SqlConnection(conexion)
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataReader
        Dim valor As String

        Try
            Dim strOwner As String = "dbo"
            Dim strTable As String = tabla
            Dim mySelectQuery As String _
                    = " SELECT i1.TABLE_NAME, i2.COLUMN_NAME " _
                    & " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 " _
                    & " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME " _
                    & " WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY' " _
                    & " AND i1.TABLE_NAME = '" & strTable & "' "

            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()
            While myReader.Read()                
                Dim row As DataGridViewRow
                For Each row In dgvCampos.Rows
                    valor = If(IsDBNull(myReader.Item("TABLE_NAME")), "", myReader.Item("TABLE_NAME").ToString)
                    If row.Cells("TablaForanea").Value.ToString = valor Then
                        'dgvCampos.Item(9, i).Value = myReader.Item("COLUMN_NAME") '                            
                        row.Cells(9).Value = valor
                        row.Cells(10).Value = valor
                    End If
                Next
            End While
            myReader.Close()

            Return dgvCampos
        Catch ex As Exception
            Return dgvCampos
        Finally
            If Not myConnection Is Nothing Then If myConnection.State <> ConnectionState.Closed Then myConnection.Close()
        End Try
    End Function

    Function ArmarCadenaConexion() As Boolean
        '' Verifico que todos los datos hayan sido completados        
        'DataBase.CadenaConexion = ""
        ''DataBase.CadenaConexion = "Data Source=" & cbodataSource.SelectedValue.ToString & ";"
        ''DataBase.CadenaConexion = "Data Source=192.168.1.10;"

        'If guest Then
        '    DataBase.CadenaConexion = "Data Source=" & My.Computer.Name & "\SQLEXPRESS;"
        '    DataBase.CadenaConexion = DataBase.CadenaConexion & "Initial Catalog = PartesTrabajo1;"
        '    DataBase.CadenaConexion = DataBase.CadenaConexion & "Trusted_Connection=True"

        '    'DataBase.CadenaConexion = "Data Source=192.168.1.100;"
        '    'DataBase.CadenaConexion = DataBase.CadenaConexion & "Initial Catalog = LAGen;"
        '    'DataBase.CadenaConexion = DataBase.CadenaConexion & "User ID=ssa;Password=Trucha0122;Trusted_Connection=False"
        'Else
        '    If My.Computer.Name = "GERENTE1" Then
        '        DataBase.CadenaConexion = "Data Source=" & My.Computer.Name & ";"
        '    Else
        '        If My.Computer.Name = "home" Then
        '            DataBase.CadenaConexion = "Data Source=" & My.Computer.Name & ";"

        '        Else
        '            DataBase.CadenaConexion = "Data Source=" & My.Computer.Name & "\SQLEXPRESS;"
        '            'DataBase.CadenaConexion = "Data Source=SERVIDOR;"
        '            'DataBase.CadenaConexion = DataBase.CadenaConexion & "Initial Catalog = LAGen;"

        '        End If
        '        DataBase.CadenaConexion = DataBase.CadenaConexion & "Initial Catalog = LA;"
        '        DataBase.CadenaConexion = DataBase.CadenaConexion & "User ID=ssa;Password=Trucha0122;Trusted_Connection=False"

        '    End If
        '    'DataBase.CadenaConexion = "Data Source=" & My.Computer.Name & ";"

        '    'DataBase.CadenaConexion = DataBase.CadenaConexion & "Initial Catalog = LA;"
        '    'DataBase.CadenaConexion = DataBase.CadenaConexion & "Initial Catalog = LAGen;"
        '    'DataBase.CadenaConexion = DataBase.CadenaConexion & "Integrated Security = True"
        'End If
        If Me.DatabaseConfig.Server = "" Then Return False

        DataBase.CadenaConexion = "Data Source=" & Me.DatabaseConfig.Server & ";" & "Initial Catalog = " & DatabaseConfig.DatabaseName & ";"
        If DatabaseConfig.AuthIntegrated Then
            DataBase.CadenaConexion = DataBase.CadenaConexion & "Integrated Security = True"
        Else
            DataBase.CadenaConexion = DataBase.CadenaConexion & "User ID=ssa;Password=Trucha0122;Trusted_Connection=False"
        End If
        Return True
    End Function

    Public Shared Sub DeleteSP(ByVal sSP As String, ByVal sConnect As String)
        Try
            Dim mySelectQuery As String = "IF EXISTS (SELECT sys.objects.name FROM sys.objects INNER JOIN sys.schemas ON sys.objects.schema_id = sys.schemas.schema_id WHERE sys.objects.name = '" & sSP & "'  and sys.schemas.name = 'dbo'  and sys.objects.type = 'P') DROP PROCEDURE [dbo].[" & sSP & "]"
            Dim myConnection As New SqlConnection
            Dim myCommand As New SqlCommand
            myConnection = New SqlConnection(sConnect)
            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As SqlException
            messagebox.show(ex.Message)
        End Try
    End Sub

    Public Shared Sub ExecuteSP(ByVal sFile As String, ByVal sConnect As String)
        Try
            Dim mySelectQuery As String = My.Computer.FileSystem.ReadAllText(sFile)
            Dim myConnection As New SqlConnection
            Dim myCommand As New SqlCommand
            myConnection = New SqlConnection(sConnect)
            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As SqlException
            messagebox.show(ex.Message)
        End Try
    End Sub

    'mover a unaclase que realice consultas
    Public Sub get_Campos(ByVal Tabla As String, ByRef arrEstructura2 As Generic.List(Of RegCampo))
        Dim TotalCamposTabla As Integer

        ArmarCadenaConexion()
        Dim datatable As New DataTable
        Try
            ' Defino variables de acceso y manipulación de datos
            Dim cn As New SqlConnection(DataBase.CadenaConexion)
            Dim da As New SqlDataAdapter("SELECT * FROM [" & Tabla & "]", cn) ' los [] ban por si es una tabla de nombre compuesto
            Dim cb As New SqlCommandBuilder(da)
            Dim ds As New DataSet

            Dim dc As DataColumn

            ' Cargo la tabla "en memoria" (el nombre "tabla" es sólo para la tabla virtual)
            da.Fill(ds, "tabla")

            ' Defino variables
            Dim indice As Integer
            arrEstructura2 = New Generic.List(Of RegCampo)

            ' Redimensiono el array con tantas posisiones como campos haya en la tabla
            ' El -1 va porque el array guarda el número de la posisión mayor y no la cantidad de elementos
            ''ReDim arrEstructura2(ds.Tables("tabla").Columns.Count() - 1)
            ' Inicializo variables
            indice = 0
            TotalCamposTabla = 0
            ' Recorro la lista de campos en la estructura de la tabla "virtual"
            For Each dc In ds.Tables("tabla").Columns()
                Dim aux As New RegCampo
                ' Guardo el nombre y tipo de cada uno de los campos
                ' La fórmula en el tipo es para eliminar el "system." si llegase a aparecer
                aux.nombre = dc.ColumnName.ToString
                aux.tipo = Mid$(dc.DataType.ToString, InStr(dc.DataType.ToString, ".", CompareMethod.Text) + 1)

                If aux.tipo.Substring(0, 3) = "Int" Then
                    aux.tipo = "Integer"
                End If
                ' Incremento la posisión dentro del array
                indice = indice + 1

                arrEstructura2.Add(aux)
            Next
            TamanoTotal = indice
            TotalCamposTabla = indice
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Función que retorna un objeto DataTable para enlazarlo con el combobox y visualizar las tablas 
    Public Function get_Tablas(ByRef cboTabla As Windows.Forms.ComboBox) As Boolean
        ArmarCadenaConexion()
        Dim connection As New SqlConnection(DataBase.CadenaConexion)

        'Dim selectText As String = If(Generador.guest, "Use [LAGen] ", "Use [LA] ") & _
        '                            "Select * From INFORMATION_SCHEMA.TABLES " & _
        '                                     "Where TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME"

        'Dim selectText As String = If(Generador.guest, "Use [EsqueletoPruebas] ", "Use [LA] ") & _
        '                           "Select * From INFORMATION_SCHEMA.TABLES " & _
        '                                    "Where TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME"


        Dim selectText As String = _
                                   "Select Table_Name From INFORMATION_SCHEMA.TABLES " & _
                                            "Where TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME"


        'Dim selectText As String = BD & _
        '                            "Select * From INFORMATION_SCHEMA.TABLES " & _
        '                                     "Where TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME"

        Dim selectCommand As New SqlCommand(selectText, connection)
        Dim dt As New DataTable
        selectCommand.CommandType = CommandType.Text
        Try
            connection.Open()
            'Dim reader As SqlDataReader = selectCommand.ExecuteReader()
            Dim tb As New DataTable
            'Dim row As DataRow
            Dim Ad As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(selectCommand)
            Dim dtsTemp As New DataSet

            Ad.Fill(dtsTemp, "NuevaTabla")
            cboTabla.DataSource = Nothing
            cboTabla.Items.Clear()
            tb = dtsTemp.Tables(0)

            'Do While reader.Read
            '    row = tb.NewRow()
            '    row.Item(0) = reader("Table_Name").ToString
            '    row.Item(1) = reader("Table_Name").ToString
            '    tb.Rows.InsertAt(row, 0)                
            'Loop
            'cboTabla.Items.Add({reader("Table_Name").ToString, reader("Table_Name").ToString})            
            'reader.Close()

            cboTabla.DataSource = tb
            cboTabla.ValueMember = tb.Columns(0).ColumnName
            cboTabla.DisplayMember = tb.Columns(0).ColumnName
            Return True
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    '' Función que retorna un objeto DataTable para enlazarlo con el combobox y visualizar las tablas   
    'Public Function get_BasesDeDatos() As DataTable
    '    'Dim cadena As String = "Data Source = " & datasource & "; Integrated Security = True"



    '    Try
    '        Using cn As New SqlConnection(CadenaConexion)
    '            Dim comando As SqlCommand = New SqlCommand()
    '            Dim da As SqlDataAdapter = New SqlDataAdapter()
    '            Dim dt As DataTable = New DataTable()

    '            With comando
    '                .Connection = cn
    '                .CommandType = CommandType.Text
    '                .CommandText = "SELECT name FROM sys.databases where owner_sid <> 0x01"
    '                da.SelectCommand = comando
    '            End With

    '            da.Fill(dt)
    '            Return dt
    '            cn.Close()
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '        Return Nothing
    '    End Try
    'End Function

    Public Function recuperarClave(ByVal conexion As String, ByVal tabla As String) As String
        Dim strOwner As String = "dbo"
        Dim strTable As String = tabla
        Dim mySelectQuery As String = "sp_pkeys"
        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataReader
        Dim field As String = ""

        '''''Get Primary Key
        myConnection = New SqlConnection(conexion)
        myCommand = New SqlCommand(mySelectQuery, myConnection)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.AddWithValue("@table_owner", "" & strOwner & "")
        myCommand.Parameters.AddWithValue("@table_name", "" & strTable & "")
        myConnection.Open()
        myReader = myCommand.ExecuteReader()
        Dim count As Short = 0
        If myReader.Read() Then
            field = myReader.Item("COLUMN_NAME").ToString

        End If
        myReader.Close()
        myConnection.Close()

        Return field
    End Function

    ' Este procedimiento recibe una cadena conexión y el nombre de una tabla y carga un array con el nombre y tipo de cada uno de los campos de la tabla.
    ' El array es de tipo regCampo y su alcance es "modular". El mismo es una estructura conteniendo nombre y tipo del campo. Los tipos de los campos se
    ' guardan en el formato "oficial" de .NET (por ejemplo los Integer son Int32, etc.).
    'Dim TamanoTotal As Integer
    Public Function CargarDesdeBD(ByVal conexion As String, ByVal tabla As String) As Generic.List(Of RegCampo)
        Dim arrEstructura As New Generic.List(Of RegCampo)
        Try
            Dim strOwner As String = "dbo"
            Dim strTable As String = tabla
            Dim mySelectQuery As String = "SELECT count(*) FROM sys.objects INNER JOIN sys.schemas ON sys.objects.schema_id = sys.schemas.schema_id INNER JOIN sys.columns ON sys.objects.object_id = sys.columns.object_id INNER JOIN sys.types ON sys.columns.system_type_id = sys.types.system_type_id WHERE (sys.objects.name = '" & strTable & "') AND (sys.schemas.name = '" & strOwner & "') AND (sys.objects.type = 'U' OR sys.objects.type = 'V') AND (sys.types.name <> 'sysname') AND (sys.types.user_type_id <= 256) AND (sys.types.name <> 'timestamp') AND (sys.types.name <> 'binary') AND (sys.types.name <> 'varbinary') AND (sys.types.name <> 'uniqueidentifier') AND (sys.types.name <> 'image') AND (sys.columns.is_computed = 0)"
            'mySelectQuery As String = "SELECT sys.columns.name AS FieldName, sys.types.name AS FieldType, sys.columns.max_length AS Length, sys.columns.precision, sys.columns.scale, sys.columns.is_nullable AS IsNul, 'No' AS fldStatus, sys.columns.is_identity, 'No' AS fkey, '' AS PKTable, '' AS PKColumn, sys.columns.name AS FieldNameB, sys.columns.name AS FieldNameU, '' AS FKDisplayColumn, 0 AS limitSort, 0 AS displaySort, 'No' AS FKAdditionalDisplayColumn, '' as syspropertiesValue, '' AS FK_Name, 0 as FK_Flag FROM sys.objects INNER JOIN sys.schemas ON sys.objects.schema_id = sys.schemas.schema_id INNER JOIN sys.columns ON sys.objects.object_id = sys.columns.object_id INNER JOIN sys.types ON sys.columns.system_type_id = sys.types.system_type_id WHERE (sys.objects.name = '" & strTable & "') AND (sys.schemas.name = '" & strOwner & "') AND (sys.objects.type = 'U' OR sys.objects.type = 'V') AND (sys.types.name <> 'sysname') AND (sys.types.user_type_id <= 256) AND (sys.types.name <> 'timestamp') AND (sys.types.name <> 'binary') AND (sys.types.name <> 'varbinary') AND (sys.types.name <> 'uniqueidentifier') AND (sys.types.name <> 'image') AND (sys.columns.is_computed = 0) ORDER BY sys.columns.column_id"
            Dim myConnection As SqlConnection
            Dim myCommand As SqlCommand
            Dim myReader As SqlDataReader
            '''''
            myConnection = New SqlConnection(conexion)
            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myConnection.Open()
            Dim count As Integer = Convert.ToInt32(myCommand.ExecuteScalar())

            mySelectQuery = "SELECT sys.columns.name AS FieldName, sys.types.name AS FieldType, sys.columns.max_length AS Length, sys.columns.precision, sys.columns.scale, sys.columns.is_nullable AS IsNul, 'No' AS fldStatus, sys.columns.is_identity, 'No' AS fkey, '' AS PKTable, '' AS PKColumn, sys.columns.name AS FieldNameB, sys.columns.name AS FieldNameU, '' AS FKDisplayColumn, 0 AS limitSort, 0 AS displaySort, 'No' AS FKAdditionalDisplayColumn, '' as syspropertiesValue, '' AS FK_Name, 0 as FK_Flag, create_date FROM sys.objects INNER JOIN sys.schemas ON sys.objects.schema_id = sys.schemas.schema_id INNER JOIN sys.columns ON sys.objects.object_id = sys.columns.object_id INNER JOIN sys.types ON sys.columns.system_type_id = sys.types.system_type_id WHERE (sys.objects.name = '" & strTable & "') AND (sys.schemas.name = '" & strOwner & "') AND (sys.objects.type = 'U' OR sys.objects.type = 'V') AND (sys.types.name <> 'sysname') AND (sys.types.user_type_id <= 256) AND (sys.types.name <> 'timestamp') AND (sys.types.name <> 'binary') AND (sys.types.name <> 'varbinary') AND (sys.types.name <> 'uniqueidentifier') AND (sys.types.name <> 'image') AND (sys.columns.is_computed = 0) ORDER BY sys.columns.column_id"
            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myReader = myCommand.ExecuteReader()
            Dim indice As Integer = 0
            Dim KeyCount As Integer = 0

            While myReader.Read()
                If myReader.Item("FieldName").ToString <> "FechaModificacion" And myReader.Item("FieldName").ToString <> "UsuarioModificacion" Then
                    Dim reg As New RegCampo
                    reg.nombre = myReader.Item("FieldName").ToString
                    reg.tipo = If(myReader.Item("FieldType").ToString = "int", "Int32", myReader.Item("FieldType").ToString)
                    reg.IsNullable = Convert.ToBoolean(myReader.Item("IsNul"))
                    reg.CaracterMaximo = If(Convert.ToInt32(myReader.Item("Length")) < 0, 4000, Convert.ToInt32(myReader.Item("Length")))
                    reg.Precision = Convert.ToInt32(myReader.Item("Precision"))
                    reg.Scale = Convert.ToInt32(myReader.Item("Scale"))
                    reg.IsIdentity = Convert.ToBoolean(myReader.Item("is_identity"))
                    reg.IsKey = IsKeyField(conexion, tabla, myReader.Item("FieldName").ToString, Convert.ToInt32(myReader.Item("is_identity")))
                    reg.SQLType = myReader.Item("FieldType").ToString
                    reg.MostrarEnGrilla = True ''Added by Jaymin - 2010.12.26
                    reg.Ver = True
                    reg.Add = True
                    reg.fechaCreacion = CDate(myReader.Item("create_date"))

                    arrEstructura.Add(reg)

                    If IsKeyField(conexion, tabla, myReader.Item("FieldName").ToString, Convert.ToInt32(myReader.Item("is_identity"))) = True Then
                        KeyCount += 1
                    End If

                    indice = indice + 1
                Else
                    count -= 1
                End If
            End While

            myReader.Close()
            myConnection.Close()
            ''''
            If KeyCount = 0 Then
                arrEstructura(0).IsKey = True
            End If
            ''''
            DataBase.TamanoTotal = indice
            Return arrEstructura
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub GetComboFields(ByVal conexion As String, ByVal tabla As String, ByRef dgvCampos As DataGridView)
        Try
            Dim strOwner As String = "dbo"
            Dim strTable As String = tabla
            Dim mySelectQuery As String _
                    = " SELECT " _
                    & " K_OWNER = FK.TABLE_SCHEMA, " _
                    & " K_Table = FK.TABLE_NAME, " _
                    & " FK_Column = CU.COLUMN_NAME, " _
                    & " PK_OWNER = PK.TABLE_SCHEMA, " _
                    & " PK_Table = PK.TABLE_NAME, " _
                    & " PK_Column = PT.COLUMN_NAME, " _
                    & " Constraint_Name = C.CONSTRAINT_NAME, " _
                    & " ROW_NUMBER() OVER (ORDER BY FK.TABLE_SCHEMA, FK.TABLE_NAME ASC) " _
                    & " FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C " _
                    & " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME " _
                    & " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME " _
                    & " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME " _
                    & " INNER JOIN (SELECT i1.TABLE_NAME, i2.COLUMN_NAME " _
                    & " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 " _
                    & " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME " _
                    & " WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY' " _
                    & " ) PT ON PT.TABLE_NAME = PK.TABLE_NAME " _
                    & " WHERE FK.TABLE_SCHEMA = '" & strOwner & "' " _
                    & " AND FK.TABLE_NAME = '" & strTable & "' "
            Dim myConnection As SqlConnection
            Dim myCommand As SqlCommand
            Dim myReader As SqlDataReader
            '''''
            myConnection = New SqlConnection(conexion)
            myCommand = New SqlCommand(mySelectQuery, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()
            Dim row As DataGridViewRow

            While myReader.Read()
                For Each row In dgvCampos.Rows
                    If row.Cells("Nombre").Value.ToString = myReader.Item("FK_Column").ToString Then
                        row.Cells(8).Value = myReader.Item("PK_Table")
                        row.Cells(9).Value = myReader.Item("PK_Column")
                        row.Cells(10).Value = myReader.Item("PK_Column")
                    End If
                Next
            End While
            myReader.Close()
            myConnection.Close()
        Catch ex As Exception
            messagebox.show(ex.Message)
        End Try
    End Sub

    Function CrearCamposUsuarioModificacion(ByVal tabla As String, ByVal conexion As String) As Boolean
        Dim connection As SqlConnection = New SqlConnection(conexion)
        Dim updateStatement As String _
        = "   ALTER TABLE [" & tabla & "]  ADD " _
        & "   [UsuarioModificacion] int"
        '& "   [UsuarioModificacion] int references Usuarios(UsuarioID) "


        Dim updateCommand As New SqlCommand(updateStatement, connection)
        updateCommand.CommandType = CommandType.Text
        updateCommand.Parameters.AddWithValue("@TableName", tabla)
        Try
            connection.Open()
            Dim count As Integer = updateCommand.ExecuteNonQuery()
            Return True
        Catch ex As SqlException
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Function CrearCamposFechaModificacion(ByVal tabla As String, ByVal conexion As String) As Boolean
        Dim connection As SqlConnection = New SqlConnection(conexion)
        Dim updateStatement As String _
        = "   ALTER TABLE [" & tabla & "]  ADD [FechaModificacion] smalldatetime "

        Dim updateCommand As New SqlCommand(updateStatement, connection)
        updateCommand.CommandType = CommandType.Text
        updateCommand.Parameters.AddWithValue("@TableName", tabla)
        Try
            connection.Open()
            Dim count As Integer = updateCommand.ExecuteNonQuery()
            Return True
        Catch ex As SqlException
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Public Function ExisteCampoUsuarioModificacion(ByVal conexion As String) As Boolean
        Dim connection As New SqlConnection(conexion)
        Dim selectText As String = "SELECT count(*) cuenta " & _
                                    "FROM sys.objects SO INNER JOIN sys.columns SC " & _
                                    "ON SO.OBJECT_ID = SC.OBJECT_ID " & _
                                    "WHERE SO.TYPE = 'U' " & _
                                    "and SO.NAME = 'PartesTrabajo1' " & _
                                    "and SC.NAME = 'UsuarioModificacion' "
        Dim selectCommand As New SqlCommand(selectText, connection)
        Dim dt As New DataTable
        selectCommand.CommandType = CommandType.Text
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader()

            Do While reader.Read
                If Convert.ToInt32(reader("cuenta")) > 0 Then
                    Return True
                Else
                    Return False
                End If
            Loop
            reader.Close()

        Catch ex As SqlException
            Throw New Exception("No se pudo comprobar los campos")
        Finally
            connection.Close()
        End Try
    End Function

    Public Function ExisteCampoFechaModificacion(ByVal conexion As String) As Boolean
        Dim connection As New SqlConnection(conexion)
        Dim selectText As String = "SELECT count(*) cuenta " & _
                                    "FROM sys.objects SO INNER JOIN sys.columns SC " & _
                                    "ON SO.OBJECT_ID = SC.OBJECT_ID " & _
                                    "WHERE SO.TYPE = 'U' " & _
                                    "and SO.NAME = 'PartesTrabajo1' " & _
                                    "and SC.NAME = 'FechaModificacion' "
        Dim selectCommand As New SqlCommand(selectText, connection)
        Dim dt As New DataTable
        selectCommand.CommandType = CommandType.Text
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader()

            Do While reader.Read
                If Convert.ToInt32(reader("cuenta")) > 0 Then
                    Return True
                Else
                    Return False
                End If
            Loop
            reader.Close()

        Catch ex As SqlException
            Throw New Exception("No se pudo comprobar los campos")
        Finally
            connection.Close()
        End Try
    End Function

    Sub guardar()
        Me.DatabaseConfig.save()
    End Sub

End Class
