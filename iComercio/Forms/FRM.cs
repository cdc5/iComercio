using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Runtime.InteropServices;
using iComercio.DAL;
using iComercio.Models;
using iComercio.Rest;
using iComercio.Auxiliar;

//using System.IO;

namespace iComercio.Forms
{
    public partial class FRM : Form
    {
    

        public Principal p;
        public BusinessLayer bl;
        //public BusinessLayer bl2;
        public Color ColorBackColorFrm; //= SystemColors.GradientInactiveCaption;
        public Color ColorBackColorTs; //= SystemColors.GradientInactiveCaption;
        public Color ColorForeColorLbl;// = SystemColors.ActiveCaption;
        public Color ColorBackColorInf; //= Color.Blue;
        public Color ColorTransparente;     

        //**EDU MOR**//
      //  public string cLlevaMor = "A";                           // "A" = AUTOMÁTICO    "M" = Manual  "N" = COMUN
        public bool bFormaPago = true;
        public bool bAceptaFOrmaPago = false;
        //**EDU MOR**//

        public int BaseID;
        public int ComID;
        public Comercio Com;
        public Empresa Emp;

        #region 
        int DY, DX;
        //' Declaraciones del API para 32 bits
        [DllImport("user32.DLL", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong(
            int hWnd,    // handle to window
            int nIndex    // offset of value to retrieve
        );
        [DllImport("user32.DLL", EntryPoint = "SetWindowLong")]
        static extern int SetWindowLong(
            int hWnd,        // handle to window
            int nIndex,     // offset of value to set
            int dwNewLong    // new value
        );
        [DllImport("user32.DLL", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,                // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                    // horizontal position
            int Y,                    // vertical position
            int cx,                    // width
            int cy,                    // height
            uint uFlags                // window-positioning options
        );
        const int GWL_STYLE = (-16);
        const int WS_THICKFRAME = 0x40000; //' Con borde redimensionable
        //'
        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;
        #endregion

        public FRM()
        {
            InitializeComponent();           
        }

        public FRM(int EmpresaID)
        {
            InitializeComponent();
            Configura_Colores(EmpresaID);            //***edu***
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
            //  this.bl = new BusinessLayer();
        }

        public FRM(Principal _p,RestApi _ra)
        {
            InitializeComponent();
            this.bl = new BusinessLayer();
            this.p = _p;
            bl.ra = _ra;
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);            //***edu***
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
        }

        public FRM(Principal _p)
        {
            InitializeComponent();
            this.bl = new BusinessLayer();
            this.p = _p;
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);            //***edu***
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
        }

        public FRM(Principal _p,BusinessLayer bl)
        {
            InitializeComponent();
            this.bl = bl;
            this.p = _p;
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);            //***edu***
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;

        }

        public FRM(Principal _p, BusinessLayer bl, RestApi _ra)
        {
            InitializeComponent();
            this.bl = bl;
            this.p = _p;
            bl.ra = _ra;
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);            //***edu***
        }


        public void RecargarEmpYComercio(bool EsM)
        {
            BaseID = bl.GetEmpresa(EsM).EmpresaID.Value;
            ComID = bl.GetComercio(EsM).ComercioID;
            Com = bl.GetComercio(EsM);
            Emp = Com.Empresa;
            
        }

        private void FRM_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.CredinIco;
            //FitFormScreen.fitFormToScreen(this, 768, 1036);
            //fitFormToScreen();
            
           
        }

        public void fitFormToScreen()
        {
            FormScaling.fitFormToScreen(this, 900, 1600, bl.pGlob.Configuracion.MinIndiceHRedux, bl.pGlob.Configuracion.MinIndiceWRedux, bl.pGlob.Configuracion.MinIndiceFontRedux);
            //this.CenterToScreen();
        }

        
        protected void Configura_Colores(int EmpresaID)       //***edu***
        {
            //   ***edu*** //               CODIGOS COLORES PARA PONER EN ALGUN LADO
            int BackColor_Frm_R = 215;// 0;//
            int BackColor_Frm_G = 228;//255;//
            int BackColor_Frm_B = 242; //127;//
                
            // label de informacion / cintas / etc / 
            int BackColor_lblInf_R = 153;
            int BackColor_lblInf_G = 180;
            int BackColor_lblInf_B = 209;
          
            // label de información de txt
            int ForeColor_lbl_R = 0;
            int ForeColor_lbl_G = 0;
            int ForeColor_lbl_B = 255;

             // Toolstrip
            int BackColor_Ts_R = 0;
            int BackColor_Ts_G = 0;
            int BackColor_Ts_B = 0;

                if (EmpresaID == 1)
            {
                BackColor_Frm_R = 129;
                BackColor_Frm_G = 145;
                BackColor_Frm_B = 250;

                // label de informacion / cintas / etc / 
                BackColor_lblInf_R = 46;
                BackColor_lblInf_G = 139;
                BackColor_lblInf_B = 87;
             
                // label de información de txt
                ForeColor_lbl_R = 0;
                ForeColor_lbl_G = 0;// 100;
                ForeColor_lbl_B = 0;

                BackColor_Ts_R = 0;
                BackColor_Ts_G =0;
                BackColor_Ts_B =0;
            }

            if (EmpresaID == 2)
            {
                BackColor_Frm_R =  246;//255
                BackColor_Frm_G = 164;//153
                BackColor_Frm_B = 93; //153

                //label de informacion / cintas / etc / 
                BackColor_lblInf_R = 255;
                BackColor_lblInf_G = 224;
                BackColor_lblInf_B = 192;
             
                // label de información de txt
                ForeColor_lbl_R = 0;
                ForeColor_lbl_G = 0;// 100;
                ForeColor_lbl_B = 0;

                BackColor_Ts_R = 0;
                BackColor_Ts_G = 0;
                BackColor_Ts_B = 0;
            }

            if (EmpresaID == 3)
            {
                BackColor_Frm_R = 152;// PaleGreen
                BackColor_Frm_G = 251;
                BackColor_Frm_B = 152;

                // label de informacion / cintas / etc / 
                BackColor_lblInf_R = 46;
                BackColor_lblInf_G = 139;
                BackColor_lblInf_B = 87;
                // label de información de txt
                ForeColor_lbl_R = 0;
                ForeColor_lbl_G = 128;// 100;
                ForeColor_lbl_B = 0;


                BackColor_Ts_R = 0;
                BackColor_Ts_G = 0;
                BackColor_Ts_B = 0;
            }
            ColorBackColorFrm = Color.FromArgb(BackColor_Frm_R, BackColor_Frm_G, BackColor_Frm_B);
            ColorBackColorInf = Color.FromArgb(BackColor_lblInf_R, BackColor_lblInf_G, BackColor_lblInf_B);
            ColorForeColorLbl  = Color.FromArgb(ForeColor_lbl_R, ForeColor_lbl_G, ForeColor_lbl_B);
            ColorBackColorTs  = Color.FromArgb(BackColor_Ts_R, BackColor_Ts_G, BackColor_Ts_B);
            ColorTransparente = Color.FromArgb(100, 100, 100);
        }

        protected void Cerrar()
        {
            this.Close();
        }
       
        protected void Grabar()
        {
            bl.Grabar();
        }

        protected void CerrarConConfirmacion()
        {
           MessageBox.Show(Properties.Resources.CerrarConConfirmacion, Properties.Resources.Informacion,
                                             MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        protected void CerrarConMensajeDeAdvertencia()
        {
            DialogResult dr = MessageBox.Show(Properties.Resources.AdvertenciaCerrando, Properties.Resources.Advertencia,
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }

        }

   

        #region //**edu**

        protected decimal Calcula_Punitorio(decimal nImporte, DateTime fVenci, decimal nPorce1, decimal nPorce2,bool EsRefi)
        {
            if (DateTime.Now <= fVenci) 
                return 0;

            if (!EsRefi)
            {
                if (Com.Tolerancia != null)
                {
                    if (fVenci.AddDays(Com.Tolerancia.Value) > DateTime.Now)
                        return 0;
                }
            }                
            
            decimal nTmp1 = 0;
            decimal punito1 = 0;
            decimal punito2 = 0;
            TimeSpan ndias = DateTime.Now - fVenci;
            if (ndias.Days < 31)
            {
                punito1 = (nPorce1 * ndias.Days * nImporte);
            }
            else
            {
                punito1 = (nPorce1 * 30 * nImporte);
                punito2 = nPorce2 * (ndias.Days - 30) * nImporte;
            }
            nTmp1 = Convert.ToDecimal(Redondeo(punito1 + punito2));
            return nTmp1;
        }

        private void ExtendedToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            // Get the separator's width and height.
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;

            // Choose the colors for drawing.
            // I've used Color.White as the foreColor.
            Color foreColor = SystemColors.Control;
            // Color.Teal as the backColor.
            Color backColor = ColorBackColorFrm; //Color.FromName(Utilities.Constants.ControlsRelatedConstants.standardBackColorName);

            // Fill the background.
            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);

            // Draw the line.
            e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
        }

        protected void Recorre_Formulario(Form fr)              //Recorre todos los controles de un formulario
        {
            string cTag = "";
            foreach (object ob in fr.Controls)
            {
                if (ob is Control)
                {
                    cTag = "";
                    if (ob is ListView)
                    {
                        // aca poner los tex, lbl, etc que estan en el formu
                        // para evitar estas líneas, habria que poner tooodos los controles sobre un panel u otros contenedores
                        ListView lv = (ListView)ob;                        
                        if (lv.Tag != null) cTag = lv.Tag.ToString();
                        if (lv.Tag != null) if (cTag.Substring(0, 1) == "C") lv.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
                        if (lv.Tag != null) if (cTag.Substring(1, 1) == "S") lv.DrawSubItem += new DrawListViewSubItemEventHandler(lista_DrawSubItem);
                        //DrawListViewItemEventHandler
                    }
                    else
                    {
                       if (ob is GroupBox || ob is DevExpress.XtraEditors.GroupControl)
                        {
                            ((Control)ob).BackColor = ColorBackColorFrm;
                        }
                        if (ob is StatusStrip)
                        {
                            ((Control)ob).BackColor = ColorBackColorFrm;
                        }
                        if (ob is MenuStrip)
                        {
                            MenuStrip ms = (MenuStrip)ob;
                            ms.BackColor = ColorBackColorFrm;
                            ColorearMenus(ms.Items);
                        }
                        if (ob is ToolStripMenuItem)
                        {
                            
                        }
                        if (ob is ToolStrip)
                        {
                            ToolStrip ts = (ToolStrip)ob;
                         //   ts.BackColor = ColorBackColorFrm;
                            //ColorearMenus(ms.Items);

                        }
                        Control ct = (Control)ob;
                        if (ct.Tag != null)
                        {
                            cTag = ct.Tag.ToString();
                            if (ct.Tag != null)
                            {
                                cTag = ct.Tag.ToString();
                                if (cTag.Length > 4)
                                {
                                    if (cTag.Substring(4, 1) == "B") ct.BackColor = ColorBackColorInf;

                                }
                                //if (cTag.Length > 5)
                                //{
                                //    if (cTag.Substring(5, 1) == "F") ct.ForeColor = ColorForeColorLbl;
                                //}
                            }
                            //"C" pone el color a los label que muestran datos
                            if ((string)ct.Tag == "C") ct.BackColor = Color.LightBlue;

                        }
                        Recorre_Controles(ct);
                    }

                }

            }
        }

        protected void ColorearMenus(ToolStripItemCollection items)
        {
            int i;
            for (i = 0; i < items.Count; i++)
            {
                if (items[i] is ToolStripMenuItem)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)items[i];
                    item.BackColor = ColorBackColorFrm;
                    if (item.DropDownItems != null && item.DropDownItems.Count > 0)
                        ColorearMenus(item.DropDownItems);
                }
                else if (items[i] is ToolStripSeparator)
                {
                    ToolStripSeparator item = (ToolStripSeparator)items[i];
                    item.Paint += ExtendedToolStripSeparator_Paint;       
                }
            }
           
            //foreach (ToolStripMenuItem item in items)
            //{
            //    item.BackColor = ColorBackColorFrm;
            //    if (item.DropDownItems != null && item.DropDownItems.Count > 0)
            //        ColorearMenus(item.DropDownItems);
            //}
        }

       

        protected void Cambia_BackFore(string qBK)
        {

        }
        protected void Recorre_Controles(Control control)                               //Recorre todos los objetos de un panel, grp, etc
        {
            string cTag = "";
            if (control.TabIndex == 0)
            {
                control.Focus();
                control.Select();
            }

            foreach (Control contr in control.Controls)
            {
                if (contr.HasChildren)
                {
                    this.Recorre_Controles(contr);                                       // vuelve sobre si mismo
                }
                else
                {
                    cTag = "";
                    if (contr is Label || contr is RadioButton)
                    {
                        if (contr.Tag != null)
                        {
                            cTag = contr.Tag.ToString();
                            if(cTag.Length>4)
                            {
                                if (cTag.Substring(4, 1) == "B") contr.BackColor =ColorBackColorInf ;
                               
                            } 
                            //if(cTag.Length>5)
                            //{
                            //    if (cTag.Substring(5, 1) == "F") contr.ForeColor = ColorForeColorLbl;
                            //}
                        }
                        //"C" pone el color a los label que muestran datos
                        if ((string)contr.Tag == "C") contr.BackColor = Color.LightBlue;
                    }
                    if (contr is GroupBox || contr is DevExpress.XtraEditors.GroupControl)
                    {
                        contr.BackColor = ColorBackColorFrm;
                    }  
                    //if (contr is RadioButton)
                    //{
                    //    if (contr.Tag != null)
                    //    {
                    //        cTag = contr.Tag.ToString();
                    //        if (cTag.Length > 4)
                    //        {
                    //            if (cTag.Substring(4, 1) == "B") contr.BackColor = ColorForeColorLbl;

                    //        }
                    //        if (cTag.Length > 5)
                    //        {
                    //            if (cTag.Substring(5, 1) == "F") contr.ForeColor = ColorBackColorInf;
                    //        }
                    //    }
                    //    //"C" pone el color a los label que muestran datos
                    //    if ((string)contr.Tag == "C") contr.BackColor = Color.LightBlue;
                    //}
                    if (contr is TextBox)
                    {
                        contr.GotFocus += contr_Txt_GotFocus;
                        if (contr.Tag != null) cTag = contr.Tag.ToString();                        
                        if (cTag.Length > 0)
                        {
                            if (cTag.Substring(0, 1) == "N") // "N"  para los tex de números sin decimales
                            {
                                contr.KeyPress += KeyPress_Solonumeros;
                                contr.Leave += new EventHandler(DejaTxtNum);
                                if (cTag.Length > 1 && cTag.Substring(1, 1) != "N")
                                    contr.Leave += new EventHandler(DejaTxtNum);
                            }
                            if (cTag.Length == 1)
                            {
                                if (cTag.Substring(0, 1) == "D") // "D" para los tex de números con dos decimales
                                {
                                    contr.KeyPress += KeyPress_Solonumeros;
                                    contr.Leave += new EventHandler(DejaTxtDeci);
                                }
                            }
                            else
                                {
                                    if (cTag.Substring(0, 2) == "D4") // "D4" para los tex de números con 4 decimales
                                    {
                                        contr.KeyPress += KeyPress_Solonumeros;
                                        contr.Leave += new EventHandler(DejaTxtDeci4);
                                    }
                                }
                            }
                    }
                    cTag = "";
                    if (contr is ListView)
                    {
                        ListView lv = (ListView)contr;
                        if (lv.Tag != null)
                        {
                            cTag = lv.Tag.ToString();
                            if (cTag.Substring(0, 1) == "C") lv.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
                            if (cTag.Substring(1, 1) == "S") lv.DrawSubItem += new DrawListViewSubItemEventHandler(lista_DrawSubItem);
                        }
                    }
                    if (contr is MenuStrip || contr is StatusStrip || contr is ToolStripMenuItem)
                    {
                        contr.BackColor = ColorBackColorFrm;
                    }                      
                }
            }
        }

        void contr_Txt_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();            
        }

        //protected int Calcula_dias_mora(DateTime fVenci, DateTime fHoy)
        //{
        //    TimeSpan ndias = fHoy - fVenci;
        //    return ndias.Days;
        //}
        protected void Txt_PasaConEnter_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        protected decimal Redondeo_Abajo(decimal Cosa) //edu 202222
        {
            decimal nTot;

            nTot = Math.Ceiling(Cosa);

            string cUlti = nTot.ToString();
            string Ulti = cUlti.Substring(cUlti.Length - 1, 1);
            int nUlti = Convert.ToInt16(Ulti);


            if (nUlti == 0)
            {
                //nada, se puede sacar
            }
            else if (nUlti < 5)
            {
                nTot = nTot - nUlti;
            }
            else if (nUlti > 5)
            {
                nTot = nTot - (10 - nUlti);
            }

            return nTot;
        }
        public decimal Redondeo(decimal Cosa)
        {
            decimal redondeo = Cosa;
            decimal nbase =  bl.pGlob.Configuracion.nRedondeo;
            if (nbase == 0) return redondeo;
            if (EsDiv(redondeo, nbase)) return redondeo;
            if (Cosa <= nbase) return redondeo;
            if (Cosa <= nbase)
            {
                nbase = nbase / 10;
            }
            bool bAbajo = false;
            decimal dCosa = Cosa + nbase;
            decimal nModulo = dCosa % nbase;
            if (bAbajo)
            {
                redondeo = Cosa - nModulo;
            }
            else
            {
                redondeo = Cosa + (nbase - nModulo);
            }

            return redondeo;


        }
        public static bool EsDiv(decimal dQue, decimal dPor)
        {
            if (Convert.ToInt64((dQue / dPor)) == dQue / dPor) return true;
            else return false;
        }
        protected decimal RedondeoXX(decimal Cosa)
        {
            decimal nTot;

            nTot = Math.Ceiling(Cosa);

            string cUlti = nTot.ToString();
            string Ulti = cUlti.Substring(cUlti.Length - 1, 1);
            int nUlti = Convert.ToInt16(Ulti);
                       
            
            if (nUlti == 0)
            {
                //nada, se puede sacar
            }
            else if (nUlti < 5)
            {
                nTot = nTot - nUlti;
            }
            else if (nUlti > 5)
            {
                nTot = nTot + (10 - nUlti);
            }

            return nTot;
        }

        protected bool Cambiar_Sin_Grabar()                         // modificar pregunta y ponerlo como los otros
        {
            DialogResult dr = MessageBox.Show("¿Salir sin grabar los cambios?", Properties.Resources.Advertencia,
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        protected void Busca_En_Combo(ComboBox cb, string qB)       // MUUUY lento para muchos datos
        {
            if (cb.Items.Count > 0 )
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cb.SelectedIndex = i;
                    if (cb.SelectedValue.ToString() == qB)
                    {
                        return;
                    }
                }
                cb.SelectedIndex = 0;
            }
            cb.SelectedIndex = -1;
          
        }
        public static void Evento_EnterColor(object sender, EventArgs e)//edu 202208
        {
            try
            {
            TextBox tt = (TextBox)sender;
            tt.BackColor = Color.AliceBlue; // .CornflowerBlue; // Color.LightBlue;
            }
            catch { }
        }
        public static void Evento_LeaveColor(object sender, EventArgs e)
        {
            try
            {
                TextBox tt = (TextBox)sender;                       //edu 202208
                tt.BackColor = Color.White;
            }
            catch { }
        }
        protected void Evento_EnterColorCmb(object sender, EventArgs e)
        {
                        try
            {
                ComboBox tt = (ComboBox)sender;                       //edu 202208
            tt.BackColor = Color.LightBlue;
            }
                        catch { }
        }
        protected void Evento_LeaveColorCmb(object sender, EventArgs e)
        {
            ComboBox tt = (ComboBox)sender;
            tt.BackColor = Color.White;
        }
        protected void lista_Dibuja_Encabezado(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                e.DrawBackground();
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                using (Font headerFont = new Font("Verdana", 7, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                            Brushes.Black, e.Bounds, sf);
                }
            }
        }
        protected void lista_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        //protected void ValidarEntero(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    int num;
        //    if (Int32.TryParse(txt.Text, out num)) // Si es mayor que el valor permitido para un entero va a ser falsa la conversion
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}

        public static void DejaTxtNum(object sender, EventArgs e)
        {
            TextBox tt = (TextBox)sender;

            decimal deja = 0;
            string cNvo = "";
            if (tt.Text == "" || tt.Text == null)
            {
                tt.Text = "0";
            }
            tt.Text = tt.Text.Trim();
            foreach (var ch in tt.Text)
            {
                if (char.IsDigit(ch))
                {
                    cNvo = cNvo + ch;
                }
            }
            if (cNvo == "") cNvo = "0";
            deja = Convert.ToDecimal(cNvo);
            tt.Text = cNvo; // deja.ToString();
        }

        public static void DejaTxtDeci(object sender, EventArgs e)
            {
                TextBox tt = (TextBox)sender;

                decimal deja = 0;
                string cNvo = "";
                if (tt.Text == "" || tt.Text == null)
                {
                    tt.Text = "0";
                }
                try
                {
                    foreach (var ch in tt.Text)
                    {
                        if (Char.IsPunctuation(ch))
                        {
                            if (char.IsLetterOrDigit(ch))
                            {
                                cNvo = cNvo + ch;
                            }
                            else if ((ch) == 44)
                            {
                                cNvo = cNvo + ch;
                            }
                            //else if ((ch) == 46)
                            //{
                            //    cNvo = cNvo + ',';
                            //}
                        }
                        if (char.IsDigit(ch))
                        {
                            cNvo = cNvo + ch;
                        }
                    }
                    if (cNvo == "") cNvo = "0";

                    deja = Convert.ToDecimal(cNvo);
                    tt.Text = deja.ToString("N2");
                }
                catch
                {
                    tt.Text = "0";
                }
            }

        public static void DejaTxtDeci4(object sender, EventArgs e)
        {
            TextBox tt = (TextBox)sender;

            decimal deja = 0;
            string cNvo = "";
            if (tt.Text == "" || tt.Text == null)
            {
                tt.Text = "0";
            }
            try
            {
                foreach (var ch in tt.Text)
                {
                    if (Char.IsPunctuation(ch))
                    {
                        if (char.IsLetterOrDigit(ch))
                        {
                            cNvo = cNvo + ch;
                        }
                        else if ((ch) == 44)
                        {
                            cNvo = cNvo + ch;
                        }
                        //else if ((ch) == 46)
                        //{
                        //    cNvo = cNvo + ',';
                        //}
                    }
                    if (char.IsDigit(ch))
                    {
                        cNvo = cNvo + ch;
                    }
                }
                if (cNvo == "") cNvo = "0";
                deja = Convert.ToDecimal(cNvo);
                tt.Text = deja.ToString("N4");
            }
            catch
            {
                tt.Text = "0";
            }
        }
        public static void KeyPress_Solonumeros(object sender, KeyPressEventArgs e)
        {
            //Para mover con enter al siguiente control
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{                
            //    SelectNextControl((Control)sender,true,true,true,true);                
            //}
            

    

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ',';
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        protected void AMinusculas(TextBox txt)  //edu 202208
        {
            txt.Text = txt.Text.ToLower();
        }
        protected void AMayusculas(TextBox txt)
        {
            txt.Text = txt.Text.ToUpper();
        }

        protected void LlenaCmb_meses(ComboBox cmb, Boolean Corto = false) 
        {

            if (Corto)
            {
                cmb.Items.Add("Ene");
                cmb.Items.Add("Feb");
                cmb.Items.Add("Mar");
                cmb.Items.Add("Abr");
                cmb.Items.Add("May");
                cmb.Items.Add("Jun");
                cmb.Items.Add("Jul");
                cmb.Items.Add("Agos");
                cmb.Items.Add("Sep");
                cmb.Items.Add("Oct");
                cmb.Items.Add("Nov");
                cmb.Items.Add("Dic");
            }
            else
            {
                cmb.Items.Add("Enero");
                cmb.Items.Add("Febrero");
                cmb.Items.Add("Marzo");
                cmb.Items.Add("Abril");
                cmb.Items.Add("Mayo");
                cmb.Items.Add("Junio");
                cmb.Items.Add("Julio");
                cmb.Items.Add("Agosto");
                cmb.Items.Add("Septiembre");
                cmb.Items.Add("Octubre");
                cmb.Items.Add("Noviembre");
                cmb.Items.Add("Diciembre");
            }
        }

        #endregion //**edu**

        #region 
        protected void Centrar_Control(Form fr, System.Windows.Forms.Control ctr)
        {
            ctr.Top = (fr.Height / 2) - (ctr.Height / 2);
            ctr.Left = (fr.Width / 2) - (ctr.Width / 2);
        }
        protected void Asigna_Poder_Mover(System.Windows.Forms.Control oContro)
        {
            oContro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Control);
            oContro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_Control);
        }
        protected void Asigna_Cambiar_Tamaño(System.Windows.Forms.Control oContro)
        {
            oContro.MouseEnter += new System.EventHandler(this.MouseEnter_Control);
        }

        protected void MouseDown_Control(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DX = e.X;
            DY = e.Y;
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender; // pone redimension
            if (e.Button == MouseButtons.Right)
            {
                CambiarEstilo(elControl);
            }
            else
            {
                elControl.BringToFront();
            }
        }
        private void MouseMove_Control(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
                elControl.Left = e.X + elControl.Left - DX;
                elControl.Top = e.Y + elControl.Top - DY;
            }
        }
        private void MouseEnter_Control(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
        }
        void CambiarEstilo(System.Windows.Forms.Control aControl)
        {
            int Style;

            try
            {
                Style = GetWindowLong(aControl.Handle.ToInt32(), GWL_STYLE);
                if ((Style & WS_THICKFRAME) == WS_THICKFRAME)
                {
                    Style = Style ^ WS_THICKFRAME; // lo saca
                }
                else
                {
                    Style = Style | WS_THICKFRAME; // lo pone
                }
                SetWindowLong(aControl.Handle.ToInt32(), GWL_STYLE, Style);
                SetWindowPos(aControl.Handle.ToInt32(), this.Handle.ToInt32(), 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_NOMOVE | SWP_DRAWFRAME);
            }
            catch
            {
                //nada
            }
        }
        #endregion

        protected string LLena_Ceros(string cNum, int CuantosCeros) 
        {
            string Ceros = "0";
            int nCuantosHay = cNum.Length;
            int nFaltan = 0;
            Ceros = cNum;
            if (nCuantosHay >= CuantosCeros)
            { Ceros = cNum; }
            else
            {
                nFaltan = CuantosCeros - nCuantosHay;
                for (int i = 1; i <= nFaltan; i++)
                {
                    Ceros = "0" + Ceros;
                }

            }
            return Ceros;
        }



        protected void PuntoAComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';
        }
        protected void Mando_A_Portapapeles(ListView aList, int nColDesde)
        {
            string cCopio = "";
            int nC = aList.Columns.Count - 1;//columnas
            int nF = aList.Items.Count;//filas
            string cBorrar;
            for (int n = nColDesde; n <= nC; n++)
            {
                cBorrar = aList.Columns[n].Text;
                cBorrar = cBorrar.Replace("\r\n", " ");
                cCopio = cCopio + cBorrar + "\t";
            }
            cCopio = cCopio + Environment.NewLine;

            foreach (ListViewItem item in aList.Items)
            {
                for (int nColum = nColDesde; nColum <= item.SubItems.Count - 1; nColum++)
                {
                    cBorrar = item.SubItems[nColum].Text;
                    cBorrar = cBorrar.Replace("\r\n", " ");
                    cCopio = cCopio + cBorrar + "\t";
                }
                cCopio = cCopio + Environment.NewLine;
            }
            Clipboard.SetText(cCopio, TextDataFormat.Text);
        }
        protected void AguardeFrm(Label olabel, int? nCuantos = 0)  
        {
            if (nCuantos == 0) nCuantos = 150;

            if (olabel.Text.Length > nCuantos) olabel.Text = "AGUARDE  "; else olabel.Text = olabel.Text + "|";
            Application.DoEvents();
        }
        protected void Mando_A_Portapapeles_Grid(DataGridView aGrid, bool bEnca = true) //, int nColDesde)
        {
            string cCopio = "";
            int nC = aGrid.ColumnCount - 1;//columnas
            int nF = aGrid.RowCount;//filas
            string cBorrar;
            if (bEnca)
            {
                for (int n = 0; n <= nC; n++)
                {
                    if (aGrid.Columns[n].Visible)
                    {
                        cBorrar = aGrid.Columns[n].Name;
                        cBorrar = cBorrar.Replace("\r\n", " ");
                        cCopio = cCopio + cBorrar + "\t";
                    }
                }
                cCopio = cCopio + Environment.NewLine;
            }
            //foreach (ListViewItem item in aList.Items)
            for (int nR = 0; nR < aGrid.Rows.Count; nR++)
            {
                //for (int nColum = nColDesde; nColum <= item.SubItems.Count - 1; nColum++)
                for (int nColum = 0; nColum < aGrid.ColumnCount; nColum++)
                {
                    if (aGrid.Columns[nColum].Visible)
                    {
                        if (aGrid.Rows[nR].Cells[nColum].Value != null)
                        {
                            cBorrar = aGrid.Rows[nR].Cells[nColum].Value.ToString();
                        }
                        else
                        {
                            cBorrar = "";
                        }
                        cBorrar = cBorrar.Replace("\r\n", " ");
                        cCopio = cCopio + cBorrar + "\t";
                    }
                }
                cCopio = cCopio + Environment.NewLine;
            }
            Clipboard.SetText(cCopio, TextDataFormat.Text);
        }
        public static void Limpia_controles(Control control)                       //edu 202208
        {
            foreach (System.Windows.Forms.Control contr in control.Controls)
            {
                if (contr.HasChildren)
                {
                    Limpia_controles(contr);
                }
                if (contr is Label)
                {
                    if (contr.Tag != null)
                    {
                        if (contr.Tag.ToString() == "C") contr.Text = "";
                        if (contr.Tag.ToString() == "T") contr.Text = "";
                        if (contr.Tag.ToString() == "N") contr.Text = "0";


                    }
                }
                if (contr is TextBox)
                {
                    if (contr.Tag != null && (contr.Tag.ToString() == "N" || contr.Tag.ToString() == "D" || contr.Tag.ToString() == "D4"))
                    {
                        contr.Text = "0";
                    }
                    else contr.Text = "";

                    TextBox tt = (TextBox)contr;
                    tt.BackColor = Color.White;
                }
                if (contr is ComboBox)
                {
                    if (((ComboBox)contr).Items.Count > 0) ((ComboBox)contr).SelectedIndex = 0;
                }
                if (contr is DataGridView)
                {
                    ((DataGridView)contr).Rows.Clear();
                }
                if (contr is DateTimePicker)
                {
                    ((DateTimePicker)contr).Value = DateTime.Now;
                }
            }
        }

        protected void GridConfigInicio(DataGridView gr, int nColumnas)                       //edu 202208
        {
            gr.Rows.Clear();
            gr.Columns.Clear();
            gr.ColumnCount = nColumnas;
        }
        protected void GridConfigFinal(DataGridView gr, Color color, int nFuenteTamaño, FontStyle fontStyle) //edu 202208
        {                      
            for (int nC = 0; nC < gr.Columns.Count; nC++)
            {
                gr.Columns[nC].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            gr.EnableHeadersVisualStyles = false;
            gr.ColumnHeadersDefaultCellStyle.BackColor = color; // Color.DarkGray; // LightSlateGray;
            gr.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Helvetica", nFuenteTamaño, fontStyle); //Helvetica  Microsoft Sans Serif
            gr.BackgroundColor = Color.WhiteSmoke;
            //gr.RowHeadersVisible = false;
            gr.RowHeadersWidth = 21;
            //gr.Columns[gr.Columns.Count-1].Visible = false;
        }
        protected void GridAgregarCol(DataGridView gr, int nColumna, string cNombre, int nWidth, string cAlig, string cTag = "T")
        {                       //edu 202208
            gr.Columns[nColumna].Name = cNombre;
            gr.Columns[nColumna].Width = nWidth;

            if (cAlig == "I") gr.Columns[nColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            if (cAlig == "C") gr.Columns[nColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (cAlig == "D") gr.Columns[nColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gr.Columns[nColumna].Tag = cTag;
            if (cTag == "D") gr.Columns[nColumna].DefaultCellStyle.Format = "N2";
            if (cTag == "N") gr.Columns[nColumna].DefaultCellStyle.Format = "N0";
            if (cTag == "F") gr.Columns[nColumna].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (nWidth == 0) gr.Columns[nColumna].Visible = false;
        }

        public static void Recorre_Formularios(Control control)                       //edu 202208
        {
            string cTag = "";
            foreach (System.Windows.Forms.Control contr in control.Controls)
            {
                if (contr.HasChildren)
                {
                    Recorre_Formularios(contr);
                }
                cTag = "Z";
                if (contr.Tag != null) cTag = contr.Tag.ToString();
                if (cTag == "") cTag = "Z";

                //if (cTag.Length > 2 && cTag.Substring(2, 1) == "S")
                //{
                //    CreaSombra(contr);
                //}
                //else if (cTag.Length > 2 && cTag.Substring(2, 1) == "T")
                //{
                //    CreaSombra(contr, 2, Color.DarkGray);
                //}


                if (contr is TextBox)
                {
                    contr.Leave += new EventHandler(Evento_LeaveColor);
                    contr.Enter += new EventHandler(Evento_EnterColor);
                    //contr.KeyPress += Txt_PasaConEnter_KeyPress;
                    if (cTag.Substring(0, 1) == "N")
                    {
                        contr.KeyPress += KeyPress_Solonumeros;
                        contr.Leave += new EventHandler(DejaTxtNum);
                    }
                    if (cTag.Length == 1)
                    {
                        if (cTag.Substring(0, 1) == "D")
                        {
                            contr.KeyPress += KeyPress_Solonumeros;
                            contr.Leave += new EventHandler(DejaTxtDeci);
                        }

                    } if (cTag.Length == 2)
                    {
                        if (cTag.Substring(0, 2) == "D4")
                        {
                            contr.KeyPress += KeyPress_Solonumeros;
                            contr.Leave += new EventHandler(DejaTxtDeci4);
                        }
                    }
                }
                if (contr is TextBox)
                {
                    contr.Leave += new EventHandler(Evento_LeaveColor);
                    contr.Enter += new EventHandler(Evento_EnterColor);
                    //contr.KeyPress += Txt_PasaConEnter_KeyPress;
                }
                if (contr is CheckBox)
                {
                    contr.Leave += new EventHandler(Evento_LeaveColor);
                    contr.Enter += new EventHandler(Evento_EnterColor);
                    //contr.KeyPress += Txt_PasaConEnter_KeyPress;
                }
                if (contr is Label)
                {
                    if (cTag.Substring(0, 1) == "L")
                    {
                        ((Label)contr).ForeColor = Color.Black; // Color.RoyalBlue;
                        ((Label)contr).Font = new System.Drawing.Font("Arial", 7, FontStyle.Bold);
                    }
                    if (cTag.Substring(0, 1) == "T")
                    {
                        ((Label)contr).ForeColor = Color.Black;
                        ((Label)contr).Font = new System.Drawing.Font("Arial", 7, FontStyle.Bold);
                    }
                }
                if (contr is CheckBox)
                {
                    if (cTag.Substring(0, 1) == "L")
                    {
                        ((CheckBox)contr).ForeColor = Color.DarkGray; // Color.RoyalBlue;
                        ((CheckBox)contr).Font = new System.Drawing.Font("Arial", 7, FontStyle.Bold);
                    }
                }
                if (contr is Button)
                {
                    if (cTag.Substring(0, 1) == "L")
                    {
                        ((Button)contr).ForeColor = Color.Black; //  Color.RoyalBlue;
                        ((Button)contr).Font = new System.Drawing.Font("Verdana", 9, FontStyle.Bold);
                    }
                    if (cTag.Substring(0, 1) == "M")
                    {
                        ((Button)contr).ForeColor = Color.Black; // Color.RoyalBlue;
                        ((Button)contr).Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                    }

                }
                if (contr is GroupBox)
                {
                    if (cTag.Substring(0, 1) == "L")
                    {
                        ((GroupBox)contr).ForeColor = Color.DarkGray; // Color.RoyalBlue;
                        ((GroupBox)contr).Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Bold);
                    }
                }
                //if (contr is ListView)
                //{
                //    ListView lv = (ListView)contr;
                //    if (cTag.Substring(0, 1) == "C") lv.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
                //    if (cTag.Substring(1, 1) == "S") lv.DrawSubItem += new DrawListViewSubItemEventHandler(lista_DrawSubItem);
                //    lv.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                //}
            }
        }
        protected int Dame_Left(System.Windows.Forms.Control ctr)//edu 202208
        {
            return ctr.Left + ctr.Width + 3;
        }
        public static void MuestraPanelConSombra(Panel pn, Label lbl, Control oFoco, bool bLimpia = false)   //edu 202208
        {
            if (bLimpia) Limpia_controles(pn);
            lbl.Width = pn.Width - 2;
            lbl.Height = pn.Height;// -2;
            lbl.Top = pn.Top + 3;
            lbl.Left = pn.Left + 5;
            lbl.BringToFront();
            lbl.Anchor = pn.Anchor;
            //lbl.BackColor = Color.DarkGray;
            lbl.Visible = true;
            pn.BringToFront();
            pn.Visible = true;

            oFoco.Select();
            oFoco.Focus();
        }
        public static void Busca_En_Combo_Value(ComboBox cb, string qB)        //edu 202208
        {
            if (cb.Items.Count == 0) return;
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SelectedIndex = i;
                if (cb.SelectedValue.ToString() == qB)
                {
                    return;
                }
            }
            cb.SelectedIndex = 0;
        }
    };
}




