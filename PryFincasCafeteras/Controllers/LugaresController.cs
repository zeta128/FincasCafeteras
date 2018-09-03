using PryFincasCafeteras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PryFincasCafeteras.Controllers
{
    public class LugaresController : Controller
    {


        public ActionResult Index()
        {
            try
            {
                using (FincasCafeterasCon db = new FincasCafeterasCon())
                {
                    
                    List<Vereda> list_ve1 = db.Vereda.ToList();
                    
                   
                    return View(list_ve1);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al cargar veredas", ex);
                return View();
            }
        }
        public ActionResult Veredas()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Vereda> list_ve = db.Vereda.ToList();
                    return PartialView(list_ve);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar la vereda", ex);
                return View();
            }
        }
        public ActionResult Municipios()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Municipio> list_mu = db.Municipio.ToList();
                    return PartialView(list_mu);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al listar municipios", ex);
                return View();
            }
        }
        public static String NombreMunicipio(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    Municipio m1 = db.Municipio.Find(id);
                    return m1.Nombre;
                }
            }
            catch (Exception ex)
            {
                return "" + ex;
            }

        }
        public static String NombreDepartamento(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    Departamento d1 = db.Departamento.Find(id);
                    return d1.Nombre;
                }
            }
            catch (Exception ex)
            {
                return ""+ex;
            }
           
        }
        public static String NombreVereda(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    Vereda v1 = db.Vereda.Find(id);
                    return v1.Nombre;
                }
            }
            catch (Exception ex)
            {
                return "" + ex;
            }

        }
        public ActionResult ListMunicipios()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Municipio> list_mu = db.Municipio.ToList();
                    return View(list_mu);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al listar municipios", ex);
                return View();
            }
        }
        public ActionResult Departamentos()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Departamento> list_de = db.Departamento.ToList();
                    return PartialView(list_de);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al listar departamentos", ex);
                return View();
            }
        }
        public ActionResult ListDepartamentos()
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    List<Departamento> list_de = db.Departamento.ToList();
                    return View(list_de);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al listar departamentos", ex);
                return View();
            }
        }
        public ActionResult AgregarVereda()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarVereda(Vereda v)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    db.Vereda.Add(v);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar la vereda", ex);
                return View();
            }

        }
        public ActionResult AgregarMunicipio()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMunicipio(Municipio m)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    db.Municipio.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el municipio", ex);
                return View();
            }

        }
        public ActionResult AgregarDepto()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarDepto(Departamento d)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    db.Departamento.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el departamento", ex);
                return View();
            }

        }
        
        public ActionResult EliminarVereda(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //Finca f1 = db.Finca.Where(f => f.Codigo == id).FirstOrDefault();
                    Vereda v1 = db.Vereda.Find(id);
                    db.Vereda.Remove(v1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error eliminando la vereda", ex);
                return View();
            }
        }
        public ActionResult EliminarMunicipio(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //
                    Municipio m1 = db.Municipio.Find(id);
                    db.Municipio.Remove(m1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error eliminando el municipio", ex);
                return View();
            }
        }
        public ActionResult EliminarDepartamento(int id)
        {
            try
            {
                using (var db = new FincasCafeterasCon())
                {
                    //
                    Departamento d1 = db.Departamento.Find(id);
                    db.Departamento.Remove(d1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error eliminando el departamento", ex);
                return View();
            }
        }
    }
}