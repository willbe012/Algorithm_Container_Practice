using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLinkedList<T>
{
    public class CustonNode<T>
    {
        public T value { get; set; }
        public CustonNode<T> linkedNode { get; set; }

        public CustonNode(T value)
        {
            this.value = value;
            this.linkedNode = null;
        }
    }

    private CustonNode<T> parent = null;
    public void AddElement(T value)
    {
        CustonNode<T> node = new CustonNode<T>(value);

        if (parent == null)
        {
            parent = node;
        }
        else
        {
            CustonNode<T> current = parent;
            while (current.linkedNode != null)
            {
                current = current.linkedNode;
            }
            current.linkedNode = node;
        }
    }
    public bool RemoveElement(T value)
    {
        if (parent == null)
            return false;

        if (parent.value.Equals(value))
        {
            parent = parent.linkedNode;
            return true;
        }

        CustonNode<T> cur = parent;
        CustonNode<T> prev = null;

        while (cur != null && !cur.value.Equals(value))
        {
            prev = cur;
            cur = cur.linkedNode;
        }

        if (cur == null)
            return false;

        prev.linkedNode = cur.linkedNode;
        return true;
    }
 }
