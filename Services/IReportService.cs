namespace rdlc_test_app.Controllers;

public interface IReportService
{
    Task<byte[]> GenerateReportAsync(string reportName);
}