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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(s => s.LibraryCard)
                   .WithOne(lc => lc.Student)
                   .HasForeignKey<LibraryCard>(lc => lc.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
