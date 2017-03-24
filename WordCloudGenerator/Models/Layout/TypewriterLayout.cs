using System.Drawing;

namespace Models.Layout
{
    public class TypewriterLayout : BaseLayout
    {
        private PointF _carret;
        private float _lineHeight;

        public TypewriterLayout(SizeF size) : base(size)
        {
            _carret = new PointF(size.Width, 0);
        }

        public override bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle)
        {
            foundRectangle = new RectangleF(_carret, size);
            if (HorizontalOverflow(foundRectangle))
            {
                foundRectangle = LineFeed(foundRectangle);
                if (!IsInsideSurface(foundRectangle))
                    return false;
            }
            _carret = new PointF(foundRectangle.Right, foundRectangle.Y);

            return true;
        }

        private RectangleF LineFeed(RectangleF rectangle)
        {
            var result = new RectangleF(new PointF(0, _carret.Y + _lineHeight), rectangle.Size);
            _lineHeight = rectangle.Height;
            return result;
        }

        private bool HorizontalOverflow(RectangleF rectangle)
        {
            return rectangle.Right > Surface.Right;
        }
    }
}