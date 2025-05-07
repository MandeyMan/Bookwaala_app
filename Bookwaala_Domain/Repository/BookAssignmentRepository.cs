using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;
using Bookwaala_Domain.ORM;
using Microsoft.EntityFrameworkCore;

namespace Bookwaala_Domain.Repository
{
    public class BookAssignmentRepository
    {
        private readonly BookwalaDbContext _context;

        public BookAssignmentRepository(BookwalaDbContext context)
        {
            _context = context;
        }

        public async Task<BookAssignment> AssignBookToStudentAsync(BookAssignment bookAssignment)
        {
            await _context.BookAssignments.AddAsync(bookAssignment);
            await _context.SaveChangesAsync();
            return bookAssignment;
        }

        public async Task<List<BookAssignment>> GetAssignmentsByBookIdAsync(int bookId)
        {
            return await _context.BookAssignments
                                 .Include(ba => ba.Student)
                                 .Where(ba => ba.BookId == bookId)
                                 .ToListAsync();
        }

        public async Task<List<BookAssignment>> GetAssignmentsByLibraryCardIdAsync(int libraryCardId)
        {
            return await _context.BookAssignments
                                 .Include(ba => ba.Book)
                                 .Where(ba => ba.LibraryCardId == libraryCardId)
                                 .ToListAsync();
        }

    }
}
