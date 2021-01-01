// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileReader.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The file reader interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.FileOperations
{
    using System.Collections.Generic;

    using WordCloudGenerator.Interfaces.WordCloud;

    /// <summary>
    /// The file reader interface.
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Gets the words from a file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        IEnumerable<IWord> GetWordsFromFile(string file);

        /// <summary>
        /// Gets the words from a file.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        IEnumerable<IWord> GetWordsFromFiles(IEnumerable<string> files);

        /// <summary>
        /// Gets the words from a file with case ignore.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        IEnumerable<IWord> GetWordsFromFileIgnoreCase(string file);

        /// <summary>
        /// Gets the words from a file with case ignore.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        IEnumerable<IWord> GetWordsFromFilesIgnoreCase(IEnumerable<string> files);
    }
}