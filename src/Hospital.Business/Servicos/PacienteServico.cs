using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Domain.Interfaces.Servicos;
using System.Collections.Generic;

namespace Hospital.Business.Servicos
{
    public class PacienteServico : IPacienteServico
    {
        private readonly IPacienteRepositorio _repositorio;
        public PacienteServico(IPacienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Alterar(Paciente entity) =>
            _repositorio.Alterar(entity);

        public Paciente ConsultarPorCpf(string cpf)
        {
            if (cpf != null)
                cpf = cpf.Replace(".", "").Replace("-", "");

            return _repositorio.ConsultarPorCpf(cpf);
        }

        public Paciente ConsultarPorCpfeNome(string cpf, string nome)
        {
            var result = default(Paciente);

            if (cpf != null)
                cpf = cpf.Replace(".", "").Replace("-", "");

            if (!string.IsNullOrWhiteSpace(cpf) && !string.IsNullOrWhiteSpace(nome))
            {
                result = _repositorio.ConsultarPorCpfeNome(cpf, nome);
            }
            else if (!string.IsNullOrWhiteSpace(cpf) && string.IsNullOrWhiteSpace(nome))
            {
                result = _repositorio.ConsultarPorCpf(cpf);
            }
            else if (string.IsNullOrWhiteSpace(cpf) && !string.IsNullOrWhiteSpace(nome))
            {
                result = _repositorio.ConsultarPorNome(nome);
            }

            return result;
        }

        public Paciente ConsultarPorId(int id) =>
            _repositorio.ConsultarPorId(id);

        public Paciente ConsultarPorNome(string nome) =>
            _repositorio.ConsultarPorNome(nome);

        public ICollection<Paciente> ConsultarTodos() =>
            _repositorio.ConsultarTodos();

        public int Excluir(int id) =>
            _repositorio.Excluir(id);

        public int Inserir(Paciente entity) =>
            _repositorio.Inserir(entity);
    }
}