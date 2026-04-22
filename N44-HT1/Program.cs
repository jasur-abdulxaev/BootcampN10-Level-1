using N44_HT1.Service;

var cancellationTokenSource = new CancellationTokenSource(5000);

try
{
    await ExampleForCancellation.Execute(cancellationTokenSource.Token);
}
catch (Exception ex)
{
    Console.WriteLine("Exception bo'ldi: " + ex.Message);
}