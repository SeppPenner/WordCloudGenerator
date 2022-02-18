// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphicEngine.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The graphics engine interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.Graphical;

/// <summary>
/// The graphics engine interface.
/// </summary>
public interface IGraphicEngine
{
    /// <summary>
    /// Measures the text size.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="weight">The weight.</param>
    /// <returns>A new <see cref="SizeF"/>.</returns>
    SizeF Measure(string text, int weight);

    /// <summary>
    /// Draws the item.
    /// </summary>
    /// <param name="layoutItem">The layout item.</param>
    void Draw(ILayoutItem layoutItem);

    /// <summary>
    /// Draws the item emphasized.
    /// </summary>
    /// <param name="layoutItem">The layout item.</param>
    void DrawEmphasized(ILayoutItem layoutItem);
}
