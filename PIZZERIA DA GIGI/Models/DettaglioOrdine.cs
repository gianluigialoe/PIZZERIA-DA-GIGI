using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIZZERIA_DA_GIGI.Models
{
    public class DettaglioOrdine
    {
        [Key]
        public int DettaglioOrdineId { get; set; }

        public int? OrdineId  { get; set; }

        [Required(ErrorMessage = "L'ID della pizza è obbligatorio.")]
        public int PizzaId { get; set; }


        [Required(ErrorMessage = "La quantità è obbligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantità deve essere maggiore di 0.")]
        public int Quantita { get; set; }

        [ForeignKey("OrdineId")]
        public virtual Ordine Ordine { get; set; }

        [ForeignKey("PizzaId")]
        public virtual Pizza Pizza { get; set; }

        
        public int? UtenteId { get; set; }
        public User Users {  get; set; }
    }

}