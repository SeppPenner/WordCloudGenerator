using System.Drawing;
using Interfaces.Layout;
using Interfaces.WordCloud;

namespace Models.Layout
{
    public class LayoutItem : ILayoutItem
    {
        public LayoutItem(RectangleF rectangle, IWord word)
        {
            Rectangle = rectangle;
            Word = word;
        }

        public LayoutItem()
        {
        }

        public RectangleF Rectangle { get; set; }
        public IWord Word { get; set; }

        public ILayoutItem Clone()
        {
            return new LayoutItem(Rectangle, Word);
        }
    }
}