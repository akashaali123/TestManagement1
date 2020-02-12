using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TestManagementContext:IdentityDbContext
    {
        public TestManagementContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<TblUser> TblUser { get; set; }
        public DbSet<TblCandidate> TblCandidate { get; set; }

        public DbSet<TblCategory> TblCategory { get; set; }

        public DbSet<TblExperienceLevel> TblExperienceLevel { get; set; }

        public DbSet<TblOption> TblOption { get; set; }

        public DbSet<TblQuestion> TblQuestion { get; set; }
        public DbSet<TblQuestionCategoryAndExpMapping> TblQuestionCategoryAndExpMapping { get; set; }

        public DbSet<TblRole> TblRole { get; set; }

        public DbSet<TblSessionHistory> TblSessionHistory { get; set; }

        public DbSet<TblTest> TblTest { get; set; }

        public DbSet<TblTestDetails> TblTestDetails { get; set; }

        public DbSet<TblUserRole> TblUserRole { get; set; }

        public DbSet<TblLogging> TblLogging { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            // builder.Entity<TblCandidate>().MapToStoredProcedures();
        //}
    }
}
