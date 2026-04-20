using N28_HT1.Models;

var eventStack = new EventStack<Event>();

eventStack.Push(new Event("Birthday Party", new DateTime(2024, 7, 20)));
eventStack.Push(new Event("Conference", new DateTime(2024, 8, 15)));
eventStack.Push(new Event("Wedding", new DateTime(2024, 9, 10)));

Console.WriteLine(eventStack.Peek());

