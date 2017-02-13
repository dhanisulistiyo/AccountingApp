using MyIdentity.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MyIdentity.EntityFramework.Configuration
{
    internal class ExternalLoginConfiguration : EntityTypeConfiguration<ExternalLogin>
    {
        internal ExternalLoginConfiguration()
        {
            ToTable("ExternalLogin");

            HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            Property(x => x.LoginProvider)
                .HasColumnName("LoginProvider")
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.ProviderKey)
                .HasColumnName("ProviderKey")
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.UserId)
                .HasColumnName("UserID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany(x => x.Logins)
                .HasForeignKey(x => x.UserId);
        }
    }
}