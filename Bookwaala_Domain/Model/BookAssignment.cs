using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookwaala_Domain.Model
{
    public class BookAssignment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int LibraryCardId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsReturned { get; set; }
        public int StudentId { get; set; }
        public Book Book { get; set; }
        public LibraryCard LibraryCard { get; set; }
        public Student Student { get; internal set; }
    }
}
