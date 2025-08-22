using ISpire.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISpire.Infrastructure.Configurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasKey(t => t.Guid);
        builder.HasOne(t => t.Subject)
            .WithMany()
            .HasForeignKey(t => t.SubjectGuid);
    }
}