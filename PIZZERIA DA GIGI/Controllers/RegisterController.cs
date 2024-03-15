using PIZZERIA_DA_GIGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PIZZERIA_DA_GIGI.Controllers
{
    public class RegisterController : Controller
    {
        // Creazione di un'istanza del contesto del database
        private readonly DBContext db = new DBContext();

        // Azione HTTP GET per la visualizzazione della pagina di registrazione
        [HttpGet]
        public ActionResult Register()
        {
            // Verifica se l'utente è già autenticato e, in tal caso, lo reindirizza alla pagina principale
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");

            // Restituisce la vista di registrazione
            return View();
        }

        // Azione HTTP POST per gestire il tentativo di registrazione
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            // Verifica se l'username è già presente nel database
            if (db.Users.Any(u => u.Nome == user.Nome))
            {
                TempData["ErrorRegister"] = "L'username inserito è già in uso. Scegli un altro username.";
                return RedirectToAction("Register");
            }

            // Assegna il ruolo "User" all'utente
            user.Role = "User";

            // Aggiunge il nuovo utente al database
            db.Users.Add(user);
            db.SaveChanges();

            // Autentica l'utente appena registrato
            FormsAuthentication.SetAuthCookie(user.UtenteId.ToString(), false);

            // Reindirizza alla pagina principale dopo la registrazione
            return RedirectToAction("Index", "Home");
        }
    }
}
