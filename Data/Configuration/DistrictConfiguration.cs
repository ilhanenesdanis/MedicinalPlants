using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.CityId });
            builder.HasOne(x => x.City).WithMany(x => x.Districts).HasForeignKey(x => x.CityId);

        }
    }
}
