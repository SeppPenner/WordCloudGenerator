// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinMax.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The minimum and maximum tuple interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.TransferObjects
{
    /// <summary>
    /// The minimum and maximum tuple interface.
    /// </summary>
    public interface IMinMax
    {
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        int Min { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        int Max { get; set; }
    }
}