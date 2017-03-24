using System.Collections.Generic;
using System.Drawing;
using Interfaces.Layout;
using Models.Layout;

namespace Models.Graphical
{
    public class QuadTree<T> where T : LayoutItem
    {
        public delegate void QuadTreeAction(QuadTreeNode<T> obj);

        private readonly QuadTreeNode<T> _mRoot;

        public QuadTree(RectangleF rectangle)
        {
            _mRoot = new QuadTreeNode<T>(rectangle);
        }

        public int Count => _mRoot.Count;

        public void Insert(T item)
        {
            _mRoot.Insert(item);
        }

        public IEnumerable<T> Query(RectangleF area)
        {
            return _mRoot.Query(area);
        }

        public bool HasContent(RectangleF area)
        {
            var result = _mRoot.HasContent(area);
            return result;
        }

        public void ForEach(QuadTreeAction action)
        {
            _mRoot.ForEach(action);
        }

        public IEnumerable<ILayoutItem> GetAllItems()
        {
            var returnItems = new List<ILayoutItem>();
            foreach (var s in _mRoot.SubTreeContents)
                returnItems.Add(new LayoutItem {Word = s.Word, Rectangle = s.Rectangle});
            return returnItems;
        }
    }
}