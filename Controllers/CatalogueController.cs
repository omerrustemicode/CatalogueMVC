using KatalogueMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KatalogueMVC.Controllers
{
    public class CatalogueController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve list of catalogues from your data source
            var catalogues = GetCataloguesFromDataSource();
            return View(catalogues);
        }

        [HttpGet]
        public IActionResult ViewPdf(string pdfUrl)
        {
            // Validate pdfUrl to prevent directory traversal attacks
            var modifiedPdfUrl = $"{pdfUrl}";
            var model = new Catalogue { PdfUrl = modifiedPdfUrl };
            return View(model);
        }

        private List<Catalogue> GetCataloguesFromDataSource()
        {
            // Read JSON file containing catalogue data
            var jsonFilePath = "catalogueData.json"; // Update the path as per your file location
            var jsonString = System.IO.File.ReadAllText(jsonFilePath);

            // Deserialize JSON to list of Catalogue objects
            var catalogues = JsonConvert.DeserializeObject<List<Catalogue>>(jsonString);

            return catalogues;
        }
    }
}
