using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Truyum_CaseStudy_DotNetCore.Models
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
    public class TruYumContext:DbContext
    {

        public TruYumContext(DbContextOptions<TruYumContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.RemovePluralizingTableNameConvention();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
    }
}
