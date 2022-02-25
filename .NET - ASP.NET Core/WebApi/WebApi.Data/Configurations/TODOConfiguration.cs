using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entities;

namespace WebApi.Data.Configurations
{
    public class TODOConfiguration : IEntityTypeConfiguration<TODO>
    {
        public void Configure(EntityTypeBuilder<TODO> builder)
        {
            builder.ToTable("TODOs");
        }
    }
}
