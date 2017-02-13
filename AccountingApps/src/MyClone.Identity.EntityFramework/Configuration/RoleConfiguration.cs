using MyIdentity.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MyIdentity.EntityFramework.Configuration
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        internal RoleConfiguration()
        {
            ToTable("TRole");

            HasKey(x => x.RoleId)
                .Property(x => x.RoleId)
                .HasColumnName("RoleID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.RoleName)
                .HasColumnName("RoleName")
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.ToTable("TUserRole");
                    x.MapLeftKey("RoleID");
                    x.MapRightKey("UserID");
                });
        }
    }
}