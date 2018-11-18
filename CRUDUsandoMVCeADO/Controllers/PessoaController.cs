using CRUDUsandoMVCeADO.Models;
using CRUDUsandoMVCeADO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsandoMVCeADO.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository respository = new PessoaRepository();
        // GET: Pessoa
        public ActionResult Index()
        {
            ViewBag.Pessoas = respository.GetAll().ToList();
            return View(respository.GetAll());
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                respository.Save(pessoa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pessoa);
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = respository.GetById(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                respository.Update(pessoa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pessoa);
            }
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            respository.DeleteById(id);
            return Json(respository.GetAll());
        }

    }
}
