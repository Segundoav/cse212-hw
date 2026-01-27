using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities (2, 5, 3).
    // Expected Result: The item with the highest priority (Item2, Pri:5) should be dequeued first.
    // Defect(s) Found: The loop in Dequeue was not correctly identifying the index of the highest priority item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result);
    }

    [TestMethod]
    // Scenario: Add two items with the same priority (10).
    // Expected Result: The first item added (ItemA) should be dequeued first (FIFO).
    // Defect(s) Found: The code used >= instead of >, which caused it to pick the last item added instead of the first one when priorities were equal.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 10);
        priorityQueue.Enqueue("ItemB", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemA", result);
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: The original code did not check if the queue was empty before attempting to remove an item.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}