using Microsoft.EntityFrameworkCore;

namespace Database.Contexts;

public class SQLiteContext : BaseContext
{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=pseudbot.db");
        }
}