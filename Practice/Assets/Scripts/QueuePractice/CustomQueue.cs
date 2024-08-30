using System.Collections.Generic;


namespace YYY
{
    public class CustomQueue<T>
    {
        // Queue -> FIFO
        private List<T> elements = new List<T>();

        public bool CheckEmpty()
        {
            return elements.Count == 0;
        }

        public void EnQueue(T element)
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

        public T DeQueue()
        {
            if (CheckEmpty() == true)
                return default(T);

            T element = elements[0];
            elements.RemoveAt(0);
            return element;
        }

    }
}
