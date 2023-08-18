
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class EmpresaEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Empresa> entity)
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("empresa");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");

            entity.Property(e => e.EmpCorreo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("emp_correo");

            entity.Property(e => e.EmpDireccion)
                .HasMaxLength(10)
                .HasColumnName("emp_direccion")
                .IsFixedLength(true);

            entity.Property(e => e.EmpIdentificacion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_identificacion");

            entity.Property(e => e.EmpNombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("emp_nombre");

            entity.Property(e => e.EmpTelefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_telefono");
        }
    }
}
