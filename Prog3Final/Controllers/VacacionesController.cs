﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prog3Final.Controllers
{
    public class VacacionesController : Controller
    {
        private DBRecursosHumanos db = new DBRecursosHumanos();

        // GET: Vacaciones
        public ActionResult Index()
        {
            return View(db.Vacaciones.ToList());
        }

        // GET: Vacaciones/Create
        public ActionResult Create()
        {
            ViewBag.PersonList = new SelectList(db.Empleados.Where(m => m.estatus == "Activo"), "Id", "Nombre");
            return View();
        }

        // POST: Vacaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vacacione vacaciones)
        {
            try
            {
                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();

                int IdSalida =  EmpleadoSalida.Id;
                vacaciones.IdEmpleado = IdSalida;
                db.Vacaciones.Add(vacaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            return View();
        }

    }
}
