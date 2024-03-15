using PIZZERIA_DA_GIGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIZZERIA_DA_GIGI.Controllers
{
    public class OrdiniController : Controller
    {
        private readonly DBContext _context;

        public OrdiniController()
        {
            _context = new DBContext(); // Inizializzazione del contesto del database
        }

        [HttpPost]
        public ActionResult AggiungiDettaglioOrdine(int ordineId, int pizzaId, int quantita)
        {
            // Trova l'ordine corrente dal database
            var ordine = _context.Ordines.Find(ordineId);

            if (ordine == null)
            {
                // Gestione errore: ordine non trovato
                return RedirectToAction("ErroreOrdineNonTrovato", "Error");
            }

            // Aggiungi un nuovo dettaglio all'ordine
            var nuovoDettaglio = new DettaglioOrdine
            {
                OrdineId = ordineId,
                PizzaId = pizzaId,
                Quantita = quantita
            };

            // Aggiorna lo stato "Evaso" dell'ordine a true
            ordine.Evaso = true;

            // Aggiungi il dettaglio all'ordine e salva le modifiche
            _context.DettaglioOrdines.Add(nuovoDettaglio);
            _context.SaveChanges();

            // Reindirizza l'utente alla pagina degli ordini
            return RedirectToAction("Index", "Ordini");
        }
    }
}