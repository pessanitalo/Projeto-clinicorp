using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo;

namespace CliniCorp.Data.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(p => p.Id);

            //builder.Property(p => p.Nome)
            //    .IsRequired()


            //    .HasColumnType("varchar(200)");

            //builder.Property(p => p.Cpf)
            //    .IsRequired()
            //    .HasColumnType("varchar(14)");

            //builder.Property(p => p.Crm)
            //    .IsRequired()
            //    .HasColumnType("varchar(11)");

            //builder.Property(p => p.Especializacao)
            //    .IsRequired()
            //    .HasColumnType("varchar(30)");
        }
    }
}
