using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace iComercio.Auxiliar
{
    public static class FormScaling
    {
        public static void fitFormToScreen(Form form, int h, int w, float HreduxMin, float WreduxMin,float FontMinRedux)
        {

            float hReduxIndex = (float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h;
            float wReduxIndex = (float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w;
            float fontReduxIndex = (float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w;

            if (hReduxIndex < HreduxMin)
                hReduxIndex = HreduxMin;

            if (wReduxIndex < WreduxMin)
                wReduxIndex = WreduxMin;


            if (fontReduxIndex < FontMinRedux)
                fontReduxIndex = FontMinRedux;

            //scale the form to the current screen resolution
            form.Height = (int)((float)form.Height * (HreduxMin));
            form.Width = (int)((float)form.Width * (wReduxIndex));

            //here font is scaled like width
            form.Font = new Font(form.Font.FontFamily, form.Font.Size * (FontMinRedux));

            foreach (Control item in form.Controls)
            {
                fitControlsToScreen(item, h, w, HreduxMin, WreduxMin, fontReduxIndex);
            }

        }

        static void fitControlsToScreen(Control cntrl, int h, int w, float HreduxMin, float WreduxMin, float FontMinRedux)
        {
            //if (cntrl.Name == "lblValida")
            //{
            //    MessageBox.Show("Stop");
            //}

            float hReduxIndex = (float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h;
            float wReduxIndex = (float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w;
            float fontReduxIndex = (float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w;

            if (hReduxIndex < HreduxMin)
                hReduxIndex = HreduxMin;

            if (wReduxIndex < WreduxMin)
                wReduxIndex = WreduxMin;

            if (fontReduxIndex < FontMinRedux)
                fontReduxIndex = FontMinRedux;

            if (Screen.PrimaryScreen.Bounds.Size.Height != h)
            {

                cntrl.Height = (int)((float)cntrl.Height * (hReduxIndex));
                cntrl.Top = (int)((float)cntrl.Top * (hReduxIndex));

            }
            if (Screen.PrimaryScreen.Bounds.Size.Width != w)
            {

                cntrl.Width = (int)((float)cntrl.Width * (wReduxIndex));
                cntrl.Left = (int)((float)cntrl.Left * (wReduxIndex));

                cntrl.Font = new Font(cntrl.Font.FontFamily, cntrl.Font.Size * (fontReduxIndex));

            }

            foreach (Control item in cntrl.Controls)
            {
                fitControlsToScreen(item, h, w, HreduxMin, WreduxMin, fontReduxIndex);
            }
        }
    


        ////inside form load event
        ////send the width and height of the screen you designed the form for
        //Utility.fitFormToScreen(this, 788, 1280);
        //this.CenterToScreen();

    }
}
