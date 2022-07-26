using Microsoft.AspNetCore.Mvc;

namespace rdlc_test_app.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("{reportName}")]
    public ActionResult Get(string reportName)
    {
        var returnString = _reportService.GenerateReportAsync(reportName);
        return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, reportName + ".pdf");
    }

}
