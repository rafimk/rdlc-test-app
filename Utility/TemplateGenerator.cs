using System.Text;

namespace rdlc_test_app.Utility;

public static class TemplateGenerator
{
    public static string GetHTMLString()
    {  
	    var membershipNo = "AUH0001";
	    var date = "01/01/2020";
	    var fullName = "Muhammed Rafi";
	    var district = "KASARAGOAD";
	    var mandalam = "TRIKARPUR";
	    var emirate = "DUBAI";
	    var area = "AUH";
	    var collectedBy = "Rafi";
        var employees = DataStorage.GetAllEmployees();
        var sb = new StringBuilder();
        sb.Append(@"<html>
					<head>
					</head>
					<body>
						<div class='id-card-holder'>
							<div class='id-card'>
								<div class='header'>
									<img src='http://member.uaekmcc.com/_next/image?url=%2Fimages%2Fmembership_card_header.png&w=128&q=75'>
								</div>
								<div class='photo'>
								</div>
								<h2>Name : </h2>
								<div class='qr-code'>
								</div>
								<h3>Membership No : <strong></strong></h3>
								<hr>
								<p>Registration Date<p>
								<p>District </p>
								<p>Muncipality/Mandalam </p>
						  <p>Emirates Area </p>
						  <p>Agent </p>
							</div>
						</div>
					</body>
</html>");
						return sb.ToString();
				}
}