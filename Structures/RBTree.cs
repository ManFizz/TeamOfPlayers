using System;
using System.Collections.Generic;

namespace TeamOfPlayers.Structures
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
            public readonly TKey Key;
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
            
            var list = new List<Node> {Root};
            do
            {
                var node = list[list.Count - 1];
                    list.RemoveAt(list.Count-1);
                if(node == _sentinel || node == null)
                    continue;
                
                list.Add(node.Left);
                list.Add(node.Right);
            }
            while (list.Count != 0) ; 
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
            var debugCounter = 0;
            while (z != Root && z.Parent.Color == Color.Red)
            {
                debugCounter++;
                Node y;
                if (z.Parent == z.Parent.Parent.Left)
                {
                    y = z.Parent.Parent.Right;
                    if (y is {Color: Color.Red})
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
                            debugCounter++;
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    y = z.Parent.Parent.Left;
                    if (y is {Color: Color.Red})
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
                            debugCounter++;
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }
            Root.Color = Color.Black;
            Program.DebugForm.WriteLine("Вставка в дерево. -Поворотов", debugCounter);
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
            var debugCounter = 0;
            var listNode = FindList(key);
            foreach (var node in listNode)
            {
                debugCounter++;
                if (node == _sentinel)
                    continue;
                debugCounter++;
                if (node.Data.GetHashCode() == data.GetHashCode())
                {
                    Remove(node);
                    Program.DebugForm.WriteLine("Удаление из дерева. -Сравнений", debugCounter);
                    return true;
                }
            }

            Program.DebugForm.WriteLine("Удаление из дерева. -Сравнений", debugCounter);
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
            var debugCounter = 0;
            while (x != _sentinel)
            {
                y = x;
                x = x.Left;
                debugCounter++;
            }
            Program.DebugForm.WriteLine("Взятие минимума в дереве. -Сравнений", debugCounter);
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

        private void Remove(Node z)
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
                y = Minimum(z.Right);
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
            var debugCounter = 0;
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
                        debugCounter++;
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
                            debugCounter++;
                            y = x.Parent.Right;
                        }
                        y.Color = x.Parent.Color;
                        x.Parent.Color = Color.Black;
                        y.Right.Color = Color.Black;
                        LeftRotate(x.Parent);
                        debugCounter++;
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
                        debugCounter++;
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
                            debugCounter++;
                            y = x.Parent.Left;
                        }
                        y.Color = x.Parent.Color;
                        x.Parent.Color = Color.Black;
                        y.Left.Color = Color.Black;
                        RightRotate(x.Parent);
                        debugCounter++;
                        x = Root;
                    }
                }
            }
            x.Color = Color.Black;
            Program.DebugForm.WriteLine("Удаление из дерева. -Поворотов", debugCounter);
        }

        #endregion

        public List<TData> FindAge(int age, Func<TKey, int> f)
        {
            if(Root.Key is not DateTime)
                throw new Exception("Функция не предназначена для работы с этим типом ключа");

            var outList = new List<TData>();
            var nodeList = new List<Node> {Root};
            var debugCounter = 0;
            while (nodeList.Count != 0)
            {
                var temp = nodeList[nodeList.Count - 1];
                nodeList.Remove(temp);
                debugCounter++;
                if(temp == _sentinel)
                    continue;
                
                debugCounter++;
                var tempAge = f(temp.Key);
                if (tempAge < age)
                    nodeList.Add(temp.Left);
                else if (tempAge > age)
                {
                    nodeList.Add(temp.Right);
                    debugCounter++;
                }
                else if (tempAge == age)
                {
                    outList.Add(temp.Data);
                    nodeList.Add(temp.Left);
                    nodeList.Add(temp.Right);
                    debugCounter++;
                }
            }

            Program.DebugForm.WriteLine("Поиск игроков по возрасту, дерево. -Сравнений", debugCounter);
            return outList;
        }

        public List<Node> FindList(TKey key)
        {
            var list = new List<Node>();
            var nodes = new List<Node> {Root};
            var debugCounter = 0;
            while (nodes.Count != 0)
            {
                var temp = nodes[nodes.Count - 1];
                nodes.RemoveAt(nodes.Count-1);
                debugCounter++;
                if (temp == _sentinel)
                    continue;
                debugCounter++;
                if (Program.CompareKeys(key, temp.Key) < 0)
                    nodes.Add(temp.Left);
                else if (Program.CompareKeys(key, temp.Key) > 0)
                {
                    nodes.Add(temp.Right);
                    debugCounter++;
                }
                else
                {
                    list.Add(temp);
                    nodes.Add(temp.Left);
                    nodes.Add(temp.Right);
                    debugCounter++;
                }
            }

            Program.DebugForm.WriteLine("Поиск игрока по ключу в дереве. -Сравнений", debugCounter);
            return list;
        }

        private Node Find(TKey key)
        {
            var temp = Root;
            var debugCounter = 0;
            while (temp != _sentinel)
            {
                debugCounter+=3;
                if (Program.CompareKeys(key, temp.Key) < 0)
                    temp = temp.Left;

                if (Program.CompareKeys(key, temp.Key) > 0)
                    temp = temp.Right;

                if (Program.CompareKeys(key, temp.Key) == 0)
                    return temp;
            }

            Program.DebugForm.WriteLine("Поиск игрока по ключу в дереве. -Сравнений", debugCounter);
            return _sentinel;
        }
    }
}
