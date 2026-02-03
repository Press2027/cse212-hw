using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>

    public void InsertHead(int value)
    {
         // Create new node
        var node = new Node(value);
 // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = _tail = node;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            node.Next = _head;
            _head.Prev = node;
            _head = node;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
         // TODO Problem 1
        var node = new Node(value);

        if (_tail is null)
        {
            _head = _tail = node;
        }
        else
        {
            node.Prev = _tail;
            _tail.Next = node;
            _tail = node;
        }
    }


/// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head is null) return;

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
    }

     // If the list has more than one item in it, then only the head
        // will be affected.
    public void RemoveTail()
    {
        if (_tail is null) return;

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // TODO Problem 2
        for (var curr = _head; curr is not null; curr = curr.Next)
        {
            if (curr.Data != value) continue;

            if (curr == _tail)
            {
                InsertTail(newValue);
            }
            else
            {
                var node = new Node(newValue)
                {
                    Prev = curr,
                    Next = curr.Next
                };

                curr.Next!.Prev = node;
                curr.Next = node;
            }
            return;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void Remove(int value)
    {
         // TODO Problem 3
        for (var curr = _head; curr is not null; curr = curr.Next)
        {
            if (curr.Data != value) continue;

            if (curr == _head) RemoveHead();
            else if (curr == _tail) RemoveTail();
            else
            {
                curr.Prev!.Next = curr.Next;
                curr.Next!.Prev = curr.Prev;
            }
            return;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
         // TODO Problem 4
        for (var curr = _head; curr is not null; curr = curr.Next)
        {
            if (curr.Data == oldValue)
                curr.Data = newValue;
        }
    }

    public IEnumerable<int> Reverse()
    {
        for (var curr = _tail; curr is not null; curr = curr.Prev)
            yield return curr.Data;
    }

    public bool HeadAndTailAreNull() => _head is null && _tail is null;
    public bool HeadAndTailAreNotNull() => _head is not null && _tail is not null;

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        // TODO Problem 5
        for (var curr = _head; curr is not null; curr = curr.Next)
            yield return curr.Data;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString()
        => "<LinkedList>{" + string.Join(", ", this) + "}";
}
