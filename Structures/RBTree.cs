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
            public readonly TKey Key;
            public Color Color;
            public Node Left, Right, Parent;

            public Node(TData player, TKey key, Func<TData, TData, bool> func) { 
                _dataList = new DataList<TData>(func);
                Add(player); 
                Key = key;
            }
            public Node(Color color, Func<TData, TData, bool> func)
            {
                _dataList = new DataList<TData>(func);
                Color = color;
            }
            public Node(Node parent, Color color, Func<TData, TData, bool> func) { Parent = parent; Color = color;
                _dataList = new DataList<TData>(func);
            }
            
            public static implicit operator bool(Node x) { return x != null; }

            //Dynamic list
            private readonly DataList<TData> _dataList;

            public void Add(TData data)
            {
                _dataList.Add(data);
            }

            public bool Remove(TData data)
            {
                return _dataList.Remove(data);
            }
            
            public bool Contains(TData data)
            {
                return _dataList.Contains(data);
            }

            public List<TData> GetList()
            {
                return _dataList.GetList();
            }

            public bool Empty()
            {
                return _dataList.Empty();
            }
        }

        public Node Root;
        private Node _sentinel;
        private readonly Func<TKey, TKey, int> _compareKeys;
        private readonly Func<TData, TData, bool> _equalData;

        public RbTree(Func<TKey, TKey, int> func,Func<TData, TData, bool> funcData)
        {
            _compareKeys = func;
            _equalData = funcData;
            Root = new Node(Color.Black, _equalData);
            _sentinel = new Node(Root, Color.Black, _equalData);
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
            var insertNode = new Node(item, key, _equalData);
            if(_compareKeys(Root.Key, default) == 0)
            {
                Root = insertNode;
                Root.Parent = _sentinel;
                Root.Left = _sentinel;
                Root.Right = _sentinel;
                Root.Color = Color.Black;
                _sentinel.Left = Root;
                _sentinel.Right = Root;
                _sentinel.Parent = Root;
                return;
            }

            var parentX = _sentinel;
            var x = Root;

            while (x != _sentinel)
            {
                parentX = x;
                switch (_compareKeys(insertNode.Key, x.Key))
                {
                    case < 0:
                    {
                        x = x.Left;
                        break;
                    }
                    case 0:
                    {
                        x.Add(item);
                        return;
                    }
                    case > 0:
                    {
                        x = x.Right;
                        break;
                    }
                }
            }
            
            insertNode.Parent = parentX;
            if (parentX == _sentinel)
                Root = insertNode;
            else if(_compareKeys(insertNode.Key, parentX.Key) < 0)  
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
            var saveDebug = z.Key;
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
            Program.DebugForm.WriteLine("Вставка в дерево по ключу <" + saveDebug + ">. -Поворотов", debugCounter);
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
            var node = Find(key);

            if (!node.Remove(data))
                return false;
            
            if (node.Empty())
                    Remove(node);
            
            return true;

        }

        public bool Remove(TKey key)
        {
            var z = Find(key);
            if (z == _sentinel)
                return false;

            Remove(z);
            return true;
        }

        private Node Minimum(Node x)
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
            var saveDebug = x.Key;
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
            Program.DebugForm.WriteLine("Удаление из дерева по ключу <" + saveDebug + ">. -Поворотов", debugCounter);
        }

        #endregion

        public List<TData> FindAge(int age)
        {
            if(Root.Key is not DateTime)
                throw new Exception("Функция не предназначена для работы с этим типом ключа");

            var bottom = DateTime.ParseExact(DateTime.Now.ToString("dd.MM") + "." + (DateTime.Now.Year - age - 1), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var top = bottom.AddYears(1);
            var outList = new List<TData>();
            var nodeList = new List<Node> {Root};
            var debugCounter = 0;
            while (nodeList.Count != 0)
            {
                var temp = nodeList[nodeList.Count - 1];
                nodeList.Remove(temp);
                debugCounter++;
                if(temp == _sentinel || temp == null || temp.Key == null)
                    continue;

                var key = DateTime.Parse(temp.Key.ToString());
                debugCounter++;
                
                if(key > top)
                    nodeList.Add(temp.Left);
                else if(key < bottom)
                    nodeList.Add(temp.Right);
                else
                {
                    outList.AddRange(temp.GetList());
                    nodeList.Add(temp.Left);
                    nodeList.Add(temp.Right);
                    debugCounter++;
                }
            }

            Program.DebugForm.WriteLine("Поиск игроков по возрасту в дереве по ключу <" + age + ">. -Сравнений", debugCounter);
            return outList;
        }

        public Node Find(TKey key)
        {
            var temp = Root;
            var debugCounter = 0;
            while (temp.Key != null)
            {
                debugCounter++;
                var result = _compareKeys(key, temp.Key);
                if (result < 0)
                    temp = temp.Left;
                else if (result > 0)
                    temp = temp.Right;
                else 
                    return temp;
            }

            Program.DebugForm.WriteLine("Поиск игрока по ключу в дереве. -Сравнений", debugCounter);
            return _sentinel;
        }
    }
}
