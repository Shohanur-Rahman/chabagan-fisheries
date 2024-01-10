using Chabagan.Chabagan.Fisheries.Models.User;
using Chabagan.Chabagan.Fisheries.Utilities;
using Chabagan.Fisheries.Entities.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
