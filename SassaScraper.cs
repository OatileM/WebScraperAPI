using HtmlAgilityPack;

namespace WebScrapper
{
    public class SassaScraper
    {
        private string baseUrl = "https://www.sassa.gov.za";

        public SassaScraper()
        {
            // Constructor, initialize any necessary objects or settings.
        }

        public string ScrapeSassaData()
        {
            // Uses HtmlAgilityPack to load and parse web pages.
            // Extracts data from the SASSA website.
            // Return the scraped data in the desired format.
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = baseUrl + "/SitePages/Supplier-Registration-Forms.aspx";
                    string htmlContent = client.GetStringAsync(url).Result;

                    // Load the HTML content into an HtmlDocument for parsing.
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(htmlContent);

                    // Use XPath to select specific elements or data from the HTML.
                    var dataNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"cbqwpctl00_ctl36_g_2ed11b4d_7320_4753_b7b0_ca0c83357450\"]");

                    if (dataNode != null)
                    {
                        string extractedData = dataNode.InnerText;

                        // Format the extracted data as needed. For example, converting it to JSON.
                        var formattedData = new
                        {
                            Data = extractedData
                        };

                        // Serialize the formatted data to JSON.
                        string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(formattedData);

                        return jsonResult;
                    }
                    else
                    {
                        return "Data not found"; // Handles the case where the data is not found on the page.
                    }
                }
            }
            catch (Exception ex)
            {
                // Handles exceptions, e.g., network issues, invalid URLs, or HTML parsing errors.
                Console.WriteLine("Error: " + ex.Message);
                return "Error occurred during scraping";
            }

        }

    }
}
