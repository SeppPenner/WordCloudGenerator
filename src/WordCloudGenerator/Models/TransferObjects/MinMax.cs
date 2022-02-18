// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinMax.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The minimum and maximum tuple class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.TransferObjects;

/// <inheritdoc cref="IMinMax"/>
/// <summary>
/// The minimum and maximum tuple class.
/// </summary>
/// <seealso cref="IMinMax"/>
public class MinMax : IMinMax
{
    /// <inheritdoc cref="IMinMax"/>
    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    /// <seealso cref="IMinMax"/>
    public int Min { get; set; }

    /// <inheritdoc cref="IMinMax"/>
    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    /// <seealso cref="IMinMax"/>
    public int Max { get; set; }
}
