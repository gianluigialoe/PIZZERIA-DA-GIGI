using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIZZERIA_DA_GIGI.Models;

namespace PIZZERIA_DA_GIGI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly DBContext db = new DBContext();

        // GET: Users/Index
        public ActionResult Index()
        {
            // Recupera gli ordini evasi
            var ordiniEvasi = db.Ordines.Where(o => o.Evaso == true).ToList();

            // Calcola la somma dei costi totali degli ordini evasi
            decimal costoTotaleOrdiniEvasi = ordiniEvasi.Sum(o => o.CostoTotale);

            // Passa la lista degli ordini evasi e il costo totale alla vista
            ViewBag.CostoTotaleOrdiniEvasi = costoTotaleOrdiniEvasi;
            return View("Index", ordiniEvasi);
        }
        public ActionResult ordini()
        {
            var Ordines = db.Ordines.ToList();
            return View(Ordines);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetEvaso(int ordineId)
        {
            // Recupera l'ordine dal database
            var ordine = db.Ordines.Find(ordineId);

            if (ordine != null)
            {
                // Imposta lo stato "Evaso" su true
                ordine.Evaso = true;

                // Salva le modifiche nel database
                db.SaveChanges();
            }
            else
            {
                // Gestisci il caso in cui l'ordine non sia trovato nel database
                // Ad esempio, restituisci una vista con un messaggio di errore
                return HttpNotFound();
            }

            // Reindirizza alla vista degli ordini dopo l'aggiornamento
            return RedirectToAction("index");
        }







        // GET: Users/CreatePizza
        public ActionResult CreatePizza()
        {
            return View();
        }

        // POST: Users/CreatePizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePizza(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizza);
        }




        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        // GET: Pizze/Delete/5
        public ActionResult Delete()
        {
            // Ottieni la lista di tutte le pizze per la visualizzazione
            var pizzaList = db.Pizzas.ToList();

            // Passa la lista delle pizze alla vista
            return View(pizzaList);
        }

        // POST: Pizze/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int pizzaIdToDelete)
        {
            // Trova la pizza dal contesto del database utilizzando l'ID fornito
            Pizza pizza = db.Pizzas.Find(pizzaIdToDelete);

            if (pizza != null)
            {
                // Elimina la pizza
                db.Pizzas.Remove(pizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
