﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog3Final
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBRecursosHumanos : DbContext
    {
        public DBRecursosHumanos()
            : base("name=DBRecursosHumanos")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Licencia> Licencias { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<SalidaEmpleado> SalidaEmpleados { get; set; }
        public virtual DbSet<Vacacione> Vacaciones { get; set; }
    }
}
