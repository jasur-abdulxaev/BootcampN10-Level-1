using System;
using System.Collections.Generic;
using System.Text;

namespace N22_HT2.Interfaces
{
    public interface IReview
    {
        Guid Id { get; set; }
        int Star { get; set; }
        string Message { get; set; }
    }
}
