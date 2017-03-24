using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Models.Layout;

namespace Models.Graphical
{
    public class QuadTreeNode<T> where T : LayoutItem
    {
        private RectangleF _mBounds;

        private QuadTreeNode<T>[] _mNodes = new QuadTreeNode<T>[0];

        public QuadTreeNode(RectangleF bounds)
        {
            _mBounds = bounds;
        }

        public bool IsEmpty => _mBounds.IsEmpty || _mNodes.Length == 0;

        public RectangleF Bounds => _mBounds;

        public int Count
        {
            get
            {
                var count = 0;

                foreach (var node in _mNodes)
                    count += node.Count;

                count += Contents.Count;

                return count;
            }
        }

        public IEnumerable<T> SubTreeContents
        {
            get
            {
                IEnumerable<T> results = new T[0];

                foreach (var node in _mNodes)
                    results = results.Concat(node.SubTreeContents);

                results = results.Concat(Contents);
                return results;
            }
        }

        public Stack<T> Contents { get; } = new Stack<T>();

        public bool HasContent(RectangleF queryArea)
        {
            var queryResult = Query(queryArea);
            return IsEmptyEnumerable(queryResult);
        }

        private static bool IsEmptyEnumerable(IEnumerable<T> queryResult)
        {
            using (var enumerator = queryResult.GetEnumerator())
            {
                return enumerator.MoveNext();
            }
        }

        public IEnumerable<T> Query(RectangleF queryArea)
        {
            foreach (var item in Contents)
                if (queryArea.IntersectsWith(item.Rectangle))
                    yield return item;

            foreach (var node in _mNodes)
            {
                if (node.IsEmpty)
                    continue;


                if (node.Bounds.Contains(queryArea))
                {
                    var subResults = node.Query(queryArea);
                    foreach (var subResult in subResults)
                        yield return subResult;
                    break;
                }

                if (queryArea.Contains(node.Bounds))
                {
                    var subResults = node.SubTreeContents;
                    foreach (var subResult in subResults)
                        yield return subResult;
                    continue;
                }

                if (!node.Bounds.IntersectsWith(queryArea)) continue;
                {
                    var subResults = node.Query(queryArea);
                    foreach (var subResult in subResults)
                        yield return subResult;
                }
            }
        }

        public void Insert(T item)
        {
            if (!_mBounds.Contains(item.Rectangle))
            {
                Trace.TraceWarning("feature is out of the bounds of this quadtree node");
                return;
            }

            if (_mNodes.Length == 0)
                CreateSubNodes();

            foreach (var node in _mNodes)
            {
                if (!node.Bounds.Contains(item.Rectangle)) continue;
                node.Insert(item);
                return;
            }

            Contents.Push(item);
        }

        public void ForEach(QuadTree<T>.QuadTreeAction action)
        {
            action(this);

            foreach (var node in _mNodes)
                node.ForEach(action);
        }

        private void CreateSubNodes()
        {
            if (_mBounds.Height * _mBounds.Width <= 10)
                return;

            var halfWidth = _mBounds.Width / 2f;
            var halfHeight = _mBounds.Height / 2f;

            _mNodes = new QuadTreeNode<T>[4];
            _mNodes[0] = new QuadTreeNode<T>(new RectangleF(_mBounds.Location, new SizeF(halfWidth, halfHeight)));
            _mNodes[1] =
                new QuadTreeNode<T>(new RectangleF(new PointF(_mBounds.Left, _mBounds.Top + halfHeight),
                    new SizeF(halfWidth, halfHeight)));
            _mNodes[2] =
                new QuadTreeNode<T>(new RectangleF(new PointF(_mBounds.Left + halfWidth, _mBounds.Top),
                    new SizeF(halfWidth, halfHeight)));
            _mNodes[3] =
                new QuadTreeNode<T>(new RectangleF(new PointF(_mBounds.Left + halfWidth, _mBounds.Top + halfHeight),
                    new SizeF(halfWidth, halfHeight)));
        }
    }
}