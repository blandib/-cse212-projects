using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: A(1), B(2), C(3)
    // Expected Result: Dequeue returns C, then B, then A (highest priority first)
    // Defect(s) Found:
    // Items may not be prioritized correctly during Dequeue.
    // The queue may return items in insertion order instead of by priority.
    public void TestPriorityQueue_EnqueueOrder()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 2);
        queue.Enqueue("C", 3);

        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
    }


 [TestMethod]
    // Scenario: Enqueue A(1), B(3), C(2)
    // Expected Result: Dequeue returns B (highest priority)
    // Defect(s) Found:
    // Dequeue may not scan for the highest priority correctly.
    // It might return the first item instead of the one with the highest priority.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);

        Assert.AreEqual("B", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(5), B(5), C(4)
    // Expected Result: Dequeue returns A (first inserted with highest priority), then B, then C
    // Defect(s) Found:
    // Dequeue may not respect FIFO order when multiple items share the highest priority.
    public void TestPriorityQueue_FIFOWithEqualPriority()
    {

var queue = new PriorityQueue();
        queue.Enqueue("A", 5);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 4);

        Assert.AreEqual("A", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found:
    // No exception is thrown, or the wrong exception/message is used when the queue is empty.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }

 catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception type: {ex.GetType().Name}");
        }
    }
}

