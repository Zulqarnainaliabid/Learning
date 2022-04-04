namespace WebApiProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalePerchase")]
    public partial class SalePerchase
    {
        public int ID { get; set; }

        public int? Sale { get; set; }

        public int? Perchase { get; set; }

        [StringLength(50)]
        public string DateAdded { get; set; }

        [StringLength(50)]
        public string DateUpdate { get; set; }

        public int? Price { get; set; }
    }
}
