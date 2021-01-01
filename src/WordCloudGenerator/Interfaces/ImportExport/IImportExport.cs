// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImportExport.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The import and export interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.ImportExport
{
    using WordCloudGenerator.Models.ImportExport;

    /// <summary>
    /// The import and export interface.
    /// </summary>
    public interface IImportExport
    {
        /// <summary>
        /// Writes the data to an XML file.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="fileName">The file name.</param>
        // ReSharper disable once UnusedMemberInSuper.Global
        void WriteDataToXmlFile<T>(T items, string fileName);

        /// <summary>
        /// Loads the <see cref="BlacklistModel"/> from a file.
        /// </summary>
        /// <param name="filename">The file name.</param>
        /// <returns>A new <see cref="BlacklistModel"/>.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        BlacklistModel LoadConfigFromXmlFile(string filename);
    }
}