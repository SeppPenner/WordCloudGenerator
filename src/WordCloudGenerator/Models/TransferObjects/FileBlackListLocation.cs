// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBlackListLocation.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The file blacklist location class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.TransferObjects;

/// <inheritdoc cref="IFileBlackListLocation"/>
/// <summary>
/// The file blacklist location class.
/// </summary>
/// <seealso cref="IFileBlackListLocation"/>
public class FileBlackListLocation : IFileBlackListLocation
{
    /// <inheritdoc cref="IFileBlackListLocation"/>
    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    /// <seealso cref="IFileBlackListLocation"/>
    public IEnumerable<string> Files { get; set; } = new List<string>();

    /// <inheritdoc cref="IFileBlackListLocation"/>
    /// <summary>
    /// Gets or sets the blacklist.
    /// </summary>
    /// <seealso cref="IFileBlackListLocation"/>
    public IEnumerable<string> Blacklist { get; set; } = new List<string>();

    /// <inheritdoc cref="IFileBlackListLocation"/>
    /// <summary>
    /// Gets or sets the save image location.
    /// </summary>
    /// <seealso cref="IFileBlackListLocation"/>
    public string SaveImageLocation { get; set; } = string.Empty;
}
