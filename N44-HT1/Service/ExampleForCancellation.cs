using System;
using System.Collections.Generic;
using System.Text;

namespace N44_HT1.Service;

public static class ExampleForCancellation
{
    public static async ValueTask Execute(CancellationToken cancellationToken)
    {
        for (int index = 0; index < 100; index++)
        {
            await Task.Delay(200, cancellationToken);
        }
    }
}