using Microsoft.AspNetCore.Mvc;

namespace WebScrapper.Controllers
{
    [Route("api/sassa")]
    [ApiController]
    public class SassaController: ControllerBase
    {

        private SassaScraper _sassaScraper = new SassaScraper();

        [HttpGet]
        [Route("scrape")]
        public IActionResult ScrapeSassaData()
        {
            try
            {
                string scrapedData = _sassaScraper.ScrapeSassaData();

                if (scrapedData != "Data not found")
                {
                    return Ok(scrapedData); // Return the scraped data in the response.
                }
                else
                {
                    return NotFound("Data not found"); // Handle the case where the data is not found.
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message); // Handle exceptions.
            }
        }
    }
}
