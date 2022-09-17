using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PlantsConfiguration : IEntityTypeConfiguration<Plants>
    {
        public void Configure(EntityTypeBuilder<Plants> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.CategoryId });
            builder.HasOne(x => x.PlantCategory).WithMany(x => x.Plants).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.District).WithMany(x => x.Plants).HasForeignKey(x => x.DisctrictId);
            builder.HasOne(x => x.City).WithMany(x => x.Plants).HasForeignKey(x => x.CityId);
            
        }
    }
}
