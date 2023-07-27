using System.Collections;

namespace Name
{
    public class LinkedList<T> : IList<T>
    {
        public LinkedList(T[] elements)
        {
            LinkedNode<T> actual = null!;
            for (int i = 0; i < elements.Length; i++)
            {
                if (i == 0)
                {
                    actual = new LinkedNode<T>(elements[0]);
                    Start = actual;
                }
                else
                {
                    actual.Next = new LinkedNode<T>(elements[i]);
                    actual = actual.Next;
                }
            }
            End = actual;
            count = elements.Length;
        }
        public LinkedNode<T> Start;
        public LinkedNode<T> End;
        public T this[int index]
        {
            get
            {
                if (index > 0 && index < Count)
                {
                    LinkedNode<T> temporal = Start;
                    for (int i = 0; i < index; i++)
                    {
                        temporal = temporal.Next;
                    }
                    return temporal.value;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index > 0 && index < Count)
                {
                    LinkedNode<T> temporal = Start;
                    for (int i = 0; i < index; i++)
                    {
                        temporal = temporal.Next;
                    }
                    temporal.value = value;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public int Count => count;
        private int count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            LinkedNode<T> end = new LinkedNode<T>(item);
            End.Next = end;
            End = end;
            this.count += 1;
        }

        public void Clear()
        {
            LinkedNode<T> cleared = Start.Next;
            for (int i = 0; cleared.Next != null; i++)
            {
                Start.Next = null!;
                Start = cleared;
                cleared = Start.Next;
            }
            End = null!;
        }

        public bool Contains(T item)
        {
            LinkedNode<T> actual = Start;
            for (int i = 0; actual.Next != null; i++)
            {
                if (actual.value!.Equals(item))
                {
                    return true;
                }
                actual = actual.Next;
            }
            return actual.value!.Equals(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> actual = Start;
            for (int i = 0; actual.Next != null; i++)
            {
                yield return actual.value;
                actual = actual.Next;
            }
        }

        public int IndexOf(T item)
        {
            LinkedNode<T> actual = Start;
            for (int i = 0; i < this.count; i++)
            {
                if (actual.value!.Equals(item)) { return i; }
                actual = actual.Next;
            }
            throw new ArgumentException();
        }

        public void Insert(int index, T item)
        {
            LinkedNode<T> actual = Start;
            LinkedNode<T> insert = new LinkedNode<T>(item);

            for (int i = 0; actual.Next != null; i++)
            {
                if (IndexOf(actual.Next.value) == index)
                {
                    insert.Next = actual.Next;
                    actual.Next = insert;
                }
                actual = actual.Next;
            }
            this.count += 1;
        }

        public bool Remove(T item)
        {
            LinkedNode<T> actual = Start;
            bool remove = false;
            for (int i = 0; i < this.count - 1; i++)
            {
                if (i == 0 && actual.value!.Equals(item))
                {
                    actual = actual.Next;
                    remove = true;
                    i += 1;
                }
                else if (actual.Next.value!.Equals(item))
                {
                    actual.Next = actual.Next.Next;
                    remove = true;
                    i += 1;
                }
                actual = actual.Next;
            }
            this.count -= 1;
            return remove;
        }

        public void RemoveAt(int index)
        {
            LinkedNode<T> actual = Start;
            for (int i = 0; i < Count; i++)
            {
                if (IndexOf(actual.Next.value) == index)
                {
                    actual.Next = actual.Next.Next;
                }
                actual = actual.Next;
            }
            this.count -= 1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class LinkedNode<T>
    {
        public T value;
        public LinkedNode<T> Next;

        public LinkedNode(T value, LinkedNode<T> next)
        {
            this.value = value;
            Next = next;
        }
        public LinkedNode(T value)
        {
            this.value = value;
            Next = null!;
        }
    }
}