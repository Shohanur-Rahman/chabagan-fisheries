using Chabagan.Chabagan.Fisheries.Models.User;
using Chabagan.Chabagan.Fisheries.Utilities;
using Chabagan.Fisheries.Entities.Models.Setup;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.Entities.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Chabagan.Fisheries.DB
{
    public class FisheriesDbContext : DbContext
    {
        #region Constructors

        public FisheriesDbContext(DbContextOptions<FisheriesDbContext> options) : base(options)
        {

        }
        #endregion

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DemoDataBuilder demoDataBuilder = new DemoDataBuilder(modelBuilder);
            demoDataBuilder.BuildData();
        }

        #endregion


        #region Database Entities
       
        public virtual DbSet<DbUser> Users { get; set; }
        public virtual DbSet<DbRole> Roles { get; set; }
        #endregion

        #region Setup Entities
        public virtual DbSet<DbBrand> Brands { get; set; }
        public virtual DbSet<DbStockCategory> StockCategories { get; set; }
        public virtual DbSet<DbProduct> Products { get; set; }
        public virtual DbSet<DbSupplier> Suppliers { get; set; }
        public virtual DbSet<DbProject> Projects { get; set; }
        public virtual DbSet<DbPond> Ponds { get; set; }
        public virtual DbSet<DbExpenseType> ExpenseTypes { get; set; }

        #endregion



        #region Stock Entities

        public virtual DbSet<DbPurchase> Purchases { get; set; }
        public virtual DbSet<DbPurchaseItem> PurchaseItems { get; set; }

        public virtual DbSet<DbPurchaseReturn> PurchaseReturns { get; set; }
        public virtual DbSet<DbPurchaseReturnItem> PurchaseReturnItems { get; set; }

        public virtual DbSet<DbSales> Sales { get; set; }
        public virtual DbSet<DbSalesItem> SalesItems { get; set; }
        public virtual DbSet<DbSalesReturn> SalesReturns { get; set; }
        public virtual DbSet<DbSalesReturnItem> SalesReturnItems { get; set; }

        public virtual DbSet<DbAccountTransection> AccountTransections { get; set; }
        public virtual DbSet<DbPaymentCollection> PaymentCollections { get; set; }
        public virtual DbSet<DbExpense> Expenses { get; set; }
        public virtual DbSet<DbIncome> Incomes { get; set; }
        #endregion
    }
}
