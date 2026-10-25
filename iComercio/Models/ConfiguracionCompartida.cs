using System;

namespace iComercio.Models
{
    public static class ConfiguracionCompartida
    {
        private static readonly object candado = new object();
        private static Configuracion actual;
        private static ConfiguracionLocal local;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static event EventHandler Cambiada;

        public static Configuracion Actual
        {
            get
            {
                lock (candado)
                {
                    if (actual == null)
                    {
                        actual = new Configuracion();
                        actual.Initialize();
                    }
                    return actual;
                }
            }
        }

        public static ConfiguracionLocal Local
        {
            get
            {
                lock (candado)
                {
                    if (local == null)
                    {
                        local = new ConfiguracionLocal();
                        local.Initialize("iComercio");
                    }
                    return local;
                }
            }
        }

        public static void Notificar()
        {
            EventHandler handlers = Cambiada;
            if (handlers == null)
                return;
            foreach (EventHandler h in handlers.GetInvocationList())
            {
                try
                {
                    h(null, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    log.Error("Error aplicando la nueva configuracion en " + h.Method.DeclaringType + "." + h.Method.Name + ": " + ex.Message, ex);
                }
            }
        }
    }
}
