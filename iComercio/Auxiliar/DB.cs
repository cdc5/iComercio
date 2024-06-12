using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace iComercio.Auxiliar
{
    public static class DB
    {
        public static bool CrearBackup(string serverName,string databaseName, string backupPath)
        {
            bool status = false;
            try
            {              
                // Cadena de conexión para conectar con la base de datos master (para realizar el backup)
                string masterConnectionString = $"Data Source={serverName};Initial Catalog=master;Integrated Security=True";

                // Consulta de backup
                string backupQuery = $@"BACKUP DATABASE [{databaseName}] TO DISK='{backupPath}\{databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak'";

                using (SqlConnection connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();

                    // Ejecuta la consulta de backup
                    using (SqlCommand command = new SqlCommand(backupQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Backup de la base de datos completado exitosamente.");
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar el backup: {ex.Message}");
            }
            return status;
        }
    }
}

 
