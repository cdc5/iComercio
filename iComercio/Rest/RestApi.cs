using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using iComercio.Models;
using iComercio.ViewModels;
using RestSharp;
using AutoMapper;
using iComercio.Rest.RestModels;
using System.Windows.Forms;




namespace iComercio.Rest
{
    public class RestApi
    {

      //  readonly string _baseUrl = "http://186.124.220.92:82";
        //  readonly string _baseUrl = "http://190.191.95.146:82";
        //readonly string BaseUrl = "http://localhost:31402/";
        
        public string _baseUrl;
        readonly string uri = "api/solicitarFondos";
        readonly string _accountSid;
        readonly string _secretKey;

        /*Test*/
        public string _baseUrlTest;
        public bool esEnvioTest = false;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public RestApi(string accountSid, string secretKey, string baseUrl, string baseUrlTest = null)
        {
            _accountSid = accountSid;
            _secretKey = secretKey;
            _baseUrl = baseUrl;
            _baseUrlTest = baseUrlTest;

        }

        private void AsignarBaseUrl(RestClient client, bool esEnvioTest)
        {
            if (esEnvioTest)
            {
                if (_baseUrlTest != null)
                    client.BaseUrl = _baseUrlTest;
                else
                    client.BaseUrl = _baseUrl;
            }
            else
                client.BaseUrl = _baseUrl;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            //client.BaseUrl = _baseUrl;
            AsignarBaseUrl(client, esEnvioTest);
            client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }

        /* Files */
        public FileUploadResult PostFile(string filePath, string fileName,string claseArchivo)
        {
            //RestClient restClient = new RestClient();
            string uri = "api/fileupload2/files2";
            RestRequest restRequest = new RestRequest(uri + "/{claseArchivo}", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = Method.POST;
            //restRequest.AddHeader("Authorization", "Authorization");
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddParameter("claseArchivo", claseArchivo, ParameterType.UrlSegment);
            restRequest.AddFile("content", filePath);
            var response = Execute<FileUploadResult>(restRequest);
            return response;
        }

        public async Task<FileUploadResult> PostFileAsync(int EmpresaID, int ComercioID, string fileName, string filePath, string claseArchivo)
        {
          
            //Quitar si no se usa modo test
            esEnvioTest = true;

            //RestClient restClient = new RestClient();
            string uri = "api/fileupload2/files2";
            RestRequest restRequest = new RestRequest(uri + "/{empId}/{comId}/{claseArchivo}", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = Method.POST;
            //restRequest.AddHeader("Authorization", "Authorization");
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddParameter("empId", EmpresaID, ParameterType.UrlSegment);
            restRequest.AddParameter("comId", ComercioID, ParameterType.UrlSegment);
            restRequest.AddParameter("claseArchivo", claseArchivo, ParameterType.UrlSegment);
            restRequest.AddFile("content", filePath);
            FileUploadResult res = await ExecuteAsync<FileUploadResult>(restRequest).ConfigureAwait(false);
            return res;
            //try
            //{
            //    System.IO.FileStream file;
            //    file = new FileStream(filePath, FileMode.Open);
            //    string uri = "api/fileupload2/files2";
            //    RestRequest request = new RestRequest(uri + "/{claseArchivo}", Method.POST);
            //    //The 2nd parameter is a short-hand of (stream) => fileStream.CopyTo(stream)
            //    request.AddFile("fileData", file.CopyTo, fileName);
            //    request.AlwaysMultipartFormData = true;
            //    //Add one of these for each form boundary you need

            //    FileUploadResult resp = await ExecuteAsyncFileUpload(request).ConfigureAwait(false);
            //    file.Close();
            //    return resp;
            //}
            //catch (IOException ex)
            //{
            //    Debug.Print((ex.ToString()));
            //}
        }
      

        public async Task<FileUploadResult> PostFileAsync(string filePath, string fileName, string claseArchivo)
        {
            //Quitar si no se usa modo test
            esEnvioTest = true;

            //RestClient restClient = new RestClient();
            string uri = "api/fileupload2/files2";
            RestRequest restRequest = new RestRequest(uri + "/{claseArchivo}", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = Method.POST;
            //restRequest.AddHeader("Authorization", "Authorization");
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddParameter("claseArchivo", claseArchivo, ParameterType.UrlSegment);
            restRequest.AddFile("content", filePath);
            FileUploadResult res = await ExecuteAsync<FileUploadResult>(restRequest).ConfigureAwait(false);
            return res;
            //try
            //{
            //    System.IO.FileStream file;
            //    file = new FileStream(filePath, FileMode.Open);
            //    string uri = "api/fileupload2/files2";
            //    RestRequest request = new RestRequest(uri + "/{claseArchivo}", Method.POST);
            //    //The 2nd parameter is a short-hand of (stream) => fileStream.CopyTo(stream)
            //    request.AddFile("fileData", file.CopyTo, fileName);
            //    request.AlwaysMultipartFormData = true;
            //    //Add one of these for each form boundary you need

            //    FileUploadResult resp = await ExecuteAsyncFileUpload(request).ConfigureAwait(false);
            //    file.Close();
            //    return resp;
            //}
            //catch (IOException ex)
            //{
            //    Debug.Print((ex.ToString()));
            //}
        }

        Task<FileUploadResult> ExecuteAsyncFileUpload(RestRequest request) 
        {
            try
            {
                var tcs = new TaskCompletionSource<FileUploadResult>();
                var client = new RestClient();
                client.AddHandler("application/json", JsonDeserializer.Default);
                client.AddHandler("text/json", JsonDeserializer.Default);
                client.AddHandler("image/gif", JsonDeserializer.Default);
                
                //client.BaseUrl = _baseUrl;
                AsignarBaseUrl(client, esEnvioTest);
                
                client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
                //client.Authenticator = new SimpleAuthenticator("username", "cdc5", "password", "popot3");
                request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
                try
                {
                    var response = client.ExecuteAsync<FileUploadResult>(request, res =>
                    {
                        if (res != null)
                            tcs.SetResult(res.Data);
                        else
                        {
                            Exception ex = new Exception("Error en la conexión");
                            tcs.TrySetException(ex);
                        }
                    });
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }

                return tcs.Task;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return null;

        }

        
        Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            try
            { 
                var tcs = new TaskCompletionSource<T>();
                var client = new RestClient();
                //client.AddHandler("application/json", JsonDeserializer.Default);
                //client.AddHandler("text/json", JsonDeserializer.Default);
                //client.AddHandler("image/gif", JsonDeserializer.Default);

                //client.BaseUrl = _baseUrl;
                AsignarBaseUrl(client, esEnvioTest);
                
                //MessageBox.Show("URL ENVIO:" + client.BaseUrl);
                //log.Debug("URL ENVIO:" + client.BaseUrl);
                
                client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
                //client.Authenticator = new SimpleAuthenticator("username", "cdc5", "password", "popot3");
                request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
                try
                {
                    var response = client.ExecuteAsync<T>(request, res => {
                                                                            if (res != null) 
                                                                                 tcs.SetResult(res.Data);
                                                                            else
                                                                            {
                                                                                Exception ex  = new Exception("Error en la conexión");
                                                                                tcs.TrySetException(ex);
                                                                            }
                                                                           });
                }
                 catch (Exception ex)
                {
                  tcs.TrySetException(ex);
                }

                return tcs.Task;
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return null;
           
        }

        Task<IRestResponse<T>> ExecuteAsyncFull<T>(RestRequest request) where T : new()
        {
            try
            {
                var tcs = new TaskCompletionSource<IRestResponse<T>>();
                var client = new RestClient();
                client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
                //client.Authenticator = new SimpleAuthenticator("username", "cdc5", "password", "popot3");
                request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request

                //Quitar sino, antes no estaba.
                AsignarBaseUrl(client, esEnvioTest);
                
                //MessageBox.Show("URL ENVIO:" + client.BaseUrl);
                //log.Debug("URL ENVIO:" + client.BaseUrl);

                var response = client.ExecuteAsync<T>(request, res => { if (res != null) tcs.SetResult(res); });
                return tcs.Task;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return null;

        }

        

        Task<T> ExecuteAsyncNossis<T>(RestRequest request) where T : new()
        {
            var tcs = new TaskCompletionSource<T>();
            var client = new RestClient();
            client.BaseUrl = "http://sac.nosis.com.ar/SAC_ServicioSF/Respuesta.asp?IdPedido=32355";
            var response = client.ExecuteAsync<T>(request, res => { if (res != null) tcs.SetResult(res.Data); });
            return tcs.Task;
        }


        Task<String> ExecuteAsyncRawResponse(RestRequest request) 
        {
            var tcs = new TaskCompletionSource<String>();
            var client = new RestClient();
            client.BaseUrl = "http://sac.nosis.com.ar/SAC_ServicioSF/Respuesta.asp?IdPedido=32355";
           // client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
            //client.Authenticator = new SimpleAuthenticator("username", "cdc5", "password", "popot3");
            //request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
            var response = client.ExecuteAsync(request, res => { if (res != null) tcs.SetResult(res.Content); });
            return tcs.Task;
        }

       
            

        /*InfoCliente */
        public async Task<InfoCliente> GetInfoClienteAsync(string url,Comercio com, Cliente cli)
        {
            //this._baseUrl = url;
            esEnvioTest = false; //No quiero que esto se envie en modo test, esto es posta.;

            string uri = "api/InfoCliente";
            var request = new RestRequest();
            /*request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}";*/
            request.Resource = uri + "/{empId}/{comId}/{Documento}/{TipoDocumentoID}";
            request.RequestFormat = DataFormat.Json;

            /* request.RootElement = "Call"; */
            request.AddParameter("empId", com.Empresa.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comId", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("Documento", cli.Documento, ParameterType.UrlSegment);
            request.AddParameter("TipoDocumentoID", cli.TipoDocumentoID, ParameterType.UrlSegment);

            request.Timeout = 90000;
            InfoClienteRestModel icrm = await ExecuteAsync<InfoClienteRestModel>(request).ConfigureAwait(false);
            InfoCliente ic = Mapper.Map<InfoClienteRestModel, InfoCliente>(icrm);
            return ic;
        }

        /*Solicitar Fondos*/
        public async Task<SolicitarFondos> GetSolicitarFondosAsync(Comercio com, DateTime fechaDesde, DateTime fechaHasta, Estado est) 
        {
            esEnvioTest = false; //No quiero que esto se envie en modo test, esto es posta.;

            var request = new RestRequest();
            /*request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}";*/
            request.Resource = uri + "/{empId}/{comId}/{fechaDesde}/{fechaHasta}";
            request.RequestFormat = DataFormat.Json;
            
            /* request.RootElement = "Call"; */
            request.AddParameter("empId", com.Empresa.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comId", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("fechaDesde", fechaDesde.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("fechaHasta", fechaHasta.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            
           
            //request.AddParameter("Timeout", 120);
           
            // var io = await ExecuteAsync<SolicitarFondosViewModel>(request).ConfigureAwait(false);
            SolicitarFondosRestModel sfrm = await ExecuteAsync<SolicitarFondosRestModel>(request).ConfigureAwait(false);
            SolicitarFondos sf = new SolicitarFondos();
            sf.infoObjetivos = sfrm.infoObjetivos;
            sf.SolicitudesDeFondos = Mapper.Map<List<SolicitudFondoRestModel>,List<SolicitudFondo>>(sfrm.SolicitudesDeFondos);
            return sf;
        }


        /*Obtener Recibos y transferencias generados en central*/
        public async Task<RecibosYTransferencias> GetRecibosYTransferenciasCentralAsync(Comercio com, DateTime fechaDesde, DateTime fechaHasta, Estado est)
        {
            esEnvioTest = true;
            string uri = "api/RecTransDep";
            var request = new RestRequest();
            
            request.Resource = uri + "/{empId}/{comId}/{fechaDesde}/{fechaHasta}";
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("empId", com.Empresa.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comId", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("fechaDesde", fechaDesde.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);
            request.AddParameter("fechaHasta", fechaHasta.ToString("yyyy-MM-dd"), ParameterType.UrlSegment);

            RecibosYTransferenciasRestModel rytRM = await ExecuteAsync<RecibosYTransferenciasRestModel>(request).ConfigureAwait(false);
            RecibosYTransferencias ryt = new RecibosYTransferencias();
            ryt.Rrm = Mapper.Map<List<ReciboRestModel>, List<Recibo>>(rytRM.Rrm); ;
            ryt.TdRm = Mapper.Map<List<TransferenciasDepositosRestModel>, List<TransferenciasDepositos>>(rytRM.TdRm); ;
            return ryt;
        }
            

        public async Task<TEntity> Post<TEntity,TEntityRM>(TEntity T,string uri,Dictionary<string,object> parametros) where TEntity  : new()
            where TEntityRM : new()
        {
            esEnvioTest = true;
            //string sUri = "Api/clientes/{EmpresaID}/{ComercioID}/{Documento}/{TipoDocumento}";
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.POST); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp
            foreach (var pair in parametros)
            {
                sUri = string.Format("{0}/{{{1}}}",sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }
            request.Resource = uri + sUri; //Revisar Que esto Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            TEntityRM sfrm = Mapper.Map<TEntity, TEntityRM>(T);
            request.AddBody(sfrm);
            TEntityRM resp = await ExecuteAsync<TEntityRM>(request).ConfigureAwait(false);
            TEntity io = Mapper.Map<TEntityRM, TEntity>(resp);
            return io;
        }

        //Para cuando paso el RestModel Directamente
        public async Task<TEntityRM> Post<TEntityRM>(TEntityRM T, string uri, Dictionary<string, object> parametros)
            where TEntityRM : new()
        {
            esEnvioTest = true;
            //string sUri = "Api/clientes/{EmpresaID}/{ComercioID}/{Documento}/{TipoDocumento}";
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.POST); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp
            foreach (var pair in parametros)
            {
                sUri = string.Format("{0}/{{{1}}}", sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }
            request.Resource = uri + sUri; //Revisar Que esto  Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            request.AddBody(T);
            TEntityRM resp = await ExecuteAsync<TEntityRM>(request).ConfigureAwait(false);
            return resp;
        }

        //Hacerlos como corresponden, ahora es copia de PoSt
        public async Task<TEntity> Put<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
            where TEntity : new()
            where TEntityRM : new()
        {
            esEnvioTest = true;
            //string sUri = "Api/clientes/{EmpresaID}/{ComercioID}/{Documento}/{TipoDocumento}";
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.POST); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp
            foreach (var pair in parametros)
            {
                sUri = string.Format("{0}/{{{1}}}", sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }
            request.Resource = uri + sUri; //Revisar Que esto Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            TEntityRM sfrm = Mapper.Map<TEntity, TEntityRM>(T);
            request.AddBody(sfrm);
            TEntityRM resp = await ExecuteAsync<TEntityRM>(request).ConfigureAwait(false);
            TEntity io = Mapper.Map<TEntityRM, TEntity>(resp);
            return io;
        }

        //Hacerlos como corresponden, ahora es copia de PoSt
        public async Task<TEntity> Get<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
            where TEntity : new()
            where TEntityRM : new()
        {
            esEnvioTest = true;
            //string sUri = "Api/clientes/{EmpresaID}/{ComercioID}/{Documento}/{TipoDocumento}";
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.GET); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp
            foreach (var pair in parametros)
            {
                sUri = string.Format("{0}/{{{1}}}", sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }
            request.Resource = uri + sUri; //Revisar Que esto Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            TEntityRM sfrm = Mapper.Map<TEntity, TEntityRM>(T);
            request.AddBody(sfrm);
            TEntityRM resp = await ExecuteAsync<TEntityRM>(request).ConfigureAwait(false);
            TEntity io = Mapper.Map<TEntityRM, TEntity>(resp);
            return io;
        }


        public async Task<TEntity> Get<TEntity>(TEntity T, Comercio com,string uri)
            where TEntity : ITransmitible,new()
        {

            esEnvioTest = true;
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.GET); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp

            foreach (var pair in T.ApiParam(com))
            {
                sUri = string.Format("{0}/{{{1}}}", sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }


            request.Resource = uri + sUri; //Revisar Que esto Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            //request.Timeout = 90000;
            TEntity resp = await ExecuteAsync<TEntity>(request).ConfigureAwait(false);
            return resp;
        }

        //Hacerlos como corresponden, ahora es copia de PoSt
        public async Task<TEntity> Delete<TEntity, TEntityRM>(TEntity T, string uri, Dictionary<string, object> parametros)
            where TEntity : new()
            where TEntityRM : new()
        {
            esEnvioTest = true;
            //string sUri = "Api/clientes/{EmpresaID}/{ComercioID}/{Documento}/{TipoDocumento}";
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.POST); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp
            foreach (var pair in parametros)
            {
                sUri = string.Format("{0}/{{{1}}}", sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }
            request.Resource = uri + sUri; //Revisar Que esto Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            TEntityRM sfrm = Mapper.Map<TEntity, TEntityRM>(T);
            request.AddBody(sfrm);
            TEntityRM resp = await ExecuteAsync<TEntityRM>(request).ConfigureAwait(false);
            TEntity io = Mapper.Map<TEntityRM, TEntity>(resp);
            return io;
        }

        //Para cuando paso el RestModel Directamente
        public async Task<TEntityRM> Delete<TEntityRM>(TEntityRM T, string uri, Dictionary<string, object> parametros)
            where TEntityRM : new()
        {
            esEnvioTest = true;
            //string sUri = "Api/clientes/{EmpresaID}/{ComercioID}/{Documento}/{TipoDocumento}";
            string sUri = "";
            RestRequest request = new RestRequest(sUri, Method.DELETE); // Se crea asi y despues se pisa la direccion sUri (Resource), porque sino el parametro Method no se crea bien en el constructor de restrequest --Es un problema de restsharp
            foreach (var pair in parametros)
            {
                sUri = string.Format("{0}/{{{1}}}", sUri, pair.Key);
                request.AddParameter(pair.Key, pair.Value, ParameterType.UrlSegment);
            }
            request.Resource = uri + sUri; //Revisar Que esto Efectivamente Ande
            request.RequestFormat = DataFormat.Json;
            request.AddBody(T);
            TEntityRM resp = await ExecuteAsync<TEntityRM>(request).ConfigureAwait(false);
            return resp;
        }


        public async Task<SolicitudFondo> PostSolicitudFondo(SolicitudFondo solfon)
        {
            esEnvioTest = false; //No quiero que esto se envie en modo test, esto es posta.;
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{solicitudFondoID}", Method.POST);
            request.AddParameter("empID", solfon.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", solfon.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("solicitudFondoID", solfon.SolicitudFondoID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            //Hacer que solo se envíen Numeros o strings, no entidades u objetos completas, es poco performante y ademas
            //tira errores por recursión entre los objetos, quizás con automapper podría hacer clases DTO, para que transformen
            //solo lo que hay que enviar, por ahora saco a mano lo que jode.
            SolicitudFondoRestModel sfrm = Mapper.Map<SolicitudFondo, SolicitudFondoRestModel>(solfon);
            request.AddBody(sfrm);
            SolicitudFondoRestModel resp = await ExecuteAsync<SolicitudFondoRestModel>(request).ConfigureAwait(false);
            SolicitudFondo io = Mapper.Map<SolicitudFondoRestModel, SolicitudFondo>(resp);
            return io;            
        }


        public async Task<SolicitudFondo> PutSolicitudFondo(SolicitudFondo solfon)
        {
            esEnvioTest = false; //No quiero que esto se envie en modo test, esto es posta.;
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{solicitudFondoID}", Method.PUT);
            request.AddParameter("empID", solfon.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", solfon.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("solicitudFondoID", solfon.SolicitudFondoID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            //Hacer que solo se envíen Numeros o strings, no entidades u objetos completas, es poco performante y ademas
            //tira errores por recursión entre los objetos, quizás con automapper podría hacer clases DTO, para que transformen
            //solo lo que hay que enviar, por ahora saco a mano lo que jode.
            SolicitudFondoRestModel sfrm = Mapper.Map<SolicitudFondo, SolicitudFondoRestModel>(solfon);
            request.AddBody(sfrm);
            SolicitudFondoRestModel resp = await ExecuteAsync<SolicitudFondoRestModel>(request).ConfigureAwait(false);
            var io = Mapper.Map<SolicitudFondoRestModel, SolicitudFondo>(resp);
            return io;
        }

        public async Task<Autorizacion> ConfirmarSolicitudFondo(SolicitudFondo solfon)
        {
            string uri = "api/solicitarFondos/ConfirmarSolicitudFondo";
            esEnvioTest = false; //No quiero que esto se envie en modo test, esto es posta.;
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{solicitudFondoID}", Method.PUT);
            request.AddParameter("empID", solfon.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", solfon.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("solicitudFondoID", solfon.SolicitudFondoID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            //Hacer que solo se envíen Numeros o strings, no entidades u objetos completas, es poco performante y ademas
            //tira errores por recursión entre los objetos, quizás con automapper podría hacer clases DTO, para que transformen
            //solo lo que hay que enviar, por ahora saco a mano lo que jode.
            SolicitudFondoRestModel sfrm = Mapper.Map<SolicitudFondo, SolicitudFondoRestModel>(solfon);
            request.AddBody(sfrm);
            var io = await ExecuteAsync<Autorizacion>(request).ConfigureAwait(false);
            return io;
        }
        

        public async Task<Proveedor> PostProveedor(Proveedor prov, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/proveedores";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ProveedorID}", Method.POST);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorID", prov.ProveedorID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ProveedorRestModel sfrm = Mapper.Map<Proveedor, ProveedorRestModel>(prov);
            request.AddBody(sfrm);
            ProveedorRestModel resp = await ExecuteAsync<ProveedorRestModel>(request).ConfigureAwait(false);
            Proveedor io = Mapper.Map<ProveedorRestModel, Proveedor>(resp);
            //Proveedor prove = Mapper.Map<ProveedorRestModel,Proveedor>(io.Data);
            //return prove;
            return io;
        }

        public async Task<Proveedor> PutProveedor(Proveedor prov, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/proveedores";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ProveedorID}", Method.PUT);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorID", prov.ProveedorID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ProveedorRestModel sfrm = Mapper.Map<Proveedor, ProveedorRestModel>(prov);
            //IEnumerable<ConceptoGastoProveedorRestModel> sfrmCGP = Mapper.Map<IEnumerable<ConceptoGastosProveedor>, IEnumerable<ConceptoGastoProveedorRestModel>>(prov.ConceptoGastosProveedor);
            request.AddBody(sfrm);
            //request.AddBody(sfrmCGP);
            var io = await ExecuteAsync<Proveedor>(request).ConfigureAwait(false);
            return io;
        }

        public async Task<IntRestModel> DeleteProveedor(Proveedor prov, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/proveedores";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ProveedorID}", Method.DELETE);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorID", prov.ProveedorID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            var io = await ExecuteAsync<IntRestModel>(request).ConfigureAwait(false);
            return io;
        }

        public async Task<ProveedorSucursal> PostProveedorSucursal(ProveedorSucursal provSuc, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/proveedoresSucursales";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ProveedorID}", Method.POST);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorID", provSuc.Proveedor.ProveedorID, ParameterType.UrlSegment);
            provSuc.ProveedorSucursalIDRemoto = provSuc.Proveedor.ProveedorID;
            //request.AddParameter("ProveedorSucursalID", provSuc.ProveedorSucursalIDCentral, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ProveedorSucursalRestModel sfrm = Mapper.Map<ProveedorSucursal, ProveedorSucursalRestModel>(provSuc);
            request.AddBody(sfrm);
            var io = await ExecuteAsync<ProveedorSucursal>(request).ConfigureAwait(false);
            return io;
        }

        public async Task<ProveedorSucursal> PutProveedorSucursal(ProveedorSucursal provSuc, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/proveedoresSucursales";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ProveedorID}/{ProveedorSucursalID}", Method.PUT);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorID", provSuc.ProveedorID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorSucursalID", provSuc.ProveedorSucursalID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ProveedorSucursalRestModel sfrm = Mapper.Map<ProveedorSucursal, ProveedorSucursalRestModel>(provSuc);
            request.AddBody(sfrm);
            var io = await ExecuteAsync<ProveedorSucursal>(request).ConfigureAwait(false);
            return io;
        }

        public async Task<IntRestModel> DeleteProveedorSucursal(ProveedorSucursal provSuc, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/proveedoresSucursales";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ProveedorID}/{ProveedorSucursalID}", Method.DELETE);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorID", provSuc.ProveedorID, ParameterType.UrlSegment);
            request.AddParameter("ProveedorSucursalID", provSuc.ProveedorSucursalID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            var io = await ExecuteAsync<IntRestModel>(request).ConfigureAwait(false);
            return io;
        }
        
        /* Concepto Gasto */
        public async Task<ConceptoGastos> PostConceptoGastos(ConceptoGastos cgp, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/ConceptosGastos";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ConceptoGastosID}", Method.POST);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ConceptoGastosID", cgp.ConceptoGastosID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ConceptoGastosRestModel sfrm = Mapper.Map<ConceptoGastos, ConceptoGastosRestModel>(cgp);
            request.AddBody(sfrm);
            var io = await ExecuteAsync<ConceptoGastos>(request).ConfigureAwait(false);
            return io;
        }

        public async Task<ConceptoGastos> PutConceptoGastos(ConceptoGastos cgp, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/ConceptosGastos";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ConceptoGastosID}", Method.PUT);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ConceptoGastosID", cgp.ConceptoGastosID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ConceptoGastosRestModel sfrm = Mapper.Map<ConceptoGastos, ConceptoGastosRestModel>(cgp);
            request.AddBody(sfrm);
            var io = await ExecuteAsync<ConceptoGastos>(request).ConfigureAwait(false);
            return io;
        }

        public async Task<IntRestModel> DeleteConceptoGastos(ConceptoGastos cgp, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/ConceptosGastos";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ConceptoGastosID}", Method.DELETE);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ConceptoGastosID", cgp.ConceptoGastosID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            var io = await ExecuteAsync<IntRestModel>(request).ConfigureAwait(false);
            return io;
        }

        /* Concepto Gasto Proveedor*/
        public async Task<ConceptoGastosProveedor> PostConceptoGastosProveedor(ConceptoGastosProveedor cgp, Comercio com)
        {
            esEnvioTest = true;
            string uri = "api/ConceptosGastosProveedor";
            RestRequest request = new RestRequest(uri + "/{empID}/{comID}/{ConceptoGastosProveedorID}", Method.POST);
            request.AddParameter("empID", com.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", com.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("ConceptoGastosProveedorID", cgp.ConceptoGastosProveedorID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            ConceptoGastoProveedorRestModel sfrm = Mapper.Map<ConceptoGastosProveedor, ConceptoGastoProveedorRestModel>(cgp);
            request.AddBody(sfrm);
            var io = await ExecuteAsync<ConceptoGastosProveedor>(request).ConfigureAwait(false);
            return io;
        }

       public async Task<IntRestModel> DeleteConceptoGastosProveedor(ConceptoGastosProveedor cgp)
        {
            esEnvioTest = true;
            string uri = "api/ConceptosGastosProveedor";
            RestRequest request = new RestRequest(uri + "/{provID}/{congasID}", Method.DELETE);
            request.AddParameter("provID", cgp.ProveedorID, ParameterType.UrlSegment);
            request.AddParameter("congasID",cgp.ConceptoGastosID, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            var io = await ExecuteAsync<IntRestModel>(request).ConfigureAwait(false);
            return io;
        }

       


        public async Task<Respuesta> ConsultaNossis()
        {
            RestRequest request = new RestRequest(Method.GET);
          /*  request.AddParameter("empID", solfon.EmpresaID, ParameterType.UrlSegment);
            request.AddParameter("comID", solfon.ComercioID, ParameterType.UrlSegment);
            request.AddParameter("solicitudFondoID", solfon.SolicitudFondoID, ParameterType.UrlSegment);*/
            request.RequestFormat = DataFormat.Xml;
            //request.AddBody(solfon);

           // var io = await ExecuteAsyncRawResponse(request).ConfigureAwait(false);
            var io = await ExecuteAsyncNossis<Respuesta>(request).ConfigureAwait(false);
            return io;
        }

        //Para ver que es lo que se esta mandando
        //client.ExecuteAsync(request, response =>
        //           {
        //               Console.WriteLine(response.Content);
        //           });
       

    }
}
