namespace rdlc_test_app.Controllers;

public interface IReportService
{
    byte[] GenerateReportAsync(string reportName);
}