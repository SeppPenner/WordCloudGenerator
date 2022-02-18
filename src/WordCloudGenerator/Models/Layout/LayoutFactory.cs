// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutFactory.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The layout factory class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Layout;

/// <inheritdoc cref="ILayoutFactory"/>
/// <summary>
/// The layout factory class.
/// </summary>
/// <seealso cref="ILayoutFactory"/>
public class LayoutFactory : ILayoutFactory
{
    /// <inheritdoc cref="ILayoutFactory"/>
    /// <summary>
    /// Creates a layout.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="type">The type.</param>
    /// <returns>A new <see cref="ILayout"/>.</returns>
    /// <seealso cref="ILayoutFactory"/>
    public ILayout CreateLayout(SizeF size, LayoutType type)
    {
        return type switch
        {
            LayoutType.Spiral => new SpiralLayout(size),
            LayoutType.Typewriter => new TypewriterLayout(size),
            _ => new SpiralLayout(size)
        };
    }
}
