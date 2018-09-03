using PryFincasCafeteras.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PryFincasCafeteras.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Asociado()
        {
            try
            {
                string sql= @"select a.Id, a.Parentesco, a.Nombres, a.Apellidos, fa.IdFinca, fa.rol from FincaAsociado fa 
                inner join Asociado a on a.Id = fa.IdAsociado";
                using (var db = new FincasCafeterasCon())
                {
                    /*
                    var data = from a in db.Asociado
                               join fa in db.FincaAsociado on a.Id equals fa.IdAsociado
                               
                               select new Asociado()
                               {
                                   Parentesco = a.Parentesco,
                                   Nombres = a.Nombres,
                                   Apellidos = a.Apellidos,
                                   rol = fa.rol
                                   
                                  
                                };*/
                    
                    return View(db.Database.SqlQuery<Asociado_>(sql).ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el trabajador", ex);
                return View();
            }
        }
        public ActionResult Empleado()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Trabajador> list_em = db.Trabajador.ToList();
                    return View(list_em);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar el trabajador", ex);
                return View();
            }
        }
        public ActionResult ListAsociado()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Asociado> list_as = db.Asociado.ToList();
                    return PartialView(list_as);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al listar el asociado", ex);
                return View();
            }
        }
        public ActionResult ListAsociadoFinca(int IdFinca)
        {
            try
            {
                //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                


               /* string sql = @"select  a.Nombres, a.Apellidos, fa.rol from FincaAsociado fa 
                inner join Asociado a on a.Id = fa.IdAsociado where fa.IdFinca= @IdFinca";
               */ using (FincasCafeterasCon db = new FincasCafeterasCon())
                {
                    var data = from a in db.Asociado
                               join fa in db.FincaAsociado on a.Id equals fa.IdAsociado

                               select new Asociado_()
                               {
                                  
                               
                                   Nombres = a.Nombres,
                                   Apellidos = a.Apellidos,
                                   rol = fa.rol


                               };
                    //List<Finca> list = db.Finca.ToList();
                    return View(data.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar la lista de Asociados", ex);
                return View();
            }

        }
        public ActionResult ListEmpleado()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Trabajador> list_em = db.Trabajador.ToList();
                    return PartialView(list_em);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al listar el empleado", ex);
                return View();
            }
        }
        public ActionResult AgregarAsociado()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarAsociado(Asociado a)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    
                    
                    db.Asociado.Add(a);
                    db.SaveChanges();
                    FincaAsociado fa = new FincaAsociado();
                    fa.IdAsociado = a.Id;
                    fa.IdFinca = a.IdFinca;
                    fa.rol = a.rol;
                    a.FincaAsociado.Add(fa);
                    
                    db.SaveChanges();
                    return RedirectToAction("Asociado");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el asociado", ex);
                return PartialView();
            }

        }
        public ActionResult AgregarTrabajador()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTrabajador(Trabajador t)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    db.Trabajador.Add(t);
                    db.SaveChanges();
                    return RedirectToAction("Empleado");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el trabajador", ex);
                return PartialView();
            }

        }
        public ActionResult EditarAsociado(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Asociado a1 = db.Asociado.Find(id);
                    return View(a1);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error editando el asociado", ex);
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAsociado(Asociado a)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Asociado a1 = db.Asociado.Find(a.Id);
                    a1.Nombres = a.Nombres;
                    a1.Apellidos = a.Apellidos;
                    a1.Parentesco = a.Parentesco;
                   
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al editar el asociado", ex);
                return View();
            }

        }
        public ActionResult EditarTrabajador(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Trabajador t1 = db.Trabajador.Find(id);
                    return View(t1);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error editando el trabajador", ex);
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarTrabajador(Trabajador t)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Trabajador t1 = db.Trabajador.Find(t.Id);
                    t1.Nombres = t.Nombres;
                    t1.Apellidos = t.Apellidos;
                    t1.PeriodoContrato = t.PeriodoContrato;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al editar el trabajador", ex);
                return View();
            }

        }
        public ActionResult EliminarAsociado(int id)
        {
            try
            {
               
                using (var db = new FincasCafeterasCon())
                {
                    Asociado a1 = db.Asociado.Find(id);
                    FincaAsociado fa = db.FincaAsociado.Where(fas => fas.IdAsociado ==a1.Id).FirstOrDefault();
                    a1.FincaAsociado.Add(fa);
                    db.Asociado.Remove(a1);
                    db.SaveChanges();
                    return RedirectToAction("Asociado");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error eliminando el asociado", ex);
                return View();
            }
        }
        public ActionResult EliminarTrabajador(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Trabajador t1 = db.Trabajador.Find(id);
                    db.Trabajador.Remove(t1);
                    db.SaveChanges();
                    return RedirectToAction("Empleado");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error eliminando el trabajador", ex);
                return View();
            }
        }
        public static String NombrePariente(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    Asociado a1 = db.Asociado.Find(id);
                    return a1.Nombres;
                }
            }
            catch (Exception ex)
            {
                return "" + ex;
            }

        }
    }
}