using System.Data.Entity;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Conventions;
using HtmlParser.Data;

namespace HtmlParser.DataAccess.Contexts
{
    public class DefaultContext : DbContext
    {
        public DefaultContext()
         : base(new SQLiteConnection()
         {
             ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = @".\ParsingData.db", ForeignKeys = true }.ConnectionString
         }, true)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            base.OnModelCreating(modelBuilder);
            var initializer =
            new SQLite.CodeFirst.SqliteCreateDatabaseIfNotExists<DefaultContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<Parsing> Parsing { get; set; }
        public DbSet<HttpResponce> Responce { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagAttribute> Attribute { get; set; }

    }
}
