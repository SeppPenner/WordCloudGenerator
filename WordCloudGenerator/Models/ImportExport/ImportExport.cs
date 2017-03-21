using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Interfaces.ImportExport;

namespace Models.ImportExport
{
    public class ImportExport : IImportExport
    {
        public void WriteDataToXmlFile<T>(T items, string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var textWriter = new XmlTextWriter(fileName, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 4
            };
            xmlSerializer.Serialize(textWriter, items);
            textWriter.Close();
        }

        public BlacklistModel LoadConfigFromXmlFile(string filename)
        {
            var xDocument = XDocument.Load(filename);
            return CreateObjectsFromString<BlacklistModel>(xDocument);
        }

        private T CreateObjectsFromString<T>(XDocument xDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T) xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
        }
    }
}