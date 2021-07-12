namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sms_template
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        public string message { get; set; }

        public byte type { get; set; }

        public bool active { get; set; }

        public int ref_user { get; set; }

        public DateTime ref_date { get; set; }
    }
}
