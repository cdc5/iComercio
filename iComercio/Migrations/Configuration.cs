namespace iComercio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using iComercio.Models;
    using iComercio.Auxiliar;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    

    internal sealed class Configuration : DbMigrationsConfiguration<iComercio.DAL.ComercioContext>
    {
        /* Log */
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Configuration() 
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = false;
            Database.SetInitializer<iComercio.DAL.ComercioContext>(null);
        }
        
        protected override void Seed(iComercio.DAL.ComercioContext context)
        {
            CargaBD cbd = new CargaBD();
            cbd.LlenarConDatos(1,context);
        }

        
         
        
    }
}
