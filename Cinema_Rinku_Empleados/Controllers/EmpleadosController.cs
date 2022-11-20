using Cinema_Rinku_Empleados.DTO;
using Cinema_Rinku_Empleados.Models;
using Cinema_Rinku_Empleados.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace Cinema_Rinku_Empleados.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadosRepositorio emp = new EmpleadosRepositorio();
        public ActionResult Index()
        {
            List<EmpleadosModel> LisEmp = new List<EmpleadosModel>();
            LisEmp = emp.ObtieneTodosEmpleados();

            return View(LisEmp);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            EmpleadosModel mod = new EmpleadosModel();
            mod.ListRoles =  ObtieneRoles();

            return View(mod);
        }
        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadosModel model)
        {
            string Respuesta = "";
            try
            {
                Respuesta = emp.Guardar(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int NumeroEmpleado)
        {
            EmpleadosModel mod= new EmpleadosModel();
            var datos = emp.ObtieneEmpleadoId(NumeroEmpleado);
            if (datos != null)
            {
                mod.NumeroEmpleado = datos.NumeroEmpleado;
                mod.RolId = datos.RolId;              
                mod.Nombre = datos.Nombre;
                mod.ApellidoP = datos.ApellidoP;
                mod.ApellidoM = datos.ApellidoM;
            } 
            mod.ListRoles = ObtieneRoles();
            return View(mod);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadosModel model)
        {
            string Respuesta = "";
            try
            {
                Respuesta = emp.Actualizar(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public List<SelectListItem> ObtieneRoles()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var listaRoles = emp.ObtieneRoles();
            if (listaRoles.Count > 0)
            {
                foreach (var item in listaRoles)
                {
                    items.Add(new SelectListItem { Text = item.Rol, Value = item.RolId.ToString() });
                }

            }
            else
            {
                items.Add(new SelectListItem { Text = "Sin Roles", Value = (0).ToString() });
            }
            return items;
        }
    }
}
