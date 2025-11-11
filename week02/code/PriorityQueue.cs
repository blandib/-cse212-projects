public class PriorityQueue
{
    private List<PriorityItem> _queue = new();
    private int _insertionCounter = 0;

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority, _insertionCounter++);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // FIXED: Changed to _queue.Count
        {
            // For higher priority items, always select them
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
            // For equal priority items, select the one with lower insertion order (FIFO)
            else if (_queue[index].Priority == _queue[highPriorityIndex].Priority)
            {
                if (_queue[index].InsertionOrder < _queue[highPriorityIndex].InsertionOrder)
                {
                    highPriorityIndex = index;
                }
            }
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // FIXED: Actually remove the item from the queue
        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }
    internal int InsertionOrder { get; set; } // FIXED: Added to track FIFO for equal priorities

    internal PriorityItem(string value, int priority, int insertionOrder)
    {
        Value = value;
        Priority = priority;
        InsertionOrder = insertionOrder;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}