﻿using System;
using System.Collections.Generic;

namespace Hospital.Domain.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public ICollection<ConsultaMedica> Consultas { get; set; }
    }
}