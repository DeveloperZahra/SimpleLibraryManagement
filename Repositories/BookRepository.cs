using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(LibraryBook Book)
        {
            var Books = GetAllBooks();
            Books.Add(Book);
            FileContext.SaveBooks(Books);
        }


        public LibraryBook GetBook(int id)

        {
            return GetAllBooks().FirstOrDefault(x => x.Id == id);
        }


        public void UpdateBook(LibraryBook Book)
        {
            var Books = GetAllBooks();
            var index = Books.FindIndex(x => x.Id == Book.Id);
            if (index != -1)
            {
                Books[index] = Book;
                FileContext.SaveBooks(Books);
            }

        }

        public List<LibraryBook> GetAllBooks()
        {
            return FileContext.LoadBooks();
        }







    }
}
