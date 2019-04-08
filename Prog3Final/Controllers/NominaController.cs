using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Prog3Final.Controllers
{
    public class NominaController : Controller
    {
         
        private DBRecursosHumanos db = new DBRecursosHumanos();

        // GET: Nomina
        public ActionResult Index(string Busqueda, string valor) 
        {
            int d = 0;
           

            if (Busqueda == "Mes") {
          
                switch (valor)
                {
                    case "Enero":
                        valor = "1";
                        d = int.Parse(valor);
                        break;
                    case "Febrero":
                        valor = "2";
                        d = int.Parse(valor);
                        break;
                    case "Marzo":
                        valor = "3";
                        d = int.Parse(valor);
                        break;
                    case "Abril":
                        valor = "4";
                        d = int.Parse(valor);
                        break;
                    case "Mayo":
                        valor = "5";
                        d = int.Parse(valor);
                        break;
                    case "Junio":
                        valor = "6";
                        d = int.Parse(valor);
                        break;
                    case "Julio":
                        valor = "7";
                        d = int.Parse(valor);
                        break;
                    case "Agosto":
                        valor = "8";
                        d = int.Parse(valor);
                        break;
                    case "Septiembre":
                        valor = "9";
                        d = int.Parse(valor);
                        break;
                    case "Octubre":
                        valor = "10";
                        d = int.Parse(valor);
                        break;
                    case "Noviembre":
                        valor = "11";
                        d = int.Parse(valor);
                        break;
                    case "Diciembre":
                        valor = "12";
                        d = int.Parse(valor);
                        break;
                    default:
                        valor = "0";
                        break;
                }
                
                return View(db.Nominas.Where(x => x.Mes == d).ToList());
            }
            else 
            {
                try {
                    if (!valor.IsEmpty())
                    {
                        d = int.Parse(valor);
                    }
                    else
                    {
                        valor = "0";
                    }
                }
                catch { }
              

                if (valor == "0") return View(db.Nominas.ToList());

                else return View(db.Nominas.Where(x => x.Año == d).ToList());
            }
        }
 
        public ActionResult VistaNomina()
        {
   
            ViewBag.TotalSalario = db.Empleados.Where(m => m.estatus == "Activo").Sum(m => m.Salario); 
            return View();
        }

        // POST NOMINA
        [HttpPost]
        public ActionResult VistaNomina(Nomina nominas)
        {
            try
            {
                db.Nominas.Add(nominas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch {   }
            return View();
        }
    }
}
