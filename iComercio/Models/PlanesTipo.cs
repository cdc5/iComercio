using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Auxiliar;


namespace iComercio.Models
{
    public class PlanesTipo
    {
        public string PlanesTipoID { get; set; }                  // cambiar PlanesTipoID
        
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }

        public string TipoAV { get; set; }

        public decimal PuntoD { get; set; }
        public decimal PuntoH { get; set; }

        public decimal Inter { get; set; }
        public decimal Inter_Incr { get; set; }

        public decimal Gasto { get; set; }
        public decimal Gasto_Incr { get; set; }
        public decimal? GastoFijo { get; set; }

        public decimal Comis { get; set; }
        public decimal Comis_Incr { get; set; }

        public decimal MontoMax { get; set; }                           //NO VA, YA ESTA EN DETALLES
        public int NroORden { get; set; }

        public string Notas { get; set; }
	    public int Corte { get; set; }

        public string TipoRetencionPlanID { get; set; }
        public virtual TipoRetencionPlan TipoRetencionPlan { get; set; }

        public virtual ObservableListSource<PlanesVenci> planesvenci { get; set; }
        public virtual ObservableListSource<PlanesBonif> planesbonif { get; set; }
        public virtual ObservableListSource<PlanesDetalle> planesdetalle { get; set; }
    }
}
