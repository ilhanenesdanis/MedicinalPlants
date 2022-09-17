using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PlantsImageConfiguration : IEntityTypeConfiguration<PlantsImage>
    {
        public void Configure(EntityTypeBuilder<PlantsImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.PlantId });
            builder.HasOne(x => x.Plants).WithMany(x => x.PlantsImages).HasForeignKey(x => x.PlantId);
        }
    }
}
