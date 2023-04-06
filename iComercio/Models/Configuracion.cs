using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westwind.Utilities.Configuration;

namespace iComercio.Models
{
    public class Configuracion : Westwind.Utilities.Configuration.AppConfiguration
    {
        public string nombreAplicacion { get; set; }
        public int MaxDisplayListItems { get; set; }
        public bool SendAdminEmailConfirmations { get; set; }
        public string Password { get; set; }
        public string AppConnectionString { get; set; }

        /*REST AUTH */
        public string RestUrlConexion { get; set; }
        public string RestUsu { get; set; }
        public string RestKey { get; set; }


        /* Nombres de formularios */
        public string frmUsuariosNombre { get; set; }

        /* Mensajes de información */
        public string BarraDeEstadoListo { get; set; }
        public string menSaldo { get; set; }

        /* Timers */

        public int TiempoEnvioTransmisiones { get; set; }
        public int TiempoActualizacionSolicitarFondos { get; set; }
        public int TiempoEnvioNovedades { get; set; }
        public int TiempoEnvioRevisiones { get; set; }


        /* SolicitarFondos */
        public int solfonDiasParaAtras { get; set; }
        public int diasRevisionesParaAtras { get; set; }

        /*Transmisiones */
        public int ReintentosTransmisiones { get; set; }
        public int ReintentosTransmisionesSol { get; set; }
        public int ReintentosTransmisionesErr { get; set; }

        /* Transmision */
        public bool TransmisionHabilitada { get; set; }
        public bool TransmisionHabilitadaM { get; set; }

        /* Imagenes */
        public string rutaImagenes { get; set; }
        public string rutaFotos { get; set; }
        public string rutaComprIma { get; set; }

        public string ftpServer { get; set; }
        public string ftpUsu { get; set; }
        public string ftpClave { get; set; }

        public string rutaFTPImagenes { get; set; }
        public string rutaFTPFotos { get; set; }
        public string rutaFTPComrp { get; set; }
        public string rutaSolicitudes { get; set; }//edunvo202112
        public bool ScanSolicitudes { get; set; }//edunvo202112
        public string rutaFTPSolicitudes { get; set; }


        public string NombreBD { get; set; }
        public string NombreBDMig { get; set; }

        /* sufijos y prefijos archivos */
        public string suf_sol1 { get; set; }
        public string suf_sol2 { get; set; }
        public string suf_sol3 { get; set; }

        public string suf_ser1 { get; set; }
        public string suf_ser2 { get; set; }
        public string suf_ser3 { get; set; }

        public string suf_otr1 { get; set; }
        public string suf_otr2 { get; set; }
        public string suf_otr3 { get; set; }

        public string suf_doc1 { get; set; }
        public string suf_doc2 { get; set; }
        public string suf_doc3 { get; set; }

        public string suf_rec1 { get; set; }
        public string suf_rec2 { get; set; }
        public string suf_rec3 { get; set; }

        public string suf_fir1 { get; set; }
        public string suf_fir2 { get; set; }
        public string suf_fir3 { get; set; }

        public string pre_foto { get; set; }

        /*Script BD*/
        public string rutaScriptBD { get; set; }

        /*Impresiones*/
        public string Titulo { get; set; }
        public string Financia { get; set; }
        public string AltaLugar { get; set; }
        public string AltaTribunales { get; set; }

        public int NumCredInicial { get; set; }

        public bool ImprimirComprobantes { get; set; }
        public bool ImprimirCredTalonComercio { get; set; }
        public bool ImprimirComprobantesCob { get; set; }
        public bool ImprimirCobTalonComercio { get; set; }

        public decimal MaxMontoMensual { get; set; }

        /*FF*/
        public decimal MontoFF { get; set; }

        //permisos
        public bool AutenticaCobranza { get; set; }
        public bool AutenticaAltaCredito { get; set; }
        public string permPagoAnticipado { get; set; }
        public string permCambiaPunitorios { get; set; }
        public string permCancelaRefi { get; set; }
        public string permArregloPagos { get; set; }
        public string permQuitaPunitorios { get; set; }
        public string permPermiteBonificar { get; set; }
        public string permCambiaMinimo { get; set; }
        public string permHabilitaPagoDebitoDirecto { get; set; }
        public string permPagoAbogado { get; set; }

        /* Pantalla */
        public float MinIndiceHRedux { get; set; }
        public float MinIndiceWRedux { get; set; }
        public float MinIndiceFontRedux { get; set; }

        /* Test*/
        public bool TestMode { get; set; }
        public string TestRestUrlConexion { get; set; }

        //**M**//
        public string RestUrlConexionM { get; set; }
        public string cLlevaMor { get; set; }               // "A" = AUTOMÁTICO    "M" = Manual  "" = COMUN
        public bool bFormaPago { get; set; }
        public bool bAceptaFOrmaPago { get; set; }
        public decimal nLlevaMorPorcentFinan { get; set; }   // procentaje que coreesponde a la financiera dentro del mes en curso
        public decimal nLlevaMorMax { get; set; }           // Total valor nominal del el mes en curso para M

        public string rutaComprImaMor { get; set; }
        public string rutaSolicitudesMor { get; set; }
        public string rutaFTPComrpMor { get; set; }
        public string rutaFTPSolicitudesMor { get; set; }
        //**M**//

        //Actualizaciones
        public bool bPropio { get; set; }
        public bool bActComercios { get; set; }
        public bool bActHabilitada { get; set; }
        public int TiempoActs { get; set; }
        public bool bActEF { get; set; }
        public bool bActDesde { get; set; }
        public DateTime ActDesde { get; set; }
        public DateTime ActHasta { get; set; }

        public int RegsLog { get; set; }

        /*Boni*/
        public int CantImpBoni { get; set; }


        public decimal dArreglo01 { get; set; } //edu20211207
        public decimal dArreglo02 { get; set; } //edu20211207
        public decimal dArreglo03 { get; set; } //edu20211207
        public int nArregloMeses { get; set; }//edu20211207

        public int nRedondeo { get; set; }//edu20211207

        // Must implement public default constructor
        public Configuracion()
    {
        nombreAplicacion = "CREDIN - iComercio";
        MaxDisplayListItems = 15;
        SendAdminEmailConfirmations = false;
        Password = "seekrit";
        AppConnectionString = "server=.;database=hosers;uid=bozo;pwd=seekrit;";

         /*REST AUTH */
        RestUrlConexion = "http://190.191.95.146:82";
        RestUsu = "admin";
        RestKey = "";

        /* Nombres de formularios */
        frmUsuariosNombre = "Administrar Usuarios";

        /* Mensajes de informacion*/
        BarraDeEstadoListo  = "Listo";
        menSaldo = "Saldo";

        /* Timers */ /*en milisegundos */
        TiempoEnvioTransmisiones = 30000;
        TiempoActualizacionSolicitarFondos = 60000;
        TiempoEnvioNovedades = 30000; /*900000 15 Minutos*/
        TiempoEnvioRevisiones = 1800000; /*1800000 30 Minutos*/

         /* SolicitarFondos */
        solfonDiasParaAtras =7;
        diasRevisionesParaAtras = 7;

        /* Transmisiones */
        ReintentosTransmisiones = 5;
        ReintentosTransmisionesSol = 10;
        ReintentosTransmisionesErr = 5;

        /* Imagenes */
        //rutaImagenes = System.IO.Directory.GetCurrentDirectory() + "\\imacli";
        //rutaFotos = System.IO.Directory.GetCurrentDirectory() + "\\Fotos";

            rutaImagenes = "\\imacli";
            rutaFotos = "\\Fotos";
            rutaComprIma = "\\Comprobates";
            rutaSolicitudes = "\\Solicitudes";//edunvo202112
            ScanSolicitudes = false;//edunvo202112

            rutaComprImaMor = "\\Comprobates";
            rutaSolicitudesMor = "\\Solicitudes";
            rutaFTPComrpMor = "5";
            rutaFTPSolicitudesMor = "6";

            ftpServer = "a";
            ftpUsu = "b"; 
            ftpClave = "c"; 

            rutaFTPImagenes = "1"; 
            rutaFTPFotos = "2";
            rutaFTPComrp = "3";
            rutaFTPSolicitudes = "4";

            /* sufijos y prefijos archivos */
            suf_sol1 = "_SOL_01";
        suf_sol2 = "_SOL_02";
        suf_sol3 = "_SOL_03";
        
        suf_ser1 = "_SER_01";
        suf_ser2 = "_SER_02";
        suf_ser3 = "_SER_03";
        
        suf_otr1 = "_OTR_01";
        suf_otr2 = "_OTR_02";
        suf_otr3 = "_OTR_03";
        
        suf_doc1 = "_DOC_01";
        suf_doc2 = "_DOC_02";
        suf_doc3 = "_DOC_03";
        
        suf_rec1 = "_REC_01";
        suf_rec2 = "_REC_02";
        suf_rec3 = "_REC_03";

        suf_fir1 = "_FIR_01";
        suf_fir2 = "_FIR_02";
        suf_fir3 = "_FIR_03";

        pre_foto = "C";
        
        /*ScriptBD*/
        rutaScriptBD = System.IO.Directory.GetCurrentDirectory() + "\\Documentos\\BD\\Scritp paises, provincias, localidades Argentina solo datos.sql";
        //@"d:\Credin\Sistemas\Proyectos\iComercio\iComercio\BD\Scritp paises, provincias, localidades Argentina solo datos.sql"

        AltaLugar = "Ciudad de Buenos Aires";
        AltaTribunales = "Tribunales de la ciudad de de Buenos Aires";

        NumCredInicial = 1;
        ImprimirComprobantes = true;
        ImprimirCredTalonComercio = true;
        ImprimirComprobantesCob = true;
        ImprimirCobTalonComercio = false;
        MaxMontoMensual = 0;

        /*FF*/
        MontoFF = 1500;

        //Permisos
        AutenticaAltaCredito = true;
        AutenticaCobranza = true;
        permPagoAnticipado = "permPagoAnticipado";
        permCambiaPunitorios = "permCambiaPunitorios";
        permCancelaRefi = "Cancelarefinanciacion";
        permArregloPagos = "permArregloPagos";
        permQuitaPunitorios = "permQuitaPunitorios";
        permPermiteBonificar = "permPermiteBonificar";
        permCambiaMinimo = "CambiaMinimo";
        permHabilitaPagoDebitoDirecto = "HabilitaPagoNormalDebitoDirecto";
        permPagoAbogado = "pagoAbogado";
            

        /*Test*/
        TestMode = false;
        TestRestUrlConexion = "http://190.191.95.146:9090";

        //**M**//
        RestUrlConexionM = "http://190.191.95.146:8282";
        cLlevaMor = "N";                           // "A" = AUTOMÁTICO    "M" = Manual  "" = COMUN
        bFormaPago = true;
        bAceptaFOrmaPago = false;
        nLlevaMorPorcentFinan = 50;                // procentaje que coreesponde a la financiera dentro del mes en curso
        nLlevaMorMax = 100000;                    // Total valor nominal del el mes en curso para M
        //**M**//

        /* Transmisiones */
        TransmisionHabilitada = true;
        TransmisionHabilitadaM = true;

        /*Pantalla*/
        MinIndiceHRedux = 0.85f;
        MinIndiceWRedux = 0.85f;
        MinIndiceFontRedux = 0.85f;

        //Acts
        bPropio = true;
        bActComercios = true;
        bActHabilitada = true;
        bActEF = false;
        bActDesde = true;
        TiempoActs = 3600000; //1 hora
        ActDesde = DateTime.Now.Date.AddDays(-1);
        ActHasta = DateTime.Now;
        RegsLog = 500;
        CantImpBoni = 2;

        NombreBD = "Comercio";
        NombreBDMig = "ComerFinanMig";

            dArreglo01 = 50; //edu20211207
            dArreglo02 = 60; //edu20211207
            dArreglo03 = 70; //edu20211207
            nArregloMeses = 6;//edu20211207

            nRedondeo = 50;

        }

        ///// 

        ///// Override this method to create the custom default provider - in this case a database
        ///// provider with a few options.
        ///// 

        protected override IConfigurationProvider OnCreateDefaultProvider(string sectionName, object configData)
    {
        string connectionString = "ComercioContext";
        string tableName = "ConfigurationData";

        var provider = new SqlServerConfigurationProvider<Configuracion>()
            {
                Key = 0,
                ConnectionString = connectionString,
                Tablename = tableName,
                ProviderName = "System.Data.SqlClient",
                EncryptionKey = "ultra-seekrit", // use a generated value here
                PropertiesToEncrypt = "Password,AppConnectionString"
            };

        return provider;
    }
    }
}
