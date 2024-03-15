using PIZZERIA_DA_GIGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PIZZERIA_DA_GIGI.Controllers
{
    [Authorize(Roles = "User")]
    public class AnteprimaController : Controller
    {
        private readonly DBContext db = new DBContext();

        // GET: Anteprima/Index
        public ActionResult Index()
        {
            var pizzaList = db.Pizzas.ToList();

            // Passa la lista delle pizze alla vista
            return View(pizzaList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ADD(DettaglioOrdine dettaglioOrdine, int quantita)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dettaglioOrdine.UtenteId = Convert.ToInt32(User.Identity.Name);

                    // Aggiungi il dettaglio ordine al database
                    db.DettaglioOrdines.Add(dettaglioOrdine);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    // Gestisci l'eccezione qui
                    // Puoi loggare l'errore, mostrare un messaggio all'utente, ecc.
                    ModelState.AddModelError(string.Empty, "Si è verificato un errore durante l'aggiunta del dettaglio ordine.");
                    return View(dettaglioOrdine);
                }
            }

            return View(dettaglioOrdine);
        }

        //// GET: Ordine/Create
        //// GET: Ordine/Create
        //public ActionResult Create()
        //{
        //    //// Prendi l'UtenteId dal cookie
        //    //dettaglioOrdine.UtenteId = Convert.ToInt32(User.Identity.Name);

        //    //var ordine = new Ordine
        //    //{
        //    //    UtenteId = utenteId,
        //    //    DataOrdine = DateTime.Now
        //    //};

        //    return View(ordine);
        //}

        // POST: Ordine/Create

        public ActionResult Create()
        {
            // Crea una nuova istanza di Ordine per il form di creazione
            var nuovoOrdine = new Ordine();

            // Inizializza il campo DataOrdine con la data corrente
            nuovoOrdine.DataOrdine = DateTime.Now;

            // Restituisci la vista con il nuovo ordine
            return View(nuovoOrdine);
        }
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult AggiungiOrdine(Ordine ordine, List<DettaglioOrdine> dettagliOrdine)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                int utenteId;
        //                if (int.TryParse(User.Identity.Name, out utenteId))
        //                {
        //                    ordine.UtenteId = utenteId;

        //                    try
        //                    {
        //                        // Calcola il costo totale dell'ordine
        //                        ordine.CostoTotale = dettagliOrdine.Sum(d => d.Pizza.Prezzo * d.Quantita);

        //                        // Aggiungi l'ordine al database
        //                        db.Ordines.Add(ordine);
        //                        db.SaveChanges();

        //                        return RedirectToAction("Index");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Gestisci l'eccezione qui
        //                        ModelState.AddModelError(string.Empty, "Si è verificato un errore durante l'aggiunta dell'ordine.");
        //                        return View(ordine);
        //                    }
        //                }
        //                else
        //                {
        //                    // Gestisci il caso in cui il valore dell'ID utente non sia valido
        //                    ModelState.AddModelError(string.Empty, "Impossibile convertire l'ID utente.");
        //                    return View(ordine);
        //                }
        //            }

        //            return View(ordine);
        //        }
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiOrdine(Ordine ordine)
        {
            ordine.UtenteId = Convert.ToInt32(User.Identity.Name);
            ordine.DataOrdine = DateTime.Now;
            ordine.Evaso = false;
            ordine.CostoTotale = 0;


            // Calcola il costo totale dell'ordine
            ordine.CostoTotale = db.DettaglioOrdines.Where(d => d.UtenteId == ordine.UtenteId && d.OrdineId == null).Sum(d => d.Pizza.Prezzo * d.Quantita);


            // Aggiungi l'ordine al database
            db.Ordines.Add(ordine);
            db.SaveChanges();

            return RedirectToAction("finale", "Anteprima");

            // Gestisci l'eccezione qui






        }

        public ActionResult finale()
        {
            var ordineList = db.Ordines.ToList();

            // Passa la lista delle pizze alla vista
            return View(ordineList);

        }
    }
}




















