
using BookStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public BooksStoreDbContext2 _booksDbContext { get; set; }


        public CategoriesRepository(BooksStoreDbContext2 booksDbContext)
        {
            _booksDbContext = booksDbContext;
        }


        public async Task<IEnumerable<Catagory>> GetCategoriesAsync()
        {

            return await _booksDbContext.Catagories.Include(b => b.books).ToListAsync();
        }

        public async Task<Catagory> GetCategoryByIdAsync(int id)
        {
            return await _booksDbContext.Catagories.Include(b => b.books).Where(c => c.Id == id).FirstOrDefaultAsync();
        }


        public async Task AddCategoryAsync(Catagory category)
        {
            if (category != null)
            {
                await _booksDbContext.Catagories.AddAsync(category);

            }
            await _booksDbContext.SaveChangesAsync();
        }


        public void RemoveCategory(Catagory category)
        {

            _booksDbContext.Catagories.Remove(category);
            _booksDbContext.SaveChanges();

        }



    }
}
