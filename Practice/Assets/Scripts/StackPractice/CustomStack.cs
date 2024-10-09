using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;


namespace YYY
{
    public class CustomStack<T>
    {
        // Stack -> FILO
        // 프링글스 통
        // LinkedList처럼 구현해보기
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


        // List 사용 방식에서 최적화. -> List는 연속적인 배열이기 때문에 특정 위치의 요소를 삭제하면 전체 요소들의 이동이 일어남.
        // LinkedList 방식을 채용할 경우 끊어진 노드의 다음 노드와 다시 연결만 해주면 된다.
        // 즉, 연속적인 배열에서 빈 메모리 공간이 생기지 않기 위한 처리를 할 필요가 없음.
        // Pop Node를 return 하면 사용자가 해당 Node를 가지고 있다가 다른 용도로도 사용할 수 있음.

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

        // for문 못 없애나?
        // 만약 없애려면 양방향 linked list로 해도 되는데, Stack 사용 이유와는 맞지 않는 느낌적인 느낌.
        // (Double)LinkedList 구현할 때 반복문 없애는 걸 연습해보자.

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
