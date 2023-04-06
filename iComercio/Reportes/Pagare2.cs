using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iComercio.Models;

namespace iComercio.Reportes
{
    public partial class Pagare2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Pagare2()
        {
            InitializeComponent();
        }

        public Pagare2(Credito cred, Image Logo, bool EsM, string Titulo, string Financia)
        {
            InitializeComponent();
            xrTitulo.Text = Titulo;
            xrFinancia.Text = Financia;
            string Empresa = cred.Empresa.Nombre;
            string EmpresaDim = cred.Empresa.EmpresaDiminutivo;
            string Pagare = @"NORMAS QUE RIGEN EL PRESENTE CREDITO: 1) El titular y el codeudor del crédito (en adelante Tit/Cod.) " +
                             "se comprometen a abonar el mismo, en la canidad, montos y fechas de vencimientos de cuotas pactadas, " +
                             "y en el domicilio de pago determinado por {0} (En adelante {1}), suscribiendo, al momento de " +
                             "recibir el crédito, el documento incluido en esta solicitud por el monto toal a cancelar. " + 
                              "2) {1} considerará cancelada cualquier suma adeudada indefectiblemente cuando sea recibida efectivamente por {1}, " +
                              "reconociéndose como válidos exclusivamente comprobantes de pago emitidos por {1}." + 
                              "3) Vencido el plazo de pago de cualquier cuota no cancelada, el crédito será considerado en mora, "+
                              "haciéndose exigible en su totalidad, más los intereses compensatorios y punitorios, y más los gastos por gestiones " +
                              "extrajudiciales y/o judiciales." +
                              "4) La no cancelación del documento a su fecha de vencimiento, dará lugar al cobro de intereses compensatorios por " +
                              "mora, más un recargo del.....% mensual en concepto de intereses punitorios, y más los gastos ocasionados por gestiones " +
                              "exrajudiciales y/o judiciales. " +
                              "5) En caso de ejecución del documento, el Tit/Cod prestan conformidad con el martillero propuesto por {1}," +
                              "consintiendo, por tratarse de un asunto exclusivamente patrimonial,la prórroga de competencia que solicite {1}" + 
                              "ante cualquier tribunal ordinario de la República Argentina." +
                              "6) El Tit/Cod se comprometen a retirar el documento una vez cancelado totalmente el crédito. Transcurridos 30 (treinta)" + 
                              "días a contar de la fecha de cancelación total del crédito sin que el Tit/Cod hayan retirado el documento, " +
                              "el Tit/Cod autorizan expresamente a {1} a destruir el mismo." +
                              "7) El Tit/Cod autorizan al comercio otorgante del crédito y a {1} a conservar los datos personales suministrados hasta " +
                              "no más de 2 (dos) años de cancelado el crédito, para facilitar la relaciòn comercial entre las partes por la presunción del " +
                              "otorgamiento de posteriores créditos, como también de informar a las distintas entidades encargadas de suministrar información " + 
                              "sobre la solvencia económico-financiera de las personas, y/o la transferencia de los datos a otras entidades similares " +
                              "y de segundo grado y la información a los asociados a dichas entidades, quedando el Tit/Cod con pleno conocimiento del " +
                              "alcance de la misma, de acuerdo a lo establecido por los Art. 5,6 y 11 inc. 1º de la Ley Nº 25.326." +
                              "8) El Tit/Cod. da su consentimiento expreso para que {1} le envíe comunicaciones de gestión administrativa, de cobranzas, " +
                              "e información comercial a través de cartas, mails, llamados y/o mensajes telefónicos y/o cualquier otro medio de comunicación " +
                              "creado o a crearse en el futurom a los domicilios, direcciones de mails y teléfonos que el Titular de crédito suministre a {1}." +
                              "9) El Tit/Cod declaran conocer y aceptar las presentes normas que rigen el mismo, dejando constancia de que todos los datos registrados" + 
                              "en la rpesente solicitud son ciertos, revistiendo el carácter de Declaración Jurada.";
            string PagareCompleto = String.Format(Pagare, Empresa, EmpresaDim);
            //xrPictureBox1.Image = Logo;
            xrlblMutuo.Text = PagareCompleto;
            xrlblComCredito.Text = String.Format("{0}-{1}", cred.ComercioID, cred.CreditoID);
            bsCredito.DataSource = cred;

            if (EsM)
            {
                xrTitulo.Text = "";
                xrFinancia.Text = "";
                //xrPictureBox1.Image = null;
            }
        }




    }
}
