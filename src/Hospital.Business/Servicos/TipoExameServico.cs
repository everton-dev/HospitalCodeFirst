using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Domain.Interfaces.Servicos;
using System.Collections.Generic;

namespace Hospital.Business.Servicos
{
    public class TipoExameServico : ITipoExameServico
    {
        private readonly ITipoExameRepositorio _repositorio;
        public TipoExameServico(ITipoExameRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Alterar(TipoExame entity) =>
            _repositorio.Alterar(entity);

        public TipoExame ConsultarPorId(int id) =>
            _repositorio.ConsultarPorId(id);

        public ICollection<TipoExame> ConsultarTodos() =>
            _repositorio.ConsultarTodos();

        public int Inserir(TipoExame entity) =>
            _repositorio.Inserir(entity);
    }
}