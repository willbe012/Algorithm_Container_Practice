namespace YYY
{
    public class CustomQueue<T>
    {
        // FIFO
        // LinkedListó�� �����غ���

        private class CustomQueueNode<T>
        {
            public T Data { get; set; }
            public CustomQueueNode<T> NextNode { get; set; }

            public CustomQueueNode(T data)
            {
                this.Data = data;
                this.NextNode = null;
            }
        }

        private CustomQueueNode<T> root = null;  
        private CustomQueueNode<T> last = null;   
        private int count = 0;

        public bool IsEmpty()
        {
            return root == null;
        }

        public void EnQueue(T element)
        {
            CustomQueueNode<T> newNode = new(element);

            if (last != null)
                last.NextNode = newNode;

            last = newNode;  


            // ù ��Ҷ�� root == last
            if (root == null)  
                root = last;

            count++;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                return default;

            T element = root.Data;
            root = root.NextNode;  

            if (root == null)
                last = null;

            count--;
            return element;
        }

        // ť�� �ִ� ��� �� ��ȯ
        public int GetCount()
        {
            return count;
        }

        public T GetElementAt(int index)
        {
            if (index < 0 || index >= count)
                return default;

            CustomQueueNode<T> current = root;

            for (int i = 0; i < index; i++)
                current = current.NextNode;

            return current.Data;
        }
    }
}