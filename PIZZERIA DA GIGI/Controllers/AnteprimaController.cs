﻿using PIZZERIA_DA_GIGI.Models;
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
                    return RedirectToAction("Index");
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
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                // Calcola il costo totale dalla somma dei prezzi delle pizze moltiplicati per la quantità nei dettagli dell'ordine
                decimal costoTotale = db.DettaglioOrdines
                    .Where(d => d.OrdineId == ordine.OrdineId)
                    .Join(db.Pizzas, dettaglio => dettaglio.PizzaId, pizza => pizza.PizzaId,
                        (dettaglio, pizza) => dettaglio.Quantita * pizza.Prezzo)
                    .Sum();

                ordine.CostoTotale = costoTotale;

              
            }

            return View(ordine);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiOrdine(Ordine ordine, List<DettaglioOrdine> dettagliOrdine)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Imposta l'ID utente prendendolo dal cookie
                    ordine.UtenteId = Convert.ToInt32(User.Identity.Name);

                    // Calcola il costo totale dell'ordine
                    ordine.CostoTotale = dettagliOrdine.Sum(d => d.Pizza.Prezzo * d.Quantita);
                    // Aggiungi l'ordine al database
                    db.Ordines.Add(ordine);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Gestisci l'eccezione qui
                    // Puoi loggare l'errore, mostrare un messaggio all'utente, ecc.
                    ModelState.AddModelError(string.Empty, "Si è verificato un errore durante l'aggiunta dell'ordine.");
                    return View(ordine);
                }
            }

            return View(ordine);
        }


    }
}







 