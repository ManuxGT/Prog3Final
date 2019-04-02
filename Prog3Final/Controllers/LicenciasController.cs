using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prog3Final.Controllers
{
    public class LicenciasController : Controller
    {
        private DBRecursosHumanos db = new DBRecursosHumanos(); 
        // GET: Licencias
        public ActionResult Index()
        {
            return View(db.Licencias.ToList());
        }

        // GET: Licencias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Licencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licencias/Create
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Create(Licencia licencia)
        {
            try
            {
                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();
                int IdSalida = EmpleadoSalida.Id;
                licencia.IdEmpleado = IdSalida;
                db.Licencias.Add(licencia);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
            }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            return View();
        }

      
    }
}
