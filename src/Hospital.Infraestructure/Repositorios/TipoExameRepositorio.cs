using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Infraestructure.Repositorios
{
    public class TipoExameRepositorio : ITipoExameRepositorio
    {
        private readonly ApplicationContext _db;

        public TipoExameRepositorio(ApplicationContext db)
        {
            _db = db;
        }

        public int Alterar(TipoExame entity)
        {
            var tipoExame = _db.TipoExames.Find(entity.Id);

            tipoExame.Nome = entity.Nome;
            tipoExame.Descricao = entity.Descricao;

            return _db.SaveChanges();
        }

        public TipoExame ConsultarPorId(int id) =>
            _db.TipoExames.AsNoTracking()
            .FirstOrDefault(p => p.Id.Equals(id));

        public ICollection<TipoExame> ConsultarTodos() =>
            (from p in _db.TipoExames.AsNoTracking() select p).ToList();

        public int Excluir(int id)
        {
            var tipoExame = _db.TipoExames.Find(id);

            _db.TipoExames.Remove(tipoExame);
            
            return _db.SaveChanges();
        }

        public int Inserir(TipoExame entity)
        {
            _db.TipoExames.Add(entity);
            return _db.SaveChanges();
        }
    }
}