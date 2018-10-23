using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StandardWebsite.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? LastLogin { get; set; }
        public DeleteFlag DeleteFlag { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }
    }

    public enum DeleteFlag
    {
        Active = 0,
        Inactive = 1
    }

    public class StandardWebsiteContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}