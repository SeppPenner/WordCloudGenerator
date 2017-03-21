using System.Drawing;
using Models.Enumerations;

namespace Interfaces.Layout
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(SizeF size, LayoutType type);
    }
}