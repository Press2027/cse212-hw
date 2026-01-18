using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode); // always add to back
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find index of item with highest priority
        int highIndex = 0;
        
        // FIX: Changed from 'i < _queue.Count - 1' to 'i < _queue.Count'
        // to ensure the last item in the list is checked.
        for (int i = 1; i < _queue.Count; i++)
        {
            // Using '>' maintains FIFO for same-priority items.
            if (_queue[i].Priority > _queue[highIndex].Priority)
            {
                highIndex = i;
            }
        }

        var value = _queue[highIndex].Value;
        _queue.RemoveAt(highIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

// This internal class must be present for the PriorityQueue to function
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}