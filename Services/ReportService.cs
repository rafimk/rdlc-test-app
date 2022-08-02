using System.Reflection;
using System.Text;
using AspNetCore.Reporting;

namespace rdlc_test_app.Controllers;

public class ReportService : IReportService
{
   public byte[] GenerateReportAsync(string reportName)
    {

        string filePath = "./ReportFiles/";

        string fileName = Path.Combine(filePath, "ReceiptV1.rdlc");
        Console.WriteLine($"File Path is {fileName}");

        // string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ReportAPI.dll", string.Empty);
        // string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("windows-1252");

        LocalReport report = new LocalReport(fileName);

        parameters.Add("MembershipNo", "AUD0001");
        parameters.Add("FullName", "Muhammed");
        parameters.Add("State", "Abu Dhabi");
        parameters.Add("District", "Kasargod");
        parameters.Add("Mandalam", "Trikaripur");
        parameters.Add("Panchayath", "Trikaripur");
        parameters.Add("MembershipDate", "22/05/2022");
        parameters.Add("CollectedBy", "Abdul Hameed");
        parameters.Add("Area", "Musaffah");

        //report.AddDataSource("dsUsers", userList);
        var result = report.Execute(GetRenderType("pdf"), 1, parameters);
        return result.MainStream;
    }

    private RenderType GetRenderType(string reportType)
    {
        var renderType = RenderType.Pdf;
        switch (reportType.ToLower())
        {
            default:
            case "pdf":
                renderType = RenderType.Pdf;
                break;
            case "word":
                renderType = RenderType.Word;
                break;
            case "excel":
                renderType = RenderType.Excel;
                break;
        }

        return renderType;
    }
}