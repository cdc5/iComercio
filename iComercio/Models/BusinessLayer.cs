using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using log4net;
using log4net.Config;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Auxiliares;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.ViewModels;
using iComercio.Exceptions;
using System.Windows.Forms;
using iComercio.Forms;


namespace iComercio.Models
{
    public class BusinessLayer : IBusinessLayer,IDisposable
    {
       
       public ParametrosGlobales pGlob { get; set; }
       public RestApi ra;
       public RestApi raM;
       public Dal dal;
       public Dal dalPrueba;
       

       public DalCamara dalCamara;
       private List<Dal> Dals = new List<Dal>();

       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        private void InicializarDals()
        {
            this.dal = Dal();
            this.dalPrueba = DalPrueba();
            this.dalCamara = new DalCamara();
            this.Dals.Add(this.dal);
            this.Dals.Add(this.dalPrueba);
        }

        public Dal Dal()
        {
            return new Dal("ComercioContext");
        }

        public Dal DalPrueba()
        {
            return new Dal("ComercioPruebaContext");
        }

        public DalCamara DalCamara()
        {
            return new DalCamara();
        }

        public List<Dal> GetDals()
        {
            return Dals;
        }

        public Dal GetDal(int BaseIDb)
        {
            if (BaseIDb == 1 || BaseIDb == 2 || BaseIDb == 3 || BaseIDb == 100)
            {
                return dal;
            }
            else if (BaseIDb == 99)
            {
                return dalPrueba;
            }
            return null;
        }

        public Image LogoEmpresa(Empresa emp)
        {
           if (emp.EmpresaID != null)
                {
                    if (emp.EmpresaID == 1)
                        return Properties.Resources.credin_logo_negro_small;
                    else if (emp.EmpresaID == 2)
                        return Properties.Resources.Acuatro_Logo_Small;
                    else if (emp.EmpresaID == 3)
                        return Properties.Resources.Credito_del_Valle_Logo_Small;
                    else
                        return null;
                }
                return null;
        }
        

        public BusinessLayer()
        {
            InicializarDals();
            //this.dal = new Dal();
            //this.dalCamara = new DalCamara();
            ////InicializarBase();
            this.pGlob = new ParametrosGlobales(this);
            ////this.ra = new RestApi(pGlob.Configuracion.RestUsu, pGlob.Configuracion.RestKey, pGlob.Configuracion.RestUrlConexion);
        }

        public BusinessLayer(RestApi ra, RestApi raM)
        {
            InicializarDals();
            //InicializarBase();
            this.pGlob = new ParametrosGlobales(this);
            this.ra = ra;
            this.raM = raM;
            //this.ra = new RestApi(pGlob.Configuracion.RestUsu, pGlob.Configuracion.RestKey, pGlob.Configuracion.RestUrlConexion);
        }

        public RestApi GetRa(int BaseIDb)
        {
            if (BaseIDb == 1 || BaseIDb == 2 || BaseIDb == 3 || BaseIDb == 100)
            {
                return ra;
            }
            else if (BaseIDb == 99)
            {
                
                ra.esEnvioTest = true;
                return ra;
            }
            return null;
        }

        //public businesslayer()
        //{
        //    inicializarbase();
        //    this.pglob = new parametrosglobales(this);
        //    this.ra = new restapi(pglob.configuracion.restusu, pglob.configuracion.restkey, pglob.configuracion.resturlconexion);
        //}

        public void InicializarBases()
        {
            //Método creado para hacer que EF ejecute y cree la base o la actualice, antes de que pase otra cosa
            //GetEmpresas();
            
            if (GetDal(99).context.Database.CreateIfNotExists())
            {
                CargaBD cbd = new CargaBD();
                cbd.LlenarConDatos(99,GetDal(99).context);
            }
        }

        

        /* Generic OP - Ifinan*/
        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> filter = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "",int? take = null) where T : class
        {
            return dal.Get<T>(filter, orderBy, includeProperties,take);
        }

        //public IEnumerable<T> GetByKeys<T>(params string[] claves) where T : class,ITransmitible
        //{ 
        //    return dal.GetByKeys<T>(claves);
        //}

        public IEnumerable<T> GetAsNoTracking<T>( Expression<Func<T, bool>> filter = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                         string includeProperties = "", int? take = null) where T : class
        {
            return dal.GetAsNoTracking<T>(filter, orderBy, includeProperties, take);
        }

        public T GetByID<T>(object id) where T : class
        {
            return dal.GetByID<T>(id);
        }

        //public IEnumerable<ITransmitible> Get<T>(Transmision tran) where T : new()
        //{


        //    Expression<Func<T, bool>> exp = null ;
        //    if (tran.EntidadID != null && tran.EntidadID != String.Empty > 0)
        //        exp = (x => x.EntidadID() == Ids[0]);
        //    if ((Ids.Count() > 1))
        //        exp = (x => x.EntidadID() == Ids[0] && x.EntidadID2() == Ids[1]);
        //    if ((Ids.Count() > 2))
        //        exp = (x => x.EntidadID() == Ids[0] && x.EntidadID2() == Ids[1] && x.EntidadID3() == Ids[2]); 
        //    return Get<T>(exp).ToList<ITransmitible>();
        //}

        public void Agregar<T>(T entity) where T : class
        {
            dal.Agregar<T>(entity);
        }

        public void Borrar<T>(object id) where T : class
        {
            dal.Borrar<T>(id);
        }

        public void Borrar<T>(T entityToDelete) where T : class
        {
            dal.Borrar<T>(entityToDelete);
        }

        public void Actualizar<T>(T entityToUpdate) where T : class,new()
        {
            dal.Actualizar<T>(entityToUpdate);
        }

        public BindingList<T> ToBindingList<T>() where T : class
        {
            return dal.ToBindingList<T>();
        }

        public void AgregarBulk<T>(List<T> lista) where T : class
        {
            dal.AgregarBulk<T>(lista);
        }

        public void AgregarRange<T>(List<T> lista) where T : class
        {
            dal.AgregarRange<T>(lista);
        }


        /* Transaccional */

        public void AgregarTransaccional<T>(T entity) where T : class
        {
            dal.AgregarTransaccional<T>(entity);
        }

        public void BorrarTransaccional<T>(object id) where T : class
        {
            dal.BorrarTransaccional<T>(id);
        }

        public void BorrarTransaccional<T>(T entityToDelete) where T : class
        {
            dal.BorrarTransaccional<T>(entityToDelete);
        }

        public void BorrarRangeTransaccional<T>(List<T> listEntityToDelete) where T : class
        {
            dal.BorrarRangeTransaccional<T>(listEntityToDelete);
        }

        public void ActualizarTransaccional<T>(T entityToUpdate) where T : class,new()
        {
            dal.ActualizarTransaccional<T>(entityToUpdate);
        }

        public void AgregarRangeTransaccional<T>(List<T> lista) where T : class
        {
            dal.AgregarRangeTransaccional<T>(lista);
        }

        public void ActualizarTransaccional<T>(List<T> lista) where T : class
        {
            dal.ActualizarTransaccional<T>(lista);
        }


        public List<MorosoEnCamara> ObtenerMorosoEnCamara(int dni, string nombre)
        {
            return dalCamara.ObtenerMorosoEnCamara(dni, nombre);
        }

        public List<Entidad> ObtenerMorosoEnCamara(string codent, string noment)
        {
            return dalCamara.ObtenerEntidades(codent,noment);
        }

        public List<Morcam> ObtenerMorCam(int dni, string noment, string empreca)
        {
            return dalCamara.ObtenerMorcam(dni, noment, empreca);
        }


        /* Generic OP - Multiples Bases*/
        public IEnumerable<T> Get<T>(int BaseIDb, Expression<Func<T, bool>> filter = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "",int? take = null) where T : class
        {
            return GetDal(BaseIDb).Get<T>(filter, orderBy, includeProperties,take);
        }

        public IEnumerable<T> GetAsNoTracking<T>(int BaseIDb, Expression<Func<T, bool>> filter = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "", int? take = null) where T : class
        {
            return GetDal(BaseIDb).GetAsNoTracking<T>(filter, orderBy, includeProperties,take);
        }



        public T GetByID<T>(int BaseIDb, object id) where T : class
        {
            return GetDal(BaseIDb).GetByID<T>(id);
        }

        public IEnumerable<T> GetInAll<T>(Expression<Func<T, bool>> filter = null,
                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                          string includeProperties = "") where T : class
        {
            List<T> listado = new List<T>();
            foreach (Dal da in GetDals())
            {
                List<T> l = da.Get<T>(filter, orderBy, includeProperties).ToList();
                listado.AddRange(l);
            }
            return listado;
        }

        public void Agregar<T>(int BaseIDb, T entity) where T : class
        {
            GetDal(BaseIDb).Agregar<T>(entity);
        }

        public void Borrar<T>(int BaseIDb, object id) where T : class
        {
            GetDal(BaseIDb).Borrar<T>(id);
        }

        public void Borrar<T>(int BaseIDb, T entityToDelete) where T : class
        {
            GetDal(BaseIDb).Borrar<T>(entityToDelete);
        }

        public void Actualizar<T>(int BaseIDb, T entityToUpdate) where T : class
        {
            GetDal(BaseIDb).Actualizar<T>(entityToUpdate);
        }

        public BindingList<T> ToBindingList<T>(int BaseIDb) where T : class
        {
            return GetDal(BaseIDb).ToBindingList<T>();
        }

        public void AgregarBulk<T>(int BaseIDb, List<T> lista) where T : class
        {
            GetDal(BaseIDb).AgregarBulk<T>(lista);
        }

        public void AgregarRange<T>(int BaseIDb, List<T> lista) where T : class
        {
            GetDal(BaseIDb).AgregarRange<T>(lista);
        }
        
       public void Attach<T>(int BaseIDb, T entity) where T : class
        {
            GetDal(BaseIDb).Attach<T>(entity);
        }

        public void Desacoplar<T>(int BaseIDb, T entity) where T : class
        {
            GetDal(BaseIDb).Desacoplar<T>(entity);
        }

           

        /* Transaccional */

        public void AgregarTransaccional<T>(int BaseIDb, T entity) where T : class
        {
            GetDal(BaseIDb).AgregarTransaccional<T>(entity);
        }

        public void BorrarTransaccional<T>(int BaseIDb, object id) where T : class
        {
            GetDal(BaseIDb).BorrarTransaccional<T>(id);
        }

        public void BorrarTransaccional<T>(int BaseIDb, T entityToDelete) where T : class
        {
            GetDal(BaseIDb).BorrarTransaccional<T>(entityToDelete);
        }

        public void BorrarRangeTransaccional<T>(int BaseIDb, List<T> listEntityToDelete) where T : class
        {
            GetDal(BaseIDb).BorrarRangeTransaccional<T>(listEntityToDelete);
        }

        public void ActualizarTransaccional<T>(int BaseIDb, T entityToUpdate) where T : class,new()
        {
            GetDal(BaseIDb).ActualizarTransaccional<T>(entityToUpdate);
        }

        public void AgregarRangeTransaccional<T>(int BaseIDb, List<T> lista) where T : class
        {
            GetDal(BaseIDb).AgregarRangeTransaccional<T>(lista);
        }

        public void ActualizarTransaccional<T>(int BaseIDb, List<T> lista) where T : class
        {
            GetDal(BaseIDb).ActualizarTransaccional<T>(lista);
        }



        /* Funciones o procedimientos comunes */
        
        /***************************/

        public static void PrimerYUltimoDiaMes(ref DateTime primerDiaMes, ref DateTime UltimoDiaMes)
        {
            primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            UltimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
        }


        public bool PuedeDarCredito()
        {
            if (pGlob.Configuracion.MaxMontoMensual > 0)
            {
                DateTime PrimerDia = DateTime.Now;
                DateTime UltimoDia = PrimerDia;
                PrimerYUltimoDiaMes(ref PrimerDia,ref UltimoDia);
                decimal SumVN = Get<Credito>(pGlob.EmpresaID, c => c.ComercioID == pGlob.ComercioID && c.FechaSolicitud >= PrimerDia && c.FechaSolicitud <= UltimoDia).Sum(c =>c.ValorNominal);
                if (SumVN > pGlob.Configuracion.MaxMontoMensual)
                {
                    MessageBox.Show(String.Format("Se ha excedido el límite mensual de Valor de crédito, Maximo mensual: ${0:00.00}",pGlob.Configuracion.MaxMontoMensual));
                    return false;
                }
            }
            return true;
        }


        public static void CargarScriptPaisesProvinciasLocalidades(iComercio.DAL.ComercioContext context,string rutaScript)
        {
            using (Dal dal = new Dal("ComercioContext"))
            {
                dal.CargarScriptPaisesProvinciasLocalidades(context,rutaScript);
            }
        }

        /********************************** MIGRACION *************************************************/

        public void ActualizarRefinanciacionesEnCreditos(BackgroundWorker bg)
        {
            ILog mLog = LogManager.GetLogger("MigracionLogger");
            log.Debug("Agregando refinanciaciones a Creditos");
            mLog.Debug("Agregando refinanciaciones a Creditos");
            List<Credito> creds = new List<Credito>();
            List<Refinanciacion> refis = Get<Refinanciacion>().ToList();
            
            foreach(Refinanciacion refi in refis)
            {
                Credito credito = Get<Credito>(c => c.EmpresaID == refi.EmpresaID && c.ComercioID == refi.ComercioID 
                                  && c.CreditoID == refi.CreditoID).SingleOrDefault();
                if (credito != null)
                {
                    credito.RefinanciacionID = refi.RefinanciacionID;
                    creds.Add(credito);
                }
            }
            ActualizarTransaccional<Credito>(creds);
            Grabar();
        }


        public int CargarRefiAnuladasDesdeComerFinan(BackgroundWorker bg)
        {
            ILog mLog = LogManager.GetLogger("MigracionLogger");
            Refinanciacion refi;
            Refinanciacion refiAct;
            Clientes cli;
            Cliente clie;
            Usuario usu;
            Credito cred;
            int cant = 0;
            int cantTot = 0;
            int diasVenci = 0;
            int total = 0;
            int restantes = 0;
            int GuardarXLote = 1000;
            int credAModificar = 0;
            DateTime tiempoI = DateTime.Now;
            ComerFinanEntities cf = new ComerFinanEntities();
            List<Refinanciacion> lcreditos = new List<Refinanciacion>();
            
            var creditosAnulAnt = cf.RefiBaja.ToList();

            total = creditosAnulAnt.Count;
            restantes = total;

            
            //Eliminar Bajas duplicadas
            string sql = "WITH cte AS (SELECT ROW_NUMBER() OVER(PARTITION BY kcomercio,kcredito  ORDER BY kcomercio,kcredito ) AS rno,kcomercio,kcredito  FROM refibaja) DELETE cte where rno >1";
            cf.Database.ExecuteSqlCommand(sql);
            

            foreach (RefiBaja creAnt in creditosAnulAnt)
            {
                refiAct = Get<Refinanciacion>(c => c.ComercioID == creAnt.KComercio && c.RefinanciacionID == creAnt.KCredito && c.CreditoID == creAnt.KCreditoAnt).FirstOrDefault();
                if (refiAct != null)
                {
                    refiAct.EstadoID = pGlob.CredEliminado.EstadoID;
                //    refiAct.Estado = pGlob.CredEliminado;
                    ActualizarTransaccional<Refinanciacion>(refiAct);
                    credAModificar++;
                    restantes--;
                    Grabar();
                }
                else
                {
                    cred = Get<Credito>(c => c.CreditoID == creAnt.KCreditoAnt && c.ComercioID == creAnt.KComercio).SingleOrDefault();
                    if (cred != null)
                    {
                        Comercio comer = Get<Comercio>(c => c.ComercioID == creAnt.KComercio).FirstOrDefault();
                        if (comer == null)
                        {
                            comer = new Comercio();
                            comer.ComercioID = creAnt.KComercio;
                            comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                            comer.Nombre = "AGREGADO POR SISTEMA X REFIBAJA; REVISAR";
                            Agregar<Comercio>(comer);
                        }

                        if (creAnt.KAbogado != "0" && creAnt.KAbogado != null)
                        {
                            comer = Get<Comercio>(c => c.ComercioID.ToString() == creAnt.KAbogado).FirstOrDefault();
                            if (comer == null)
                            {
                                comer = new Comercio();
                                comer.ComercioID = System.Convert.ToInt32(creAnt.KAbogado);
                                comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                comer.Nombre = "AGREGADO POR SISTEMA X REFIBAJA; REVISAR";
                                Agregar<Comercio>(comer);
                            }
                        }


                        if (creAnt.Usuario == null || creAnt.Usuario == String.Empty)
                        {
                            usu = Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                            if (usu == null)
                            {
                                usu = new Usuario();
                                usu.nombre = "AGREGADO POR SISTEMA X REFIBAJA; REVISAR Y UNIFICAR USUARIOS";
                                usu.usuario = "NULO";
                                usu.pass = "PONER CONTRASEÑA";
                                usu.creacion = DateTime.Now;
                                usu.activo = false;
                                Agregar<Usuario>(usu);
                            }
                        }
                        else
                        {
                            usu = Get<Usuario>(c => c.usuario == creAnt.Usuario).FirstOrDefault();
                            if (usu == null)
                            {
                                usu = new Usuario();
                                usu.nombre = "AGREGADO POR SISTEMA X REFIBAJA; REVISAR Y UNIFICAR USUARIOS";
                                usu.usuario = creAnt.Usuario;
                                usu.pass = "PONER CONTRASEÑA";
                                usu.creacion = DateTime.Now;
                                usu.activo = false;
                                Agregar<Usuario>(usu);
                            }
                        }
                        refi = new Refinanciacion();
                        refi.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                        refi.UsuarioID = usu.UsuarioID;
                        refi.ComercioID = creAnt.KComercio;
                        refi.CreditoID = creAnt.KCreditoAnt;
                        refi.RefinanciacionID = creAnt.KCredito;
                        if (creAnt.KDocumento != null && creAnt.KCodDocu != null)
                        {
                            refi.Documento = creAnt.KDocumento.Value;
                            refi.TipoDocumentoID = creAnt.KCodDocu;
                        }
                        else
                        {
                            refi.Documento = cred.Documento;
                            refi.TipoDocumentoID = cred.TipoDocumentoID;
                        }
                        if (creAnt.KValorCuota != null)
                            refi.ValorCuota = cred.ValorCuota;
                        if (creAnt.KValorNom != null)
                            refi.ValorNominal = cred.ValorNominal;
                        //refi.ValorAdelanto = creAnt.Value;
                        refi.FechaCreacion = creAnt.KFechaLote;
                        refi.FechaSolicitud = cred.FechaSolicitud;
                        refi.Interes = cred.Interes;
                        refi.CantidadCuotas = cred.CantidadCuotas;
                        refi.PcComer = Environment.MachineName;
                        refi.EstadoID = pGlob.CredEliminado.EstadoID;   
                        //refi.Estado = pGlob.CredEliminado;
                        //refi.FechaCreacion = creAnt.KFechSoli;
                        lcreditos.Add(refi);
                    }
                    else
                    {
                        mLog.Info(String.Format("Credito no existente en Migracion de RefiCobranza. Comercio:{0} Credito:{1} Refi {2}", creAnt.KComercio, creAnt.KCreditoAnt, creAnt.KCredito));
                        restantes--;
                        total--;
                    }                            
                }
                    cant++;
                    cantTot++;
                    bg.ReportProgress((int)(((decimal)cant / (decimal)total) * 100));

                    if (cant == GuardarXLote || (restantes == lcreditos.Count + credAModificar && restantes < GuardarXLote))
                    {
                        using (Dal da = Dal())
                        {
                            da.AgregarRangeTransaccional<Refinanciacion>(lcreditos);
                            da.Save();
                            
                            
                            restantes -= GuardarXLote;
                            cant = 0;
                            lcreditos.Clear();
                        }
                    }
                }

            using (Dal da = Dal())
            {
                da.AgregarRange<Refinanciacion>(lcreditos);
                da.Save();
                dal.Save();
            }
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Refi Anuladas", t.Hours, t.Minutes, t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cant;
        }

        public int CargarRefiCobranzasDesdeComerFinan(BackgroundWorker bg)
        {
            ILog mLog = LogManager.GetLogger("MigracionLogger");

            Usuario usu;
            RefinanciacionCuota cuo;
            RefinanciacionCobranza cob;
            TipoPago tp;
            int cant = 0;
            int cantTot = 0;
            int nCobra = 0;
            int total = 0;
            int restantes = 0;
            DateTime tiempoI = DateTime.Now;
            List<RefinanciacionCobranza> lcob = new List<RefinanciacionCobranza>();
            List<RefiCobra> CobranzasAnt;
            RefinanciacionCobranza cobEsta;

            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;
            string sql = string.Format(@"Select * from [{0}].dbo.RefiCobra s LEFT OUTER join {1}.dbo.RefinanciacionCobranza i
                                        on s.aComercio = i.ComercioID and s.aCredito = i.refinanciacionID and s.aNumCuota = i.RefinanciacionCuotaID
                                        and s.ANumCob = i.RefinanciacionCobranzaID 
                                        where i.RefinanciacionCobranzaID is null", sBaseMig, sBase);

            using (ComerFinanEntities cf = new ComerFinanEntities())
            {
                CobranzasAnt = cf.RefiCobra.ToList();
            }

            total = CobranzasAnt.Count;
            restantes = total;
            int GuardarXLote = 1000;

            foreach (RefiCobra cobAnt in CobranzasAnt)
            {
                cobEsta = Get<RefinanciacionCobranza>(c => c.ComercioID == cobAnt.AComercio && c.RefinanciacionID == cobAnt.ACredito
                             && c.RefinanciacionCuotaID == cobAnt.ANumCuota && c.RefinanciacionCobranzaID == cobAnt.ANumCob).FirstOrDefault();
                if (cobEsta == null)
                {
                    nCobra++;

                    cob = new RefinanciacionCobranza();
                    cuo = Get<RefinanciacionCuota>(c => c.ComercioID == cobAnt.AComercio && c.RefinanciacionID == cobAnt.ACredito && c.RefinanciacionCuotaID == cobAnt.ANumCuota).SingleOrDefault();

                    if (cuo == null)
                    {
                        mLog.Info(String.Format("Cuota no existente en Migracion de Cobranza. Comercio:{0} Credito:{1} Cuota{2} Cobranza{3}", cobAnt.AComercio, cobAnt.ACredito, cobAnt.ANumCuota, cobAnt.ANumCob));
                        restantes--;
                        total--;
                    }
                    else
                    {
                        if (cobAnt.Usuario == null || cobAnt.Usuario == String.Empty)
                        {
                            usu = Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                            if (usu == null)
                            {
                                usu = new Usuario();
                                usu.nombre = "AGREGADO POR SISTEMA X REFICOBRA; REVISAR Y UNIFICAR USUARIOS";
                                usu.usuario = "NULO";
                                usu.pass = "PONER CONTRASEÑA";
                                usu.creacion = DateTime.Now;
                                usu.activo = false;
                                Agregar<Usuario>(usu);
                            }
                        }
                        else
                        {
                            usu = Get<Usuario>(c => c.usuario == cobAnt.Usuario).FirstOrDefault();
                            if (usu == null)
                            {
                                usu = new Usuario();
                                usu.nombre = "AGREGADO POR SISTEMA X REFICOBRA; REVISAR Y UNIFICAR USUARIOS";
                                usu.usuario = cobAnt.Usuario;
                                usu.pass = "PONER CONTRASEÑA";
                                usu.creacion = DateTime.Now;
                                usu.activo = false;
                                Agregar<Usuario>(usu);
                            }
                        }

                        cob.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                        cob.ComercioID = (int)cobAnt.AComercio;
                        cob.CreditoID = cuo.CreditoID;
                        cob.RefinanciacionID = cobAnt.ACredito; //Esta bien!!
                        cob.RefinanciacionCuotaID = cobAnt.ANumCuota;
                        cob.RefinanciacionCobranzaID = cobAnt.ANumCob;
                        cob.Documento = cuo.Documento;
                        cob.TipoDocumentoID = cuo.TipoDocumentoID;

                        if (cobAnt.APago != null)
                        {
                            tp = Get<TipoPago>(c => c.TipoPagoID == cobAnt.APago).FirstOrDefault();
                            if (tp == null)
                            {
                                tp = new TipoPago();
                                tp.TipoPagoID = cobAnt.APago;
                                tp.Nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPOPAGO";
                                tp.Descripcion = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPO PAGO";
                                Agregar<TipoPago>(tp);
                            }
                        }

                        cob.TipoPagoID = cobAnt.APago;

                        cob.FechaPago = cobAnt.AFechaPago.Value;
                        cob.FechaRev = cobAnt.AFechaRev;
                        if (cobAnt.AFechVenci == null)
                            cob.FechaVencimiento = cuo.FechaVencimiento;
                        else
                            cob.FechaVencimiento = cobAnt.AFechVenci.Value;
                        cob.GestionID = cobAnt.AGestion.Value;
                        cob.ImportePago = cobAnt.AImpPago.Value;
                        cob.ImportePagoPunitorios = cobAnt.AImpPuni.Value;
                        cob.PagoRev = cobAnt.APagoRev;
                        if (cobAnt.APuniCalc != null)
                            cob.PunitoriosCalc = cobAnt.APuniCalc.Value;


                        lcob.Add(cob);
                        cant++;
                        cantTot++;
                        bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));
                    }


                    mLog.Info(String.Format("cant:{0} GuardarXLote:{1} restantes:{2} lcob.Count:{3}", cant, GuardarXLote, restantes, lcob.Count));
                    if (cant == GuardarXLote || (restantes == lcob.Count && restantes < GuardarXLote))
                    {
                        using (Dal da = Dal())
                        {
                            mLog.Info(String.Format("Entró a grabar reficobras"));
                            da.AgregarRange<RefinanciacionCobranza>(lcob);
                            lcob.Clear();
                            restantes -= GuardarXLote;
                            cant = 0;
                        }
                    }
                }
                else
                {
                    log.Debug(String.Format("Ya se encuentra en el sistema la cobranza {0}-{1}-{2}", cobAnt.ACredito, cobAnt.ANumCuota, cobAnt.ANumCob));
                }


            }

            //AgregarClientesRange(lClientes);
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            //  Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Refi Cobranzas", t.Hours, t.Minutes, t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cantTot;
        }
      
        public int CargarCobranzasDesdeComerFinan(BackgroundWorker bg)
        {
            ILog mLog = LogManager.GetLogger("MigracionLogger");

            Usuario usu;
            Cuota cuo;
            Cobranza cob;
            TipoPago tp;
            int cant = 0;
            int cantTot = 0;
            int nCobra = 0;
            int total = 0;
            int restantes = 0;
            DateTime tiempoI = DateTime.Now;
            List<Cobranza> lcob = new List<Cobranza>();
            List<CobranzasANT> CobranzasAnt;

            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;
            string sql = string.Format(@"Select * from [{0}].dbo.Cobranzas s LEFT OUTER join {1}.dbo.Cobranza i
                                        on s.aComercio = i.ComercioID and s.aCredito = i.CreditoID and s.aNumCuota = i.CuotaID
                                        and s.ANumCob = i.CobranzaID 
                                        where i.CobranzaID is null", sBaseMig, sBase);

            using (ComerFinanEntities cf = new ComerFinanEntities())
            {
                cf.Database.CommandTimeout = 600;
                CobranzasAnt = cf.Database.SqlQuery<CobranzasANT>(sql).ToList();
                //CobranzasAnt = cf.CobranzasANT.AsNoTracking().ToList();                
            }
            /**/
            dal.context.Configuration.AutoDetectChangesEnabled = false;
            /**/

            


            total = CobranzasAnt.Count;
            restantes = total;
            int GuardarXLote = 1000;
           // CobranzasAnt = CobranzasAnt.GetRange(499999, total - 500000);
            Dal daa = Dal();
            daa.context.Configuration.AutoDetectChangesEnabled = false;
            foreach (CobranzasANT cobAnt in CobranzasAnt)
            {
                nCobra++;
                //using (Dal daa = Dal())
                //{
                    cob = new Cobranza();
                    cuo = daa.Get<Cuota>(c => c.ComercioID == cobAnt.AComercio && c.CreditoID == cobAnt.ACredito
                                    && c.CuotaID == cobAnt.ANumCuota).SingleOrDefault();

                    if (cuo == null)
                    {
                        mLog.Info(String.Format("Credito no existente en Migracion de cuota. Comercio:{0} Credito:{1} Cuota{2} Cobranza{3}", cobAnt.AComercio, cobAnt.ACredito, cobAnt.ANumCuota, cobAnt.ANumCob));
                        restantes--;
                        total--;
                    }
                    else
                    {

                        if (cobAnt.Usuario == null || cobAnt.Usuario == String.Empty)
                        {
                            usu = daa.Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                            if (usu == null)
                            {
                                usu = new Usuario();
                                usu.nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                                usu.usuario = "NULO";
                                usu.pass = "PONER CONTRASEÑA";
                                usu.creacion = DateTime.Now;
                                usu.activo = false;
                                daa.Agregar<Usuario>(usu);
                            }
                        }
                        else
                        {
                            usu = daa.Get<Usuario>(c => c.usuario == cobAnt.Usuario).FirstOrDefault();
                            if (usu == null)
                            {
                                usu = new Usuario();
                                usu.nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                                usu.usuario = cobAnt.Usuario;
                                usu.pass = "PONER CONTRASEÑA";
                                usu.creacion = DateTime.Now;
                                usu.activo = false;
                                daa.Agregar<Usuario>(usu);
                            }
                        }

                        cob.CobranzaID = (int)cobAnt.ANumCob;
                        cob.ComercioID = cobAnt.AComercio;
                        cob.CreditoID = cobAnt.ACredito;
                        cob.CuotaID = cobAnt.ANumCuota;
                        cob.Documento = cuo.Documento;
                        cob.TipoDocumentoID = cuo.TipoDocumentoID;

                        if (cobAnt.APago != null)
                        {
                            tp = daa.Get<TipoPago>(c => c.TipoPagoID == cobAnt.APago).FirstOrDefault();
                            if (tp == null)
                            {
                                tp = new TipoPago();
                                tp.TipoPagoID = cobAnt.APago;
                                tp.Nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPOPAGO";
                                tp.Descripcion = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPO PAGO";
                                daa.Agregar<TipoPago>(tp);
                            }
                        }

                        cob.TipoPagoID = cobAnt.APago;
                        cob.UsuarioID = usu.UsuarioID;
                        cob.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                        cob.FechaPago = (DateTime)cobAnt.AFechaPago;
                        cob.FechaRev = cobAnt.AFechaRev;
                        if (cobAnt.AFechVenci == null)
                            cob.FechaVencimiento = cuo.FechaVencimiento;
                        else
                            cob.FechaVencimiento = cobAnt.AFechVenci.Value;
                        cob.GestionEmpresaID = pGlob.Empresa.EmpresaID.Value;
                        cob.GestionID = cobAnt.AGestion.Value;
                        cob.ImportePago = (decimal)cobAnt.AImpPago;
                        cob.ImportePagoPunitorios = cobAnt.AImpPuni.Value;
                        if (cobAnt.AImpInte != null)
                            cob.Interes = cobAnt.AImpInte.Value;
                        else
                            cob.Interes = 0;
                        cob.PagoRev = cobAnt.APagoRev;
                        cob.PorcentajeBonificacion = cobAnt.PorBoni;
                        cob.PunitoriosCalc = cobAnt.APuniCalc;
                        //if (cobAnt.TipoBoni == String.Empty || cobAnt.TipoBoni == "0")
                        //{
                        //    cuo.TipoBonificacionID = null;
                        //}
                        //else
                        //{
                        //    cuo.TipoBonificacionID = cobAnt.TipoBoni;
                        //}

                        lcob.Add(cob);
                        cant++;
                        cantTot++;
                        bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));
                        
                        if (cant == GuardarXLote || (restantes == lcob.Count && restantes < GuardarXLote))
                        {
                            using (Dal da = Dal())
                            {
                                da.context.Configuration.AutoDetectChangesEnabled = false;
                               // da.context.BulkInsert(lcob);
                                da.AgregarRange<Cobranza>(lcob);
                              
                                lcob.Clear();
                                restantes -= GuardarXLote;
                                cant = 0;
                                daa = Dal();
                                daa.context.Configuration.AutoDetectChangesEnabled = false;
                            }
                        }
                    }
                //}
            }

            //AgregarClientesRange(lClientes);
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
          //  Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Cobranzas", t.Hours, t.Minutes, t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cantTot;
        }

        public bool EsNotaCobCred(string causa)
        {
            return (causa == "ANTICIPADA" || causa == "ANTICIPADO" || causa.Contains("ANTICIPADO") 
                   || causa == "bonificado" || causa == "Anulacion" || causa == "ANULACION");
        }

        public int CargarNotasCDs( BackgroundWorker bg)
        {
            Credito cre = null;
            Cliente clie;
            Usuario usu;
            Cuota cuo = null;
            Cobranza cob = null;
            NotasCD NotaCD;
            TipoPago tp = null;
            Cuota cuoAux = null;

            int cant = 0;
            int cantTot = 0;
            int total = 0;
            int restantes = 0;
            DateTime tiempoI = DateTime.Now;
            int cuoMal = 0;
            int credMal = 0;

            ILog mLog = LogManager.GetLogger("MigracionLogger");
            mLog.Info("NotasCD sin Cobranza");
            log.Info("NotasCD sin Cobranza");
            List<NotasCD> lNotasCD = new List<NotasCD>();
            List<Notas> notasCDAnt;

            using (ComerFinanEntities cf = new ComerFinanEntities())
            {
                //Corregir Notas Con ID REPETIDO
                string sql = "WITH cte AS (SELECT ROW_NUMBER() OVER(PARTITION BY comercio,credito,numcuota  ORDER BY comercio,credito,numcuota,numero ) AS rno,comercio,credito,numcuota,numero  FROM notas) update cte set numero = rno";
                cf.Database.ExecuteSqlCommand(sql);

                string sBase = pGlob.Configuracion.NombreBD;
                string sBaseMig = pGlob.Configuracion.NombreBDMig;
                 sql = string.Format(@"Select * from {0}.dbo.Notas s LEFT OUTER join {1}.dbo.NotasCD i
                                        on s.Numero = i.NotaCDID and s.Comercio = i.ComercioID and s.Credito = i.CreditoID 
                                        and s.NumCuota = i.CuotaID where i.NotaCDID is null order by Comercio,Credito,NumCuota", sBaseMig, sBase);

                notasCDAnt = cf.Database.SqlQuery<Notas>(sql).ToList();
                // notasCDAnt = cf.Notas.AsNoTracking().OrderBy(c => c.Comercio).ThenBy(c => c.Credito).ThenBy(c => c.NumCuota).ToList();
                notasCDAnt =notasCDAnt.Where(c => EsNotaCobCred(c.Causa)).ToList();
            }

            /**/
            dal.context.Configuration.AutoDetectChangesEnabled = false;

            total = notasCDAnt.Count;
            restantes = total;

            int GuardarXLote = 1000;
            bool ErrCuo = false;
            bool ErrCred = false;

            
            foreach (Notas notaAnt in notasCDAnt)
            {
                using (Dal d = Dal())
                {
                    cre = null;
                    cuo = null;
                    ErrCuo = false;
                    ErrCred = false;
                    if (notaAnt.NumCuota != null && notaAnt.NumCuota != 0)
                    {
                        cuo = d.Get<Cuota>(c => c.ComercioID == notaAnt.Comercio && c.CreditoID == notaAnt.Credito && c.CuotaID == notaAnt.NumCuota).SingleOrDefault();
                        if (cuo == null || cuo.Cobranzas == null || cuo.Cobranzas.Count < 1)
                        {
                            log.Info(string.Format("NOTASCD: No se encuentra la Cuota Comercio:{0} Credito:{1} Cuota{2}", notaAnt.Comercio, notaAnt.Credito, notaAnt.NumCuota));
                            restantes--;
                            cuoMal++;
                            log.Info(string.Format("cuoMal:{0} ", cuoMal));
                            ErrCuo = true;
                        }
                    }
                    else
                    {
                        ErrCuo = true;
                    }

                        Cuota pricuo = null;
                        if (notaAnt.Credito != null && notaAnt.Credito != 0)
                        {
                            
                            cre = d.Get<Credito>(c => c.ComercioID == notaAnt.Comercio && c.CreditoID == notaAnt.Credito).SingleOrDefault();
                            if (cre != null)
                              pricuo = cre.Cuotas.FirstOrDefault(c => c.CuotaID == notaAnt.NumCuota);
                            
                            if (cre == null || cre.Cuotas == null || cre.Cuotas.Count < 1
                                || pricuo == null
                                || pricuo.Cobranzas == null
                                || pricuo.Cobranzas.Count < 1)
                            {
                                log.Info(string.Format("NOTASCD: No se encuentra el Credito  Comercio:{0} Credito:{1}", notaAnt.Comercio, notaAnt.Credito));
                                restantes--;
                                cuoMal++;
                                log.Info(string.Format("credMal:{0} ", credMal));
                                ErrCred = true;
                            }
                        }
                        else
                        {
                            ErrCred = true;
                        }
                    
                    

                    if (!ErrCred || !ErrCuo)
                    {
                        NotaCD = new NotasCD();
                        NotaCD.NotaCDID = System.Convert.ToInt32(notaAnt.Numero);
                        NotaCD.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                        NotaCD.ComercioID = (int)notaAnt.Comercio;
                        

                        if (cuo != null )
                        {
                            NotaCD.CuotaID = cuo.CuotaID;
                            NotaCD.CreditoID = cuo.CreditoID;
                            NotaCD.CobranzaID = cuo.Cobranzas.Max(c => c.CobranzaID); //Asigno a ultima cobranza
                            NotaCD.Documento = cuo.Documento;
                            NotaCD.TipoDocumentoID = cuo.TipoDocumentoID;
                        }
                        else if (cre != null)
                        {
                            NotaCD.CreditoID = cre.CreditoID;
                            NotaCD.CuotaID = cre.Cuotas.Max(c => c.CuotaID);
                            NotaCD.CobranzaID = cre.Cuotas.First(c => c.CuotaID == NotaCD.CuotaID).Cobranzas.Max(c => c.CobranzaID);//Asigno a ultima cobranza
                            NotaCD.Documento = cre.Documento;
                            NotaCD.TipoDocumentoID = cre.TipoDocumentoID;
                        }

                        NotaCD.Detalle = notaAnt.Causa;
                        if (notaAnt.Fecha != null)
                            NotaCD.Fecha = notaAnt.Fecha.Value;
                        NotaCD.GestionID = (int)notaAnt.Comercio;
                        if (notaAnt.Valor != null)
                            NotaCD.Importe = notaAnt.Valor.Value;
                        NotaCD.TipoNota = notaAnt.Tipo;
                        usu = BuscarYCargarUsuario(pGlob.Empresa.EmpresaID.Value, notaAnt.Usuario);
                        NotaCD.UsuarioID = usu.UsuarioID;
                        NotaCD.PcComer = notaAnt.Confeccion;
                        //NotaCD.Notas = notaAnt.Notas1;

                        lNotasCD.Add(NotaCD);
                        cre = null;
                        cuo = null;
                        cant++;
                        cantTot++;
                        bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));

                        if (cant == GuardarXLote || (restantes == lNotasCD.Count && restantes < GuardarXLote))
                        {
                            d.AgregarRange<NotasCD>(lNotasCD);
                            lNotasCD.Clear();
                            restantes -= GuardarXLote;
                            cant = 0;
                        }
                    }
                }
            }
            //AgregarClientesRange(lClientes);
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            log.Info(String.Format("Tiempo:{0}:{1}:{2}", t.Hours, t.Minutes, t.Seconds));
            //    Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            return cantTot;
        }

        private Usuario BuscarYCargarUsuario(int BaseIDb, string usuario)
        {
            Usuario usu = null;
            using (Dal da = Dal())
            {
                if (usuario == null || usuario == String.Empty)
                {
                    usu = da.Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                    if (usu == null)
                    {
                        usu = new Usuario();
                        usu.pass = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                        usu.usuario = "NULO";
                        usu.creacion = DateTime.Now;
                        usu.UsuarioID = da.Get<Usuario>().Max(u => u.UsuarioID) + 1;
                        da.Agregar<Usuario>(usu);
                    }
                }
                else
                {
                    usu = da.Get<Usuario>(c => c.usuario == usuario).FirstOrDefault();
                    if (usu == null)
                    {
                        usu = new Usuario();
                        usu.pass = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                        usu.usuario  = usuario; ;
                        usu.creacion = DateTime.Now;
                        usu.UsuarioID = da.Get<Usuario>().Max(u => u.UsuarioID) + 1;
                        da.Agregar<Usuario>(usu);
                    }
                }
            }
            return usu;
        }

        public int CargarRefiCuotasDesdeComerFinan(BackgroundWorker bg)
        {

            ILog mLog = LogManager.GetLogger("MigracionLogger");

            Refinanciacion cre;
            RefinanciacionCuota cuo;
            int cant = 0;
            int cantTot = 0;
            int total = 0;
            int restantes = 0;
            DateTime tiempoI = DateTime.Now;
            List<RefiCuotas> cuotasAnt;
            List<RefinanciacionCuota> lCuotas = new List<RefinanciacionCuota>();
            
            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;
            string sql = string.Format(@"Select * from [{0}].dbo.RefiCuotas s LEFT OUTER join {1}.dbo.RefinanciacionCuota i 
                                        on s.JComercio = i.ComercioID and s.JCredito = i.RefinanciacionID and s.JNumCuota = i.RefinanciacionCuotaID
                                        where i.RefinanciacionCuotaID is null order by JFechUlti asc", sBaseMig, sBase);

            using (ComerFinanEntities cf = new ComerFinanEntities())
            {
                cuotasAnt = cf.Database.SqlQuery<RefiCuotas>(sql).ToList();
                //cuotasAnt = cf.RefiCuotas.ToList();
                //string sql = "ALTER TABLE dbo.refinanciacionCuota  DROP COLUMN Deuda ";
                //sql += "alter table dbo.refinanciacionCuota ADD Deuda AS ([Importe] - [ImportePago]);";
                //cf.Database.ExecuteSqlCommand(sql);
            }

            total = cuotasAnt.Count;
            restantes = total;
            int GuardarXLote = 1000;

            foreach (RefiCuotas cuoAnt in cuotasAnt)
            {
                cuo = new RefinanciacionCuota();
                cre = Get<Refinanciacion>(c => c.EmpresaID == pGlob.Empresa.EmpresaID 
                                          && c.ComercioID == cuoAnt.JComercio 
                                          && c.RefinanciacionID == cuoAnt.JCredito).OrderByDescending(C=>C.CreditoID).FirstOrDefault();
                if (cre == null)
                {
                    mLog.Info(String.Format("Credito no existente en Migracion de cuota. Comercio:{0} Credito:{1} Cuota{2} ", cuoAnt.JComercio, cuoAnt.JCredito, cuoAnt.JNumCuota));
                    restantes--;
                    total--;
                }
                else
                {
                    cuo.CantidadCuotas = cuoAnt.JCantCuota.Value;
                    cuo.ComercioID = cuoAnt.JComercio;
                    cuo.CreditoID = cre.CreditoID;
                    cuo.RefinanciacionID = cuoAnt.JCredito;
                    cuo.RefinanciacionCuotaID = cuoAnt.JNumCuota;
                    cuo.Documento = cre.Documento;
                    cuo.TipoDocumentoID = cre.TipoDocumentoID;
                    cuo.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                    
                    if (cuoAnt.JFechUlti != null)
                        cuo.FechaUltimoPago = cuoAnt.JFechUlti.Value;
                    else
                        cuo.FechaUltimoPago = null;

                    cuo.FechaVencimiento = cuoAnt.JFechVenci.Value;
                    cuo.Importe = cuoAnt.JImpCuota.Value;
                    cuo.ImportePago = cuoAnt.JImpPago.Value;
                    cuo.ImportePagoPunitorios = cuoAnt.JImpPuni.Value;
                    //Existen mas tipos de cuotas que A o V, agregar las que vayan apareciendo si no estan.
                    if (cuoAnt.Jtipo != null)
                    {
                        TipoCuota tcuota = Get<TipoCuota>(tc => tc.TipoCuotaID == cuoAnt.Jtipo).FirstOrDefault();
                        if (tcuota == null)
                        {
                            tcuota = new TipoCuota();
                            tcuota.TipoCuotaID = cuoAnt.Jtipo;
                            tcuota.Nombre = "AGREGADO POR SISTEMA X REFICUOTA; REVISAR Y UNIFICAR TIPOCUOTA";
                            Agregar<TipoCuota>(tcuota);
                        }
                    }
                  
                    lCuotas.Add(cuo);
                    cant++;
                    cantTot++;
                    bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));

                    if (cant == GuardarXLote || (restantes == lCuotas.Count && restantes < GuardarXLote))
                    {
                        using (Dal da = Dal())
                        {
                            da.AgregarRange<RefinanciacionCuota>(lCuotas);
                            lCuotas.Clear();
                            restantes -= GuardarXLote;
                            cant = 0;
                        }
                    }
                }
            }

            //AgregarClientesRange(lClientes);
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            //    Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Refi Cuotas", t.Hours, t.Minutes, t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cantTot;
        }

        public int CargarCuotasDesdeComerFinan(BackgroundWorker bg)
        {

            ILog mLog = LogManager.GetLogger("MigracionLogger");

            Credito cre;
            Cuota cuo;
            int cant = 0;
            int cantTot = 0;
            int total = 0;
            int restantes = 0;
            DateTime tiempoI = DateTime.Now;
            List<CuotasANT> cuotasAnt;
            List<Cuota> lCuotas = new List<Cuota>();
            int acred;
            int acuo;
            DateTime afechavenci;

            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;
            string sql = string.Format(@"Select * from [{0}].dbo.Cuotas s LEFT OUTER join {1}.dbo.Cuota i 
                                        on s.JComercio = i.ComercioID and s.JCredito = i.CreditoID and s.JNumCuota = i.CuotaID
                                        where i.CuotaID is null order by JFechUlti asc", sBaseMig,sBase);

            mLog.Info("Iniciando Migración Cuotas");

            using (ComerFinanEntities cf = new ComerFinanEntities())
            {
                cf.Database.CommandTimeout = 600;
                cuotasAnt = cf.Database.SqlQuery<CuotasANT>(sql).ToList();
                //cuotasAnt = cf.CuotasANT.AsNoTracking().ToList();
                //string sql = "ALTER TABLE cuota DROP COLUMN Deuda ";
                //sql += "alter table cuota ADD Deuda AS ([Importe] - [ImportePago])";
                //cf.Database.ExecuteSqlCommand(sql);
            }
            /**/
            dal.context.Configuration.AutoDetectChangesEnabled = false;
            /**/
            total = cuotasAnt.Count;
            restantes = total;
            int GuardarXLote = 1000;

            //CuotasANT priCuota= cuotasAnt.First(); 
            //acred = priCuota.JCredito;
            //acuo = priCuota.JNumCuota;
            //afechavenci = priCuota.JFechVenci.Value;

            foreach (CuotasANT cuoAnt in cuotasAnt)
            {
                //if (cuoAnt.JCredito == 27)
                //{
                //    MessageBox.Show("stop");
                //}

                cuo = new Cuota();
                cre = Get<Credito>(c => c.ComercioID == cuoAnt.JComercio && c.CreditoID == cuoAnt.JCredito).SingleOrDefault();
                if (cre == null)
                {
                    mLog.Info(String.Format("Credito no existente en Migracion de cuota. Comercio:{0} Credito:{1} Cuota{2} ", cuoAnt.JComercio, cuoAnt.JCredito, cuoAnt.JNumCuota));
                    restantes--;
                    total--;
                }
                else
                {
                    cuo.CantidadCuotas = cuoAnt.JCantCuota.Value;
                    cuo.ComercioID = cuoAnt.JComercio ;
                    cuo.CreditoID = cuoAnt.JCredito;
                    cuo.CuotaID = cuoAnt.JNumCuota;
                    cuo.Documento = cre.Documento;
                    cuo.TipoDocumentoID = cre.TipoDocumentoID;
                    cuo.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                    cuo.FechaUltimoPago = cuoAnt.JFechUlti;
                    if (cuoAnt.JFechVenci != null)
                        cuo.FechaVencimiento = cuoAnt.JFechVenci.Value;                    
                    if (cuoAnt.JImpCuota != null)
                        cuo.Importe = cuoAnt.JImpCuota.Value;
                    if (cuoAnt.JIntCuota != null)
                        cuo.Interes = cuoAnt.JIntCuota.Value;
                    if (cuoAnt.JImpPago != null)
                        cuo.ImportePago = cuoAnt.JImpPago.Value;
                    if (cuoAnt.JImpPuni  != null)
                        cuo.ImportePagoPunitorios = cuoAnt.JImpPuni.Value;
                    else
                        cuo.ImportePagoPunitorios = 0;
                    //if ( acred == cuo.CreditoID && acuo > cuo.CuotaID && cuo.FechaVencimiento < afechavenci )
                    //{
                    //    MessageBox.Show("Aca esta la papa");
                    //}

                    //acred = cuo.CreditoID ;
                    //acuo = cuo.CuotaID;
                    //afechavenci = cuo.FechaVencimiento;

                    //  cuo.PorcentajeBonificacion = cuoAnt.PorBoni;
                    //if (cuoAnt.TipoBoni == String.Empty || cuoAnt.TipoBoni == "0")
                    //{
                    //    cuo.TipoBonificacionID = null;
                    //}
                    //else
                    //{
                    //    cuo.TipoBonificacionID = cuoAnt.TipoBoni;
                    //}
                    // cuo.TipoCuotaID = cuoAnt.Jtipo;

                    //Existen mas tipos de cuotas que A o V, agregar las que vayan apareciendo si no estan.
                    if (cuoAnt.Jtipo != null)
                    { 
                        TipoCuota tcuota = Get<TipoCuota>(tc => tc.TipoCuotaID == cuoAnt.Jtipo).FirstOrDefault();
                        if (tcuota == null)
                        {
                            tcuota = new TipoCuota();
                            tcuota.TipoCuotaID = cuoAnt.Jtipo;
                            tcuota.Nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR TIPOCUOTA";
                            Agregar<TipoCuota>(tcuota);
                        }
                    }
                    cuo.TipoCuotaID = cuoAnt.Jtipo;
                    //Hacer Carga de Notas
                    //cuo.Notas = CargarNotasCuotasDesdeComerFinan(cuoAnt);
                    lCuotas.Add(cuo);
                    cant++;
                    cantTot++;
                    bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));

                                    
                    if (cant == GuardarXLote || (restantes == lCuotas.Count && restantes < GuardarXLote))
                    {
                        using (Dal da = Dal())
                        {
                            //da.context.BulkInsert(lCuotas);
                            da.AgregarRange<Cuota>(lCuotas);
                            lCuotas.Clear();
                            restantes -= GuardarXLote;
                            cant = 0;
                        }
                    }
                }
            }
        
            //AgregarClientesRange(lClientes);
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
        //    Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Cuotas", t.Hours, t.Minutes, t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cantTot;
        }

        public ObservableListSource<Nota> CargarNotasCuotasDesdeComerFinan(CuotasANT cuoAnt)
        {
            ObservableListSource<Nota> notas = null;
            Nota nota;
            string sNota = cuoAnt.jnotas;
            if (sNota != null)
            {
                notas = new ObservableListSource<Nota>();
                foreach (string s in sNota.SplitByLength(500))
                {
                    nota = new Nota();
                    nota.Detalle = s;
                    nota.CreditoID = cuoAnt.JCredito;
                    nota.CuotaID = cuoAnt.JNumCuota;
                    nota.Fecha = DateTime.Now;
                    nota.UsuarioID = pGlob.uSistema.UsuarioID;
                    notas.Add(nota);
                }
            }
            //if (cliAnt.CNotas != null && cliAnt.CNotas.Length > 1200)
            //    Console.WriteLine(cliAnt.CNotas + ":" + cliAnt.CNotas.Length);
            return notas;
        }

        public int CargarRefinanciacionesDesdeComerFinan(BackgroundWorker bg)
        {
            Refinanciacion cre;
            Clientes cli;
            Cliente clie;
            Usuario usu;
            int cant = 0;
            int cantTot = 0;
            int total = 0;
            int restantes = 0;
            int GuardarXLote = 1000;
            DateTime tiempoI = DateTime.Now;
            ComerFinanEntities cf = new ComerFinanEntities();
            List<Refinanciacion> lcreditos = new List<Refinanciacion>();
            Credito credEst;
            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;
            string sql = string.Format(@"Select * from {0}.dbo.refinan s LEFT OUTER join {1}.dbo.refinanciacion i
                                        on s.kComercio = i.ComercioID and s.kCredito = i.RefinanciacionID where  
                                        i.RefinanciacionID is null", sBaseMig, sBase);
            var creditosAnt = cf.Database.SqlQuery<Refinan>(sql).ToList();
            //var creditosAnt = cf.Refinan.ToList();
            total = creditosAnt.Count;
            restantes = total;

            foreach (Refinan creAnt in creditosAnt)
            {
                if (creAnt == null)
                {
                }
                else
                {
                    cre = Get<Refinanciacion>(c => c.ComercioID == creAnt.KComercio && c.CreditoID == creAnt.KCredito).FirstOrDefault();
                    if (cre == null)
                    {
                        credEst = Get<Credito>(c => c.ComercioID == creAnt.KComercio && c.CreditoID == creAnt.KCreditoAnt).FirstOrDefault();
                        if (credEst != null)
                        {
                            cre = new Refinanciacion();
                            clie = Get<Cliente>(c => c.Documento == creAnt.KDocumento.Value && c.TipoDocumentoID == creAnt.KCodDocu).FirstOrDefault();
                            if (clie == null)
                            {
                                log.Debug(String.Format("No se encuentra el cliente {0}", creAnt.KDocumento.Value));
                                restantes -= 1;
                            }
                            else
                            {
                                Comercio comer = Get<Comercio>(c => c.ComercioID == creAnt.KComercio).FirstOrDefault();
                                if (comer == null)
                                {
                                    comer = new Comercio();
                                    comer.ComercioID = creAnt.KComercio;
                                    comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                    comer.Nombre = "AGREGADO POR SISTEMA  X REFI; REVISAR";
                                    Agregar<Comercio>(comer);
                                }


                                if (creAnt.Usuario == null || creAnt.Usuario == String.Empty)
                                {
                                    usu = Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                                    if (usu == null)
                                    {
                                        usu = new Usuario();
                                        usu.nombre = "AGREGADO POR SISTEMA X REFI ; REVISAR Y UNIFICAR USUARIOS ";
                                        usu.usuario = "NULO";
                                        usu.pass = "PONER CONTRASEÑA";
                                        usu.creacion = DateTime.Now;
                                        usu.activo = false;
                                        Agregar<Usuario>(usu);
                                    }
                                }
                                else
                                {
                                    usu = Get<Usuario>(c => c.usuario == creAnt.Usuario).FirstOrDefault();
                                    if (usu == null)
                                    {
                                        usu = new Usuario();
                                        usu.nombre = "AGREGADO POR SISTEMA  X REFI; REVISAR Y UNIFICAR USUARIOS";
                                        usu.usuario = creAnt.Usuario;
                                        usu.pass = "PONER CONTRASEÑA";
                                        usu.creacion = DateTime.Now;
                                        usu.activo = false;
                                        Agregar<Usuario>(usu);
                                    }
                                }

                                cre.UsuarioID = usu.UsuarioID;
                                cre.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                cre.ComercioID = creAnt.KComercio;
                                cre.CreditoID = creAnt.KCreditoAnt;
                                cre.RefinanciacionID = creAnt.KCredito;
                                cre.Documento = creAnt.KDocumento.Value;
                                cre.TipoDocumentoID = creAnt.KCodDocu;
                                cre.ValorCuota = creAnt.KValorCuota.Value;
                                cre.ValorNominal = creAnt.KValorNom.Value;
                                //cre.ValorAdelanto = creAnt.Value;
                                cre.FechaSolicitud = creAnt.KFechSoli.Value;
                                cre.Interes = creAnt.KTasa.HasValue ? (decimal)creAnt.KTasa.Value : (decimal)0;
                                cre.CantidadCuotas = creAnt.KCuotas.HasValue ? creAnt.KCuotas.Value : 0;
                                cre.PcComer = Environment.MachineName;
                                cre.EstadoID = pGlob.Vigente.EstadoID;
                                // cre.Estado = pGlob.CredVigente;
                                cre.FechaCreacion = creAnt.KFechSoli;

                                lcreditos.Add(cre);
                                cant++;
                                cantTot++;
                                restantes -= cant;
                                bg.ReportProgress((int)(((decimal)cant / (decimal)total) * 100));
                            }
                        }
                    }
                    else
                    {
                        log.Debug(String.Format("No se encuentra el Credito {0}", creAnt.KCreditoAnt));
                        restantes -= 1;
                    }
                    if (cant == GuardarXLote || cant == restantes)
                    {
                        using (Dal da = Dal())
                        {
                            da.AgregarRange<Refinanciacion>(lcreditos);
                            cant = 0;
                            lcreditos.Clear();
                        }
                    }
                }
            }

            using (Dal da = Dal())
            {
                da.AgregarRange<Refinanciacion>(lcreditos);
            }

            //AgregarClientesRange(lClientes);
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            //Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}","Refinanciaciones",t.Hours,t.Minutes,t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cant;
        }

        public int CargarCreditosAnuladosDesdeComerFinan(BackgroundWorker bg)
        {
            CreditoAnulado cre;
            Clientes cli;
            Cliente clie;
            Usuario usu;
            int cant = 0;
            int cantTot = 0;
            int diasVenci = 0;
            int total = 0;
            int restantes = 0;
            int GuardarXLote = 1000;
            DateTime tiempoI = DateTime.Now;
            ComerFinanEntities cf = new ComerFinanEntities();
            List<CreditoAnulado> lcreditos = new List<CreditoAnulado>();

            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;

            string sql = string.Format(@"Select * from {0}.dbo.Bajas s LEFT OUTER join {1}.dbo.CreditoAnulado i
                                       on s.KComercio = i.ComercioID and s.KCredito = i.CreditoID 
                                       where i.CreditoID is null order by s.kcomercio,s.kcredito", sBaseMig,sBase);

            var creditosAnulAnt = cf.Database.SqlQuery<Bajas>(sql).ToList();

            total = creditosAnulAnt.Count;
            restantes = total;

            foreach (Bajas creAnt in creditosAnulAnt)
            {
                if (creAnt == null)
                {
                }
                else
                {
                    cre = Get<CreditoAnulado>(c => c.ComercioID == creAnt.KComercio && c.CreditoID == creAnt.KCredito).FirstOrDefault();
                    if (cre == null)
                    {
                        cre = new CreditoAnulado();
                        clie = Get<Cliente>(c => c.Documento == creAnt.KDocumento && c.TipoDocumentoID == creAnt.KCodDocu).FirstOrDefault();
                        if (clie == null)
                        {
                        }
                        else
                        {                  
                            Comercio comer = Get<Comercio>(c => c.ComercioID == creAnt.KComercio).FirstOrDefault();
                            if (comer == null)
                            {
                                comer = new Comercio();
                                comer.ComercioID = creAnt.KComercio;
                                comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                comer.Nombre = "AGREGADO POR SISTEMA; REVISAR";
                                Agregar<Comercio>(comer);
                            }

                            if (creAnt.KAbogado != "0" && !String.IsNullOrEmpty(creAnt.KAbogado))
                            {
                                comer = Get<Comercio>(c => c.ComercioID.ToString() == creAnt.KAbogado).FirstOrDefault();
                                if (comer == null)
                                {
                                    comer = new Comercio();
                                    comer.ComercioID = System.Convert.ToInt32(creAnt.KAbogado);
                                    comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                    comer.Nombre = "AGREGADO POR SISTEMA; REVISAR";
                                    Agregar<Comercio>(comer);
                                    cre.AbogadoID = System.Convert.ToInt32(creAnt.KAbogado);
                                }
                            }
                            else
                            {
                                cre.AbogadoID = null;
                            }

                            if (creAnt.Usuario == null || creAnt.Usuario == String.Empty)
                            {
                                usu = Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                                if (usu == null)
                                {
                                    usu = new Usuario();
                                    usu.nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                                    usu.usuario = "NULO";
                                    usu.pass = "PONER CONTRASEÑA";
                                    usu.creacion = DateTime.Now;
                                    usu.activo = false;
                                    Agregar<Usuario>(usu);
                                }
                            }
                            else
                            {
                                usu = Get<Usuario>(c => c.usuario == creAnt.Usuario).FirstOrDefault();
                                usu = Get<Usuario>(c => c.usuario == creAnt.Usuario).FirstOrDefault();
                                if (usu == null)
                                {
                                    usu = new Usuario();
                                    usu.nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                                    usu.usuario = creAnt.Usuario;
                                    usu.pass = "PONER CONTRASEÑA";
                                    usu.creacion = DateTime.Now;
                                    usu.activo = false;
                                    Agregar<Usuario>(usu);
                                }
                            }

                            cre.UsuarioID = usu.UsuarioID;
                            cre.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                            cre.ComercioID = creAnt.KComercio;
                            cre.CreditoID = creAnt.KCredito;
                            cre.Documento = creAnt.KDocumento.Value;
                            cre.TipoDocumentoID = creAnt.KCodDocu;
                            cre.ValorCuota = creAnt.KValorCuota.Value;
                            cre.ValorNominal = creAnt.KValorNom.Value;
                            cre.FechaSolicitud = creAnt.KFechSoli.Value;
                            cre.Interes = creAnt.KInteresImp.HasValue ? creAnt.KInteresImp.Value : 0;
                            cre.Gasto = creAnt.KGastoImp.HasValue ? creAnt.KGastoImp.Value : 0;
                            cre.Comision = creAnt.KComisionImp.HasValue ? creAnt.KComisionImp.Value : 0;
                            cre.CantidadCuotas = creAnt.KCuotas.HasValue ? creAnt.KCuotas.Value : 0;
                            

                            int.TryParse(creAnt.KVenci, out diasVenci);
                            cre.DiasVenciPrimerCuota = System.Convert.ToInt32(diasVenci);
                            if (creAnt.KGarante1 != 0 && creAnt.KGarante1 != null)
                            {
                                //clie = BuscarYCargarCliente(creAnt.KGarante1, creAnt.KCodDocuG1);
                                clie = Get<Cliente>(c => c.Documento == creAnt.KGarante1.Value && c.TipoDocumentoID == creAnt.KCodDocuG1).FirstOrDefault();
                                if (clie != null)
                                {
                                    cre.Garante1 = clie.Documento;
                                    cre.TipoDocumentoIDG1 = clie.TipoDocumentoID;
                                }
                            }
                            if (creAnt.KGarante2 != 0 && creAnt.KGarante2 != null)
                            {
                                clie = BuscarYCargarCliente(creAnt.KGarante2, creAnt.KCodDocuG2);
                                if (clie != null)
                                {
                                    cre.Garante2 = clie.Documento;
                                    cre.TipoDocumentoIDG2 = clie.TipoDocumentoID;
                                }
                            }
                            if (creAnt.KGarante3 != 0 && creAnt.KGarante3 != null)
                            {
                                clie = BuscarYCargarCliente(creAnt.KGarante3, creAnt.KCodDocuG3);
                                if (clie != null)
                                {
                                    cre.Garante3 = clie.Documento;
                                    cre.TipoDocumentoIDG3 = clie.TipoDocumentoID;
                                }
                            }

                            cre.Avalado = creAnt.KAvalado;
                            //cre.Avales = ConvertirTipoAval(creAnt.QueAvalo);
                            if (creAnt.KTasa == null)
                            {
                                cre.TasaPlan = 0;
                            }
                            else
                            {
                                cre.TasaPlan = (decimal)creAnt.KTasa;
                            }

                            cre.ComisionPlan = creAnt.KComision.HasValue ? (decimal)creAnt.KComision.Value : 0;
                            cre.GastoPlan = creAnt.KGasto.HasValue ? (decimal)creAnt.KGasto.Value : 0;
                            cre.TipoCuotaID = creAnt.KTipCuota;
                            cre.TipoRetencionPlanID = creAnt.KRetencion;
                            

                            cre.FechaComer = DateTime.Now;
                            cre.PcComer = Environment.MachineName;

                            //Hacer Carga de Notas
                            if (creAnt.KNotas != "" && creAnt.KNotas != null)
                            {
                                cre.Motivo = creAnt.KNotas;
                            }

                            lcreditos.Add(cre);
                            cant++;
                            cantTot++;
                            restantes -= cant;
                            bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));
                        }
                    }
                    if (cant == GuardarXLote)
                    {
                        using (Dal da = Dal())
                        {
                            da.AgregarRange<CreditoAnulado>(lcreditos);
                            cant = 0;
                            lcreditos.Clear();
                        }
                    }
                }
            }

            using (Dal da = Dal())
            {
                da.AgregarRange<CreditoAnulado>(lcreditos);
            }
            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Creditos Anulados", t.Hours, t.Minutes, t.Seconds);
            log.Info(Tiempo);
            Debug.Write(Tiempo);
            return cant;
        }

        public int CargarCreditosDesdeComerFinan(BackgroundWorker bg)
        {
            Credito cre;
            Clientes cli;
            Cliente clie;
            Usuario usu;
            int cant = 0;
            int cantTot = 0;
            int diasVenci = 0;
            int total = 0;
            int restantes = 0;
            int GuardarXLote = 2500;
            DateTime tiempoI = DateTime.Now;
            ComerFinanEntities cf = new ComerFinanEntities();
            cf.Configuration.AutoDetectChangesEnabled = false;

            DateTime tiempof = DateTime.Now;
            TimeSpan t = (tiempof - tiempoI);
            string Tiempo = "";

            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;

            string sql = string.Format(@"Select * from {0}.dbo.Creditos s LEFT OUTER join {1}.dbo.Credito i
                                        on s.kComercio = i.ComercioID and s.kCredito = i.CreditoID where i.CreditoID is null",
                                        sBaseMig,sBase);
            
            List<Credito> lcreditos = new List<Credito>();
            cf.Database.CommandTimeout = 600;
            var creditosAnt = cf.Database.SqlQuery<CreditosANT>(sql).ToList();

            /*prueba*/
            dal.context.Configuration.AutoDetectChangesEnabled = false;
            /**/
            
            
            
            total = creditosAnt.Count;
            restantes = total;

                foreach (CreditosANT creAnt in creditosAnt)
                {
                    if (creAnt == null)
                    {
                    }
                    else
                    {
                        cre = Get<Credito>(c => c.ComercioID == creAnt.KComercio && c.CreditoID == creAnt.KCredito).FirstOrDefault();
                        if (cre == null)
                        {
                            cre = new Credito();
                            clie = Get<Cliente>(c => c.Documento == creAnt.KDocumento.Value && c.TipoDocumentoID == creAnt.KCodDocu).FirstOrDefault();
                            if (clie == null)
                            {
                                //clie = Get<Cliente>(c => c.Documento == creAnt.KDocumento.Value && c.TipoDocumentoID == 'DNI').FirstOrDefault();
                                //if (clie == null)
                                //{
                                //BuscarYCargarCliente(creAnt.KDocumento.Value, creAnt.KCodDocu);
                                //}
                            }
                            else
                            {       //cre = new Credito();      
                                ////Verificamos que existan todos los clientes
                                ////cli = cf.Clientes.Find(creAnt.KDocumento, creAnt.KCodDocu);
                                //clie = BuscarYCargarCliente(creAnt.KDocumento.Value, creAnt.KCodDocu);

                                //clie = Get<Cliente>(c => c.Documento == creAnt.KDocumento.Value && c.TipoDocumentoID == creAnt.KCodDocu).FirstOrDefault();
                                //if (clie == null)
                                //{
                                //    clie = Get<Cliente>(c => c.Documento == creAnt.KDocumento.Value).FirstOrDefault();
                                //    if (clie == null)
                                //    {
                                //        clie = new Cliente();
                                //        clie.Documento = creAnt.KDocumento.Value;
                                //        clie.TipoDocumentoID = creAnt.KCodDocu;
                                //        clie.Nombre = "NO ESTABA EN BASE; BUSCAR; CORREGIR Y AGREGAR";
                                //        clie.Apellido = "NO ESTABA EN BASE; BUSCAR; CORREGIR Y AGREGAR";
                                //        clie.EstadoID = pGlob.ClienteImportadoSistemaAnterior.EstadoID.Value;
                                //        clie.FechaAlta = DateTime.Now;
                                //        Agregar<Cliente>(clie);
                                //    }
                                //    else
                                //    {
                                //        creAnt.KCodDocu = clie.TipoDocumentoID;
                                //    }                        
                                //}                  
                                Comercio comer = Get<Comercio>(c => c.ComercioID == creAnt.KComercio).FirstOrDefault();
                                if (comer == null)
                                {
                                    comer = new Comercio();
                                    comer.ComercioID = creAnt.KComercio;
                                    comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                    comer.Nombre = "AGREGADO POR SISTEMA; REVISAR";
                                    Agregar<Comercio>(comer);
                                }

                                if (creAnt.KAbogado != 0 && creAnt.KAbogado != null)
                                {
                                    comer = Get<Comercio>(c => c.ComercioID == creAnt.KAbogado).FirstOrDefault();
                                    if (comer == null)
                                    {
                                        comer = new Comercio();
                                        comer.ComercioID = creAnt.KAbogado.Value;
                                        comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                        comer.Nombre = "AGREGADO POR SISTEMA; REVISAR";
                                        Agregar<Comercio>(comer);
                                        cre.AbogadoID = creAnt.KAbogado;
                                    }
                                }
                                else
                                {
                                    cre.AbogadoID = null;
                                }

                                //comer = Get<Comercio>(c => c.ComercioID == creAnt.KAbogado).FirstOrDefault();
                                //if (comer == null)
                                //{
                                //    comer = new Comercio();
                                //    comer.ComercioID = creAnt.KAbogado.Value;
                                //    comer.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                //    comer.Nombre = "AGREGADO POR SISTEMA; REVISAR";
                                //    Agregar<Comercio>(comer);
                                //}


                                if (creAnt.Usuario == null || creAnt.Usuario == String.Empty)
                                {
                                    usu = Get<Usuario>(c => c.usuario == "NULO").FirstOrDefault();
                                    if (usu == null)
                                    {
                                        usu = new Usuario();
                                        usu.nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                                        usu.usuario = "NULO";
                                        usu.pass = "PONER CONTRASEÑA";
                                        usu.creacion = DateTime.Now;
                                        usu.activo = false;
                                        Agregar<Usuario>(usu);
                                    }
                                }
                                else
                                {
                                    usu = Get<Usuario>(c => c.usuario == creAnt.Usuario).FirstOrDefault();
                                    if (usu == null)
                                    {
                                        usu = new Usuario();
                                        usu.nombre = "AGREGADO POR SISTEMA; REVISAR Y UNIFICAR USUARIOS";
                                        usu.usuario = creAnt.Usuario;
                                        usu.pass = "PONER CONTRASEÑA";
                                        usu.creacion = DateTime.Now;
                                        usu.activo = false;
                                        Agregar<Usuario>(usu);
                                    }
                                }

                                cre.UsuarioID = usu.UsuarioID;
                                cre.EmpresaID = pGlob.Empresa.EmpresaID.Value;
                                cre.ComercioID = creAnt.KComercio;
                                cre.CreditoID = creAnt.KCredito;
                                cre.Documento = creAnt.KDocumento.Value;
                                cre.TipoDocumentoID = creAnt.KCodDocu;
                                cre.ValorCuota = creAnt.KValorCuota.Value;
                                cre.ValorNominal = creAnt.KValorNom.Value;
                                cre.FechaSolicitud = creAnt.KFechSoli.Value;
                                cre.Interes = creAnt.KInteresImp.HasValue ? creAnt.KInteresImp.Value : 0;
                                cre.Gasto = creAnt.KGastoImp.HasValue ? creAnt.KGastoImp.Value : 0;
                                cre.Comision = creAnt.KComisionImp.HasValue ? creAnt.KComisionImp.Value : 0;
                                cre.CantidadCuotas = creAnt.KCuotas.HasValue ? creAnt.KCuotas.Value : 0;
                                cre.Cancelado = creAnt.KCancelado;
                            if (creAnt.KPlazo == null) cre.Corte = 0; else cre.Corte = (int)creAnt.KPlazo;
                            if(creAnt.KFechCorte == null)  cre.FechaAviso = (DateTime)creAnt.KFechSoli; else cre.FechaAviso = (DateTime)creAnt.KFechCorte;
                            int.TryParse(creAnt.KVenci, out diasVenci);
                                cre.DiasVenciPrimerCuota = System.Convert.ToInt32(diasVenci);
                                if (creAnt.KGarante1 != 0 && creAnt.KGarante1 != null)
                                {
                                    //clie = BuscarYCargarCliente(creAnt.KGarante1, creAnt.KCodDocuG1);
                                    clie = Get<Cliente>(c => c.Documento == creAnt.KGarante1.Value && c.TipoDocumentoID == creAnt.KCodDocuG1).FirstOrDefault();
                                    if (clie != null)
                                    {
                                        cre.Garante1 = clie.Documento;
                                        cre.TipoDocumentoIDG1 = clie.TipoDocumentoID;
                                    }
                                }
                                if (creAnt.KGarante2 != 0 && creAnt.KGarante2 != null)
                                {
                                    clie = BuscarYCargarCliente(creAnt.KGarante2, creAnt.KCodDocuG2);
                                    if (clie != null)
                                    {
                                        cre.Garante2 = clie.Documento;
                                        cre.TipoDocumentoIDG2 = clie.TipoDocumentoID;
                                    }
                                }
                                if (creAnt.KGarante3 != 0 && creAnt.KGarante3 != null)
                                {
                                    clie = BuscarYCargarCliente(creAnt.KGarante3, creAnt.KCodDocuG3);
                                    if (clie != null)
                                    {
                                        cre.Garante3 = clie.Documento;
                                        cre.TipoDocumentoIDG3 = clie.TipoDocumentoID;
                                    }
                                }

                                if (creAnt.DocuAdi != 0 && creAnt.DocuAdi != null)
                                {
                                    clie = BuscarYCargarCliente(creAnt.DocuAdi, creAnt.CodAdi);
                                    if (clie != null)
                                    {
                                        cre.Adicional = clie.Documento;
                                        cre.TipoDocumentoIDAdi = clie.TipoDocumentoID;
                                    }
                                }

                                //cre.AbogadoID = creAnt.KAbogado;
                                if (creAnt.kFechaAbo != null)
                                    cre.FechaAbogado = creAnt.kFechaAbo.Value;
                                cre.Avalado = creAnt.KAvalado;
                                cre.CreditoAvales = ConvertirTipoAval(creAnt.QueAvalo,cre.EmpresaID,cre.ComercioID,usu.UsuarioID,cre.CreditoID);
                                if (creAnt.KTasa == null)
                                {
                                    cre.TasaPlan = 0;
                                }
                                else
                                {
                                    cre.TasaPlan = (decimal)creAnt.KTasa;
                                }
                                cre.ComisionPlan = creAnt.KComision.HasValue ? (decimal)creAnt.KComision.Value : 0;
                                cre.GastoPlan = creAnt.KGasto.HasValue ? (decimal)creAnt.KGasto.Value : 0;
                                if (creAnt.KTipCuota == "#")
                                    cre.TipoCuotaID = null;
                                else
                                    cre.TipoCuotaID = creAnt.KTipCuota;

                                cre.NroInformeContel = creAnt.NroInf;
                                cre.TipoRetencionPlanID = creAnt.KRetencion;
                                if (creAnt.TipoBoni == String.Empty || creAnt.TipoBoni == "##")
                                {
                                    cre.TipoBonificacionID = null;
                                }
                                else
                                {
                                    cre.TipoBonificacionID = creAnt.TipoBoni;
                                }

                                cre.PorcentajeBonificacion = creAnt.PorBoni;

                                cre.UsuarioAnt = creAnt.Usuario;
                                cre.UsuarioAvalAnt = creAnt.UsuAval;

                                cre.FechaComer = DateTime.Now;
                                cre.PcComer = Environment.MachineName;

                                //Hacer Carga de Notas
                                if (creAnt.KNotas != "" && creAnt.KNotas != null)
                                {
                                    cre.Notas = CargarNotasCreditosDesdeComerFinan(creAnt);
                                }

                                lcreditos.Add(cre);
                                cant++;
                                cantTot++;
                                restantes -= cant;
                                bg.ReportProgress((int)(((decimal)cantTot / (decimal)total) * 100));
                            }
                        }
                        if (cant == GuardarXLote)
                        {
                            using (Dal da = Dal())
                            {
                                tiempof = DateTime.Now;
                                t = (tiempof - tiempoI);
                                Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Creditos", t.Hours, t.Minutes, t.Seconds);
                                log.Info(Tiempo);
                                Debug.Write("Creditos:" + Tiempo);
                                //da.context.BulkInsert(lcreditos);
                                da.AgregarRange<Credito>(lcreditos);
                                cant = 0;
                                lcreditos.Clear();
                            }
                        }
                    }
                }
                using (Dal da = Dal())
                {
                    //da.context.BulkInsert(lcreditos);
                    da.AgregarRange<Credito>(lcreditos);
                }
                        
                //AgregarClientesRange(lClientes);
                 tiempof=DateTime.Now;
                 t = (tiempof - tiempoI);
                 //Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
                 Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Creditos", t.Hours, t.Minutes, t.Seconds);
                 log.Info(Tiempo);
                 Debug.Write("Creditos:" + Tiempo);
             
             return cant;
        }

        private Cliente BuscarYCargarCliente(int? documento, string tipoDocumento)
        {
            Cliente clie = null;
            if (documento != null && documento != 0 && tipoDocumento != null && tipoDocumento != String.Empty)
            { 
                clie = Get<Cliente>(c => c.Documento == documento && c.TipoDocumentoID == tipoDocumento).FirstOrDefault();
                if (clie == null)
                {
                    clie = Get<Cliente>(c => c.Documento == documento).FirstOrDefault();
                    if (clie == null)
                    {
                        clie = new Cliente();
                        clie.Documento = documento.Value;
                        clie.TipoDocumentoID = tipoDocumento;
                        clie.Nombre = "NO ESTABA EN BASE; BUSCAR; CORREGIR Y AGREGAR";
                        clie.Apellido = "NO ESTABA EN BASE; BUSCAR; CORREGIR Y AGREGAR";
                        clie.EstadoID = pGlob.ClienteImportadoSistemaAnterior.EstadoID;
                        clie.FechaAlta = DateTime.Now;
                        Agregar<Cliente>(clie);
                    }
                }
            }
            return clie;
        }

        public ObservableListSource<Nota> CargarNotasCreditosDesdeComerFinan(CreditosANT creAnt)
        {
            ObservableListSource<Nota> notas = null;
            Nota nota;
            string sNota = creAnt.KNotas;
            if (sNota != null)
            {
                notas = new ObservableListSource<Nota>();
                foreach (string s in sNota.SplitByLength(500))
                {
                    nota = new Nota();
                    nota.Detalle = s;
                    nota.CreditoID = creAnt.KCredito;
                    nota.Fecha = DateTime.Now;
                    nota.UsuarioID = 1;//pGlob.uSistema.UsuarioID;
                    notas.Add(nota);
                }
            }
            //if (cliAnt.CNotas != null && cliAnt.CNotas.Length > 1200)
            //    Console.WriteLine(cliAnt.CNotas + ":" + cliAnt.CNotas.Length);
            return notas;
        }
       
        public ObservableListSource<CreditoAval> ConvertirTipoAval(string queAvala,int EmpresaID,int ComercioID,int UsuarioID, int CreditoID)
        {
            CreditoAval ca;
            if (queAvala != null)
                {
                    ObservableListSource<CreditoAval> Avales = new ObservableListSource<CreditoAval>();
                
                if (queAvala.Length > 0 && queAvala[0] == 'S')
                {
                    ca = new CreditoAval();
                    ca.ComercioID = ComercioID;
                    ca.CreditoID = CreditoID;
                    ca.EmpresaID = EmpresaID;
                    ca.TipoAvalID =pGlob.AvalSueldo.TipoAvalID;
                    ca.UsuarioID = UsuarioID;
                    Avales.Add(ca);
                }
                if (queAvala.Length > 1 && queAvala[1] == 'S')
                {
                    ca = new CreditoAval();
                    ca.ComercioID = ComercioID;
                    ca.CreditoID = CreditoID;
                    ca.EmpresaID = EmpresaID;
                    ca.TipoAvalID = pGlob.AvalCamara.TipoAvalID;
                    ca.UsuarioID = UsuarioID;
                    Avales.Add(ca);
                }
                if (queAvala.Length > 2 && queAvala[2] == 'S')
                {
                    ca = new CreditoAval();
                    ca.ComercioID = ComercioID;
                    ca.CreditoID = CreditoID;
                    ca.EmpresaID = EmpresaID;
                    ca.TipoAvalID = pGlob.AvalCredAnt.TipoAvalID;
                    ca.UsuarioID = UsuarioID;
                    Avales.Add(ca);
                }
                if (queAvala.Length > 3 && queAvala[3] == 'S')
                {
                    ca = new CreditoAval();
                    ca.ComercioID = ComercioID;
                    ca.CreditoID = CreditoID;
                    ca.EmpresaID = EmpresaID;
                    ca.TipoAvalID = pGlob.AvalRenueva.TipoAvalID;
                    ca.UsuarioID = UsuarioID;
                    Avales.Add(ca);
                }
                return Avales;        
            }
            return null;
            
        }

        public int CargarClientesDesdeComerFinan(BackgroundWorker bg)
        {
            int GuardarXLote = 1000;
            string apellido = "";
            string nombre = "";
            int napellido = 0;
            Cliente cli;
            int cant = 0;
            DateTime tiempoI=DateTime.Now;

            string sBase = pGlob.Configuracion.NombreBD;
            string sBaseMig = pGlob.Configuracion.NombreBDMig;

            string sql = string.Format(@"Select * from [{0}].dbo.Clientes where CDocumento not in 
                                          (Select Documento from {1}.dbo.Cliente)", sBaseMig, sBase);


            using (ComerFinanEntities cf = new ComerFinanEntities())
            {

                List<Cliente> lClientes = new List<Cliente>();
                cf.Configuration.AutoDetectChangesEnabled = false;
                

                var clientes = cf.Database.SqlQuery<Clientes>(sql).ToList();

                //var clientes = cf.Clientes.ToList();
                string[] Labs = GetProfesionesID(pGlob.EmpresaID);
                foreach (Clientes cliAnt in clientes)
                {
                    cli = new Cliente();

                    napellido = cliAnt.Cnombre.IndexOf(" ");
                    if (napellido > 0)
                    {
                        apellido = cliAnt.Cnombre.Substring(0, napellido);
                        if (napellido > cliAnt.Cnombre.Length)
                        {
                            nombre = "";
                        }
                        else
                        {
                            nombre = cliAnt.Cnombre.Substring(napellido + 1);
                        }
                    }
                    else
                    {
                        apellido = cliAnt.Cnombre;
                        nombre = "";
                    }

                    cli.Nombre = cliAnt.Cnombre;
                    cli.Documento =(int) cliAnt.CDocumento;
                    cli.TipoDocumentoID = cliAnt.CCodDocu;
                    cli.EmpresaLaboral = cliAnt.CEmpresa;
                    cli.EstadoID = pGlob.ClienteImportadoSistemaAnterior.EstadoID;
                    cli.FechaAlta = DateTime.Now; // Se pone la fecha de hoy porque se sabe que el estado de cliente es importado del sistama anterior, en este caso seria fechaImportacion
                    cli.FechaModificacion = null;
                    cli.FechaNacimiento = cliAnt.CFechaNaci;
                    cli.Tarjeta = cliAnt.etique != null ? (cliAnt.etique == 1 ? true : false) : (bool?)null;
                    cli.FechaAltaTarjeta = cliAnt.fetiq;
                   // cli.FechaVencimientoTarjeta = cliAnt.fechv;
                    cli.Legajo = cliAnt.Legajo;
                    cli.ProfesionID = TransformarLaboral(pGlob.EmpresaID,cliAnt.CCodEmpleo, cliAnt.CComLab, Labs); 
                    cli.Puntaje = 0;
                    cli.SexoID = (cliAnt.CSexo != String.Empty)  ? ((cliAnt.CSexo == "M") || (cliAnt.CSexo == "F"))?cliAnt.CSexo:null:(string)null;
                    cli.Sueldo = cliAnt.CSueldo;
                    
                    //Carga de domicilios
                    if(cliAnt.Cdomicilio != null    && cliAnt.Cdomicilio.Length > 3) cli.Domicilios.Add(CargarDomicilioClienteDesdeComerFinan(cliAnt));
                    if (cliAnt.CDomicilioE != null && cliAnt.CDomicilioE.Length > 3) cli.Domicilios.Add(CargarDomicilioEmpresaDesdeComerFinan(cliAnt));

                    //Carga de Telefonos
                    if(cliAnt.CTelefono1 != null && cliAnt.CTelefono1.Length>3) cli.Telefonos.Add(CargarTelefonoClienteDesdeComerFinan(cliAnt));
                    if (cliAnt.CTelefono2 != null && cliAnt.CTelefono2.Length > 3) cli.Telefonos.Add(CargarTelefono2ClienteDesdeComerFinan(cliAnt));
                    if (cliAnt.mail != null && cliAnt.mail.Length>3) cli.Telefonos.Add(CargarTelefonoEmpresaClienteDesdeComerFinan(cliAnt));
                    
                    ////Carga de mails
                    cli.Mails.Add(CargarMailClienteDesdeComerFinan(cliAnt));

                    //////Hacer Carga de Notas
                    //cli.Notas.Add(CargarNotasClienteDesdeComerFinan(cliAnt));
                    cli.Notas = CargarNotasClienteDesdeComerFinan(cliAnt);
                   

                    ////Carga de ComoConocio
                    cli.TipoComoConocioID = CargarComoConocioDesdeComerFinan(cliAnt);

                    lClientes.Add(cli);
                    cant++;
                    bg.ReportProgress((int)(((decimal)cant / (decimal)clientes.Count) * 100));

                    if (cant == GuardarXLote)
                    {
                        using (Dal da = Dal())
                        {
                            //da.context.BulkInsert(lcreditos);
                            da.AgregarRange<Cliente>(lClientes);
                            cant = 0;
                            lClientes.Clear();
                        }
                    }
                }

                using ( Dal da = Dal())
                {
                    //da.context.BulkInsert(lClientes);
                    da.AgregarRange<Cliente>(lClientes);
                }
                //AgregarClientesRange(lClientes);
                
                DateTime tiempof=DateTime.Now;
                TimeSpan t = (tiempof - tiempoI);
               // Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
                string Tiempo = String.Format("Tiempo {0} {1}:{2}:{3}", "Clientes", t.Hours, t.Minutes, t.Seconds);
                log.Info(Tiempo);
                Debug.Write(Tiempo);
            }
            return cant;
        }

        public string CargarComoConocioDesdeComerFinan(Clientes cliAnt)
        {
            TipoComoConocio tcc;
            if (cliAnt.Conocio != null && cliAnt.Conocio != String.Empty 
                && cliAnt.Conocio != "." && cliAnt.Conocio != "***"
                && cliAnt.Conocio != "0" && cliAnt.Conocio != "139"
                && cliAnt.Conocio != "2" && cliAnt.Conocio != "321"
                && cliAnt.Conocio != "44" && cliAnt.Conocio != "467"
                && cliAnt.Conocio != "52" && cliAnt.Conocio != "59"
                && cliAnt.Conocio != "6003" && cliAnt.Conocio != "l"
                && cliAnt.Conocio != "Vacio")
            {
                if (cliAnt.Conocio == "MSJ. TEXTO")
                    cliAnt.Conocio = "SMS";
                if (cliAnt.Conocio == "LLAM. TELEFONICA")
                    cliAnt.Conocio = "TELEVENTA";                
            }
            tcc = GetTiposComoConocio(t => t.Nombre == cliAnt.Conocio).FirstOrDefault();
            if (tcc == null)
            {
                tcc = new TipoComoConocio();
                tcc.TipoComoConocioID = "J";//OTRO
            }
            return tcc.TipoComoConocioID;
        }

        public ObservableListSource<Nota> CargarNotasClienteDesdeComerFinan(Clientes cliAnt)
        {
            ObservableListSource<Nota> notas = null;
            Nota nota;
            string sNota = cliAnt.CNotas;
            if (sNota != null && sNota != " ")
            {
                notas = new ObservableListSource<Nota>();
                foreach (string s in sNota.SplitByLength(500))
                {
                    nota = new Nota();
                    nota.Documento = (int)cliAnt.CDocumento;
                    nota.TipoDocumentoID = cliAnt.CCodDocu;
                    nota.Detalle = s;
                    nota.Fecha = DateTime.Now;
                    nota.UsuarioID = 1;
                    notas.Add(nota);
                }
            }
            //if (cliAnt.CNotas != null && cliAnt.CNotas.Length > 1200)
            //    Console.WriteLine(cliAnt.CNotas + ":" + cliAnt.CNotas.Length);
            return notas;
        }

        //public Nota CargarNotasClienteDesdeComerFinan(Clientes cliAnt)
        //{
        //    Nota nota = new Nota();
        //    nota.TipoDocumentoID = cliAnt.CCodDocu;
        //    nota.Detalle = cliAnt.CNotas;
        //    nota.Fecha = DateTime.Now;
        //    return nota;
        //}

        public Mail CargarMailClienteDesdeComerFinan(Clientes cliAnt)
        {
            Mail mail = new Mail();
            mail.Documento = (int)cliAnt.CDocumento;
            mail.TipoDocumentoID = cliAnt.CCodDocu;
            mail.ClaseDatoID = pGlob.DatoCliente.ClaseDatoID;
            mail.EstadoID = pGlob.Vigente.EstadoID;
            mail.Direccion = cliAnt.mail;
            mail.Fecha = DateTime.Now;
            mail.UsuarioID = 1;
            return mail;
        }

        public Telefono CargarTelefonoClienteDesdeComerFinan(Clientes cliAnt)
        {
            Telefono tel = new Telefono();
            tel.Documento = (int)cliAnt.CDocumento;
            tel.TipoDocumentoID = cliAnt.CCodDocu;
            tel.ClaseDatoID = pGlob.DatoCliente.ClaseDatoID;    
            tel.Numero = cliAnt.CTelefono1;
            tel.EstadoID = pGlob.Vigente.EstadoID;
            tel.Fecha = DateTime.Now;
            tel.UsuarioID = 1;
            return tel;
        }

        public Telefono CargarTelefono2ClienteDesdeComerFinan(Clientes cliAnt)
        {
            Telefono tel = new Telefono();
            tel.Documento = (int)cliAnt.CDocumento;
            tel.TipoDocumentoID = cliAnt.CCodDocu;
            tel.ClaseDatoID = pGlob.DatoCliente.ClaseDatoID;
            tel.Numero = cliAnt.CTelefono2;
            tel.EstadoID = pGlob.Vigente.EstadoID;
            tel.Fecha = DateTime.Now;
            tel.UsuarioID = 1;
            return tel;
        }

        public Telefono CargarTelefonoEmpresaClienteDesdeComerFinan(Clientes cliAnt)
        {
            Telefono tel = new Telefono();
            tel.Documento = (int)cliAnt.CDocumento;
            tel.TipoDocumentoID = cliAnt.CCodDocu;
            tel.ClaseDatoID = pGlob.DatoEmpresa.ClaseDatoID;
            tel.Numero = cliAnt.CTelefonoE;
            tel.EstadoID = pGlob.Vigente.EstadoID;
            tel.Fecha = DateTime.Now;
            tel.UsuarioID = 1;
            return tel;
        }

        public Domicilio CargarDomicilioClienteDesdeComerFinan(Clientes cliAnt)
        {
            //Agregar resto de datos en notas domicilio
	        Domicilio dom = new Domicilio();
            dom.Direccion = cliAnt.Cdomicilio;
            dom.Documento = (int)cliAnt.CDocumento;
            dom.TipoDocumentoID = cliAnt.CCodDocu;
            string NotasDomicilio = String.Format("{0}-{1}-{2}", cliAnt.Cdomicilio, cliAnt.Clocalidad, ObtenerProvinciaDesdeClave(cliAnt.CProvincia));
            dom.NotasDomicilio = NotasDomicilio;            
            dom.ClaseDatoID = pGlob.DatoCliente.ClaseDatoID;           
	        dom.EstadoID = pGlob.Vigente.EstadoID;
            dom.Fecha = DateTime.Now;
            dom.UsuarioID = 1;
            return dom;
        }

        public Domicilio CargarDomicilioEmpresaDesdeComerFinan(Clientes cliAnt)
        {
            Domicilio dom = new Domicilio();
            dom.Direccion = cliAnt.CDomicilioE;
            string NotasDomicilio = String.Format("{0}-{1}-{2}", cliAnt.CDomicilioE, cliAnt.CLocalidadE,ObtenerProvinciaDesdeClave( cliAnt.CProvinciaE));
            dom.Documento = (int)cliAnt.CDocumento;
            dom.TipoDocumentoID = cliAnt.CCodDocu;
            dom.NotasDomicilio = NotasDomicilio;
            dom.ClaseDatoID = pGlob.DatoEmpresa.ClaseDatoID;
            dom.EstadoID = pGlob.Vigente.EstadoID;
            dom.Fecha = DateTime.Now;
            dom.UsuarioID = 1;
            return dom;
        }
        

        public string TransformarLaboral(int BaseIDb, string CCodEmpleo, string CComLab, string[] Labs )
        {
            string ProfesionID = null;
            if (CComLab != String.Empty)
            {
                // new String[50]{"AM","AP","AU","CO","DJ","DO","ED","EJ","JU","MU","PE","PO","PR","PT","PU","SD","SU"};
                if (Labs.Contains(CComLab))
                    ProfesionID = CComLab;
            }
            else if (CCodEmpleo != String.Empty)
            {
                ProfesionID = CCodEmpleo;
                if (CCodEmpleo == "POL")
                {
                    ProfesionID = "PO";
                }
                if (CCodEmpleo == "MUN")
                {
                    ProfesionID = "MU";
                }
                if (CCodEmpleo == "DOP" || CCodEmpleo == "DON")
                {
                    ProfesionID = "DO";
                } 
                if (CCodEmpleo == "" || CCodEmpleo == " ")
                {
                    ProfesionID = "S/N";
                }
                else
                    ProfesionID = "S/N";
            }
            return ProfesionID;
        }

        public void CorregirFechasDeCuotas(BackgroundWorker bg, int Comercio)
        {
            using (ComercioContext cf = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext")))
            {
                string sql = @"SELECT   c1.comercioid as Com, c1.creditoid as Cred
                    FROM        Cuota c1
                    inner    join   Cuota c2 
                    on c1.empresaid = c2.empresaid
                    and c1.comercioid= c2.comercioid
                    and c1.creditoid = c2.creditoid
                    WHERE        (c1.ComercioID = " + Comercio + @")
                    and c1.FechaVencimiento  > c2.FechaVencimiento
                    and c1.CuotaID < c2.CuotaID
                    group by c1.empresaid,c1.comercioid,c1.creditoid";


                var result = cf.Database.SqlQuery<ComCred>(sql).ToList();
                int cant = 0;
                foreach (ComCred comcred in result)
                {
                    List<Cuota> Cuotas = Get<Cuota>(c => c.ComercioID == comcred.Com && c.CreditoID == comcred.Cred).OrderBy(c => c.CuotaID).ToList();
                    if (Cuotas != null && Cuotas.Count > 0)
                    {
                        var Fechas = Cuotas.Select(s => new { s.FechaVencimiento, s.FechaUltimoPago, s.ImportePago, s.ImportePagoPunitorios }).ToList();
                        Fechas = Fechas.OrderBy(s => s.FechaVencimiento).ToList();
                        int i = 0;
                        foreach (Cuota cuo in Cuotas)
                        {
                            cuo.FechaVencimiento = Fechas[i].FechaVencimiento;
                            cuo.FechaUltimoPago = Fechas[i].FechaUltimoPago;
                            cuo.ImportePago = Fechas[i].ImportePago;
                            cuo.ImportePagoPunitorios = Fechas[i].ImportePagoPunitorios;
                            ActualizarTransaccional<Cuota>(cuo);
                            i++;
                        }
                        cant++;
                        bg.ReportProgress((int)(((decimal)cant / (decimal)result.Count) * 100));
                    }
                }
                Grabar();
                MessageBox.Show("Se han Corregido " + result.Count + " créditos");

                //             SqlCommand command = new SqlCommand(
                //            "SELECT CategoryID, CategoryName FROM Categories;",
                //            connection);
                //            connection.Open();

                //    SqlDataReader reader = command.ExecuteReader();

                //    if (reader.HasRows)
                //    {
                //        while (reader.Read())
                //        {
                //            Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                //                reader.GetString(1));
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("No rows found.");
                //    }
                //    reader.Close();
                //}

            }
        }

        public class ComCred
        {
            public int Com { get; set; }
            public int Cred { get; set; }
        }

        public void CorregirImporteDeCuotas(BackgroundWorker bg, int Comercio)
        {
            using (ComercioContext cf = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext")))
            {
                string sql = @"SELECT c1.ComercioID as Com, c1.CreditoID as Cred
                                FROM        Cuota c1
                                inner    join   Cuota c2 
                                on c1.empresaid = c2.empresaid
                                and c1.comercioid= c2.comercioid
                                and c1.creditoid = c2.creditoid
                                WHERE        (c1.ComercioID = " + Comercio + @")
                                and c1.ImportePago   =  0
                                and c2.ImportePago  <> 0
                                and c1.CuotaID < c2.CuotaID
                                group by c1.empresaid,c1.comercioid,c1.creditoid";

                decimal TotCob = 0;
                decimal TotPuni = 0;
                DateTime? UltimaFecha;
                var result = cf.Database.SqlQuery<ComCred>(sql).ToList();
                int cant = 0;
                foreach (ComCred comcred in result)
                {
                    List<Cuota> Cuotas = Get<Cuota>(c => c.ComercioID == comcred.Com && c.CreditoID == comcred.Cred).OrderBy(c => c.CuotaID).ToList();
                    if (Cuotas != null && Cuotas.Count > 0)
                    {
                        int i = 0;
                        foreach (Cuota cuo in Cuotas)
                        {
                            TotCob = cuo.Cobranzas.Sum(c => c.ImportePago);
                            TotPuni = cuo.Cobranzas.Sum(c => c.ImportePagoPunitorios);
                            UltimaFecha = cuo.Cobranzas.Max(c =>(DateTime?) c.FechaPago);
                            cuo.ImportePago = TotCob;
                            cuo.ImportePagoPunitorios = TotPuni;
                            cuo.FechaUltimoPago = UltimaFecha;
                            ActualizarTransaccional<Cuota>(cuo);
                            i++;
                        }
                        cant++;
                        bg.ReportProgress((int)(((decimal)cant / (decimal)result.Count) * 100));
                    }
                    Grabar();
                }
                MessageBox.Show("Se han Corregido " + result.Count + " créditos");

            }
        }


        public void CorregirNumCuotasAdelantadas(BackgroundWorker bg, int Comercio)
        {
           

            using (ComercioContext cf = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext")))
            {
                string sql = @"select	cre.ComercioID as Com,
		                        cre.CreditoID as Cred			                       
                                from Credito cre
                                where cre.TipoCuotaID = 'A'
                                and (select sum(cuo2.Deuda) from Cuota cuo2 where cuo2.ComercioID = cre.ComercioID and cuo2.CreditoID = cre.CreditoID) > 0
                                and (select min(cuo2.cuotaid) from Cuota cuo2 where cuo2.ComercioID = cre.ComercioID and cuo2.CreditoID = cre.CreditoID) = 1
                                order by 1,2";

                //string sql = @"select	cre.ComercioID,
		              //          cre.CreditoID	
		              //          -- (select min(cuo2.cuotaid) from Cuota cuo2 where cuo2.ComercioID = cre.ComercioID and cuo2.CreditoID = cre.CreditoID) 'MINNUMCUOTA',
		              //          -- (select sum(cuo2.Deuda) from Cuota cuo2 where cuo2.ComercioID = cre.ComercioID and cuo2.CreditoID = cre.CreditoID) 'DEUDA'
                //                from Credito cre
                //                where cre.TipoCuotaID = 'A'
                //                and (select sum(cuo2.Deuda) from Cuota cuo2 where cuo2.ComercioID = cre.ComercioID and cuo2.CreditoID = cre.CreditoID) > 0
                //                and (select min(cuo2.cuotaid) from Cuota cuo2 where cuo2.ComercioID = cre.ComercioID and cuo2.CreditoID = cre.CreditoID) = 1
                //                order by 1,2";



                var result = cf.Database.SqlQuery<ComCred>(sql).ToList();
                int cant = 0;
                List<Cobranza> Cobs;
                Cobranza cob;
                Cuota NuevaCuota;
                Cuota cuo;
                int res;
                List<CuentaCorriente> ccs;
                Cobranza NuevaCobranza;
                foreach (ComCred comcred in result)
                {
                    List<Cuota> Cuotas = Get<Cuota>(c => c.ComercioID == comcred.Com && c.CreditoID == comcred.Cred).OrderByDescending(c => c.CuotaID).ToList();
                    for (int i = 0;i< Cuotas.Count ;i++)
                    {
                        cuo = Cuotas[i];
                        Cobs = Get<Cobranza>(c => c.ComercioID == cuo.ComercioID && c.CreditoID == cuo.CreditoID && c.CuotaID == cuo.CuotaID).OrderBy(c => c.CuotaID).ToList();
                        if (Cobs.Count > 0)
                        {
                            Desacoplar<Cuota>(cuo.EmpresaID, cuo);
                            NuevaCuota = AutoMapper.Mapper.Map<Cuota,Cuota>(cuo);
                       
                            NuevaCuota.CuotaID = cuo.CuotaID + 1;
                            Agregar<Cuota>(cuo.EmpresaID, NuevaCuota);

                            for (int j = 0; j < Cobs.Count; j++)
                            {
                                cob = Cobs[j];
                                ccs = Get<CuentaCorriente>(c => c.ComercioID == cob.ComercioID && c.CreditoID == cob.CreditoID
                                                            && c.CuotaID == cob.CuotaID && c.CobranzaID == cob.CobranzaID).ToList();
                                if (ccs.Count > 0)
                                {
                                    Desacoplar<Cobranza>(cob.EmpresaID, cob);
                                    NuevaCobranza = AutoMapper.Mapper.Map<Cobranza, Cobranza>(cob);
                                    NuevaCobranza.CuotaID = NuevaCuota.CuotaID;
                                    Agregar<Cobranza>(cuo.EmpresaID, NuevaCobranza);

                                    sql = String.Format(@"UPDATE CuentaCorriente set CuotaId = {0} WHERE EmpresaID ={1} AND ComercioID = {2} and CreditoID = {3} and CuotaID = {4} and cobranzaid= {5}",
                                                    NuevaCuota.CuotaID, cob.EmpresaID, cob.ComercioID, cob.CreditoID, cob.CuotaID,cob.CobranzaID);
                                    res = cf.Database.ExecuteSqlCommand(sql);

                                    sql = String.Format(@"DELETE FROM Cobranza WHERE EmpresaID ={0} AND ComercioID = {1} and CreditoID = {2} and CuotaID = {3} and cobranzaID = {4}",
                                                   cob.EmpresaID, cob.ComercioID, cob.CreditoID, cob.CuotaID, cob.CobranzaID);
                                    res = cf.Database.ExecuteSqlCommand(sql);
                                }
                            }
                            

                            sql = String.Format(@"UPDATE Cobranza set CuotaId = {0} WHERE EmpresaID ={1} AND ComercioID = {2} and CreditoID = {3} and CuotaID = {4}",
                                                    NuevaCuota.CuotaID, cuo.EmpresaID, cuo.ComercioID, cuo.CreditoID, cuo.CuotaID);
                            res = cf.Database.ExecuteSqlCommand(sql);

                            sql = String.Format(@"DELETE FROM CUOTA WHERE EmpresaID ={0} AND ComercioID = {1} and CreditoID = {2} and CuotaID = {3}",
                                                   cuo.EmpresaID, cuo.ComercioID, cuo.CreditoID, cuo.CuotaID);
                            res = cf.Database.ExecuteSqlCommand(sql);

                            //for (int j = 0; j < Cobs.Count; j++)
                            //{
                            //    cob = Cobs[j];
                            //    sql = String.Format(@"UPDATE Cobranza set CuotaId = {0} WHERE EmpresaID ={1} AND ComercioID = {2} and CreditoID = {3} and CuotaID = {4}",
                            //                        NuevaCuota.CuotaID,cuo.EmpresaID,cuo.ComercioID,cuo.CreditoID,cuo.CuotaID);
                            //    cob.CuotaID = NuevaCuota.CuotaID;
                            //    Actualizar<Cobranza>(cob.EmpresaID,cob);
                            //}
                            //Borrar<Cuota>(cuo);
                        }
                        else
                        {
                            sql = String.Format(@"UPDATE CUOTA SET CUOTAID = {0} WHERE EmpresaID ={1} AND ComercioID = {2} and CreditoID = {3} and CuotaID = {4}",
                                                  cuo.CuotaID + 1,cuo.EmpresaID, cuo.ComercioID, cuo.CreditoID, cuo.CuotaID);
                            res = cf.Database.ExecuteSqlCommand(sql);
                            Desacoplar<Cuota>(cuo.EmpresaID,cuo);
                        }
                    }
                    cant++;
                    bg.ReportProgress((int)(((decimal)cant / (decimal)result.Count) * 100));
                    }
                MessageBox.Show("Se han Corregido " + result.Count + " créditos");
            }
                

            }
        
        /********************************** MIGRACION *************************************************/




        public ParametrosGlobales GetParametrosGlobales()
        {
            return pGlob;
        }


        /* Control Diario */
        public ControlDiarioRestModel GetControlDiarioHoy(Comercio com)
        {
            DateTime DiaInicio = DateTime.Now.Date;
            DateTime DiaFin = DiaInicio.AddDays(1).AddTicks(-1);
            return GetControlDiario(com, DiaInicio, DiaFin);
        }


        public ControlDiarioRestModel GetControlDiario(Comercio com,DateTime FechaDesde,DateTime FechaHasta)
        {
            DateTime DiaInicio = FechaDesde.Date;
            DateTime DiaFin = FechaHasta.Date.AddDays(1).AddTicks(-1);
            ControlDiarioRestModel cdrm = new ControlDiarioRestModel();
            cdrm.EmpresaID = com.EmpresaID;
            cdrm.ComercioID = com.ComercioID;
            cdrm.Fecha = DiaInicio;
            
            List<Credito> creds = GetCreditosEntreFechas(com,DiaInicio,DiaFin);
            if (creds != null && creds.Count > 0)
            {
                cdrm.AltasCreditos = creds.Count;
                cdrm.ValorNominalAltas = creds.Sum(c => c.ValorNominal);
            }

            List<CreditoAnulado> credsAn = GetCreditosAnuladosEntreFechas(com,DiaInicio,DiaFin);
            if (creds != null && creds.Count > 0)
            {
                cdrm.BajasCreditos = credsAn.Count;
                cdrm.ValorNominalBajas = credsAn.Sum(c => c.ValorNominal);
            }

            List<Cobranza> cobs = GetCobranzasEntreFechas(com,DiaInicio,DiaFin);
            if (cobs != null && cobs.Count >0)
            {
                cdrm.Cobranzas = cobs.Count();
                cdrm.ImporteCobranzas = cobs.Sum(c => c.ImporteTotal);
            }

            List<Cobranza> cobsBaja = GetBajasCobranzasEntreFechas(com,DiaInicio,DiaFin);
            if (cobs != null && cobs.Count > 0)
            {
                cdrm.BajasCobranzas = cobsBaja.Count();
                cdrm.BajasImporteCobranzas = cobsBaja.Sum(c => c.ImporteTotal);
            }

            /* cdcnvo_10022021*/
            List<NotasCD> NotasCredito = GetNotasCDEntreFechas(com, DiaInicio, DiaFin, pGlob.TipoNotaCredito);
            List<NotasCD> NotasDebito = GetNotasCDEntreFechas(com, DiaInicio, DiaFin, pGlob.TipoNotaDebito);
            if (NotasCredito != null && NotasCredito.Count > 0)
            {
                cdrm.NotasCD = NotasCredito.Count() - NotasDebito.Count();

                cdrm.ImporteNotasCD = NotasCredito.Sum(c => c.Importe) - NotasDebito.Sum(c=>c.Importe);          
            }

            List<CuentaCorrienteComun> lccc = CuentaCorriente(com.EmpresaID, com.ComercioID, FechaDesde,FechaHasta);
            if (lccc != null && lccc.Count > 1)
            {
                CuentaCorrienteComun ccc = lccc[1];
                cdrm.CtaCteDebe = ccc.Debe;
                cdrm.CtaCteHaber = ccc.Haber;
                cdrm.CtaCteSaldoDiario = ccc.SaldoDiario;
                cdrm.CtaCteSaldo = ccc.Saldo;
            }                
            /**/
            return cdrm;
        }

       

        public List<Credito> GetCreditosEntreFechas(Comercio com,DateTime DiaInicio,DateTime DiaFin)
        {
            List<Credito> creds = Get<Credito>(com.EmpresaID, c => c.FechaSolicitud >= DiaInicio && c.FechaSolicitud <= DiaFin
                                    && c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID).ToList();
            return creds;
        }

        
        public List<CreditoAnulado> GetCreditosAnuladosEntreFechas(Comercio com,DateTime DiaInicio,DateTime DiaFin)
        {
            List<CreditoAnulado> credsAn = Get<CreditoAnulado>(com.EmpresaID, c => c.FechaSolicitud >= DiaInicio && c.FechaSolicitud <= DiaFin
                                    && c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID).ToList();
            return credsAn;
        }

        public List<Cobranza> GetCobranzasEntreFechas(Comercio com,DateTime DiaInicio,DateTime DiaFin)
        {
            List<Cobranza> cobs = Get<Cobranza>(com.EmpresaID,c=>c.FechaPago >= DiaInicio && c.FechaPago <= DiaFin 
                                    && c.GestionEmpresaID == com.EmpresaID && c.GestionID == com.ComercioID && c.ImporteTotal > 0).ToList();
            return cobs;
        }

        public List<Cobranza> GetBajasCobranzasEntreFechas(Comercio com,DateTime DiaInicio,DateTime DiaFin)
        {
            List<Cobranza> cobsBaja = Get<Cobranza>(com.EmpresaID, c => c.FechaPago >= DiaInicio && c.FechaPago <= DiaFin
                                    && c.GestionEmpresaID == com.EmpresaID && c.GestionID == com.ComercioID 
                                    && c.ImporteTotal < 0).ToList();
            return cobsBaja;
        }

        public List<Cobranza> GetCobranzasYBajasEntreFechas(Comercio com,DateTime DiaInicio,DateTime DiaFin)
        {
            List<Cobranza> cobs = Get<Cobranza>(com.EmpresaID,c=>c.FechaPago >= DiaInicio && c.FechaPago <= DiaFin 
                                    && c.GestionEmpresaID == com.EmpresaID && c.GestionID == com.ComercioID).ToList();
            return cobs;
        }

        /* cdcnvo_10022021*/
        public List<NotasCD> GetNotasCDEntreFechas(Comercio com, DateTime DiaInicio, DateTime DiaFin, string TipoNota)
        {
            List<NotasCD> notasCDs = Get<NotasCD>(com.EmpresaID, c => c.Fecha >= DiaInicio && c.Fecha <= DiaFin
                                     && c.EmpresaID == com.EmpresaID && c.GestionID == com.ComercioID
                                     && c.TipoNota == TipoNota).ToList();
            return notasCDs;
        }
        /**/


        /* Obtener Tipos Movimientos para Recibos*/

        public List<TipoMovimiento> GetMovimientosRec()
        {
            return  Get<TipoMovimiento>(t => t.Cod == "NREC").ToList();
        }

        /* Buscar Imagenes */
        //var searchedDirectory = new DirectoryInfo(ruta);
        public string[] SearchDirectory(string path, string pattern)
        {
            var searchedDirectory = new DirectoryInfo(path);
            if (!searchedDirectory.Exists)
            { return null; }
            List<string> listado = new List<string>();

            FileSystemInfo[] fsi = searchedDirectory.GetFileSystemInfos();
            foreach (FileSystemInfo info in fsi)
            {
                if (info.Attributes != FileAttributes.Directory)
                {
                    var file = (FileInfo)info;
                    if (file != null)
                    {
                        if (file.Name.Contains(pattern))
                            listado.Add(file.Name);
                    }
                }                
                else
                {
                    var dir = (DirectoryInfo)info;
                    if (dir != null)
                    {
                        SearchDirectory(dir.FullName, pattern);
                    }
                }
            }
            return listado.ToArray();
        }

        public List<string> EnumerarRutaImagenesDNI(string dni, string ruta)
        {
            
            List<string> files = new List<string>();
            try
            {
                dni = String.Format("*{0}*.jpg", dni);

                FileData[] filesData = FastDirectoryEnumerator.GetFiles(ruta, dni, SearchOption.AllDirectories);
                for (int i = 0; i < filesData.Length; i++)
                {
                    if ((filesData[i].Attributes & FileAttributes.Directory) == 0)
                    {
                        files.Add(filesData[i].Path);                        
                    }
                }

                //DirectoryInfo dirInfo = new DirectoryInfo(ruta);
                //FileInfo[] oldFiles = dirInfo.EnumerateFiles(dni, SearchOption.AllDirectories).AsParallel().ToArray();
                //files = oldFiles.Select(x => x.FullName).ToList();


                //files = Directory.EnumerateFiles(ruta,dni, SearchOption.AllDirectories).ToList();
                //files = GetFileList(dni,ruta).ToArray();
                return files;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("No se encuentra el Directorio, configure las ruta de Fotos e Imágenes en las opciones de configuración", "Error de rutas");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encuentra el Directorio, configure las ruta de Fotos e Imágenes en las opciones de configuración", "Error de rutas");
            }
            return files;
        }


        public string[] BuscarRutaImagenesDNI(string dni, string ruta)
            {
                List<string> files = new List<string>();
                try
                {
                dni = String.Format("*{0}*.jpg", dni);

                FileData[] filesData = FastDirectoryEnumerator.GetFiles(ruta, dni, SearchOption.AllDirectories);
                for (int i = 0; i < filesData.Length; i++)
                {
                    if ((filesData[i].Attributes & FileAttributes.Directory) == 0)
                    {
                        files.Add(filesData[i].Path);
                    }
                }



                //files = Directory.GetFiles(ruta, dni,SearchOption.AllDirectories);
                //  files = Directory.EnumerateFiles(ruta, dni, SearchOption.AllDirectories).ToArray();
                //files = GetFileList(dni,ruta).ToArray();
                return  files.ToArray();
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show("No se encuentra el Directorio, configure las ruta de Fotos e Imágenes en las opciones de configuración", "Error de rutas");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se encuentra el Directorio, configure las ruta de Fotos e Imágenes en las opciones de configuración", "Error de rutas");
                }
                return files.ToArray();
            }

        public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
        {
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            string[] tmp;
            while (pending.Count > 0)
            {
                rootFolderPath = pending.Dequeue();
                try
                {
                    tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                for (int i = 0; i < tmp.Length; i++)
                {
                    yield return tmp[i];
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                for (int i = 0; i < tmp.Length; i++)
                {
                    pending.Enqueue(tmp[i]);
                }
            }
        }

        public Image BuscarUnaImagenDni(string dni, string QIma,ref List<string> rutasOut)
            {
                string[] rutas = BuscarRutaImagenesDNI(dni + "_" + QIma, pGlob.Configuracion.rutaImagenes);
                if (rutas != null && rutas.Length > 0)
                {
                    rutasOut.AddRange(rutas.ToList());
                    return BuscarImagen(rutas[0]);
                }                    
                return null;
            }
        /*cdc_nvo 07102020*/
        public bool ExisteImagenDni(string dni, string QIma)
        {
            string[] rutas = BuscarRutaImagenesDNI(dni + QIma, pGlob.Configuracion.rutaImagenes);
            if (rutas != null && rutas.Length > 0)
                return true;
            return false;
        }
        public  async Task<string> TraeRutaImagen(string dni, string QIma) //edu202103
        {
            string cFile = "";
            String[] files = null;
            try
            {
                string[] rutas =  BuscarRutaImagenesDNI(dni + QIma, pGlob.Configuracion.rutaImagenes);
                if (rutas != null && rutas.Length > 0)
                {
                    cFile = rutas[0];
                }
                return cFile;
            }
            catch
            {

            }
            return cFile;
        }
        public Image BuscarUnaImagenDni(string dni, string QIma)
            {
                string[] rutas = BuscarRutaImagenesDNI(dni + QIma, pGlob.Configuracion.rutaImagenes);
                if (rutas != null && rutas.Length > 0)
                for (int i = 0; i < rutas.Length; i++)
                {
                    return BuscarImagen(rutas[0]);
                }
            //return BuscarImagen(rutas[0]);
                return null;
            }

            public Image[] BuscarImagenesDni(string dni)
            {
                string[] rutas = BuscarRutaImagenesDNI(dni, pGlob.Configuracion.rutaImagenes);
                Image[] Imagenes = new Image[rutas.Length];
                for (int i = 0; i < rutas.Length; i++)
                {
                    Imagenes[i] = BuscarImagen(rutas[i]);
                }
                return Imagenes;
            }

            public Image BuscarFotosDni(string dni)
            {
                string[] rutas = BuscarRutaImagenesDNI(dni, pGlob.Configuracion.rutaFotos);
                if (rutas != null && rutas.Length > 0)
                    return BuscarImagen(rutas[0]);
                return null;
            }

            public Image BuscarFotosDni(string dni, ref List<string> rutasOut)
            {
                try
                {
                    string[] rutas = BuscarRutaImagenesDNI(dni, pGlob.Configuracion.rutaFotos);
                    if (rutas != null && rutas.Length > 0)
                    {
                        rutasOut.AddRange(rutas.ToList());
                        return BuscarImagen(rutas[0]);
                    }
                    
                }
                catch { }
                return null;
            }

            
            public Image BuscarImagen(string rutaImagen)
            {
                if (File.Exists(rutaImagen))
                //return Image.FromFile(rutaImagen);
                {
                    if (new FileInfo(rutaImagen).Length != 0)
                    {
                        Image img;
                        using (var bmpTemp = new Bitmap(rutaImagen))
                        {
                            img = new Bitmap(bmpTemp);
                        }
                        return img;
                    }
                    else
                        MessageBox.Show("La imagen seleccionada esta vacia, tamaño 0");
                    }                    
                return null;
            }

        public string[] BuscarSolicitudesImagen(string cComer, string cCredito)//edunvo202112
        {
            String[] files = null;
            if(pGlob.Configuracion.ScanSolicitudes == false) return files;
             string cArch = cComer.PadLeft(4, '0') + "_" + cCredito; // + "*.*";
            if(cComer == pGlob.ComercioID.ToString())
            {
                files = BuscarRutaImagenesDNI(cArch, pGlob.Configuracion.rutaSolicitudes);
            }
            else
            {
                files = BuscarRutaImagenesDNI(cArch, pGlob.Configuracion.rutaSolicitudesMor);
            }
            
            return files;
        }

        /*TipoComoConocio */
        public IEnumerable<TipoComoConocio> GetTiposComoConocio(Expression<Func<TipoComoConocio, bool>> filter = null,
                                     Func<IQueryable<TipoComoConocio>, IOrderedQueryable<TipoComoConocio>> orderBy = null,
                                     string includeProperties = "")
            {
                return dal.GetTiposComoConocio(filter, orderBy, includeProperties);
            }

            public TipoComoConocio GetTipoComoConocioByID(object id)
            {
                return dal.GetTipoComoConocioByID(id);
            }

            public void AgregarTipoComoConocio(TipoComoConocio s)
            {
                dal.AgregarTipoComoConocio(s);
            }

            public void BorrarTipoComoConocio(object id)
            {
                dal.BorrarTipoComoConocio(id);
            }

            public void BorrarTipoComoConocio(TipoComoConocio s)
            {
                dal.BorrarTipoComoConocio(s);
            }

            public void ActualizarTipoComoConocio(TipoComoConocio s)
            {
                dal.ActualizarTipoComoConocio(s);
            }

            public BindingList<TipoComoConocio> TipoComoConocioBindingList()
            {
                return dal.TipoComoConocioBindingList();
            }

            /*ClaseDato */
            public IEnumerable<ClaseDato> GetClasesDato(Expression<Func<ClaseDato, bool>> filter = null,
                                     Func<IQueryable<ClaseDato>, IOrderedQueryable<ClaseDato>> orderBy = null,
                                     string includeProperties = "")
            {
                return dal.GetClasesDato(filter, orderBy, includeProperties);
            }

            public ClaseDato GetClaseDatoByID(object id)
            {
                return dal.GetClaseDatoByID(id);
            }

            public void AgregarClaseDato(ClaseDato s)
            {
                dal.AgregarClaseDato(s);
            }

            public void BorrarClaseDato(object id)
            {
                dal.BorrarClaseDato(id);
            }

            public void BorrarClaseDato(ClaseDato s)
            {
                dal.BorrarClaseDato(s);
            }

            public void ActualizarClaseDato(ClaseDato s)
            {
                dal.ActualizarClaseDato(s);
            }

            public BindingList<ClaseDato> ClaseDatoBindingList()
            {
                return dal.ClaseDatoBindingList();
            }

            /*Cliente */
            public IEnumerable<Cliente> GetClientes(Expression<Func<Cliente, bool>> filter = null,
                                     Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> orderBy = null,
                                     string includeProperties = "")
            {
                return dal.GetClientes(filter, orderBy, includeProperties);
            }
        public IEnumerable<Cliente> GetClientes(int BaseIDb, Expression<Func<Cliente, bool>> filter = null,
                                 Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> orderBy = null,
                                 string includeProperties = "")
        {
            return GetDal(BaseIDb).GetClientes(filter, orderBy, includeProperties);
        }
        public Cliente GetClienteByID(object id)
            {
                return dal.GetClienteByID(id);
            }

            public void AgregarCliente(Cliente s)
            {
                //dal.context.Configuration.AutoDetectChangesEnabled = false;
                dal.AgregarCliente(s);
                //dal.context.Configuration.AutoDetectChangesEnabled = true;
            }

            public void AgregarClientesBulk(List<Cliente>lista)
            {
                //Dura Casi lo mismo que uno por uno deshabilitando el contexto, osea el metodo AgregarCliente
                dal.context.Configuration.AutoDetectChangesEnabled = false;
                foreach (Cliente cli in lista)
                {
                    dal.AgregarCliente(cli);
                }
                dal.context.Configuration.AutoDetectChangesEnabled = true;
            }

            public void AgregarClientesRange(List<Cliente> lista)
            {
                dal.context.Configuration.AutoDetectChangesEnabled = false; 
                //Este es el metodo mas rapido de los comparando con los tres anteriores
                //tendria que probar deshabilitaando tambien el autoDetectChangesEnabled
                dal.context.Clientes.AddRange(lista);
                dal.Save();
                dal.context.Configuration.AutoDetectChangesEnabled = true; 
            }
            

            public void BorrarCliente(object id)
            {
                dal.BorrarCliente(id);
            }

            public void BorrarCliente(Cliente s)
            {
                dal.BorrarCliente(s);
            }

            public void ActualizarCliente(Cliente s)
            {
                dal.ActualizarCliente(s);
            }

            public BindingList<Cliente> ClienteBindingList()
            {
                return dal.ClienteBindingList();
            }


            /*Sexo */
            public IEnumerable<Sexo> GetSexos(Expression<Func<Sexo, bool>> filter = null,
                                     Func<IQueryable<Sexo>, IOrderedQueryable<Sexo>> orderBy = null,
                                     string includeProperties = "")
            {
                return dal.GetSexos(filter, orderBy, includeProperties);
            }

            public Sexo GetSexoByID(object id)
            {
                return dal.GetSexoByID(id);
            }

            public void AgregarSexo(Sexo s)
            {
                dal.AgregarSexo(s);
            }

            public void BorrarSexo(object id)
            {
                dal.BorrarSexo(id);
            }

            public void BorrarSexo(Sexo s)
            {
                dal.BorrarSexo(s);
            }

            public void ActualizarSexo(Sexo s)
            {
               dal.ActualizarSexo(s);
            }

            public BindingList<Sexo> SexoBindingList()
            {
                return dal.SexoBindingList();
            }

            /* Gastos */
            public Gasto  AgregarGasto(Gasto gasto,Comercio com)
            {
                Agregar<Gasto>(gasto);
                CuentaCorriente cc = ImputacionCuentaCorrienteGasto(gasto);
                Grabar(gasto.EmpresaID);
                List<Transmision> ltrans = new List<Transmision>();
                ltrans = Transmision<Gasto>(ltrans, gasto, com, pGlob.TransAltaGasto, pGlob.UriGastos);
                ltrans = Transmision<CuentaCorriente>(ltrans, cc, com, pGlob.TransImputacionCC, pGlob.UriGastos);
                GrabarTransmisiones(gasto.EmpresaID, ltrans);
                return gasto;
            }

            public Gasto EliminarGasto(Gasto gasto, Comercio com)
            {
                gasto.EstadoID = pGlob.Eliminado.EstadoID;
                Actualizar<Gasto>(gasto);
                CuentaCorriente cc = ImputacionAnulacionCuentaCorrienteGasto(gasto);
                Grabar(gasto.EmpresaID);
                List<Transmision> ltrans = new List<Transmision>();
                ltrans = Transmision<Gasto>(ltrans, gasto, com, pGlob.TransBajaGasto, pGlob.UriGastos);
                ltrans = Transmision<CuentaCorriente>(ltrans, cc, com, pGlob.TransImputacionCC, pGlob.UriGastos);
                GrabarTransmisiones(gasto.EmpresaID, ltrans);
                return gasto;
            }

            /* ConceptoGastos */
            public IEnumerable<ConceptoGastos> GetConceptoGastos(Expression<Func<ConceptoGastos, bool>> filter = null,
                                   Func<IQueryable<ConceptoGastos>, IOrderedQueryable<ConceptoGastos>> orderBy = null,
                                   string includeProperties = "")
            {
                return dal.GetConceptoGastos(filter, orderBy, includeProperties);
            }

            public IEnumerable<ConceptoGastos> GetConceptoGastosLogico(Expression<Func<ConceptoGastos, bool>> filter = null,
                                   Func<IQueryable<ConceptoGastos>, IOrderedQueryable<ConceptoGastos>> orderBy = null,
                                   string includeProperties = "")
            {
                IEnumerable<ConceptoGastos> lista = GetConceptoGastos(filter, orderBy, includeProperties).Where(c => c.EstadoID != pGlob.ConceptoGastoEliminado.EstadoID).ToList();
                foreach (ConceptoGastos cg in lista)
                {
                    
                }
                return lista;
            }

            public IEnumerable<ConceptoGastos> GetConceptoGastosLogicoEnNivelFinal(Expression<Func<ConceptoGastos, bool>> filter = null,
                                       Func<IQueryable<ConceptoGastos>, IOrderedQueryable<ConceptoGastos>> orderBy = null,
                                       string includeProperties = "")
            {
                IEnumerable<ConceptoGastos> lista = GetConceptoGastos(filter, orderBy, includeProperties)
                                            .Where(c => c.EstadoID != pGlob.ConceptoGastoEliminado.EstadoID
                                            && c.NivelFinal).ToList();
                return lista;
            }

            public ConceptoGastos GetConceptoGastosByID(object id)
            {
                return dal.ConceptoGastosByID(id);
            }

            public void AgregaConceptoGastos(ConceptoGastos gst)
            {
                gst.ConceptoGastosID = ObtenerProximoNumeroDeConceptoGst();
                dal.AgregarConceptoGasto(gst);
            }

            public int ObtenerProximoNumeroDeConceptoGst()
            {
                if (dal.GetConceptoGastos().Any())
                {
                    return dal.GetConceptoGastos().Max(p => p.ConceptoGastosID).Value + 1;
                }
                else
                    return 1;
            }

            public void BorrarConceptoGasto(object id)
            {
                dal.BorrarConceptoGasto(id);
                //dal.BorrarProveedor(id);
            }

            public void BorrarConceptoGasto(ConceptoGastos cgs)
            {
                dal.BorrarConceptoGasto(cgs);
            }

            public void BorrarConceptoGastoLogico(ConceptoGastos gst)
            {
                gst.EstadoID = pGlob.ConceptoGastoEliminado.EstadoID;
                ActualizarConceptoGasto(gst);
            }

            public void ActualizarConceptoGasto(ConceptoGastos gst)
            {
                dal.ActualizarConceptoGasto(gst);
            }

            public List<ConceptoGastos> GetConceptosGastoNoEn(IEnumerable<ConceptoGastosProveedor> lista,
                                                                    Expression<Func<ConceptoGastos, bool>> filter = null,
                                                                    Func<IQueryable<ConceptoGastos>, IOrderedQueryable<ConceptoGastos>> orderBy = null,
                                                                    string includeProperties = "")
            {
                return GetConceptoGastosLogicoEnNivelFinal(filter, orderBy, includeProperties)
                        .Where(c => !lista.Any(l => l.ConceptoGastosID == c.ConceptoGastosID)).ToList();
            }

           



            /* ConceptoGastosProveedor */
            public IEnumerable<ConceptoGastosProveedor> GetConceptoGastosProveedor(Expression<Func<ConceptoGastosProveedor, bool>> filter = null,
                                   Func<IQueryable<ConceptoGastosProveedor>, IOrderedQueryable<ConceptoGastosProveedor>> orderBy = null,
                                   string includeProperties = "")
            {
                return dal.GetConceptoGastosProveedor(filter, orderBy, includeProperties);
            }

            public IEnumerable<ConceptoGastosProveedor> GetConceptoGastosProveedorLogico(Expression<Func<ConceptoGastosProveedor, bool>> filter = null,
                                   Func<IQueryable<ConceptoGastosProveedor>, IOrderedQueryable<ConceptoGastosProveedor>> orderBy = null,
                                   string includeProperties = "")
            {
                IEnumerable<ConceptoGastosProveedor> lista = GetConceptoGastosProveedor(filter, orderBy, includeProperties).Where(c => c.EstadoID != pGlob.ConceptoGastoProveedorEliminado.EstadoID).ToList();
                return lista;
            }

            public ConceptoGastosProveedor GetConceptoGastosProveedorByID(object id)
            {
                return dal.ConceptoGastosProveedorByID(id);
            }


            public void BorrarConceptoGastoProveedor(object id)
            {
                dal.BorrarConceptoGastoProveedor(id);
                //dal.BorrarProveedor(id);
            }

            public void BorrarConceptoGastoProveedor(ConceptoGastosProveedor cgs)
            {
                dal.BorrarConceptoGastoProveedor(cgs);
            }

            public void BorrarConceptoGastoProveedorLogico(ConceptoGastosProveedor gst)
            {
                gst.EstadoID = pGlob.ConceptoGastoProveedorEliminado.EstadoID;
                ActualizarConceptoGastoProveedor(gst);
            }

            public void ActualizarConceptoGastoProveedor(ConceptoGastosProveedor gst)
            {
                dal.ActualizarConceptoGastoProveedor(gst);
            }            


            /* Usuarios */
        public IEnumerable<Usuario> GetUsuarios(Expression<Func<Usuario, bool>> filter = null,
                               Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetUsuarios(filter, orderBy, includeProperties);
    }

        public Usuario GetUsuarioByID(object id) 
        { 
            return dal.GetUsuarioByID(id); 
        }

        public void AgregarUsuario(Usuario usu)
        {
            dal.AgregarUsuario(usu);
        }

        public void BorrarUsuario(object id) 
        {
            dal.BorrarUsuario(id);
        }

        public void BorrarUsuario(Usuario usu) 
        {
            dal.BorrarUsuario(usu);
        }

        public void ActualizarUsuario(Usuario usu)
        {
            dal.ActualizarUsuario(usu);
        }

        public BindingList<Usuario> UsuarioBindingList()
        {
            return dal.UsuarioBindingList();
        }

        public Usuario AutenticarUsuario(string usuario,string pass)
        {
            Usuario usu = GetUsuarios(u => u.usuario == usuario).FirstOrDefault();
            if (usu != null)
            {
                if (usu.pass == pass)
                    return usu;
            }
            return null;
        }

        /* Perfiles */
        public IEnumerable<Perfil> GetPerfiles(Expression<Func<Perfil, bool>> filter = null,
                               Func<IQueryable<Perfil>, IOrderedQueryable<Perfil>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetPerfiles(filter, orderBy, includeProperties);
        }

        public Perfil GetPerfilByID(object id)
        {
            return dal.GetPerfilByID(id);
        }

        public void AgregarPerfil(Perfil per)
        {
            dal.AgregarPerfil(per);
        }

        public void BorrarPerfil(object id)
        {
            dal.BorrarPerfil(id);
        }

        public void BorrarPerfil(Perfil per)
        {
            dal.BorrarPerfil(per);
        }

        public void ActualizarPerfil(Perfil per)
        {
            dal.ActualizarPerfil(per);
        }

        public BindingList<Perfil> PerfilBindingList()
        {
            return dal.PerfilBindingList();
        }

        
        public void AsignarPerfilesAUsuario(Usuario usu, IEnumerable<Perfil> perfiles)
        {
            foreach (Perfil per in perfiles)
            {
                this.AsignarPerfilAUsuario(usu,per);
            }
       }

        public void QuitarPerfilAUsuario(Usuario usu, Perfil per)
        {
            usu.Perfiles.Remove(per);
        }

        public void QuitarPerfilesAUsuario(Usuario usu, IEnumerable<Perfil> perfiles)
        {
            foreach (Perfil per in perfiles)
            {
                this.QuitarPerfilAUsuario(usu, per);
            }
        }

        public void AsignarPerfilAUsuario(Usuario usu, Perfil per)
        {
            usu.Perfiles.Add(per);
        }


        public IEnumerable<Perfil> GetPerfilesPosiblesParaAsignar(Usuario usu)
        {
           IEnumerable<Perfil> perfiles = this.GetPerfiles();
           return perfiles.Where(p => !usu.Perfiles.Any(p2 => p2.PerfilID == p.PerfilID)).ToList<Perfil>();
        }

        /* Permisos */

        public IEnumerable<Permiso> GetPermisos(Expression<Func<Permiso, bool>> filter = null,
                               Func<IQueryable<Permiso>, IOrderedQueryable<Permiso>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetPermisos(filter, orderBy, includeProperties);
        }

        public Permiso GetPermisoByID(object id)
        {
            return dal.GetPermisoByID(id);
        }

        public void AgregarPermiso(Permiso per)
        {
            dal.AgregarPermiso(per);
        }

        public void BorrarPermiso(object id)
        {
            dal.BorrarPermiso(id);
        }

        public void BorrarPermiso(Permiso per)
        {
            dal.BorrarPermiso(per);
        }

        public void ActualizarPermiso(Permiso per)
        {
            dal.ActualizarPermiso(per);
        }

        public BindingList<Permiso> PermisoBindingList()
        {
            return dal.PermisoBindingList();
        }


        public void AsignarPermisosAPerfiles(Perfil perf, IEnumerable<Permiso> permisos)
        {
            foreach (Permiso perm in permisos)
            {
                this.AsignarPermisoAPerfil(perf, perm);
            }
        }

        public void QuitarPermisoAPerfil(Perfil perf, Permiso perm)
        {
            perf.Permisos.Remove(perm);
        }

        public void QuitarPermisosAPerfiles(Perfil perf, IEnumerable<Permiso> permisos)
        {
            foreach (Permiso perm in permisos)
            {
                this.QuitarPermisoAPerfil(perf, perm);
            }
        }

        public void AsignarPermisoAPerfil(Perfil perf, Permiso perm)
        {
            perf.Permisos.Add(perm);
        }


        public IEnumerable<Permiso> GetPermisosPosiblesParaAsignar(Usuario usu)
        {
            IEnumerable<Permiso> permisos = this.GetPermisos();
            return permisos.Where(p => !usu.GetPermisos().Any(p2 => p2.PermisoID == p.PermisoID)).ToList<Permiso>();
        }

        public IEnumerable<Permiso> GetPermisosPosiblesParaAsignar(Perfil per)
        {
            IEnumerable<Permiso> permisos = this.GetPermisos();
            return permisos.Where(p => !per.Permisos.Any(p2 => p2.PermisoID == p.PermisoID)).ToList<Permiso>();
        }

        public bool TienePermiso(Usuario usu,string Permisos)
        {
            List<string> permisos = usu.GetPermisos().Select(pe => pe.nombre).ToList();
            if (permisos.Contains(Permisos))
            {
               return true;
            }
            return false;
        }

        

        
        /****** Solicitudes de Fondo ***************/
        public IEnumerable<SolicitudFondo> GetSolicitudesDeFondos(Expression<Func<SolicitudFondo, bool>> filter = null,
                               Func<IQueryable<SolicitudFondo>, IOrderedQueryable<SolicitudFondo>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetSolicitudesDeFondos(filter, orderBy, includeProperties);                
        }

        public SolicitudFondo GetSolicitudesDeFondosByID(object id)
        {
            return dal.GetSolicitudesDeFondosByID(id);
        }

        public void AgregarSolicitudesDeFondos(SolicitudFondo solfon)
        {
            dal.AgregarSolicitudesDeFondos(solfon);
        }

        public void BorrarSolicitudesDeFondos(object id)
        {
            dal.BorrarSolicitudesDeFondos(id);
        }

        public void BorrarSolicitudesDeFondos(SolicitudFondo solfon)
        {
            dal.BorrarSolicitudesDeFondos(solfon);
        }

        public void ActualizarSolicitudDeFondos(SolicitudFondo solfon)
        {
            dal.ActualizarSolicitudDeFondos(solfon);
        }

        public List<SolicitudFondo> GetSolicitudesDeFondos(Comercio com, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<SolicitudFondo> ls=  GetSolicitudesDeFondos(s => s.ComercioID == com.ComercioID 
                                           /*&& (s.FechaPago >= fechaDesde.Date &&  s.FechaPago <= fechaHasta.Date)*/).ToList();
            // Por ahora se hace asi porque la implementacion dle generic repository no permite comparar con DateTime.Date
            // Tengo que hacer el repositorio mejor, de forma que permita comparaciones mas complejas, esto del date y equals por ejemplo
            ls = ls.FindAll(s => s.FechaPago.Value.Date >= fechaDesde.Date && s.FechaPago.Value.Date <= fechaHasta.Date);
            return ls;
        }

        //private bool SolicitudEnEstadoFinal(SolicitudFondo sf)
        //{
        //    return (!(sf.EstadoID == pGlob.SolicitudFondoInicial.EstadoID)
        //            && !(sf.EstadoID == pGlob.SolicitudFondoRechazadaGerencia.EstadoID)
        //            && !(sf.EstadoID == pGlob.SolicitudFondoRechazadaTesoreria.EstadoID)
        //            && !(sf.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID));
        //}


        public bool EsEstadoFinal(Estado Est)
        {
            if (Est.EstadoID == pGlob.SolicitudFondoInicial.EstadoID
                || Est.EstadoID == pGlob.SolicitudFondoRechazadaGerencia.EstadoID
                || Est.EstadoID == pGlob.SolicitudFondoRechazadaTesoreria.EstadoID
                || Est.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID
                || Est.EstadoID == pGlob.SolicitudFondoAnulada.EstadoID)
                return true;
            return false;
             
        }


        public List<SolicitudFondo> GetSolicitudesDeFondosYEnEstadoNoFinal(Comercio com, DateTime fechaDesde, DateTime fechaHasta)
        {   
            DateTime FechaDesdeCuando = DateTime.Now.AddDays(-pGlob.Configuracion.solfonDiasParaAtras);
            List<SolicitudFondo> lsolNoFinal = GetSolicitudesDeFondos(s=> s.ComercioID == com.ComercioID && s.EmpresaID == com.Empresa.EmpresaID
                                                              &&  !(s.EstadoID == pGlob.SolicitudFondoInicial.EstadoID)
                                                              &&  !(s.EstadoID == pGlob.SolicitudFondoRechazadaGerencia.EstadoID)
                                                              &&  !(s.EstadoID == pGlob.SolicitudFondoRechazadaTesoreria.EstadoID)
                                                              &&  !(s.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID)
                                                              &&  !(s.EstadoID == pGlob.SolicitudFondoAnulada.EstadoID)).ToList();

            lsolNoFinal = lsolNoFinal.Where(sf => !(sf.EstadoID == pGlob.SolicitudFondoAnulada.EstadoID && sf.FechaPago <= FechaDesdeCuando)).ToList();

            List<SolicitudFondo> lsol = GetSolicitudesDeFondos(s => s.ComercioID == com.ComercioID && s.EmpresaID == com.Empresa.EmpresaID
                                                              &&  ((s.EstadoID == pGlob.SolicitudFondoInicial.EstadoID)
                                                              ||  (s.EstadoID == pGlob.SolicitudFondoRechazadaGerencia.EstadoID)
                                                              ||  (s.EstadoID == pGlob.SolicitudFondoRechazadaTesoreria.EstadoID)
                                                              ||  (s.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID)
                                                              ||  (s.EstadoID == pGlob.SolicitudFondoAnulada.EstadoID))).ToList();
            
            lsol = lsol.Where(s=> s.FechaPago.Value.Date >= fechaDesde.Date && s.FechaPago.Value.Date <= fechaHasta.Date).ToList();
            lsol.AddRange(lsolNoFinal);
            lsol.OrderBy(s=> s.FechaPago);
            return lsol;
        }

        public void CompararYActualizarSolicitudesFondos(Comercio com, DateTime fechaDesde, DateTime fechaHasta,List<SolicitudFondo> sfsServidor)
        {
            if (sfsServidor.Count > 0 )
            { 
                List<SolicitudFondo> sfs =  GetSolicitudesDeFondos(com, fechaDesde, fechaHasta);
                if (sfs.Count > 0 )
                { 
                    sfs.ForEach(s =>
                        {
                            var sfr = sfsServidor.FirstOrDefault(sr => sr.SolicitudFondoID.Equals(s.SolicitudFondoID));
                            if (sfr != null)
                            {
                                ActualizarSolicitudConDatosDeServidor(s, sfr);
                            }
                        }
                    );
                }
            }
        }

        private void ActualizarSolicitudConDatosDeServidor(SolicitudFondo sflocal,SolicitudFondo sfserver)
        {
            if (sfserver.NumCheque != null)
            {
                AgregarChequeChequera(sfserver);
            }
            if (sflocal.EstadoID == pGlob.SolicitudFondoConfirmadaYFonRet.EstadoID)
                 sfserver.EstadoID = pGlob.SolicitudFondoConfirmadaYFonRet.EstadoID;
            sflocal.ActualizarConDatosDeServidor(sfserver);
            if (sflocal.EstadoID == pGlob.SolicitudFondoAnulada.EstadoID)
            {
                AnularAutorizaciones(sflocal);
            }
            ActualizarSolicitudDeFondos(sflocal);
        }

        public void ActualizarEstadoAutorizacionesCAPyFF(List<SolicitudFondo> sfs)
        {
            foreach (SolicitudFondo sf in sfs)
            {
                if (EsCapOFF(sf))
                {
                    sf.EstadoID = pGlob.SolicitudFondoConfirmada.EstadoID;
                    Actualizar<SolicitudFondo>(sf);
                }
            }
        }

        public void ActualizarEstadoAutorizacionesNoResueltas(List<SolicitudFondo> sfs)
        {
            foreach (SolicitudFondo sf in sfs)
            {
                if (!EsEstadoFinal(sf.Estado))
                {
                    sf.EstadoID = pGlob.SolicitudFondoAnulada.EstadoID;
                    Actualizar<SolicitudFondo>(sf);
                }
            }
        }


        public bool EsCapOFF(SolicitudFondo sf)
        {
            if (EsCap(sf) || EsFF(sf))
                return true;
            return false;
        }

        public bool EsCap(SolicitudFondo sf)
        {
            return (sf.TipoSolicitudID == pGlob.tsCap.TipoSolicitudID);
        }

        public bool EsFF(SolicitudFondo sf)
        {
            return (sf.TipoSolicitudID == pGlob.tsFF.TipoSolicitudID);
        }

        private void AnularAutorizaciones(SolicitudFondo sf)
        {
            List<Autorizacion> auts = Get<Autorizacion>(sf.EmpresaID.Value, a => a.EmpresaID == sf.EmpresaID
                                                       && a.ComercioID == sf.ComercioID
                                                       && a.SolicitudFondoID == sf.SolicitudFondoID).ToList();
            foreach (Autorizacion aut in auts)
            {
                aut.EstadoID = pGlob.AutorizacionAnulada.EstadoID;
                ActualizarTransaccional<Autorizacion>(aut.EstadoID.Value, aut);
            }            
        }

        private void AgregarChequeChequera(SolicitudFondo sf)
        {
            Cheque cheq = Get<Cheque>(sf.EmpresaID.Value, c => c.EmpresaID == sf.EmpresaID && c.CuentaBancariaID == sf.CuentaBancariaID
                        && c.ChequeraID == sf.NumChequera && c.ChequeID == sf.NumCheque).FirstOrDefault();
            if (cheq == null)
            {
                cheq = AgregarCheque(sf);
                Chequera chequera = Get<Chequera>(sf.EmpresaID.Value, c => c.EmpresaID == sf.EmpresaID && c.CuentaBancariaID == sf.CuentaBancariaID
                        && c.ChequeraID == sf.NumChequera).FirstOrDefault();
                if (chequera == null)
                    AgregarChequera(cheq);
                Grabar(cheq.EmpresaID.Value);
            }            
        }

        private void AgregarChequera(Cheque Cheque)
        {
            Chequera cheq = new Chequera();
            cheq.EmpresaID = Cheque.EmpresaID;
            cheq.CuentaBancariaID = Cheque.CuentaBancariaID;
            cheq.ChequeraID = Cheque.ChequeraID;
            cheq.NumTalonario = Cheque.ChequeraID;
            AgregarTransaccional<Chequera>(cheq.EmpresaID.Value,cheq);
        }

        private Cheque AgregarCheque(SolicitudFondo sf)
        {
            Cheque Cheque = new Cheque();
            Cheque.EmpresaID = sf.EmpresaID;
            Cheque.CuentaBancariaID = sf.CuentaBancariaID;
            Cheque.ChequeraID = sf.NumChequera;
            Cheque.ChequeID = sf.NumCheque;
            Cheque.EstadoID = pGlob.ChequeUtilizado.EstadoID;
            Cheque.Monto = sf.Importe;
            AgregarTransaccional<Cheque>(Cheque.EmpresaID.Value, Cheque);
            return Cheque;
        }
       


        public async Task<InfoCliente> ObtenerInfoCliente(string url,Comercio com, Cliente cli)
        {
            InfoCliente ic = await ra.GetInfoClienteAsync(url, com, cli);
            return ic;
        }

        public async Task<RecibosYTransferencias> ActualizarRecibosYTransferenciasCentral(Comercio com, DateTime fechaDesde, DateTime fechaHasta, Estado est)
        {
            RecibosYTransferencias sfvm = await ra.GetRecibosYTransferenciasCentralAsync(com, fechaDesde, fechaHasta, est);
            return sfvm;
        }

        public void CompararYActualizarRecibosYTransferenciasCentral(Comercio com, DateTime fechaDesde, DateTime fechaHasta, RecibosYTransferencias RytServidor)
        {
            if (RytServidor != null)
            {
                if (RytServidor.Rrm != null && RytServidor.Rrm.Count > 0)
                {
                    List<Recibo> lRec = Get<Recibo>(r=>r.EmpresaID == com.EmpresaID &&  r.ComercioID == com.ComercioID && r.Fecha >= fechaDesde && r.Fecha <= fechaHasta).ToList();
                    List<Recibo> lRecGrab = new List<Recibo>();
                    RytServidor.Rrm.ForEach(ryt => 
                        {
                            Recibo rec = lRec.FirstOrDefault(lrec => lrec.ReciboIDRemoto.Equals(ryt.ReciboID));
                            if (rec == null)
                            {
                                ryt.ReciboIDRemoto = ryt.ReciboID;
                                lRecGrab.Add(ryt);
                            }
                        }
                        );
                    AgregarRange<Recibo>(lRecGrab);
                }

                if (RytServidor.TdRm != null && RytServidor.TdRm.Count > 0)
                {
                    List<TransferenciasDepositos> lTd = Get<TransferenciasDepositos>(t => t.EmpresaID == com.EmpresaID && t.ComercioID == com.ComercioID && t.Fecha >= fechaDesde && t.Fecha <= fechaHasta).ToList();
                    List<TransferenciasDepositos> lTdGrab = new List<TransferenciasDepositos>();
                    RytServidor.TdRm.ForEach(ryt =>
                    {
                        TransferenciasDepositos tyd = lTd.FirstOrDefault(ltd => ltd.TransferenciasDepositosIDRemoto.Equals(ryt.TransferenciasDepositosID));
                        if (tyd == null)
                        {
                            ryt.TransferenciasDepositosIDRemoto = ryt.TransferenciasDepositosID;
                            lTdGrab.Add(ryt);
                        }
                    }
                        );
                    AgregarRange<TransferenciasDepositos>(lTdGrab);
                }
            }
            Grabar();
           
        }

        public async Task<List<string>> ActualizarDesdeCentral(Comercio Com,Usuario usu)
        {
            DateTime Desde = DateTime.Now;
            DateTime Hasta = DateTime.Now;
            List<String> Res = new List<string>();

            string Seteo = "";

            if (pGlob.Configuracion.bActHabilitada)
            {
                List<Comercio> comers = new List<Comercio>();
                if (pGlob.Configuracion.bPropio)
                {
                    comers.Add(Com);
                    Seteo += "Propio";
                }

                if (pGlob.Configuracion.bActComercios)
                {
                    comers.AddRange(Get<Comercio>(Com.EmpresaID, c => c.Actualiza.Value).ToList());
                    Seteo += " Comercios";
                    foreach (Comercio c in comers)
                    {
                        Seteo += "|" +c.ComercioID.ToString();
                    }
                }

                if (pGlob.Configuracion.bActEF)
                {
                    Desde = pGlob.Configuracion.ActDesde;
                    Hasta = pGlob.Configuracion.ActHasta;
                    Seteo += " Entre Fechas: " + Desde.ToShortDateString() + "-" + Hasta.ToShortDateString();
                }

                if (pGlob.Configuracion.bActDesde)
                {
                    Desde = pGlob.Configuracion.ActDesde;
                    Hasta = DateTime.Now;
                    Seteo += " Desde" + Desde.ToShortDateString();
                }
                Res = await ProcesarInfoActAuto(Com, comers, Desde, Hasta);
                
                Res.Insert(0, Seteo);
                Log(Com.EmpresaID,usu, Res,"Actualizaciones");               
            }
            else
            {
                Res.Add("Actualización Deshabilitada");
            }
            return Res;
        }

        /*Logs*/
        public void Log(int BaseIDb,Usuario usu, List<string> log,string Tipo)
        {
            Log Log = new Log();
            Log.Fecha = DateTime.Now;
            Log.Host = Environment.MachineName;
            Log.Usuario = usu.nombre;
            Log.Tipo = Tipo;
            foreach (string l in log )
            {
                Log.Mens = l;
                Agregar<Log>(BaseIDb,Log);
            }            
        }

        public void Log(int BaseIDb, Usuario usu, string log, string Tipo)
        {
            Log Log = new Log();
            Log.Fecha = DateTime.Now;
            Log.Host = Environment.MachineName;
            Log.Usuario = usu.nombre;
            Log.Mens = log;
            Log.Tipo = Tipo;
            Agregar<Log>(BaseIDb, Log);
        }

        public async Task<List<string>> ProcesarInfoActAuto(Comercio com,List<Comercio> comersBusca,  DateTime fechaDesde, DateTime fechaHasta)
        {
            List<string> log = new List<string>();

            //DateTime desde = fechaDesde;
            //DateTime hasta = fechaHasta;
            //Auxiliares.Utilidades.ExtremarFechas(ref desde,ref hasta);
            //int dias =(hasta-desde).Days;
            //for(int i=0; i <= dias;i++)
            //{
                foreach (Comercio comer in comersBusca)
                {
                    InfoActRestModel iarm = await GetInfoAct(com, comer, fechaDesde, fechaHasta);
                    if (iarm != null)
                    {
                        log.AddRange(ProcesarInfoAct(com.EmpresaID, iarm));
                    }    
                }
            //}
           
            return log;
        }


        public async Task<List<string>> ProcesarInfoAct(Comercio com, Comercio comerBusca, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<string> log  = new List<string>();
            InfoActRestModel iarm = await GetInfoAct(com, comerBusca, fechaDesde, fechaHasta);
            if (iarm != null)
            {
                log = ProcesarInfoAct(com.EmpresaID,iarm);
            }            
            return log;
        }

        public async Task<List<string>> ProcesarInfoAct(Comercio com, Comercio comerBusca,int CreditoID)
        {
            List<string> log = new List<string>();
            InfoActRestModel iarm = await GetInfoAct(com, comerBusca, CreditoID);
            if (iarm != null)
            {
                log = ProcesarInfoAct(com.EmpresaID, iarm);
            }
            return log;
        }

        public Comercio AgregarComercio(int EmpID,int ComercioID)
        {
            Comercio Comer = new Comercio();
            Comer.EmpresaID = EmpID;
            Comer.ComercioID = ComercioID;
            Comer.Nombre = "Agregado Por Sistema en Actualización de cobranzas y créditos";
            Comer.Descripcion = "Agregado Por Sistema en Actualización de cobranzas y créditos";
            Comer.Principal = false;
            Agregar<Comercio>(Comer);
            return Comer;
        }

        public List<string> ProcesarInfoAct(int BaseIDb,InfoActRestModel iarm)
         {
            List<string> log = new List<string>();
            log.Add("Procesando información de Actualización");
            

            Cliente cliEsta;
            Credito creEsta;
            CreditoAnulado creAnulEsta;
            Cuota cuoEsta;
            Cobranza cobEsta;
            Comercio estaComer;
            Usuario usu;
            Refinanciacion RefiEsta;
            RefinanciacionCuota RefiCuoEsta;
            RefinanciacionCobranza RefiCobEsta;

            try
            {            
            List<Cliente> clientes = AutoMapper.Mapper.Map<List<ClienteRestModel>,List<Cliente>>(iarm.Clientes);
            log.Add("Clientes:" + clientes.Count());
            foreach (Cliente cli in clientes)
            {
                
                cliEsta = Get<Cliente>(c => c.TipoDocumentoID == cli.TipoDocumentoID && c.Documento == cli.Documento).FirstOrDefault();
                if (cliEsta != null)
                   {
                       Desacoplar<Cliente>(BaseIDb, cliEsta);
                       cli.Domicilios = null;
                       cli.Telefonos = null;
                       cli.Mails = null;
                       cli.Notas = null;
                       Actualizar<Cliente>(BaseIDb, cli);
                       log.Add(String.Format("El Cliente:{0}-{1} Ya se encontraba en la Base", cli.Documento, cli.NombreCompleto));
                   }
                else
                    {
                        usu = Get<Usuario>(c => c.UsuarioID == cli.UsuarioModificacionID.Value).FirstOrDefault();
                        if (usu == null)
                        {
                            log.Add(String.Format("Usuario:{0} no encontrado, se utilizará el usuario sistema", cli.UsuarioModificacionID));
                            cli.UsuarioModificacionID = 1;
                        }
                        Agregar<Cliente>(BaseIDb, cli);
                        log.Add(String.Format("Cliente:{0}-{1} Agregado", cli.Documento, cli.NombreCompleto));
                    }
            }           
            
            List<Credito> Creditos = AutoMapper.Mapper.Map<List<CreditoRestModel>, List<Credito>>(iarm.Creditos);
            log.Add("Créditos:"+ Creditos.Count());
            foreach (Credito cre in Creditos)
            {
                creEsta = Get<Credito>(c =>  c.EmpresaID == cre.EmpresaID && c.ComercioID == cre.ComercioID && c.CreditoID == cre.CreditoID ).FirstOrDefault();
                if (creEsta != null)
                {
                    log.Add(String.Format("El Credito:{0}-{1} Ya se encuentra en la Base", cre.ComercioID, cre.CreditoID));
                }
                else
                {
                    usu = Get<Usuario>(c => c.UsuarioID == cre.UsuarioID).FirstOrDefault();
                    if (usu == null)
                    {
                        log.Add(String.Format("Usuario:{0} no encontrado, se utilizará el usuario sistema", cre.UsuarioID));
                        cre.UsuarioID = 1;
                    }
                    if (cre.usuarioAvalID != null)
                        {
                            usu = Get<Usuario>(c => c.UsuarioID == cre.usuarioAvalID).FirstOrDefault();
                            if (usu == null)
                            {
                                log.Add(String.Format("UsuarioAval:{0} no encontrado, se utilizará el usuario sistema", cre.usuarioAvalID));
                                cre.usuarioAvalID = 1;
                            }
                        }
                    Agregar<Credito>(BaseIDb,cre);
                    log.Add(String.Format("Credito:{0}-{1} Agregado", cre.ComercioID, cre.CreditoID));
                }
                
                foreach (Cuota cuo in cre.Cuotas)
                {
                    cuoEsta = Get<Cuota>(c => c.EmpresaID == cuo.EmpresaID && c.ComercioID == cuo.ComercioID && c.CreditoID == cuo.CreditoID && c.CuotaID == cuo.CuotaID).FirstOrDefault();
                    if (cuoEsta != null)
                    {
                        log.Add(String.Format("La cuota Credito:{0}-{1} Ya se encuentra en la Base", cuo.CreditoID, cuo.CuotaID));
                    }
                    else
                    {
                        Agregar<Cuota>(BaseIDb, cuo);
                        log.Add(String.Format("Cuota:{0}-{1} Agregada", cuo.CreditoID, cuo.CuotaID));
                    }  
                }
            }
            
            log.Add("Empresa|Comercio|Crédito");
            foreach (Credito cre in Creditos)
            {
                log.Add(String.Format("Crédito:{0}-{1}-{2} Agregado {3} Cuotas:{4}",cre.EmpresaID,cre.ComercioID, cre.CreditoID, Environment.NewLine,cre.CantidadCuotas));
            }

            log.Add("Créditos Anulados:");
            List<CreditoAnulado> CreditosAnulados = AutoMapper.Mapper.Map<List<CreditoAnuladoRestModel>, List<CreditoAnulado>>(iarm.CreditosAnulados);
            log.Add("Créditos Anulados:" + CreditosAnulados.Count());
            foreach (CreditoAnulado cre in CreditosAnulados)
            {
                creAnulEsta = Get<CreditoAnulado>(c => c.EmpresaID == cre.EmpresaID && c.ComercioID == cre.ComercioID && c.CreditoID == cre.CreditoID && c.CreditoAnuladoID == cre.CreditoAnuladoID).FirstOrDefault();
                if (creAnulEsta != null)
                {
                    log.Add(String.Format("El Credito Anulado:{0}-{1} Ya se encuentra en la Base", cre.ComercioID, cre.CreditoID));
                }
                else
                {
                        usu = Get<Usuario>(c => c.UsuarioID == cre.UsuarioID).FirstOrDefault();
                        if (usu == null)
                        {
                            log.Add(String.Format("Usuario:{0} no encontrado, se utilizará el usuario sistema", cre.UsuarioID));
                            cre.UsuarioID = 1;
                        }
                        if (cre.usuarioAvalID != null)
                        {
                            usu = Get<Usuario>(c => c.UsuarioID == cre.usuarioAvalID).FirstOrDefault();
                            if (usu == null)
                            {
                                log.Add(String.Format("UsuarioAval:{0} no encontrado, se utilizará el usuario sistema", cre.usuarioAvalID));
                                cre.usuarioAvalID = 1;
                            }
                        }
                        Agregar<CreditoAnulado>(BaseIDb, cre);
                        log.Add(String.Format("Credito Anulado:{0}-{1} Agregado", cre.ComercioID, cre.CreditoID));
                }
            }
            
            
            log.Add("Empresa|Comercio|Crédito|Cuota|Cobranza|Empresa Géstión|Gestión");
            List<Cobranza> Cobranzas = AutoMapper.Mapper.Map<List<CobranzaRestModel>, List<Cobranza>>(iarm.Cobranzas);
            log.Add("Cobranzas:"+ Cobranzas.Count());
            Cobranzas = Cobranzas.OrderBy(c => c.EmpresaID).ThenBy(c => c.ComercioID).ThenBy(c => c.CreditoID).ThenBy(c => c.CuotaID).ThenBy(c => c.FechaPago).ToList();
            foreach (Cobranza cob in Cobranzas)
            {
                log.Add(String.Format("{0}-{1}-{2}-{3}-{4}-{5}",cob.EmpresaID,cob.ComercioID,cob.CreditoID,cob.CuotaID,cob.CobranzaID,cob.GestionID));
                cobEsta = Get<Cobranza>(cob.EmpresaID,c=>c.EmpresaID == cob.EmpresaID && c.ComercioID == cob.ComercioID && c.CreditoID == cob.CreditoID
                                        && c.CuotaID == cob.CuotaID && c.CobranzaID == cob.CobranzaID 
                                        && c.GestionEmpresaID == cob.GestionEmpresaID && c.GestionID == cob.GestionID).FirstOrDefault();
                
                if (cobEsta == null)
                {
                    Cuota cuota = Get<Cuota>(cob.EmpresaID, c => c.EmpresaID == cob.EmpresaID && c.ComercioID == cob.ComercioID && c.CreditoID == cob.CreditoID
                                        && c.CuotaID == cob.CuotaID).FirstOrDefault();
                    if (cuota != null)
                    {
                        if (cuota.ImportePago + cob.ImportePago > cuota.Importe )
                        {
                            log.Add(String.Format("Error: Se supera el importe correspondiente a la cuota, no se agregará la cobranza: {0}",cob.CobranzaID));
                        }
                        else
                        {
                            cuota.ImportePago += cob.ImportePago;
                            cuota.ImportePagoPunitorios += cob.ImportePagoPunitorios;
                            cuota.FechaUltimoPago = cob.FechaPago;
                            Actualizar<Cuota>(cuota);

                            estaComer = Get<Comercio>(cob.EmpresaID, c => c.ComercioID == cob.ComercioID).FirstOrDefault();
                            if (estaComer == null)
                            {
                                AgregarComercio(cob.EmpresaID, cob.ComercioID);
                            }
                                usu = Get<Usuario>(c => c.UsuarioID == cob.UsuarioID).FirstOrDefault();
                                if (usu == null)
                                {
                                    log.Add(String.Format("Usuario:{0} no encontrado, se utilizará el usuario sistema", cob.UsuarioID));
                                    cob.UsuarioID = 1;
                                }
                                //cob.UsuarioID = 1; //Acá se podría actualizar el usuario o cargar los que no están de alguna forma. Sino dejamos a sistemas y listo
                            Agregar<Cobranza>(cob);
                        }

                        List<Cuota> cuotasAnteriores = cuota.Credito.Cuotas.ToList();
                        cuotasAnteriores = cuotasAnteriores.Where(c=>c.Deuda > 0 &&  c.CuotaID < cuota.CuotaID).ToList();
                        if (cuotasAnteriores != null && cuotasAnteriores.Count > 0)
                            {
                                 log.Add(String.Format("El crédito:{0}-{1}-{2} no registra las cuotas anteriores pagas",cuota.ComercioID,cuota.CreditoID,cuota.CuotaID) );
                                 //Generar una solicitud para actualizar cuotas anteriores, o sino simplemente asegurarme al momento de realizar la primer actualizacion que todo este correctament actualizado,
                                 // o realizar este mismo procedimiento para una fecha anterior.
                            }
                    }
                    else
                    {
                            log.Add("Error: No se encuentra la cuota correspondiente a la cobranza");
                    }

                }
                else
                 {
                    log.Add("Ya se encontraba la cobranza");
                 }
           }


            

             List<NotasCD> NotasCD = AutoMapper.Mapper.Map<List<NotasCDRestModel>, List<NotasCD>>(iarm.NotasCD);
            log.Add("Notas de Crédito:" + NotasCD.Count());
            log.Add("Empresa|Comercio|Crédito|Cuota|Cobranza|Nota de crédito");
            Cobranza cobra;
            foreach (NotasCD nota in NotasCD)
            {
                log.Add(String.Format("{0}-{1}-{2}-{3}-{4}-{5}", nota.EmpresaID, nota.ComercioID, nota.CreditoID, nota.CuotaID, nota.CobranzaID, nota.NotaCDID));
                NotasCD notaEsta = Get<NotasCD>(nota.EmpresaID, c => c.EmpresaID == nota.EmpresaID && c.ComercioID == nota.ComercioID && c.CreditoID == nota.CreditoID
                                        && c.CuotaID == nota.CuotaID && c.CobranzaID == nota.CobranzaID && c.NotaCDID == nota.NotaCDID).FirstOrDefault();

                if (notaEsta == null)
                {
                    cobra = Get<Cobranza>(nota.EmpresaID, c => c.EmpresaID == nota.EmpresaID && c.ComercioID == nota.ComercioID && c.CreditoID == nota.CreditoID
                                        && c.CuotaID == nota.CuotaID && c.CobranzaID == nota.CobranzaID).FirstOrDefault();
                    if (cobra != null)
                    {
                        usu = Get<Usuario>(c => c.UsuarioID == nota.UsuarioID).FirstOrDefault();
                        if (usu == null)
                        {
                            log.Add(String.Format("Usuario:{0} no encontrado, se utilizará el usuario sistema", nota.UsuarioID));
                                nota.UsuarioID = 1;
                        }
                        Agregar<NotasCD>(nota);
                        log.Add("Se ha agregado la NotaCD");
                    }
                    else
                    {
                        log.Add("Error: No se encuentra la Cobranza correspondiente a la NotaCD");
                    }

                }
                {
                    log.Add("Ya se encontraba la cobranza");
                }
            }
            

            
            List<Refinanciacion> Refis = AutoMapper.Mapper.Map<List<RefinanciacionRestModel>, List<Refinanciacion>>(iarm.Refinanciaciones);
            log.Add("Refinanciaciones:" + Refis.Count());
            foreach (Refinanciacion refi in Refis)
            {
                RefiEsta = Get<Refinanciacion>(c => c.EmpresaID == refi.EmpresaID && c.ComercioID == refi.ComercioID && c.CreditoID == refi.CreditoID
                                                && c.RefinanciacionID == refi.RefinanciacionID).FirstOrDefault();
                if (RefiEsta != null)
                {
                    log.Add(String.Format("La Refinanciacion:{0}-{1} Ya se encuentra en la Base", refi.ComercioID, refi.RefinanciacionID));
                }
                else
                {                    
                    creEsta = Get<Credito>(refi.EmpresaID, c => c.EmpresaID == refi.EmpresaID && c.ComercioID == refi.ComercioID && c.CreditoID == refi.CreditoID).FirstOrDefault();
                    if (creEsta != null)
                    {
                        usu = Get<Usuario>(c => c.UsuarioID == refi.UsuarioID).FirstOrDefault();
                        if (usu == null)
                        {
                            log.Add(String.Format("Usuario:{0} no encontrado, se utilizará el usuario sistema", refi.UsuarioID));
                            refi.UsuarioID = 1;
                        }
                        Agregar<Refinanciacion>(BaseIDb, refi);
                        log.Add(String.Format("Refinanciacion:{0}-{1} Agregado", refi.ComercioID, refi.RefinanciacionID));
                        creEsta.RefinanciacionID = refi.RefinanciacionID;
                        Actualizar<Credito>(creEsta.CreditoID,creEsta);

                        foreach (RefinanciacionCuota reficuo in refi.RefinanciacionCuotas)
                        {
                            RefiCuoEsta = Get<RefinanciacionCuota>(c => c.EmpresaID == reficuo.EmpresaID && c.ComercioID == reficuo.ComercioID && c.CreditoID == reficuo.CreditoID
                                                                   && c.RefinanciacionID == reficuo.RefinanciacionID && c.RefinanciacionCuotaID == reficuo.RefinanciacionCuotaID).FirstOrDefault();
                            if (RefiCuoEsta != null)
                            {
                                log.Add(String.Format("La Cuota Refinanciación:{0}-{1} Ya se encuentra en la Base", reficuo.RefinanciacionID, reficuo.RefinanciacionCuotaID));
                            }
                            else
                            {
                                Agregar<RefinanciacionCuota>(BaseIDb, reficuo);
                                log.Add(String.Format("Cuota:{0}-{1} Agregada", reficuo.RefinanciacionID, reficuo.RefinanciacionCuotaID));
                            }
                        }                    
                    }
                    else
                    {
                        log.Add(String.Format("No se ha encontrado el crédito:{0} correspondiente a la refinanciación {1}", refi.CreditoID, refi.RefinanciacionID));
                    }
                }
            }

           log.Add("Empresa|Comercio|Refinanciación|Crédito");
           foreach (Refinanciacion cre in Refis)
            {
                log.Add(String.Format("Refinanciación:{0}-{1}-{2}-{3} Agregado {3} Cuotas:{4}", cre.EmpresaID, cre.ComercioID, cre.RefinanciacionID, cre.CreditoID, Environment.NewLine, cre.CantidadCuotas));
            }

       
            List<Refinanciacion> RefinanciacionesAnuladas = AutoMapper.Mapper.Map<List<RefinanciacionRestModel>, List<Refinanciacion>>(iarm.RefinanciacionesAnuladas);
            log.Add("Refinanciaciones Anulados:" + RefinanciacionesAnuladas.Count());
            log.Add("Empresa|Comercio|Refinanciación|Crédito");
            Refinanciacion refiEsta;
            foreach (Refinanciacion refi in RefinanciacionesAnuladas)
            {
                log.Add(String.Format("{0}-{1}-{2}-{3}", refi.EmpresaID, refi.ComercioID, refi.RefinanciacionID, refi.CreditoID));
                refiEsta = Get<Refinanciacion>(refi.EmpresaID, c => c.EmpresaID == refi.EmpresaID && c.ComercioID == refi.ComercioID && c.CreditoID == refi.CreditoID
                                        && c.RefinanciacionID == refi.RefinanciacionID).FirstOrDefault();
                
                if (refiEsta != null)
                {
                    Actualizar<Refinanciacion>(refi);
                    log.Add("Se ha actualizado la refinancación anulada");
                }
                else
                {
                    log.Add("Error: No se encuentra la Refinancación correspondiente");
                }
            }

            List<RefinanciacionCobranza> RefiCobranzas = AutoMapper.Mapper.Map<List<RefinanciacionCobranzaRestModel>, List<RefinanciacionCobranza>>(iarm.RefinanciacionesCobranzas);

            log.Add("Refinanciación Cobranzas:" + RefiCobranzas.Count());
            log.Add("Empresa|Comercio|Refinanciación|Crédito|Cuota|Cobranza|Empresa Géstión|Gestión");
            RefinanciacionCobranza reficobEsta;
            RefinanciacionCuota reficuota;
            foreach (RefinanciacionCobranza cob in RefiCobranzas)
            {
                log.Add(String.Format("{0}-{1}-{2}-{3}-{4}-{5}", cob.EmpresaID, cob.ComercioID, cob.RefinanciacionID,cob.CreditoID, cob.RefinanciacionCuotaID, cob.RefinanciacionCobranzaID));
                reficobEsta = Get<RefinanciacionCobranza>(cob.EmpresaID, c => c.EmpresaID == cob.EmpresaID && c.ComercioID == cob.ComercioID && c.CreditoID == cob.CreditoID
                                        && c.RefinanciacionCuotaID == cob.RefinanciacionCuotaID && c.RefinanciacionCobranzaID == cob.RefinanciacionCobranzaID && c.GestionID == cob.GestionID).FirstOrDefault();

                if (reficobEsta == null)
                {
                    reficuota = Get<RefinanciacionCuota>(cob.EmpresaID, c => c.EmpresaID == cob.EmpresaID && c.ComercioID == cob.ComercioID && c.CreditoID == cob.CreditoID
                                        && c.RefinanciacionID == cob.RefinanciacionID && c.RefinanciacionCuotaID == cob.RefinanciacionCuotaID).FirstOrDefault();
                    if (reficuota != null)
                    {
                        if (reficuota.ImportePago + cob.ImportePago > reficuota.Importe)
                        {
                            log.Add("Error: Se supera el importe correspondiente a la Refi cuota");
                        }
                        else
                        {
                            reficuota.ImportePago += cob.ImportePago;
                            reficuota.ImportePagoPunitorios += cob.ImportePagoPunitorios;
                            reficuota.FechaUltimoPago = cob.FechaPago;
                            Actualizar<RefinanciacionCuota>(reficuota);
                            Agregar<RefinanciacionCobranza>(cob);
                        }

                        List<RefinanciacionCuota> reficuotasAnteriores = reficuota.Refinanciacion.RefinanciacionCuotas.ToList();
                        reficuotasAnteriores = reficuotasAnteriores.Where(c => c.Deuda > 0 && c.RefinanciacionCuotaID < reficuota.RefinanciacionCuotaID).ToList();
                        if (reficuotasAnteriores != null && reficuotasAnteriores.Count > 0)
                        {
                            log.Add(String.Format("La Refinanciación:{0}-{1}-{2} No registra cuotas anteriores pagas", reficuota.ComercioID, reficuota.RefinanciacionID, reficuota.RefinanciacionCuotaID));
                        }

                    }
                    else
                    {
                        log.Add("Error: No se encuentra la Refi cuota correspondiente a la Refi cobranza");
                    }

                }
                {
                    log.Add("Ya se encontraba la Refi cobranza");
                }
            }
            }
            catch (Exception ex)
            {
                throw new Exceptions.ErrorException("Error al actualizar un registro",ex);
            }
            return log;


        }


        public async Task<InfoActRestModel> GetInfoAct(Comercio com,Comercio comerBusca, DateTime fechaDesde, DateTime fechaHasta)
        {
            InfoActRestModel iarm = new InfoActRestModel();
            DateTime desde = fechaDesde;
            DateTime hasta = fechaHasta;
            Auxiliares.Utilidades.ExtremarFechas(ref desde,ref hasta);
            iarm.Desde = desde;
            iarm.Hasta = hasta;
            iarm.ComercioBusqueda = comerBusca.ComercioID;
            iarm.ComercioBusquedaEmpId = comerBusca.EmpresaID;
            iarm.CreditoID = 0;
            iarm = await ra.Get<InfoActRestModel>(iarm, com,pGlob.UriInfoAct);
            return iarm;
        }

        public async Task<InfoActRestModel> GetInfoAct(Comercio com, Comercio comerBusca, int CreditoID)
        {
            InfoActRestModel iarm = new InfoActRestModel();
            iarm.ComercioBusqueda = comerBusca.ComercioID;
            iarm.ComercioBusquedaEmpId = comerBusca.EmpresaID;
            iarm.CreditoID = CreditoID;
            iarm = await ra.Get<InfoActRestModel>(iarm, com, pGlob.UriInfoAct);
            return iarm;
        }


       


        public async Task<SolicitarFondos> SolicitarFondos(Comercio com, DateTime fechaDesde, DateTime fechaHasta, Estado est)
        {
            SolicitarFondos sfvm = await ra.GetSolicitarFondosAsync(com, fechaDesde, fechaHasta, est);
            return sfvm;
        }

        public bool isSolicitudFondosConfirmadaEnReceptoria(SolicitudFondo sf)
        {
            string solfonID = sf.SolicitudFondoID.ToString();
          
            List<Transmision> trans = GetTransmisiones(sf.EmpresaID.Value,t => t.OperacionID == pGlob.TransConfirmarSolicitudDeFondo.OperacionID
                                      && t.EntidadID == solfonID && t.EmpresaID == sf.EmpresaID && t.ComercioID == sf.ComercioID).ToList();
            if (trans.Count > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<SolicitudFondo> GetSolicitudesDeFondosCap(Expression<Func<SolicitudFondo, bool>> filter = null,
                               Func<IQueryable<SolicitudFondo>, IOrderedQueryable<SolicitudFondo>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetSolicitudesDeFondos(filter, orderBy, includeProperties).Where(s => s.TipoSolicitudID == pGlob.tsCap.TipoSolicitudID).ToList(); 
        }

        /* Cuenta Bancaria Cliente */

        public void EliminarCuentaBancariaCliente(Empresa emp,CuentaBancariaCliente cbc)
        {
            cbc.EstadoID = pGlob.Eliminado.EstadoID;
            ActualizarTransaccional<CuentaBancariaCliente>(cbc);
            Grabar(emp.EmpresaID.Value);

            Transmision<Cliente>(cbc.Cliente, pGlob.Comercio, pGlob.TransAgregarCliente, pGlob.UriClientes);
            Grabar();
            
        }
      
        /* CAP */

        public void GrabarCap(Comercio Com,Cap Cap,bool Actualiza)
        {
            AgregarTransaccional<Cap>(Com.EmpresaID, Cap);
            AgregarTransaccional<SolicitudFondo>(Com.EmpresaID, Cap.SolicitudFondo);
            Grabar(Com.EmpresaID);
            //Transmision<Cap>(Cap, Com, pGlob.TransActualizarSolicitudFondos, pGlob.UriSolicitarFondos);
            //AgregarTransmisionSolicitudDeFondo(ff.SolicitudFondo);    
            List<Transmision> lTrans = new List<Transmision>();
            lTrans = Transmision(lTrans, Cap, Com, pGlob.TransAltaCap, pGlob.UriCap);
            lTrans = Transmision<SolicitudFondo>(lTrans, Cap.SolicitudFondo, Com, pGlob.TransEnviarSolicitudDeFondo, pGlob.UriCap);
            GrabarTransmisiones(Com.EmpresaID, lTrans);
            
        }

        public void EliminarCap(Comercio Com, Cap Cap)
        {
            Cap.EstadoID = pGlob.Eliminado.EstadoID;
            Cap.SolicitudFondo.EstadoID = pGlob.SolicitudFondoAnulada.EstadoID;
            ActualizarTransaccional<Cap>(Cap);
            ActualizarTransaccional<SolicitudFondo>(Cap.SolicitudFondo);
            
            Grabar(Com.EmpresaID);
            
            List<Transmision> lTrans = new List<Transmision>();
            lTrans = Transmision(lTrans,Cap, Com, pGlob.TransBajaCap, pGlob.UriCap);
            lTrans = Transmision<SolicitudFondo>(lTrans, Cap.SolicitudFondo, Com, pGlob.TransActualizarSolicitudFondos, pGlob.UriFF);
            GrabarTransmisiones(Com.EmpresaID, lTrans);
        }

        public Pago CapDetalleAPago(CapDetalle CapDetalle)
        {
            Pago pago = new Pago(CapDetalle.EmpresaID, CapDetalle.ComercioID, CapDetalle.Cap.SolicitudFondoID, CapDetalle.CapID, CapDetalle.CapDetalleID,
                                 null, null, DateTime.Now, CapDetalle.Importe,pGlob.Vigente.EstadoID);
            return pago;
        }

        /* FF */
        public void GrabarFF(Comercio Com, FF ff)
        {
            AgregarTransaccional<FF>(Com.EmpresaID, ff);
            AgregarTransaccional<SolicitudFondo>(Com.EmpresaID, ff.SolicitudFondo);
            //CuentaCorriente cc = ImputacionCuentaCorrienteFF(ff);
            //Falta Agregar el envio de FF
            Grabar(Com.EmpresaID);
            
            //AgregarTransmisionSolicitudDeFondo(ff.SolicitudFondo);    
            List<Transmision> lTrans = new List<Transmision>();
            lTrans = Transmision(lTrans,ff, Com, pGlob.TransAltaFF, pGlob.UriFF);
            lTrans = Transmision<SolicitudFondo>(lTrans, ff.SolicitudFondo, Com, pGlob.TransEnviarSolicitudDeFondo, pGlob.UriFF);
            //lTrans = Transmision<CuentaCorriente>(lTrans, cc, Com, pGlob.TransImputacionCC, pGlob.UriFF);
            GrabarTransmisiones(Com.EmpresaID, lTrans);            
        }

        public void EliminarFF(Comercio Com, FF ff)
        {
            ff.EstadoID = pGlob.Eliminado.EstadoID;
            ff.SolicitudFondo.EstadoID = pGlob.SolicitudFondoAnulada.EstadoID;
            //BorrarTransaccional<SolicitudFondo>(ff.SolicitudFondo);
            //BorrarTransaccional<FF>(ff);
            ActualizarTransaccional<FF>(ff);
            ActualizarTransaccional<SolicitudFondo>(ff.SolicitudFondo);
            //CuentaCorriente cc = ImputacionAnulacionCuentaCorrienteFF(ff);
            Grabar(Com.EmpresaID);

            List<Transmision> lTrans = new List<Transmision>();
            lTrans = Transmision(lTrans,ff, Com, pGlob.TransBajaFF, pGlob.UriFF);
           // lTrans = Transmision<CuentaCorriente>(lTrans, cc, Com, pGlob.TransImputacionCC, pGlob.UriFF);
            GrabarTransmisiones(Com.EmpresaID, lTrans);
        }
      
        public DateTime? ObtenerUltimaFechaDeFF(Comercio com)
        {
            FF ff = Get<FF>(com.EmpresaID, f => f.EmpresaID == com.EmpresaID && f.ComercioID == com.ComercioID, o => o.OrderByDescending(x => x.Fecha),"", 1).FirstOrDefault()  ;
            if (ff != null)
                return ff.Fecha;
            return null;
        }
        
        public List<FFDetalle> ObtenerFFDetallesDesdeUltimaFechaFF(Comercio Com)
        {
            List<FFDetalle> FFDetalles = null;
            List<Gasto> gastos = ObtenerGastosDesdeUltimaFechaFF(Com);
            if (gastos != null)
            {
              FFDetalles =  gastos.Select(x => new FFDetalle
                {
                    EmpresaID = x.EmpresaID,
                    ComercioID = x.ComercioID,
                    Fecha = x.Fecha,
                    Importe = x.Importe,
                    Detalle = x.Descripcion,
                    ImportePago = x.Importe
                }).ToList();
            }
            return FFDetalles;
        }


        public List<Gasto> ObtenerGastosDesdeUltimaFechaFF(Comercio Com)
        {
            List<Gasto> gastos = null;
            DateTime? UltiFecha = ObtenerUltimaFechaDeFF(Com);
            
            if (UltiFecha != null)
            {
                UltiFecha = UltiFecha.Value.Date;
                gastos = Get<Gasto>(Com.EmpresaID, g => g.EmpresaID == Com.EmpresaID && g.ComercioID == Com.ComercioID 
                                    && g.Fecha > UltiFecha && g.EstadoID == pGlob.Vigente.EstadoID).ToList();
            }
            else
            {
                gastos = Get<Gasto>(Com.EmpresaID, g => g.EmpresaID == Com.EmpresaID && g.ComercioID == Com.ComercioID
                                    && g.EstadoID == pGlob.Vigente.EstadoID).ToList();
            }
            return gastos;
        }

        /* Pagos */

        public Pago GrabarPago(Comercio Com, CapDetalle CapDetalle, decimal Importe, DateTime FechaPago, Delegados.DelegadoDecimal Graba_Pago)
        {
            Pago pago = null;
            if (Importe > CapDetalle.PendientePago)
            {
                MessageBox.Show("No se puede ingresar un importe mayor al importe del detalle pendiente");
            }
            else
            {
                pago = new Pago(CapDetalle.EmpresaID, CapDetalle.ComercioID, CapDetalle.Cap.SolicitudFondoID,
                                CapDetalle.Cap.CapID, CapDetalle.CapDetalleID, null, null, FechaPago, Importe,pGlob.Vigente.EstadoID);

                AgregarTransaccional<Pago>(pago);
                CuentaCorriente cc = ImputacionCuentaCorrientePago(pago, CapDetalle.Cap);
                Graba_Pago(Importe);
                //CapDetalle.Finalizado = objForm.chkFinalizado
                Grabar(CapDetalle.EmpresaID);

                List<Transmision> lTrans = new List<Transmision>();
                lTrans = Transmision(lTrans, pago, Com, pGlob.TransAltaPago, pGlob.UriPago);
                lTrans = Transmision<CuentaCorriente>(lTrans, cc, Com, pGlob.TransImputacionCC, pGlob.UriPago);
                GrabarTransmisiones(Com.EmpresaID, lTrans);


            };
            return pago;
        }

        public void EliminarPago(Comercio Com, Pago Pago)
        {
            CuentaCorriente cc = null;
            Pago.EstadoID = pGlob.Eliminado.EstadoID;
            //Pago.SolicitudFondo.EstadoID = pGlob.SolicitudFondoAnulada.EstadoID;
            ActualizarTransaccional<Pago>(Pago);
            //ActualizarTransaccional<SolicitudFondo>(Pago.SolicitudFondo);

          
            if (Pago.CapDetalle != null && Pago.CapDetalle.Cap != null)
            {
                Pago.CapDetalle.Cap.Finalizado = false;
                Pago.CapDetalle.Cap.Pagado -= Pago.Importe;

                Pago.CapDetalle.Finalizado = false;
                Pago.CapDetalle.ImportePago -= Pago.Importe;

                cc = ImputacionAnulacionCuentaCorrientePago(Pago, Pago.CapDetalle.Cap);
            }

            if (Pago.FFDetalle != null && Pago.FFDetalle.FF != null)
            {
                Pago.FFDetalle.FF.Pagado = false;
                Pago.FFDetalle.ImportePago -= Pago.Importe;
                cc = ImputacionAnulacionCuentaCorrientePago(Pago, Pago.FFDetalle.FF);
            }

            Grabar(Com.EmpresaID);

            List<Transmision> lTrans = new List<Transmision>();
            lTrans = Transmision(lTrans, Pago, Com, pGlob.TransBajaPago, pGlob.UriPago);
            lTrans = Transmision<CuentaCorriente>(lTrans, cc, Com, pGlob.TransImputacionCC, pGlob.UriPago);
           // lTrans = Transmision<CuentaCorriente>(lTrans, cc, Com, pGlob.TransImputacionCC, pGlob.UriPago);
            GrabarTransmisiones(Com.EmpresaID, lTrans);
        }

        /* Recibos */
         
        public Recibo GrabarRecibo(Comercio com, int? Comprobante, decimal? Importe, DateTime Fecha, string notas,SolicitudFondo Solfon,Estado SolfonEst,
                                Estado est, Usuario usu, bool generaTransDep,CuentaBancaria origen, CuentaBancaria destino, Cheque cheque,
                                TipoMovimiento tm,int? comAdhEmpID,int? comAdhID,int? CreditoID,int? CuotaID, int? CobranzaID)
        {
            TransferenciasDepositos transDep = null;
            CuentaCorriente cc = null;

            Recibo rec = new Recibo();
            rec.EmpresaID = com.EmpresaID;
            rec.ComercioID = com.ComercioID;

            rec.CreditoID = CreditoID;
            rec.CuotaID = CuotaID;
            rec.CobranzaID = CobranzaID;
            
            if (Comprobante != null)
                rec.Comprobante = Comprobante.Value;
            if (Importe != null)
                rec.Importe = Importe.Value;
            rec.Fecha = Fecha;
           
            rec.Notas = notas;
            if (Solfon != null)
            {
                rec.SolicitudFondoID = Solfon.SolicitudFondoID;
                if (SolfonEst != null)
                    Solfon.EstadoID = SolfonEst.EstadoID;
                Actualizar<SolicitudFondo>(Solfon);
            }
            rec.FechaIngreso = DateTime.Now;
            rec.UsuarioID = usu.UsuarioID;
            rec.Host = System.Environment.MachineName;
            rec.EstadoID = est.EstadoID;
            if (generaTransDep)
            {
                transDep = GrabarTransferenciaDeposito(rec, origen, destino, cheque);
                rec.TransferenciasDepositosEmpId = transDep.EmpresaID;
                rec.TransferenciasDepositos = transDep;
            }

            rec.ComercioAdheridoEmpresaID = comAdhEmpID;
            rec.ComercioAdheridoComercioID = comAdhID;

            if (tm != null)
            {
                rec.TipoMovimientoID = tm.TipoMovimientoID;
                cc = ImputarCuentaCorriente(com,rec, transDep, tm, rec.Importe);
                //Agregar imputacion de transferencia y recibo a cuenta corriente. 
                //y en Ifinan agregar campos de cuentacorriente para recibo y transferencia.
            }

                        

            AgregarTransaccional<Recibo>(rec.EmpresaID, rec);
            if (cheque != null)
            {
                cheque.EstadoID = pGlob.ChequeUtilizado.EstadoID;
                ActualizarTransaccional<Cheque>(cheque.EmpresaID.Value, cheque);
            }
            Grabar(rec.EmpresaID);

            List<Transmision> ltrans = new List<Transmision>();
            ltrans = Transmision<Recibo>(ltrans, rec, com, pGlob.TransAltaRecibo, pGlob.UriRecibos);
            ltrans = Transmision<CuentaCorriente>(ltrans, cc, com, pGlob.TransImputacionCC, pGlob.UriRecibos);
            if (transDep != null)
                ltrans = Transmision<TransferenciasDepositos>(ltrans, transDep, com, pGlob.TransAltaTransDep, pGlob.UriRecibos);
            GrabarTransmisiones(rec.EmpresaID, ltrans);
            return rec;
        }


        public TransferenciasDepositos GrabarTransferenciaDeposito(Recibo rec, CuentaBancaria origen, CuentaBancaria destino, Cheque cheq)
        {
            TransferenciasDepositos transDep = new TransferenciasDepositos();
            transDep.ComercioID = rec.ComercioID;
            transDep.ComercioEmpresaID = rec.EmpresaID;
            transDep.EmpresaID = rec.EmpresaID;
            transDep.Fecha = rec.Fecha;
            transDep.Importe = rec.Importe;
            transDep.MonedaID = pGlob.Peso.MonedaID;
            transDep.Notas = rec.Notas;
            transDep.NumTransferencia = rec.Comprobante.ToString();
            transDep.UsuarioID = rec.UsuarioID;
            transDep.Host = System.Environment.MachineName;
            transDep.MedioDePagoID = pGlob.TransferenciaBancaria.MedioDePagoID;
            transDep.TipoTransferenciaDepositoID = pGlob.ttdComercio.TipoTransferenciaDepositoID;
            transDep.EstadoID = pGlob.Pendiente.EstadoID;
            if (origen != null)
            {
                transDep.CuentaOrigenCbID = origen.CuentaBancariaID;
                transDep.CuentaOrigenEmpresaID = origen.EmpresaID;
            }
            if (destino != null)
            {
                transDep.CuentaDestinoCbID = destino.CuentaBancariaID;
                transDep.CuentaDestinoEmpresaID = destino.EmpresaID;
            }
            if (cheq != null)
            {
                //transDep.cheque = cheq;
                transDep.ChequeEmpID = cheq.EmpresaID;
                transDep.ChequeCbID = cheq.CuentaBancariaID;
                transDep.ChequeNumChequera = cheq.ChequeraID;
                transDep.ChequeNumCheque = cheq.ChequeID;
                transDep.MedioDePagoID = pGlob.Cheque.MedioDePagoID;
            }
            AgregarTransaccional<TransferenciasDepositos>(transDep.EmpresaID, transDep);
            return transDep;
        }


        /* Empresas */
        public IEnumerable<Empresa> GetEmpresas(Expression<Func<Empresa, bool>> filter = null,
                               Func<IQueryable<Empresa>, IOrderedQueryable<Empresa>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetEmpresas(filter, orderBy, includeProperties);
        }

        public Empresa GetEmpresasByID(object id)
        {
            return dal.GetEmpresasByID(id);
        }

        public void AgregarEmpresa(Empresa emp)
        {
            dal.AgregarEmpresa(emp);
        }

        public void BorrarEmpresa(object id)
        {
            dal.BorrarEmpresa(id);
        }

        public void BorrarEmpresa(Empresa emp)
        {
            dal.BorrarEmpresa(emp);
        }

        public void ActualizarEmpresa(Empresa emp)
        {
            dal.ActualizarEmpresa(emp);
        }

        public BindingList<Empresa> EmpresaBindingList()
        {
            return dal.EmpresaBindingList();
        }


        /* Comercio */
        public IEnumerable<Comercio> GetComercios(Expression<Func<Comercio, bool>> filter = null,
                               Func<IQueryable<Comercio>, IOrderedQueryable<Comercio>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetComercios(filter, orderBy, includeProperties);
        }

        public Comercio GetComercioByID(object id)
        {
            return dal.GetComercioByID(id);
        }

        public void AgregarComercio(Comercio com)
        {
            dal.AgregarComercio(com);
        }

        public void BorrarComercio(object id)
        {
            dal.BorrarComercio(id);
        }

        public void BorrarComercio(Comercio com)
        {
            dal.BorrarComercio(com);
        }

        public void ActualizarComercio(Comercio com)
        {
            dal.ActualizarComercio(com);
        }

        public void ComercioBindingList()
        {
            dal.ComercioBindingList();
        }

        public Comercio GetComercio(int BaseIDb)
        {
            if (BaseIDb == 1 || BaseIDb == 2 || BaseIDb == 3)
            {
                return pGlob.Comercio;
            }
            else if (BaseIDb == 99)
            {
                return pGlob.ComercioM;
            }
            return null;

        }

        public Comercio GetComercio(bool EsM)
        {
            if (EsM)
                return pGlob.ComercioM;
            else
                return pGlob.Comercio;
        }

        public Empresa GetEmpresa(bool EsM)
        {
            if (EsM)
                return pGlob.EmpresaM;
            else
                return pGlob.Empresa;
        }

        public List<Comercio> GetComerciosAdheridos(int BaseIDb)
        {
            return Get<Comercio>(BaseIDb, c => !c.Principal).ToList();
        }

        public List<Comercio> GetComercios(int BaseIDb)
        {
            return Get<Comercio>(BaseIDb).ToList();
        }
        public List<TipoRetencionPlan> GetTipoRetencionPlan(int BaseIDb)
        {
            return Get<TipoRetencionPlan>(BaseIDb).ToList();
        }
        /* Estado */
        public IEnumerable<Estado> GetEstados(Expression<Func<Estado, bool>> filter = null,
                               Func<IQueryable<Estado>, IOrderedQueryable<Estado>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetEstados(filter, orderBy, includeProperties);
        }

        public Estado GetEstadoByID(object id)
        {
            return dal.GetEstadoByID(id);
        }

        public void AgregarEstado(Estado est)
        {
            dal.AgregarEstado(est);
        }

        public void BorrarEstado(object id)
        {
            dal.BorrarEstado(id);
        }

        public void BorrarEstado(Estado est)
        {
            dal.BorrarEstado(est);
        }

        public void ActualizarEstado(Estado est)
        {
            dal.ActualizarEstado(est);
        }

        public BindingList<Estado> EstadoBindingList()
        {
            return dal.EstadoBindingList();
        }

        public List<Estado> GetEstadosGenerales(int BaseIDb)
        {
            return Get<Estado>(BaseIDb, e => e.TipoEstadoID == pGlob.TeEstadoGeneral.TipoEstadoID).ToList();
        }

        public List<Estado> GetEstadosVigenteAnulado(int BaseIDb)
        {
            return GetEstadosGenerales(BaseIDb).Where(e => e.EstadoID == pGlob.Vigente.EstadoID 
                                      || e.EstadoID == pGlob.Anulado.EstadoID).ToList();
        }

        

        /* Conceptos Fondos */
        public IEnumerable<ConceptoFondos> GetConceptosFondos(Expression<Func<ConceptoFondos, bool>> filter = null,
                               Func<IQueryable<ConceptoFondos>, IOrderedQueryable<ConceptoFondos>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetConceptosFondos(filter, orderBy, includeProperties);
        }

        public ConceptoFondos GetConceptoFondoByID(object id)
        {
            return dal.GetConceptoFondoByID(id);
        }

        public void AgregarConceptoFondo(ConceptoFondos cf)
        {
            dal.AgregarConceptoFondo(cf);
        }

        public void BorrarConceptoFondo(object id)
        {
            dal.BorrarConceptoFondo(id);
        }

        public void BorrarConceptoFondos(ConceptoFondos cf)
        {
            dal.BorrarConceptoFondo(cf);
        }

        public void ActualizarConceptoFondo(ConceptoFondos cf)
        {
            dal.ActualizarConceptoFondo(cf);
        }

        public BindingList<ConceptoFondos> ConceptoFondosBindingList()
        {
            return dal.ConceptoFondosBindingList();
        }

        public List<ConceptoFondos> GetConceptosFondos()
        {
            List<ConceptoFondos> conceptos = new List<ConceptoFondos>();
            conceptos.Add(pGlob.RetCob);
            conceptos.Add(pGlob.ExtBan);
            conceptos.Add(pGlob.RetValoresARendir);
            return conceptos;
        }


        /* Tipo Solicitud */
        public IEnumerable<TipoSolicitud> GetTiposSolicitud(Expression<Func<TipoSolicitud, bool>> filter = null,
                               Func<IQueryable<TipoSolicitud>, IOrderedQueryable<TipoSolicitud>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetTiposSolicitud(filter, orderBy, includeProperties);
        }

        public TipoSolicitud GetTipoSolicitudByID(object id)
        {
            return dal.GetTipoSolicitudByID(id);
        }

        public void AgregarTipoSolicitud(TipoSolicitud ts)
        {
            dal.AgregarTipoSolicitud(ts);
        }

        public void BorrarTipoSolicitud(object id)
        {
            dal.BorrarTipoSolicitud(id);
        }

        public void BorrarTipoSolicitud(TipoSolicitud ts)
        {
            dal.BorrarTipoSolicitud(ts);
        }

        public void ActualizarTipoSolicitud(TipoSolicitud ts)
        {
            dal.ActualizarTipoSolicitud(ts);
        }

        public BindingList<TipoSolicitud> TipoSolicitudBindingList()
        {
            return dal.TipoSolicitudBindingList();
        }

        public IEnumerable<TipoSolicitud> GetTiposSolicitudCap()
        {
            List<TipoSolicitud> ts = new List<TipoSolicitud>();
            ts.Add(pGlob.tsCap);
            return ts;
        }

        public IEnumerable<TipoSolicitud> GetTiposSolicitudFF()
        {
            List<TipoSolicitud> ts = new List<TipoSolicitud>();
            ts.Add(pGlob.tsFF);
            return ts;
        }

        public IEnumerable<TipoSolicitud> GetTiposSolicitudVenta()
        {
            List<TipoSolicitud> ts = new List<TipoSolicitud>();
            ts.Add(pGlob.tsVenta);
            ts.Add(pGlob.tsVentaAnticipada);
            return ts;
        }

        /* Moneda */
        public IEnumerable<Moneda> GetMonedas(Expression<Func<Moneda, bool>> filter = null,
                               Func<IQueryable<Moneda>, IOrderedQueryable<Moneda>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetMonedas(filter, orderBy, includeProperties);
        }

        public Moneda GetMonedaByID(object id)
        {
            return dal.GetMonedaByID(id);
        }

        public void AgregarMoneda(Moneda mon)
        {
            dal.AgregarMoneda(mon);
        }

        public void BorrarMoneda(object id)
        {
            dal.BorrarMoneda(id);
        }

        public void BorrarMoneda(Moneda mon)
        {
            dal.BorrarMoneda(mon);
        }

        public void ActualizarMoneda(Moneda mon)
        {
            dal.ActualizarMoneda(mon);
        }

        public BindingList<Moneda> MonedaBindingList()
        {
            return dal.MonedaBindingList();
        }

        public Moneda GetPeso()
        {
            return pGlob.Peso;
        }


       
        /* Operacion */
        public IEnumerable<Operacion> GetOperaciones(Expression<Func<Operacion, bool>> filter = null,
                               Func<IQueryable<Operacion>, IOrderedQueryable<Operacion>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetOperaciones(filter, orderBy, includeProperties);
        }

        public Operacion GetOperacionByName(string nombre)
        {
            switch (nombre)
            {
                case "TransEnviarSolicitudDeFondo":
                    return (TransEnviarSolicitudDeFondo)GetOperacionByID(1);
                case "TransConfirmarSolicitudDeFondo":
                    return (TransConfirmarSolicitudDeFondo)GetOperacionByID(2);
                case "TransAgregarProveedor":
                    return (TransAgregarProveedor)GetOperacionByID(3);
                case "TransActualizarProveedor":
                    return (TransActualizarProveedor)GetOperacionByID(4);
                case "TransEliminarProveedor":
                    return (TransEliminarProveedor)GetOperacionByID(5);
                case "TransAgregarSucursalProveedor":
                    return (TransAgregarProveedorSucursal)GetOperacionByID(6);
                case "TransActualizarSucursalProveedor":
                    return (TransActualizarProveedorSucursal)GetOperacionByID(7);
                case "TransEliminarSucursalProveedor":
                    return (TransEliminarProveedorSucursal)GetOperacionByID(8);
                case "TransAgregarConceptoGastos":
                    return (TransAgregarConceptoGastos)GetOperacionByID(9);
                case "TransActualizarConceptoGastos":
                    return (TransActualizarConceptoGastos)GetOperacionByID(10);
                case "TransEliminarConceptoGastos":
                    return (TransEliminarConceptoGastos)GetOperacionByID(11);
                case "TransAgregarConceptoGastoProveedor":
                    return (TransAgregarConceptoGastoProveedor)GetOperacionByID(12);
                case "TransEliminarConceptoGastoProveedor":
                    return (TransEliminarConceptoGastoProveedor)GetOperacionByID(13);
                case "TransAgregarCliente":
                    return (TransAgregarCliente)GetOperacionByID(14);
                case "TransActualizarCliente":
                    return (TransActualizarCliente)GetOperacionByID(15);
                case "TransEliminarCliente":
                    return (TransEliminarCliente)GetOperacionByID(16);
                case "TransAltaCredito":
                    return (TransAltaCredito)GetOperacionByID(17);
                case "TransBajaCredito":
                    return (TransBajaCredito)GetOperacionByID(18);
                case "TransAltaCobranza":
                    return (TransAltaCobranza)GetOperacionByID(19);
                case "TransBajaCobranza":
                    return (TransBajaCobranza)GetOperacionByID(20);
                case "TransBajaRefinanciacionCobranza":
                    return (TransBajaRefinanciacionCobranza)GetOperacionByID(21);
                case "TransActualizarRefinanciacionCuota":
                    return (TransActualizarRefinanciacionCuota)GetOperacionByID(22);
                case "TransActualizarRefinanciacionCobranza":
                    return (TransActualizarRefinanciacionCobranza)GetOperacionByID(23);
                case "TransActualizarCuota":
                    return (TransActualizarCuota)GetOperacionByID(24);
                case "TransAgregarCobranza":
                    return (TransAgregarCobranza)GetOperacionByID(25);
                case "TransActualizarCobranza":
                    return (TransActualizarCobranza)GetOperacionByID(26);
                case "TransAltaNotaCD":
                    return (TransAltaNotaCD)GetOperacionByID(27);
                case "TransAltaArregloCancelacion":
                    return (TransAltaArregloCancelacion)GetOperacionByID(28);
                case "TransAltaPagoAnticipado":
                    return (TransAltaPagoAnticipado)GetOperacionByID(29);
                case "TransAltaRefinanciacion":
                    return (TransAltaRefinanciacion)GetOperacionByID(30);
                case "TransAltaRefinanciacionCobranza":
                    return (TransAltaRefinanciacionCobranza)GetOperacionByID(31);
                case "TransActualizarCredito":
                    return (TransActualizarCredito)GetOperacionByID(32);
                case "TransAltaRefinanciacionCuota":
                    return (TransAltaRefinanciacionCuota)GetOperacionByID(33);
                case "TransBajaNotaCD":
                    return (TransBajaNotaCD)GetOperacionByID(34);
                case "TransPagoAnticipadoNotaCD":
                    return (TransPagoAnticipadoNotaCD)GetOperacionByID(35);
                case "TransImputacionCC":
                    return (TransImputacionCC)GetOperacionByID(36);
                case "TransBajaRefinanciacion":
                    return (TransBajaRefinanciacion)GetOperacionByID(37);
                case "TransArchivo":
                    return (TransArchivo)GetOperacionByID(38);
                case "TransAltaRecibo":
                    return (TransAltaRecibo)GetOperacionByID(39);
                case "TransAltaTransDep":
                    return (TransAltaTransDep)GetOperacionByID(40);
                case "TransControlDiario":
                    return (TransControlDiario)GetOperacionByID(41);
                case "TransActualizarSolicitudFondos":
                    return (TransActualizarSolicitudDeFondo)GetOperacionByID(42);
                case "TransAltaFF":
                    return (TransAltaFF)GetOperacionByID(43);
                case "TransBajaFF":
                    return (TransBajaFF)GetOperacionByID(44);
                case "TransActualizarFF":
                    return (TransActualizarFF)GetOperacionByID(45);
                case "TransAltaCap":
                    return (TransAltaCap)GetOperacionByID(46);
                case "TransBajaCap":
                    return (TransBajaCap)GetOperacionByID(47);
                case "TransActualizarCap":
                    return (TransActualizarCap)GetOperacionByID(48);
                case "TransAltaPago":
                    return (TransAltaPago)GetOperacionByID(49);
                case "TransBajaPago":
                    return (TransBajaPago)GetOperacionByID(50);
                case "TransActualizarPago":
                    return (TransActualizarPago)GetOperacionByID(51);
               case "TransAltaComprobante":
                    return (TransAltaComprobante)GetOperacionByID(52);
                case "TransBajaComprobante":
                    return (TransBajaComprobante)GetOperacionByID(53);
                case "TransActualizarComprobante":
                    return (TransActualizarComprobante)GetOperacionByID(54);
                case "TransAltaCobranzas":
                    return (TransAltaCobranzas)GetOperacionByID(55);
                case "TransAltaGasto":
                    return (TransAltaGasto)GetOperacionByID(56);
                case "TransBajaGasto":
                    return (TransBajaGasto)GetOperacionByID(57);
                case "TransInfoAct":
                    return (TransInfoAct)GetOperacionByID(58);
                case "TransBajaRecibo":
                    return (TransBajaRecibo)GetOperacionByID(59);                   
                    
            }
            return null;
        }

        public Operacion GetOperacionByID(object id)
        {
            return dal.GetOperacionByID(id);
        }

        public void AgregarOperacion(Operacion op)
        {
            dal.AgregarOperacion(op);
        }

        public void BorrarOperacion(object id)
        {
            dal.BorrarOperacion(id);
        }

        public void BorrarOperacion(Operacion op)
        {
            dal.BorrarOperacion(op);
        }

        public void ActualizarOperacion(Operacion op)
        {
            dal.ActualizarOperacion(op);
        }

        public BindingList<Operacion> OperacionBindingList()
        {
            return dal.OperacionBindingList();
        }

        /*Profesiones */
        /*Profesiones */
        public IEnumerable<Profesion> GetProfesiones(Expression<Func<Profesion, bool>> filter = null,
                                 Func<IQueryable<Profesion>, IOrderedQueryable<Profesion>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetProfesiones(filter, orderBy, includeProperties);
        }

        public IEnumerable<Profesion> GetProfesionesPadres(int BaseIDb,Expression<Func<Profesion, bool>> filter = null,
                                Func<IQueryable<Profesion>, IOrderedQueryable<Profesion>> orderBy = null,
                                string includeProperties = "")
        {
            return Get<Profesion>(BaseIDb,p => p.ProfesionPadreID == null);
        }



        public Profesion GetProfesionByID(object id)
        {
            return dal.GetProfesionByID(id);
        }

        public void AgregarProfesion(Profesion p)
        {
            dal.AgregarProfesion(p);
        }

        public void BorrarProfesion(object id)
        {
            dal.BorrarProfesion(id);
        }

        public void BorrarProfesion(Profesion p)
        {
            dal.BorrarProfesion(p);
        }

        public void ActualizarProfesion(Profesion p)
        {
           dal.ActualizarProfesion(p);
        }

        public BindingList<Profesion> ProfesionBindingList()
        {
            return dal.ProfesionBindingList();
        }

        public String[] GetProfesionesID(int BaseIDb)
        {
            return Get<Profesion>(BaseIDb).Select(p=>p.ProfesionID).ToArray();
        }

        /*Tipos Documento */
        public IEnumerable<TipoDocumento> GetTiposDocumento(Expression<Func<TipoDocumento, bool>> filter = null,
                                 Func<IQueryable<TipoDocumento>, IOrderedQueryable<TipoDocumento>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetTiposDocumento(filter, orderBy, includeProperties);
        }

        public TipoDocumento TipoDocumentoByID(object id)
        {
            return dal.GetTipoDocumentoByID(id);
        }

        public void AgregaripoDocumento(TipoDocumento td)
        {
            dal.AgregarTipoDocumento(td);
        }

        public void BorraripoDocumento(object id)
        {
            dal.BorrarTipoDocumento(id);
        }

        public void BorraripoDocumento(TipoDocumento td)
        {
            dal.BorrarTipoDocumento(td);
        }
        public void ActualizaripoDocumento(TipoDocumento td)
        {
            dal.ActualizarTipoDocumento(td);
        }

        public BindingList<TipoDocumento> TiposDocumentoBindingList()
        {
            return dal.TiposDocumentoBindingList();
        }

        /* EstadoTransmision */
        public IEnumerable<EstadoTransmision> GetEstadosTransmision(Expression<Func<EstadoTransmision, bool>> filter = null,
                               Func<IQueryable<EstadoTransmision>, IOrderedQueryable<EstadoTransmision>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetEstadosTransmision(filter, orderBy, includeProperties);
        }

        public EstadoTransmision GetEstadoTransmisionByID(object id)
        {
                return dal.GetEstadoTransmisionByID(id);
        }

        public void AgregarEstadoTransmision(EstadoTransmision et)
        {
            dal.AgregarEstadoTransmision(et);
        }

        public void BorrarEstadoTransmision(object id)
        {
            dal.BorrarEstadoTransmision(id);
        }

        public void BorrarEstadoTransmision(EstadoTransmision et)
        {
            dal.BorrarEstadoTransmision(et);
        }

        public void ActualizarEstadoTransmision(EstadoTransmision et)
        {
            dal.ActualizarEstadoTransmision(et);
        }

        public BindingList<EstadoTransmision> EstadoTransmisionBindingList()
        {
            return dal.EstadoTransmisionBindingList();
        }

        /* Transmision */
        public IEnumerable<Transmision> GetTransmisiones(int BaseIDb,Expression<Func<Transmision, bool>> filter = null,
                               Func<IQueryable<Transmision>, IOrderedQueryable<Transmision>> orderBy = null,
                               string includeProperties = "")
        {
            return GetDal(BaseIDb).GetTransmisiones(filter, orderBy, includeProperties);
        }

        public Transmision GetTransmisionByID(int BaseIDb, object id)
        {
            return GetDal(BaseIDb).GetTransmisionByID(id);
        }

        public void AgregarTransmision(Transmision t)
        {
            //dal.AgregarTransmision(t);
            GetDal(t.EmpresaID).AgregarTransaccional<Transmision>(t);           
        }

        public void BorrarTransmision(int BaseIDb, object id)
        {
            GetDal(BaseIDb).BorrarTransaccional<Transmision>(id);
            //dal.BorrarTransmision(id);
        }

        public void BorrarTransmision(Transmision t)
        {
            GetDal(t.EmpresaID).BorrarTransaccional<Transmision>(t);
            //dal.BorrarTransmision(t);
        }

        public void ActualizarTransmision(Transmision t)
        {
            GetDal(t.EmpresaID).ActualizarTransaccional<Transmision>(t);
            //dal.ActualizarTransmision(t);
        }

        /* Transmision Genérico */
        public void Transmision<T>(T ObjetoATransmitir, Comercio comer, Operacion op, string RutaApi) where T : ITransmitible
        {
            AgregarTransmision(ObjetoATransmitir, comer, op, pGlob.PendienteDeEnvio, RutaApi,null);
            //return ObjetoATransmitir;
        }

        public Transmision Transmision<T>(T ObjetoATransmitir, Comercio comer, Operacion op,EstadoTransmision est, string RutaApi) where T : ITransmitible
        {
            InfoTransmision InfoTransmision = ObjetoATransmitir.InfoTransmision();
            InfoTransmision.Fecha = DateTime.Now;
            InfoTransmision.RutaApi = RutaApi;
            InfoTransmision.Comercio = comer;
            InfoTransmision.Operacion = op;
            InfoTransmision.EstadoTransmision = est;
            Transmision t = new Transmision(InfoTransmision);
            t.Comercio = comer;
            t.Operacion = op;
            t.EstadoTransmision = est;
            t.CantTransmisiones = 0;
            return t;
        }


        public List<Transmision> Transmision(List<Transmision> ltrans, Comercio comer, Operacion op, string RutaApi)
        {
            EstadoTransmision estado = pGlob.EnvioEnGrupo;
            int? GrupoTransmision = null;
            int? SubGrupoTransmision = null;
            if (ltrans != null && ltrans.Count == 0)
            {
                GrupoTransmision = GetDal(comer.EmpresaID).context.Transmisiones.Max(t => t.GrupoTransmision) + 1;
                if (GrupoTransmision == null)
                {
                    GrupoTransmision = 1;
                }
                estado = pGlob.PendienteDeEnvio;
            }
            else
            {
                GrupoTransmision = ltrans[0].GrupoTransmision;
            }
            AgregarTransmision(ltrans,comer, op, estado, RutaApi, GrupoTransmision);
            return ltrans;
        }

        public List<Transmision> Transmision<T>(List<Transmision> ltrans,T ObjetoATransmitir, Comercio comer, Operacion op, string RutaApi) where T : ITransmitible
        {
            EstadoTransmision estado = pGlob.EnvioEnGrupo;
            int? GrupoTransmision = null;
            if (ltrans != null && ltrans.Count == 0)
            {
                GrupoTransmision = GetDal(comer.EmpresaID).context.Transmisiones.Max(t => t.GrupoTransmision) + 1;
                if (GrupoTransmision == null)
                {
                    GrupoTransmision = 1;
                }
                estado = pGlob.PendienteDeEnvio;
            }
            else
            {
                GrupoTransmision = ltrans[0].GrupoTransmision;
            }
            ltrans = AgregarTransmision(ltrans,ObjetoATransmitir, comer, op, estado, RutaApi, GrupoTransmision);
            return ltrans;
        }

        public int Transmision<T>(T ObjetoATransmitir, Comercio comer, Operacion op, string RutaApi, int? GrupoTransmision) where T : ITransmitible
        {
            EstadoTransmision estado = pGlob.EnvioEnGrupo;
            if (GrupoTransmision == null)
            {
                GrupoTransmision = GetDal(comer.EmpresaID).context.Transmisiones.Max(t => t.GrupoTransmision) + 1;
                if (GrupoTransmision == null)
                {
                    GrupoTransmision = 1;
                }
                estado = pGlob.PendienteDeEnvio;
            }
            AgregarTransmision(ObjetoATransmitir, comer, op, estado, RutaApi, GrupoTransmision);
            return GrupoTransmision.Value;
        }

        public int Transmision(Comercio comer, Operacion op, string RutaApi, int? GrupoTransmision)
        {
            EstadoTransmision estado = pGlob.EnvioEnGrupo;
            if (GrupoTransmision == null)
            {
                GrupoTransmision = GetDal(comer.EmpresaID).context.Transmisiones.Max(t => t.GrupoTransmision) + 1;
                estado = pGlob.PendienteDeEnvio;
            }
            AgregarTransmision(comer, op, estado, RutaApi, GrupoTransmision);
            return GrupoTransmision.Value;
        }

        public List<Transmision> AgregarTransmision(List<Transmision> ltrans, ITransmitible T, Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string RutaApi, int? GrupoTransmision)
        {
            if (T == null) return null;
            InfoTransmision InfoTransmision = T.InfoTransmision();
            InfoTransmision.Comercio = Comercio;
            InfoTransmision.Operacion = Operacion;
            InfoTransmision.EstadoTransmision = EstadoTransmision;
            InfoTransmision.Fecha = DateTime.Now;
            Transmision t = new Transmision(InfoTransmision);
            t.RutaApi = RutaApi;
            t.GrupoTransmision = GrupoTransmision;
            t.CantTransmisiones = 0;
            ltrans.Add(t);
            return ltrans;
        }

        public List<Transmision> AgregarTransmision(List<Transmision> lTrans, Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string RutaApi, int? GrupoTransmision)
        {
            InfoTransmision InfoTransmision = new InfoTransmision();
            InfoTransmision.Comercio = Comercio;
            InfoTransmision.Operacion = Operacion;
            InfoTransmision.EstadoTransmision = EstadoTransmision;
            InfoTransmision.Fecha = DateTime.Now;
            Transmision t = new Transmision(InfoTransmision);
            t.RutaApi = RutaApi;
            t.GrupoTransmision = GrupoTransmision;
            t.CantTransmisiones = 0;
            lTrans.Add(t);
            return lTrans;
        }
        
        public bool AgregarTransmision(ITransmitible T, Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string RutaApi, int? GrupoTransmision)
        {
            InfoTransmision InfoTransmision = T.InfoTransmision();
            InfoTransmision.Comercio = Comercio;
            InfoTransmision.Operacion = Operacion;
            InfoTransmision.EstadoTransmision = EstadoTransmision;
            InfoTransmision.Fecha = DateTime.Now;
            Transmision t = new Transmision(InfoTransmision);
            t.RutaApi = RutaApi;
            t.GrupoTransmision = GrupoTransmision;
            t.CantTransmisiones = 0;
            AgregarTransmision(t);
            return true;
        }

        


        public bool AgregarTransmision(Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string RutaApi, int? GrupoTransmision)
        {
            InfoTransmision InfoTransmision = new InfoTransmision();
            InfoTransmision.Comercio = Comercio;
            InfoTransmision.Operacion = Operacion;
            InfoTransmision.EstadoTransmision = EstadoTransmision;
            InfoTransmision.Fecha = DateTime.Now;
            Transmision t = new Transmision(InfoTransmision);
            t.RutaApi = RutaApi;
            t.GrupoTransmision = GrupoTransmision;
            t.CantTransmisiones = 0;
            AgregarTransmision(t);
            return true;
        }

        public bool AgregarTransmision(Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string RutaApi,string nombreArchivo, string rutaArchivo, string tipoArchivo)
        {
            InfoTransmision InfoTransmision = new InfoTransmision();
            InfoTransmision.Comercio = Comercio;
            InfoTransmision.Operacion = Operacion;
            InfoTransmision.EstadoTransmision = EstadoTransmision;
            InfoTransmision.Fecha = DateTime.Now;
            Transmision t = new Transmision(InfoTransmision);
            t.RutaApi = RutaApi;
            t.EntidadID = nombreArchivo;
            t.EntidadID2= rutaArchivo;
            t.EntidadID3 = tipoArchivo;
            t.CantTransmisiones = 0;
            AgregarTransmision(t);
            return true;
        }


        public void GrabarTransmisiones(int BaseIDb,List<Transmision> lTrans)
        {
            AgregarRange<Transmision>(BaseIDb, lTrans);
        }

        public void  AgregarTransmisionArchivo(Comercio com,string nombreArchivo,string rutaArchivo,string tipoArchivo)
        {
            AgregarTransmision(com, pGlob.TransArchivo, pGlob.PendienteDeEnvio, pGlob.UriArchivos, nombreArchivo, rutaArchivo, tipoArchivo);
            Grabar(com.EmpresaID);           
        }

        
        public async Task<SolicitudFondo> AgregarTransmisionSolicitudDeFondo(SolicitudFondo solfon)
        {
           //AgregarSolicitudesDeFondos(solfon); //EF automaticamente popula la clave con la insertada en la base.
           Transmision t = new Transmision(solfon.Empresa, solfon.Comercio, pGlob.TransEnviarSolicitudDeFondo,pGlob.PendienteDeEnvio, solfon.SolicitudFondoID.Value.ToString(),DateTime.Now);
           AgregarTransmision(t);
           Grabar(t.EmpresaID);
           return solfon;
        }

        public async Task<SolicitudFondo> TransmisionConfirmarSolicitudDeFondo(SolicitudFondo solfon)
        {
            Transmision t = new Transmision(solfon.Empresa, solfon.Comercio, pGlob.TransConfirmarSolicitudDeFondo, pGlob.PendienteDeEnvio, solfon.SolicitudFondoID.Value.ToString(), DateTime.Now);
            AgregarTransmision(t);
            Grabar(t.EmpresaID);
            return solfon;
        }

       
        
        /*Transmision proveedor */
        public  Proveedor TransmisionAgregarProveedor(Proveedor prov, Comercio comer)
        {
            return TransmisionProveedor(prov, comer, pGlob.TransAgregarProveedor); 
        }

        public  Proveedor TransmisionActualizarProveedor(Proveedor prov, Comercio comer)
        {
            return  TransmisionProveedor(prov, comer, pGlob.TransActualizarProveedor);
        }

        public Proveedor TransmisionEliminarProveedor(Proveedor prov, Comercio comer)
        {
            return TransmisionProveedor(prov, comer, pGlob.TransEliminarProveedor);
        }

        public Proveedor TransmisionProveedor(Proveedor prov, Comercio comer,Operacion op)
        {
            Transmision t = new Transmision(comer.Empresa, comer,op, pGlob.PendienteDeEnvio, prov.ProveedorID.Value.ToString(), DateTime.Now);
            AgregarTransmision(t);
            Grabar(t.EmpresaID);
            return prov;
        }


        public ProveedorSucursal TransmisionAgregarProveedorSucursal(ProveedorSucursal provSuc, Comercio comer)
        {
            TransmisionProveedorSucursal(provSuc, comer, pGlob.TransAgregarSucursalProveedor);
            return provSuc;
        }

        public ProveedorSucursal TransmisionActualizarProveedorSucursal(ProveedorSucursal provSuc, Comercio comer)
        {
            TransmisionProveedorSucursal(provSuc, comer, pGlob.TransActualizarSucursalProveedor);
            return provSuc;
        }

        public ProveedorSucursal TransmisionEliminarProveedorSucursal(ProveedorSucursal provSuc, Comercio comer)
        {
            TransmisionProveedorSucursal(provSuc, comer, pGlob.TransEliminarSucursalProveedor);
            return provSuc;
        }

        public Transmision TransmisionProveedorSucursal(ProveedorSucursal provSuc, Comercio comer, Operacion op)
        {
            Transmision t = new Transmision(comer.Empresa, comer, op, pGlob.PendienteDeEnvio, provSuc.ProveedorSucursalID.ToString(), provSuc.ProveedorID.Value.ToString(), DateTime.Now);
            AgregarTransmision(t);
            Grabar(t.EmpresaID);
            return t;
        }

        /*Transmision Concepto de gastos */
        public ConceptoGastos TransmisionAgregarConceptoGastos(ConceptoGastos cgp, Comercio comer)
        {
            return TransmisionConceptoGastos(cgp, comer, pGlob.TransAgregarConceptoGastos);
        }

        public ConceptoGastos TransmisionActualizarConceptoGastos(ConceptoGastos cgp, Comercio comer)
        {
            return TransmisionConceptoGastos(cgp, comer, pGlob.TransActualizarConceptoGastos);
        }

        public ConceptoGastos TransmisionEliminarConceptoGastos(ConceptoGastos cgp, Comercio comer)
        {
            return TransmisionConceptoGastos(cgp, comer, pGlob.TransEliminarConceptoGastos);
        }
        
        public ConceptoGastos TransmisionConceptoGastos(ConceptoGastos cgp, Comercio comer, Operacion op)
        {
            Transmision t = new Transmision(comer.Empresa, comer, op, pGlob.PendienteDeEnvio, cgp.ConceptoGastosID.Value.ToString(), DateTime.Now);
            AgregarTransmision(t);
            Grabar(t.EmpresaID);
            return cgp;
        }

        /*Transmision Concepto de gastos Proveedor */
        public void TransmisionAgregarConceptoGastosProveedor(ConceptoGastosProveedor cgp, Comercio comer)
        {
            Transmision<ConceptoGastosProveedor>(cgp, comer, pGlob.TransAgregarConceptoGastosProveedor,"Api/ConceptoGastosProveedor");
            Grabar( comer.EmpresaID);
        }

        public void TransmisionEliminarConceptoGastosProveedor(ConceptoGastosProveedor cgp, Comercio comer)
        {
            Transmision<ConceptoGastosProveedor>(cgp, comer, pGlob.TransEliminarConceptoGastosProveedor, "Api/ConceptoGastosProveedor");
            Grabar();
        }


       
        /* Transmitir Generico */
        public async Task<TEntity> Post<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
            where TEntity : new()
            where TEntityRM : new()
        {
            TEntity e = await ra.Post<TEntity, TEntityRM>(T,uri, parametros);
            return e;
        }

        public async Task<TEntityRM> Post<TEntityRM>(TEntityRM T, string uri, Dictionary<string, object> parametros)
            where TEntityRM : new()
        {
            TEntityRM e = await ra.Post<TEntityRM>(T, uri, parametros);
            return e;
        }

       public async Task<TEntity> Put<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
            where TEntity : new()
            where TEntityRM : new()
        {
            TEntity e = await ra.Put<TEntity, TEntityRM>(T, uri, parametros);
            return e;
        }

       public async Task<TEntity> Get<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
           where TEntity : new()
           where TEntityRM : new()
       {
           TEntity e = await ra.Get<TEntity, TEntityRM>(T, uri, parametros);
           return e;
       }

       public async Task<TEntity> Get<TEntity>(TEntity T,Comercio com, string uri)
           where TEntity : ITransmitible,new()
       {
           TEntity e = await ra.Get<TEntity>(T, com,uri);
           return e;
       }

       public async Task<TEntity> Delete<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
           where TEntity : new()
           where TEntityRM : new()
       {
           TEntity e = await ra.Delete<TEntity, TEntityRM>(T, uri, parametros);
           return e;
       }

       public async Task<TEntityRM> Delete<TEntityRM>(TEntityRM T, string uri, Dictionary<string, object> parametros)
           where TEntityRM : new()
       {
           TEntityRM e = await ra.Delete<TEntityRM>(T, uri, parametros);
           return e;
       }

        /* Transmitir Archivo*/
       public async Task<FileUploadResult> TransmitirAchivo(int EmpresaID, int ComercioID, string fileName, string filePath, string claseArchivo)
        {
            FileUploadResult res = await ra.PostFileAsync(EmpresaID, ComercioID, fileName, filePath, claseArchivo);
            return res;
        }
        

        /*Transmision Solicitudes de fondo */
        public async Task<SolicitudFondo> TransmitirSolicitudDeFondo(SolicitudFondo solfon)
        {
            SolicitudFondo sf = await ra.PostSolicitudFondo(solfon);
            return sf;
        }

        public async Task<Autorizacion> ConfirmarSolicitudDeFondo(SolicitudFondo solfon)
        {
            //Autorizacion sf = await ra.PutSolicitudFondo(solfon);
            Autorizacion sf = await ra.ConfirmarSolicitudFondo(solfon);
            return sf;
        }

        public async Task<SolicitudFondo> TransActualizarSolicitudDeFondo(SolicitudFondo solfon)
        {
            //Autorizacion sf = await ra.PutSolicitudFondo(solfon);
            SolicitudFondo sf = await ra.PutSolicitudFondo(solfon);
            return sf;
        }
        

        /*Transmision Proveedores */
        public async Task<Proveedor> TransmitirAgregarProveedor(Proveedor proveedor,Comercio com)
        {
            Proveedor prov = await ra.PostProveedor(proveedor,com);
            return prov;
        }

        public async Task<Proveedor> TransmitirActualizarProveedor(Proveedor proveedor, Comercio com)
        {
            Proveedor prov = await ra.PutProveedor(proveedor, com);
            return prov;
        }

        public async Task<int?> TransmitirEliminarProveedor(Proveedor proveedor, Comercio com)
        {
            IntRestModel r= await ra.DeleteProveedor(proveedor, com);
            if (r!= null)
            { 
               return r.Value;
            }
            return null;
        }

        public async Task<ProveedorSucursal> TransmitirAgregarSucursalProveedor(ProveedorSucursal proveedorSucursal, Comercio com)
        {

            ProveedorSucursal prov = await ra.PostProveedorSucursal(proveedorSucursal, com);
            return prov;
        }

        public async Task<ProveedorSucursal> TransmitirActualizarSucursalProveedor(ProveedorSucursal proveedorSucursal, Comercio com)
        {
            ProveedorSucursal prov = await ra.PutProveedorSucursal(proveedorSucursal, com);
            return prov;
        }

        public async Task<int?> TransmitirEliminarProveedorSucursal(ProveedorSucursal proveedorSucursal, Comercio com)
        {
            IntRestModel r = await ra.DeleteProveedorSucursal(proveedorSucursal, com);
            if (r != null)
            {
                return r.Value;
            }
            return null;
        }
        
        /* Transmitir Concepto de gastos */
        public async Task<ConceptoGastos> TransmitirAgregarConceptoGasto(ConceptoGastos cgp, Comercio com)
        {
            ConceptoGastos prov = await ra.PostConceptoGastos(cgp, com);
            return cgp;
        }

        public async Task<ConceptoGastos> TransmitirActualizarConceptoGasto(ConceptoGastos cgp, Comercio com)
        {
            ConceptoGastos prov = await ra.PutConceptoGastos(cgp, com);
            return cgp;
        }

        public async Task<int?> TransmitirEliminarConceptoGasto(ConceptoGastos cgp, Comercio com)
        {
            IntRestModel r = await ra.DeleteConceptoGastos(cgp, com);
            if (r != null)
            {
                return r.Value;
            }
            return null;
        }


        /* Transmitir Concepto de gastos  Proveedor*/
        public async Task<ConceptoGastosProveedor> TransmitirAgregarConceptoGastoProveedor(ConceptoGastosProveedor cgp, Comercio com)
        {
            ConceptoGastosProveedor prov = await ra.PostConceptoGastosProveedor(cgp, com);
            return cgp;
        }

        public async Task<int?> TransmitirEliminarConceptoGastoProveedor(ConceptoGastosProveedor cgp, Comercio com)
        {
            IntRestModel r = await ra.DeleteConceptoGastosProveedor(cgp);
            if (r != null)
            {
                return r.Value;
            }
            return null;
        }

        private Transmision TransmisionControlDiario(Comercio com,DateTime FechaDesde,DateTime FechaHasta)
        {
             // ControlDiarioRestModel cdrm =  GetControlDiario(com); //Generar solo la transmision, ya que los datos los carga directamente el objeto operacion
              //Transmision t = Transmision<ControlDiarioRestModel>(cdrm, com, pGlob.TransControlDiario, pGlob.PendienteDeEnvio,pGlob.UriControlDiario);
              Transmision t = new Transmision();
              t.Empresa = com.Empresa;
              t.EmpresaID = com.EmpresaID;
              t.Comercio = com;
              t.ComercioID = com.ComercioID;
              t.EstadoTransmision = pGlob.PendienteDeEnvio;
              t.Fecha = DateTime.Now;
              t.Operacion = pGlob.TransControlDiario;
              t.OperacionID = t.Operacion.OperacionID;
              t.RutaApi = pGlob.UriControlDiario;
              t.EntidadID = FechaDesde.ToShortDateString();
              t.EntidadID2 = FechaHasta.Date.AddDays(1).AddTicks(-1).ToShortDateString();
              return t;                                
        }

        public void RetransmitirErroneas(Comercio Com,DateTime FechaDesde,DateTime FechaHasta)
        {
            DateTimeExtensions.ExtremarFechas(ref FechaDesde,ref FechaHasta);
            List<Transmision> trans = Get<Transmision>(Com.EmpresaID,t=>t.EmpresaID == Com.EmpresaID && t.ComercioID == Com.ComercioID 
                                                      && t.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID
                                                      && t.EstadoTransmisionID != pGlob.EnvioEnGrupo.EstadoTransmisionID
                                                      && t.Fecha >= FechaDesde && t.Fecha <= FechaHasta).ToList();
            foreach (Transmision t in trans)
            {
                t.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                Actualizar<Transmision>(t);
            }            
        }



        public List<String> RestablecerTransRevisadasXSistema(Comercio Com, DateTime FechaDesde, DateTime FechaHasta)
        {
            List<String> Error = new List<string>();
            List<Transmision> trans = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == Com.EmpresaID && t.ComercioID == Com.ComercioID
                                                     && t.EstadoTransmisionID == pGlob.RevisadaSistema.EstadoTransmisionID
                                                     && t.EstadoTransmisionID != pGlob.EnvioEnGrupo.EstadoTransmisionID
                                                     && t.Fecha >= FechaDesde && t.Fecha <= FechaHasta).ToList();
            foreach (Transmision t in trans)
            {
                t.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                Actualizar<Transmision>(t);
            }
            Error.Add("Transmisiones Restablecidas");
            return Error;
        }

        public List<String> RevisarTransmisiones(Comercio Com, DateTime FechaDesde,DateTime FechaHasta)
        {
            List<String> Error = new List<string>();
            DateTime Fecha;
            int dias = (FechaHasta - FechaDesde).Days;

            List<String> ErrCob;
            List<String> ErrAlt;
            List<String> ErrRec;

            Fecha = FechaDesde;
            using (ComercioContext cf = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext")))
            {

                //string sql = string.Format("Update transmision set EstadoTransmisionID = {0} where Fecha < '{1}' and EstadoTransmisionID <> {2} and EstadoTransmisionID <> {3} ",
                //                    pGlob.RevisadaSistema.EstadoTransmisionID, Fecha.ToString("yyyyMMdd"), pGlob.Enviado.EstadoTransmisionID, pGlob.EnvioEnGrupo.EstadoTransmisionID);

                string sql = string.Format(@"update transmision set EstadoTransmisionID = {0} ,CantTransmisiones = {1} 
                                            where Fecha >= '{2}'
                                            and (EstadoTransmisionID = {3} OR EstadoTransmisionID = {4})",
                                             pGlob.PendienteDeEnvio.EstadoTransmisionID, 0,Fecha.ToString("yyyyMMdd"),
                                             pGlob.PendienteDeEnvio.EstadoTransmisionID, pGlob.Erronea.EstadoTransmisionID);
                
                cf.Database.ExecuteSqlCommand(sql);
            }

           
            for (int i = 0; i <= dias;i++ )
            {
               Error.Add(Fecha.ToShortDateString());
               ErrCob = RevisarCobranzas(Com, Fecha);
                if (ErrCob != null)
                    Error.AddRange(ErrCob);
                
                ErrAlt = RevisarAltas(Com, Fecha);
                if (ErrAlt != null)
                    Error.AddRange(ErrAlt);

                ErrRec = RevisarRecibos(Com, Fecha);
                if (ErrRec != null)
                    Error.AddRange(ErrRec);

                Fecha = Fecha.AddDays(1);
            }
            return Error;
        }


        public List<String> RevisarRecibos(Comercio Com, DateTime Fecha)
        {
            DateTime Hasta = Fecha;
            DateTimeExtensions.ExtremarFechas(ref Fecha, ref Hasta);
            Transmision tran;
            Transmision tranAnt;
            List<Transmision> ltrans = new List<Transmision>();
            List<Recibo> recs = Get<Recibo>(c => c.Fecha >= Fecha && c.Fecha <= Hasta).ToList();
            List<string> Errores = new List<string>();

            foreach (Recibo rec in recs)
            {
                tran = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == rec.EmpresaID && t.ComercioID == rec.ComercioID
                                                && t.EntidadID3 == rec.ReciboID.ToString()).FirstOrDefault();
                if (tran != null)
                {
                    if (tran.EstadoTransmisionID == pGlob.EnvioEnGrupo.EstadoTransmisionID)
                    {
                        tranAnt = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == rec.EmpresaID && t.ComercioID == rec.ComercioID
                                                && t.GrupoTransmision == tran.GrupoTransmision).OrderBy(c => tran.TransmisionID).FirstOrDefault();
                        if (tranAnt != null)
                        {
                            if (tranAnt.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID)
                            {
                                tranAnt.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                                Actualizar<Transmision>(tranAnt);
                            }

                        }
                        else
                        {
                            Errores.Add(String.Format("Error (INCLUYE RECIBO): No se encuentra la transmisión SUPERIOR correspondiente a la transmision{0}- Recibo {1} - Fecha {2}"
                                                      , tran.TransmisionID, tran.EntidadID3,tran.Fecha.ToShortDateString()));
                        }
                    }
                    else
                        if (tran.OperacionID == pGlob.TransAltaRecibo.OperacionID)
                        {

                            if (tran.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID)
                            {
                                tran.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                                Actualizar<Transmision>(tran);
                                Errores.Add(String.Format("(RECIBO): Reenvio: transmision:{0}- Recibo {1}- FECHA:{2}"
                                                      , tran.TransmisionID, tran.EntidadID3, tran.Fecha.ToShortDateString()));
                            }
                        }
                }
                else
                {
                    Errores.Add(String.Format("Error (RECIBO): No se encuentra la transmisión correspondiente al Recibo {0} FECHA:{1}"
                                                      , rec.ReciboID, rec.Fecha.Value.ToShortDateString()));

                    CuentaCorriente cc = Get<CuentaCorriente>(rec.EmpresaID, c => c.EmpresaID == rec.EmpresaID && c.ComercioID == rec.ComercioID
                                                              && c.ReciboID == rec.ReciboID && c.Fecha >= Fecha && c.Fecha <= Hasta).FirstOrDefault();
                    if (cc == null)
                    {
                        Errores.Add(String.Format("Error (RECIBO-CTA CTE): No se encuentra la Cuenta Corriente correspondiente al Recibo {0} - FECHA:{1}"
                                                      , rec.ReciboID,rec.Fecha.Value.ToShortDateString()));
                    }
                    else
                    {
                        ltrans = new List<Transmision>();
                        ltrans = Transmision<Recibo>(ltrans, rec, rec.Comercio, pGlob.TransAltaRecibo, pGlob.UriRecibos);
                        ltrans = Transmision<CuentaCorriente>(ltrans, cc, rec.Comercio, pGlob.TransImputacionCC, pGlob.UriRecibos);
                        if (rec.TransferenciasDepositos != null)
                            ltrans = Transmision<TransferenciasDepositos>(ltrans, rec.TransferenciasDepositos, rec.Comercio, pGlob.TransAltaTransDep, pGlob.UriRecibos);
                        GrabarTransmisiones(rec.EmpresaID, ltrans);
                    }

                }
            }
            return Errores;
        }

        public List<String> RevisarCobranzas(Comercio Com, DateTime Fecha)
        {
            DateTime Hasta = Fecha;
            DateTimeExtensions.ExtremarFechas(ref Fecha, ref Hasta);
            Transmision tran;
            Transmision tranAnt;
            List<Transmision> ltrans = new List<Transmision>();
            List<Cobranza> cobs = Get<Cobranza>(c => c.FechaPago >= Fecha && c.FechaPago <= Hasta).ToList();
            List<string> Errores = new List<string>();

            foreach (Cobranza cob in cobs)
            {
                tran = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == cob.EmpresaID && t.ComercioID == cob.ComercioID
                                                && t.EntidadID3 == cob.CreditoID.ToString()
                                                && t.EntidadID4 == cob.CuotaID.ToString()
                                                && t.EntidadID5 == cob.CobranzaID.ToString()).FirstOrDefault();
                if (tran != null)
                {
                    if (tran.EstadoTransmisionID == pGlob.EnvioEnGrupo.EstadoTransmisionID)
                    {
                        tranAnt = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == cob.EmpresaID && t.ComercioID == cob.ComercioID
                                                && t.GrupoTransmision == tran.GrupoTransmision).OrderBy(c => tran.TransmisionID).FirstOrDefault();
                        if (tranAnt != null)
                        {
                            if (tran.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID)
                            {
                                tranAnt.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                                Actualizar<Transmision>(tranAnt);
                            }
                        }
                        else
                        {
                            Errores.Add(String.Format("Error (INCLUYE COBRANZA): No se encuentra la transmisión SUPERIOR correspondiente a la transmision{0}- Cobranza {1} - Crédito {2} - Fecha {3}"
                                                      , tran.TransmisionID, tran.EntidadID5, tran.EntidadID3,tran.Fecha.ToShortDateString()));
                        }
                    }
                    else
                        if (tran.OperacionID == pGlob.TransAltaCobranza.OperacionID)
                        {

                            if (tran.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID)
                            {
                                tran.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                                Actualizar<Transmision>(tran);
                                Errores.Add(String.Format("(COBRANZA): Reenvio: transmision:{0}- Cobranza {1} - Crédito {2} - FECHA:{3}"
                                                      , tran.TransmisionID, tran.EntidadID5, tran.EntidadID3,tran.Fecha.ToShortDateString()));
                            }
                        }
                }
                else
                {
                    Errores.Add(String.Format("Error (COBRANZA): No se encuentra la transmisión correspondiente a la  Cobranza {0} - Crédito {1} - FECHA:{2}"
                                                      , cob.CobranzaID,cob.CreditoID,cob.FechaPago.ToShortDateString()));

                    CuentaCorriente cc = Get<CuentaCorriente>(cob.EmpresaID, c => c.EmpresaID == cob.EmpresaID && c.ComercioID == cob.ComercioID
                                                              && c.CreditoID == cob.CreditoID && c.CuotaID == cob.CuotaID && c.CobranzaID == cob.CobranzaID
                                                              && c.Fecha >= Fecha && c.Fecha <= Hasta).FirstOrDefault();
                    if (cc == null)
                    {
                        Errores.Add(String.Format("Error (COBRANZA-CTA CTE): No se encuentra la Cuenta Corriente correspondiente la Cobranza {0} - Crédito {1} - FECHA:{2}"
                                                      , cob.CobranzaID,cob.CreditoID,cob.FechaPago.ToShortDateString()));
                    }
                    else
                    {
                        ltrans = new List<Transmision>();
                        ltrans = Transmision<Cobranza>(ltrans, cob, cob.Comercio, pGlob.TransAltaCobranzas, pGlob.UriAltaCobranzas);
                        ltrans = Transmision<CuentaCorriente>(ltrans, cc, cob.Comercio, pGlob.TransImputacionCC, pGlob.UriAltaCobranzas);
                        GrabarTransmisiones(cob.EmpresaID,ltrans);
                        Errores.Add(String.Format("(COBRANZA): Reenvio: Cobranza {0} - Crédito {1} - FECHA:{2}"
                                                      , cob.CobranzaID,cob.CreditoID,cob.FechaPago.ToShortDateString()));
                    }

                }
            }
            return Errores;
        }

        public List<String> RevisarAltas(Comercio Com, DateTime Fecha)
        {
            DateTime Hasta = Fecha;
            DateTimeExtensions.ExtremarFechas(ref Fecha, ref Hasta);
            Transmision tran;
            List<Transmision> ltrans = new List<Transmision>();
            List<Credito> creds = Get<Credito>(c => c.FechaSolicitud >= Fecha && c.FechaSolicitud <= Hasta).ToList();
            List<string> Errores = new List<string>();

            foreach (Credito cred in creds)
            {
                tran = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == cred.EmpresaID && t.ComercioID == cred.ComercioID
                                                && t.EntidadID3 == cred.CreditoID.ToString()).FirstOrDefault();
                if (tran != null)
                {
                   if (tran.OperacionID == pGlob.TransAltaCredito.OperacionID)
                        {

                            if (tran.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID)
                            {
                                tran.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                                Actualizar<Transmision>(tran);
                                Errores.Add(String.Format("(CREDITO): Reenvio: transmision{0}- Crédito {1} - FECHA:{2}"
                                                      , tran.TransmisionID, tran.EntidadID3,tran.Fecha.ToShortDateString()));
                            }
                        }
                }
                else
                {
                    Errores.Add(String.Format("Error (CREDITO): No se encuentra la transmisión correspondiente al Crédito {0} - FECHA:{1}"
                                                      ,cred.CreditoID,cred.FechaSolicitud.ToShortDateString()));

                    List<CuentaCorriente> ccs = Get<CuentaCorriente>(cred.EmpresaID, c => c.EmpresaID == cred.EmpresaID && c.ComercioID == cred.ComercioID
                                                              && c.CreditoID == cred.CreditoID && c.Fecha >= Fecha && c.Fecha <= Hasta).ToList();
                    if (ccs == null)
                    {
                        Errores.Add(String.Format("Error (CREDITO-CTA CTE): No se encuentra la Cuenta Corriente correspondiente a al Crédito {0} - FECHA:{1}"
                                                      ,cred.CreditoID,cred.FechaSolicitud.ToShortDateString()));
                    }
                    else
                    {
                        int? GrupoTransmision = null;
                        GrupoTransmision = Transmision<Credito>(cred, cred.Comercio, pGlob.TransAltaCredito, pGlob.UriCreditos, GrupoTransmision);
                        foreach (CuentaCorriente item in ccs)
                        {
                            GrupoTransmision = Transmision<CuentaCorriente>(item, cred.Comercio, pGlob.TransImputacionCC, pGlob.UriAltaCobranza, GrupoTransmision);
                        }
                        Grabar(cred.EmpresaID);
                        Errores.Add(String.Format("(CREDITO): Reenvio: Crédito {0} - FECHA:{1}"
                                                      , cred.CreditoID,cred.FechaSolicitud.ToShortDateString()));
                    }

                }
            }
            return Errores;
        }
        

        public List<String> ActualizarCuotasDesdeCobranzas(Comercio Com, DateTime FechaDesde, DateTime FechaHasta)
        {
            Cuota cuo = null;
            List<String> Error = new List<string>();
            List<Cobranza> trans = Get<Cobranza>(Com.EmpresaID, t => t.FechaPago >= FechaDesde && t.FechaPago <= FechaHasta).ToList();
            Error.Add(String.Format("Actualizando cuotas desde Cobranzas {0:dd/MM/yyyy}-{1:dd/MM/yyyy}", FechaDesde, FechaHasta));
            foreach (Cobranza t in trans)
            {
                    cuo = Get<Cuota>(Com.EmpresaID,c=>c.EmpresaID == t.EmpresaID && c.ComercioID == t.ComercioID 
                                            && c.CreditoID == t.CreditoID && c.CuotaID == t.CuotaID).SingleOrDefault();
                    if (cuo != null)
                    {
                        cuo.ImportePago += t.ImportePago;
                        cuo.ImportePagoPunitorios += t.ImportePagoPunitorios;
                        cuo.FechaUltimoPago = t.FechaPago;
                        Actualizar<Cuota>(cuo);
                        Error.Add(String.Format("Cuota:{0}-{1}-{2} Agregada", cuo.ComercioID, cuo.CreditoID, cuo.CuotaID));
                    }
                else
                    {
                        Error.Add(String.Format("No se encuentra la Cuota:{0}-{1}-{2} Agregada", cuo.ComercioID, cuo.CreditoID, cuo.CuotaID));
                    }
                        
            }
            Error.Add("Transmisiones Restablecidas");
            return Error;
        }

        public List<String> ActualizarRefiCuotasDesdeCobranzas(Comercio Com, DateTime FechaDesde, DateTime FechaHasta)
        {
            RefinanciacionCuota cuo = null;
            List<String> Error = new List<string>();
            List<RefinanciacionCobranza> trans = Get<RefinanciacionCobranza>(Com.EmpresaID, t => t.FechaPago >= FechaDesde && t.FechaPago <= FechaHasta).ToList();
            Error.Add(String.Format("Actualizando REFI cuotas desde Cobranzas {0:dd/MM/yyyy}-{1:dd/MM/yyyy}", FechaDesde, FechaHasta));
            foreach (RefinanciacionCobranza t in trans)
            {
                cuo = Get<RefinanciacionCuota>(Com.EmpresaID, c => c.EmpresaID == t.EmpresaID && c.ComercioID == t.ComercioID
                                        && c.CreditoID == t.CreditoID && c.RefinanciacionID == t.RefinanciacionID && c.RefinanciacionCuotaID == t.RefinanciacionCuotaID).SingleOrDefault();
                if (cuo != null)
                {
                    cuo.ImportePago += t.ImportePago;
                    cuo.ImportePagoPunitorios += t.ImportePagoPunitorios;
                    cuo.FechaUltimoPago = t.FechaPago;
                    Actualizar<RefinanciacionCuota>(cuo);
                    Error.Add(String.Format("REFI Cuota:{0}-{1}-{2}-{3} Agregada", cuo.ComercioID, cuo.CreditoID, cuo.RefinanciacionID,cuo.RefinanciacionCuotaID));
                }
                else
                {
                    Error.Add(String.Format("No se encuentra la REFI Cuota:{0}-{1}-{2}-{3} Agregada", cuo.ComercioID, cuo.RefinanciacionID, cuo.RefinanciacionCuotaID));
                }

            }
            Error.Add("Transmisiones Restablecidas");
            return Error;
        }
        
                        

        public void RetransmitirTodas(Comercio Com, DateTime FechaDesde, DateTime FechaHasta)
        {
            DateTimeExtensions.ExtremarFechas(ref FechaDesde, ref FechaHasta);
            List<Transmision> trans = Get<Transmision>(Com.EmpresaID, t => t.EmpresaID == Com.EmpresaID && t.ComercioID == Com.ComercioID 
                                                       && (t.EstadoTransmisionID == pGlob.Erronea.EstadoTransmisionID 
                                                       || t.EstadoTransmisionID == pGlob.PendienteDeEnvio.EstadoTransmisionID
                                                       || t.EstadoTransmisionID == pGlob.Enviado.EstadoTransmisionID)
                                                       && t.EstadoTransmisionID != pGlob.EnvioEnGrupo.EstadoTransmisionID
                                                       && t.Fecha >= FechaDesde && t.Fecha <= FechaHasta).ToList();
            foreach (Transmision t in trans)
            {
                t.EstadoTransmisionID = pGlob.PendienteDeEnvio.EstadoTransmisionID;
                Actualizar<Transmision>(t);
            }
        }

        
        public async Task<bool> RealizarTransmisionesControlesDiarios(object transmitiendo,DateTime FechaDesde,DateTime FechaHasta)
        {
            bool res = true;
            bool resAux = true;
            if (Monitor.TryEnter(transmitiendo))
            {
                try
                {
                    FechaDesde = FechaDesde.Date;
                    FechaHasta = FechaHasta.Date;
                    while (FechaDesde <= FechaHasta)
                    {
                        log.Debug($"Transmitiendo Control Diario {pGlob.Comercio} {FechaDesde}");
                        Transmision t = TransmisionControlDiario(pGlob.Comercio, FechaDesde, FechaDesde);
                        var transmitido = Transmitir(t, false);
                        resAux =  transmitido.Result;
                        FechaDesde = FechaDesde.AddDays(1); 
                        if (!resAux)
                        {
                            res = false;
                        }
                    }
                        
                    
                }
                catch (Exception ex)
                {
                    string mens = "Error en la transmision: " + ex.Message + Environment.NewLine;
                    if (ex.InnerException != null)
                        mens += " " + ex.InnerException.Message;
                    log.Debug(mens);
                    // throw new TransmisionException(mens);
                    //edu saco//   throw;   
                }
                finally
                {
                    Monitor.Exit(transmitiendo);
                }
            }
            else
            {
                return false;

            }
            return res;
        }

        public bool RealizarTransmisionesNovedades(object transmitiendo)
        {
            bool res = true;
            if (Monitor.TryEnter(transmitiendo))
            {
                try
                {
                    Transmision t = TransmisionControlDiario(pGlob.Comercio,DateTime.Now,DateTime.Now);
                    var transmitido = Transmitir(t,false);
                    res = transmitido.Result;
                }
                catch (Exception ex)
                {
                    string mens = "Error en la transmision: " + ex.Message + Environment.NewLine;
                    if (ex.InnerException != null)
                        mens += " " + ex.InnerException.Message;
                    log.Debug(mens);
                    // throw new TransmisionException(mens);
                    //edu saco//   throw;   
                }
                finally
                {
                    Monitor.Exit(transmitiendo);
                }
            }
            else
            {
                return false;

            }
            return res;
        }
        
      public async Task<bool> RealizarTransmisionesEnCierre(object transmitiendo)
        { 
            bool res = true;
            if (Monitor.TryEnter(transmitiendo))
            {
                try
                {
                    List<Transmision> trans = GetTransmisiones(pGlob.Empresa.EmpresaID.Value, t => t.CantTransmisiones <= pGlob.Configuracion.ReintentosTransmisiones &&
                                                t.EstadoTransmision.EstadoTransmisionID.Equals((pGlob.PendienteDeEnvio.EstadoTransmisionID)), p => p.OrderBy(s => s.TransmisionID)).ToList();
                    for (int i = 0; res && i < trans.Count; i++)
                    {
                        res = await Transmitir(trans[i],true);
                    }
                }
                catch (Exception ex)
                {
                    throw new TransmisionException("Error en la transmision al cerrar el programa:" + ex.Message);
                }
                finally
                {
                    Monitor.Exit(transmitiendo);
                }
            }
            else
            {
                return false;
            }
            return res;

        }

      public bool RetransmitirErroneas(object transmitiendo)
      {
          bool res = true;
          if (Monitor.TryEnter(transmitiendo))
          {
              try
              {
                  List<Transmision> trans = GetTransmisiones(pGlob.Empresa.EmpresaID.Value,
                                             t =>(t.CantTransmisiones <= pGlob.Configuracion.ReintentosTransmisiones && t.EstadoTransmisionID.Equals(pGlob.Erronea.EstadoTransmisionID))
                                             && (t.OperacionID != pGlob.TransArchivo.OperacionID), p => p.OrderBy(s => s.TransmisionID)).ToList();
                  for (int i = 0; res && i < trans.Count; i++)
                  {
                      var transmitido = Transmitir(trans[i], true);
                      res = transmitido.Result;
                  }
              }
              catch (Exception ex)
              {
                  string mens = "Error en la transmision: " + ex.Message + Environment.NewLine;
                  if (ex.InnerException != null)
                      mens += " " + ex.InnerException.Message;
                  log.Debug(mens);
                  // throw new TransmisionException(mens);
                  //edu saco//   throw;   
              }

              finally
              {
                  Monitor.Exit(transmitiendo);
              }
          }
          else
          {
              return false;

          }
          return res;
      }


      public bool RealizarTransmisionesSolicitudes(object transmitiendo)
      {
          bool res = true;
          if (Monitor.TryEnter(transmitiendo))
          {
              try
              {
                  List<Transmision> trans = GetTransmisiones(pGlob.Empresa.EmpresaID.Value,
                                             t => (t.EstadoTransmision.EstadoTransmisionID.Equals(pGlob.PendienteDeEnvio.EstadoTransmisionID) 
                                                || t.EstadoTransmision.EstadoTransmisionID.Equals(pGlob.Erronea.EstadoTransmisionID))  
                                                && (t.OperacionID != pGlob.TransArchivo.OperacionID) 
                                                && (t.OperacionID == pGlob.TransEnviarSolicitudDeFondo.OperacionID)
                                                && (t.CantTransmisiones <= pGlob.Configuracion.ReintentosTransmisionesSol), 
                                             p => p.OrderBy(s => s.TransmisionID)).ToList();
                  for (int i = 0; res && i < trans.Count; i++)
                  {
                      var transmitido = Transmitir(trans[i], true);
                      res = transmitido.Result;
                  }
              }
              catch (Exception ex)
              {
                  string mens = "Error en la transmision: " + ex.Message + Environment.NewLine;
                  if (ex.InnerException != null)
                      mens += " " + ex.InnerException.Message;
                  log.Debug(mens);
                  // throw new TransmisionException(mens);
                  //edu saco//   throw;   
              }

              finally
              {
                  Monitor.Exit(transmitiendo);
              }
          }
          else
          {
              return false;

          }
          return res;
      }
       
        public bool RealizarTransmisiones(object transmitiendo, int baseID)
        {
            bool res = true;
            if (Monitor.TryEnter(transmitiendo))
                {
                    string mens = "Inicio Transmision";
                    log.Debug(mens);
                    try
                    {

                         List<Transmision> trans = GetTransmisiones(baseID,
                                                    t =>(t.CantTransmisiones <= pGlob.Configuracion.ReintentosTransmisiones
                                                    && t.EstadoTransmision.EstadoTransmisionID.Equals(pGlob.PendienteDeEnvio.EstadoTransmisionID) )
                                                    && (t.OperacionID != pGlob.TransArchivo.OperacionID), p => p.OrderBy(s => s.TransmisionID)).ToList();
                        for (int i = 0; res && i < trans.Count; i++)
                        {
                            var transmitido = Transmitir(trans[i],true);
                            res = transmitido.Result;
                        }
                    }
                    catch (Exception ex)
                    {
                        mens = "Error en la transmision: " + ex.Message + Environment.NewLine;
                        if (ex.InnerException != null)
                            mens += " " + ex.InnerException.Message;
                        log.Debug(mens);
                       // throw new TransmisionException(mens);
                     //edu saco//   throw;   
                    }

                    finally 
                    {
                        Monitor.Exit(transmitiendo);
                    }
                }
            else
            { 
                return false;

            }
            return res;
        }

        public bool RealizarTransmisionesArchivo(object transmitiendo)
        {
            bool res = true;
            if (Monitor.TryEnter(transmitiendo))
            {
                try
                {
                    List<Transmision> trans = GetTransmisiones(pGlob.Empresa.EmpresaID.Value,t => t.EstadoTransmision.EstadoTransmisionID.Equals(pGlob.PendienteDeEnvio.EstadoTransmisionID)
                                                            && (t.OperacionID == pGlob.TransArchivo.OperacionID)
                                                            && t.CantTransmisiones <= pGlob.Configuracion.ReintentosTransmisionesErr, 
                                                            p => p.OrderBy(s => s.TransmisionID)).ToList();
                    for (int i = 0; res && i < trans.Count; i++)
                    {
                        var transmitido = Transmitir(trans[i],true);
                        res = transmitido.Result;
                    }
                }
                catch (Exception ex)
                {
                    string mens = "Error en la transmision: " + ex.Message + Environment.NewLine;
                    if (ex.InnerException != null)
                        mens += " " + ex.InnerException.Message;
                    log.Debug(mens);
                }

                finally
                {
                    Monitor.Exit(transmitiendo);
                }
            }
            else
            {
                return false;

            }
            return res;
        }    

        public bool HayTransmisionesPendientesHoy()
        {
            return GetTransmisiones(pGlob.Empresa.EmpresaID.Value,t => t.EstadoTransmisionID == pGlob.PendienteDeEnvio.EstadoTransmisionID).
                                   Where(t => t.Fecha.Date == DateTime.Now.Date).Count() > 0 ? true : false;                     
        }
        
        public async Task<bool> ChequearTransmisionesAntesDeCerrar(object transmitiendo)
        {
            return await RealizarTransmisionesEnCierre(transmitiendo);
        }
        


      /* public  bool RealizarTransmisiones(Boolean transmitiendo)
        {
                IEnumerable<Transmision> trans = GetTransmisiones(t => t.EstadoTransmision.EstadoTransmisionID.Equals(
                                (pGlob.PendienteDeEnvio.EstadoTransmisionID)), p => p.OrderBy(s => s.TransmisionID));
                foreach (Transmision tran in trans)
                {
                    var transmitido = Transmitir(tran);
                    if (!transmitido.Result)
                    {
                        transmitiendo = false;
                        return false;                        
                    }
                }
                return true;
         }          */ 
           
        public async Task<bool> Transmitir(Transmision tran,bool grabaTransmision)
        {
            if (tran.OperacionID != pGlob.TransControlDiario.OperacionID)
            {
                tran.CantTransmisiones = ++tran.CantTransmisiones ?? 1;
                tran.UltimaTransmision = DateTime.Now;
                ActualizarTransmision(tran);
                Grabar(tran.EmpresaID);
            }
          
            if (await tran.Operacion.Enviar(this, tran))
                {
                log.Info(String.Format("Transmitiendo transmision N°:{0}-Entidad ID:{1}-Entidad ID2:{2}-Entidad ID3:{3}",
                                                                        tran.TransmisionID, tran.EntidadID, tran.EntidadID2, tran.EntidadID3));
                    if (grabaTransmision)
                    {
                        tran.EstadoTransmisionID = pGlob.Enviado.EstadoTransmisionID;
                        ActualizarTransmision(tran);
                        Grabar(tran.EmpresaID);
                    }
                    return true;
                }
                else
                {
                    log.Info(String.Format("Error transmision N°:{0}-Entidad ID:{1}-Entidad ID2:{2}-Entidad ID3:{3}",
                                                                        tran.TransmisionID, tran.EntidadID, tran.EntidadID2, tran.EntidadID3));
                    if (grabaTransmision)
                    {
                        tran.EstadoTransmisionID = pGlob.Erronea.EstadoTransmisionID;
                        ActualizarTransmision(tran);
                        Grabar(tran.EmpresaID);
                    }
                    return false;
                }           
        }

        /* Autorizaciones */
        public IEnumerable<Autorizacion> GetAutorizaciones(Expression<Func<Autorizacion, bool>> filter = null,
                              Func<IQueryable<Autorizacion>, IOrderedQueryable<Autorizacion>> orderBy = null,
                              string includeProperties = "")
        {
            return dal.GetAutorizaciones(filter, orderBy, includeProperties);
        }

        public Autorizacion GetAutorizacionByID(object id)
        {
            return dal.GetAutorizacionByID(id);
        }

        public void AgregarAutorizacion(Autorizacion aut)
        {
            dal.AgregarAutorizacion(aut);
        }

        public void BorrarAutorizacion(object id)
        {
            dal.BorrarAutorizacion(id);
        }

        public void BorrarAutorizacion(Autorizacion aut)
        {
            dal.BorrarAutorizacion(aut);
        }

        public void ActualizarAutorizacion(Autorizacion aut)
        {
            dal.ActualizarAutorizacion(aut);
        }

        public BindingList<Autorizacion> AutorizacionBindingList()
        {
            return dal.AutorizacionBindingList();
        }

        public void VisualizarOP(SolicitudFondo sf)
        {
            MemoryStream pdfAut;
            string nombre;
            Autorizacion aut = GetAutorizaciones(a => a.EmpresaID == sf.EmpresaID
                                                && a.ComercioID == sf.ComercioID
                                                && a.SolicitudFondoID == sf.SolicitudFondoIDRemoto).FirstOrDefault();
            if (aut != null)
            {
                if (sf.ConceptoFondosID.Equals(pGlob.ExtBan.ConceptoFondosID))
                {
                     pdfAut = PDF.CrearAutorizacionExtBan(aut.EmpresaNombre.ToUpper(),aut.ConceptoFondosNombre,aut.TipoSolicitudNombre,aut.ComercioID.Value,aut.ComercioNombreNum,
                                                                        aut.AutorizacionID.Value,aut.OrdenDePagoID,aut.SolicitudFondoFechaPago,aut.ChequeNumCheque,
                                                                        aut.CuentaBancaria, aut.CuentaContable, aut.Importe, aut.Observaciones, pGlob.ConfLocal.rutaPdfAutorizacionExtBan);    
                }
                else 
                {
                    pdfAut = PDF.CrearAutorizacion(aut.EmpresaNombre.ToUpper(), aut.ConceptoFondosNombre, aut.TipoSolicitudNombre, aut.ComercioID.Value,aut.ComercioNombreNum,
                                                    aut.AutorizacionID.Value, aut.OrdenDePagoID, aut.SolicitudFondoFechaPago, aut.SolicitudFondoFechaPago, aut.NumCajaImpCont,
                                                    aut.Importe, String.Empty,pGlob.ConfLocal.rutaPdfAutorizacionRetCob);
                }
                nombre = String.Format("{4}Autorizacion-{0}-{1}-{2}-{3}.pdf",
                                        String.Format("{0:ddMMyyyy}", sf.FechaPago),
                                        sf.ComercioID, sf.Comercio.Nombre, sf.TipoSolicitud.Nombre, pGlob.ConfLocal.rutaPdfAutorizacionGuardado);
                IO.SaveMemoryStreamToFile(nombre,pdfAut);
                Process.Start(nombre);
            }

        }
        /* Formulario OP */
     /*   public MemoryStream ObtenerAutorizacion(Empleado empl)
        {
            Autorizacion aut = Autorizacion.ObtenerAutorizacion(emp_id, null, solfon_id, null, null, com_id, null, null);
            if (conceptoFondos.id.Equals(ConceptoFondos.extBan.id))
            {
                TransferenciasDepositos trandep = TransferenciasDepositos.ObtenerTransferenciaDeposito(emp_id, trandep_id);
                CuentaBancaria cb = CuentaBancaria.ObtenerCuentaBancaria(trandep.emp_id, trandep.cuenta_destino_ccb_id, trandep.cuenta_destino_cb_id, null, null, null, null);
                Cheque cheque = Cheque.ObtenerCheque(trandep.emp_id, trandep.cb_id_cheques, trandep.ccb_id_cheques, trandep.cheq_num_chequera, trandep.che_num_cheque, null, null);
                return PDF.CrearAutorizacionExtBan(emp.nombre.ToUpper(), conceptoFondos.nombre.ToUpper(), tipoSolicitud.tps_nombre, String.Format("{0}-{1}", com.com_id, com.com_nombre),
                                              (long)aut.aut_id, (long)ordpag_id, aut.SolicitudFondo.solfon_fecha_pago.Value, cheque.che_num_cheque, cb.ToString(), cb.cbe_cuenta_contable, (decimal)solfon_importe, String.Empty);
            }
            else
            {
                return PDF.CrearAutorizacion(emp.nombre.ToUpper(), conceptoFondos.nombre.ToUpper(), tipoSolicitud.tps_nombre, String.Format("{0}-{1}", com.com_id, com.com_nombre),
                                              (long)aut.aut_id, (long)ordpag_id, aut.SolicitudFondo.solfon_fecha_pago.Value, aut.SolicitudFondo.solfon_fecha_pago.Value, com.com_num_caja_imp_cont, (decimal)solfon_importe, String.Empty);
            }

        }*/


        /* Bancos */



        /* Cuentas Bancarias*/

        public List<CuentaBancaria> GetCuentasBancariasParaDeposito(Comercio com)
        {
            List<CuentaBancaria> Lista = GetCuentasBancariasCentral(com);
            Lista.AddRange(GetCuentasBancariasReceptoria(com));
            return Lista;
        }


        public List<CuentaBancaria> GetCuentasBancariasCentral(Comercio com)
        {
            return Get<CuentaBancaria>(c => c.EmpresaID == com.EmpresaID && c.ComercioID == 999).ToList();
        }

        public List<CuentaBancaria> GetCuentasBancariasReceptoria(Comercio com)
        {
            return Get<CuentaBancaria>(c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID).ToList(); 
        }

         public void CargarCuentasBancarias(List<CuentaBancaria> cbs)
         {
             AgregarRange<CuentaBancaria>(cbs);
         }


        public CuentaBancaria GetCuentaDebitoDirecto(Comercio com)
         {
             return GetCuentasBancariasCentral(com).Where(c => c.DebitoDirecto).FirstOrDefault();
         }

        public void CargarDummyInfo()
        {
            ///*Bancos*/

            //List<Banco> bancos = new List<Banco>();
            //Banco ban = new Banco();
            //ban.BancoID = 1;
            //ban.Nombre = "NACION";
            //ban.Descripcion = "NACION";
            //bancos.Add(ban);

            //ban = new Banco();
            //ban.BancoID = 2;
            //ban.Nombre = "FRANCES";
            //ban.Descripcion = "FRANCES";
            //bancos.Add(ban);

            //AgregarRange<Banco>(bancos);

            ///*Sucursales */

            //List<SucursalBanco> Sucbancos = new List<SucursalBanco>();

            //SucursalBanco SucursalBanco = new SucursalBanco();
            //SucursalBanco.BancoID = 1;
            //SucursalBanco.Nombre = "SUC NaCION";
            //SucursalBanco.Descripcion = "SUC NACION";
            //Sucbancos.Add(SucursalBanco);

            //SucursalBanco = new SucursalBanco();
            //SucursalBanco.BancoID = 2;
            //SucursalBanco.Nombre = "SUC FRANCES";
            //SucursalBanco.Descripcion = "SUC FRANCES";
            //Sucbancos.Add(SucursalBanco);

            //AgregarRange<SucursalBanco>(Sucbancos);

            /* Cuentas Bancarias */
            List<CuentaBancaria> cbs = new List<CuentaBancaria>();
            CuentaBancaria cb = new CuentaBancaria();
            cb.EmpresaID = 1;
            cb.ComercioID = 999;
            cb.CuentaBancariaID = 999;
            cb.BancoID = 1;
            cb.SucursalBancoID = 1;
            //cb.ClaseCuentaBancariaID = 1;
            cb.EmiteCheque = true;
            cb.MonedaID = 1;
            cb.NumCuenta = "999999/9";
            cb.TipoCuentaBancariaID = 1;
            cbs.Add(cb);           


            /* Chequeras */
            ObservableListSource<Chequera> chequeras = new ObservableListSource<Chequera>();
            Chequera chequera = new Chequera();
            chequera.ChequeraID = "1";
            chequera.EstadoID = 5;
            chequeras.Add(chequera);

            /* Cheques */
            ObservableListSource<Cheque> cheques = new ObservableListSource<Cheque>();
            Cheque cheque = new Cheque();
            cheque.EstadoID = 53;
            cheque.Monto = 0;
            cheque.ChequeID = "100051";
            cheques.Add(cheque);
            
            cheque = new Cheque();
            cheque.EstadoID = 53;
            cheque.Monto = 0;
            cheque.ChequeID = "100052";
            cheques.Add(cheque);

            cheque = new Cheque();
            cheque.EstadoID = 53;
            cheque.Monto = 0;
            cheque.ChequeID = "100053";
            cheques.Add(cheque);

            cheque = new Cheque();
            cheque.EstadoID = 53;
            cheque.Monto = 0;
            cheque.ChequeID = "100054";
            cheques.Add(cheque);

            cheque = new Cheque();
            cheque.EstadoID = 53;
            cheque.Monto = 0;
            cheque.ChequeID = "100055";
            cheques.Add(cheque);

            chequera.Cheques = cheques;
            cb.Chequeras = chequeras;
            AgregarRange<CuentaBancaria>(cbs);

        }
        /* Bonificadas */
        public bool PuedeBonificar(Credito cred,int ToleranciaBoni, int NumCuotaHasta)
        {
            var cuotas  = cred.Cuotas.Where(c=> c.CuotaID <= NumCuotaHasta);
            return !cuotas.Any(c => DiasMora(c) > ToleranciaBoni);            
        }

        public int Calcula_dias_mora(DateTime fVenci, DateTime fHoy)
        {
            TimeSpan ndias = fHoy - fVenci;
            return ndias.Days;
        }

        public int DiasMora(Cuota cuota)
        {
            DateTime FechaUltimoPago;
            if (cuota.FechaUltimoPago == null)
                FechaUltimoPago = DateTime.Now;
            else
                FechaUltimoPago = cuota.FechaUltimoPago.Value;
            return Calcula_dias_mora(cuota.FechaVencimiento, FechaUltimoPago);
        }

        /* Chequeras y Cheques */

        public void CargarChequeras(List<Chequera> chequeras)
        {
            AgregarRange<Chequera>(chequeras);
        }

        /*Cuenta Corriente*/
        public void ActualizarCCDesdeRemoto(ImputacionCuentaCorrienteRestModel iccRM)
        {
            foreach (CuentaCorrienteRestModel icc in iccRM.MovimientosCC)
            {
                CuentaCorriente cc = Get<CuentaCorriente>(icc.EmpresaID.Value, c => c.EmpresaID == icc.EmpresaID
                                        && c.ComercioID == icc.ComercioID && c.CuentaCorrienteID == icc.IDRemoto).SingleOrDefault();
                if (cc != null)
                {
                    cc.IDRemoto = icc.CuentaCorrienteID; // Al no usar automapper acá, va así, es para evitar una llamada a automapper
                    ActualizarTransaccional<CuentaCorriente>(cc);
                    Grabar(icc.EmpresaID.Value);
                }                
            }
            
        }



        public List<CuentaCorrienteComun> CuentaCorriente(int GestionEmpresaID, int ComercioID, DateTime FechaInicial, DateTime FechaFinal)
        {
            CuentaCorrienteComun cccSaldo = CuentaCorrienteArrastre(GestionEmpresaID, ComercioID, FechaInicial);
            List<CuentaCorrienteComun> cccs = CuentaCorrienteEntreFechas(GestionEmpresaID, ComercioID, FechaInicial, FechaFinal, cccSaldo.Saldo);
            cccs.Add(cccSaldo);
            cccs = cccs.OrderBy(c => c.Fecha).ToList();
            return cccs;
        }

        public List<Cap> CapsPendientes(Comercio com)
        {
            return Get<Cap>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID
                    && c.ComercioID == com.ComercioID && c.Saldo > 0).ToList();
        }

        public int CantCAPPendientes(Comercio com)
        {
            int cant = Get<Cap>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID
                    && c.ComercioID == com.ComercioID && c.Saldo > 0).Count();
            return cant;
        }

        public decimal RetenidoPorCap(Comercio com)
        {
            Cap cap = Get<Cap>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID 
                                   && c.Saldo > 0, o => o.OrderByDescending(c => c.Fecha), "", 1).FirstOrDefault();
            if (cap != null)
                if (cap.SolicitudFondo != null)
                    if (cap.SolicitudFondo.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID)
                        return cap.Total;
                    else
                     return 0;
            return 0;

            //decimal? ret = Get<Cap>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID
            //                       && c.Saldo > 0).Sum(c => (decimal?)c.Saldo);
            //if (ret != null)
            //    return ret.Value;
            //else
            //    return 0;
        }

        public int CantFFPendientes(Comercio com)
        {
            int cant = Get<FF>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID
                    && c.ComercioID == com.ComercioID  && !c.Pagado).Count();
            return cant;
        }

        public decimal RetenidoPorFF(Comercio com)
        {
            FF ff = Get<FF>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID
                             && c.ComercioID == com.ComercioID && !c.Pagado, o => o.OrderByDescending(c => c.Fecha), "", 1).FirstOrDefault();
            if (ff != null)
                if (ff.SolicitudFondo != null)
                    if (ff.SolicitudFondo.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID)
                        return ff.MontoFF;
                    else
                        return 0;
            return 0;
        }

        public decimal FFPendienteReposicion(Comercio com)  
        {
            decimal? ret = Get<FF>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID
                                    && !c.Pagado).Sum(c => (decimal?)c.AReponer);
            if (ret != null)
                return ret.Value;
            else
                return 0;
        }

         public decimal DisponibleParaVenta(Comercio com,DateTime Fecha)
        {
            DateTime FechaInicial = Fecha.Date;
            DateTime FechaFinal = FechaInicial.AddDays(1).AddTicks(-1);
            decimal? Importe = Get<SolicitudFondo>(com.EmpresaID, c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID
                                    && (c.TipoSolicitudID == pGlob.tsVenta.TipoSolicitudID || c.TipoSolicitudID == pGlob.tsVentaAnticipada.TipoSolicitudID)
                                    && c.FechaPago >= FechaInicial && c.FechaPago <= FechaFinal ).Where(c=>(EsSolfonEstadoConfirmado(c))).Sum(c => (decimal?)c.Importe);
            if (Importe != null)
                return Importe.Value;
            else
                return 0;
        }

        public decimal AutorizadoAVender(Comercio com, DateTime Fecha)
        {
            Fecha = Fecha.Date;
            DateTime FechaFinal = Fecha.AddDays(1).AddTicks(-1);
            decimal? Autorizado = DisponibleParaVenta(com, Fecha);
            decimal? Venta = GetCreditosEntreFechas(com, Fecha, FechaFinal).Sum(c=>(decimal?)c.ValorNominal);
                      
            if (Autorizado == null)
                Autorizado = 0;

            if (Venta == null)
                Venta = 0;

            decimal Disponible = Autorizado.Value - Venta.Value;
            return Disponible;
        }

        public decimal AutorizadoAVender(Comercio com)
        {
            DateTime Hoy = DateTime.Now;
            DateTime Ayer = Hoy.AddDays(-1);
            
            decimal DisponibleAyer = AutorizadoAVender(com, Ayer);
            decimal DisponibleHoy = AutorizadoAVender(com, Hoy);
            return DisponibleAyer + DisponibleHoy;
        }

        public bool EsSolfonEstadoConfirmado(SolicitudFondo solfon)
        {
            if (solfon.ConceptoFondosID == pGlob.ExtBan.ConceptoFondosID)
                return solfon.EstadoID == pGlob.SolicitudFondoConfirmadaYFonRet.EstadoID;
            if (solfon.ConceptoFondosID == pGlob.RetCob.ConceptoFondosID)
                return solfon.EstadoID == pGlob.SolicitudFondoConfirmada.EstadoID;
            return false;
        }

        public decimal VentaAutorizadaHasta(Comercio Com, DateTime FechaDesde, DateTime FechaHasta)
        {
            FechaHasta = FechaDesde.AddDays(1).AddTicks(-1);
            decimal? Importe = Get<SolicitudFondo>(Com.EmpresaID, c => c.EmpresaID == Com.EmpresaID && c.ComercioID == Com.ComercioID
                                    && (c.TipoSolicitudID == pGlob.tsVenta.TipoSolicitudID || c.TipoSolicitudID == pGlob.tsVentaAnticipada.TipoSolicitudID)
                                    && c.FechaPago >= FechaDesde  && c.FechaPago <= FechaHasta).Where(c => (EsSolfonEstadoConfirmado(c))).Sum(c => (decimal?)c.Importe);
            if (Importe != null)
                return Importe.Value;
            else
                return 0;
        }

        public decimal VentaHasta(Comercio Com, DateTime FechaDesde,DateTime FechaHasta)
        {
            decimal? Importe = Get<Credito>(Com.EmpresaID, c => c.EmpresaID == Com.EmpresaID && c.ComercioID == Com.ComercioID
                                            && FechaDesde >= c.FechaSolicitud && c.FechaSolicitud <= FechaHasta).Sum(c => (decimal?)c.ValorNominal);
            if (Importe != null)
                return Importe.Value;
            else
                return 0;
        }

        public decimal DisponibleVenta(Comercio Com, DateTime FechaDesde, DateTime FechaHasta)
        {
            return VentaAutorizadaHasta(Com, FechaDesde, FechaHasta) - VentaHasta(Com, FechaDesde, FechaHasta);
        }

        public decimal VentaAutorizadaHasta(Comercio Com,  DateTime FechaHasta)
        {
           decimal? Importe = Get<SolicitudFondo>(Com.EmpresaID, c => c.EmpresaID == Com.EmpresaID && c.ComercioID == Com.ComercioID
                                    && (c.TipoSolicitudID == pGlob.tsVenta.TipoSolicitudID || c.TipoSolicitudID == pGlob.tsVentaAnticipada.TipoSolicitudID)
                                     && c.FechaPago <= FechaHasta).Where(c => (EsSolfonEstadoConfirmado(c))).Sum(c => (decimal?)c.Importe);
            if (Importe != null)
                return Importe.Value;
            else
                return 0;
        }

        public decimal VentaHasta(Comercio Com, DateTime FechaHasta)
        {
            decimal? Importe = Get<Credito>(Com.EmpresaID, c => c.EmpresaID == Com.EmpresaID && c.ComercioID == Com.ComercioID
                                             && c.FechaSolicitud <= FechaHasta).Sum(c => (decimal?)c.ValorNominal);
            if (Importe != null)
                return Importe.Value;
            else
                return 0;
        }

        public decimal DisponibleVenta(Comercio Com, DateTime FechaHasta)
        {
            CuentaCorrienteCorte ccc = CuentaCorrienteCorte(Com.EmpresaID, Com.ComercioID, FechaHasta);
            if (ccc!=null)
            {
                DateTime Desde = ccc.Fecha;
                return VentaAutorizadaHasta(Com, Desde, FechaHasta) - VentaHasta(Com, Desde, FechaHasta);
            }
            return VentaAutorizadaHasta(Com, FechaHasta) - VentaHasta(Com, FechaHasta);
        }

        public CuentaCorrienteCorte CuentaCorrienteCorte(int GestionEmpresaID, int ComercioID, DateTime Fecha)
        {
            CuentaCorrienteCorte ccc = Get<CuentaCorrienteCorte>(GestionEmpresaID, c => c.EmpresaID == GestionEmpresaID && c.ComercioID == ComercioID
                                                                && c.Fecha <= Fecha, o => o.OrderByDescending(c => c.Fecha), "", 1).FirstOrDefault();
            return ccc;

        }

        public CuentaCorrienteComun CuentaCorrienteArrastre(int GestionEmpresaID, int ComercioID, DateTime FechaHasta)
        {
            decimal? saldo = 0;
            decimal? saldoCorte = 0;
            FechaHasta = FechaHasta.Date.AddTicks(-1);
            DateTime DiaSiguienteCorte;
            //decimal? saldo = GetDalFinan(GestionEmpresaID).iFinanContext.imputacion_cuenta_corriente
            //                            .Where(c => c.emp_id == GestionEmpresaID && c.com_id == ComercioID && c.icc_fecha_imputacion <= FechaHasta)
            //                            .Sum(c=>c.ImporteSignado);

            CuentaCorrienteCorte ccc = CuentaCorrienteCorte(GestionEmpresaID, ComercioID, FechaHasta);
            if (ccc == null)
            {
                saldo = Get<CuentaCorriente>(GestionEmpresaID, c => c.EmpresaID == GestionEmpresaID && c.GestionID == ComercioID
                                                              && c.Fecha <= FechaHasta).Sum(c => c.ImporteSignado);
                saldoCorte = 0;
            }
            else
            {
                DiaSiguienteCorte = ccc.Fecha.Date.AddDays(1);
                saldo = Get<CuentaCorriente>(GestionEmpresaID, c => c.EmpresaID == GestionEmpresaID && c.GestionID == ComercioID
                                                              && c.Fecha >= DiaSiguienteCorte && c.Fecha <= FechaHasta)
                                                              .Sum(c => c.ImporteSignado);
                saldoCorte = ccc.Saldo;
            }


            if (saldo == null)
                saldo = 0;
            saldo += saldoCorte;

            CuentaCorrienteComun cc = new CuentaCorrienteComun();
            cc.Fecha = FechaHasta;
            cc.Debe = 0;
            cc.Haber = 0;
            cc.Saldo = saldo.Value;


            return cc;
        }

        public CuentaCorrienteDiaria CuentaCorrienteDiaria(int GestionEmpresaID, int ComercioID, DateTime FechaInicial, DateTime FechaFinal)
        {
            CuentaCorrienteDiaria ccd = new CuentaCorrienteDiaria();
            FechaInicial = FechaInicial.Date;
            FechaFinal = FechaFinal.Date.AddDays(1).AddTicks(-1);
            List<CuentaCorriente> movs = new List<CuentaCorriente>();



            CuentaCorrienteComun cccSaldo = CuentaCorrienteArrastre(GestionEmpresaID, ComercioID, FechaInicial);
            ccd.Arrastre = cccSaldo.Saldo;

            //CuentaCorrienteDiariaMovs Arrastre = new CuentaCorrienteDiariaMovs();
            //Arrastre.Nombre = "Arrastre";
            //Arrastre.Movimientos = new List<CuentaCorrienteMovsAgrup>();
            //CuentaCorrienteMovsAgrup ccmaArrastre = new CuentaCorrienteMovsAgrup();

            //Arrastre.Movimientos

            movs = Get<CuentaCorriente>(GestionEmpresaID, c => c.EmpresaID == GestionEmpresaID && c.GestionID == ComercioID
                                                   && c.Fecha >= FechaInicial && c.Fecha <= FechaFinal,
                                                   q => q.OrderBy(c => c.Fecha).ThenBy(c => c.TipoMovimientoID)).ToList();
            List<CuentaCorriente> movsDebe = movs.Where(m => m.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Ingreso.ClaseMovimientoID).ToList();
            List<CuentaCorriente> movsHaber = movs.Where(m => m.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Egreso.ClaseMovimientoID).ToList();
//            decimal Saldo = arrastre;

            CuentaCorrienteDiariaMovs movsDebeXtpm = new CuentaCorrienteDiariaMovs();
            movsDebeXtpm.Nombre = "INGRESOS";
            movsDebeXtpm.Movimientos = movsDebe.GroupBy(f => f.TipoMovimientoID).Select(grp =>
                                                    new CuentaCorrienteMovsAgrup
                                                    {
                                                        TipoMovimientoID = grp.Key.Value,
                                                        Nombre = grp.Max(c => c.TipoMovimiento.Nombre),
                                                        Fecha = grp.Max(c => c.Fecha),
                                                        SaldoMov = grp.Sum(c => c.ImporteSignado)
                                                    }).ToList();

            CuentaCorrienteMovsAgrup ccmaIng = new CuentaCorrienteMovsAgrup();
            ccmaIng.Nombre = "Total";
            ccmaIng.SaldoMov = movsDebeXtpm.Movimientos.Sum(c => c.SaldoMov);
            movsDebeXtpm.Movimientos.Add(ccmaIng);

            CuentaCorrienteDiariaMovs movsHaberXtpm = new CuentaCorrienteDiariaMovs();
            movsHaberXtpm.Nombre = "EGRESOS";
            movsHaberXtpm.Movimientos = movsHaber.GroupBy(f => f.TipoMovimientoID).Select(grp =>
                                               new CuentaCorrienteMovsAgrup
                                               {
                                                   TipoMovimientoID = grp.Key.Value,
                                                   Nombre = grp.Max(c => c.TipoMovimiento.Nombre),
                                                   Fecha = grp.Max(c => c.Fecha),
                                                   SaldoMov = grp.Sum(c => c.ImporteSignado)
                                               }).ToList();
            CuentaCorrienteMovsAgrup ccmaEG = new CuentaCorrienteMovsAgrup();
            ccmaEG.Nombre = "Total";
            ccmaEG.SaldoMov = movsHaberXtpm.Movimientos.Sum(c => c.SaldoMov);
            movsHaberXtpm.Movimientos.Add(ccmaEG);

            ccd.Movimientos.Add(movsDebeXtpm);
            ccd.Movimientos.Add(movsHaberXtpm);
            return ccd;
        }



        public List<CuentaCorrienteComun> CuentaCorrienteEntreFechas(int GestionEmpresaID, int ComercioID, DateTime FechaInicial, DateTime FechaFinal, decimal arrastre)
        {
            FechaInicial = FechaInicial.Date;
            FechaFinal = FechaFinal.Date.AddDays(1).AddTicks(-1);
            CuentaCorrienteComun ccc;
            List<CuentaCorrienteComun> cccs = new List<CuentaCorrienteComun>();
            List<CuentaCorriente> movs = new List<CuentaCorriente>();
            movs = Get<CuentaCorriente>(GestionEmpresaID, c => c.EmpresaID == GestionEmpresaID && c.GestionID == ComercioID
                                                    && c.Fecha >= FechaInicial && c.Fecha <= FechaFinal,
                                                    q => q.OrderBy(c => c.Fecha).ThenBy(c => c.TipoMovimientoID)).ToList();
            List<CuentaCorriente> movsDebe = movs.Where(m => m.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Ingreso.ClaseMovimientoID).ToList();
            List<CuentaCorriente> movsHaber = movs.Where(m => m.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Egreso.ClaseMovimientoID).ToList();
            decimal Saldo = arrastre;


            int dias = (FechaFinal.Date - FechaInicial.Date).Days;
            DateTime Fecha = FechaInicial;
            for (int i = 0; i <= dias; i++)
            {
                decimal? sumaDebe;
                decimal? sumaHaber;

                List<CuentaCorriente> MovsDebeFecha = movsDebe.Where(md => md.Fecha.Date == Fecha.Date).ToList();
                List<CuentaCorriente> MovsHaberFecha = movsHaber.Where(mh => mh.Fecha.Date == Fecha.Date).ToList();

                List<CuentaCorrienteMovsAgrup> movsDebeXtpm = MovsDebeFecha.GroupBy(f => f.TipoMovimientoID).Select(grp =>
                                                    new CuentaCorrienteMovsAgrup
                                                    {
                                                        TipoMovimientoID = grp.Key.Value,
                                                        Nombre = grp.Max(c => c.TipoMovimiento.Nombre),
                                                        Fecha = grp.Max(c => c.Fecha),
                                                        SaldoMov = grp.Sum(c => c.ImporteSignado)
                                                    }).ToList();

                List<CuentaCorrienteMovsAgrup> movsHaberXtpm = MovsHaberFecha.GroupBy(f => f.TipoMovimientoID).Select(grp =>
                                                   new CuentaCorrienteMovsAgrup
                                                   {
                                                       TipoMovimientoID = grp.Key.Value,
                                                       Nombre = grp.Max(c => c.TipoMovimiento.Nombre),
                                                       Fecha = grp.Max(c => c.Fecha),
                                                       SaldoMov = grp.Sum(c => c.ImporteSignado)
                                                   }).ToList();


                sumaDebe = MovsDebeFecha.Sum(c => c.ImporteSignado);
                sumaHaber = MovsHaberFecha.Sum(c => c.ImporteSignado);

                if (sumaDebe == null)
                    sumaDebe = 0;
                if (sumaHaber == null)
                    sumaHaber = 0;


                ccc = new CuentaCorrienteComun();
                ccc.Fecha = Fecha;
                ccc.Debe = sumaDebe.Value;
                ccc.Haber = sumaHaber.Value;
                ccc.SaldoDiario = ccc.Debe + ccc.Haber;
                Saldo += ccc.SaldoDiario;
                ccc.Saldo += Saldo;

                ccc.MovimientosDebe = MovimientosAString(movsDebeXtpm);
                ccc.MovimientosHaber = MovimientosAString(movsHaberXtpm);
                cccs.Add(ccc);

                Fecha = Fecha.AddDays(1);
            }
            return cccs;


            //var agrupMovsFecha = movs.GroupBy(c=>c.icc_fecha_imputacion.Value.Date)
            //            .Select(grp => new CuentaCorrienteComun{
            //                                Fecha = grp.Key.Date,
            //                                Saldo = grp.Sum(i=>i.ImporteSignado).Value
            //                                });



            ////var agrupMovsFecha = movs.GroupBy(c=>c.icc_fecha_imputacion.Value.Date)
            ////            .Select(grp => String.Format("{0} {1}: ${2:##.##}",grp.Sum(i=>i.ImporteSignado)));


            ////var agrupMovs = movs.GroupBy(c=> new {c.icc_fecha_imputacion.Value.Date,c.tpm_id,c.tipos_movimientos.Nombre})
            ////            .Select(grp => String.Format("{0} {1}: ${2:##.##}",grp.Key.tpm_id,grp.Key.Nombre,grp.Sum(i=>i.ImporteSignado)));


            //List<imputacion_cuenta_corriente> movsDebe = movs.Where(m=>m.tipos_movimientos.clase_movimiento.cm_id == pGlob.Ingreso.cm_id).ToList();
            //var agrupDebe = movsDebe.GroupBy(c=> new {c.icc_fecha_imputacion.Value.Date,c.tpm_id,c.tipos_movimientos.Nombre})
            //            .Select(grp => new CuentaCorrienteComun{
            //                                Fecha = grp.Key.Date,
            //                                Debe = grp.Sum
            //                                Saldo = grp.Sum(i=>i.ImporteSignado).Value
            //                                });


            //var agrupDebe = movsDebe.GroupBy(c=> new {c.icc_fecha_imputacion.Value.Date,c.tpm_id,c.tipos_movimientos.Nombre})
            //            .Select(grp => String.Format("{0} {1}: ${2:##.##}",grp.Key.tpm_id,grp.Key.Nombre,grp.Sum(i=>i.ImporteSignado)));

            //List<imputacion_cuenta_corriente> movsHaber = movs.Where (m=>m.tipos_movimientos.clase_movimiento.cm_id == pGlob.Egreso.cm_id).ToList();
            //var agrupHaber = movsHaber.GroupBy(c=> new {c.icc_fecha_imputacion.Value.Date,c.tpm_id,c.tipos_movimientos.Nombre})
            //            .Select(grp => String.Format("{0} {1}: ${2:##.##}",grp.Key.tpm_id,grp.Key.Nombre,grp.Sum(i=>i.ImporteSignado)));


            //var a = from ad in agrupDebe
            //        join ah in agrupHaber
            //        on ad.

        }

        private List<string> MovimientosAString(List<CuentaCorriente> movs)
        {
            return movs.Select(m => String.Format("{0}: ${1}", m.TipoMovimiento.Nombre, m.ImporteSignado)).ToList();
        }

        private List<string> MovimientosAString(List<CuentaCorrienteMovsAgrup> movs)
        {
            return movs.Select(m => String.Format("{0}: ${1}", m.Nombre, m.SaldoMov)).ToList();
        }
        
        /*Cuenta Corriente de Comercio Funcional*/
        public List<CuentaCorrienteComun> SuperCuentaCorriente(int GestionEmpresaID,int ComercioID,DateTime FechaInicial,DateTime FechaFinal)
        {
            decimal SumaAvisos = 0;
            decimal SumaBajaAvisos = 0;
            decimal SumaCobranzas = 0;
            decimal SumaNotasCD = 0;
            decimal SumaDepositosComer = 0;
            decimal SumaDepositosFinan = 0;
            decimal SumaRecibosProvisoriosFinan = 0;
            decimal SumaRecibosProvisoriosComer = 0;
            decimal SumaCompensaciones = 0;
            decimal SaldoAcumulado = 0;
            
            CuentaCorrienteSaldos ccs = new CuentaCorrienteSaldos();
            CuentaCorrienteComun ccc;
            //CuentaCorrienteDetalle ccd;
            //CuentaCorrienteMovs ccdm;
            List<CuentaCorrienteComun> lccc = new List<CuentaCorrienteComun>();

            FechaInicial = FechaInicial.Date;
            FechaFinal = FechaFinal.Date.AddDays(1).AddTicks(-1);
            
            /*Hasta la Fecha Inicial*/
            var avi = dal.context.Creditos.Where(c => c.EmpresaID == GestionEmpresaID &&  c.ComercioID == ComercioID 
                                                 && c.FechaSolicitud < FechaInicial).ToList();
            ccs.SumaAviso = avi.Sum(c => CalcularAvisoDePago(c));

            var aviBaja = dal.context.CreditoAnulado.Where(c => c.EmpresaID == GestionEmpresaID &&  c.ComercioID == ComercioID 
                                                          && c.FechaComercioAnula < FechaInicial).ToList();
            ccs.SumaAvisoBajas = aviBaja.Sum(c => CalcularAvisoDePago(c));
           
            ccs.SumaCobranzas = dal.context.Cobranzas.Where(c => c.GestionEmpresaID == GestionEmpresaID && c.GestionID == ComercioID 
                                                            && c.FechaPago < FechaInicial).ToList().Sum(c => c.ImportePago);
            
            ccs.SumaNotasCD = dal.context.NotasCD.Where(c => c.EmpresaID == GestionEmpresaID && c.GestionID == ComercioID 
                                                        && c.Fecha < FechaInicial).ToList().Sum(c => c.Importe); 

            ccs.SumaDepositosComer = dal.context.TransferenciasDepositos.Where(c => c.ComercioEmpresaID == GestionEmpresaID && c.ComercioID == ComercioID
                                                                                && c.Fecha < FechaInicial && c.TipoTransferenciaDepositoID == pGlob.ttdComercio.TipoTransferenciaDepositoID && c.EstadoID == pGlob.Acreditado.EstadoID).ToList().Sum(c => c.Importe).Value;
           
            ccs.SumaDepositosFinan = dal.context.TransferenciasDepositos.Where(c => c.ComercioEmpresaID == GestionEmpresaID && c.ComercioID == ComercioID
                                                                                && c.Fecha < FechaInicial && c.TipoTransferenciaDepositoID == pGlob.ttdFinanciera.TipoTransferenciaDepositoID && c.EstadoID == pGlob.Acreditado.EstadoID).ToList().Sum(c => c.Importe).Value;

            ccs.SumaCompensaciones = dal.context.Recibo.Where(c => c.EmpresaID == GestionEmpresaID && c.ComercioID == ComercioID
                                                                       && c.Fecha < FechaInicial && c.TipoMovimientoID == pGlob.TmCompensacion.TipoMovimientoID).ToList().Sum(c => c.Importe);

            ccs.SumaRecibosProvisoriosFinan = dal.context.Recibo.Where(c => c.EmpresaID == GestionEmpresaID && c.ComercioID == ComercioID
                                                                       && c.Fecha < FechaInicial && c.TipoMovimientoID == pGlob.TmDepAComer.TipoMovimientoID && c.EstadoID == pGlob.Provisorio.EstadoID).ToList().Sum(c => c.Importe);

            ccs.SumaRecibosProvisoriosComer = dal.context.Recibo.Where(c => c.EmpresaID == GestionEmpresaID && c.ComercioID == ComercioID
                                                                       && c.Fecha < FechaInicial && c.TipoMovimientoID == pGlob.TmDepCobRec.TipoMovimientoID && c.EstadoID == pGlob.Provisorio.EstadoID).ToList().Sum(c => c.Importe);
            
            ccs.SaldoAvisos = ccs.SumaAviso - ccs.SumaAvisoBajas - ccs.SumaDepositosFinan - ccs.SumaCompensaciones;
            ccs.SaldoCobranzas = ccs.SumaCobranzas - ccs.SumaNotasCD -ccs.SumaDepositosComer;
            ccs.Saldo = ccs.SaldoAvisos - ccs.SaldoCobranzas;
            /* Fin hasta fecha inicial */


            ccc = new CuentaCorrienteComun();
            ccc.Fecha = FechaInicial;
            ccc.Saldo = ccs.Saldo;
            lccc.Add(ccc);
            /* Diario */

            List<Credito> lcreds = dal.context.Creditos.Where(c => c.EmpresaID == GestionEmpresaID && c.ComercioID == ComercioID && c.FechaSolicitud >= FechaInicial && c.FechaSolicitud <= FechaFinal).ToList();
            List<CreditoAnulado> lcredsAnul = dal.context.CreditoAnulado.Where(ca => ca.EmpresaID == GestionEmpresaID && ca.ComercioID == ComercioID && ca.FechaSolicitud >= FechaInicial && ca.FechaSolicitud <= FechaFinal).ToList();
            List<Cobranza> lcobs = dal.context.Cobranzas.Where(cob => cob.GestionEmpresaID == GestionEmpresaID && cob.GestionID == ComercioID && cob.FechaPago >= FechaInicial && cob.FechaPago <= FechaFinal).ToList();
            List<NotasCD> lncds = dal.context.NotasCD.Where(nc => nc.EmpresaID == GestionEmpresaID && nc.GestionID == ComercioID &&  nc.Fecha >= FechaInicial && nc.Fecha <= FechaFinal).ToList();
            List<Recibo> lRecCompensaciones = dal.context.Recibo.Where(rec => rec.EmpresaID == GestionEmpresaID && rec.ComercioID == ComercioID && rec.Fecha >= FechaInicial && rec.Fecha <= FechaFinal && rec.TipoMovimientoID == pGlob.TmCompensacion.TipoMovimientoID).ToList();
            List<Recibo> lRecProvFinan = dal.context.Recibo.Where(rec => rec.EmpresaID == GestionEmpresaID && rec.ComercioID == ComercioID && rec.Fecha >= FechaInicial && rec.Fecha <= FechaFinal && rec.TipoMovimientoID == pGlob.TmDepAComer.TipoMovimientoID && rec.EstadoID == pGlob.Provisorio.EstadoID).ToList();
            List<Recibo> lRecProvComer = dal.context.Recibo.Where(rec => rec.EmpresaID == GestionEmpresaID && rec.ComercioID == ComercioID && rec.Fecha >= FechaInicial && rec.Fecha <= FechaFinal && rec.TipoMovimientoID == pGlob.TmDepCobRec.TipoMovimientoID && rec.EstadoID == pGlob.Provisorio.EstadoID).ToList();
            List<TransferenciasDepositos> lDepComer = dal.context.TransferenciasDepositos.Where(depComer => depComer.ComercioEmpresaID == GestionEmpresaID && depComer.ComercioID == ComercioID && depComer.Fecha >= FechaInicial && depComer.Fecha <= FechaFinal && depComer.TipoTransferenciaDepositoID == pGlob.ttdComercio.TipoTransferenciaDepositoID && depComer.EstadoID == pGlob.Acreditado.EstadoID).ToList();
            List<TransferenciasDepositos> lDepFinan = dal.context.TransferenciasDepositos.Where(depFinan => depFinan.ComercioEmpresaID == GestionEmpresaID && depFinan.ComercioID == ComercioID && depFinan.Fecha >= FechaInicial && depFinan.Fecha <= FechaFinal && depFinan.TipoTransferenciaDepositoID == pGlob.ttdFinanciera.TipoTransferenciaDepositoID && depFinan.EstadoID == pGlob.Acreditado.EstadoID).ToList();

            SaldoAcumulado = ccc.Saldo;
            
            int dias = (FechaFinal.Date-FechaInicial.Date).Days;
            DateTime Fecha = FechaInicial;
            for (int i = 0;i<= dias;i++)
            {
                ccc = new CuentaCorrienteComun();
                ccc.Fecha = Fecha;

                SumaAvisos = lcreds.Where(c => c.FechaSolicitud.Date == Fecha.Date).Sum(c => CalcularAvisoDePago(c));
                SumaBajaAvisos = lcredsAnul.Where(c => c.FechaComercioAnula.Date == Fecha).Sum(c => CalcularAvisoDePago(c));
                SumaCobranzas = lcobs.Where(c => c.FechaPago.Date == Fecha).Sum(c => c.ImportePago);
                SumaNotasCD = lncds.Where(c => c.Fecha.Date == Fecha).Sum(c => c.Importe);
                SumaCompensaciones = lRecCompensaciones.Where(c => c.Fecha.Value.Date == Fecha).Sum(c => c.Importe);
                SumaRecibosProvisoriosFinan = lRecProvFinan.Where(c => c.Fecha.Value.Date == Fecha).Sum(c => c.Importe);
                SumaRecibosProvisoriosComer = lRecProvComer.Where(c => c.Fecha.Value.Date == Fecha).Sum(c => c.Importe);
                SumaDepositosComer = lDepComer.Where(c => c.Fecha.Value.Date == Fecha).Sum(c => c.Importe).Value;
                SumaDepositosFinan = lDepFinan.Where(c => c.Fecha.Value.Date == Fecha).Sum(c => c.Importe).Value;

                ccc.Haber = -SumaAvisos - SumaNotasCD + SumaDepositosFinan + SumaCompensaciones;
                ccc.Debe = SumaCobranzas + SumaBajaAvisos - SumaDepositosComer;
                ccc.SaldoDiario = ccc.Haber - ccc.Debe ;
                SaldoAcumulado += ccc.SaldoDiario;
                ccc.Saldo = SaldoAcumulado;

                //ccd = new CuentaCorrienteDetalle();
                //ccdm = new CuentaCorrienteMovs();
                
                ccc.MovimientosHaber.Add(String.Format("Avisos de Pago: $ {0}", SumaAvisos));
                ccc.MovimientosHaber.Add(String.Format("Notas de Crédito: $ {0}", SumaNotasCD));
                ccc.MovimientosHaber.Add(String.Format("Compensaciones: $ {0}", SumaCompensaciones));
                ccc.MovimientosHaber.Add(String.Format("Depositos Financiera: $ {0}", SumaDepositosFinan));
                ccc.MovimientosHaber.Add(String.Format("Depositos Provisorios Financiera: $ {0}", SumaRecibosProvisoriosFinan));
                ccc.MovimientosDebe.Add(String.Format("baja Avisos de Pago: $ {0}", SumaBajaAvisos));
                ccc.MovimientosDebe.Add(String.Format("Cobranzas: $ {0}", SumaCobranzas));
                ccc.MovimientosDebe.Add(String.Format("Depositos Comercio {1}: $ {0}", SumaDepositosComer, ComercioID));
                ccc.MovimientosDebe.Add(String.Format("Depositos Provisorios Comercio {1}: $ {0}", SumaRecibosProvisoriosComer, ComercioID));

                if (SumaRecibosProvisoriosFinan > 0 || SumaRecibosProvisoriosComer > 0)
                {
                    ccc.provisorios = true;
                }

                lccc.Add(ccc);
                Fecha = Fecha.AddDays(1);
            }
            return lccc;
        }

        public decimal CalcularAvisoDePago(Credito cred)
        {
            decimal valor = cred.ValorNominal;
             if (cred.TipoCuotaID == "A")
             {
                 valor -= cred.ValorCuota;
             }
             valor -= cred.Gasto;
             if (cred.Comision > 0)
                 valor += (cred.Comision * (decimal)1.21);
             else
                 valor += cred.Comision;
             return valor * (-1);
         }

        public decimal CalcularAvisoDePago(CreditoAnulado cred)
        {
            decimal valor = cred.ValorNominal;
            if (cred.TipoCuotaID == "A")
            {
                valor -= cred.ValorCuota;
            }
            valor -= cred.Gasto;
            if (cred.Comision > 0)
                valor += (cred.Comision * (decimal)1.21);
            else
                valor += cred.Comision;
            return valor;
        }
        


        /* Cuenta Corriente */
        



        public IEnumerable<CuentaCorriente> GetCuentasCorrientes(Expression<Func<CuentaCorriente, bool>> filter = null,
                               Func<IQueryable<CuentaCorriente>, IOrderedQueryable<CuentaCorriente>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetCuentasCorrientes(filter, orderBy, includeProperties);
            
        }

        public CuentaCorriente GetCuentaCorrienteByID(object id)
        {
            return dal.GetCuentaCorrienteByID(id);
        }

        public void AgregarCuentaCorriente(CuentaCorriente cc)
        {
            dal.AgregarCuentaCorriente(cc);
        }

        public void BorrarCuentaCorriente(object id)
        {
            dal.BorrarCuentaCorriente(id);
        }

        public void BorrarCuentaCorriente(CuentaCorriente cc)
        {
            dal.BorrarCuentaCorriente(cc);
        }

        public void ActualizarCuentaCorriente(CuentaCorriente cc)
        {
            dal.ActualizarCuentaCorriente(cc);
        }
        public void ActualizarCuentaCorriente(int BaseIDb, CuentaCorriente cc)
        {
            GetDal(BaseIDb).ActualizarCuentaCorriente(cc);
        }
        public BindingList<CuentaCorriente> CuentaCorrienteBindingList()
        {
            return dal.CuentaCorrienteBindingList();
        }

        public void BorrarImputacionCuentaCorrienteCredito(Credito cred)
        {
            CuentaCorriente cc = Get<CuentaCorriente>(cred.EmpresaID,c=>c.CreditoID == cred.CreditoID 
                                && c.TipoMovimientoID == pGlob.TmCredOtorEfec.TipoMovimientoID).Single();
            BorrarTransaccional<CuentaCorriente>(cred.EmpresaID,cc);
        }

        public CuentaCorriente ImputarCuentaCorriente(Comercio com,Recibo rec, TransferenciasDepositos td, TipoMovimiento tm,decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(com, rec, td, tm, Importe);
            AgregarTransaccional<CuentaCorriente>(rec.EmpresaID, cc);
            // AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputacionCuentaCorrienteGasto(Gasto gasto)
        {
            CuentaCorriente cc = new CuentaCorriente(gasto, pGlob.TmGastosFF);
            AgregarTransaccional<CuentaCorriente>(gasto.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionAnulacionCuentaCorrienteGasto(Gasto gasto)
        {
            CuentaCorriente cc = new CuentaCorriente(gasto, pGlob.TmAnuGastosFF);
            AgregarTransaccional<CuentaCorriente>(gasto.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionCuentaCorrienteFF(FF ff)
        {
            CuentaCorriente cc = new CuentaCorriente(ff,pGlob.TmGastosFF);
            AgregarTransaccional<CuentaCorriente>(ff.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionAnulacionCuentaCorrienteFF(FF ff)
        {
            CuentaCorriente cc = new CuentaCorriente(ff, pGlob.TmAnuGastosFF);
            AgregarTransaccional<CuentaCorriente>(ff.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionCuentaCorrienteCap(Cap cap,decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(cap, pGlob.TmGastosCAP, Importe);
            AgregarTransaccional<CuentaCorriente>(cap.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionCuentaCorrientePago(Pago Pago, TipoMovimiento tm)
        {
            decimal Importe = Math.Abs(Pago.Importe);
            CuentaCorriente cc = new CuentaCorriente(Pago, tm, Importe);
            AgregarTransaccional<CuentaCorriente>(Pago.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionCuentaCorrientePago(Pago Pago,Cap cap)
        {
            decimal Importe = Math.Abs(Pago.Importe);
            CuentaCorriente cc = new CuentaCorriente(Pago, pGlob.TmGastosCAP, Importe);
            AgregarTransaccional<CuentaCorriente>(Pago.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionAnulacionCuentaCorrientePago(Pago Pago, Cap cap)
        {
            decimal Importe = Math.Abs(Pago.Importe);
            CuentaCorriente cc = new CuentaCorriente(Pago, pGlob.TmAnuGastosCAP, Importe);
            AgregarTransaccional<CuentaCorriente>(Pago.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionCuentaCorrienteFF(Pago Pago, FF FF)
        {
            decimal Importe = Math.Abs(Pago.Importe);
            CuentaCorriente cc = new CuentaCorriente(Pago, pGlob.TmGastosFF, Importe);
            AgregarTransaccional<CuentaCorriente>(Pago.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionAnulacionCuentaCorrientePago(Pago Pago, FF FF)
        {
            decimal Importe = Math.Abs(Pago.Importe);
            CuentaCorriente cc = new CuentaCorriente(Pago, pGlob.TmAnuGastosFF, Importe);
            AgregarTransaccional<CuentaCorriente>(Pago.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputacionAnulacionCuentaCorrienteCap(Cap cap, decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(cap, pGlob.TmAnuGastosCAP, Importe);
            AgregarTransaccional<CuentaCorriente>(cap.EmpresaID, cc);
            return cc;
        }

        public CuentaCorriente ImputarSolicitudFondoACuentaCorriente(SolicitudFondo sf)
        {
            CuentaCorriente cc = null;
            if (sf.ConceptoFondos.ConceptoFondosID == pGlob.ExtBan.ConceptoFondosID)
            {
                decimal Importe = Math.Abs(sf.Importe.Value);
                cc = new CuentaCorriente(sf, pGlob.TmRetBcoCaja, Importe);
                AgregarTransaccional<CuentaCorriente>(cc);
                //AgregarCuentaCorriente(cc);
            }
            
            return cc;
        }

        public CuentaCorriente ImputarCreditoACuentaCorriente(Credito cred)
        {
            decimal Importe = Math.Abs(cred.ValorNominal);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmCredOtorEfec, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarComisionCreditoACuentaCorriente(int BaseIDb, Credito cred) //

        {
            decimal Importe = Math.Abs(cred.Comision);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmComisCredOtorEfec, Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }


        public CuentaCorriente ImputarAnulacionComisionCreditoACuentaCorriente(int BaseIDb, Credito cred, DateTime fNvaFEcha) //eduardo cambio
        {
            decimal Importe = Math.Abs(cred.Comision);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmAnuComisCredOtorEfec, Importe, fNvaFEcha);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionCreditoACuentaCorriente(int BaseIDb, Credito cred, DateTime fNvaFEcha)//eduardo cambio
        {
            decimal Importe = Math.Abs(cred.ValorNominal);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmAnuCredOtorEfec, Importe, fNvaFEcha);
            cc.CreditoID = null;
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            // AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarCreditoACuentaCorriente(int BaseIDb, Credito cred)
        {
            decimal Importe = Math.Abs(cred.ValorNominal);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmCredOtorEfec, Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }


        public CuentaCorriente ImputarAnulacionCreditoACuentaCorriente(Credito cred)
        {
            decimal Importe = Math.Abs(cred.ValorNominal);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmAnuCredOtorEfec, Importe);
            cc.CreditoID = null;
            AgregarTransaccional<CuentaCorriente>(cc);
           // AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionGastoCreditoACuentaCorriente(Credito cred, DateTime fNvaFEcha)//eduardo cambio
        {
            decimal Importe = Math.Abs(cred.Gasto);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmAnuGasCredOtor, Importe, fNvaFEcha);
            cc.CreditoID = null;
            AgregarTransaccional<CuentaCorriente>(cred.EmpresaID, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }
        

        public CuentaCorriente ImputarGastoCreditoACuentaCorriente(Credito cred)
        {
            decimal Importe = Math.Abs(cred.Gasto);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmGasDescCredOtor, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarGastoCreditoACuentaCorriente(int BaseIDb, Credito cred, DateTime fFechaAviso)
        {
            decimal Importe = Math.Abs(cred.Gasto);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmGasDescCredOtor, Importe, fFechaAviso);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarDescuentoCobranzaPorCancelaciónAnticipadoACuentaCorriente(int BaseIDb, NotasCD NotasCD) //edu camb
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmDescCobCancAnt, importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            return cc;
        }

        public CuentaCorriente ImputarDescuentoCobranzaPorPromocionBonificadaACuentaCorriente(int BaseIDb, NotasCD NotasCD) 
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmDescCobPromBoni, importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionGastoCreditoACuentaCorriente(Credito cred)
        {
            decimal Importe = Math.Abs(cred.Gasto);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmAnuGasCredOtor, Importe);
            AgregarTransaccional<CuentaCorriente>(cred.EmpresaID,cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionDescuentoCobranzaPorPromocionBonificadaACuentaCorriente(int BaseIDb, NotasCD NotasCD, DateTime fNvaFEcha) //eduardo cambio
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmAnulDesCobBoni, importe, fNvaFEcha);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarCobranzaACuentaCorriente(Cobranza cob)
        {
            decimal Importe = Math.Abs( cob.ImportePago + cob.ImportePagoPunitorios);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmCobranza, Importe);
            AgregarTransaccional<CuentaCorriente>(cob.EmpresaID,cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarCobranzaACuentaCorriente(int BaseIDb, Cobranza cob)
        {
            decimal Importe = Math.Abs( cob.ImportePago + cob.ImportePagoPunitorios);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmCobranza, Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarDescPuniRefiACuentaCorriente(int BaseIDb, Cobranza cob)
        {
            decimal Importe = Math.Abs(cob.ImportePago + cob.ImportePagoPunitorios);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmDescPuniRefi, Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);            
            return cc;
        }

        public CuentaCorriente ImputarAnuDescPuniRefiACuentaCorriente(int BaseIDb, Cobranza cob)
        {
            decimal Importe = Math.Abs(cob.ImportePago + cob.ImportePagoPunitorios);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmAnuDescPuniRefi, Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            return cc;
        }

        public CuentaCorriente ImputarCobranzaDebitoACuentaCorriente(int BaseIDb, int EmpresaID,int ComercioID,int CreditoID,int CuotaID,int CobranzaID,decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(pGlob.TmCobPorDebito,EmpresaID,ComercioID,CreditoID,CuotaID,CobranzaID,Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionCobranzaDebitoACuentaCorriente(int BaseIDb, int EmpresaID, int ComercioID, int CreditoID, int CuotaID, int CobranzaID, decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(pGlob.TmAnuCobPorDebito, EmpresaID, ComercioID, CreditoID, CuotaID, CobranzaID, Importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }      

        public CuentaCorriente ImputarAnulacionCobranzaACuentaCorriente(Cobranza cob)
        {
            decimal importe = Math.Abs(cob.ImportePago + cob.ImportePagoPunitorios);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmAnuCobranza,importe );
            AgregarTransaccional<CuentaCorriente>(cob.EmpresaID,cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionCobranzaDebitoACuentaCorriente(Cobranza cob,Recibo rec)
        {
            decimal importe = Math.Abs(rec.Importe);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmAnuCobPorDebito, importe);
            AgregarTransaccional<CuentaCorriente>(cob.EmpresaID, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }


        //public CuentaCorriente ImputarCuotaAdelantadaACuentaCorriente(int BaseIDb, Credito cred, Cuota CuotaAdelantada, DateTime fFEchaAviso)//edu202109
        //{
        //    decimal Importe = Math.Abs(cred.ValorCuota);
        //    CuentaCorriente cc = new CuentaCorriente(cred, CuotaAdelantada, pGlob.TmCuotaAdelantada, Importe, fFEchaAviso);
        //    AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
        //    //AgregarCuentaCorriente(cc);
        //    return cc;
        //}
        public CuentaCorriente ImputarCuotaAdelantadaACuentaCorriente(int BaseIDb, Credito cred, DateTime fFEchaAviso)//edu202109
        {
            decimal Importe = Math.Abs(cred.ValorCuota);
            CuentaCorriente cc = new CuentaCorriente(cred,  pGlob.TmCuotaAdelantada, Importe, fFEchaAviso);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }
        public CuentaCorriente ImputarAnulacionCuotaAdelantadaACuentaCorriente(Credito cred, DateTime fNvaFEcha) 
        {
            decimal Importe = Math.Abs(cred.ValorCuota);
            CuentaCorriente cc = new CuentaCorriente(cred, pGlob.TmAnuCuotaAdelantada, fNvaFEcha);
            //CuentaCorriente cc = new CuentaCorriente(cred, CuotaAdelantada, pGlob.TmAnuCuotaAdelantada, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarNotaDeCreditoACuentaCorriente(NotasCD NotasCD)
        {
            decimal Importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmNC, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }
  
        public CuentaCorriente ImputarNotaDeCreditoACuentaCorriente(int BaseIDb, NotasCD NotasCD)
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmNC, importe);
            AgregarTransaccional<CuentaCorriente>(BaseIDb, cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionNotaDeCreditoACuentaCorriente(NotasCD NotasCD)
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmAnulNC, importe);
            AgregarTransaccional<CuentaCorriente>(NotasCD.EmpresaID,cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarDescuentoCobranzaPorCancelaciónAnticipadoACuentaCorriente(Cobranza cob, decimal Importe)
        {
            decimal importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmDescCobCancAnt, importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionDescuentoCobranzaPorCancelaciónAnticipadoACuentaCorriente(NotasCD NotasCD)
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmAnuDescAnt, importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarDescuentoCobranzaPorPromocionBonificadaACuentaCorriente(Cobranza cob, decimal Importe)
        {
            decimal importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmDescCobPromBoni, importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionDescuentoCobranzaPorPromocionBonificadaACuentaCorriente(Cobranza cob, decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmAnulDesCobBoni, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionDescuentoCobranzaPorCancelaciónAnticipadoACuentaCorriente(int BaseIDb, NotasCD NotasCD, DateTime fNvaFEcha) //edu camb
        {
            decimal importe = Math.Abs(NotasCD.Importe);
            CuentaCorriente cc = new CuentaCorriente(NotasCD, pGlob.TmAnuDescAnt, importe, fNvaFEcha);
            AgregarTransaccional<CuentaCorriente>(cc);
            //AgregarCuentaCorriente(cc);
            return cc;
        }

        public CuentaCorriente ImputarRetiroDeBancoACajaACuentaCorriente(int EmpresaID,int ComercioID,Decimal Importe)
        {
            Importe = Math.Abs(Importe);
            CuentaCorriente cc = new CuentaCorriente(EmpresaID, ComercioID, pGlob.TmRetBcoCaja, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            return cc;
        }

        public CuentaCorriente ImputarAnulacionRetiroDeBancoACajaACuentaCorriente(int EmpresaID, int ComercioID, Cobranza cob)
        {
            decimal Importe = Math.Abs(cob.ImportePago + cob.ImportePagoPunitorios);
            CuentaCorriente cc = new CuentaCorriente(cob, pGlob.TmRetBcoCaja, Importe);
            AgregarTransaccional<CuentaCorriente>(cc);
            return cc;
        }

        public List<CuentaCorrienteViewModel> ObtenerCuentaCorriente(Comercio com,DateTime FechaDesde,DateTime FechaHasta)
        {
            //Obtener el saldo hasta el dia que se solicita
            //Mostrar listado de cuenta corriente en período solicitado acumulado por fecha

            List<CuentaCorrienteViewModel> ccItems = ObtenerSaldoCuentaCorrienteHasta(com, FechaDesde);
            /*List<CuentaCorrienteViewModel> ccItems = GetCuentasCorrientes(c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID).ToList()
                                                     .FindAll(x => x.Fecha >= FechaDesde && x.Fecha <= FechaHasta).
                                                     Select(g => new CuentaCorrienteViewModel() 
                                                        { 
                                                        fecha = g.Fecha,
                                                        Debe = (g.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Ingreso.ClaseMovimientoID ? g.Importe : 0),
                                                        Haber = (g.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Egreso.ClaseMovimientoID ? g.Importe : 0),
                                                        MovimientoID = g.TipoMovimientoID.Value,
                                                        Movimiento = g.TipoMovimiento.Nombre
                                                        //Saldo = g.Sum(x=>x.Importe * x.TipoMovimiento.ClaseMovimiento.Modificador) 
                                                        }).ToList();       */     
            

            List<CuentaCorrienteViewModel> ccSaldos = GetCuentasCorrientes(c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID)
                                                .Where(x => x.Fecha.Date >= FechaDesde.Date && x.Fecha.Date <= FechaHasta.Date)
                                                .GroupBy(c => c.Fecha).Select(g => new CuentaCorrienteViewModel() 
                                                { 
                                                    fecha = g.Key.Date,
                                                    Movimiento = pGlob.Configuracion.menSaldo,
                                                    Saldo = g.Sum(x=>x.Importe * x.TipoMovimiento.ClaseMovimiento.Modificador),
                                                    Orden = 2
                                                }).ToList();

            List<CuentaCorrienteViewModel> cc = GetCuentasCorrientes(c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID)
                                                                    .Where(x => x.Fecha.Date >= FechaDesde.Date && x.Fecha.Date <= FechaHasta.Date)
                                                                    .Select(g => new CuentaCorrienteViewModel()
                                                                    {
                                                                        fecha = g.Fecha,
                                                                        Debe = (g.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Egreso.ClaseMovimientoID ? g.Importe : 0),
                                                                        Haber = (g.TipoMovimiento.ClaseMovimiento.ClaseMovimientoID == pGlob.Ingreso.ClaseMovimientoID ? g.Importe : 0),
                                                                        MovimientoID = g.TipoMovimientoID.Value,
                                                                        Movimiento = g.TipoMovimiento.Nombre,
                                                                        Orden = 1
                                                                        //Saldo = g.Sum(x=>x.Importe * x.TipoMovimiento.ClaseMovimiento.Modificador) 
                                                                    }).ToList();

            
            ccItems.AddRange(cc);

            foreach (CuentaCorrienteViewModel item in ccItems)
            {
                
            }

            ccItems.AddRange(ccSaldos);
            ccItems = ccItems.OrderBy(x => x.fecha).ThenBy(x=>x.Orden).ToList();
            return ccItems;
        }


        public List<CuentaCorrienteViewModel> ObtenerSaldoCuentaCorrienteHasta(Comercio com, DateTime fecha)
        {
            List<CuentaCorrienteViewModel> ccItems = new List<CuentaCorrienteViewModel>();
            CuentaCorrienteViewModel item = new CuentaCorrienteViewModel();
            decimal saldo =  GetCuentasCorrientes(c => c.EmpresaID == com.EmpresaID && c.ComercioID == com.ComercioID)
                                .Where(x => x.Fecha <= fecha.AddDays(-1))
                                .Sum(x => x.Importe * x.TipoMovimiento.ClaseMovimiento.Modificador);

            item.fecha = fecha.AddDays(-1);
            item.Movimiento = pGlob.Configuracion.menSaldo;
            item.Saldo = saldo;
            ccItems.Add(item);
            return ccItems;
        }

        /*Aviso de pago*/

        public AvisoDePago ActualizarAvisoDePago(Credito cred)
        {
            AvisoDePago avi = new AvisoDePago();
            avi.EmpresaID = cred.EmpresaID;
            avi.ComercioID = cred.ComercioID;
            return avi;
        }

        /* Proveedor */
        public IEnumerable<Proveedor> GetProveedores(Expression<Func<Proveedor, bool>> filter = null,
                               Func<IQueryable<Proveedor>, IOrderedQueryable<Proveedor>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetProveedores(filter, orderBy, includeProperties);
        }

        public IEnumerable<Proveedor> GetProveedoresActivos(Expression<Func<Proveedor, bool>> filter = null,
                               Func<IQueryable<Proveedor>, IOrderedQueryable<Proveedor>> orderBy = null,
                               string includeProperties = "")
        {
            return GetProveedores(filter, orderBy, includeProperties).Where(p => p.EstadoID != pGlob.ProveedorEliminado.EstadoID).ToList();             
        }

        public Proveedor GetProveedorByID(object id)
        {
            return dal.GetProveedorByID(id);
        }

        
        public int ObtenerProximoNumeroDeProveedor()
        {
            if (dal.GetProveedores().Any())
            {
                return dal.GetProveedores().Max(p => p.ProveedorID).Value + 1;
            }
            else
                return 1;
        }

        
        public void AgregaProveedor(Proveedor prov)
        {
            //prov.ProveedorID = ObtenerProximoNumeroDeProveedor();
            dal.AgregarProveedor(prov);
        }


        public void BorrarProveedor(object id)
        {
            dal.BorrarProveedor(id);
        }

        public void BorrarProveedorPorIDCentral(Proveedor prov)
        {
            Proveedor prove = GetProveedores(p => p.ProveedorIDRemoto == prov.ProveedorIDRemoto).SingleOrDefault();
                dal.BorrarProveedor(prove);
        }

        public void BorrarProveedor(Proveedor prov)
        {
            dal.BorrarProveedor(prov);
        }

        public void BorrarProveedorLogico(Proveedor prov)
        {
            prov.EstadoID = pGlob.ProveedorEliminado.EstadoID;
            ActualizarProveedor(prov);
        }

        public void ActualizarProveedor(Proveedor prov)
        {
             //if (prov.ProveedorIDCentral == null)
             //{
             //   prov.ProveedorIDCentral = GetProveedorByID(prov.ProveedorID).ProveedorIDCentral;
             //}
             dal.ActualizarProveedor(prov);
        }

        public BindingList<Proveedor> ProveedorBindingList()
        {
            return dal.ProveedorBindingList();
        }

        public void ProveedorRecargar(Proveedor p)
        {
            dal.RecargarProvedor(p);
        }

        /* Proveedor Sucursal */
        public IEnumerable<ProveedorSucursal> GetProveedorSucursales(Expression<Func<ProveedorSucursal, bool>> filter = null,
                               Func<IQueryable<ProveedorSucursal>, IOrderedQueryable<ProveedorSucursal>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetProveedorSucursales(filter, orderBy, includeProperties);
        }

        public IEnumerable<ProveedorSucursal> GetProveedorSucursalesLogico(Proveedor prov)
        {
            IEnumerable<ProveedorSucursal> lista  = GetProveedorSucursales(p => p.ProveedorID == prov.ProveedorID && p.EstadoID != pGlob.ProveedorSucursalEliminada.EstadoID);
            return lista;
        }

        public ProveedorSucursal GetProveedorSucursalByID(object id)
        {
            return dal.GetProveedorSucursalByID(id);
        }

        public void AgregaProveedorSucursal(ProveedorSucursal prov)
        {
            dal.AgregarProveedorSucursal(prov);
        }

        public void BorrarProveedorSucursal(object id)
        {
            dal.BorrarProveedorSucursal(id);
        }

        public void BorrarProveedorSucursalLogico(ProveedorSucursal prov)
        {
            prov.EstadoID = pGlob.ProveedorSucursalEliminada.EstadoID;
            ActualizarProveedorSucursal(prov);
        }

        public void BorrarProveedorSucursalPorIDCentral(ProveedorSucursal suc)
        {
            ProveedorSucursal prov = GetProveedorSucursales(p =>p.ProveedorSucursalIDRemoto == suc.ProveedorSucursalIDRemoto).SingleOrDefault();
            dal.BorrarProveedorSucursal(prov);
        }

        public void BorrarProveedorSucursal(ProveedorSucursal prov)
        {
            dal.BorrarProveedorSucursal(prov);
        }

        public void ActualizarProveedorSucursal(ProveedorSucursal prov)
        {
            ProveedorSucursal suc = GetProveedorSucursales(s=>s.ProveedorSucursalID == prov.ProveedorSucursalID
                                                            && s.ProveedorID == prov.ProveedorID).SingleOrDefault();
            prov.ProveedorSucursalIDRemoto = suc.ProveedorSucursalIDRemoto;
            dal.ActualizarProveedorSucursal(prov);
        }

        public void ProveedorSucursalBindingList()
        {
            dal.ProveedorSucursalBindingList();
        }

        /* Pais */
        public IEnumerable<Pais> GetPaises(Expression<Func<Pais, bool>> filter = null,
                               Func<IQueryable<Pais>, IOrderedQueryable<Pais>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetPaises(filter, orderBy, includeProperties);
        }

        public Pais GetPaisByID(object id)
        {
            return dal.GetPaisByID(id);
        }

        public void AgregarPais(Pais pais)
        {
            dal.AgregarPais(pais);
        }

        public void BorrarPais(object id)
        {
            dal.BorrarPais(id);
        }

        public void BorrarPais(Pais pais)
        {
            dal.BorrarPais(pais);
        }

        public void ActualizarPais(Pais pais)
        {
            dal.ActualizarPais(pais);
        }

        public BindingList<Pais> PaisBindingList()
        {
            return dal.PaisBindingList();
        }

        public List<Pais> GetPaisArgentinaLista()
        {
            return GetPaises(p=>p.PaisID == 5).ToList();
        }



        /* Provincia */
        public IEnumerable<Provincia> GetProvincias(Expression<Func<Provincia, bool>> filter = null,
                               Func<IQueryable<Provincia>, IOrderedQueryable<Provincia>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetProvincias(filter, orderBy, includeProperties);
        }

        public Provincia GetProvinciaByID(object id)
        {
            return dal.GetProvinciaByID(id);
        }

        public void AgregarProvincia(Provincia provincia)
        {
            dal.AgregarProvincia(provincia);
        }

        public void BorrarProvincia(object id)
        {
            dal.BorrarProvincia(id);
        }

        public void BorrarProvincia(Provincia provincia)
        {
            dal.BorrarProvincia(provincia);
        }

        public void ActualizarProvincia(Provincia provincia)
        {
            dal.ActualizarProvincia(provincia);
        }

        public BindingList<Provincia> ProvinciaBindingList()
        {
            return dal.ProvinciaBindingList();
        }

        public int ObtenerCodigoProvincia(string Clave)
        {
            Provincia prov = GetProvincias(p => p.Nombre == ObtenerProvinciaDesdeClave(Clave)).FirstOrDefault();
            return prov.ProvinciaID.Value;
        }

        public string ObtenerProvinciaDesdeClave(string clave)
        {
            switch (clave)
            {
                case "B":
                    return "BUENOS AIRES";
                case "C":
                    return "CAPITAL FEDERAL";
                case "I":
                    return "CATAMARCA";
                case "G":
                    return "CHACO";
                case "W":
                    return "CHUBUT";
                case "P":
                    return "CORDOBA";
                case "N":
                    return "CORRIENTES";
                case "O":
                    return "ENTRE RIOS";
                case "F":
                    return "FORMOSA";
                case "D":
                    return "JUJUY";
                case "T":
                    return "LA PAMPA";
                case "Q":
                    return "LA RIOJA";
                case "M":
                    return "MENDOZA";
                case "L":
                    return "MISIONES";
                case "U":
                    return "NEUQUEN";
                case "V":
                    return "RIO NEGRO";
                case "E":
                    return "SALTA";
                case "R":
                    return "SAN JUAN";
                case "S":
                    return "SAN LUIS";
                case "X":
                    return "SANTA CRUZ";
                case "H":
                    return "SANTIAGO DEL ESTERO";
                case "Y":
                    return "TIERRA DEL FUEGO";
                case "J":
                    return "TUCUMAN";
            }
            return null;
        }

        /* Localidad */
        public IEnumerable<Localidad> GetLocalidades(Expression<Func<Localidad, bool>> filter = null,
                               Func<IQueryable<Localidad>, IOrderedQueryable<Localidad>> orderBy = null,
                               string includeProperties = "")
        {
            return dal.GetLocalidades(filter, orderBy, includeProperties);
        }
        public IEnumerable<Localidad> GetLocalidades(int BaseIDb, Expression<Func<Localidad, bool>> filter = null,
                       Func<IQueryable<Localidad>, IOrderedQueryable<Localidad>> orderBy = null,
                       string includeProperties = "")
        {
            return GetDal(BaseIDb).GetLocalidades(filter, orderBy, includeProperties);
        }
        public Localidad GetLocalidadByID(object id)
        {
            return dal.GetLocalidadByID(id);
        }

        public void AgregarLocalidad(Localidad Localidad)
        {
            dal.AgregarLocalidad(Localidad);
        }

        public void BorrarLocalidad(object id)
        {
            dal.BorrarLocalidad(id);
        }

        public void BorrarLocalidad(Localidad Localidad)
        {
            dal.BorrarLocalidad(Localidad);
        }

        public void ActualizarLocalidad(Localidad Localidad)
        {
            dal.ActualizarLocalidad(Localidad);
        }

        public BindingList<Localidad> LocalidadBindingList()
        {
            return dal.LocalidadBindingList();
        }

        public Localidad GetLocalidadDeComercio(Comercio com)
        {
            return Get<Localidad>(l => l.LocalidadID == com.LocalidadID).SingleOrDefault();
        }

        #region //**edu**

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Credito edu
        public IEnumerable<Credito> GetCreditos(Expression<Func<Credito, bool>> filter = null,
                                  Func<IQueryable<Credito>, IOrderedQueryable<Credito>> orderBy = null,
                                  string includeProperties = "")
        {
            return dal.GetCreditos(filter, orderBy, includeProperties);
        }                       //ok
        public IEnumerable<Credito> GetCreditos(int BaseIDb, Expression<Func<Credito, bool>> filter = null,
                          Func<IQueryable<Credito>, IOrderedQueryable<Credito>> orderBy = null,
                          string includeProperties = "")
        {
            return GetDal(BaseIDb).GetCreditos(filter, orderBy, includeProperties);
        }
        public Credito GetCreditoByID(object id)
        {
            return dal.GetCreditoByID(id);
        }
        public void AgregarCredito(Credito pp)
        {
            dal.AgregarCredito(pp);
        }               //ok
        public void BorrarCredito(object id)
        {
            dal.BorrarCredito(id);
        }              //ok

        public void BorrarCredito(Credito pp)
        {
            dal.BorrarCredito(pp);
        }               //ok
        public void ActualizarCredito(Credito pp)
        {
            dal.ActualizarCredito(pp);
        }               //ok
        public BindingList<Credito> CreditoBindingList()
        {
            return dal.CreditoBindingList();
        }
        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 rEFINANCIACIONCOBRANZA edu fin
        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 RefinanciacionCobranza edu
        public IEnumerable<RefinanciacionCobranza> GetRefinanciacionCobranzas(Expression<Func<RefinanciacionCobranza, bool>> filter = null,
                                  Func<IQueryable<RefinanciacionCobranza>, IOrderedQueryable<RefinanciacionCobranza>> orderBy = null,
                                  string includeProperties = "")
        {
            return dal.GetRefinanciacionCobranzas(filter, orderBy, includeProperties);
        }                       //ok

        public RefinanciacionCobranza GetRefinanciacionCobranzaByID(object id)
        {
            return dal.GetRefinanciacionCobranzaByID(id);
        }
        public void AgregarRefinanciacionCobranza(RefinanciacionCobranza pp)
        {
            dal.AgregarRefinanciacionCobranza(pp);
        }               //ok
        public void BorrarRefinanciacionCobranza(object id)
        {
            dal.BorrarRefinanciacionCobranza(id);
        }              //ok

        public void BorrarRefinanciacionCobranza(RefinanciacionCobranza pp)
        {
            dal.BorrarRefinanciacionCobranza(pp);
        }               //ok
        public void ActualizarRefinanciacionCobranza(RefinanciacionCobranza pp)
        {
            dal.ActualizarRefinanciacionCobranza(pp);
        }               //ok
        public BindingList<RefinanciacionCobranza> RefinanciacionCobranzaBindingList()
        {
            return dal.RefinanciacionCobranzaBindingList();
        }
        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Mail edu fin

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 RefinanciacionCuota edu
        public IEnumerable<RefinanciacionCuota> GetRefinanciacionCuotas(Expression<Func<RefinanciacionCuota, bool>> filter = null,
                                  Func<IQueryable<RefinanciacionCuota>, IOrderedQueryable<RefinanciacionCuota>> orderBy = null,
                                  string includeProperties = "")
        {
            return dal.GetRefinanciacionCuotas(filter, orderBy, includeProperties);
        }                       //ok

        public RefinanciacionCuota GetRefinanciacionCuotaByID(object id)
        {
            return dal.GetRefinanciacionCuotaByID(id);
        }
        public void AgregarRefinanciacionCuota(RefinanciacionCuota pp)
        {
            dal.AgregarRefinanciacionCuota(pp);
        }               //ok
        public void BorrarRefinanciacionCuota(object id)
        {
            dal.BorrarRefinanciacionCuota(id);
        }              //ok

        public void BorrarRefinanciacionCuota(RefinanciacionCuota pp)
        {
            dal.BorrarRefinanciacionCuota(pp);
        }               //ok
        public void ActualizarRefinanciacionCuota(RefinanciacionCuota pp)
        {
            dal.ActualizarRefinanciacionCuota(pp);
        }               //ok
        public BindingList<RefinanciacionCuota> RefinanciacionCuotaBindingList()
        {
            return dal.RefinanciacionCuotaBindingList();
        }
        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Mail edu fin

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Refinanciacion edu
        public IEnumerable<Refinanciacion> GetRefinanciaciones(Expression<Func<Refinanciacion, bool>> filter = null,
                                  Func<IQueryable<Refinanciacion>, IOrderedQueryable<Refinanciacion>> orderBy = null,
                                  string includeProperties = "")
        {
            return dal.GetRefinanciaciones(filter, orderBy, includeProperties);
        }                       //ok

        public Refinanciacion GetRefinanciacionByID(object id)
        {
            return dal.GetRefinanciacionByID(id);
        }
        public void AgregarRefinanciacion(Refinanciacion pp)
        {
            dal.AgregarRefinanciacion(pp);
        }               //ok
        public void BorrarRefinanciacion(object id)
        {
            dal.BorrarRefinanciacion(id);
        }              //ok

        public void BorrarRefinanciacion(Refinanciacion pp)
        {
            dal.BorrarRefinanciacion(pp);
        }               //ok
        public void ActualizarRefinanciacion(Refinanciacion pp)
        {
            dal.ActualizarRefinanciacion(pp);
        }               //ok
        public BindingList<Refinanciacion> RefinanciacionBindingList()
        {
            return dal.RefinanciacionBindingList();
        }
        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Refinanciacion edu fin

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Mail edu
        public IEnumerable<Mail> GetMails(Expression<Func<Mail, bool>> filter = null,
                                  Func<IQueryable<Mail>, IOrderedQueryable<Mail>> orderBy = null,
                                  string includeProperties = "")
        {
            return dal.GetMails(filter, orderBy, includeProperties);
        }                       //ok

        public Mail GetMailByID(object id)
        {
            return dal.GetMailByID(id);
        }
        public void AgregarMail(Mail pp)
        {
            dal.AgregarMail(pp);
        }               //ok
        public void BorrarMail(object id)
        {
            dal.BorrarMail(id);
        }              //ok

        public void BorrarMail(Mail pp)
        {
            dal.BorrarMail(pp);
        }               //ok
        public void ActualizarMail(Mail pp)
        {
            dal.ActualizarMail(pp);
        }               //ok
        public void ActualizarMail(int BaseIDb, Mail pp)
        {
            GetDal(BaseIDb).ActualizarMail(pp);
        }
        public BindingList<Mail> MailBindingList()
        {
            return dal.MailBindingList();
        }
        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Mail edu fin

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 telefono edu
        public IEnumerable<Telefono> GetTelefonos(Expression<Func<Telefono, bool>> filter = null,
                                  Func<IQueryable<Telefono>, IOrderedQueryable<Telefono>> orderBy = null,
                                  string includeProperties = "")
        {
            return dal.GetTelefonos(filter, orderBy, includeProperties);
        }                       //ok

        public Telefono GetTelefonoByID(object id)
        {
            return dal.GetTelefonoByID(id);
        }
        public void AgregarTelefono(Telefono pp)
        {
            dal.AgregarTelefono(pp);
        }               //ok
        public void BorrarTelefono(object id)
        {
            dal.BorrarTelefono(id);
        }              //ok

        public void BorrarTelefono(Telefono pp)
        {
            dal.BorrarTelefono(pp);
        }               //ok
        public void ActualizarTelefono(Telefono pp)
        {
            dal.ActualizarTelefono(pp);
        }               //ok
        public BindingList<Telefono> TelefonoBindingList()
        {
            return dal.TelefonoBindingList();
        }        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 telefono edu fin

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 doicilio edu
        public IEnumerable<Domicilio> GetDomicilios(Expression<Func<Domicilio, bool>> filter = null,
                                 Func<IQueryable<Domicilio>, IOrderedQueryable<Domicilio>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetDomicilios(filter, orderBy, includeProperties);
        }                       //ok

        public Domicilio GetDomicilioByID(object id)
        {
            return dal.GetDomicilioByID(id);
        }
        public void AgregarDomicilio(Domicilio pp)
        {
            dal.AgregarDomicilio(pp);
        }               //ok
        public void BorrarDomicilio(object id)
        {
            dal.BorrarDomicilio(id);
        }              //ok

        public void BorrarDomicilio(Domicilio pp)
        {
            dal.BorrarDomicilio(pp);
        }               //ok
        public void ActualizarDomicilio(Domicilio pp)
        {
            dal.ActualizarDomicilio(pp);
        }               //ok
        public BindingList<Domicilio> DomicilioBindingList()
        {
            return dal.DomicilioBindingList();
        }

        //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 doicilio edu  fin
        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      Nota  edu*

        public IEnumerable<Nota> GetNotas(Expression<Func<Nota, bool>> filter = null,
                                 Func<IQueryable<Nota>, IOrderedQueryable<Nota>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetNotas(filter, orderBy, includeProperties);
        }                       //ok

        public Nota GetNotaByID(object id)
        {
            return dal.GetNotaByID(id);
        }
        public void AgregarNota(Nota pp)
        {
            dal.AgregarNota(pp);
        }               //ok
        public void BorrarNota(object id)
        {
            dal.BorrarNota(id);
        }              //ok

        public void BorrarNota(Nota pp)
        {
            dal.BorrarNota(pp);
        }               //ok
        public void ActualizarNota(Nota pp)
        {
            dal.ActualizarNota(pp);
        }               //ok
        public BindingList<Nota> NotaBindingList()
        {
            return dal.NotaBindingList();
        }
        //public int ObtenerProximoNumeroDeNota()
        //{
        //    if (dal.GetNotas().Any())
        //    {
        //        return dal.GetNotas().Max(c => c.NotaID) + 1;

        //    }
        //    else
        //        return 1;
        //}
        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      Nota  edu FIN*



        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      NOTACD  edu*

        public IEnumerable<NotasCD> GetNotasCD(Expression<Func<NotasCD, bool>> filter = null,
                                 Func<IQueryable<NotasCD>, IOrderedQueryable<NotasCD>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetNotasCD(filter, orderBy, includeProperties);
        }                       //ok
        public IEnumerable<NotasCD> GetNotasCD(int BaseIDb, Expression<Func<NotasCD, bool>> filter = null,
                                 Func<IQueryable<NotasCD>, IOrderedQueryable<NotasCD>> orderBy = null,
                                 string includeProperties = "")
        {
            return GetDal(BaseIDb).GetNotasCD(filter, orderBy, includeProperties);
        }
        public NotasCD GetNotasCDByID(object id)
        {
            return dal.GetNotasCDByID(id);
        }
        public void AgregarNotasCD(NotasCD pp)
        {
            dal.AgregarNotasCD(pp);
        }               //ok
        public void BorrarNotasCD(object id)
        {
            dal.BorrarNotasCD(id);
        }              //ok

        public void BorraNotasCD(NotasCD pp)
        {
            dal.BorrarNotasCD(pp);
        }               //ok
        public void ActualizarNotasCD(NotasCD pp)
        {
            dal.ActualizarNotasCD(pp);
        }               //ok
        public BindingList<NotasCD> NotasCDBindingList()
        {
            return dal.NotasCDBindingList();
        }

        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      NOTASCD  edu FIN*




        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      Cuota  edu*
        public IEnumerable<Cuota> GetCuotas(Expression<Func<Cuota, bool>> filter = null,
                                 Func<IQueryable<Cuota>, IOrderedQueryable<Cuota>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetCuotas(filter, orderBy, includeProperties);
        }                       //ok
        public IEnumerable<Cuota> GetCuotas(int BaseIDb, Expression<Func<Cuota, bool>> filter = null,
                                 Func<IQueryable<Cuota>, IOrderedQueryable<Cuota>> orderBy = null,
                                 string includeProperties = "")
        {
            return GetDal(BaseIDb).GetCuotas(filter, orderBy, includeProperties);
        }
        public Cuota GetCuotaByID(object id)
        {
            return dal.GetCuotaByID(id);
        }
        public void AgregarCuota(Cuota pp)
        {
            dal.AgregarCuota(pp);
        }               //ok
        public void BorrarCuota(object id)
        {
            dal.BorrarCuota(id);
        }              //ok

        public void BorrarCuota(Cuota pp)
        {
            dal.BorrarCuota(pp);
        }               //ok
        public void ActualizarCuota(Cuota pp)
        {
            dal.ActualizarCuota(pp);
        }               //ok
        public BindingList<Cuota> CuotaBindingList()
        {
            return dal.CuotaBindingList();
        }

        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      Cuota  edu FIN*
        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      Cobranzas  edu*

        public IEnumerable<Cobranza> GetCobranzas(Expression<Func<Cobranza, bool>> filter = null,
                                 Func<IQueryable<Cobranza>, IOrderedQueryable<Cobranza>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetCobranzas(filter, orderBy, includeProperties);
        }                       //ok
        public IEnumerable<Cobranza> GetCobranzas(int BaseIDb, Expression<Func<Cobranza, bool>> filter = null,
                         Func<IQueryable<Cobranza>, IOrderedQueryable<Cobranza>> orderBy = null,
                         string includeProperties = "")
        {
            return GetDal(BaseIDb).GetCobranzas(filter, orderBy, includeProperties);
        }
        public Cobranza GetCobranzaByID(object id)
        {
            return dal.GetCobranzaByID(id);
        }
        public void AgregarCobranza(Cobranza pp)
        {
            dal.AgregarCobranza(pp);
        }               //ok
        public void BorrarCobranza(object id)
        {
            dal.BorrarCobranza(id);
        }              //ok

        public void BorrarCobranza(Cobranza pp)
        {
            dal.BorrarCobranza(pp);
        }               //ok
        public void ActualizarCobranza(Cobranza pp)
        {
            dal.ActualizarCobranza(pp);
        }               //ok
        public BindingList<Cobranza> CobranzaBindingList()
        {
            return dal.CobranzaBindingList();
        }
        public int ObtenerProximoNumeroDeCobranza()
        {
            if (dal.GetCobranzas().Any())
            {
                return dal.GetCobranzas().Max(c => c.CobranzaID) + 1;

            }
            else
                return 1;
        }

        public void ConvertirCobranzaDebitoEfectivo(Cobranza cob,Comercio Com)
        {
            if (EsCobranzaPorDebito(cob))
                ConvertirCobranzaAEfectivo(cob,Com);
            else
                ConvertirCobranzaADebito(cob,Com);
        }

        public void ConvertirCobranzaADebito(Cobranza cob,Comercio Com)
        {
            
            GrabarRecibo(Com, null, cob.ImporteTotal, DateTime.Now, null, null, null,pGlob.Provisorio,
                                    cob.Usuario, false, null, null, null, pGlob.TmCobPorDebito,cob.EmpresaID, cob.ComercioID,
                                    cob.CreditoID, cob.CuotaID, cob.CobranzaID);
        }

        public void ConvertirCobranzaAEfectivo(Cobranza cob,Comercio Com)
        {
            CuentaCorriente ccdeb = null;
            int ComercioID = cob.ComercioID;
            int EmpresaID = cob.EmpresaID;
            int GestionID = cob.ComercioID;
            Recibo rec;
            if (cob.ComercioID != Com.ComercioID)
            {
                GestionID = Com.ComercioID;
                rec = Get<Recibo>(cob.EmpresaID, r => r.EmpresaID == EmpresaID && r.ComercioID == GestionID
                                                 && r.ComercioAdheridoEmpresaID == EmpresaID && r.ComercioAdheridoComercioID == ComercioID
                                && r.CreditoID == cob.CreditoID && r.CuotaID == cob.CuotaID && r.CobranzaID == cob.CobranzaID
                                                && (r.TipoMovimientoID == pGlob.TmCobPorDebito.TipoMovimientoID)).FirstOrDefault();
            }
            else
            {
                rec = Get<Recibo>(cob.EmpresaID, r => r.EmpresaID == Com.EmpresaID && r.ComercioID == Com.ComercioID &&
                                                r.CreditoID == cob.CreditoID && r.CuotaID == cob.CuotaID && r.CobranzaID == cob.CobranzaID
                                                && (r.TipoMovimientoID == pGlob.TmCobPorDebito.TipoMovimientoID)).FirstOrDefault();
            }
            
            if (rec != null)
            {
                if (rec.EstadoID == pGlob.Anulado.EstadoID)
                    MessageBox.Show("La Cobranza ya tiene una anulación de cobranza por débito");                    
                else
                {
                    CuentaCorriente cc = Get<CuentaCorriente>(rec.EmpresaID, c => c.EmpresaID == EmpresaID
                                            && c.ComercioID == ComercioID && c.GestionID == GestionID
                                            && c.ReciboID == rec.ReciboID 
                                            && c.CreditoID == rec.CreditoID && c.CuotaID == rec.CuotaID 
                                            && c.CobranzaID == rec.CobranzaID).FirstOrDefault();
                    if (cc != null)
                    {
                       ccdeb =  AnularRecibo(rec, cob);            
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encuentra el recibo de débito correspondiente"); 
            }

            Grabar(rec.EmpresaID);

            List<Transmision> ltrans = new List<Transmision>();
            ltrans = Transmision<Recibo>(ltrans, rec, cob.Comercio, pGlob.TransBajaRecibo, pGlob.UriRecibos);
            ltrans = Transmision<CuentaCorriente>(ltrans, ccdeb, cob.Comercio, pGlob.TransImputacionCC, pGlob.UriRecibos);
            GrabarTransmisiones(rec.EmpresaID, ltrans);

        }

        public CuentaCorriente AnularRecibo(Recibo rec,Cobranza cob)
        {
            CuentaCorriente ccDeb = null;
            if (rec != null)
            {
                rec.EstadoID = pGlob.Anulado.EstadoID;
                if (rec.TransferenciasDepositos != null)
                    rec.TransferenciasDepositos.EstadoID = pGlob.Anulado.EstadoID;
                ActualizarTransaccional<Recibo>(rec.EmpresaID, rec);
                ccDeb = ImputarAnulacionCobranzaDebitoACuentaCorriente(cob, rec);               
            }
            return ccDeb;
        }


        public bool EsCobranzaPorDebito(Cobranza cob)
        {
            Recibo rec = Get<Recibo>(cob.EmpresaID,r=> r.CreditoID == cob.CreditoID && r.CuotaID == cob.CuotaID && r.CobranzaID == cob.CobranzaID
                                                && (r.TipoMovimientoID == pGlob.TmCobPorDebito.TipoMovimientoID || r.TipoMovimientoID == pGlob.TmAnuCobPorDebito.TipoMovimientoID)).FirstOrDefault();
            if (rec != null)
            {
                return true;
            }
            return false;
        }

        public decimal EsCobranzaPorDebitoImp(Cobranza cob)
        {
            Recibo rec = Get<Recibo>(cob.EmpresaID, r => r.CreditoID == cob.CreditoID && r.CuotaID == cob.CuotaID && r.CobranzaID == cob.CobranzaID
                                                && (r.TipoMovimientoID == pGlob.TmCobPorDebito.TipoMovimientoID || r.TipoMovimientoID == pGlob.TmAnuCobPorDebito.TipoMovimientoID)).FirstOrDefault();
            if (rec != null)
            {
                return rec.Importe;
            }
            return 0;
        }


        public string TipoCobranza(Cobranza cob)
        {
            decimal importeDeb = 0;
            importeDeb = EsCobranzaPorDebitoImp(cob);
            if (pGlob.TpaDebitoDirecto == null)
            {
                return "VACIO";

            }
            else
            {
                if (cob.TipoPagoID == pGlob.TpaDebitoDirecto.TipoPagoID)
                    return pGlob.TpaDebitoDirecto.Nombre;
                else if (cob.TipoPagoID == pGlob.TpaTarjetaCredito.TipoPagoID)
                    return pGlob.TpaTarjetaCredito.Nombre;
                else if (importeDeb > 0) //Se hace así porque muchas cobranzas no estan marcadas como con tarjeta de crédito
                    return String.Format("{0}:{1:##.00}", pGlob.TpaTarjetaDebito.Nombre, importeDeb);
                else
                    return "MANUAL";
            }
        }

        //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333      Cobranzas  edu FIN*

        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesTipo  edu*
        public IEnumerable<PlanesTipo> GetPlanesTipos(Expression<Func<PlanesTipo, bool>> filter = null,
                                 Func<IQueryable<PlanesTipo>, IOrderedQueryable<PlanesTipo>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetPlanesTipos(filter, orderBy, includeProperties);
        }                       //ok

        public PlanesTipo GetPlanesTipoByID(object id, int nBaseID)
        {
            return GetDal(nBaseID).GetPlanesTipoByID(id);
            //return dal.GetPlanesTipoByID(id);
        }

        public void AgregarPlanesTipo(PlanesTipo pp, int nBaseID)
        {
            GetDal(nBaseID).AgregarPlanesTipo(pp);
            //dal.AgregarPlanesTipo(pp);
        }               //ok

        public void BorrarPlanesTipo(object id)
        {
            dal.BorrarPlanesTipo(id);
        }              //ok

        public void BorrarPlanesTipo(PlanesTipo pp)
        {
            dal.BorrarPlanesTipo(pp);
        }               //ok
        public void ActualizarPlanesTipo(PlanesTipo pp, int nBaseID)
        {
            GetDal(nBaseID).ActualizarPlanesTipo(pp);
            //dal.ActualizarPlanesTipo(pp);
        }               //ok

        public BindingList<PlanesTipo> PlanesTipoBindingList()
        {
            return dal.PlanesTipoBindingList();
        }
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesTipo  edu  FIN*
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesdetalle  edu*
        public IEnumerable<PlanesDetalle> GetPlanesDetalles(Expression<Func<PlanesDetalle, bool>> filter = null,
                                 Func<IQueryable<PlanesDetalle>, IOrderedQueryable<PlanesDetalle>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetPlanesDetalles(filter, orderBy, includeProperties);
        }                       //ok

        public PlanesDetalle GetPlanesDetalleByID(object id, int nBaseID)
        {
            return GetDal(nBaseID).GetPlanesDetalleByID(id);
            //return dal.GetPlanesDetalleByID(id);
        }
        public void AgregarPlanesDetalle(PlanesDetalle pp, int nBaseID)
        {
            GetDal(nBaseID).AgregarPlanesDetalle(pp);
            //dal.AgregarPlanesDetalle(pp);
        }               //ok
        public void BorrarPlanesDetalle(object id)
        {
            dal.BorrarPlanesDetalle(id);
        }              //ok

        public void BorrarPlanesDetalle(PlanesDetalle pp)
        {
            dal.BorrarPlanesDetalle(pp);
        }               //ok
        public void ActualizarPlanesDetalle(PlanesDetalle pp, int nBaseID)
        {
            GetDal(nBaseID).ActualizarPlanesDetalle(pp);
            //dal.ActualizarPlanesDetalle(pp);
        }               //ok
        public BindingList<PlanesDetalle> PlanesDetalleBindingList()
        {
            return dal.PlanesDetalleBindingList();
        }
        public int ObtenerProximoNumeroDePlanesDeta(int nBaseID)
        {

            if (GetDal(nBaseID).GetPlanesDetalles().Any())
            {
                return GetDal(nBaseID).GetPlanesDetalles().Max(p => Convert.ToInt16(p.PlanesDetalleID) + 1);
            }
            else return 1;

            //    if (dal.GetPlanesDetalles().Any())
            //{
            //    return dal.GetPlanesDetalles().Max(p => Convert.ToInt16(p.PlanesDetalleID) + 1);
            //}
            //else
            //    return 1;
        }
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesdetalle  edu*  FIN

        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesVENCI  edu*
        public IEnumerable<PlanesVenci> GetPlanesVencis(Expression<Func<PlanesVenci, bool>> filter = null,
                                 Func<IQueryable<PlanesVenci>, IOrderedQueryable<PlanesVenci>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetPlanesVencis(filter, orderBy, includeProperties);
        }                       //ok

        public PlanesVenci GetPlanesVenciByID(object id, int nBaseID)
        {
            return GetDal(nBaseID).GetPlanesVenciByID(id);
            //return dal.GetPlanesVenciByID(id);
        }
        public void AgregarPlanesVenci(PlanesVenci pp, int nBaseID)
        {
            GetDal(nBaseID).AgregarPlanesVenci(pp);
            //dal.AgregarPlanesVenci(pp);
        }               //ok
        public void BorrarPlanesVenci(object id)
        {
            dal.BorrarPlanesVenci(id);
        }              //ok

        public void BorrarPlanesVenci(PlanesVenci pp)
        {
            dal.BorrarPlanesVenci(pp);
        }               //ok
        public void ActualizarPlanesVenci(PlanesVenci pp, int nBaseID)
        {
            GetDal(nBaseID).ActualizarPlanesVenci(pp);
            //dal.ActualizarPlanesVenci(pp);
        }               //ok
        public BindingList<PlanesVenci> PlanesVenciBindingList()
        {
            return dal.PlanesVenciBindingList();
        }

        public int ObtenerProximoNumeroDePlanesVenci(int nBaseID)
        {
            if (GetDal(nBaseID).GetPlanesVencis().Any())
            {
                return GetDal(nBaseID).GetPlanesVencis().Max(p => Convert.ToInt16(p.PlanesVenciID) + 1);
            }
            else return 1;

            //if (dal.GetPlanesVencis().Any())
            //{
            //    return dal.GetPlanesVencis().Max(p => Convert.ToInt16(p.PlanesVenciID) + 1);
            //}
            //else
            //    return 1;
        }

        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesVENCI  edu*    FIN
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesBONIF  edu*
        public IEnumerable<PlanesBonif> GetPlanesBonifs(Expression<Func<PlanesBonif, bool>> filter = null,
                                 Func<IQueryable<PlanesBonif>, IOrderedQueryable<PlanesBonif>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetPlanesBonifs(filter, orderBy, includeProperties);
        }                       //ok

        public PlanesBonif GetPlanesBonifByID(object id, int nBaseID)
        {
            return GetDal(nBaseID).GetPlanesBonifByID(id);
            //return dal.GetPlanesBonifByID(id);
        }
        public void AgregarPlanesBonif(PlanesBonif pb, int nBaseID)
        {
            GetDal(nBaseID).AgregarPlanesBonif(pb);
            //dal.AgregarPlanesBonif(pb);
        }               //ok
        public void BorrarPlanesBonif(object id)
        {
            dal.BorrarPlanesBonif(id);
        }              //ok

        public void BorrarPlaneBonif(PlanesBonif pb)
        {
            dal.BorrarPlanesBonif(pb);
        }               //ok
        public void ActualizarPlanesBonif(PlanesBonif pb, int nBaseID)
        {
            GetDal(nBaseID).ActualizarPlanesBonif(pb);
            //dal.ActualizarPlanesBonif(pb);
        }               //ok
        public BindingList<PlanesBonif> PlanesBonifBindingList()
        {
            return dal.PlanesBonifBindingList();
        }

        public int ObtenerProximoNumeroDePlanesBonif(int nBaseID)
        {

            if (GetDal(nBaseID).GetPlanesBonifs().Any())
            {
                return GetDal(nBaseID).GetPlanesBonifs().Max(p => Convert.ToInt16(p.PlanesBonifID) + 1);
            }
            else return 1;

            //    if (dal.GetPlanesBonifs().Any())
            //{
            //    return dal.GetPlanesBonifs().Max(p => Convert.ToInt16(p.PlanesBonifID) + 1);
            //}
            //else
            //    return 1;
        }
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesBONIF  edu*    FIN
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesparam  edu*
        public IEnumerable<PlanesParam> GetPlanesParams(Expression<Func<PlanesParam, bool>> filter = null,
                                 Func<IQueryable<PlanesParam>, IOrderedQueryable<PlanesParam>> orderBy = null,
                                 string includeProperties = "")
        {
            return dal.GetPlanesParams(filter, orderBy, includeProperties);
        }                       //ok

        public PlanesParam GetPlanesParamByID(object id)
        {
            return dal.GetPlanesParamByID(id);
        }
        public void AgregarPlanesParam(PlanesParam pb)
        {
            dal.AgregarPlanesParam(pb);
        }               //ok
        public void BorrarPlanesParam(object id)
        {
            dal.BorrarPlanesParam(id);
        }              //ok

        public void BorrarPlaneParam(PlanesParam pb)
        {
            dal.BorrarPlanesParam(pb);
        }               //ok
        public void ActualizarPlanesParam(PlanesParam pb)
        {
            dal.ActualizarPlanesParam(pb);
        }               //ok
        public BindingList<PlanesParam> PlanesParamBindingList()
        {
            return dal.PlanesParamBindingList();
        }

        public int ObtenerProximoNumeroDePlanesParam()
        {
            if (dal.GetPlanesParams().Any())
            {
                return dal.GetPlanesParams().Max(p => p.PlanesParamId + 1);
            }
            else
                return 1;
        }
        //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      planesparam  edu*    FIN
        //**edu** fin
        #endregion  //**edu**






        public void ImprimirAlta(Credito cred,bool EsM)
        {
            CuentaBancariaCliente cbc = null;
            CuentaBancaria cb = null;
            if (pGlob.Configuracion.ImprimirComprobantes)
            {
                TipoImpresion tipoImpresion = GetByID<TipoImpresion>(1);
                TipoImpresion tipoImpresionDebito = pGlob.ImpDebito;

                if (!String.IsNullOrEmpty(cred.NumCuentaBancaria))
                {
                    cbc = cred.Cliente.CuentasBancariasCliente.Where(c => c.NumCuentaBancaria == cred.NumCuentaBancaria).FirstOrDefault();

                    cb = GetCuentaDebitoDirecto(cred.Comercio);

                    if (cb == null)
                    {
                        MessageBox.Show("No se encuentra la Cuenta Bancaria de la Empresa para el débito, o no está configurada");
                        return;
                    }
                }                  

                if (tipoImpresion == null)
                {
                    throw new ErrorException(Properties.Resources.TipoImpresionAltaNoDefinida);
                }
                else if (tipoImpresion.Impresora == null && tipoImpresion.Impresora == String.Empty)
                {
                    throw new ErrorException(Properties.Resources.ImpresoraAltaNoDefinida);
                }
                else
                {
                    Impresion imp = new Impresion();
                    Image logo = LogoEmpresa(cred.Empresa);
                    imp.ImprimirAlta(cred, pGlob.Configuracion.AltaLugar, DateTime.Now.ToShortDateString(),
                                    pGlob.Configuracion.AltaTribunales, tipoImpresion.Impresora,
                                    logo, EsM, pGlob.Configuracion.Titulo, pGlob.Configuracion.Financia,
                                    pGlob.Configuracion.ImprimirCredTalonComercio,tipoImpresionDebito.Impresora,cbc,cb,pGlob.Configuracion.CantImpBoni);
                }
            }            
        }

        public void ImprimirCobranza(Cobranza cob,bool EsM)
        {
            if (pGlob.Configuracion.ImprimirComprobantesCob)
            {
                TipoImpresion tipoImpresion = GetByID<TipoImpresion>(4);
                if (tipoImpresion == null)
                {
                    throw new ErrorException(Properties.Resources.TipoImpresionCobranzaNoDefinida);
                }
                else if (tipoImpresion.Impresora == null && tipoImpresion.Impresora == String.Empty)
                {
                    throw new ErrorException(Properties.Resources.ImpresoraCobranzaNoDefinida);
                }
                else
                {
                    Impresion imp = new Impresion();
                    Image logo = LogoEmpresa(cob.Empresa);
                    imp.ImprimirCobranza(this,cob,EsM,logo,tipoImpresion.Impresora,pGlob.Configuracion.Titulo,pGlob.Configuracion.Financia,
                                        pGlob.Configuracion.ImprimirCobTalonComercio);
                }
            }
        }

        public string ProximoVencimiento(Cobranza cob)
        {
            Cuota cuo = cob.Credito.Cuotas.Where(c => c.CuotaID == cob.CuotaID + 1).FirstOrDefault();
            if (cuo != null)
            {
                return cuo.FechaVencimiento.ToShortDateString();
            }
            return null;
        }

        public string Observaciones(Cobranza cob)
        {
            string obs = "";
            if (cob.ImportePago < cob.Cuota.Importe)
            {
                obs += "PAGO A CUENTA " + Environment.NewLine;
            }

            if (cob.Cuota.Deuda == 0)
            {
                obs += "CUOTA CANCELADA " + Environment.NewLine;
            }

            decimal sumDeuda = cob.Credito.Cuotas.Sum(c => c.Deuda);
            decimal sumImpPagoCobranzas = cob.Credito.Cobranzas.Sum(c => c.ImportePago);
            decimal sumImpCuotas = cob.Credito.Cuotas.Sum(c => c.Importe);

            if (sumDeuda == 0 && cob.Credito.CantidadCuotas == cob.CuotaID && sumImpCuotas == sumImpPagoCobranzas)
            {
                obs += "CREDITO CANCELADO " + " " + Environment.NewLine;
            }
            //if (cob.Credito != null && cob.Credito.Cancelado)
            ////else if (cob.Credito != null && cob.Credito.CantidadCuotas == cob.CuotaID && cob.Cuota != null && cob.Cuota.Deuda <= 0)
            //{
            //    obs = "CREDITO CANCELADO";
            //}

            if (cob.TipoBonificacionID != null && cob.TipoBonificacion != null && cob.TipoBonificacionID != "N")
            {
                obs += "CUOTA BONIFICADA " + " " + Environment.NewLine;

            }

            if (cob.Gestion.ComercioID != cob.ComercioID && cob.Gestion != null)
            {
                obs += "SUC. " + cob.Gestion.NumeroYNombre + " " + Environment.NewLine;
            }
            return obs;

            //           Select Case DatCobr.Fields!APago
            //             Case Is = "A"
            //                FlexCobr.Text = "A Cuenta"

            //            Case Is = "C"
            //                FlexCobr.Text = "Cuota"

            //            Case Is = "B"
            //                FlexCobr.Text = "Bonificada"

            //            Case Is = "G"
            //                FlexCobr.Text = "Arreglo"

            //            Case Is = "T"
            //                FlexCobr.Text = "Anticipado"

            //            Case Is = "R"
            //                FlexCobr.Text = "Refinanciada"

            //            Case Is = "N"
            //                FlexCobr.Text = "Anulada"
            //            Case Is = "M"
            //                FlexCobr.Text = "Arr. Moroso"


            //             If qPago = "Cancela Cuota" Then qPago = " "
            //qDescuen = ""

            //            If qPago = "Bonificado" Then
            //            qDescuen = "Cuota bonificada"
            //        End If
            //        qPago = "CREDITO CANCELADO"
        }


        /**M**/
        public List<MetodoFuncionamiento> GetMetodosFuncionamiento()
        {
            List<MetodoFuncionamiento> l = new List<MetodoFuncionamiento>();
            l.Add(pGlob.mfNormal);
            l.Add(pGlob.mfAutomatico);
            l.Add(pGlob.mfManual);
            return l;
        }

        public bool LlevaM()
        {
            return (pGlob.Configuracion.cLlevaMor == pGlob.mfManual.MetodoFuncionamientoID
                    || pGlob.Configuracion.cLlevaMor == pGlob.mfAutomatico.MetodoFuncionamientoID);
        }

        public bool LlevaMA()
        {
            return (pGlob.Configuracion.cLlevaMor == pGlob.mfAutomatico.MetodoFuncionamientoID);
        }
        public bool LlevaMM()
        {
            return (pGlob.Configuracion.cLlevaMor == pGlob.mfManual.MetodoFuncionamientoID);
        }
        
        public void SetMM()
        {
            pGlob.Configuracion.cLlevaMor = pGlob.mfManual.MetodoFuncionamientoID;
        }


        /**M**/

        

        /* Datos Maestros */ 
        public void GenerarDatosMaestros()
        {
            using (var context = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext")))
            {
                var perfiles = new List<Perfil>
            {
            new Perfil{nombre="Admin",descripcion="Admin",creacion=DateTime.Parse("2005-09-01"),activo=true,Permisos = new ObservableListSource<Permiso>()},
            new Perfil{nombre="Usuario",descripcion="usuario",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()},
            new Perfil{nombre="Encargado",descripcion="Encargado",creacion=DateTime.Parse("2005-09-01"),activo=true, Permisos = new ObservableListSource<Permiso>()},
            };
                perfiles.ForEach(s => context.Perfiles.Add(s));
                context.SaveChanges();


                var usuarios = new List<Usuario>
            {
                new Usuario{usuario="admin",nombre="Admin",apellido="Admin",pass="1234",creacion=DateTime.Parse("2005-09-01"),activo=true,Perfiles = new ObservableListSource<Perfil>()},
               // new Usuario{usuario="cdc",nombre="Christian Damian",apellido="Cristofano",pass="1234",creacion=DateTime.Parse("2005-09-01"),activo=true},
            };

                usuarios.ForEach(s => context.Usuarios.Add(s));
                context.SaveChanges();

                Usuario usu = context.Usuarios.SingleOrDefault(x => x.nombre == "Admin");
                ObservableListSource<Perfil> pers = usu.Perfiles;
                Perfil perf = context.Perfiles.SingleOrDefault(p => p.nombre == "Admin");
                pers.Add(perf);
                context.SaveChanges();

                /*var usuariosPerfiles = new List<UsuarioPerfil>
                {
                new UsuarioPerfil{UsuarioID=0,PerfilID=0},
                new UsuarioPerfil{UsuarioID=0,PerfilID=1},
                new UsuarioPerfil{UsuarioID=0,PerfilID=2},
                new UsuarioPerfil{UsuarioID=1,PerfilID=0},
                new UsuarioPerfil{UsuarioID=1,PerfilID=1},
                };
                usuariosPerfiles.ForEach(s => context.UsuariosPerfiles.Add(s));
                context.SaveChanges();*/


                var permisos = new List<Permiso>
            {
            new Permiso{nombre="Admin",descripcion="Admin",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="Estadistcas",descripcion="Estadistcas",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="Altas",descripcion="Altas",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuFondos",descripcion="mnuFondos",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuConfiguracion",descripcion="mnuConfiguracion",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuAdminUsuarios",descripcion="mnuAdminUsuarios",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuSolicitarFondos",descripcion="mnuSolicitarFondos",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuUsuarios",descripcion="mnuUsuarios",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuAdminPerfiles",descripcion="mnuAdminPerfiles",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuPerfiles",descripcion="mnuPerfiles",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuAsignarPerfilesUsuarios",descripcion="mnuAsignarPerfilesUsuarios",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuPermisos",descripcion="mnuPermisos",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuOpciones",descripcion="mnuOpciones",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuAsignarPermisosPerfiles",descripcion="mnuAsignarPermisosPerfiles",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuCuentaCorriente",descripcion="mnuCuentaCorriente",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuVerCuentaCorriente",descripcion="mnuVerCuentaCorriente",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuProveedores",descripcion="mnuProveedores",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuListadoDeProveedores",descripcion="mnuListadoDeProveedores",creacion=DateTime.Parse("2005-09-01"),activo=true},
            new Permiso{nombre="mnuABMProveedores",descripcion="mnuABMProveedores",creacion=DateTime.Parse("2005-09-01"),activo=true},


            };
                permisos.ForEach(s => context.Permisos.Add(s));
                context.SaveChanges();

                perf = context.Perfiles.SingleOrDefault(x => x.nombre == "Admin");
                permisos.ForEach(s => perf.Permisos.Add(s));
                context.SaveChanges();

                var Empresas = new List<Empresa>
            {
            new Empresa{EmpresaID = 1,Nombre = "Credin S.A.",Descripcion = "Credin S.A."},
            new Empresa{EmpresaID = 2,Nombre = "ACuatro S.A.",Descripcion = "ACuatro S.A."},
            new Empresa{EmpresaID = 3,Nombre = "Crédito del Valle S.A.",Descripcion = "Crédito del Valle S.A."},
            };
                Empresas.ForEach(e => context.Empresas.Add(e));
                context.SaveChanges();

                var Comercios = new List<Comercio>
            {
                new Comercio{ComercioID = 801,Nombre = "Receptoría Rivadavia",Descripcion = "Receptoría Rivadavia",EmpresaID = 1,Tolerancia = 6, ToleranciaBoni = 0}
            };
                Comercios.ForEach(c => context.Comercios.Add(c));
                context.SaveChanges();


                var TipoEstados = new List<TipoEstado>
            {
                new TipoEstado{TipoEstadoID=1,Nombre = "EstadoCuentasBancariasEmpleados",Descripcion = "EstadoCuentasBancariasEmpleados"},
                new TipoEstado{TipoEstadoID=2,Nombre = "EstadoCuentasBancariasEmpresas",Descripcion = "EstadoCuentasBancariasEmpresas"},
                new TipoEstado{TipoEstadoID=3,Nombre = "EstadoChequeras",Descripcion = "EstadoChequeras"},
                new TipoEstado{TipoEstadoID=4,Nombre = "EstadoMensajes",Descripcion = "EstadoMensajes"},
                new TipoEstado{TipoEstadoID=5,Nombre = "EstadoAlertas",Descripcion = "EstadoAlertas"},
                new TipoEstado{TipoEstadoID=6,Nombre = "EstadoSolicitudesFondos",Descripcion = "EstadoSolicitudesFondos"},
                new TipoEstado{TipoEstadoID=7,Nombre = "EstadoAutorizaciones",Descripcion = "EstadoAutorizaciones"},
                new TipoEstado{TipoEstadoID=8,Nombre = "EstadoOrdenesDePago",Descripcion = "EstadoOrdenesDePago"},
                new TipoEstado{TipoEstadoID=9,Nombre = "EstadoEmpleados",Descripcion = "EstadoEmpleados"},
                new TipoEstado{TipoEstadoID=10,Nombre = "EstadoUsuarios",Descripcion = "EstadoUsuarios"},
                new TipoEstado{TipoEstadoID=11,Nombre = "EstadoCreditos",Descripcion = "EstadoCreditos"},
                new TipoEstado{TipoEstadoID=12,Nombre = "EstadoCheques",Descripcion = "EstadoCheques"}
            };
                TipoEstados.ForEach(c => context.TiposEstados.Add(c));
                context.SaveChanges();

                var Estados = new List<Estado>
            {
                new Estado{EstadoID = 1,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=1,est_color = "WHITE"},  
                new Estado{EstadoID = 2,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=1,est_color = "WHITE"},
                new Estado{EstadoID = 3,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=2,est_color = "WHITE"},
                new Estado{EstadoID = 4,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=2,est_color = "WHITE"},
                new Estado{EstadoID = 5,Nombre="Habilitada",Descripcion="Habilitada",TipoEstadoID=3,est_color = "WHITE"},
                new Estado{EstadoID = 6,Nombre="Inhabilitada",Descripcion="Inhabilitada",TipoEstadoID=3,est_color = "WHITE"},
                new Estado{EstadoID = 7,Nombre="Enviado",Descripcion="Enviado",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 8,Nombre="En espera",Descripcion="En espera",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 9,Nombre="Recibido",Descripcion="Recibido",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 10,Nombre="Leido",Descripcion="Leido",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 11,Nombre="No Leido",Descripcion="No Leido",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 12,Nombre="Destacado",Descripcion="Destacado",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 13,Nombre="Importante",Descripcion="Importante",TipoEstadoID=4,est_color = "WHITE"},
                new Estado{EstadoID = 14,Nombre="Enviada",Descripcion="Enviada",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 15,Nombre="En espera",Descripcion="En espera",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 16,Nombre="Recibida",Descripcion="Recibida",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 17,Nombre="Leida",Descripcion="Leida",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 18,Nombre="No Leida",Descripcion="No Leida",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 19,Nombre="Destacada",Descripcion="Destacada",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 20,Nombre="Importante",Descripcion="Importante",TipoEstadoID=5,est_color = "WHITE"},
                new Estado{EstadoID = 21,Nombre="Inicial",Descripcion="Inicial",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 22,Nombre="Pendiente de resolución en tesorería",Descripcion="Pendiente de resolución en tesorería",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 23,Nombre="Rechazada en tesorería",Descripcion="Rechazada en tesorería",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 24,Nombre="Pendiente de resolución en gerencia",Descripcion="Pendiente de resolución en gerencia",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 25,Nombre="Autorizada en gerencia",Descripcion="Autorizada en gerencia",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 26,Nombre="Rechazada en gerencia",Descripcion="Rechazada en gerencia",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 28,Nombre="Autorizada",Descripcion="Autorizada",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 33,Nombre="Confirmada",Descripcion="Confirmada",TipoEstadoID=6,est_color = "WHITE"},
                new Estado{EstadoID = 34,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=7,est_color = "WHITE"},
                new Estado{EstadoID = 35,Nombre="En espera",Descripcion="En espera",TipoEstadoID=7,est_color = "WHITE"},
                new Estado{EstadoID = 36,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=7,est_color = "WHITE"},
                new Estado{EstadoID = 37,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=7,est_color = "WHITE"},
                new Estado{EstadoID = 38,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=7,est_color = "WHITE"},
                new Estado{EstadoID = 39,Nombre="Aceptada",Descripcion="Aceptada",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 40,Nombre="En espera",Descripcion="En espera",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 41,Nombre="Rechazada",Descripcion="Rechazada",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 42,Nombre="Anulada",Descripcion="Anulada",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 43,Nombre="Pagada",Descripcion="Pagada",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 44,Nombre="Emitida",Descripcion="Emitida",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 45,Nombre="Conformada",Descripcion="Conformada",TipoEstadoID=8,est_color = "WHITE"},
                new Estado{EstadoID = 46,Nombre="Activo",Descripcion="Activo",TipoEstadoID=9,est_color = "WHITE"},
                new Estado{EstadoID = 47,Nombre="Desvinculado",Descripcion="Desvinculado",TipoEstadoID=9,est_color = "WHITE"},
                new Estado{EstadoID = 48,Nombre="Activo",Descripcion="Activo",TipoEstadoID=10,est_color = "WHITE"},
                new Estado{EstadoID = 49,Nombre="Inactivo",Descripcion="Inactivo",TipoEstadoID=10,est_color = "WHITE"},
                new Estado{EstadoID = 50,Nombre="Moroso",Descripcion="Moroso",TipoEstadoID=11,est_color = "WHITE"},
                new Estado{EstadoID = 51,Nombre="Activo",Descripcion="Activo",TipoEstadoID=11,est_color = "WHITE"},
                new Estado{EstadoID = 52,Nombre="Cancelado",Descripcion="Cancelado",TipoEstadoID=11,est_color = "WHITE"},
                new Estado{EstadoID = 53,Nombre="Habilitado",Descripcion="Habilitado",TipoEstadoID=12,est_color = "WHITE"},
                new Estado{EstadoID = 54,Nombre="Inhabilitado",Descripcion="Inhabilitado",TipoEstadoID=12,est_color = "WHITE"},
                new Estado{EstadoID = 56,Nombre="Anulado",Descripcion="Anulado",TipoEstadoID=12,est_color = "WHITE"},
                new Estado{EstadoID = 58,Nombre="Utilizado",Descripcion="Utilizado",TipoEstadoID=12,est_color = "WHITE"},

            };
                Estados.ForEach(c => context.Estados.Add(c));
                context.SaveChanges();


                var MediosDePago = new List<MedioDePago>
            {
                new MedioDePago{MedioDePagoID=1,Nombre = "Efectivo",Descripcion = "Efectivo" },
                new MedioDePago{MedioDePagoID=2,Nombre = "Cheque",Descripcion = "Cheque" },
                new MedioDePago{MedioDePagoID=3,Nombre = "Transferencia Bancaria",Descripcion = "Transferencia Bancaria" }
            };
                MediosDePago.ForEach(m => context.MediosDePagos.Add(m));
                context.SaveChanges();

                var ConceptoFondos = new List<ConceptoFondos>
            {
                new ConceptoFondos{ConceptoFondosID=1,Nombre = "Retención de Cobranzas",Descripcion = "Retención de Cobranzas",MedioDePagoID =1 },
                new ConceptoFondos{ConceptoFondosID=2,Nombre = "Extración bancaria",Descripcion = "Extración bancaria",MedioDePagoID =2 },
                new ConceptoFondos{ConceptoFondosID=4,Nombre = "Retención de Valores a Rendir",Descripcion = "Retención de Valores a Rendir",MedioDePagoID =1 }

            };
                ConceptoFondos.ForEach(c => context.ConceptoFondos.Add(c));
                context.SaveChanges();

                var TiposSolicitud = new List<TipoSolicitud>
            {
                new TipoSolicitud{TipoSolicitudID=1,Nombre = "Ventas",Descripcion = "Ventas" },
                new TipoSolicitud{TipoSolicitudID=2,Nombre = "Cuentas a pagar",Descripcion = "Cuentas a pagar" },
                new TipoSolicitud{TipoSolicitudID=3,Nombre = "Fondo Fijo",Descripcion = "Fondo Fijo" },
                new TipoSolicitud{TipoSolicitudID=4,Nombre = "Venta Anticipada",Descripcion = "Venta Anticipada" },
            };
                TiposSolicitud.ForEach(t => context.TiposSolicitud.Add(t));
                context.SaveChanges();

                var EstadosTransmision = new List<EstadoTransmision>
            {
                new EstadoTransmision{EstadoTransmisionID=1,Nombre = "Enviado",Descripcion = "Enviado" },
                new EstadoTransmision{EstadoTransmisionID=2,Nombre = "Pendiente de envío",Descripcion = "Pendiente de envío" },
                new EstadoTransmision{EstadoTransmisionID=3,Nombre = "Recibido",Descripcion = "Recibido" }

            };
                EstadosTransmision.ForEach(t => context.EstadoTransmisiones.Add(t));
                context.SaveChanges();

                var ClasesMovimiento = new List<ClaseMovimiento>
            {
                new Ingreso{ClaseMovimientoID=1,Nombre = "Ingreso",Descripcion = "Ingreso" },
                new Egreso{ClaseMovimientoID=2,Nombre = "Egreso",Descripcion = "Egreso" }

            };
                ClasesMovimiento.ForEach(t => context.ClasesMovimientos.Add(t));
                context.SaveChanges();

                var TiposMovimiento = new List<TipoMovimiento>
            {
                new TipoMovimiento{TipoMovimientoID = 101, Nombre = "Ajuste Positivo Caja",Descripcion = "Ajuste Positivo Caja" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 014, Nombre = "Ajuste Negativo Caja",Descripcion = "Ajuste Negativo Caja" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 610, Nombre = "Depósito Cobranza Receptoría",Descripcion = "Depósito Cobranza Receptoría" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 020, Nombre = "Créditos Otorgados en Efectivo",Descripcion = "Créditos Otorgados en Efectivo" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 011, Nombre = "Descuento Cobranza por Cancelación Anticipada",Descripcion = "Descuento Cobranza por Cancelación Anticipada" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 013, Nombre = "Anulación Cobranza Receptoría",Descripcion = "Anulación Cobranza Receptoría" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 201, Nombre = "Anulación Créditos Otorgados en Efectivo",Descripcion = "Anulación Créditos Otorgados en Efectivo" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 012, Nombre = "Descuento Cobranza por Promoción Bonificada",Descripcion = "Descuento Cobranza por Promoción Bonificada" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 100, Nombre = "Cobranza Receptoría",Descripcion = "Cobranza Receptoría" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 200, Nombre = "Gastos Descontados a Creditos Otorgados",Descripcion = "Gastos Descontados a Creditos Otorgados" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 021, Nombre = "Anulación Gastos de Creditos Otorgados",Descripcion = "Anulación Gastos de Creditos Otorgados" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 120, Nombre = "Cobranza de Comercio Adherido",Descripcion = "Cobranza de Comercio Adherido" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 701, Nombre = "Valores a Depositar a Banco",Descripcion = "Valores a Depositar a Banco" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 023, Nombre = "Retiro de Bco A Caja",Descripcion = "Retiro de Bco A Caja" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 620, Nombre = "Deposito Cobr. Com Adherido",Descripcion = "Deposito Cobr. Com Adherido" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 230, Nombre = "Cuota Adelantada",Descripcion = "Cuota Adelantada" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 233, Nombre = "Anulacion de Cuota Adelantada",Descripcion = "Anulacion de Cuota Adelantada" ,Cod = "", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 022, Nombre = "Anulacion descuento Anticipada",Descripcion = "Anulacion descuento Anticipada" ,Cod = "", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 300, Nombre = "Cancelación Gs. por nosotros",Descripcion = "Cancelación Gs. por nosotros" ,Cod = "CGN", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 301, Nombre = "Devolución cheque propio",Descripcion = "Devolución cheque propio" ,Cod = "DCH", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 302, Nombre = "Descuento punitório",Descripcion = "Descuento punitório" ,Cod = "DCP", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 303, Nombre = "Intereses no cobrados",Descripcion = "Intereses no cobrados" ,Cod = "INC", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 304, Nombre = "Ajuste redondéo negativo",Descripcion = "Ajuste redondéo negativo" ,Cod = "AR-", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 305, Nombre = "Recibo",Descripcion = "Recibo" ,Cod = "REC", ClaseMovimientoID=2},
                new TipoMovimiento{TipoMovimientoID = 306, Nombre = "Intereses a Comercio",Descripcion = "Intereses a Comercio" ,Cod = "INT", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 307, Nombre = "Ajuste redondeo positivo",Descripcion = "Ajuste redondeo positivo" ,Cod = "AR+", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 308, Nombre = "Teléfono",Descripcion = "Teléfono" ,Cod = "TEL", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 309, Nombre = "Varios",Descripcion = "Varios" ,Cod = "VAR", ClaseMovimientoID=1},
                new TipoMovimiento{TipoMovimientoID = 310, Nombre = "Por Cta y Orden VALLE",Descripcion = "Por Cta y Orden VALLE" ,Cod = "CDV", ClaseMovimientoID=1},
            };
                TiposMovimiento.ForEach(t => context.TiposMovimientos.Add(t));
                context.SaveChanges();
            }

        }

        public void Grabar(int BaseIDb)
        {
            GetDal(BaseIDb).Save();
        }

        public void Grabar()
        {
            dal.Save();
        }

        public void GrabarPrueba()
        {
            dalPrueba.Save();
        }


        /** Nossis **/
        public async Task<Respuesta> ConsultaNossis()
        {
            Respuesta consulta = await ra.ConsultaNossis();
            return consulta;
        }

       

        /* Timers */

        public void RealizarTransmisionesTick(Object stateInfo)
        {
            System.Threading.Timer tt =(System.Threading.Timer) stateInfo;
            
        }

        /*BK*/
        public void BackUpBase() //Ejecutar Command
        {
            //Muestra el CMD
            //string strCmdText;
            //strCmdText = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            //Esconde CMD
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            process.StartInfo = startInfo;
            process.Start();

            //--- < Begin Code Batch Script > ---
            //sqlcmd -S MYSERVER\OFFICESERVERS -E -Q 
            //"BACKUP DATABASE MASTER TO TESTBACKUP"
            //--- < End Code Batch Script > -----

            //..where "MYSERVER" is the name of the SQL Server physical machine.
            //..where "OFFICESERVERS" is the name of the SQL Server.
            //..where "TESTBACKUP" is the name of the backup job.
            //..where "MASTER" is the name of the database.
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dal.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string GetImpresora(string cQueImprimo) //EDUNVO 202110
        {
            string cImp = "";

            TipoImpresion tI = dal.Get<TipoImpresion>(i => i.Nombre == cQueImprimo).FirstOrDefault();
            if (tI != null) cImp = tI.Impresora;
            return cImp;
        }


        public double CalculaPuntaje(int BaseIDb, double ParamSueldo, int ParamCreditos, int ParamCanceldos, int ParamMorosidad, string ParamLaboral)
        {
            double dPuntIngre = 0;
            double dPuntCred = 0;
            double dPuntCanc = 0;
            double dPuntMora = 0;
            double dPuntLabo = 0;
            double dPuntaje = 0;
            double nTmp;
            PlanesParam regPlanesParam;
            List<PlanesParam> regPlanesParamList = new List<PlanesParam>() ;
            Busca_Parametros(BaseIDb, "INGRESOS", ref regPlanesParamList);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= ParamSueldo && lplparam.Hasta >= ParamSueldo)
                {
                    regPlanesParam = Get<PlanesParam>(1, c => c.Param1 == "INGRESOS").FirstOrDefault();
                    //nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    //dPuntIngre = nTmp / 100;
                    nTmp = Convert.ToDouble(lplparam.Valor);
                    dPuntIngre = (nTmp * regPlanesParam.Valor)  / 100;
                }
            }
            if (ParamCreditos > 0)
            {
                Busca_Parametros(1, "CREDITOS", ref regPlanesParamList);
                nTmp = 0;
                foreach (PlanesParam lplparam in regPlanesParamList)
                {
                    if (lplparam.Desde <= ParamCreditos && lplparam.Hasta >= ParamCreditos)
                    {
                        regPlanesParam = Get<PlanesParam>(1, c => c.Param1 == "CREDITOS").FirstOrDefault();
                        nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                        dPuntCred = nTmp / 100;
                    }
                }

                Busca_Parametros(1, "CANCELADOS", ref regPlanesParamList);
                nTmp = 0;
                foreach (PlanesParam lplparam in regPlanesParamList)
                {
                    if (lplparam.Desde <= ParamCanceldos && lplparam.Hasta >= ParamCanceldos)
                    {
                        regPlanesParam = Get<PlanesParam>(1, c => c.Param1 == "CANCELADOS").FirstOrDefault();
                        nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                        dPuntCanc = nTmp / 100;
                    }
                }

                Busca_Parametros(1, "MOROSIDAD", ref regPlanesParamList);
                nTmp = 0;
                foreach (PlanesParam lplparam in regPlanesParamList)
                {
                    if (lplparam.Desde <= ParamMorosidad && lplparam.Hasta >= ParamMorosidad)
                    {
                        regPlanesParam = Get<PlanesParam>(1, c => c.Param1 == "MOROSIDAD").FirstOrDefault();
                        nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                        dPuntMora = nTmp / 100;
                    }
                }
            }
            Busca_Parametros(1, "LABORAL", ref regPlanesParamList);
            nTmp = 0;
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Param1 == ParamLaboral)
                {
                    regPlanesParam = Get<PlanesParam>(1, c => c.Param1 == "LABORAL").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    dPuntLabo = nTmp / 100;
                }
            }
            dPuntaje = dPuntIngre + dPuntCred + dPuntCanc + dPuntMora + dPuntLabo;
            return dPuntaje;


        }

        private void Busca_Parametros(int BaseIDb, string qParam, ref List<PlanesParam> regPlanesParamList)
        {
            regPlanesParamList = Get<PlanesParam>(BaseIDb, c => c.Param2 == qParam, p => p.OrderBy(pl => pl.Orden)).ToList();
            //return regPlanesParamList;
            //if (regPlanesParamList.Count == 0)
            //{
            //    //ACA ERROR
            //    return false;
            //}
            //return true;
        }
    }
}
