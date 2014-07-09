Imports System.Data.SqlClient
Imports System.IO

Public Module modOne

    

    Function CalcWidth(ByVal inString As String) As Integer

        Dim cwLen, cwX, cwTot, retVal As Integer
        Dim cwStr As Char
        Dim cnvStr As String

        Dim strTemp As String = Nothing
        Dim strTemp1 As String = Nothing
        For cwX = 1 To inString.Length
            strTemp1 = Mid(Trim(inString), cwX, 1)
            If strTemp1 = "." Then
                cwX = inString.Length
            Else
                strTemp = strTemp + strTemp1
            End If
        Next cwX
        inString = strTemp

        cnvStr = StrConv(inString, VbStrConv.ProperCase)
        cwLen = Len(Trim(cnvStr))
        cwTot = 0
        For cwX = 1 To cwLen
            cwStr = Mid(cnvStr, cwX, 1)
            If cwStr = "I" Or cwStr = "f" Or cwStr = "i" Or cwStr = "j" Or cwStr = "l" Or cwStr = "t" Or cwStr = " " Or cwStr = "A" Then
                cwTot = cwTot + 7
            ElseIf cwStr = "r" Or cwStr = "-" Then
                cwTot = cwTot + 8
            ElseIf cwStr = "J" Or cwStr = "L" Or cwStr = "_" Then
                cwTot = cwTot + 10
            ElseIf cwStr = "a" Or cwStr = "b" Or cwStr = "c" Or cwStr = "d" Or cwStr = "e" _
                Or cwStr = "g" Or cwStr = "h" Or cwStr = "k" Or cwStr = "n" Or cwStr = "o" _
                Or cwStr = "p" Or cwStr = "q" Or cwStr = "s" Or cwStr = "u" Or cwStr = "v" _
                Or cwStr = "x" Or cwStr = "y" Or cwStr = "z" Then
                cwTot = cwTot + 10
            ElseIf cwStr = "0" Or cwStr = "1" Or cwStr = "2" Or cwStr = "3" Or cwStr = "4" _
                Or cwStr = "5" Or cwStr = "6" Or cwStr = "7" Or cwStr = "8" Or cwStr = "9" Then
                cwTot = cwTot + 10
            ElseIf cwStr = "F" Or cwStr = "T" Or cwStr = "Z" Then
                cwTot = cwTot + 11
            ElseIf cwStr = "A" Or cwStr = "B" Or cwStr = "C" Or cwStr = "D" Or cwStr = "E" _
                Or cwStr = "H" Or cwStr = "K" Or cwStr = "N" Or cwStr = "P" Or cwStr = "R" _
                Or cwStr = "S" Or cwStr = "U" Or cwStr = "V" Or cwStr = "X" Or cwStr = "Y" _
                Or cwStr = "w" Then
                cwTot = cwTot + 12
            ElseIf cwStr = "G" Or cwStr = "O" Or cwStr = "Q" Then
                cwTot = cwTot + 13
            ElseIf cwStr = "M" Or cwStr = "m" Then
                cwTot = cwTot + 14
            ElseIf cwStr = "W" Then
                cwTot = cwTot + 15
            Else
                cwTot = cwTot + 10
            End If
        Next cwX
        ' ...
        If cwLen = 1 Or cwLen = 2 Or cwLen = 3 Or cwLen = 4 Then
            retVal = cwTot
        ElseIf cwLen = 5 Or cwLen = 6 Then
            retVal = cwTot / 1.41
        ElseIf cwLen = 7 Or cwLen = 8 Then
            retVal = cwTot / 1.44
        ElseIf cwLen = 9 Or cwLen = 10 Then
            retVal = cwTot / 1.49
        ElseIf cwLen = 11 Or cwLen = 12 Then
            retVal = cwTot / 1.51
        ElseIf cwLen = 13 Or cwLen = 14 Or cwLen = 15 Then
            retVal = cwTot / 1.52
        ElseIf cwLen = 16 Or cwLen = 17 Then
            retVal = cwTot / 1.53
        ElseIf cwLen = 18 Or cwLen = 19 Or cwLen = 20 Or cwLen = 21 Then
            retVal = cwTot / 1.54
        ElseIf cwLen = 22 Or cwLen = 23 Or cwLen = 24 Or cwLen = 25 _
            Or cwLen = 26 Or cwLen = 27 Or cwLen = 28 Or cwLen = 29 _
            Or cwLen = 30 Or cwLen = 31 Or cwLen = 32 Or cwLen = 33 Then
            retVal = cwTot / 1.55
        ElseIf cwLen = 34 Or cwLen = 35 Or cwLen = 36 Or cwLen = 37 _
            Or cwLen = 38 Or cwLen = 39 Or cwLen = 40 Or cwLen = 41 _
            Or cwLen = 42 Or cwLen = 43 Or cwLen = 44 Or cwLen = 45 _
            Or cwLen = 46 Or cwLen = 47 Or cwLen = 48 Or cwLen = 49 Then
            retVal = cwTot / 1.56
        ElseIf cwLen >= 50 Then
            retVal = cwTot / 1.57
        End If
        ' ...
        Return retVal
        ' ...
    End Function

    Function GetDotNetDataType(ByVal SQLDataType As String) As String
        SQLDataType = LCase(SQLDataType)

        'Reference from - http://msdn.microsoft.com/en-us/library/ms131092.aspx
        If SQLDataType = "bigint" Then
            Return "Long" '"Int64"
        ElseIf SQLDataType = "binary" Then
            Return "Byte[]"
        ElseIf SQLDataType = "boolean" Then
            Return "Boolean"
        ElseIf SQLDataType = "bit" Then
            Return "Boolean"
        ElseIf SQLDataType = "char" Then
            Return "Char" 'None
            'ElseIf SQLDataType = "cursor" Then
            '    Return ""'None
            'End If
        ElseIf SQLDataType = "timespan" Then
            Return "TimeSpan"
        ElseIf SQLDataType = "date" Then
            Return "Date"
        ElseIf SQLDataType = "datetime" Then
            Return "DateTime"
        ElseIf SQLDataType = "smalldatetime" Then
            Return "DateTime"
        ElseIf SQLDataType = "datetime2" Then
            Return "DateTime"
        ElseIf SQLDataType = "DATETIMEOFFSET" Then
            Return "DateTimeOffset"
        ElseIf SQLDataType = "decimal" Then
            Return "Double" '"Decimal"
        ElseIf SQLDataType = "float" Then
            Return "Double" '"Double"
        ElseIf SQLDataType = "image" Then
            Return "Byte"
        ElseIf SQLDataType = "int" Then
            Return "Integer"
        ElseIf SQLDataType = "integer" Then
            Return "Integer"
        ElseIf SQLDataType = "int32" Then
            Return "Integer"
        ElseIf SQLDataType = "money" Then
            Return "Double" '"Decimal"
        ElseIf SQLDataType = "nchar" Then
            Return "String"
        ElseIf SQLDataType = "ntext" Then
            Return "String" 'None
        ElseIf SQLDataType = "numeric" Then
            Return "Double" '"Decimal"
        ElseIf SQLDataType = "nvarchar" Then
            Return "String"
        ElseIf SQLDataType = "real" Then
            Return "Double"
        ElseIf SQLDataType = "rowversion" Then
            Return "Byte[]"
        ElseIf SQLDataType = "smallint" Then
            Return "Integer" '"Int16"
        ElseIf SQLDataType = "smallmoney" Then
            Return "Double" '"Decimal"
        ElseIf SQLDataType = "sql_variant" Then
            Return "Object"
        ElseIf SQLDataType = "text" Then
            Return "String" 'None
        ElseIf SQLDataType = "time" Then
            Return "TimeSpan"
        ElseIf SQLDataType = "timestamp" Then
            Return "Byte[]" 'None
        ElseIf SQLDataType = "tinyint" Then
            Return "Byte"
        ElseIf SQLDataType = "uniqueidentifier" Then
            Return "Guid"
        ElseIf SQLDataType = "varbinary" Then
            Return "Byte[]"
        ElseIf SQLDataType = "varchar" Then
            Return "String" 'None
        ElseIf SQLDataType = "xml" Then
            Return "String" 'None
        Else
            Return "String"
        End If
    End Function

    Function ConvertToDotNetDataType(ByVal SQLDataType As String) As String

        SQLDataType = LCase(SQLDataType)
        If SQLDataType = "bigint" Then
            Return "CLng"
        ElseIf SQLDataType = "binary" Then
            Return "System.Convert.ToByte"
        ElseIf SQLDataType = "bit" Then
            Return "System.Convert.ToBoolean"
        ElseIf SQLDataType = "char" Then
            Return "System.Convert.ToString"
        ElseIf SQLDataType = "date" Then
            Return "CDate"
        ElseIf SQLDataType = "datetime" Then
            Return "System.Convert.ToDateTime"
        ElseIf SQLDataType = "datetime2" Then
            Return "System.Convert.ToDateTime"
        ElseIf SQLDataType = "DATETIMEOFFSET" Then
            Return "System.Convert.ToDateTime"
        ElseIf SQLDataType = "decimal" Then
            Return "System.Convert.ToDouble"
        ElseIf SQLDataType = "float" Then
            Return "System.Convert.ToDouble"
        ElseIf SQLDataType = "int" Then
            Return "System.Convert.ToInt32"
        ElseIf SQLDataType = "money" Then
            Return "System.Convert.ToDecimal"
        ElseIf SQLDataType = "nchar" Then
            Return "System.Convert.ToString"
        ElseIf SQLDataType = "ntext" Then
            Return "System.Convert.ToString" 'None
        ElseIf SQLDataType = "numeric" Then
            Return "System.Convert.ToDecimal"
        ElseIf SQLDataType = "nvarchar" Then
            Return "System.Convert.ToString"
        ElseIf SQLDataType = "real" Then
            Return "System.Convert.ToDouble"
        ElseIf SQLDataType = "rowversion" Then
            Return "System.Convert.ToByte"
        ElseIf SQLDataType = "smallint" Then
            Return "System.Convert.ToInt16"
        ElseIf SQLDataType = "smallmoney" Then
            Return "System.Convert.ToDouble"
        ElseIf SQLDataType = "sql_variant" Then
            Return "System.Convert.ToString"
        ElseIf SQLDataType = "text" Then
            Return "System.Convert.ToString" 'None
        ElseIf SQLDataType = "time" Then
            Return "System.Convert.ToDateTime"
        ElseIf SQLDataType = "timestamp" Then
            Return "System.Convert.ToByte" 'None
        ElseIf SQLDataType = "tinyint" Then
            Return "System.Convert.ToSByte"
        ElseIf SQLDataType = "uniqueidentifier" Then
            Return "System.Convert.ToString"
        ElseIf SQLDataType = "varbinary" Then
            Return "System.Convert.ToByte"
        ElseIf SQLDataType = "varchar" Then
            Return "System.Convert.ToString" 'None
        ElseIf SQLDataType = "xml" Then
            Return "System.Convert.ToString" 'None
        ElseIf SQLDataType = "int32" Then
            Return "System.Convert.ToInt32"
        ElseIf SQLDataType = "integer" Then
            Return "System.Convert.ToInt32"
        ElseIf SQLDataType = "single" Then
            Return "System.Convert.ToSingle"
        ElseIf SQLDataType = "boolean" Then
            Return "System.Convert.ToBoolean"
        ElseIf SQLDataType = "datetime" Then
            Return "System.Convert.ToDateTime"
        Else
            Return "System.Convert.ToString"
        End If
    End Function

    Function IsKeyField(ByVal conexion As String, ByVal tabla As String, ByVal Field As String, ByVal Is_Identity As Integer) As Boolean
        Dim strOwner As String = "dbo"
        Dim strTable As String = tabla
        Dim mySelectQuery As String = "sp_pkeys"
        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataReader
        '''''Get Primary Key
        myConnection = New SqlConnection(conexion)
        myCommand = New SqlCommand(mySelectQuery, myConnection)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.AddWithValue("@table_owner", "" & strOwner & "")
        myCommand.Parameters.AddWithValue("@table_name", "" & strTable & "")
        myConnection.Open()
        myReader = myCommand.ExecuteReader()
        Dim count As Short = 0
        While myReader.Read()
            If Field = myReader.Item("COLUMN_NAME") Then
                Return True
            End If
        End While
        myReader.Close()
        myConnection.Close()
        '''''Get Auto-Numbered Key
        If Is_Identity = 1 Then
            Return True
        End If
        '''''
        Return False
    End Function

    'Public Sub AddFields(ByVal conexion As String, ByVal TableName As String)
    '    Try
    '        Dim connection As SqlConnection = New SqlConnection(conexion)
    '        Dim updateStatement As String _
    '        = "   ALTER TABLE [" & TableName & "]  ADD [FechaModificacion] smalldatetime " _
    '        & "   , [UsuarioModificacion] int references Usuarios(UsuarioID) " _
    '        & ""
    '        Dim updateCommand As New SqlCommand(updateStatement, connection)
    '        updateCommand.CommandType = CommandType.Text
    '        updateCommand.Parameters.AddWithValue("@TableName", TableName)
    '        Try
    '            connection.Open()
    '            Dim count As Integer = updateCommand.ExecuteNonQuery()
    '        Catch ex As SqlException
    '            'messagebox.show(ex.Message)
    '        Finally
    '            connection.Close()
    '        End Try
    '    Catch ex As Exception
    '    End Try
    'End Sub
End Module
