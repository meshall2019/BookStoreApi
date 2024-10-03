using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;



namespace BookStoreProject.Models
{
    public class BooksStoreDbContext2 : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("BooksStoreDbContext2");
        //}

        public BooksStoreDbContext2(DbContextOptions<BooksStoreDbContext2> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }



    }
}
