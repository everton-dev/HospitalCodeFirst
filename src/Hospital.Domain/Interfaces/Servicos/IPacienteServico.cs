using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos.Base;

namespace Hospital.Domain.Interfaces.Servicos
{
    public interface IPacienteServico : IServico<Paciente>
    {
        Paciente ConsultarPorCpf(string cpf);
        Paciente ConsultarPorNome(string nome);
        Paciente ConsultarPorCpfeNome(string cpf, string nome);
    }
}