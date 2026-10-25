using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Data.Entity;
using System.Globalization;
using iComercio.Migrations;
using iComercio.DAL;
using iComercio.Forms;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Configuration;
using iComercio.Auxiliar;
using Imprentus.Auxiliares;

namespace iComercio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        [STAThread]
        static void Main()
        {
            //Para que actualice
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComercioContext,iComercio.Migrations.Configuration>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComercioContext, iComercio.Migrations.Configuration>("ComercioPruebaContext"));
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ComercioContext>()); 

            /* unhandled excepctions handling */
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
          //  AppDomain.CurrentDomain.FirstChanceException += new EventHandler<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>(Application_FirstChanceException);

            //AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            //{
            //    Debug.WriteLine(eventArgs.Exception.ToString());
            //};

            /*Culture*/
            /*Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");*/

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InicializarContextPorPerformance();
            Application.Run(new Principal());

        }

        static void InicializarContextPorPerformance()
        {
            //Pequeño truquillo para acelerar La carga inicial de EF
            var tarea = new Task(() =>
                    {
                        using (var dbContext = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext")))
                        {
                            var empresa = dbContext.Empresas.First();  //force the model creation
                        }
                    });
            tarea.Start();            
        }
      

        static void Application_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            
            //ExceptionHandlerByType(e.Exception);
            String mens;
            mens = e.Exception + " " + e.Exception.TargetSite + " "
                    + e.Exception.StackTrace + " " + GetExecutingMethodName(e.Exception)
                    + " " + e.Exception.GetType().ToString() + " Excepcion de Hilo"
                    + e.Exception.ToString();

            if (e.Exception != null)
            {
                var ex = e.Exception.InnerException;
                while (ex != null)
                {
                    log.Info(e.Exception.InnerException.Message);
                    mens = mens + ex.Message + Environment.NewLine;
                    mens += ex.TargetSite.ToString() + Environment.NewLine;
                    mens += ex.StackTrace + Environment.NewLine;
                    mens += GetExecutingMethodName(ex) + Environment.NewLine;
                    mens += " " + ex.GetType().ToString();
                    mens += ex.ToString();
                    ex = ex.InnerException;
                }
              
                if (ex is System.Data.Entity.Validation.DbEntityValidationException)
                {
                    var dbex = (System.Data.Entity.Validation.DbEntityValidationException)ex;
                    EntityValidationExceptionHandler(dbex);
                }
            }
           
            log.Info(mens);
            FlexibleMessageBox.Show(mens, " Excepcion de Hilo ");
            // here you can log the exception ...


            //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            //{
            //    Exception raise = dbEx;
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            string message = string.Format("{0}:{1}",
            //                validationErrors.Entry.Entity.ToString(),
            //                validationError.ErrorMessage);
            //            // raise a new exception nesting
            //            // the current instance as InnerException
            //            raise = new InvalidOperationException(message, raise);
            //        }
            //    }
            //    throw raise;
            //}
        }   

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string mens = RegistrarExcepcion(e.Exception, "Excepcion de Hilo de Interfaz");
            try
            {
                FlexibleMessageBox.Show(mens, " Excepcion de Hilo ");
            }
            catch { }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            RegistrarExcepcion(e.ExceptionObject as Exception, "Excepcion no controlada (terminando: " + e.IsTerminating + ")");
        }

        static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            RegistrarExcepcion(e.Exception, "Excepcion de Task no observada");
            e.SetObserved();
        }

        public static string RegistrarExcepcion(Exception exe, string origen)
        {
            string mens = origen;
            try
            {
                if (exe == null)
                {
                    log.Error(mens + ": excepcion nula");
                    return mens;
                }
                try { ExceptionHandlerByType(exe); } catch { }

                var sb = new System.Text.StringBuilder();
                sb.AppendLine(origen);
                int nivel = 0;
                for (Exception ex = exe; ex != null; ex = ex.InnerException, nivel++)
                {
                    sb.AppendLine(string.Format("[{0}] {1}: {2}", nivel, ex.GetType().FullName, ex.Message));
                    if (ex is DbEntityValidationException)
                    {
                        foreach (var ve in ((DbEntityValidationException)ex).EntityValidationErrors)
                            foreach (var err in ve.ValidationErrors)
                                sb.AppendLine(string.Format("    {0}.{1}: {2}", ve.Entry.Entity.GetType().Name, err.PropertyName, err.ErrorMessage));
                    }
                    if (ex is System.Data.SqlClient.SqlException)
                    {
                        var sqlEx = (System.Data.SqlClient.SqlException)ex;
                        sb.AppendLine(string.Format("    SqlError Numero:{0} Servidor:{1}", sqlEx.Number, sqlEx.Server));
                    }
                }
                sb.AppendLine(exe.ToString());
                mens = sb.ToString();
                log.Error(mens);
            }
            catch (Exception exLog)
            {
                try { log.Error(origen + " (fallo al registrar: " + exLog.Message + ")"); } catch { }
            }
            return mens;
        }

        // private string GetExecutingMethodName()
        //{
        //    string result = " Unknown ";
        //    StackTrace trace = new StackTrace(false);
        //    Type type = this.GetType();

        //    for (int index = 0; index < trace.FrameCount; ++index)
        //    {
        //        StackFrame frame = trace.GetFrame(index);
        //        MethodBase method = frame.GetMethod();

        //        if (method.DeclaringType != type && !type.IsAssignableFrom(method.DeclaringType))
        //        {
        //            result = string.Concat(method.DeclaringType.FullName, ".", method.Name);
        //            break;
        //        }
        //    }

        //    return result;
        //}

        private static string GetExecutingMethodName(Exception exception)
        {
            var trace = new StackTrace(exception);
            var frame = trace.FrameCount > 0 ? trace.GetFrame(0) : null;
            var method = frame == null ? null : frame.GetMethod();
            if (method == null)
                return "Desconocido";
            return string.Concat(method.DeclaringType == null ? "" : method.DeclaringType.FullName, ".", method.Name);
        }

        private static void ExceptionHandlerByType(Exception ex)
        {
            string mens = "";
            if (ex == null)
                return;
            if (ex is System.Reflection.TargetException)
            {
                log.Info("Entro Al type");
                TargetException AuxEx = (TargetException)ex;
                mens = String.Format("{0}-{1}-{2}-{3}", AuxEx.Source, AuxEx.StackTrace, AuxEx.TargetSite.ToString(), AuxEx.ToString());
                log.Info("chris" + mens);
                log.Info("chris" + ex.InnerException.ToString());
            }
            if (ex is DbEntityValidationException)
            {
                DbEntityValidationException dbEx = (DbEntityValidationException)ex;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        log.Info(ex.Message);
                        Debug.Print("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            // Get stack trace for the exception with source file information
            GetErrorLineNumber(ex);
            GetErrorLineNumberFr(ex);
            ExceptionHandlerByType(ex.InnerException);
        }

        private static void GetErrorLineNumber(Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            if (st.FrameCount > 0)
            {
                var frame = st.GetFrame(0);

                // Get the line number from the stack frame
                var linea = frame.GetFileLineNumber();
                var nombre = frame.GetFileName();
                string metodo = frame.GetMethod().Name;
                int col = frame.GetFileColumnNumber();
                log.Info(string.Format("Nombre de Archivo:{0}-Linea:{1}-Columna:{2}-Metodo:{3}", nombre, linea, col, metodo));
            }

        }

        private static void GetErrorLineNumberFr(Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            if (st.FrameCount > 0)
            {
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var linea = frame.GetFileLineNumber();
                var nombre = frame.GetFileName();
                string metodo = frame.GetMethod().Name;
                int col = frame.GetFileColumnNumber();
                log.Info(string.Format("Nombre de Archivo:{0}-Linea:{1}-Columna:{2}-Metodo:{3}", nombre, linea, col, metodo));
            }
        }

        static void EntityValidationExceptionHandler(System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
            Exception raise = dbEx;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    string message = string.Format("{0}:{1}",
                        validationErrors.Entry.Entity.ToString(),
                        validationError.ErrorMessage);
                    // raise a new exception nesting
                    // the current instance as InnerException
                    raise = new InvalidOperationException(message, raise);
                }
            }
            throw raise;
        }
    }
}
