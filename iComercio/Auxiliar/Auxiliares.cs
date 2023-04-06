using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace iComercio.Auxiliares
{
    public class Utilidades
    {
        public static string SeleccionarDirectorio()
        {
            string FileName = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = false;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
            }
            return FileName;
        }


        public static void CargarCombo(ComboBox cmb, IList lista, string DisplayMember, string ValueMember, int? SelectedIndex = null)
        {
            cmb.DataSource = null;
            cmb.DataSource = lista;
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
            if (lista.Count > 0)
            {
                if (SelectedIndex != null)
                    cmb.SelectedIndex = SelectedIndex.Value;
                else
                    cmb.SelectedIndex = 0;
            }
        }

        public static void CargarCombo(ComboBox cmb, IList lista, string ValueMember, int? SelectedIndex = null)
        {
            cmb.DataSource = null;
            cmb.DataSource = lista;
            //cmb.ValueMember = ValueMember;
            if (lista.Count > 0)
            {
                if (SelectedIndex != null)
                    cmb.SelectedIndex = SelectedIndex.Value;
                else
                    cmb.SelectedIndex = 0;
            }
        }

        public static void CargarCombo(ComboBox cmb, object elemento, string DisplayMember, string ValueMember, int? SelectedIndex = null)
        {
            cmb.DataSource = elemento;
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
            if (SelectedIndex != null)
                cmb.SelectedIndex = SelectedIndex.Value;
            else
                cmb.SelectedIndex = 0;
        }

        public static void CargarComboGeneric<T>(ComboBox cmb, T elemento, string DisplayMember, string ValueMember, int? SelectedIndex = null) where T : class
        {
            List<T> l = new List<T>();
            l.Add(elemento);
            cmb.DataSource = l;
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
            if (SelectedIndex != null)
                cmb.SelectedIndex = SelectedIndex.Value;
            else
                cmb.SelectedIndex = 0;
        }

       
        public static void SeleccionarItemEnCombo<TEntity>(ComboBox cmb, TEntity elementoABuscar) where TEntity : class
        {
            cmb.SelectedItem = cmb.Items.Contains(elementoABuscar);
            //  cmb.SelectedItem = ((List<TEntity>)cmb.DataSource).(c => cb.Banco.BancoID == c.);            
        }



        public static void PosicionarControl(Control Control, bool Visible, int Left, int Top)
        {
            Control.Visible = Visible;
            Control.Left = Left;
            Control.Top = Top;
        }

        public static void RedimensionarControl(Control Control, bool Visible, int Width, int Height)
        {
            Control.Visible = Visible;
            Control.Width = Width;
            Control.Height = Height;
        }


        public static void HabilitarBotones(bool habilitado, params Button[] lista)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i].Enabled = habilitado;
            }
        }

        public static void MostrarBotones(bool habilitado, params Button[] lista)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i].Visible = habilitado;
            }
        }

        public static void HabilitarControles(bool habilitado, params Control[] lista)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i].Enabled = habilitado;
            }
        }

        public static void MostrarControles(bool habilitado, params Control[] lista)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i].Visible = habilitado;
            }
        }

        public static void HabilitarYMostrarControles(bool habilitado, params Control[] lista)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i].Visible = habilitado;
                lista[i].Enabled = habilitado;
            }
        }

        private void QuitarCarcteresIlegales(string path)
        {
            // string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                path = path.Replace(c.ToString(), "");
            }
        }

        private void QuitarCarcteresIlegalesByRegex(string path)
        {
            //string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            path = r.Replace(path, "");
        }

        private static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static void AutoSeleccionarIndex(ComboBox cmb)
        {
            if (cmb.Items.Count > 0)
            {
                cmb.SelectedIndex = cmb.Items.Count - 1;
                cmb.SelectedIndex = 0;
            }
        }

        public static void ExtremarFechas(ref DateTime desde, ref DateTime hasta)
        {
            desde = desde.Date;
            hasta = hasta.Date.AddDays(1).AddTicks(-1);
        }

        public static void PrimerYUltimoDiaMes(ref DateTime primerDiaMes, ref DateTime UltimoDiaMes)
        {
            primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            UltimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
        }

        //     public static string NumberToWords(double doubleNumber)
        //{
        //    var beforeFloatingPoint = (int) Math.Floor(doubleNumber);
        //    var beforeFloatingPointWord = $"{NumberToWords(beforeFloatingPoint)} dollars";
        //    var afterFloatingPointWord =
        //        $"{SmallNumberToWord((int) ((doubleNumber - beforeFloatingPoint) * 100), "")} cents";
        //    return $"{beforeFloatingPointWord} and {afterFloatingPointWord}";
        //}

        //private static string NumberToWords(int number)
        //{
        //    if (number == 0)
        //        return "zero";

        //    if (number < 0)
        //        return "minus " + NumberToWords(Math.Abs(number));

        //    var words = "";

        //    if (number / 1000000000 > 0)
        //    {
        //        words += NumberToWords(number / 1000000000) + " billion ";
        //        number %= 1000000000;
        //    }

        //    if (number / 1000000 > 0)
        //    {
        //        words += NumberToWords(number / 1000000) + " million ";
        //        number %= 1000000;
        //    }

        //    if (number / 1000 > 0)
        //    {
        //        words += NumberToWords(number / 1000) + " thousand ";
        //        number %= 1000;
        //    }

        //    if (number / 100 > 0)
        //    {
        //        words += NumberToWords(number / 100) + " hundred ";
        //        number %= 100;
        //    }

        //    words = SmallNumberToWord(number, words);

        //    return words;
        //}

        //private static string SmallNumberToWord(int number, string words)
        //{
        //    if (number <= 0) return words;
        //    if (words != "")
        //        words += " ";

        //    var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        //    var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        //    if (number < 20)
        //        words += unitsMap[number];
        //    else
        //    {
        //        words += tensMap[number / 10];
        //        if ((number % 10) > 0)
        //            words += "-" + unitsMap[number % 10];
        //    }
        //    return words;
        //}



        public static bool EstaArchivo(string cArchivo) // edu202104
        {
            if (File.Exists(cArchivo))
            {
                FileInfo file = new FileInfo(cArchivo);
                if (file.Length == 0) return false;
                return true;
            }

            return false;
        }
        public static bool ExisteArchivo(string Ruta)
        {
            if (File.Exists(Ruta))
            {
                return true;
            }
            return false;
        }
        public static bool ExisteDirectorio(string Ruta)
        {
            if (Directory.Exists(Ruta))
            {
                return true;
            }
            return false;
        }

        public static DirectoryInfo ExisteRuta(string Ruta)
        {
            if (ExisteArchivo(Ruta))
            {
                return null;
            }
            else if (ExisteDirectorio(Ruta))
            {
                return null;
            }
            else
            {
                return Directory.CreateDirectory(Ruta);
            }
        }

        public static bool CrearCarpetas(List<string> rutas)
        {
            foreach (string carpeta in rutas)
                ExisteRuta(carpeta);
            return true;
        }
        public static string FullPath(string path)
        {
            return Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
        }
        public static string FileName(string path)
        {
            return Path.GetFileName(path);
        }

        public static string RutaDirRelativa(string path)
        {
            return new FileInfo(path).Directory.FullName;
        }

        public static string RutaDirAbsoluta(string path)
        {
            return Path.GetDirectoryName(path);

            //DirectoryInfo inf = new DirectoryInfo(@"C:\Windows\Microsoft.NET");
            //textBox1.Text = inf.Name;
            //textBox2.Text = inf.Parent.Name;
            //textBox3.Text = inf.FullName;
            //textBox4.Text = inf.Parent.FullName;
        }

        //     public static ExistDirectory()
        //{
        //    foreach (string path in args)
        //    {
        //        if (File.Exists(path))
        //        {
        //            // This path is a file
        //            ProcessFile(path);
        //        }
        //        else if (Directory.Exists(path))
        //        {
        //            // This path is a directory
        //            ProcessDirectory(path);
        //        }
        //        else
        //        {
        //            Console.WriteLine("{0} is not a valid file or directory.", path);
        //        }
        //    }
        //}



        //// Process all files in the directory passed in, recurse on any directories 
        //// that are found, and process the files they contain.
        //        public static void ProcessDirectory(string targetDirectory)
        //    {
        //        // Process the list of files found in the directory.
        //        string[] fileEntries = Directory.GetFiles(targetDirectory);
        //        foreach (string fileName in fileEntries)
        //            ProcessFile(fileName);

        //        // Recurse into subdirectories of this directory.
        //        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        //        foreach (string subdirectory in subdirectoryEntries)
        //            ProcessDirectory(subdirectory);
        //    }

        //    // Insert logic for processing found files here.
        //    public static void ProcessFile(string path)
        //    {
        //        Console.WriteLine("Processed file '{0}'.", path);
        //    }

    }
}
