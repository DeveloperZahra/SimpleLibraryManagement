using SimpleLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Repositories
{
    public class BookRepository 
    {
        public void AddBook(Book book)
        {
            var books = GetAllBooks();
            books.Add(book);
            FileContext.SaveBooks(books);
        }



        public List<Book> GetAllBooks()
        {
            return FileContext.LoadBooks();
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
