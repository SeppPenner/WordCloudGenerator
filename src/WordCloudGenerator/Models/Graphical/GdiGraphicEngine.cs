// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GdiGraphicEngine.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The GDI graphics engine class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Graphical
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    using WordCloudGenerator.Interfaces.Graphical;
    using WordCloudGenerator.Interfaces.Layout;

    /// <inheritdoc cref="IGraphicEngine"/>
    /// <summary>
    /// The GDI graphics engine class.
    /// </summary>
    /// <seealso cref="IGraphicEngine"/>
    public class GdiGraphicEngine : IGraphicEngine
    {
        /// <summary>
        /// The maximum word weight.
        /// </summary>
        private readonly int maximumWordWeight;

        /// <summary>
        /// The graphics.
        /// </summary>
        private readonly Graphics graphics;

        /// <summary>
        /// The minimum word weight.
        /// </summary>
        private readonly int minimumWordWeight;

        /// <summary>
        /// The last used font.
        /// </summary>
        private Font lastUsedFont;

        /// <summary>
        /// Initializes a new instance of the <see cref="GdiGraphicEngine"/> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="palette">The palette.</param>
        /// <param name="minimumFontSize">The minimum font size.</param>
        /// <param name="maximumFontSize">The maximum font size.</param>
        /// <param name="minimumWordWeight">The minimum word weight.</param>
        /// <param name="maximumWordWeight">The maximum word weight.</param>
        public GdiGraphicEngine(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, Color[] palette, float minimumFontSize, float maximumFontSize, int minimumWordWeight, int maximumWordWeight)
        {
            this.minimumWordWeight = minimumWordWeight;
            this.maximumWordWeight = maximumWordWeight;
            this.graphics = graphics;
            this.FontFamily = fontFamily;
            this.FontStyle = fontStyle;
            this.Palette = palette;
            this.MinimumFontSize = minimumFontSize;
            this.MaximumFontSize = maximumFontSize;
            this.lastUsedFont = new Font(this.FontFamily, maximumFontSize, this.FontStyle);
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        /// <summary>
        /// Gets or sets the font family.
        /// </summary>
        public FontFamily FontFamily { get; set; }

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Gets the palette.
        /// </summary>
        public Color[] Palette { get; }

        /// <summary>
        /// Gets or sets the minimum font size.
        /// </summary>
        public float MinimumFontSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum font size.
        /// </summary>
        public float MaximumFontSize { get; set; }

        /// <inheritdoc cref="IGraphicEngine"/>
        /// <summary>
        /// Measures the text size.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="weight">The weight.</param>
        /// <returns>A new <see cref="SizeF"/>.</returns>
        /// <seealso cref="IGraphicEngine"/>
        public SizeF Measure(string text, int weight)
        {
            var font = this.GetFont(weight);
            return this.graphics.MeasureString(text, font);
        }

        /// <inheritdoc cref="IGraphicEngine"/>
        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="layoutItem">The layout item.</param>
        /// <seealso cref="IGraphicEngine"/>
        public void Draw(ILayoutItem layoutItem)
        {
            var font = this.GetFont(layoutItem.Word.Occurrences);
            var color = this.GetPseudoRandomColorFromPalette(layoutItem);
            var point = new Point((int)layoutItem.Rectangle.X, (int)layoutItem.Rectangle.Y);
            this.graphics.DrawString(layoutItem.Word.Text, font, new SolidBrush(color), point);
        }

        /// <inheritdoc cref="IGraphicEngine"/>
        /// <summary>
        /// Draws the item emphasized.
        /// </summary>
        /// <param name="layoutItem">The layout item.</param>
        /// <seealso cref="IGraphicEngine"/>
        public void DrawEmphasized(ILayoutItem layoutItem)
        {
            var font = this.GetFont(layoutItem.Word.Occurrences);
            var color = this.GetPseudoRandomColorFromPalette(layoutItem);
            var point = new Point((int)layoutItem.Rectangle.X, (int)layoutItem.Rectangle.Y);
            this.graphics.DrawString(layoutItem.Word.Text, font, new SolidBrush(Color.LightGray), point.X, point.Y);
            var offset = (int)(5 * font.Size / this.MaximumFontSize) + 1;
            point.Offset(-offset, -offset);
            this.graphics.DrawString(layoutItem.Word.Text, font, new SolidBrush(color), point.X, point.Y);
        }

        /// <summary>
        /// Gets the font.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <returns>A new <see cref="Font"/>.</returns>
        private Font GetFont(int weight)
        {
            // ReSharper disable ArrangeRedundantParentheses
            var fontSize = (((weight - this.minimumWordWeight) / (float)(this.maximumWordWeight - this.minimumWordWeight)) * (this.MaximumFontSize - this.MinimumFontSize)) + this.MinimumFontSize;

            if (Math.Abs(this.lastUsedFont.Size - fontSize) > 0.0000000000001)
            {
                this.lastUsedFont = new Font(this.FontFamily, fontSize, this.FontStyle);
            }

            return this.lastUsedFont;
        }

        /// <summary>
        /// Gets a pseudo random color from the color palette.
        /// </summary>
        /// <param name="layoutItem">The layout item.</param>
        /// <returns>A new <see cref="Color"/>.</returns>
        private Color GetPseudoRandomColorFromPalette(ILayoutItem layoutItem)
        {
            var color = this.Palette[(layoutItem.Word.Occurrences * layoutItem.Word.Text.Length) % this.Palette.Length];
            return color;
        }
    }
}