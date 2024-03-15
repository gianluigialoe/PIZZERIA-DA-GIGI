using PIZZERIA_DA_GIGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIZZERIA_DA_GIGI.Controllers
{
    public class ChiamteAsincroneController : Controller
    {
        DBContext db = new DBContext();
        // GET: ChiamteAsincrone
        public ActionResult Index()
        {
            // Recupera gli ordini evasi
            var ordiniEvasi = db.Ordines.Where(o => o.Evaso == true).ToList();

            // Calcola la somma dei costi totali degli ordini evasi
            decimal costoTotaleOrdiniEvasi = ordiniEvasi.Sum(o => o.CostoTotale);

            // Crea un oggetto anonimo contenente sia la lista degli ordini evasi che il costo totale
            var result = new
            {
                CostoTotaleOrdiniEvasi = costoTotaleOrdiniEvasi,
                OrdiniEvasi = ordiniEvasi
            };

            // Restituisci il risultato come JSON
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Data(DateTime data)
        {
            // Recupera gli ordini evasi per la data specificata
            var ordiniEvasi = db.Ordines.Where(o => o.Evaso == true && o.DataOrdine.Date == data.Date).ToList();

            // Calcola la somma dei costi totali degli ordini evasi per la data specificata
            decimal costoTotaleOrdiniEvasi = ordiniEvasi.Sum(o => o.CostoTotale);

            // Restituisci il risultato come JSON
            return Json(new { Data = data.Date, TotaleIncassato = costoTotaleOrdiniEvasi }, JsonRequestBehavior.AllowGet);
        }
    }
}