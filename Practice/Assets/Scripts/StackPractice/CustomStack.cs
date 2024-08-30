using System.Collections.Generic;
using System.Linq;


namespace YYY
{
    public class CustomStack<T>
    {
        // Stack -> FILO
        // 프링글스 통

        private List<T> elements = new List<T>();

        public bool CheckEmpty()
        {
            return elements.Count == 0;
        }

        public void Push(T element)
        {
            elements.Add(element);
        }

        public int GetTotalCount()
        {
            return elements.Count;
        }

        public T GetElementAt(int index)
        {
            return elements[index];
        }

        public T Pop()
        {
            if (CheckEmpty() == true)
                return default(T);

            T element = elements.Last();
            elements.RemoveAt(elements.Count - 1);
            return element;
        }

    }
}
