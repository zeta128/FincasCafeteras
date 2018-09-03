using PryFincasCafeteras.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PryFincasCafeteras.Controllers
{
    public class FincasController : Controller
    {
        // GET: Fincas
        public ActionResult Index()
        {
            try
            {
               
                using (FincasCafeterasCon db1 = new FincasCafeterasCon())
                {
                    
                    List<Finca> listf = db1.Finca.ToList();
                    return View(listf);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar la lista de fincas", ex);
                return View();
            }
            
        }

        public ActionResult ListAsociadoFinca(int IdFinca)
        {
            try
            {
              
                using (FincasCafeterasCon db = new FincasCafeterasCon())
                {
                    var data = from a in db.Asociado
                               join fa in db.FincaAsociado on a.Id equals fa.IdAsociado
                               where fa.IdFinca.Equals(IdFinca)
                               select new Asociado_()
                               {

                                   IdFinca = fa.IdFinca,
                                   Nombres = a.Nombres,
                                   Apellidos = a.Apellidos,
                                   rol = fa.rol


                               } ;
                   
                    return PartialView(data.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar la lista de Asociados", ex);
                return PartialView();
            }

        }
        public ActionResult ListTrabajadorFinca(int IdFinca)
        {
            try
            {

                using (FincasCafeterasCon db = new FincasCafeterasCon())
                {
                    var data = from t in db.Trabajador
                               join f in db.Finca on t.IdFinca equals f.Codigo
                               
                               select new Trabajador_()
                               {

                                   IdFinca = t.IdFinca,
                                   Nombres = t.Nombres,
                                   Apellidos = t.Apellidos,
                                   PeriodoContrato = t.PeriodoContrato


                               };

                    return View(data.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar la lista de Asociados", ex);
                return View();
            }

        }
        public ActionResult ListFincas()
        {
            try
            {
                using (FincasCafeterasCon db = new FincasCafeterasCon())
                {
                    List<Finca> list = db.Finca.ToList();
                    return PartialView(list);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar la lista de fincas", ex);
                return  PartialView();
            }

        }
        public ActionResult AgregarFinca()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarFinca(Finca f)
        {
            if(!ModelState.IsValid)
            return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    db.Finca.Add(f);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar la finca",ex);
                return View();
            }
               
        }
       
        public ActionResult EditarFinca(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Finca f1 = db.Finca.Find(id);
                    return View(f1);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error editando finca", ex);
                return View();
            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarFinca(Finca f)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Finca f1 = db.Finca.Find(f.Codigo);
                    f1.Codigo = f.Codigo;
                    f1.Nombre = f.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                   
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al editar finca", ex);
                return View();
            }
            
        }
        public ActionResult DetallesFinca(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Finca f1 = db.Finca.Find(id);
            
                    return View(f1);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error cargando detalles de la finca", ex);
                return View();
            }
        }
        public ActionResult EliminarFinca(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    
                    Finca f1 = db.Finca.Find(id);
                    db.Finca.Remove(f1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error eliminando la finca", ex);
                return View();
            }
        }
        public static String NombreFinca(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    Finca f1 = db.Finca.Find(id);
                    return f1.Nombre;
                }
            }
            catch (Exception ex)
            {
                return "" + ex;
            }

        }
        public static Finca fincacon(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    Finca f1 = db.Finca.Find(id);
                    return f1;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}