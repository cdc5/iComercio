using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;


namespace iComercio.Models
{
    public interface ITransmitible
    {
        //string EntidadID();
        //string EntidadID2();
        //string EntidadID3();
       
        InfoTransmision InfoTransmision();
        Dictionary<string, Object> ApiParam(Comercio com);
        void ApiActualizarDesdeRemoto(BusinessLayer bl, object entidad);
        //Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran, Operacion op);
    }
}
