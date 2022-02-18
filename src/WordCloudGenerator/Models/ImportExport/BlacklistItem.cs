// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistItem.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The blacklist item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.ImportExport;

/// <summary>
/// The blacklist item.
/// </summary>
[Serializable]
public class BlacklistItem
{
    /// <summary>
    /// Gets or sets the item.
    /// </summary>
    public string Item { get; set; } = string.Empty;
}
