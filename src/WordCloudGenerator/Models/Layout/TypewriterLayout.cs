// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypewriterLayout.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The type writer layout class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Layout
{
    using System.Drawing;

    /// <inheritdoc cref="BaseLayout"/>
    /// <summary>
    /// The type writer layout class.
    /// </summary>
    /// <seealso cref="BaseLayout"/>
    public class TypewriterLayout : BaseLayout
    {
        /// <summary>
        /// The caret.
        /// </summary>
        private PointF caret;

        /// <summary>
        /// The line height.
        /// </summary>
        private float lineHeight;

        /// <inheritdoc cref="BaseLayout"/>
        /// <summary>
        /// Initializes a new instance of the <see cref="TypewriterLayout"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <seealso cref="BaseLayout"/>
        public TypewriterLayout(SizeF size) : base(size)
        {
            this.caret = new PointF(size.Width, 0);
        }

        /// <inheritdoc cref="BaseLayout"/>
        /// <summary>
        /// Tries to find a free rectangle.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="foundRectangle">The found rectangle.</param>
        /// <returns>A value indicating whether the rectangle is free or not.</returns>
        /// <seealso cref="BaseLayout"/>
        public override bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle)
        {
            foundRectangle = new RectangleF(this.caret, size);

            if (this.HorizontalOverflow(foundRectangle))
            {
                foundRectangle = this.LineFeed(foundRectangle);
                if (!this.IsInsideSurface(foundRectangle))
                {
                    return false;
                }
            }

            this.caret = new PointF(foundRectangle.Right, foundRectangle.Y);
            return true;
        }

        /// <summary>
        /// Gets the line feed.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>A new <see cref="RectangleF"/>.</returns>
        private RectangleF LineFeed(RectangleF rectangle)
        {
            var result = new RectangleF(new PointF(0, this.caret.Y + this.lineHeight), rectangle.Size);
            this.lineHeight = rectangle.Height;
            return result;
        }

        /// <summary>
        /// Checks whether there is horizontal overflow or not.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns><c>true</c> if there is horizontal overflow, <c>false</c> else.</returns>
        private bool HorizontalOverflow(RectangleF rectangle)
        {
            return rectangle.Right > this.Surface.Right;
        }
    }
}