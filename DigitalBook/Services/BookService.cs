using DigitalBook.Model;

namespace DigitalBook.Services
{
    public class BookService : IBookService
    {
        private readonly ConnectionDBContext _connectionDBContext;

        public BookService (ConnectionDBContext connectionDBContext)
        {
            _connectionDBContext = connectionDBContext;
        }   

        public string AddBook(Book book)
        {
            string result = string.Empty;
            try
            {
                _connectionDBContext.Books.Add(book);
                _connectionDBContext.SaveChanges();
                result = "Book Added";
            }
            catch (Exception Ex)
            {
                result = $"Book details not saved {Ex.InnerException}";
            }

            return result;
        }

        public string updateBook(int bookId,Book book)
        {
            string result = string.Empty;
           var books = _connectionDBContext.Books.Where(x=>x.bookId==bookId).SingleOrDefault();
            if (books != null)
            {
                try
                {
                    books.modifiedDate = book.modifiedDate;
                    books.title = book.title;
                    books.publisher = book.publisher;
                    books.category = book.category;
                    books.price = book.price;
                    _connectionDBContext.SaveChanges();

                    result = "Record Updated";
                }
                catch(Exception Ex)
                {
                    result = $"BookId is not exists";
                }
            }
            return result;
        }
        public string DeletedBook(int bookId)
        {
           string result = string.Empty ;
           var books = _connectionDBContext.Books.Where(x=>x.bookId==bookId).SingleOrDefault();
            if (books != null)
            {
                try
                {
                    _connectionDBContext.Remove(books);
                    _connectionDBContext.SaveChanges();
                }


                catch (Exception Ex)
                {
                    result = $"BookId is not exists{Ex.Message}";
                }
            }
            return result;
        }

       
    }
}
