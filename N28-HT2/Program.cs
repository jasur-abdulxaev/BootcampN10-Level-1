using N28_HT2.Model;

ClonableList<StorageFile> clonableList = new ClonableList<StorageFile>
{ new StorageFile("File1", "Description1", 10.5m),
  new StorageFile("File2", "Description2", 20.0m),
  new StorageFile("File3", "Description3", 15.75m)
};

var clonedList = (ClonableList<StorageFile>)clonableList.Clone();

//update original list
var firstItem = clonableList.First();
firstItem.Description = "Updated Description";

// clone listni elementlarini chiqarish
clonedList.ForEach(Console.WriteLine);