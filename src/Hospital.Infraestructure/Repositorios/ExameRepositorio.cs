using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Infraestructure.Repositorios
{
    public class ExameRepositorio : IExameRepositorio
    {
        private readonly ApplicationContext _db;

        public ExameRepositorio(ApplicationContext db)
        {
            _db = db;
        }

        public int Alterar(Exame entity)
        {
            var exame = _db.Exames.Find(entity.Id);

            exame.Nome = entity.Nome;
            exame.Observacao = entity.Observacao;
            exame.TipoExame = entity.TipoExame;

            return _db.SaveChanges();
        }

        public Exame ConsultarPorId(int id) =>
            _db.Exames.AsNoTracking()
            .FirstOrDefault(p => p.Id.Equals(id));

        public ICollection<Exame> ConsultarTodos() =>
            (from p in _db.Exames.AsNoTracking() select p).ToList();

        public int Inserir(Exame entity)
        {
            _db.Exames.Add(entity);
            return _db.SaveChanges();
        }
    }
}