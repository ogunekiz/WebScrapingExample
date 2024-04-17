
using HtmlAgilityPack;
using System.Net;

// Pulling data from the website
string url = "https://webscraper.io/test-sites/e-commerce/allinone/laptops/laptops";
WebClient client = new WebClient();
string htmlContent = client.DownloadString(url);

// Using HtmlAgilityPack to analyze HTML content
HtmlDocument doc = new HtmlDocument();
doc.LoadHtml(htmlContent);

// Selecting the table containing laptops
HtmlNodeCollection laptopNodes = doc.DocumentNode.SelectNodes("//div[@class='col-md-4 col-xl-4 col-lg-4']");

if (laptopNodes != null)
{
    foreach (HtmlNode laptopNode in laptopNodes)
    {
        // Find descriptions and prices
        string title = laptopNode.SelectSingleNode(".//a[@class='title']").InnerText.Trim();
        string description = laptopNode.SelectSingleNode(".//p[@class='description card-text']").InnerText.Trim();
        string price = laptopNode.SelectSingleNode(".//h4[@class='float-end price card-title pull-right']").InnerText.Trim();

        Console.WriteLine("Title: " + title);
        Console.WriteLine("Description: " + description);
        Console.WriteLine("Price: " + price);
        Console.WriteLine();
    }
}

else
{
    Console.WriteLine("The laptop was not found.");
}



