public class CustomLinkedList<T>
{

    public class CustomNode<T>
    {
        public T value { get; set; }
        public CustomNode<T> next { get; set; }
        public CustomNode<T> prev { get; set; }

        public CustomNode(T value)
        {
            this.value = value;
            this.next = null;
            this.prev = null;
        }
    }

    private CustomNode<T> root = null;
    private CustomNode<T> last = null;
    private int count;

    public int GetCount()
    {
        return count;
    }

    public T AddElement(T value)
    {
        CustomNode<T> node = new CustomNode<T>(value);

        if (root == null)
        {
            root = node;
            last = node;
        }
        else
        {
            last.next = node;
            node.prev = last;
            last = node;
        }
        count++;

        return value;
    }


    // 마찬가지로 T return 해서 사용자가 가지고 있다가 사용할 수 있게끔 한다.
    public T RemoveElement(T value)
    {
        if (root == null)
            return default;

        CustomNode<T> current = root;

        while (current != null && !current.value.Equals(value))
        {
            current = current.next;
        }

        if (current == null)
            return default;
        
        if (current == root)
        {
            root = root.next;
            if (root != null)
                root.prev = null;
        }
        else if (current == last)
        {
            root = last.prev;
            if (last != null)
                last.next = null;
        }
        else
        {
            current.prev.next = current.next;
            if (current.next != null)
            {
                current.next.prev = current.prev;
            }
        }

        count--;

        return current.value;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            return default;

        CustomNode<T> current;
        int currentIndex;


        if (index < count / 2)
        {
            current = root;
            currentIndex = 0;
            while (currentIndex < index)
            {
                current = current.next;
                currentIndex++;
            }
        }
        else
        {
            current = last;
            currentIndex = count - 1;
            while (currentIndex > index)
            {
                current = current.prev;
                currentIndex--;
            }
        }

        return current.value;
    }
}