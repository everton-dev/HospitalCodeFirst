using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos.Base;
using System;
using System.Collections.Generic;

namespace Hospital.Domain.Interfaces.Servicos
{
    public interface IConsultaMedicaServico : IServico<ConsultaMedica>
    {
        ICollection<ConsultaMedica> ConsultarPorDataHoraExame(DateTime dataInicial, DateTime dataFinal);
        bool ValidarSeExisteNaDataHora(int pacienteId, int tipoExameId, DateTime dataHoraExame);
    }
}