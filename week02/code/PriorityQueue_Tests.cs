using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities (1, 5, 3). 
    // Expected Result: The item with the highest priority (5) is returned first.
    // Defect(s) Found: Fixed loop index in PriorityQueue.cs (was skipping the last item).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same high priority (7).
    // Expected Result: The first item added with priority 7 should be dequeued first (FIFO).
    // Defect(s) Found: Verified that Dequeue uses '>' instead of '>=' to preserve order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First 7", 7);
        priorityQueue.Enqueue("Second 7", 7);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("First 7", priorityQueue.Dequeue());
        Assert.AreEqual("Second 7", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with "The queue is empty."
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}