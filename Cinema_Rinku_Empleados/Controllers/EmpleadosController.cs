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
        EmpleadosDTO dto = new EmpleadosDTO();
        public ActionResult Index()
        {
            List<EmpleadosModel> LisEmp = new List<EmpleadosModel>();
            try
            {
                LisEmp = emp.ObtieneTodosEmpleados();
            }

            catch (Exception ex)
            {
                return View(LisEmp);
            }
            return View(LisEmp);
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
            string respuesta = "";
            try
            {

                respuesta = emp.Guardar(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int numeroEmpleado)
        {
            EmpleadosModel mod= new EmpleadosModel();
            var datos = emp.ObtieneEmpleadoId(numeroEmpleado);
            if (datos != null)
            {
                mod.NumeroEmpleado = datos.NumeroEmpleado;
                mod.NumeroEmpleado2 = datos.NumeroEmpleado;
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
            string respuesta = "";
            try
            {
                respuesta = emp.Actualizar(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public List<SelectListItem> ObtieneRoles()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            try
            {
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
            }
            catch (Exception)
            {

                items.Add(new SelectListItem { Text = "Sin Roles", Value = (0).ToString() }); // Debe ser mensaje de error
            }
            return items;
        }
        public ActionResult CreateMovimientos()
        {
            EmpleadosModel mod = new EmpleadosModel();
            mod.ListEmpleados = ObtieneEmpleados();
            mod.ListRoles = ObtieneRoles();
            mod.ListMeses= ListaMeses();
            return View(mod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovimientos(EmpleadosModel  model)
        {
            string respuesta = "";
            try
            {
                respuesta = emp.GuardarMovimientos(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                EmpleadosModel mod = new EmpleadosModel();
                mod.ListEmpleados = ObtieneEmpleados();
                mod.ListRoles = ObtieneRoles();
                mod.ListMeses = ListaMeses();

                return View(mod);
            }
        }
        public List<SelectListItem> ObtieneEmpleados()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var listaEmpleados = emp.ObtieneTodosEmpleados();
                if (listaEmpleados.Count > 0)
                {
                    foreach (var item in listaEmpleados)
                    {
                        items.Add(new SelectListItem { Text = item.NumeroEmpleado.ToString(), Value = item.NumeroEmpleado.ToString() });
                    }
                }
                else
                {
                    items.Add(new SelectListItem { Text = "Sin empleado", Value = (0).ToString() });
                }
            }
            catch (Exception)
            {
                items.Add(new SelectListItem { Text = "Sin empleado", Value = (0).ToString() }); // Debe ser un mensaje de error
            }
            return items;
        }
        public ActionResult DatosEmpleado(int numeroEmpleado)
        {         
            var datos = emp.ObtieneEmpleadoId(numeroEmpleado);

            if (datos != null)
            {
                dto.Nombre = datos.Nombre + " " + datos.ApellidoP + " " + datos.ApellidoM;
                dto.RolId = datos.RolId;
                dto.Rol = datos.Rol;

                string NombreCompleto = datos.Nombre + " " + datos.ApellidoP + " " + datos.ApellidoM;

                    return Json(new { NombreCompleto, dto.RolId, dto.Rol });
            }
            return Json(new { NombreCompleto = "", RolId = 0, Rol = "" });
        }
        public List<SelectListItem> ListaMeses()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var listaMeses = emp.ObtieneMeses();
                if (listaMeses.Count > 0)
                {
                    foreach (var item in listaMeses)
                    {
                        items.Add(new SelectListItem { Text = item.Mes, Value = item.IdMes.ToString() });
                    }
                }
                else
                {
                    items.Add(new SelectListItem { Text = "Sin Datos", Value = (0).ToString() });
                }
            }
            catch (Exception)
            {

                items.Add(new SelectListItem { Text = "Sin Datos", Value = (0).ToString() });// Debe ser un mensaje de error
            }
            return items;

        }
        public ActionResult DetallesMovimientos(int numeroEmpleado)
        {
            var datos = emp.ObtieneEmpleadoId(numeroEmpleado);

            if (datos != null)
            {
                dto.Nombre = datos.Nombre + " " + datos.ApellidoP + " " + datos.ApellidoM;
                ViewBag.Nombre = dto.Nombre;
            }

            List<EmpleadosModel> LisEmp = new List<EmpleadosModel>();
            LisEmp = emp.DetallesMovimientoEmp(numeroEmpleado);

            return View(LisEmp);
        }
    }
}
