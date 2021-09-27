using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Infraestructure.Repositorios
{
    public class ConsultaMedicaRepositorio : IConsultaMedicaRepositorio
    {
        private readonly ApplicationContext _db;

        public ConsultaMedicaRepositorio(ApplicationContext db)
        {
            _db = db;
        }

        public int Alterar(ConsultaMedica entity)
        {
            var consulta = _db.ConsultaMedicas.Find(entity.Id);

            consulta.Paciente = entity.Paciente;
            consulta.Exame = entity.Exame;
            consulta.DataHoraExame = entity.DataHoraExame;
            consulta.Protocolo = entity.Protocolo;

            return _db.SaveChanges();
        }

        public ICollection<ConsultaMedica> ConsultarPorDataHoraExame(DateTime dataInicial, DateTime dataFinal) =>
            (from p in _db.ConsultaMedicas.AsNoTracking() 
             where p.DataHoraExame >= dataInicial && p.DataHoraExame <= dataFinal select p)
            .ToList();

        public ConsultaMedica ConsultarPorId(int id) =>
            _db.ConsultaMedicas.AsNoTracking()
            .FirstOrDefault(p => p.Id.Equals(id));

        public ICollection<ConsultaMedica> ConsultarTodos() =>
            (from p in _db.ConsultaMedicas.AsNoTracking() select p).ToList();

        public int Excluir(int id)
        {
            var consulta = _db.ConsultaMedicas.Find(id);

            _db.ConsultaMedicas.Remove(consulta);

            return _db.SaveChanges();
        }

        public int Inserir(ConsultaMedica entity)
        {
            _db.ConsultaMedicas.Add(entity);
            return _db.SaveChanges();
        }
    }
}