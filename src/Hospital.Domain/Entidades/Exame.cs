namespace Hospital.Domain.Entidades
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public TipoExame TipoExame { get; set; }
    }
}