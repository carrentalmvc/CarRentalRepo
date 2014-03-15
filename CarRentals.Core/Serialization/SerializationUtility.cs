using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarRentals.Core
{
    /// <summary>
    /// This is the Xml serialization/Deserialization Utility
    /// please chekout this SO post : http://stackoverflow.com/questions/1564718/using-stringwriter-for-xml-serialization
    /// </summary>
    public class SerializationUtility
    {
        private string xmlString = null;

        public string XmlStringSerialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                using (var tw = new XmlTextWriter(ms, Encoding.UTF8))
                {
                    var ser = new XmlSerializer(obj.GetType());
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    ser.Serialize(tw, obj, ns);
                    xmlString = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return xmlString;
        }

        public void XmlStringSerializeToFile(object obj)
        {
            var localFile = ConfigurationManager.AppSettings["XmlTestFileLocation"].ToString();
            using (var ms = new FileStream(localFile, FileMode.Open, FileAccess.Write))
            {
                using (var tw = new XmlTextWriter(ms, Encoding.UTF8))
                {
                    var ser = new XmlSerializer(obj.GetType());
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    ser.Serialize(tw, obj, ns);
                }
            }
        }

        public T DeSerialize<T>(string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            var settings = new XmlReaderSettings();
            using (var stringReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(stringReader, settings))
                {
                    var ser = new XmlSerializer(typeof(T));
                    return ser.Deserialize(xmlReader) as T;
                }
            }
        }
    }
}