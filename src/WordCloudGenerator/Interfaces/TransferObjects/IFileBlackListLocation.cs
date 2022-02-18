// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileBlackListLocation.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The file blacklist location interface..
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.TransferObjects;

/// <summary>
/// The file blacklist location interface..
/// </summary>
public interface IFileBlackListLocation
{
    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    IEnumerable<string> Files { get; set; }

    /// <summary>
    /// Gets or sets the blacklist.
    /// </summary>
    IEnumerable<string> Blacklist { get; set; }

    /// <summary>
    /// Gets or sets the save image location.
    /// </summary>
    string SaveImageLocation { get; set; }
}
