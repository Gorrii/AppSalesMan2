using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppSalesMan2.Database
{
    public class AppSalesMan2DbContext : DbContext
    {
        public DbSet<SalesMansData> SalesManDatas { get; set; }
        public DbSet<CustomerData> CustomerDatas { get; set; }
        public DbSet<ChangeRequestData> ChangeRequestDatas { get; set; }
        public DbSet<CustomersVolumenData> customersVolumenDatas { get; set; }
        public DbSet<PlansData> plansDatas { get; set; }
        public DbSet<IndirectData> IndirectDatas { get; set; }
        public DbSet<WonOppData> WonOppDatas { get; set; }
        public DbSet<ContentOnMMData> ContentOnMMDatas { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // => options.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database=AppContext.ConnectionResiliency;Trusted_Connection=True;ConnectRetryCount=0");
        //  protected override void OnConfiguring(DbContextOptionsBuilder options)
        // => options.UseSqlServer(@"Server = MD1XZ8FC\SQLEXPRESS; Database=AppContext.ConnectionResiliency;Trusted_Connection=True;ConnectRetryCount=0");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server = MD2QE8BC; Database=SalesMan;Trusted_Connection=True;ConnectRetryCount=0");
    }

}
