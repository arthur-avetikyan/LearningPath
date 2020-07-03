using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] collection;
        private int index;

        public int Length { get; private set; }

        public MyList()
        {
            collection = new T[0];
            index = -1;
            Length = 0;
        }

        #region Instance Methods

        public void Add(T item)
        {
            var temp = collection;
            index++;
            Length++;

            collection = new T[Length];
            for (int i = 0; i < temp.Length; i++)
            {
                collection[i] = temp[i];
            }
            collection[index] = item;
        }

        public void AddRange(IEnumerable<T> list)
        {
            var temp = collection;
            index += list.Count();
            Length = index + 1;

            collection = new T[Length];

            for (int i = 0; i < temp.Length; i++)
            {
                collection[i] = temp[i];
            }

            int counter = temp.Length;
            foreach (var item in list)
            {
                collection[counter] = item;
                counter++;
            }
        }

        public void Remove()
        {
            var temp = collection;
            index -= 1;
            Length = index + 1;

            collection = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                collection[i] = temp[i];
            }
        }

        public void RemoveItem(T item)
        {
            int itemIndex = FindIndex(item);
            if (itemIndex != -1)
                RemoveAtIndex(itemIndex);
        }

        public void RemoveAtIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex > index)
                return;

            var temp = collection;
            index -= 1;
            Length = index + 1;
            int y = 0;

            collection = new T[Length];

            for (int i = 0; i < temp.Length; i++)
            {
                if (i != itemIndex)
                {
                    collection[y] = temp[i];
                    y++;
                }
            }
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (collection[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (collection[i].Equals(item))
                    return true;
            }
            return false;
        }

        public void SortByAscending()
        {
            IComparer<T> comparer = Comparer<T>.Default;

            bool isSorted = false;
            for (int y = 0; y < collection.Length && !isSorted; y++)
            {
                isSorted = true;
                for (int i = 0; i < collection.Length - 1; i++)
                {
                    if (comparer.Compare(collection[i], collection[i + 1]) > 0)
                    {
                        var temp = collection[i];
                        collection[i] = collection[i + 1];
                        collection[i + 1] = temp;
                        isSorted = false;
                    }
                }
            }
        }

        public void SortByDescending()
        {
            IComparer<T> comparer = Comparer<T>.Default;

            bool isSorted = false;
            for (int y = 0; y < collection.Length && !isSorted; y++)
            {
                isSorted = true;
                for (int i = 0; i < collection.Length - 1; i++)
                {
                    if (comparer.Compare(collection[i], collection[i + 1]) < 0)
                    {
                        var temp = collection[i];
                        collection[i] = collection[i + 1];
                        collection[i + 1] = temp;
                        isSorted = false;
                    }
                }
            }
        }

        #endregion

        #region IEnumerable

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Enumerator

        public class Enumerator : IEnumerator<T>
        {
            private MyList<T> list;
            private int totalItems;
            private int counter;

            public Enumerator(MyList<T> list)
            {
                this.list = list;
                totalItems = list.Length;
                counter = -1;
            }

            public T Current => list.collection[counter];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                counter++;
                return counter < totalItems;
            }

            public void Reset() => counter = -1;
        }

        #endregion
    }
}