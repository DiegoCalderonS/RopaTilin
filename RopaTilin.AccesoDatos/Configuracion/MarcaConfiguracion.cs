﻿using Microsoft.EntityFrameworkCore;
using RopaTilin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopaTilin.AccesoDatos.Configuracion
{
    public class MarcaConfiguracion : IEntityTypeConfiguration<Marca>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Marca> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}