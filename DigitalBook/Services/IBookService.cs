using DigitalBook.Model;

namespace DigitalBook.Services
{
    public interface IBookService
    {
        string AddBook(Book book);
        string updateBook( int bookId,Book book);
        string DeletedBook(int bookId);
        //string ModifiedBook(List<Book> books, Book book);
    }
}