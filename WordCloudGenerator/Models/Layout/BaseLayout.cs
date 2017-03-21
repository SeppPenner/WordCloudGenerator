using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Interfaces.Graphical;
using Interfaces.Layout;
using Interfaces.WordCloud;
using Models.Graphical;

namespace Models.Layout
{
    public abstract class BaseLayout : ILayout
    {
        protected BaseLayout(SizeF size)
        {
            Surface = new RectangleF(new PointF(0, 0), size);
            QuadTree = new QuadTree<LayoutItem>(Surface);
            Center = new PointF(Surface.X + size.Width / 2, Surface.Y + size.Height / 2);
        }

        public PointF Center { get; set; }
        public RectangleF Surface { get; }

        public QuadTree<LayoutItem> QuadTree { get; }

        public int Arrange(IEnumerable<IWord> words, IGraphicEngine graphicEngine)
        {
            if (words == null)
                throw new ArgumentNullException(nameof(words));

            var enumerable = words as IWord[] ?? words.ToArray();
            if (enumerable.First() == null)
                return 0;

            foreach (var word in enumerable)
            {
                var size = graphicEngine.Measure(word.Text, word.Occurrences);
                RectangleF freeRectangle;
                if (!TryFindFreeRectangle(size, out freeRectangle))
                    break;
                var item = new LayoutItem(freeRectangle, word);
                QuadTree.Insert(item);
                graphicEngine.Draw(item);
            }
            return QuadTree.Count;
        }

        public IEnumerable<LayoutItem> GetWordsInArea(RectangleF area)
        {
            return QuadTree.Query(area);
        }

        public abstract bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle);

        protected bool IsInsideSurface(RectangleF targetRectangle)
        {
            return IsInside(Surface, targetRectangle);
        }

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