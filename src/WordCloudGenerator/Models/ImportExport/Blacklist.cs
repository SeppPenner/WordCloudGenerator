// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Blacklist.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The blacklist.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.ImportExport
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The blacklist.
    /// </summary>
    [Serializable]
    public class Blacklist
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the filter list.
        /// </summary>
        public List<BlacklistItem> FilterList { get; set; } = new();
    }
}