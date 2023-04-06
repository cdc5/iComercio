using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security;
using iComercio.DAL;
using System.Data.Entity;


namespace iComercio
{
    public partial class Form1 : Form
    {
        ComercioContext db = new ComercioContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dbs = db.Usuarios.Include(i => i.Perfiles).ToList();
            dgv.DataSource = dbs;
            
        }
    }
}
