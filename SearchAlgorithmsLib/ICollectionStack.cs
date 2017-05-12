using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class ICollectionStack<T> : ICollection<T>
    {
        private Stack<T> stack;


        public ICollectionStack(Stack<T> stack)
        {
            this.stack = stack;
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            stack.Push(item);
        }

        public T Pop()
        {
            return stack.Pop();
        }

        public T Peek()
        {
            return stack.Peek();
        }

        public void Clear()
        {
            stack.Clear();
        }

        public bool Contains(T item)
        {
            return stack.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            stack.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return stack.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stack.GetEnumerator();
        }
    }
}
