using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KmK_Business.Model
{
    class KmKContext : DbContext
    {
        public DbSet<AdminDB> AdminDB { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<TradingJournalModel> TradingJournalModel { get; set; }


        public KmKContext()
          : base("name=KmKContext")
        { }

        public KmKContext(string connectionString)
            : base(new SQLiteConnection() { ConnectionString = connectionString }, true)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
