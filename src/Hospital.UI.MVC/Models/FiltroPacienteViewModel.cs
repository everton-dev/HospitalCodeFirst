using Hospital.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.UI.MVC.Models
{
    public class FiltroPacienteViewModel
    {
        public FiltroPacienteViewModel()
        {
            Cpf = string.Empty;
            Nome = string.Empty;
            Paciente = null;
        }

        public FiltroPacienteViewModel(string cpf, string nome, Paciente paciente)
        {
            Cpf = cpf;
            Nome = nome;
            Paciente = paciente;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public Paciente Paciente { get; set; }
    }
}