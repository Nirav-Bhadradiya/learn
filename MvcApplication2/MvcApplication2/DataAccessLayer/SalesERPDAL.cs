using System.Data.Entity;
using MvcApplication2.Models;

namespace MvcApplication2.DataAccessLayer
{
    public class SalesErpdal : DbContext
    {
        public DbSet<Employee> Employees { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
}