// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImportExport.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The import and export class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.ImportExport
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using WordCloudGenerator.Interfaces.ImportExport;

    /// <inheritdoc cref="IImportExport"/>
    /// <summary>
    /// The import and export class.
    /// </summary>
    /// <seealso cref="IImportExport"/>
    public class ImportExport : IImportExport
    {
        /// <inheritdoc cref="IImportExport"/>
        /// <summary>
        /// Writes the data to an XML file.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="fileName">The file name.</param>
        /// <seealso cref="IImportExport"/>
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

        /// <inheritdoc cref="IImportExport"/>
        /// <summary>
        /// Loads the <see cref="BlacklistModel"/> from a file.
        /// </summary>
        /// <param name="filename">The file name.</param>
        /// <returns>A new <see cref="BlacklistModel"/>.</returns>
        /// <seealso cref="IImportExport"/>
        public BlacklistModel LoadConfigFromXmlFile(string filename)
        {
            var xDocument = XDocument.Load(filename);
            return CreateObjectsFromString<BlacklistModel>(xDocument);
        }

        /// <summary>
        /// Creates a object from the <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="xDocument">The X document.</param>
        /// <returns>A new object of type <see cref="T"/>.</returns>
        private static T CreateObjectsFromString<T>(XDocument xDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
        }
    }
}