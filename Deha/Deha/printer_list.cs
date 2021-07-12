namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class printer_list
    {
        public int id { get; set; }

        [StringLength(255)]
        public string names { get; set; }

        [StringLength(255)]
        public string adress { get; set; }
    }
}
