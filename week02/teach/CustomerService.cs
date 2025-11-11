/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    
    public static void Run()
    {
       // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        var cs = new CustomerService(10);
        Console.WriteLine(cs);

        // === Test 1 ===
        // Scenario: Add one customer and serve them
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();  // Prompt user to enter customer details
        service.ServeCustomer();   // Display and remove the first customer
        Console.WriteLine("=================");
        // Defect(s) Found: 
        // Test 2
        // Scenario: 
        // Expected Result: 


        Console.WriteLine("Test 2");
        // Defect(s) Found:
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");
        Console.WriteLine("=================");
        // Add more Test Cases As Needed Below
    }
     
    // Internal queue to hold customer objects
    private readonly List<Customer> _queue = new();

    // Maximum number of customers allowed in the queue
    private readonly int _maxSize;

   
    public CustomerService(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

     /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        // Format customer info for display
        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    public void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();
        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

     /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}