using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace iComercio.Auxiliar
{
    public static class Xml
    {
        public static void CreateDocument()
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

            //create the root element
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //string.Empty makes cleaner code
            XmlElement element1 = doc.CreateElement(string.Empty, "Mainbody", string.Empty);
            doc.AppendChild(element1);

        }

        public static void CreateElement()
        {
            
        }


    }
}
