namespace WebApiProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(500)]
        public string Discription { get; set; }

        [StringLength(1000)]
        public string Other { get; set; }

        [StringLength(200)]
        public string Img { get; set; }

        [StringLength(100)]
        public string DateAdded { get; set; }

        [StringLength(100)]
        public string DateUpdated { get; set; }

        public bool? is_active { get; set; }
    }
}
