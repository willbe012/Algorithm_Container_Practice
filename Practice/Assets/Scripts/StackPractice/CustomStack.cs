using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;


namespace YYY
{
    public class CustomStack<T>
    {
        // Stack -> FILO
        // �����۽� ��
        // LinkedListó�� �����غ���
        private class CustomStackNode<T>
        {
            public T Data { get; set; }
            public CustomStackNode<T> NextNode { get; set; }

            public CustomStackNode(T data)
            {
                this.Data = data;
                this.NextNode = null;
            }
        }

        private CustomStackNode<T> root = null;
        private int count = 0;

        public int GetCount()
        {
            return count;
        }

        public bool IsEmpty()
        {
            if (root == null)
                return true;

            return false;
        }

        public void Push(T element)
        {
            CustomStackNode<T> newNode = new(element)
            {
                NextNode = root
            };
            root = newNode;
            count++;
        }


        // List ��� ��Ŀ��� ����ȭ. -> List�� �������� �迭�̱� ������ Ư�� ��ġ�� ��Ҹ� �����ϸ� ��ü ��ҵ��� �̵��� �Ͼ.
        // LinkedList ����� ä���� ��� ������ ����� ���� ���� �ٽ� ���Ḹ ���ָ� �ȴ�.
        // ��, �������� �迭���� �� �޸� ������ ������ �ʱ� ���� ó���� �� �ʿ䰡 ����.
        // Pop Node�� return �ϸ� ����ڰ� �ش� Node�� ������ �ִٰ� �ٸ� �뵵�ε� ����� �� ����.

        public T Pop()
        {
            var isEmpty = IsEmpty();
            if(isEmpty)
            {
                return default;
            }

            var element = root.Data;
            root = root.NextNode;
            count--;
            return element;
        }

        // for�� �� ���ֳ�?
        // ���� ���ַ��� ����� linked list�� �ص� �Ǵµ�, Stack ��� �����ʹ� ���� �ʴ� �������� ����.
        // (Double)LinkedList ������ �� �ݺ��� ���ִ� �� �����غ���.

        public T GetElementAt(int index)
        {
            if (index < 0 || index >= count)
                return default;

            CustomStackNode<T> current = root;

            for (int i = 0; i < index; i++)
                current = current.NextNode;

            return current.Data;
        }

    }
}
