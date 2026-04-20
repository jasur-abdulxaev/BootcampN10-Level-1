using N43_HT1.Services.Interfaces;

namespace N43_HT1.Services;

public class AccountService : IAccauntService
{
    private readonly IEmployeeService _employeeService;
    private readonly IPerfomanceService _perfomanceService;

    public AccountService(IEmployeeService employeeService, IPerfomanceService perfomanceService)
    {
        _employeeService = employeeService;
        _perfomanceService = perfomanceService;
    }


    public Task CreateReportAsync(Guid id)
    {
        var result = _employeeService.CreatePerfomanceRecordAsync(id)
            .ContinueWith(_ => _perfomanceService.ReportPerfomanceAsync(id));

        return result;
    }
}
