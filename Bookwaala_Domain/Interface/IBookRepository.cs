using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;

namespace Bookwaala_Domain.Interface
{
    public interface IBookRepository
    {

        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
    }
}
