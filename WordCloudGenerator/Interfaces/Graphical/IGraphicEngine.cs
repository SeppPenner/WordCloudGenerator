using System.Drawing;
using Interfaces.Layout;

namespace Interfaces.Graphical
{
    public interface IGraphicEngine
    {
        SizeF Measure(string text, int weight);
        void Draw(ILayoutItem layoutItem);
        void DrawEmphasized(ILayoutItem layoutItem);
    }
}