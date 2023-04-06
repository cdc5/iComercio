//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;
//using System.IO;
//using System.Data.SqlClient;

//namespace iComercio.Auxiliar
//{
//    public class GeneradorBD
//    {
//    string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";

//    string script = File.ReadAllText(@"E:\Project Docs\MX462-PD\MX756_ModMappings1.sql");

//    SqlConnection conn = new SqlConnection(sqlConnectionString);

//    Server server = new Server(new ServerConnection(conn));

//    server.ConnectionContext.ExecuteNonQuery(script);
//    }
//}
