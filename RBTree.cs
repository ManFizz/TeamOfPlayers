using System;
using System.Collections.Generic;

namespace TeamOfPlayers
{
    public class RbTree<TData, TKey>
    {
        public enum Color
        {
            Red = 0,
            Black
        }

        public class Node
        {
            public TData Data;
            public TKey Key;
            public Color Color;
            public Node Left, Right, Parent;

            public Node(TData player, TKey key) { Data = player; Key = key;}
            public Node(Color color) { Color = color; } 
            public Node(Node parent, Color color) { Parent = parent; Color = color; }
            
            public static implicit operator bool(Node x) { return x != null; }

            public static implicit operator string(Node x) { return x.Data.ToString(); }
        }

        public Node Root;

        private static Node _sentinel;

        public RbTree()
        {
            Root = new Node(Color.Black);
            _sentinel = new Node(Root, Color.Black);
            Root.Parent = _sentinel;
            Root.Left = Root.Right = _sentinel;
        }

        ~RbTree()
        {
            if (Root == _sentinel)
                return;
            var stack = new Stack<Node>();
            stack.Push(Root);
            do
            {
                var node = stack.Pop();
                if(node == _sentinel)
                    continue;

                stack.Push(node.Left);
                stack.Push(node.Right);
            }
            while (stack.Count != 0 && stack.Peek() != null) ; 
            _sentinel = null;
        }

        #region Add

        public void Add(TData item, TKey key)
        {
            var insertNode = new Node(item, key);
            if (Root.Data == null)
            {
                Root = insertNode;
                Root.Parent = _sentinel;
                Root.Left = _sentinel;
                Root.Right = _sentinel;
                Root.Color = Color.Black;
                return;
            }

            var parentX = _sentinel;
            var x = Root;

            while (x != _sentinel)
            {
                parentX = x;
                x = Program.CompareKeys(insertNode.Key, x.Key) < 0 ? x.Left : x.Right;
            }
            insertNode.Parent = parentX;
            if (parentX == _sentinel)
                Root = insertNode;
            else if(Program.CompareKeys(insertNode.Key, parentX.Key) < 0)  
                parentX.Left = insertNode;
            else
                parentX.Right = insertNode;

            insertNode.Left = _sentinel;
            insertNode.Right = _sentinel;

            insertNode.Color = Color.Red;
            InsertFixUp(insertNode);
        }

        private void InsertFixUp(Node z)
        {
            while (z != Root && z.Parent.Color == Color.Red)
            {
                Node y;
                if (z.Parent == z.Parent.Parent.Left)
                {
                    y = z.Parent.Parent.Right;
                    if (y != null && y.Color == Color.Red)
                    {
                        z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    y = z.Parent.Parent.Left;
                    if (y != null && y.Color == Color.Red)
                    {
                        z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            RightRotate(z);
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }
            Root.Color = Color.Black;
        }

        #endregion

        #region Rotates

        private void LeftRotate(Node x)
        {
            var y = x.Right;
            x.Right = y.Left;

            if (y.Left != _sentinel)
                y.Left.Parent = x;

            y.Parent = x.Parent;

            if (x.Parent == _sentinel)
                Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;

        }

        private void RightRotate(Node y)
        {
            var x = y.Left;
            y.Left = x.Right;
            if (x.Right != _sentinel)
                x.Right.Parent = y;

            x.Parent = y.Parent;

            if (y.Parent == _sentinel)
                Root = x;
            else if (y == y.Parent.Right)
                y.Parent.Right = x;
            else
                y.Parent.Left = x;

            x.Right = y;
            y.Parent = x;
        }
        #endregion

        #region Remove

        public bool Remove(TData data, TKey key)
        {
            var listNode = FindList(key);
            foreach (var node in listNode)
            {
                if (node == _sentinel)
                    continue;

                if (node.Data.GetHashCode() == data.GetHashCode())
                {
                    Remove(node);
                    return true;
                }
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            var z = Find(key);
            if (z == _sentinel)
                return false;

            Remove(z);
            return true;
        }

        private static Node Minimum(Node x)
        {
            var y = _sentinel;
            while (x != _sentinel)
            {
                y = x;
                x = x.Left;
            }
            return y;
        }

        private void Transplant(Node u, Node v)
        {
            if (u.Parent == _sentinel)
                Root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else
                u.Parent.Right = v;
            if (v)
                v.Parent = u.Parent;
        }

        public void Remove(Node z)
        {
            var y = z;
            Node x;
            var yOriginalColor = y.Color;
            if (z.Left == _sentinel)
            {
                x = z.Right;
                Transplant(z, z.Right);
            }
            else if (z.Right == _sentinel)
            {
                x = z.Left;
                Transplant(z, z.Left);
            }
            else
            {
                y = Minimum(z.Right); //Без проверок возможна бесконечная рекурсия
                yOriginalColor = y.Color;
                x = y.Right;
                if (y.Parent == z)
                    x.Parent = y;
                else
                {
                    Transplant(y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }
                Transplant(z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
                y.Color = z.Color;
            }

            if (yOriginalColor == Color.Black)
                DeleteFixUp(x);
        }

        private void DeleteFixUp(Node x)
        {
            while (x != Root && x.Color == Color.Black)
            {
                if (x == x.Parent.Left)
                {
                    var y = x.Parent.Right;
                    if (y.Color == Color.Red)
                    {
                        y.Color = Color.Black;
                        x.Parent.Color = Color.Red;
                        LeftRotate(x.Parent);
                        y = x.Parent.Right;
                    }

                    if (y.Left.Color == Color.Black && y.Right.Color == Color.Black)
                    {
                        y.Color = Color.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (y.Right.Color == Color.Black)
                        {
                            y.Left.Color = Color.Black;
                            y.Color = Color.Red;
                            RightRotate(y);
                            y = x.Parent.Right;
                        }
                        y.Color = x.Parent.Color;
                        x.Parent.Color = Color.Black;
                        y.Right.Color = Color.Black;
                        LeftRotate(x.Parent);
                        x = Root;
                    }
                }
                else
                {
                    var y = x.Parent.Left;
                    if (y.Color == Color.Red)
                    {
                        y.Color = Color.Black;
                        x.Parent.Color = Color.Red;
                        RightRotate(x.Parent);
                        y = x.Parent.Left;
                    }

                    if (y.Right.Color == Color.Black && y.Left.Color == Color.Black)
                    {
                        y.Color = Color.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (y.Left.Color == Color.Black)
                        {
                            y.Right.Color = Color.Black;
                            y.Color = Color.Red;
                            LeftRotate(y);
                            y = x.Parent.Left;
                        }
                        y.Color = x.Parent.Color;
                        x.Parent.Color = Color.Black;
                        y.Left.Color = Color.Black;
                        RightRotate(x.Parent);
                        x = Root;
                    }
                }
            }
            x.Color = Color.Black;
        }

        #endregion

        //Это касcстыль BUG НЕ ТРОГАТЬ
        public List<TData> FindAge(int age, Func<TKey, int> f)
        {
            if(!(Root.Key is DateTime))
                throw new Exception("Кастыль");

            var list = new List<TData>();
            var stack = new Stack<Node>();
            stack.Push(Root);
            while (stack.Count != 0)
            {
                var temp = stack.Pop();
                if(temp == _sentinel)
                    continue;

                var tempAge = f(temp.Key);
                if (tempAge < age)
                    stack.Push(temp.Left);
                else if (tempAge > age)
                    stack.Push(temp.Right);
                else if (tempAge == age)
                {
                    list.Add(temp.Data);
                    stack.Push(temp.Left);
                    stack.Push(temp.Right);
                }
            }

            return list;
        }

        public List<Node> FindList(TKey key)
        {
            var list = new List<Node>();
            var stack = new Stack<Node>();
            stack.Push(Root);
            while (stack.Count != 0)
            {
                var temp = stack.Pop();
                if (temp == _sentinel)
                    continue;

                if (Program.CompareKeys(key, temp.Key) < 0)
                    stack.Push(temp.Left);
                else if (Program.CompareKeys(key, temp.Key) > 0)
                    stack.Push(temp.Right);
                else
                {
                    list.Add(temp);
                    stack.Push(temp.Left);
                    stack.Push(temp.Right);
                }
            }

            return list;
        }

        public Node Find(TKey key)
        {
            var temp = Root;
            while (temp != _sentinel)
            {
                if (Program.CompareKeys(key, temp.Key) < 0)
                    temp = temp.Left;

                if (Program.CompareKeys(key, temp.Key) > 0)
                    temp = temp.Right;

                if (Program.CompareKeys(key, temp.Key) == 0)
                    return temp;
            }

            return _sentinel;
        }

        //public List<TData> GetList()
        //{
        //    var list = new List<TData>();
        //    var stack = new Stack<Node>();
        //    stack.Push(Root);
        //    while (stack.Count != 0)
        //    {
        //        var node = stack.Pop();
        //        if(node == _sentinel)
        //            continue;

        //        if(node.Right != null) stack.Push(node.Right);
        //        if (node.Left != null) stack.Push(node.Left);
        //        list.Add(node.Data);
        //    }

        //    return list;
        //}
    }
}
