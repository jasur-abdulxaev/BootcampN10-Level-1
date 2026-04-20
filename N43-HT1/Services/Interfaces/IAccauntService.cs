using System;
using System.Collections.Generic;
using System.Text;

namespace N43_HT1.Services.Interfaces;

public interface IAccauntService
{
    Task CreateReportAsync(Guid id);
}
