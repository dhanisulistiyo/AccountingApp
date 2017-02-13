using MyIdentity.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyIdentity.EntityFramework.Configuration
{
    internal class ClaimConfiguration : EntityTypeConfiguration<Claim>
    {
        internal ClaimConfiguration()
        {
            ToTable("TClaim");

            HasKey(x => x.ClaimId)
                .Property(x => x.ClaimId)
                .HasColumnName("ClaimID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.UserId)
                .HasColumnName("UserID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("varchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("varchar")
                .IsMaxLength()
                .IsOptional();

            HasRequired(x => x.User)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId);
        }
    }
}