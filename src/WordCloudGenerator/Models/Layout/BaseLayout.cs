// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseLayout.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The base layout class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Layout
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using WordCloudGenerator.Interfaces.Graphical;
    using WordCloudGenerator.Interfaces.Layout;
    using WordCloudGenerator.Interfaces.WordCloud;
    using WordCloudGenerator.Models.Graphical;

    /// <inheritdoc cref="ILayout"/>
    /// <summary>
    /// The base layout class.
    /// </summary>
    /// <seealso cref="ILayout"/>
    public abstract class BaseLayout : ILayout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLayout"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        protected BaseLayout(SizeF size)
        {
            this.Surface = new RectangleF(new PointF(0, 0), size);
            this.QuadTree = new QuadTree<LayoutItem>(this.Surface);
            // ReSharper disable ArrangeRedundantParentheses
            this.Center = new PointF(this.Surface.X + (size.Width / 2), this.Surface.Y + (size.Height / 2));
        }

        /// <summary>
        /// Gets or sets the center.
        /// </summary>
        public PointF Center { get; set; }

        /// <summary>
        /// Gets the surface.
        /// </summary>
        public RectangleF Surface { get; }

        /// <inheritdoc cref="ILayout"/>
        /// <summary>
        /// Gets the quad tree.
        /// </summary>
        /// <seealso cref="ILayout"/>
        public QuadTree<LayoutItem> QuadTree { get; }

        /// <inheritdoc cref="ILayout"/>
        /// <summary>
        /// Arranges the words on the graphics engine.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="graphicEngine">The graphics engine.</param>
        /// <returns>The word count.</returns>
        /// <seealso cref="ILayout"/>
        public int Arrange(IEnumerable<IWord> words, IGraphicEngine graphicEngine)
        {
            if (words == null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            var enumerable = words as IWord[] ?? words.ToArray();

            if (enumerable.First() == null)
            {
                return 0;
            }

            foreach (var word in enumerable)
            {
                var size = graphicEngine.Measure(word.Text, word.Occurrences);

                if (!this.TryFindFreeRectangle(size, out var freeRectangle))
                {
                    break;
                }

                var item = new LayoutItem(freeRectangle, word);
                this.QuadTree.Insert(item);
                graphicEngine.Draw(item);
            }

            return this.QuadTree.Count;
        }

        /// <summary>
        /// Gets the words in the area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The <seealso cref="LayoutItem"/>.</returns>
        public IEnumerable<LayoutItem> GetWordsInArea(RectangleF area)
        {
            return this.QuadTree.Query(area);
        }

        /// <summary>
        /// Tries to find a free rectangle.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="foundRectangle">The found rectangle.</param>
        /// <returns>A value indicating whether the rectangle is free or not.</returns>
        public abstract bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle);

        /// <summary>
        /// Checks whether the rectangle is inside the surface rectangle or not.
        /// </summary>
        /// <param name="targetRectangle">The target rectangle.</param>
        /// <returns><c>true</c> if the rectangle is inside the surface rectangle, <c>false</c> else.</returns>
        protected bool IsInsideSurface(RectangleF targetRectangle)
        {
            return IsInside(this.Surface, targetRectangle);
        }

        /// <summary>
        /// Checks whether the rectangle is inside the other rectangle or not.
        /// </summary>
        /// <param name="outer">The outer rectangle.</param>
        /// <param name="inner">The inner rectangle.</param>
        /// <returns><c>true</c> if the rectangle is inside the other rectangle, <c>false</c> else.</returns>
        private static bool IsInside(RectangleF outer, RectangleF inner)
        {
            return
                inner.X >= outer.X &&
                inner.Y >= outer.Y &&
                inner.Bottom <= outer.Bottom &&
                inner.Right <= outer.Right;
        }
    }
}