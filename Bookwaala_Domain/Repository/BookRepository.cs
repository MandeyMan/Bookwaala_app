using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Interface;
using Bookwaala_Domain.Model;
using Bookwaala_Domain.ORM;
using Microsoft.EntityFrameworkCore;

namespace Bookwaala_Domain.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookwalaDbContext _context;

        public BookRepository(BookwalaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
