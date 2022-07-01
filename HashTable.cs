using System;
using System.Linq;

namespace TeamOfPlayers
{
    class HashTable
    {
        public enum HtStatus
        {
            Empty = 0,
            Filled,
            Deleted
        }

        public int _size;
        public int _capacity;
        private readonly int _origSize;

        public Player[] _arr;
        public HtStatus?[] _arrStatus;

        public HashTable(int iSize = 0)
        {
            if (iSize < 0)
                throw new ArgumentOutOfRangeException();

            if (iSize < 4)
                iSize = 4;
            _origSize = iSize;
            _capacity = 0;
            _size = iSize;
            _arr = new Player[_size];
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
            _arr = new Player[_size];
            for (var i = 0; i < oldSize; i++)
            {
                if (arrStatus[i] != HtStatus.Filled)
                    continue;

                var pos = GetFreeHash(arr[i].Name);
                _arr[pos] = arr[i];
                _arrStatus[pos] = HtStatus.Filled;
            }
        }
        
        public int GetPos(string data)
        {
            int pos;
            var attempt = 0;
            do
            {
                pos = GetHash(data, attempt);
                attempt++;

                if (_arrStatus[pos] != HtStatus.Filled || _arr[pos].Name != data)
                    continue;

                return pos;

            } while (_arrStatus[pos] != HtStatus.Empty);

            return -1;
        }

        public bool Remove(Player data)
        {
            return Remove(data.Name);
        }

        public bool Remove(string data)
        {
            var pos = GetPos(data);
            if (pos == -1)
                return false;

            _arrStatus[pos] = HtStatus.Deleted;
            _capacity--;
            Recalc();

            return true;
        }

        public int Add(Player data)
        {
            if (GetPos(data.Name) != -1)
                return -1;

            var pos = GetFreeHash(data.Name);
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