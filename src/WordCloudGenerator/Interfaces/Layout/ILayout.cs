// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILayout.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The layout interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.Layout;

/// <summary>
/// The layout interface.
/// </summary>
public interface ILayout
{
    /// <summary>
    /// Gets the quad tree.
    /// </summary>
    QuadTree<LayoutItem> QuadTree { get; }

    /// <summary>
    /// Arranges the words on the graphics engine.
    /// </summary>
    /// <param name="words">The words.</param>
    /// <param name="graphicEngine">The graphics engine.</param>
    /// <returns>The word count.</returns>
    int Arrange(IEnumerable<IWord> words, IGraphicEngine graphicEngine);

    /// <summary>
    /// Gets the words in the area.
    /// </summary>
    /// <param name="area">The area.</param>
    /// <returns>The <seealso cref="LayoutItem"/>.</returns>
    IEnumerable<LayoutItem> GetWordsInArea(RectangleF area);
}
