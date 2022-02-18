// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuadTreeNode.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The quad tree node class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Graphical;

/// <summary>
/// The quad tree node class.
/// </summary>
/// <typeparam name="T">The type parameter.</typeparam>
public class QuadTreeNode<T> where T : LayoutItem
{
    /// <summary>
    /// The bounds.
    /// </summary>
    private RectangleF bounds;

    /// <summary>
    /// The nodes.
    /// </summary>
    private QuadTreeNode<T>[] nodes = Array.Empty<QuadTreeNode<T>>();

    /// <summary>
    /// Initializes a new instance of the <see cref="QuadTreeNode{T}"/> class.
    /// </summary>
    /// <param name="bounds">The bounds.</param>
    public QuadTreeNode(RectangleF bounds)
    {
        this.bounds = bounds;
    }

    /// <summary>
    /// Gets a value indicating whether the node is empty or not.
    /// </summary>
    public bool IsEmpty => this.bounds.IsEmpty || this.nodes.Length == 0;

    /// <summary>
    /// Gets the bounds.
    /// </summary>
    public RectangleF Bounds => this.bounds;

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count
    {
        get
        {
            var count = this.nodes.Sum(node => node.Count);
            count += this.Contents.Count;
            return count;
        }
    }

    /// <summary>
    /// Gets the sub tree contents.
    /// </summary>
    public IEnumerable<T> SubTreeContents
    {
        get
        {
            IEnumerable<T> results = Array.Empty<T>();
            results = this.nodes.Aggregate(results, (current, node) => current.Concat(node.SubTreeContents));
            results = results.Concat(this.Contents);
            return results;
        }
    }

    /// <summary>
    /// Gets the contents.
    /// </summary>
    public Stack<T> Contents { get; } = new Stack<T>();

    /// <summary>
    /// Checks whether the rectangle has content or not.
    /// </summary>
    /// <param name="queryArea">The query area.</param>
    /// <returns><c>true</c> if the rectangle has content, <c>false</c> else.</returns>
    public bool HasContent(RectangleF queryArea)
    {
        var queryResult = this.Query(queryArea);
        return IsEmptyEnumerable(queryResult);
    }

    /// <summary>
    /// Queries the quad tree node.
    /// </summary>
    /// <param name="queryArea">The query area.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="T"/>.</returns>
    public IEnumerable<T> Query(RectangleF queryArea)
    {
        foreach (var item in this.Contents.Where(item => queryArea.IntersectsWith(item.Rectangle)))
        {
            yield return item;
        }

        foreach (var node in this.nodes)
        {
            if (node.IsEmpty)
            {
                continue;
            }

            if (node.Bounds.Contains(queryArea))
            {
                var subResults = node.Query(queryArea);

                foreach (var subResult in subResults)
                {
                    yield return subResult;
                }

                break;
            }

            if (queryArea.Contains(node.Bounds))
            {
                var subResults = node.SubTreeContents;

                foreach (var subResult in subResults)
                {
                    yield return subResult;
                }

                continue;
            }

            if (!node.Bounds.IntersectsWith(queryArea))
            {
                continue;
            }

            var subResults2 = node.Query(queryArea);

            foreach (var subResult in subResults2)
            {
                yield return subResult;
            }
        }
    }

    /// <summary>
    /// Inserts a new item.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Insert(T item)
    {
        if (!this.bounds.Contains(item.Rectangle))
        {
            Trace.TraceWarning("The feature is out of the bounds of this quad tree node.");
            return;
        }

        if (this.nodes.Length == 0)
        {
            this.CreateSubNodes();
        }

        foreach (var node in this.nodes)
        {
            if (!node.Bounds.Contains(item.Rectangle))
            {
                continue;
            }

            node.Insert(item);
            return;
        }

        this.Contents.Push(item);
    }

    /// <summary>
    /// A foreach iterator for the quad tree nodes.
    /// </summary>
    /// <param name="action">The action.</param>
    public void ForEach(QuadTree<T>.QuadTreeAction action)
    {
        action(this);

        foreach (var node in this.nodes)
        {
            node.ForEach(action);
        }
    }

    /// <summary>
    /// Checks whether the enumerable is empty or not.
    /// </summary>
    /// <param name="queryResult">The query result.</param>
    /// <returns><c>true</c> if the enumerable is empty, <c>false</c> else.</returns>
    private static bool IsEmptyEnumerable(IEnumerable<T> queryResult)
    {
        using var enumerator = queryResult.GetEnumerator();
        return enumerator.MoveNext();
    }

    /// <summary>
    /// Creates the sub nodes.
    /// </summary>
    private void CreateSubNodes()
    {
        if (this.bounds.Height * this.bounds.Width <= 10)
        {
            return;
        }

        var halfWidth = this.bounds.Width / 2f;
        var halfHeight = this.bounds.Height / 2f;

        this.nodes = new QuadTreeNode<T>[4];
        this.nodes[0] = new QuadTreeNode<T>(new RectangleF(this.bounds.Location, new SizeF(halfWidth, halfHeight)));
        this.nodes[1] = new QuadTreeNode<T>(
            new RectangleF(
                new PointF(this.bounds.Left, this.bounds.Top + halfHeight),
                new SizeF(halfWidth, halfHeight)));
        this.nodes[2] = new QuadTreeNode<T>(
            new RectangleF(
                new PointF(this.bounds.Left + halfWidth, this.bounds.Top),
                new SizeF(halfWidth, halfHeight)));
        this.nodes[3] = new QuadTreeNode<T>(
            new RectangleF(
                new PointF(this.bounds.Left + halfWidth, this.bounds.Top + halfHeight),
                new SizeF(halfWidth, halfHeight)));
    }
}
