using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infraestructure.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(c => c.Cpf).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(c => c.DataNascimento).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.Sexo).HasColumnType("CHAR(1)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("CHAR(11)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("VARCHAR(400)").IsRequired();

            builder.HasIndex(i => i.Cpf).HasName("IX_PACIENTE_CPF");

            builder.HasMany(p => p.Consultas)
                .WithOne(p => p.Paciente);
        }
    }
}