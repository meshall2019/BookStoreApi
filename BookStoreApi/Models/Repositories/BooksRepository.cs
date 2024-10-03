using BookStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models.Repositories
{
    public class BooksRepository : IBooksRepository
    {

        //DbConecction
        public BooksStoreDbContext2 _booksDbContext { get; set; }
        public BooksRepository(BooksStoreDbContext2 booksDbContext)
        {
            _booksDbContext = booksDbContext;
        }


        //Here Get All Books
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {

            return await _booksDbContext.Books.Include(c => c.Category).Include(a => a.Auther).ToListAsync();
        }

        //Here Get Book By Id
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _booksDbContext.Books.Where(c => c.Id == id).Include(c => c.Category).Include(a => a.Auther).FirstOrDefaultAsync();
        }

        //Here Add New Book
        public async Task AddbookAsync(Book book)
        {
            if (book != null)
            {
                await _booksDbContext.Books.AddAsync(book);

            }
            await _booksDbContext.SaveChangesAsync();
        }

        //Here Remove A book
        public void RemoveBook(Book book)
        {

            _booksDbContext.Books.Remove(book);
            _booksDbContext.SaveChanges();

        }


    }
}
