using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookwaala_Domain.Model
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Student Student { get; set; } = null!;
        public ICollection<BookAssignment> BookAssignments { get; set; } = new List<BookAssignment>();

    }
}
