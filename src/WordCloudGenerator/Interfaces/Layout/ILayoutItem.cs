// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILayoutItem.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The layout item interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.Layout;

/// <summary>
/// The layout item interface.
/// </summary>
public interface ILayoutItem
{
    /// <summary>
    /// Gets or sets the rectangle.
    /// </summary>
    RectangleF Rectangle { get; set; }

    /// <summary>
    /// Gets or sets the word.
    /// </summary>
    IWord Word { get; set; }

    /// <summary>
    /// Clones the object.
    /// </summary>
    ILayoutItem Clone();
}
