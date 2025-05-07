using Bookwaala_Domain.Interface;
using Bookwaala_Domain.Model;
using Bookwaala_Domain.ORM;
using Bookwaala_Domain.Repository;

namespace Bookwaala_app
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using var context = new BookwalaDbContext();

            // initnituaing  all repos
            var studentRepo = new StudentRepository(context);
            var cardRepo = new LibraryCardRepository(context);
            var bookRepo = new BookRepository(context);
            var assignmentRepo = new BookAssignmentRepository(context);

            Console.WriteLine("\n Hello and Welcome to Bookwaala App \n");

            //  creating /registring a student
            var student = new Student
            {
                Name = "Pankaj Sir",
                Email = "pankaj@taazaa.com"
            };
            var registeredStudent = await studentRepo.RegisterStudentAsync(student);
            Console.WriteLine($"Student Registered: {registeredStudent.Id} - {registeredStudent.Name}");

            // Issue a LibraryCard
            var libraryCard = new LibraryCard
            {
                StudentId = registeredStudent.Id,
                IssueDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddYears(1)
            };
            var issuedCard = await cardRepo.IssueLibraryCardAsync(libraryCard);
            Console.WriteLine($"Library Card Issued: {issuedCard.Id} for Student {issuedCard.StudentId}");

            //  Creating a Book Master Record
            var book = new Book
            {
                Title = "Love is Virtual",
                Author = "Prakash Ghayal",
                TotalCopies = 10,
                AvailableCopies = 10
            };
            var createdBook = await bookRepo.CreateBookAsync(book);
            Console.WriteLine($"Book Created: {createdBook.Id} - {createdBook.Title}");

            // Assign a Book to a Student via LibraryCard
            var assignment = new BookAssignment
            {
                BookId = createdBook.Id,
                LibraryCardId = issuedCard.Id,
                StudentId = registeredStudent.Id,
                FromDate = DateTime.UtcNow,
                ToDate = DateTime.UtcNow.AddDays(15),
                IsReturned = false
            };
            var assignedBook = await assignmentRepo.AssignBookToStudentAsync(assignment);
            Console.WriteLine($"Book Assigned: {assignedBook.BookId} to Student {assignedBook.StudentId}");

            // Gettoing all students who have been assigned that specific book
            var bookAssignments = await assignmentRepo.GetAssignmentsByBookIdAsync(createdBook.Id);
            Console.WriteLine($"\n Assignments for Book ID {createdBook.Id}:");
            foreach (var a in bookAssignments)
            {
                Console.WriteLine($"Student: {a.Student.Name}, Period: {a.FromDate.ToShortDateString()} - {a.ToDate.ToShortDateString()}");
            }

            // Get all books issued under a specific LibraryCard
            var libraryCardAssignments = await assignmentRepo.GetAssignmentsByLibraryCardIdAsync(issuedCard.Id);
            Console.WriteLine($"\nBooks issued under LibraryCardID :  {issuedCard.Id}:");
            foreach (var a in libraryCardAssignments)
            {
                Console.WriteLine($"Book: {a.Book.Title}, Period: {a.FromDate.ToShortDateString()} - {a.ToDate.ToShortDateString()}");
            }
            // 

            Console.WriteLine("----- Thankyou for using BookWala 🙏 -------");
        }
    }
}
