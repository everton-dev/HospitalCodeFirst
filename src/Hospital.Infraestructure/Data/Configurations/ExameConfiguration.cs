using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infraestructure.Data.Configurations
{
    public class ExameConfiguration : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exame");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(c => c.Observacao).HasColumnType("VARCHAR(300)").IsRequired();
        }
    }
}