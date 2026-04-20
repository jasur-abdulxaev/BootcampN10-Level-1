var usernameList = new List<string>
{
    "Alice",
    "Bob",
    "Charlie",
    "David",
    "Eve"
};

var tasks = usernameList.Select(username => Task.Run(() =>
{
    Console.WriteLine($"Task for {username} started.");
    Thread.Sleep(1000); // Simulate work
    Console.WriteLine($"Task for {username} completed.");
}));

Task.WhenAll(tasks).Wait();