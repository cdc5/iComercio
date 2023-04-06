using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace iComercio.Models
{
    public class InfoObjetivos
    {
        [DataType(DataType.Currency)]
        [Display(Name = "Saldo caja cobranzas:")]
        public decimal? saldoCajaCob { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Saldo caja ventas:")]
        public decimal? saldoCajaVen { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Objetivo de ventas:")]
        public decimal? objetivoVentas { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Venta diaria:")]
        public decimal? VentaDiaria { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Ventas del período:")]
        public decimal? Ventas { get; set; }

        [Display(Name = "Porcentaje de objetivo de ventas cumplido:")]
        public decimal? porcObjVentas { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Objetivo de cobranzas:")]
        public decimal? objetivoCobranzas { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Cobranza diaria:")]
        public decimal? CobranzaDiaria { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Cobranzas del período:")]
        public decimal? Cobranzas { get; set; }

        [Display(Name = "Porcentaje de objetivo de cobranzas cumplido:")]
        public decimal? porcObjCob { get; set; }

        [Display(Name = "Días hábiles:")]
        public int? DiasHab { get; set; }

        [Display(Name = "Días hábiles transcurridos:")]
        public int? DiasHabTrans { get; set; }

        [Display(Name = "Porcentaje de días hábiles transcurridos:")]
        public decimal? porcObjDiasHabTrans { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Venta diaria para objetivo:")]
        public decimal? VentaDiariaParaObj { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Cobranza diaria para objetivo:")]
        public decimal? CobranzaDiariaParaObj { get; set; }

        public string simboloMoneda { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valores a rendir")]
        public decimal? ValoresARendir { get; set; }
    }
    
}
