﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prog3Final.Controllers
{
    public class PermisosController : Controller
    {
        private DBRecursosHumanos db = new DBRecursosHumanos();

        // GET: Permisos
        public ActionResult Index()
        {
            return View(db.Permisos.ToList());
        }

        // GET: Permisos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            ViewBag.Encargado = new SelectList(db.Empleados, "Id", "Codigo");
            return View();
        }

        // POST: Permisos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Permiso permiso)
        {
            try
            {
                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();
                int IdSalida = EmpleadoSalida.Id;
                permiso.IdEmpleado = IdSalida;
                db.Permisos.Add(permiso);
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