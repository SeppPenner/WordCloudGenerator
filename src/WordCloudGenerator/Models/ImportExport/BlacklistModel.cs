// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistModel.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The blacklist model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.ImportExport
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The blacklist model.
    /// </summary>
    [Serializable]
    public class BlacklistModel
    {
        /// <summary>
        /// Gets or sets the blacklists.
        /// </summary>
        public List<Blacklist> Blacklists { get; set; } = new();
    }
}