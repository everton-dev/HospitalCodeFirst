using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.UI.MVC.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteServico _servico;

        public PacienteController(IPacienteServico servico)
        {
            _servico = servico;
        }

        // GET: PacienteController
        public ActionResult Index() =>
            View(_servico.ConsultarTodos());

        // GET: PacienteController/Details/5
        public ActionResult Details(int id) =>
            View(_servico.ConsultarPorId(id));

        // GET: PacienteController/Create
        public ActionResult Create()
        {
            ViewBag.Sexos = ObterSexo();
            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                _servico.Inserir(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Sexos = ObterSexo();
            return View(_servico.ConsultarPorId(id));
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            try
            {
                _servico.Alterar(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Delete/5
        public ActionResult Delete(int id) =>
            View(_servico.ConsultarPorId(id));

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Paciente paciente)
        {
            try
            {
                _servico.Excluir(paciente.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> ObterSexo() =>
            new List<SelectListItem>()
            {
                new SelectListItem("Masculino", "M"),
                new SelectListItem("Feminino", "F")
            };
    }
}
