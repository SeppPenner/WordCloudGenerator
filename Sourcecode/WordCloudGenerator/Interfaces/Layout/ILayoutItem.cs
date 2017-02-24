using System.Drawing;
using Interfaces.WordCloud;

namespace Interfaces.Layout
{
    public interface ILayoutItem
    {
        RectangleF Rectangle { get; set; }
        IWord Word { get; set; }

        ILayoutItem Clone();
    }
}