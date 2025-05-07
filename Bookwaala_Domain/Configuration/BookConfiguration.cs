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
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.Author)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.TotalCopies)
                   .IsRequired();

            builder.Property(b => b.AvailableCopies)
                   .IsRequired();

            builder.HasMany(b => b.BookAssignments)
                   .WithOne(ba => ba.Book)
                   .HasForeignKey(ba => ba.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
