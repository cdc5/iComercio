using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace iComercio.Auxiliar
{
    public class IO
    {
        public static void SaveMemoryStreamToFile(string path,MemoryStream ms)
        {
           using (FileStream file = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write)) {
               byte[] bytes = new byte[ms.Length];
               ms.Read(bytes, 0, (int)ms.Length);
               file.Write(bytes, 0, bytes.Length);
               ms.Close();
           }
        }

        public static MemoryStream ReadMemoryStreamFromFile(string path)
        {
            using (MemoryStream ms = new MemoryStream())
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);
                return ms;
            }
        }
    }
}

