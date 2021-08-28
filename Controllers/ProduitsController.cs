using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenGestionProduit.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenGestionProduit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly ExamenContext _context;

        public ProduitsController(ExamenContext context)
        {
            _context = context;
        }


        // GET: api/<ProduitsController>
        [HttpGet]
        public JsonResult list()
        {
            return new JsonResult(_context.produits.ToList());
        }

        // GET api/<ProduitsController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var produit = _context.produits.Find(id);
           
            return new JsonResult(produit);
        }

        // POST api/<ProduitsController>
        [HttpPost]
        public JsonResult create([Bind("Libelle,Description,PU,Quantitee,DatePeremtion")] Produit produit)
        {
            _context.Add(produit);
            _context.SaveChanges();
            return new JsonResult("produit créé");
        }

        // PUT api/<ProduitsController>/5
        [HttpPut("{id}")]
        public JsonResult edit(int id, [Bind("Libelle,Description,PU,Quantitee,DatePeremtion")] Produit produit)
        {
            if (id == produit.Id)
            {
                _context.Update(produit);
                _context.SaveChanges();
                return new JsonResult("produit modifié");
            }
            else
            {
                return new JsonResult("produit introuvable");

            }
        }

        // DELETE api/<ProduitsController>/5
        [HttpDelete("{id}")]
        public JsonResult delete(int id)
        {
            var produit = _context.produits.Find(id);
            _context.produits.Remove(produit);
            _context.SaveChanges();
            return new JsonResult("produit supprimé");
        }
        // POST api/<ProduitsController>recherche
        [HttpPost("recherche", Name = "recherche")]
        public JsonResult recherche(string Libelle, DateTime DatePeremtion)
        {

            var produits = _context.produits.Where(p => p.Libelle == Libelle && p.DatePeremtion == DatePeremtion);
            if (produits == null) { 
                return new JsonResult("Aucun produit trouvé");
            }
            return new JsonResult(produits.ToList());
        }
    }
}
