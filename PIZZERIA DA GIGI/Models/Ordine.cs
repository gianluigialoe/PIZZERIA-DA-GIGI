using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIZZERIA_DA_GIGI.Models
{
    public class Ordine
    {
        [Key]
        public int OrdineId { get; set; }

        [Required(ErrorMessage = "L'ID dell'utente è obbligatorio.")]
        public int UtenteId { get; set; }

        [Required(ErrorMessage = "La data dell'ordine è obbligatoria.")]
        public DateTime DataOrdine { get; set; }

        [Required(ErrorMessage = "Lo stato 'Evaso' dell'ordine è obbligatorio.")]
        public bool? Evaso { get; set; }

        [ForeignKey("UtenteId")]
        public virtual User User { get; set; }

        public virtual ICollection<DettaglioOrdine> DettagliOrdine { get; set; }


        [Required(ErrorMessage = "Il costo totale è obbligatorio.")]
        public decimal CostoTotale { get; set; }

        [Required(ErrorMessage = "L'indirizzo di spedizione è obbligatorio.")]
        public string IndirizzoSpedizione { get; set; }

        public string Note { get; set; }
    }

}
