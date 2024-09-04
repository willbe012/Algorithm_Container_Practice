using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CustomLinkedList<T>
{
    public class CustomNode<T>
    {
        public T value { get; set; }
        public CustomNode<T> linkedNode { get; set; }

        public CustomNode(T value)
        {
            this.value = value;
            this.linkedNode = null;
        }
    }

    private CustomNode<T> parent = null;
    private int count;

    public int GetCount()
    {
        return count;
    }
    public void AddElement(T value)
    {
        CustomNode<T> node = new CustomNode<T>(value);

        if (parent == null)
        {
            parent = node;
        }
        else
        {
            CustomNode<T> current = parent;
            while (current.linkedNode != null)
            {
                current = current.linkedNode;
            }
            current.linkedNode = node;
        }
        count++;
    }
    public void RemoveElement(T value)
    {
        if (parent == null)
            return;

        if (parent.value.Equals(value))
        {
            parent = parent.linkedNode;
            count--;
            return;
        }

        CustomNode<T> cur = parent;
        CustomNode<T> prev = null;

        while (cur != null && !cur.value.Equals(value))
        {
            prev = cur;
            cur = cur.linkedNode;
        }

        if (cur == null)
            return;

        prev.linkedNode = cur.linkedNode;
        count--;
        return;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            return default;

        CustomNode<T> current = parent;
        int currentIndex = 0;

        while (currentIndex < index)
        {
            current = current.linkedNode;
            currentIndex++;
        }

        return current.value;
    }
}
