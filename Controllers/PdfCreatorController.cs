using System.Text.RegularExpressions;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using rdlc_test_app.Utility;

namespace rdlc_test_app.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfCreatorController : ControllerBase
{
     private IConverter _converter;
    public PdfCreatorController(IConverter converter)
    {
        _converter = converter;
    }

    [HttpGet]
    public IActionResult CreatePDF()
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report",
            Out = @"C:\PDFCreator\Employee_Report.pdf"
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHTMLString(),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };
        _converter.Convert(pdf);
        return Ok("Successfully created PDF document.");
    }

    [HttpGet("/download")]
    public ActionResult Get(string reportName)
    {
         var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report",
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHTMLString(),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };
        
        var returnString = _converter.Convert(pdf);;
        return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, reportName + ".pdf");
    }
}