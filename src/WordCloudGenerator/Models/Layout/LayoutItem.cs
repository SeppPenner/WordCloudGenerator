// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutItem.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The layout item class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Layout
{
    using System.Drawing;

    using WordCloudGenerator.Interfaces.Layout;
    using WordCloudGenerator.Interfaces.WordCloud;

    /// <inheritdoc cref="ILayoutItem"/>
    /// <summary>
    /// The layout item class.
    /// </summary>
    /// <seealso cref="ILayoutItem"/>
    public class LayoutItem : ILayoutItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutItem"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="word">The word.</param>
        public LayoutItem(RectangleF rectangle, IWord word)
        {
            this.Rectangle = rectangle;
            this.Word = word;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutItem"/> class.
        /// </summary>
        public LayoutItem()
        {
        }

        /// <inheritdoc cref="ILayoutItem"/>
        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        /// <seealso cref="ILayoutItem"/>
        public RectangleF Rectangle { get; set; }

        /// <inheritdoc cref="ILayoutItem"/>
        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <seealso cref="ILayoutItem"/>
        public IWord Word { get; set; }

        /// <inheritdoc cref="ILayoutItem"/>
        /// <summary>
        /// Clones the object.
        /// </summary>
        /// <returns>A new <see cref="ILayoutItem"/>.</returns>
        /// <seealso cref="ILayoutItem"/>
        public ILayoutItem Clone()
        {
            return new LayoutItem(this.Rectangle, this.Word);
        }
    }
}