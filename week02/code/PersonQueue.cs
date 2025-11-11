public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {      // FIXED: Add to end (back of queue)
        _queue.Add(person); 
    }

    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {    // FIXED: Proper error handling
            throw new InvalidOperationException("Queue is empty"); 
        }
        // Remove from front
        var person = _queue[0];    
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }
}