// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILayoutFactory.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The layout factory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.Layout;

/// <summary>
/// The layout factory interface.
/// </summary>
public interface ILayoutFactory
{
    /// <summary>
    /// Creates a layout.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="type">The type.</param>
    /// <returns>A new <see cref="ILayout"/>.</returns>
    ILayout CreateLayout(SizeF size, LayoutType type);
}
