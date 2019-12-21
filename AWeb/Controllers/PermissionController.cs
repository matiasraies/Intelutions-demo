using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWeb.Controllers
{
    public class PermissionController : Controller
    {
        private const string URIAPI = "https://localhost:44329/api/v1/";

        /// <summary>
        /// Muestra la pantalla principal de controlador.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IEnumerable<PermissionViewModel> permissions = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URIAPI);

                var responseTask = client.GetAsync("permission");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PermissionViewModel>>();
                    readTask.Wait();
                    permissions = readTask.Result;
                }
                else
                {
                    permissions = Enumerable.Empty<PermissionViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(permissions);
        }

        /// <summary>
        /// Genera la vista inicial para la creacion de un Permission.
        /// </summary>
        /// <returns></returns>
        public IActionResult create()
        {
            var vm = new PermissionViewModel
            {
                PermissionTypes = GetPermissionTypes()
            };

            return View(vm);
        }

        /// <summary>
        /// Crea un Permission por medio de la API.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult create(PermissionViewModel permission)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URIAPI);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<PermissionViewModel>("permission/create", permission);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(permission);
        }

        /// <summary>
        /// Accion para consumir el metodo DELETE de la API.
        /// </summary>
        /// <param name="id">Id del Permission a eliminar.</param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URIAPI);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("permission/delete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Obtiene los PermissionTypes de la API.
        /// </summary>
        /// <returns>Lista de PermissionType.</returns>
        public IEnumerable<PermissionType> GetPermissionTypes()
        {
            IEnumerable<PermissionType> permissionTypes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URIAPI);

                var responseTask = client.GetAsync("permission/types/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PermissionType>>();
                    readTask.Wait();
                    permissionTypes = readTask.Result;
                }
                else
                {
                    permissionTypes = Enumerable.Empty<PermissionType>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return permissionTypes;
        }
    }
}