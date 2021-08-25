using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenGestionProduit.Models
{
    public class Produit
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Libelle"), MaxLength(80), Required(ErrorMessage = "*")]
        public string Libelle { get; set; }
        [Display(Name = "Description "), MaxLength(200), Required(ErrorMessage = "*")]
        public int Description { get; set; }
        [Display(Name = "Prix Unitaire "), Required(ErrorMessage = "*")]
        public Double PU { get; set; }
        [Display(Name = "Quantité en stock"),  Required(ErrorMessage = "*")]
        public Double Quantitee { get; set; }   
        [Display(Name = "Date Peremtion"), DataType(DataType.DateTime), Required(ErrorMessage = "*")]
        public DateTime DatePeremtion { get; set; }
    }
}
