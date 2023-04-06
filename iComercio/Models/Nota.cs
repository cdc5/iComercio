﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Nota
    {
        public int? NotaID { get; set; }
        public int EmpresaID { get; set; }
        public int? Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public int? ComercioID { get; set; }
        public int? CreditoID { get; set; }
        public int? CuotaID { get; set; }
        public int? CobranzaID { get; set; }
        public string Detalle { get; set; }
        public int? UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; } //Usuario
        public DateTime Fecha { get; set; }
    }
}
