using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PlantCategoryConfiguration : IEntityTypeConfiguration<PlantCategory>
    {
        public void Configure(EntityTypeBuilder<PlantCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
        }
    }
}
