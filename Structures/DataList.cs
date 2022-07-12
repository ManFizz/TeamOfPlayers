using System;
using System.Collections.Generic;

namespace TeamOfPlayers.Structures
{
    public class DataList<TData>
    {
        private class Node
        {
            public Node Next, Prev;
            public TData Data;

            public static implicit operator bool(Node node) { return node != null; }
        }
        
        private Node _head, _tail;
        private readonly Func<TData, TData, bool> _equalData;
        
        public DataList(Func<TData, TData, bool> equalData)
        {
            _equalData = equalData;
            _head = null;
            _tail = null;
        }

        public void Add(TData x)
        {
            var node = new Node
            {
                Data = x,
                Next = null,
                Prev = _tail
            };

            if (_head == null)
                _head = _tail = node;
            else
            {
                _tail.Next = node;
                _tail = node;
            }

        }
        
        public bool Remove(TData x)
        {
            return Remove(Find(x));
        }
        
        public bool Contains(TData data)
        {
            return Find(data) != null;
        }

        public bool Empty()
        {
            return _head is null;
        }
        private bool Remove(Node temp)
        {
            if (temp is null)
                return false;

            if (temp.Next)
                temp.Next.Prev = temp.Prev;
            else
                _tail = temp.Prev;

            if (temp.Prev)
                temp.Prev.Next = temp.Next;
            else
                _head = temp.Next;
            return true;
        }

        private Node Find(TData data)
        {
            var temp = _head;
            while (temp is not null) 
            {
                if (_equalData(temp.Data, data))
                    return temp;
                
                temp = temp.Next;
            }

            return null;
        }

        public List<TData> GetList()
        {
            var list = new List<TData>();
            var temp = _head;
            while (temp is not null) 
            {
                list.Add(temp.Data);
                temp = temp.Next;
            }

            return list;
        }
    }
}