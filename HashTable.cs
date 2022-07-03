using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamOfPlayers
{
    public class HashTable<T>
    {
        public enum HtStatus
        {
            Empty = 0,
            Filled,
            Deleted
        }

        private int _size;
        private int _capacity;
        private readonly int _origSize;

        private Node[] _arr;
        private HtStatus?[] _arrStatus;

        public class Node
        {
            public T Data;
            public string Key;

            public Node(T player, string key) { Data = player; Key = key; }

            public static implicit operator bool(Node x) { return x != null; }

            public static implicit operator string(Node x) { return x.Data.ToString(); }
        }

        public HashTable(int iSize = 0)
        {
            if (iSize < 0)
                throw new ArgumentOutOfRangeException();

            if (iSize < 4)
                iSize = 4;
            _origSize = iSize;
            _capacity = 0;
            _size = iSize;
            _arr = new Node[_size];
            _arrStatus = new HtStatus?[_size];
            for (var i = 0; i < _size; i++)
                _arrStatus[i] = HtStatus.Empty;
        }

        ~HashTable()
        {
            for (var i = 0; i < _arr.Length;i++)
                _arr[i] = null;
            for (var i = 0; i < _arrStatus.Length;i++)
                _arrStatus[i] = null;
        }

        private void Recalc()
        {
            var oldSize = _size;
            if (_capacity >= 0.75 * _size)
            {
                _size *= 2;
            }
            else if (_capacity <= 0.25 * _size)
            {
                if (_size > _origSize)
                    _size /= 2;
                else return;
            }
            else return;


            var arrStatus = _arrStatus;
            _arrStatus = new HtStatus?[_size];
            for (var i = 0; i < _size; i++)
                _arrStatus[i] = HtStatus.Empty;

            var arr = _arr;
            _arr = new Node[_size];
            for (var i = 0; i < oldSize; i++)
            {
                if (arrStatus[i] != HtStatus.Filled)
                    continue;

                var pos = GetFreeHash(arr[i].Key);
                _arr[pos] = arr[i];
                _arrStatus[pos] = HtStatus.Filled;
            }
        }

        public T Get(int pos)
        {
            return Enumerable.Range(0, _size-1).Contains(pos) ? _arr[pos].Data : default;
        }

        public T Get(string key)
        {
            var pos = GetPos(key);
            return pos == -1 ? default : _arr[pos].Data;
        }

        public List<T> GetList()
        {
            var list = new List<T>();
            for(var i = 0; i < _size; i++)
                if (_arrStatus[i] == HtStatus.Filled)
                    list.Add(_arr[i].Data);

            return list;
        }

        public int GetPos(string data)
        {
            int pos;
            var attempt = 0;
            do
            {
                pos = GetHash(data, attempt);
                attempt++;

                if (_arrStatus[pos] != HtStatus.Filled || Program.CompareKeys(_arr[pos].Key,data) == 0)
                    continue;

                return pos;

            } while (_arrStatus[pos] != HtStatus.Empty);

            return -1;
        }

        public bool Remove(T data, string key)
        {

            return Remove(new Node(data,key));
        }

        private bool Remove(Node data)
        {
            var pos = GetPos(data.Key);
            if (pos == -1)
                return false;

            _arrStatus[pos] = HtStatus.Deleted;
            _capacity--;
            Recalc();

            return true;
        }

        public int Add(T data, string key)
        {
            return Add(new Node(data, key));
        }

        private int Add(Node data)
        {
            if (GetPos(data.Key) != -1)
                return -1;

            var pos = GetFreeHash(data.Key);
            _arr[pos] = data;
            _arrStatus[pos] = HtStatus.Filled;
            _capacity++;
            Recalc();
            return pos;
        }

        private int GetFreeHash(string data)
        {
            int pos;
            var attempt = 0;
            do
            {
                pos = GetHash(data, attempt);
                attempt++;
                if (attempt == _size)
                    throw new Exception("Хеш функция зациклилась");
            } while (_arrStatus[pos] == HtStatus.Filled);

            return pos;
        }

        private int GetHash(string data, int attempt = 0)
        {
            //return (GetHashFirst(key) + attempt * GetHashSecond(key, attempt)) % _size;
            //return (key % _size + attempt * 1) % _size;
            return (data.Aggregate(0, (current, c) => current + c) + attempt) % _size;
        }
    }
}