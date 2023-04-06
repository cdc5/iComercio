using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;    

namespace iComercio.Forms
{
    public partial class FrmHerramientas : FRM
    {
        public FrmHerramientas()
        {
            InitializeComponent();
        }

        private void Herramientas_Load(object sender, EventArgs e)
        {

        }
        public FrmHerramientas(Principal p)
            : base(p)
        {
            InitializeComponent();
        }

        private void Separa()
        {
            lblreg.Text = "";
            lblCambio.Text = "";
            lblMsg.Text = "";
            List<Cliente> regListCuota;
            lblMsg.Text = "Buscando...";
            regListCuota = bl.Get<Cliente>(bl.pGlob.Comercio.EmpresaID, c => c.Apellido == null).ToList();
            if (regListCuota.Count==0)
            {
                lblMsg.Text = "No hay clientes sin nombre";
                return;

            }
            lblreg.Text = regListCuota.Count.ToString() + " cliente";
            string cApeNom;
            int nPos;
            string s;
             char[] chars = { ' '};
             int nLengh;
             int nC = 0;
             //Cliente regClienteNVO;
            foreach(Cliente cli in regListCuota)
            {
                cApeNom = cli.Nombre;
                nPos = cApeNom.IndexOfAny(chars);
                nLengh = cApeNom.Length - nPos - 1;
                cli.Apellido = cApeNom.Substring(0, nPos);
                cli.Nombre = cApeNom.Substring(nPos + 1, nLengh);
                bl.ActualizarCliente(cli);
                //bl.Transmision<Cliente>(cli, bl.pGlob.Comercio, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
                nC++;
                lblCambio.Text = nC.ToString();
            }
            
            bl.Grabar();
            lblMsg.Text = "Terminado";

        }
        private void BtnSepara_Click(object sender, EventArgs e)
        {
            Separa();
        }
    }
}
