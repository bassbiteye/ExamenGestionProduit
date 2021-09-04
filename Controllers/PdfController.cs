using ExamenGestionProduit.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace ExamenGestionProduit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        readonly IGeneratePdf _generatePdf;
        private readonly ExamenContext _context;

        public PdfController(IGeneratePdf generatePdf, ExamenContext context)
        {
            _context = context;

            _generatePdf = generatePdf;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> ListProduit()
        {
            var prodObj = _context.produits.ToList();


            return await _generatePdf.GetPdf("Views/Produit/Produit.cshtml", prodObj);

        }

    }
}

