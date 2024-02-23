using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;


public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
{
    public void Configure(EntityTypeBuilder<CarImage> builder)
    {
        builder.ToTable("CarImages").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.CarId).HasColumnName("CarId").IsRequired();
        builder.Property(x => x.ImagePath).HasColumnName("ImagePath").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Car);
    }
}
