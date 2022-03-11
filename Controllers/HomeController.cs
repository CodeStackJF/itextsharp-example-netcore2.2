using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using Northwind.Models.CustomTypes;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using Northwind.Helper;
using Microsoft.EntityFrameworkCore.Storage;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindCTX ctx;
        private IConfiguration Configuration { get; }
        private readonly IHostingEnvironment env;
        public HomeController(IConfiguration configuration, IHostingEnvironment _env, NorthwindCTX _ctx)
        {
            ctx = _ctx;
            env = _env;
            Configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            Document doc = new Document(PageSize.Letter);
            doc.SetMargins(40f, 40f, 40f, 40f);
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);


            doc.AddAuthor("CodeStack");
            doc.AddTitle("Reporte de Ventas");
            doc.Open();


            doc.NewPage();
            doc.NewPage();
            doc.NewPage();


            writer.Close();
            doc.Close();
            ms.Seek(0, SeekOrigin.Begin);

            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfReader reader = new PdfReader(bytes);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            Document document = new Document(pdfDoc);
            Rectangle pageSize;
            PdfCanvas canvas;
            int n = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                PdfPage page = pdfDoc.GetPage(i);
                pageSize = page.GetPageSize();
                canvas = new PdfCanvas(page);
                // draw page numbers on the canvas
            }
            pdfDoc.close();

            return File(ms, "application/pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
