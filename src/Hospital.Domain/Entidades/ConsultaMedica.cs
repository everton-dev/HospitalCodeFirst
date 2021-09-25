using System;

namespace Hospital.Domain.Entidades
{
    public class ConsultaMedica
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Exame Exame { get; set; }
        public DateTime DataHoraExame { get; set; }
        public int Protocolo { get; set; }
    }
}