namespace BookStoreApi.Models.Repositories
{
    public interface IAuthersRepository
    {

        public Task<IEnumerable<Auther>> GetAuthersAsync();
        public Task<Auther> GetAutherByIdAsync(int id);
        public Task AddAutherAsync(Auther auther);
        public void RemoveAuther(Auther auther);

    }
}
