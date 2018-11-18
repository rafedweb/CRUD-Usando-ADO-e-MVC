using CRUDUsandoMVCeADO.Models;
using CRUDUsandoMVCeADO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsandoMVCeADO.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteRepository respository = new ClienteRepository();
        // GET: Clientes
        public ActionResult Index()
        {
            ViewBag.ClienteId = new SelectList
                (
                    respository.GetAll().ToList(),
                    "CodigoCliente",
                    "NomeFantasia"
                );

            return View(respository.GetAll());
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList
                (
                    respository.GetAll().ToList(),
                    "CodigoCliente",
                    "NomeFantasia"                    
                );


            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                respository.Save(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = respository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                respository.Update(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            respository.DeleteById(id);
            return Json(respository.GetAll());
        }
    }
}
