using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookwaala_Domain.Configuration
{
    public class BookAssignmentConfiguration : IEntityTypeConfiguration<BookAssignment>
    {
        public void Configure(EntityTypeBuilder<BookAssignment> builder)
        {
            builder.HasKey(ba => ba.Id);

            builder.Property(ba => ba.FromDate)
                   .IsRequired();

            builder.Property(ba => ba.ToDate)
                   .IsRequired();

            builder.Property(ba => ba.IsReturned)
                   .IsRequired();
        }
    }
}
