using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Interface;
using Bookwaala_Domain.Model;
using Bookwaala_Domain.ORM;

namespace Bookwaala_Domain.Repository
{
    public class LibraryCardRepository: ILibraryCardRepository
    {
        private readonly BookwalaDbContext _context;

        public LibraryCardRepository(BookwalaDbContext context)
        {
            _context = context;
        }

        public async Task<LibraryCard> IssueLibraryCardAsync(LibraryCard libraryCard)
        {
            await _context.LibraryCards.AddAsync(libraryCard);
            await _context.SaveChangesAsync();
            return libraryCard;
        }
    }
}
