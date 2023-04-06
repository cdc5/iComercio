using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;

namespace iComercio.Forms
{
    public partial class frmQueImprimo : FRM 
    {
        Button[] bots = null;
        Button bot = null;
        public int? resp = null;

        public frmQueImprimo()
        {
            InitializeComponent();
        }

        public frmQueImprimo(Principal p,BusinessLayer bl,Dictionary<int,string> botones):base(p,bl)
        {
            Configura_Colores(this.bl.pGlob.Comercio.EmpresaID);

            bots = new Button[botones.Count()];
            InitializeComponent();
            int posx = this.Left+5;
            int posy = this.Top;

            foreach (KeyValuePair<int, string> b in botones)
            {   
                bot = new Button();
                bot.Name = b.Key.ToString();
                bot.Text = b.Value;
                bot.Click += bot_Click;
                
                bot.Height = 40;
                bot.Width = this.Width - 25;
                bot.Left = posx;
                bot.Top = posy;
                bot.Enabled = true;
                bot.Visible = true;
                this.Controls.Add(bot);

                posy += bot.Height;                    
            }                
        }

        void bot_Click(object sender, EventArgs e)
        {
            this.resp = System.Convert.ToInt32(((Button)sender).Name);
            this.Close();
        }

        private void frmQueImprimo_Load(object sender, EventArgs e)
        {

        }
    }
}
