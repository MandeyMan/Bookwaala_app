using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookwaala_Domain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public ICollection<BookAssignment> BookAssignments { get; set; } = new List<BookAssignment>();
    }
}
