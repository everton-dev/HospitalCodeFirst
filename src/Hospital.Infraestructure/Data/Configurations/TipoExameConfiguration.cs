using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infraestructure.Data.Configurations
{
    public class TipoExameConfiguration : IEntityTypeConfiguration<TipoExame>
    {
        public void Configure(EntityTypeBuilder<TipoExame> builder)
        {
            builder.ToTable("TipoExame");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(c => c.Descricao).HasColumnType("VARCHAR(300)").IsRequired();
            builder.HasData(new TipoExame[]
            {
                    new TipoExame { Id = 1, Nome = "Hemograma", Descricao = "Exame de sangue, jejum 12 horas."},
                    new TipoExame { Id = 2, Nome = "Raio X", Descricao = "Exame de imagem."}
            });
        }
    }
}