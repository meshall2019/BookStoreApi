using BookStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models.Repositories
{
    public class AuthersRepository : IAuthersRepository
    {

        public BooksStoreDbContext2 _booksDbContext { get; set; }


        public AuthersRepository(BooksStoreDbContext2 booksDbContext)
        {
            _booksDbContext = booksDbContext;
        }


        public async Task<IEnumerable<Auther>> GetAuthersAsync()
        {

            return await _booksDbContext.Authers.Include(b => b.books).ToListAsync();
        }

        public async Task<Auther> GetAutherByIdAsync(int id)
        {
            return await _booksDbContext.Authers.Include(a => a.books).Where(c => c.Id == id).FirstOrDefaultAsync();
        }


        public async Task AddAutherAsync(Auther auther)
        {
            if (auther != null)
            {
                await _booksDbContext.Authers.AddAsync(auther);

            }
            await _booksDbContext.SaveChangesAsync();
        }


        public void RemoveAuther(Auther auther)
        {

            _booksDbContext.Authers.Remove(auther);
            _booksDbContext.SaveChanges();

        }


    }
}
