// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileListFactory.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The file list factory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.FileOperations;

/// <summary>
/// The file list factory interface.
/// </summary>
public interface IFileListFactory
{
    /// <summary>
    /// Gets the file list.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <returns>A new <see cref="List{T}"/> of <see cref="string"/>.</returns>
    IEnumerable<string> GetFileList(IEnumerable<string> files);
}
