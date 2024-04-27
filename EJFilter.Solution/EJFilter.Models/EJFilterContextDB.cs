
using EJFilter.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models
{
    public class EJFilterContextDB : DbContext
    {
        public EJFilterContextDB() : base("EJContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<EJFilterContextDB>(null);
        }

        public EJFilterContextDB(string  connectionString):base(connectionString)
        {
            Database.SetInitializer<EJFilterContextDB>(null);
        }

        public DbSet<MasterBranch> MasterBranches { get; set; }
        public DbSet<MasterStore> MasterStores { get; set; }
        public DbSet<MasterCompany> MasterCompany { get; set; }
        public DbSet<ConfigTypes> ConfigType { get; set; }
        public DbSet<POSSystem> POSSystems { get; set; }
        public DbSet<TelnetServer> TelnetServers { get; set; }
        public DbSet<DBCredentials> DBCredentials { get; set; }
        public DbSet<HeaderFooterVQP> HeaderFooterFormat { get; set; }
        public DbSet<HeaderFooterTP> HeaderFooterFormatTP { get; set; }
        public DbSet<ImportTPFiles> ImportTPFiles { get; set; }

        //public static string ConnectToSqlServer()
        //{
        //    SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
        //    {
        //        DataSource = "ServerName",
        //        InitialCatalog = "DatabaseName",
        //        PersistSecurityInfo = true,
        //        IntegratedSecurity = false,
        //        MultipleActiveResultSets = true,

        //        UserID = "Username",
        //        Password = "Password",
        //    };
        //    var entityConnectionStringBuilder = new EntityConnectionStringBuilder
        //    {
        //        Provider = "System.Data.SqlClient",
        //        ProviderConnectionString = sqlBuilder.ConnectionString,
        //        Metadata = "res://*/Data.Database.csdl|res://*/Data.Database.ssdl|res://*/Data.Database.msl",
        //    };

        //    return entityConnectionStringBuilder.ConnectionString;
        //}
    }

    
}
