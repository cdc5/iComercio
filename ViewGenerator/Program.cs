using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.EntityClient;
using System.IO;
using iComercio.DAL; // tu namespace del DbContext

namespace ViewGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia el DbContext
            using (var context = new ComercioContext())
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;

                // Pre-genera las vistas
                var mappingCollection = objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);

                // Exporta las vistas a archivo
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ComercioContext.Views.cs");

                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var entitySet in objectContext.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace))
                    {
                        writer.WriteLine("// EntitySet: " + entitySet.Name);
                        // Nota: aquí puedes personalizar la escritura si quieres generar clases
                    }
                }

                Console.WriteLine($"Archivo generado en: {filePath}");
            }
        }
    }
 }
