﻿using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios.Base;
using System;
using System.Collections.Generic;

namespace Hospital.Domain.Interfaces.Repositorios
{
    public interface IConsultaMedicaRepositorio : IRepositorio<ConsultaMedica>
    {
        ICollection<ConsultaMedica> ConsultarPorDataHoraExame(DateTime dataInicial, DateTime dataFinal);
    }
}