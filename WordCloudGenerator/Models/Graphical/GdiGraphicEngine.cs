using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Interfaces.Graphical;
using Interfaces.Layout;

namespace Models.Graphical
{
    public class GdiGraphicEngine : IGraphicEngine
    {
        private readonly int _maxWordWeight;
        private readonly Graphics _mGraphics;

        private readonly int _minWordWeight;
        private Font _lastUsedFont;

        public GdiGraphicEngine(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, Color[] palette,
            float minFontSize, float maxFontSize, int minWordWeight, int maxWordWeight)
        {
            _minWordWeight = minWordWeight;
            _maxWordWeight = maxWordWeight;
            _mGraphics = graphics;
            FontFamily = fontFamily;
            FontStyle = fontStyle;
            Palette = palette;
            MinFontSize = minFontSize;
            MaxFontSize = maxFontSize;
            _lastUsedFont = new Font(FontFamily, maxFontSize, FontStyle);
            _mGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public FontFamily FontFamily { get; set; }
        public FontStyle FontStyle { get; set; }
        public Color[] Palette { get; }
        public float MinFontSize { get; set; }
        public float MaxFontSize { get; set; }

        public SizeF Measure(string text, int weight)
        {
            var font = GetFont(weight);
            return _mGraphics.MeasureString(text, font);
        }

        public void Draw(ILayoutItem layoutItem)
        {
            var font = GetFont(layoutItem.Word.Occurrences);
            var color = GetPresudoRandomColorFromPalette(layoutItem);
            var point = new Point((int) layoutItem.Rectangle.X, (int) layoutItem.Rectangle.Y);
            _mGraphics.DrawString(layoutItem.Word.Text, font, new SolidBrush(color), point);
        }

        public void DrawEmphasized(ILayoutItem layoutItem)
        {
            var font = GetFont(layoutItem.Word.Occurrences);
            var color = GetPresudoRandomColorFromPalette(layoutItem);
            var point = new Point((int) layoutItem.Rectangle.X, (int) layoutItem.Rectangle.Y);
            _mGraphics.DrawString(layoutItem.Word.Text, font, new SolidBrush(Color.LightGray), point.X, point.Y);
            var offset = (int) (5 * font.Size / MaxFontSize) + 1;
            point.Offset(-offset, -offset);
            _mGraphics.DrawString(layoutItem.Word.Text, font, new SolidBrush(color), point.X, point.Y);
        }

        private Font GetFont(int weight)
        {
            var fontSize = (float) (weight - _minWordWeight) / (_maxWordWeight - _minWordWeight) *
                           (MaxFontSize - MinFontSize) + MinFontSize;
            if (Math.Abs(_lastUsedFont.Size - fontSize) > 0.0000000000001)
                _lastUsedFont = new Font(FontFamily, fontSize, FontStyle);
            return _lastUsedFont;
        }

        private Color GetPresudoRandomColorFromPalette(ILayoutItem layoutItem)
        {
            var color = Palette[layoutItem.Word.Occurrences * layoutItem.Word.Text.Length % Palette.Length];
            return color;
        }
    }
}