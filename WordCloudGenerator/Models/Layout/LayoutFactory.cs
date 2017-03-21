using System.Drawing;
using Interfaces.Layout;
using Models.Enumerations;

namespace Models.Layout
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(SizeF size, LayoutType type)
        {
            switch (type)
            {
                case LayoutType.Spiral:
                    return new SpiralLayout(size);
                case LayoutType.Typewriter:
                    return new TypewriterLayout(size);
                default:
                    return new SpiralLayout(size);
            }
        }
    }
}