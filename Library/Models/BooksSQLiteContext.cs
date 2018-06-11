using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BooksSQLiteContext: DbContext
    {
        public BooksSQLiteContext() { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_popularity> Author_popularityTable { get; set; }
        public DbSet<Book_popularity> Book_popularityTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyDbBooks.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
