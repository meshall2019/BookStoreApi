namespace BookStoreApi.Models.Repositories
{
    public interface ICategoriesRepository
    {

        public Task<IEnumerable<Catagory>> GetCategoriesAsync();
        public Task<Catagory> GetCategoryByIdAsync(int id);
        public Task AddCategoryAsync(Catagory category);
        public void RemoveCategory(Catagory category);


    }
}
