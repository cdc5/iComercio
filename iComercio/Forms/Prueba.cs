using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iComercio.Models;

namespace iComercio.Forms
{
    public partial class Prueba : Form
    {
        BindingSource b = new BindingSource();
        public Prueba()
        {
            InitializeComponent();
        }



        public BindingList<int> sum(BindingList<int> lista) 
        {
            int n = lista.LastOrDefault();
            if (n <= 9)
            {
                lista.Add(n);
                return lista;    
            }
            n= lista.LastOrDefault() / 10 + n % 10;
            lista.Add(n);
            sum(lista);
            return lista;
            
        }

 

        private void Prueba_Load(object sender, EventArgs e)
        {
            BindingList<Int32> lista = new BindingList<Int32>();
            lista.Add(15400);
            lista = sum(lista);
            List<String> ls = lista.Select(x => x.ToString()).ToList();
            MessageBox.Show(lista.LastOrDefault().ToString());
            dgv.AutoGenerateColumns = true;
            b.DataSource = ls;
            dgv.DataSource = b;


           
            //Factura fact = new Factura();
            //List<Factura> facts = new List<Factura>();
            //facts.Add(fact);
            //fact.FacturaID = 1;
            //fact.items = new List<Items>();
            //int i;
            //for (i=0; i <= 10; i++) 
            //{
            //    Items item = new Items();
            //    item.ItemId = i;
            //    item.Factura = fact;
            //    fact.items.Add(item);
            //}
            //dtgFac.DataSource = facts;
            
            //DtgItems.DataSource = fact.items;
            
            
        }
    }
}
