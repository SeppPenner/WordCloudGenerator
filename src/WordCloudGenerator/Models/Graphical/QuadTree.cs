// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuadTree.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The quad tree class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Graphical;

/// <summary>
/// The quad tree class.
/// </summary>
/// <typeparam name="T">The type parameter.</typeparam>
public class QuadTree<T> where T : LayoutItem
{
    /// <summary>
    /// The root quad tree.
    /// </summary>
    private readonly QuadTreeNode<T> root;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuadTree{T}"/> class.
    /// </summary>
    /// <param name="rectangle">The root rectangle.</param>
    public QuadTree(RectangleF rectangle)
    {
        this.root = new QuadTreeNode<T>(rectangle);
    }

    /// <summary>
    /// A delegate handler for a quad tree action.
    /// </summary>
    /// <param name="obj">The object.</param>
    public delegate void QuadTreeAction(QuadTreeNode<T> obj);

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => this.root.Count;

    /// <summary>
    /// Inserts a new item.
    /// </summary>
    /// <param name="item">The item.s</param>
    public void Insert(T item)
    {
        this.root.Insert(item);
    }

    /// <summary>
    /// Queries the quad tree.
    /// </summary>
    /// <param name="queryArea">The query area.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="T"/>.</returns>
    public IEnumerable<T> Query(RectangleF queryArea)
    {
        return this.root.Query(queryArea);
    }

    /// <summary>
    /// Checks whether the rectangle has content or not.
    /// </summary>
    /// <param name="queryArea">The query area.</param>
    /// <returns><c>true</c> if the rectangle has content, <c>false</c> else.</returns>
    public bool HasContent(RectangleF queryArea)
    {
        var result = this.root.HasContent(queryArea);
        return result;
    }

    /// <summary>
    /// A foreach iterator for the quad tree.
    /// </summary>
    /// <param name="action">The action.</param>
    public void ForEach(QuadTreeAction action)
    {
        this.root.ForEach(action);
    }

    /// <summary>
    /// Gets all items.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="ILayoutItem"/>.</returns>
    public IEnumerable<ILayoutItem> GetAllItems()
    {
        return this.root.SubTreeContents.Select(s => new LayoutItem { Word = s.Word, Rectangle = s.Rectangle }).Cast<ILayoutItem>().ToList();
    }
}
