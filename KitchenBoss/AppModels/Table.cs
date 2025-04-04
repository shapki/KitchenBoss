namespace KitchenBoss.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        public int TableID { get; set; }

        public int TableNumber { get; set; }

        public int Capacity { get; set; }
    }
}
