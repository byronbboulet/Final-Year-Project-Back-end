using MentalHealthAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalHealthAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // this is the posts table in the database which is used to store all the posts, any operations to read ,create, update and delete posts are editing this table
        public DbSet<Post> posts => Set<Post>();

        public DbSet<User> Users => Set<User>();

    }
}
