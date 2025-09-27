using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue removes the highest-priority item and the queue shrinks.
    // Expected Result: "B" (3), then "C" (2), then "A" (1); ToString reflects removals.
    // Defect(s) Found: Dequeue did not remove the item from the queue.
    public void TestPriorityQueue_RemoveHighestAndShrink()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("[A (Pri:1), C (Pri:2)]", pq.ToString());

        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("[A (Pri:1)]", pq.ToString());

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("[]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Tie on priority should be FIFO (earliest enqueued first).
    // Expected Result: "A" then "B".
    // Defect(s) Found: Using >= could pick the later equal-priority item.
    public void TestPriorityQueue_TieUsesFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Highest-priority item is at the last position.
    // Expected Result: "C" is dequeued first.
    // Defect(s) Found: Loop skipped the last item (index < Count - 1).
    public void TestPriorityQueue_ConsidersLastElement()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 5);

        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Guard and exact message must be present.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
