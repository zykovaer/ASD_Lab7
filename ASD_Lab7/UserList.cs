using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ASD_Lab7
{
    class UserList<T> : IEnumerable<T>
    {
        private class Element
        {
            public T Data { set; get; }
            public Element Next { set; get; }
            public Element()
            {
            }
            public Element(T a)
            {
                Data = a;
                Next = null;
            }
        }
        Element Head = null;

        public void PushBack(T a)
        {
            Element tmp = new Element(a);
            if (Head == null)
            {
                Head = tmp;
            }
            else
            {
                Element t = Head;
                while (t.Next != null)
                {
                    t = t.Next;
                }
                t.Next = tmp;
            }
        }

        public void PushFirst(T a)
        {
            Element tmp = new Element(a);
            if (Head == null)
            {
                Head = tmp;
            }
            else
            {
                tmp.Next = Head;
                Head = tmp;
            }
        }

        public T Top()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                return Head.Data;
            }
        }

        public T Back()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                Element tmp = Head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                return tmp.Data;
            }
        }

        public T PopFirst()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                T c = Head.Data;
                Head = Head.Next;
                return c;
            }
        }

        public T PopBack()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                if (Head.Next == null)
                {
                    T c = Head.Data;
                    Head = null;
                    return c;
                }
                else
                {
                    Element tmp = Head;
                    while (tmp.Next.Next != null)
                    {
                        tmp = tmp.Next;
                    }
                    T c = tmp.Next.Data;
                    tmp.Next = null;
                    return c;
                }
            }
        }

        public int Count
        {
            get
            {
                if (Head == null)
                {
                    return 0;
                }
                else
                {
                    int count = 0;
                    Element tmp = Head;
                    while (tmp != null)
                    {
                        count++;
                        tmp = tmp.Next;
                    }
                    return count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = Head;
            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }
        public void AddAfter(T data, int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            Element newEl = new Element(data);

            Element tmp = Head;
            Element next = tmp.Next;
            for (int i = 1; i <= index; i++)
            {
                tmp = tmp.Next;
                next = tmp.Next;
            }

            tmp.Next = newEl;
            newEl.Next = next;
        }
        public void AddBefore(T data, int index) 
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            if(index == 0)
            {
                this.PushFirst(data);
            }
            else
            {
                Element newEl = new Element(data);

                Element tmp = Head;
                Element prev = tmp;
                for (int i = 1; i <= index; i++)
                {
                    prev = tmp;
                    tmp = tmp.Next;
                }

                newEl.Next = tmp;
                prev.Next = newEl;
            }
        }
        public void Del(int i)
        {
            if (Head != null)
            {
                if (i == this.Count - 1)
                {
                    this.PopBack();
                }
                else
                {
                    if (i < this.Count && this.Count > 1)
                    {
                        Element p = Head;
                        int count = 1;
                        while (p.Next != null && count != i - 1)
                        {
                            p = p.Next;
                            count++;
                        }
                        if (count == i - 1)
                        {
                            p.Next = p.Next.Next;
                        }
                    }
                    else if (i == 1) this.PopFirst();
                }
            }
        }
        public void DelAfter(int index)
        {
            if (index >= this.Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            Element tmp = Head;
            int count = 0;
            while (count != index)
            {
                tmp = tmp.Next;
                count++;
            }
            tmp.Next = tmp.Next.Next;
        }
        public void DelBefore(int index)
        {
            if (index >= this.Count || index < 1)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            if (index == 1)
            {
                this.PopFirst();
            }
            else
            {
                Element tmp = Head;
                int count = 0;
                while (count != index - 2)
                {
                    tmp = tmp.Next;
                    count++;
                }
                tmp.Next = tmp.Next.Next;
            }
        }


        public bool Contains(T a)
        {
            Element p = Head;

            while (p != null)
            {
                if (p.Data.Equals(a)) return true;
                p = p.Next;

            }
            return false;

        }
        public T Search(int i)
        {
            if (Head != null)
            {
                Element p = Head;
                int count = 1;
                while (p.Next != null && count != i)
                {
                    p = p.Next;
                    count++;
                }
                if (count == i)
                {
                    return p.Data;
                }
            }
            return default(T);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            string s = "";
            if (Head != null)
            {
                Element tmp = Head;
                while (tmp != null)
                {
                    s += tmp.Data + " ";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
    
}
