using System.Drawing;
using Interfaces.WordCloud;
using Models.Layout;

namespace Interfaces.Layout
{
    public interface ILayoutItem
    {
        RectangleF Rectangle { get; set; }
        IWord Word { get; set; }

        LayoutItem Clone();
    }
}