using PIZZERIA_DA_GIGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PIZZERIA_DA_GIGI.Controllers
{
    public class LoginController : Controller
    {
        // Creazione di un'istanza del contesto del database
        DBContext db = new DBContext();

        // Azione HTTP GET per la visualizzazione della pagina di login
        [HttpGet]
        public ActionResult Login()
        {
            // Verifica se l'utente è già autenticato e, in tal caso, lo reindirizza alla pagina principale
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                {
                    return RedirectToAction("Index", "Users"); // Reindirizza gli utenti admin alla pagina principale dell'admin
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Reindirizza gli altri utenti alla pagina principale
                }
            }

            // Restituisce la vista di login
            return View();
        }
    

        // Azione HTTP POST per gestire il tentativo di accesso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user, bool keepLogged)
        {
            // Cerca un utente nel database con il nome utente e la password forniti
            var loggedUser = db.Users.Where(u => u.Nome == user.Nome && u.Password == user.Password).FirstOrDefault();

            // Se l'utente non viene trovato, imposta un flag di errore e reindirizza alla pagina di login
            if (loggedUser == null)
            {
                TempData["ErrorLogin"] = true;
                return RedirectToAction("Login");
            }

            // Se l'utente è autenticato con successo, imposta un cookie di autenticazione e reindirizza alla pagina principale
            FormsAuthentication.SetAuthCookie(loggedUser.UtenteId.ToString(), keepLogged);
            return RedirectToAction("Index", "Anteprima");
        }

        // Azione HTTP POST per gestire il logout
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // Effettua il logout rimuovendo il cookie di autenticazione e reindirizza alla pagina principale
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}