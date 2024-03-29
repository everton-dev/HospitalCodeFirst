﻿using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Infraestructure.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ApplicationContext _db;

        public PacienteRepositorio(ApplicationContext db)
        {
            _db = db;
        }

        public int Alterar(Paciente entity)
        {
            var paciente = _db.Pacientes.Find(entity.Id);

            paciente.Nome = entity.Nome;
            paciente.Cpf = entity.Cpf;
            paciente.DataNascimento = entity.DataNascimento;
            paciente.Sexo = entity.Sexo;
            paciente.Telefone = entity.Telefone;
            paciente.Email = entity.Email;

            return _db.SaveChanges();
        }

        public Paciente ConsultarPorCpf(string cpf) =>
            _db.Pacientes.AsNoTracking()
                .Include(p => p.Consultas)
                .ThenInclude(c => c.Exame)
                .ThenInclude(c => c.TipoExame)
            .FirstOrDefault(p => p.Cpf.Equals(cpf));

        public Paciente ConsultarPorCpfeNome(string cpf, string nome) =>
            _db.Pacientes.AsNoTracking()
                .Include(p => p.Consultas)
                .ThenInclude(c => c.Exame)
                .ThenInclude(c => c.TipoExame)
            .FirstOrDefault(p => p.Cpf.Equals(cpf) && p.Nome.Contains(nome));

        public Paciente ConsultarPorId(int id) =>
            _db.Pacientes.AsNoTracking()
                .Include(p => p.Consultas)
                .ThenInclude(c => c.Exame)
                .ThenInclude(c => c.TipoExame)
            .FirstOrDefault(p => p.Id.Equals(id));

        public Paciente ConsultarPorNome(string nome) =>
            _db.Pacientes.AsNoTracking()
                .Include(p => p.Consultas)
                .ThenInclude(c => c.Exame)
                .ThenInclude(c => c.TipoExame)
            .FirstOrDefault(p => p.Nome.Contains(nome));

        public ICollection<Paciente> ConsultarTodos() =>
            (from p in _db.Pacientes.AsNoTracking() select p).ToList();

        public int Excluir(int id)
        {
            var paciente = _db.Pacientes.Find(id);

            _db.Pacientes.Remove(paciente);

            return _db.SaveChanges();
        }

        public int Inserir(Paciente entity)
        {
            _db.Pacientes.Add(entity);
            return _db.SaveChanges();
        }
    }
}