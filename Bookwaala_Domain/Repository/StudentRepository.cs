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
    public class StudentRepository : IStudentRepository
    {
        private readonly BookwalaDbContext _context;

        public StudentRepository(BookwalaDbContext context)
        {
            _context = context;
        }

        public async Task<Student> RegisterStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
