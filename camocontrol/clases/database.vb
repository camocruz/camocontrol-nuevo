Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class database
    Public Shared inf_despachos As String = "E:\bases_sidoc\Despachos\Bascula_sidlog.mdb" ' "\\Sidocsrv\aseguramiento\DSG\Bascula_sidlog.mdb" '"E:\bases_sidoc\Despachos\Bascula_sidlog.mdb"
    Public Shared inf_despachos_seg As String = "E:\Backups\Temp\icdp_sgrdd.mdw" '"\\Sidocsrv\aseguramiento\DSG\icdp_sgrdd.mdw" '"E:\Backups\Temp\icdp_sgrdd.mdw"
    Public Shared inf_despachos_user As String = "sidoc"
    Public Shared inf_despachos_clave As String = "963"

    'Conexión para PgSql utilizando oledb
    Public Shared Function obtener_conexion() As NpgsqlConnection
        Dim oconn As NpgsqlConnection = New NpgsqlConnection()
        'Obtiene el string de Conexión, leyéndolo del elemento <appSettings> del archivo app.config
        'De ésta manera, podemos cambiar el String de Conexión sin necesidad de re-compilar la aplicación.
        'oconn.ConnectionString = ConfigurationSettings.AppSettings("connectionstring")
        oconn.ConnectionString = ConfigurationManager.ConnectionStrings("cs_camocontrol").ConnectionString
        oconn.ConnectionString = oconn.ConnectionString.Replace("usuario", "camo")
        oconn.ConnectionString = oconn.ConnectionString.Replace("clave", "camo001")
        oconn.Open()
        Return oconn
    End Function
    Public Shared Function obtener_conexion_sql() As SqlConnection
        Dim oconn_sql As SqlConnection = New SqlConnection
        oconn_sql.ConnectionString = ConfigurationManager.ConnectionStrings("cs_unoee").ConnectionString
        oconn_sql.ConnectionString = oconn_sql.ConnectionString.Replace("usuario", "sa")
        oconn_sql.ConnectionString = oconn_sql.ConnectionString.Replace("clave", "SaAdmin123")
        oconn_sql.Open()
        Return oconn_sql
    End Function
    Public Shared Function obtener_conexion_access(ByVal mydatabase As String, ByVal mdw As String, ByVal myUsername As String, ByVal myPassword As String) As OleDbConnection
        Dim oconn_access As OleDbConnection = New OleDbConnection
        oconn_access.ConnectionString = ConfigurationManager.ConnectionStrings("cs_access_wg").ConnectionString
        oconn_access.ConnectionString = oconn_access.ConnectionString.Replace("mdtbase", mydatabase)
        oconn_access.ConnectionString = oconn_access.ConnectionString.Replace("systemmdw", mdw)
        oconn_access.ConnectionString = oconn_access.ConnectionString.Replace("Usrnme", myUsername)
        oconn_access.ConnectionString = oconn_access.ConnectionString.Replace("Pssword", myPassword)
        oconn_access.Open()
        Return oconn_access
    End Function
    Public Shared Function obtener_esquema() As String
        Dim vesquema As String = ""
        'Obtiene el Esquema de la Base de Datos
        'vesquema = ConfigurationSettings.AppSettings("esquema")
        vesquema = ConfigurationManager.ConnectionStrings("esquema_camocontrol").ConnectionString
        Return vesquema
    End Function

    Public Shared Function get_data_reader(ByVal csql As String) As NpgsqlDataReader
        'Este método, devuelve un Objeto DataReader
        Dim oconn As NpgsqlConnection
        Dim ocmd As NpgsqlCommand
        Dim odr As NpgsqlDataReader

        oconn = obtener_conexion()
        ocmd = obtener_comando(oconn)
        ocmd.CommandText = csql

        odr = ocmd.ExecuteReader(CommandBehavior.CloseConnection)
        Return odr
    End Function
    Public Shared Function get_data_reader_sql(ByVal csql As String) As SqlDataReader
        'Este método, devuelve un Objeto DataReader
        Dim oconn_sql As SqlConnection
        Dim ocmd_sql As SqlCommand
        Dim odr_sql As SqlDataReader

        oconn_sql = obtener_conexion_sql()
        ocmd_sql = obtener_comando_sql(oconn_sql)
        ocmd_sql.CommandText = csql

        odr_sql = ocmd_sql.ExecuteReader(CommandBehavior.CloseConnection)
        Return odr_sql
    End Function
    Public Shared Function get_data_reader_access(ByVal csql As String, ByVal mydatabase As String, ByVal mdw As String, ByVal myUsername As String, ByVal myPassword As String) As OleDbDataReader
        'Este método, devuelve un Objeto DataReader
        Dim oconn_access As OleDbConnection
        Dim ocmd_access As OleDbCommand
        Dim odr_access As OleDbDataReader

        oconn_access = obtener_conexion_access(mydatabase, mdw, myUsername, myPassword)
        ocmd_access = obtener_comando_access(oconn_access)
        ocmd_access.CommandText = csql

        odr_access = ocmd_access.ExecuteReader(CommandBehavior.CloseConnection)
        Return odr_access
    End Function
    Public Shared Function obtener_comando(ByVal oconn As NpgsqlConnection) As NpgsqlCommand
        'Este método, devuelve un objeto Comando
        Dim ocmd As NpgsqlCommand
        ocmd = New NpgsqlCommand
        ocmd.Connection = oconn
        ocmd.CommandTimeout = 86400
        ocmd.CommandType = CommandType.Text
        Return ocmd
    End Function
    Public Shared Function obtener_comando_sql(ByVal oconn_sql As SqlConnection) As SqlCommand
        'Este método, devuelve un objeto Comando
        Dim ocmd_sql As SqlCommand
        ocmd_sql = New SqlCommand
        ocmd_sql.Connection = oconn_sql
        ocmd_sql.CommandTimeout = 86400
        ocmd_sql.CommandType = CommandType.Text
        Return ocmd_sql
    End Function
    Public Shared Function obtener_comando_access(ByVal oconn_access As OleDbConnection) As OleDbCommand
        'Este método, devuelve un objeto Comando
        Dim ocmd_access As OleDbCommand
        ocmd_access = New OleDbCommand
        ocmd_access.Connection = oconn_access
        ocmd_access.CommandTimeout = 86400
        ocmd_access.CommandType = CommandType.Text
        Return ocmd_access
    End Function
End Class
