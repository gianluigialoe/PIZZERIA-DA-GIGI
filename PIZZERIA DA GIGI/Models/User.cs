using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIZZERIA_DA_GIGI.Models
{
    public class User
    {
        [Key]
        public int UtenteId { get; set; }

        [Required(ErrorMessage = "Il nome dell'utente è obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "L'email dell'utente è obbligatoria.")]
        [EmailAddress(ErrorMessage = "Inserire un indirizzo email valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La password dell'utente è obbligatoria.")]
        public string Password { get; set; } // Dovresti utilizzare una forma di crittografia per la password
        [Required(ErrorMessage = "Il ruolo dell'utente è obbligatorio.")]
        public string Role { get; set; } // Aggiungi la proprietà Role per indicare il ruolo dell'utente
    }
}