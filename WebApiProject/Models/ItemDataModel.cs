namespace WebApiProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ItemDataModel : DbContext
    {
        public ItemDataModel()
            : base("name=ItemDataModel")
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<SalePerchase> SalePerchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
