using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace ExamenGestionProduit.Models
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Prenom"), MaxLength(80), Required(ErrorMessage = "*")]

        public string FirstName { get; set; }
        [Display(Name = "Nom"), MaxLength(80), Required(ErrorMessage = "*")]

        public string LastName { get; set; }
        [Display(Name = "Nom utilisateur"), MaxLength(80), Required(ErrorMessage = "*")]

        public string Username { get; set; }

        [JsonIgnore]
        [Display(Name = "Mot de passe"), MaxLength(80), Required(ErrorMessage = "*")]

        public string Password { get; set; }
    }
}
