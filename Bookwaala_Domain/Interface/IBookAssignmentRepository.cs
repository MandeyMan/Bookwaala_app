using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;

namespace Bookwaala_Domain.Interface
{
    public interface IBookAssignmentRepository
    {
        Task<BookAssignment> AssignBookToStudentAsync(BookAssignment bookAssignment);
        Task<List<BookAssignment>> GetAssignmentsByBookIdAsync(int bookId);
        Task<List<BookAssignment>> GetAssignmentsByLibraryCardIdAsync(int libraryCardId);
    }
}
