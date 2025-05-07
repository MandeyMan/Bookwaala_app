using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;

namespace Bookwaala_Domain.Interface
{
    public interface ILibraryCardRepository
    {
        Task<LibraryCard> IssueLibraryCardAsync(LibraryCard libraryCard);
    }
}
