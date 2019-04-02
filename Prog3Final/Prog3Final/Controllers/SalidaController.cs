using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;
namespace Prog3Final.Controllers
{
    public class SalidaController : Controller
    { 
        private DBRecursosHumanos db= new DBRecursosHumanos();

        // GET: Salida
        public ActionResult Index()
        {
            return View(db.SalidaEmpleados.ToList());
        }

        // GET: Salida/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Salida/Edit/5
        public ActionResult Create()
        {
            ViewBag.Encargado = new SelectList(db.Empleados, "Id", "Codigo");
            return View( );
        }

        // POST: Salida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalidaEmpleado salida)
        {
            try
            {
                    
                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();
    
               
                int IdSalida = EmpleadoSalida.Id;
                Empleado EmpleadoStatus = db.Empleados.Where(m => m.estatus == "Activo" && m.Id == salida.IdEmpleado).First();
                EmpleadoStatus.estatus = "Inactivo";

                salida.IdEmpleado = IdSalida;
                db.Entry(EmpleadoStatus).State = EntityState.Modified;
                db.SalidaEmpleados.Add(salida);
                db.SaveChanges();
               return RedirectToAction("Index");
              
            }
            catch { }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            return View();
        }

     
    }
}
