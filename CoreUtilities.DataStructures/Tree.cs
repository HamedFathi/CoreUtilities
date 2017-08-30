using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreUtilities
{
    public class Tree<T>
    {
        public ICollection<Tree<T>> Children { get; set; }

        public T Data { get; }

        public bool IsLeaf => !Children.Any();

        public bool IsRoot => Parent == null;

        public int Level => IsRoot ? 0 : Parent.Level + 1;

        public Tree<T> Parent { get; }

        public Tree(T data, Tree<T> parent = null)
        {
            Data = data;
            Parent = parent;

            Children = new LinkedList<Tree<T>>();
        }

        public Tree<T> AddChild(T value)
        {
            var newChild = new Tree<T>(value, this);
            Children.Add(newChild);
            return newChild;
        }

        private Tree<T> CompareWithData(T dataToSearch, Tree<T> currentNode)
                    => dataToSearch.Equals(currentNode.Data) ? currentNode : null;

        private Tree<T> CompareWithNode(Tree<T> nodeToSearch, Tree<T> currentNode)
                    => currentNode.Equals(nodeToSearch) ? currentNode : null;

        public IEnumerable<Tree<T>> GetAncestors()
        {
            var ancestor = Parent;
            while (ancestor != null)
            {
                yield return ancestor;
                ancestor = ancestor.Parent;
            }
        }

        public IEnumerable<Tree<T>> GetDescendants(Tree<T> nodeToSearch = null)
        {
            HashSet<Tree<T>> visitedNodes = new HashSet<Tree<T>>();

            // populate queue
            var queue = new Queue<Tree<T>>();  // Breadth First Search
            queue.Enqueue(this);

            // traversing queue until no more new childs are enqueued
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in node.Children)
                {
                    if (!visitedNodes.Contains(child))
                    {
                        yield return child;  // lazy implementation
                        queue.Enqueue(child);
                    }
                }
            }

        }

        public void RemoveChild(Tree<T> node) => Children.Remove(node);

        public Tree<T> SearchAncestors(Tree<T> node)
                    => GetAncestors().SingleOrDefault(ancestor => ancestor == node);

        public Tree<T> SearchAncestors(T data)
                    => GetAncestors().SingleOrDefault(ancestor => ancestor.Data.Equals(data));

        public Tree<T> SearchInDescendants(Tree<T> nodeToSearch = null)
                    => SearchInDescendants(CompareWithNode, nodeToSearch);

        public Tree<T> SearchInDescendants(T data)
                    => SearchInDescendants(CompareWithData, data);

        private Tree<T> SearchInDescendants<TSearchTarget>(
                    Func<TSearchTarget, Tree<T>, Tree<T>> compareWithSearchTarget,
                    TSearchTarget searchTarget)
        {
            HashSet<Tree<T>> visitedNodes = new HashSet<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                var comparisonResult = compareWithSearchTarget(searchTarget, currentNode);

                if (comparisonResult != null)
                    return comparisonResult;

                foreach (var child in currentNode.Children)
                {
                    if (!visitedNodes.Contains(child))
                    {
                        queue.Enqueue(child);
                        visitedNodes.Add(child);
                    }
                }
            }

            return null;
        }
    }
}
