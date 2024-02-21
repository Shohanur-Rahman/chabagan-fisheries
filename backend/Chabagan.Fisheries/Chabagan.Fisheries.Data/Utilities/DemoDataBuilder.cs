using Chabagan.Chabagan.Fisheries.Models.User;
using Chabagan.Fisheries.Common.Encription;
using Chabagan.Fisheries.Entities.Models.Setup;
using Chabagan.Fisheries.Entities.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Chabagan.Fisheries.Utilities
{
    public class DemoDataBuilder
    {
        #region "Constructors #
        /// <summary>
        /// Inject Model Builder
        /// </summary>
        private ModelBuilder modelBuilder;
        public DemoDataBuilder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Build demo data
        /// </summary>
        public void BuildData()
        {
            this.SetupTransectionTypeData();
            this.SetupRoleData();
            this.SetupUserData();
            this.SetupStockData();
        }

        #endregion

        #region Setup Master Data

        private void SetupTransectionTypeData()
        {
            this.modelBuilder.Entity<DbTransectionType>().HasData(
                new DbTransectionType
                {
                    Id = 1,
                    Name = "Purchase"
                },
                new DbTransectionType
                {
                    Id = 2,
                    Name = "Purchase Return",
                },
                new DbTransectionType
                {
                    Id = 3,
                    Name = "Sales",
                },
                new DbTransectionType
                {
                    Id = 4,
                    Name = "Sales Return",
                },
                new DbTransectionType
                {
                    Id = 5,
                    Name = "Income",
                },
                new DbTransectionType
                {
                    Id = 6,
                    Name = "Expense",
                },
                new DbTransectionType
                {
                    Id = 7,
                    Name = "Payment",
                },
                new DbTransectionType
                {
                    Id = 8,
                    Name = "Collection",
                }
            );
        }

        private void SetupRoleData()
        {
            this.modelBuilder.Entity<DbRole>().HasData(
                new DbRole
                {
                    Id = 1,
                    Name = "System Administrator"
                },
                new DbRole
                {
                    Id = 2,
                    Name = "Business Manager",
                },
                new DbRole
                {
                    Id = 3,
                    Name = "General User",
                }
            );
        }

        private void SetupUserData()
        {
            string salt = EncryptPassword.GetSalt();
            this.modelBuilder.Entity<DbUser>().HasData(
                new DbUser
                {
                    Id = 1,
                    Name = "Admin User",
                    Email = "admin@gmail.com",
                    PasswordSalt = salt,
                    Password = EncryptPassword.GetHas("Password1!", salt),
                    RoleId= 1,
                    CreatedDate = DateTime.Now
                },
                new DbUser
                {
                    Id = 2,
                    Name = "Site Manager",
                    Email = "manager@gmail.com",
                    PasswordSalt = salt,
                    Password = EncryptPassword.GetHas("Password2!", salt),
                    RoleId = 2,
                    CreatedDate = DateTime.Now
                },
                new DbUser
                {
                    Id = 3,
                    Name = "Field User",
                    Email = "user@gmail.com",
                    PasswordSalt = salt,
                    Password = EncryptPassword.GetHas("Password1!", salt),
                    RoleId = 3,
                    CreatedDate = DateTime.Now
                }
            );
        }
        #endregion

        #region Setup Stock Data
        private void SetupStockData()
        {


            this.modelBuilder.Entity<DbProject>().HasData(
                new DbProject
                {
                    Id = 1,
                    Name = "চা বাগান 1"
                },
                new DbProject
                {
                    Id = 2,
                    Name = "চা বাগান 2"
                }
            );

            this.modelBuilder.Entity<DbPond>().HasData(
               new DbPond
               {
                   Id = 1,
                   Name = "মধুমতি",
                   ProjectId = 1
               },
               new DbPond
               {
                   Id = 2,
                   Name = "সূর্যমুখী",
                   ProjectId = 1
               },
               new DbPond
               {
                   Id = 3,
                   Name = "নীলকন্যা",
                   ProjectId = 2
               }
           );

            this.modelBuilder.Entity<DbBrand>().HasData(
                new DbBrand
                {
                    Id = 1,
                    Name = "Squre"
                },
                new DbBrand
                {
                    Id = 2,
                    Name = "Beximco",
                },
                new DbBrand
                {
                    Id = 3,
                    Name = "Ibn Sina",
                }
            );

            this.modelBuilder.Entity<DbStockCategory>().HasData(
                new DbStockCategory
                {
                    Id = 1,
                    Name = "Medicine"
                },
                new DbStockCategory
                {
                    Id = 2,
                    Name = "Feed",
                },
                new DbStockCategory
                {
                    Id = 3,
                    Name = "Accessories",
                }
            );

            this.modelBuilder.Entity<DbProduct>().HasData(
                new DbProduct
                {
                    Id = 1,
                    Name = "Napa Extra",
                    CategoryId=1,
                    MRP= Convert.ToDecimal(50.65),
                    Description= "First, make sure you have Material-UI installed in your project:"
                },
                new DbProduct
                {
                    Id = 2,
                    Name = "Peracitamol",
                    CategoryId = 1,
                    MRP = Convert.ToDecimal(50.65),
                    Description = "First, make sure you have Material-UI installed in your project:"
                },
                new DbProduct
                {
                    Id = 3,
                    Name = "Filmate",
                    CategoryId = 1,
                    MRP = Convert.ToDecimal(50.65),
                    Description = "First, make sure you have Material-UI installed in your project:"
                }
            );


            this.modelBuilder.Entity<DbSupplier>().HasData(
                new DbSupplier
                {
                    Id = 1,
                    Name = "Abdullah Al Mamun",
                    ShopName = "Mamun Hatchary and Feeds",
                    Mobile = "017XX XXXX"
                },
                new DbSupplier
                {
                    Id = 2,
                    Name = "Sohel Tanvir",
                    ShopName = "Tanvir Hatchary and Feeds",
                    Mobile = "017XX XXXX"
                },
                new DbSupplier
                {
                    Id = 3,
                    Name = "Nusrat Imroz",
                    ShopName = "Nusrat Hatchary and Feeds",
                    Mobile = "017XX XXXX"
                }
            );

        }
        #endregion
    }
}
