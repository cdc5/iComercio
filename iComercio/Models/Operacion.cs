using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public abstract class Operacion
    {
        public int OperacionID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public abstract Task<bool> Enviar(BusinessLayer bl, Transmision tran);
        //public abstract Task<bool> Enviar<TEntity, TEntityRM>(BusinessLayer bl, Transmision tran)
        //    where TEntity : class,new()
        //    where TEntityRM : class, new();


        //   public static Operacion EnviarSolicitudDeFondo = new EnviarSolicitudDeFondo(1, "Enviar Solicitud de fondo", "Enviar Solicitud de fondo");
        //   public static Operacion ConfirmarSolicitudDeFondo = new ConfirmarSolicitudDeFondo(1, "Enviar Solicitud de fondo", "Enviar Solicitud de fondo");

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Operacion()
        {
            
        }

        public Operacion(int OperacionID,string Nombre, string Descripcion)
        {
            this.OperacionID = OperacionID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }

        public async Task<bool> Post<TEntity, TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitible ent) where TEntity : class,ITransmitible, new()
            where TEntityRM : class, new()
        {
            if (ent != null)
            {
                log.Debug($"Transmitiendo {ent} {tran.RutaApi} {ent.ApiParam(tran.Comercio)}");
                var entRM = await bl.Post<TEntity, TEntityRM>((TEntity)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    log.Debug($"Transmitiendo {entRM}");
                    ent.ApiActualizarDesdeRemoto(bl,entRM);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> PostConCC<TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitibleCC ent)
            where TEntityRM : class,ITransmitible, new()
        {
            if (ent != null)
            {
                TransImputacionCC ticc = new TransImputacionCC();
                ImputacionCuentaCorrienteRestModel iccrm = ticc.DatosImputacionCuentaCorriente(bl, tran);
                ent.ImputacionCC = iccrm;
                
                var entRM = await bl.Post<TEntityRM>((TEntityRM)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl, entRM);
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> Post< TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitible ent)
            where TEntityRM : class,ITransmitible, new()
        {
            if (ent != null)
            {
                log.Debug($"Transmitiendo {ent} {tran.RutaApi} {ent.ApiParam(tran.Comercio)}");
                var entRM = await bl.Post<TEntityRM>((TEntityRM)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    log.Debug($"Transmitiendo {entRM}");
                    ent.ApiActualizarDesdeRemoto(bl,entRM);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Put<TEntity, TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitible ent)
            where TEntity : class,ITransmitible, new()
            where TEntityRM : class, new()
        {
            if (ent != null)
            {
                var entRM = await bl.Put<TEntity, TEntityRM>((TEntity)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl,entRM);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Get<TEntity>(BusinessLayer bl, Transmision tran, ITransmitible ent)
            where TEntity : class,ITransmitible, new()            
        {
            if (ent != null)
            {
                var entRM = await bl.Get<TEntity>((TEntity)ent,tran.Comercio, tran.RutaApi);
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl, entRM);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Get<TEntity, TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitible ent)
            where TEntity : class,ITransmitible, new()
            where TEntityRM : class, new()
        {
            if (ent != null)
            {
                var entRM = await bl.Get<TEntity, TEntityRM>((TEntity)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl,entRM);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Delete<TEntity, TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitible ent)
            where TEntity : class,ITransmitible, new()
            where TEntityRM : class, new()
        {
            if (ent != null)
            {
                var entRM = await bl.Post<TEntity, TEntityRM>((TEntity)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl,entRM);
                    return true;
                }
            }
            return false;
        }

         
         
        public async Task<bool> DeleteConCC<TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitibleCC ent)
           where TEntityRM : class,ITransmitible, new()
        {
            if (ent != null)
            {
                TransImputacionCC ticc = new TransImputacionCC();
                ImputacionCuentaCorrienteRestModel iccrm = ticc.DatosImputacionCuentaCorriente(bl, tran);
                ent.ImputacionCC = iccrm;
                var entRM = await bl.Delete<TEntityRM>((TEntityRM)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl, entRM);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Delete<TEntityRM>(BusinessLayer bl, Transmision tran, ITransmitible ent)
            where TEntityRM : class,ITransmitible, new()
        {
            if (ent != null)
            {
                var entRM = await bl.Delete<TEntityRM>((TEntityRM)ent, tran.RutaApi, ent.ApiParam(tran.Comercio));
                if (entRM != null)
                {
                    ent.ApiActualizarDesdeRemoto(bl, entRM);
                    return true;
                }
            }
            return false;
        }
    }
}
