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


        /*
        [HttpGet]
        public ActionResult Index(string mes)
        {
            if (mes != "Ninguno")
            {
                int Mes = Convert.ToInt32(mes);

                return View(db.SalidaEmpleados.Where(d => d.FechaSalida.Month == Mes).ToList());
            }
            else {
                return View(db.SalidaEmpleados.ToList());
            }

        }
        */

        public ActionResult Listado()
        {

            return View(db.SalidaEmpleados.ToList());
        }


        [HttpPost]
        public ActionResult Listado(string mes)
        {
            if (mes != "Ninguno")
            {
                int Mes = Convert.ToInt32(mes);

                return View(db.SalidaEmpleados.Where(d => d.FechaSalida.Month == Mes).ToList());
            }
            else
            {

                return View(db.SalidaEmpleados.ToList());
            }

        }

        // GET: Salida/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Salida/Edit/5
        public ActionResult Create()
        {
            ViewBag.PersonList = new SelectList(db.Empleados.Where(m=>m.estatus == "Activo"), "Id", "Nombre");
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
               return RedirectToAction("Listado");
              
            }
            catch { }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            return View();
        }

     
    }
}
