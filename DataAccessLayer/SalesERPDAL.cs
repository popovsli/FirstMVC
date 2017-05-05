using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BusinessEntities;

namespace DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {
        //If change connection string name
        //public SalesERPDAL() : base("NewName")
        //{
        //}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            modelBuilder.Entity<UserDetails>().ToTable("TblUserDetails");
            base.OnModelCreating(modelBuilder);
        }
    }
}