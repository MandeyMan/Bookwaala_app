using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bookwaala_Domain.Configuration
{
    public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.HasKey(lc => lc.Id);

            builder.Property(lc => lc.IssueDate)
                   .IsRequired();

            builder.Property(lc => lc.ExpiryDate)
                   .IsRequired();

            builder.HasMany(lc => lc.BookAssignments)
                   .WithOne(ba => ba.LibraryCard)
                   .HasForeignKey(ba => ba.LibraryCardId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
