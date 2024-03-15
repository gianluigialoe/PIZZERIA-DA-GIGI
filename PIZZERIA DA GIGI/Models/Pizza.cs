using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIZZERIA_DA_GIGI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        [Required(ErrorMessage = "Il nome della pizza è obbligatorio.")]
        public string Nome { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio.")]
        public decimal Prezzo { get; set; }

        [Required(ErrorMessage = "Il tempo di consegna è obbligatorio.")]
        public int TempoConsegna { get; set; }

        [Required(ErrorMessage = "Gli ingredienti della pizza sono obbligatori.")]
        public string Ingredienti { get; set; }
    }
}