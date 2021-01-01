// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileListFactory.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The file list factory class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.FileOperations
{
    using System.Collections.Generic;

    using WordCloudGenerator.Interfaces.FileOperations;

    /// <inheritdoc cref="IFileListFactory"/>
    /// <summary>
    /// The file list factory class.
    /// </summary>
    /// <seealso cref="IFileListFactory"/>
    public class FileListFactory : IFileListFactory
    {
        /// <inheritdoc cref="IFileListFactory"/>
        /// <summary>
        /// Gets the file list.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>A new <see cref="List{T}"/> of <see cref="string"/>.</returns>
        /// <seealso cref="IFileListFactory"/>
        public IEnumerable<string> GetFileList(IEnumerable<string> files)
        {
            var fileList = new List<string>();
            fileList.AddRange(files);
            return fileList;
        }
    }
}