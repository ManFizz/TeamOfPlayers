using System;
using System.Linq;

namespace TeamOfPlayers.Structures
{
    public class HashTable<T>
    {
        public enum CellStatus
        {
            Empty = 0,
            Filled,
            Deleted
        }

        private int _size;
        private int _capacity;
        private readonly int _origSize;

        public Node[] Arr;
        public CellStatus?[] ArrStatus;

        public Action OnResize;

        public class Node
        {
            public T Data;
            public readonly string Key;

            public Node(T player, string key) { Data = player; Key = key; }

            public static implicit operator bool(Node x) { return x != null; }

            public static implicit operator string(Node x) { return x.Data.ToString(); }
        }

        public HashTable(int iSize = 0)
        {
            iSize = iSize switch
            {
                < 0 => throw new ArgumentOutOfRangeException(),
                < 4 => 4,
                _ => iSize
            };

            _origSize = iSize;
            _capacity = 0;
            _size = iSize;
            Arr = new Node[_size];
            ArrStatus = new CellStatus?[_size];
            for (var i = 0; i < _size; i++)
                ArrStatus[i] = CellStatus.Empty;
        }

        ~HashTable()
        {
            for (var i = 0; i < Arr.Length;i++)
                Arr[i] = null;
            for (var i = 0; i < ArrStatus.Length;i++)
                ArrStatus[i] = null;
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
            Program.DebugForm.WriteLine("Изменение размера хеш-таблицы " + _size +". Перерасчет всего хеша");


            var arrStatus = ArrStatus;
            ArrStatus = new CellStatus?[_size];
            for (var i = 0; i < _size; i++)
                ArrStatus[i] = CellStatus.Empty;

            var arr = Arr;
            Arr = new Node[_size];
            for (var i = 0; i < oldSize; i++)
            {
                if (arrStatus[i] != CellStatus.Filled)
                    continue;

                var pos = GetFreeHash(arr[i].Key);
                Arr[pos] = arr[i];
                ArrStatus[pos] = CellStatus.Filled;
            }

            OnResize();
        }

        public T Get(int pos)
        {
            return Enumerable.Range(0, _size-1).Contains(pos) ? Arr[pos].Data : default;
        }

        public T Get(string key)
        {
            var pos = GetPos(key);
            return pos == -1 ? default : Arr[pos].Data;
        }

        public int GetPos(string key)
        {
            int pos;
            var attempt = 0;
            do
            {
                pos = GetHash(key, attempt);
                attempt++;

                if (ArrStatus[pos] != CellStatus.Filled || Program.CompareKeys(Arr[pos].Key,key) != 0)
                    continue;
                
                Program.DebugForm.WriteLine("Взятие хеша: позиция = " + pos + ". -Попыток", attempt);
                return pos;

            } while (ArrStatus[pos] != CellStatus.Empty);

            Program.DebugForm.WriteLine("Взятие хеша: позиция = -1. -Попыток", attempt);
            return -1;
        }

        public int Remove(T data, string key)
        {

            return Remove(new Node(data,key));
        }

        private int Remove(Node data)
        {
            var pos = GetPos(data.Key);
            if (pos == -1)
                return pos;

            ArrStatus[pos] = CellStatus.Deleted;
            _capacity--;
            Recalc();

            return pos;
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
            Arr[pos] = data;
            ArrStatus[pos] = CellStatus.Filled;
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
            } while (ArrStatus[pos] == CellStatus.Filled);

            Program.DebugForm.WriteLine("Взятие хеша: позиция = " + pos + ". -Попыток", attempt);
            return pos;
        }

        private int GetHash(string data, int attempt = 0)
        {
            var k = _size/ (_size % 10) - 1;
            if (k <= 0) k = 1;
            return (data.Sum(c => c) + k*attempt) % _size;
        }
    }
}