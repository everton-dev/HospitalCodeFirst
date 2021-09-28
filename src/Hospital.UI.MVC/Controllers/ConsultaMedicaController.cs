using AutoMapper;
using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using Hospital.UI.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.UI.MVC.Controllers
{
    public class ConsultaMedicaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConsultaMedicaServico _servico;
        private readonly IPacienteServico _pacienteServico;
        private readonly IExameServico _exameServico;
        private readonly ITipoExameServico _tipoExameServico;

        public ConsultaMedicaController(IMapper mapper, IConsultaMedicaServico servico, IPacienteServico pacienteServico, IExameServico exameServico, ITipoExameServico tipoExameServico)
        {
            _mapper = mapper;
            _servico = servico;
            _pacienteServico = pacienteServico;
            _exameServico = exameServico;
            _tipoExameServico = tipoExameServico;
        }

        // GET: ConsultaMedicaController
        public ActionResult Index(FiltroPacienteViewModel filtro) =>
            View(filtro ?? new FiltroPacienteViewModel());

        [HttpPost]
        public ActionResult Index(string cpf, string nome) =>
            View(new FiltroPacienteViewModel(cpf, nome, _pacienteServico.ConsultarPorCpfeNome(cpf, nome)));
                
        public ActionResult Agendar(int idPaciente) =>
            View(_pacienteServico.ConsultarPorId(idPaciente));

        // GET: ConsultaMedicaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConsultaMedicaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsultaMedicaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ConsultaMedicaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsultaMedicaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ConsultaMedicaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsultaMedicaController/Delete/5
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
    }
}