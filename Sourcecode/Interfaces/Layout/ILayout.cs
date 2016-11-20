using System.Collections.Generic;
using System.Drawing;
using Interfaces.Graphical;
using Interfaces.WordCloud;
using Models.Graphical;
using Models.Layout;

namespace Interfaces.Layout
{
    public interface ILayout
    {
        QuadTree<LayoutItem> QuadTree { get; }
        int Arrange(IEnumerable<IWord> words, IGraphicEngine graphicEngine);

        IEnumerable<LayoutItem> GetWordsInArea(RectangleF area);
    }
}