namespace BookStoreApi.Models.Repositories
{
    public interface IBooksRepository
    {

        public Task<IEnumerable<Book>> GetBooksAsync();
        public Task<Book> GetBookByIdAsync(int id);
        public Task AddbookAsync(Book book);
        public void RemoveBook(Book book);
    }
}
