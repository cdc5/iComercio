// Herramienta de diagnostico del arranque de iComercio (no forma parte del exe).
// Compilar (con iComercio.exe ya compilado en bin\Debug):
//   csc /out:bin\Debug\ViewGen.exe /r:bin\Debug\iComercio.exe /r:bin\Debug\lib\EntityFramework.dll /r:System.Data.dll /r:System.Core.dll ViewGen.cs
//   copy bin\Debug\iComercio.exe.config bin\Debug\ViewGen.exe.config
// Uso (ejecutar con la base accesible):
//   ViewGen.exe medir                 -> tiempos del modelo, comparacion de hash de vistas pregeneradas, generacion desde cero
//   ViewGen.exe migracion             -> tiempo de la primera consulta incluyendo MigrateDatabaseToLatestVersion
//   ViewGen.exe generar <archivo.cs>  -> escribe un ComercioContext.Views.cs nuevo (solo si el hash del modelo cambio)
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

class ViewGen
{
    static string CadenaConexion()
    {
        Assembly asm = typeof(iComercio.DAL.ComercioContext).Assembly;
        Type t = asm.GetType("iComercio.Auxiliar.ConnectionStrings");
        return (string)t.GetMethod("GetDecryptedConnectionString").Invoke(null, new object[] { "ComercioContext" });
    }

    static void Main(string[] args)
    {
        string modo = args.Length > 0 ? args[0] : "medir";
        string salida = args.Length > 1 ? args[1] : null;
        Assembly asm = typeof(iComercio.DAL.ComercioContext).Assembly;
        string cs = CadenaConexion();
        Stopwatch sw = Stopwatch.StartNew();

        if (modo == "migracion")
        {
            Type cfg = asm.GetType("iComercio.Migrations.Configuration");
            Type init = typeof(MigrateDatabaseToLatestVersion<,>).MakeGenericType(typeof(iComercio.DAL.ComercioContext), cfg);
            Database.SetInitializer<iComercio.DAL.ComercioContext>((IDatabaseInitializer<iComercio.DAL.ComercioContext>)Activator.CreateInstance(init));
        }
        else
        {
            Database.SetInitializer<iComercio.DAL.ComercioContext>(null);
        }

        using (var ctx = new iComercio.DAL.ComercioContext(cs))
        {
            ObjectContextHolder h = new ObjectContextHolder(ctx);
            Console.WriteLine("1) construir contexto + modelo (carga vistas pregeneradas si son validas): " + sw.ElapsedMilliseconds + " ms");
            if (modo == "migracion")
            {
                sw.Restart();
                var e = ctx.Empresas.First();
                Console.WriteLine("2) primera consulta incluyendo migraciones: " + sw.ElapsedMilliseconds + " ms");
                return;
            }

            var map = (StorageMappingItemCollection)h.Workspace.GetItemCollection(DataSpace.CSSpace);

            string hashActual = null;
            MethodInfo mh = typeof(StorageMappingItemCollection).GetMethod("ComputeMappingHashValue", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            if (mh != null)
                hashActual = (string)mh.Invoke(map, null);
            Console.WriteLine("   hash del modelo actual : " + hashActual);

            var attr = asm.GetCustomAttributesData().FirstOrDefault(d => d.AttributeType == typeof(DbMappingViewCacheTypeAttribute) && (Type)d.ConstructorArguments[0].Value == typeof(iComercio.DAL.ComercioContext));
            if (attr != null)
            {
                Type tipoCache = (Type)attr.ConstructorArguments[1].Value;
                DbMappingViewCache cache = (DbMappingViewCache)Activator.CreateInstance(tipoCache);
                Console.WriteLine("   hash de las vistas pregeneradas : " + cache.MappingHashValue);
                Console.WriteLine("   coinciden: " + (cache.MappingHashValue == hashActual));
            }
            else
                Console.WriteLine("   no hay vistas pregeneradas en el ensamblado");

            sw.Restart();
            var errores = new List<EdmSchemaError>();
            var vistas = map.GenerateViews(errores);
            Console.WriteLine("3) generar vistas desde cero: " + sw.ElapsedMilliseconds + " ms (" + vistas.Count + " vistas, " + errores.Count + " errores)");
            foreach (var er in errores)
                Console.WriteLine("   ERROR: " + er.Message);

            sw.Restart();
            var q = ctx.Empresas.First();
            Console.WriteLine("4) primera consulta sin migraciones: " + sw.ElapsedMilliseconds + " ms");

            if (modo == "generar" && salida != null && errores.Count == 0)
            {
                Escribir(salida, hashActual, vistas);
                Console.WriteLine("Archivo generado: " + salida);
            }
        }
    }

    class ObjectContextHolder
    {
        public System.Data.Entity.Core.Metadata.Edm.MetadataWorkspace Workspace;
        public ObjectContextHolder(DbContext ctx)
        {
            Workspace = ((IObjectContextAdapter)ctx).ObjectContext.MetadataWorkspace;
        }
    }

    static void Escribir(string ruta, string hash, Dictionary<EntitySetBase, DbMappingView> vistas)
    {
        string clase = "ViewsForBaseEntitySets" + hash;
        var sb = new StringBuilder();
        sb.AppendLine("//------------------------------------------------------------------------------");
        sb.AppendLine("// <auto-generated>");
        sb.AppendLine("//     This code was generated by a tool.");
        sb.AppendLine("//");
        sb.AppendLine("//     Changes to this file may cause incorrect behavior and will be lost if");
        sb.AppendLine("//     the code is regenerated.");
        sb.AppendLine("// </auto-generated>");
        sb.AppendLine("//------------------------------------------------------------------------------");
        sb.AppendLine();
        sb.AppendLine("using System.Data.Entity.Infrastructure.MappingViews;");
        sb.AppendLine();
        sb.AppendLine("[assembly: DbMappingViewCacheTypeAttribute(");
        sb.AppendLine("    typeof(iComercio.DAL.ComercioContext),");
        sb.AppendLine("    typeof(Edm_EntityMappingGeneratedViews." + clase + "))]");
        sb.AppendLine();
        sb.AppendLine("namespace Edm_EntityMappingGeneratedViews");
        sb.AppendLine("{");
        sb.AppendLine("    using System;");
        sb.AppendLine("    using System.CodeDom.Compiler;");
        sb.AppendLine("    using System.Data.Entity.Core.Metadata.Edm;");
        sb.AppendLine();
        sb.AppendLine("    /// <summary>");
        sb.AppendLine("    /// Implements a mapping view cache.");
        sb.AppendLine("    /// </summary>");
        sb.AppendLine("    [GeneratedCode(\"Entity Framework 6 Power Tools\", \"0.9.5.0\")]");
        sb.AppendLine("    internal sealed class " + clase + " : DbMappingViewCache");
        sb.AppendLine("    {");
        sb.AppendLine("        /// <summary>");
        sb.AppendLine("        /// Gets a hash value computed over the mapping closure.");
        sb.AppendLine("        /// </summary>");
        sb.AppendLine("        public override string MappingHashValue");
        sb.AppendLine("        {");
        sb.AppendLine("            get { return \"" + hash + "\"; }");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        /// <summary>");
        sb.AppendLine("        /// Gets a view corresponding to the specified extent.");
        sb.AppendLine("        /// </summary>");
        sb.AppendLine("        /// <param name=\"extent\">The extent.</param>");
        sb.AppendLine("        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>");
        sb.AppendLine("        public override DbMappingView GetView(EntitySetBase extent)");
        sb.AppendLine("        {");
        sb.AppendLine("            if (extent == null)");
        sb.AppendLine("            {");
        sb.AppendLine("                throw new ArgumentNullException(\"extent\");");
        sb.AppendLine("            }");
        sb.AppendLine();
        sb.AppendLine("            var extentName = extent.EntityContainer.Name + \".\" + extent.Name;");
        sb.AppendLine();

        var lista = vistas.ToList();
        for (int i = 0; i < lista.Count; i++)
        {
            string nombre = lista[i].Key.EntityContainer.Name + "." + lista[i].Key.Name;
            sb.AppendLine("            if (extentName == \"" + nombre + "\")");
            sb.AppendLine("            {");
            sb.AppendLine("                return GetView" + i + "();");
            sb.AppendLine("            }");
            sb.AppendLine();
        }
        sb.AppendLine("            return null;");
        sb.AppendLine("        }");

        for (int i = 0; i < lista.Count; i++)
        {
            string nombre = lista[i].Key.EntityContainer.Name + "." + lista[i].Key.Name;
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Gets the view for " + nombre + ".");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>The mapping view.</returns>");
            sb.AppendLine("        private static DbMappingView GetView" + i + "()");
            sb.AppendLine("        {");
            sb.Append("            return new DbMappingView(@\"");
            sb.Append(lista[i].Value.EntitySql.Replace("\"", "\"\""));
            sb.AppendLine("\");");
            sb.AppendLine("        }");
        }
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(ruta, sb.ToString().Replace("\r\n", "\n").Replace("\n", "\r\n"), new UTF8Encoding(false));
    }
}
