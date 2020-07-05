using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] collection;
        private int currentIndex;

        public int Length { get; private set; }

        public MyList()
        {
            collection = new T[16];
            currentIndex = -1;
            Length = 0;
        }

        public MyList(int length)
        {
            collection = new T[length];
            currentIndex = -1;
            Length = length;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 && index >= Length)
                    throw new IndexOutOfRangeException();
                return collection[index];
            }
            set
            {
                if (index < 0 && index >= Length)
                    throw new IndexOutOfRangeException();
                collection[index] = value;
            }
        }


        #region Instance Methods

        public void Add(T item)
        {
            currentIndex++;
            Length++;
            if (collection.Length < Length)
            {
                var temp = collection;
                collection = new T[Length + 15];
                for (int i = 0; i < temp.Length; i++)
                {
                    collection[i] = temp[i];
                }
                collection[currentIndex] = item;
            }
            else
            {
                collection[currentIndex] = item;
            }
        }

        public void AddRange(IEnumerable<T> list)
        {
            var itemsToAddCount = list.Count();
            int openSlots = collection.Length - Length;

            if (openSlots < itemsToAddCount)
            {
                var temp = collection;
                var existingItemsCount = Length;
                int arrayResizeLength = collection.Length;

                int sizeToAdd = (itemsToAddCount - openSlots) / 16;
                arrayResizeLength += (itemsToAddCount - openSlots) % 16 != 0 ? 16 * (sizeToAdd + 1) : 16 * sizeToAdd;

                collection = new T[arrayResizeLength];

                for (int i = 0; i < existingItemsCount; i++)
                {
                    collection[i] = temp[i];
                }

                int counter = existingItemsCount;
                foreach (var item in list)
                {
                    collection[counter] = item;
                    counter++;
                }
            }
            else
            {
                int counter = Length;
                foreach (var item in list)
                {
                    collection[counter] = item;
                    counter++;
                }
            }
            Length += itemsToAddCount;
            currentIndex = Length - 1;
        }

        public void Remove()
        {
            collection[currentIndex] = default;
            currentIndex -= 1;
            Length = currentIndex + 1;
        }

        public void RemoveItem(T item)
        {
            int itemIndex = FindIndex(item);
            if (itemIndex != -1)
                RemoveAtIndex(itemIndex);
        }

        public void RemoveAtIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex > currentIndex)
                return;

            var temp = collection;
            currentIndex -= 1;
            Length = currentIndex + 1;

            for (int i = itemIndex; i < temp.Length - 1; i++)
            {
                collection[i] = temp[i + 1];
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
            for (int y = 0; y < Length && !isSorted; y++)
            {
                isSorted = true;
                for (int i = 0; i < Length - 1; i++)
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
            for (int y = 0; y < Length && !isSorted; y++)
            {
                isSorted = true;
                for (int i = 0; i < Length - 1; i++)
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