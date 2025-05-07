using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookwaala_Domain.Model
{
    public class Student
    {
      
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public LibraryCard? LibraryCard { get; set; }
    }
}
