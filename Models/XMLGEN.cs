using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace SSCASPEL.Models
{

    public class XMLGEN
    {
        public XmlDocument xmlDoc;
        public XmlNode rootNode;

        public XMLGEN()
        {
            xmlDoc = new XmlDocument();
            XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(docNode);
        }

        public void creaEnc()
        {

            rootNode = xmlDoc.CreateElement("dte:GTDocumento", "ds");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "42";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "John Doe";
            rootNode.AppendChild(userNode);

            userNode = xmlDoc.CreateElement("user");
            attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "39";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "Jane Doe";
            rootNode.AppendChild(userNode);

        }

        public XmlDocument getXml() {

            return xmlDoc;
        }

        public string AsString()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {
                    xmlDoc.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }
    }
}
