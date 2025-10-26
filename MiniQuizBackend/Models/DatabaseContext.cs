using Microsoft.EntityFrameworkCore;

namespace QuizAPI.Models

{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}