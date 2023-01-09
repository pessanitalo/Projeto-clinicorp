﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo;

namespace CliniCorp.Data.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(p => p.Id);

            // 1 : 1 => Consulta : Paciente
            builder.HasOne(f => f.Paciente)
                .WithOne(e => e.Consulta);
               

            //// 1 : 1 => Consulta : Medico
            builder.HasOne(f => f.Medico)
                .WithOne(e => e.Consulta);

        }

    }
}