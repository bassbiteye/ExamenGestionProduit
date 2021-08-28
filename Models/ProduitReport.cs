using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenGestionProduit.Models
{
    public class ProduitReport
    {

        public int Id { get; set; }
        public string Libelle { get; set; }
        public String Description { get; set; }
        public Double PU { get; set; }
        public Double Quantitee { get; set; }
        public DateTime DatePeremtion { get; set; }
    }
}
