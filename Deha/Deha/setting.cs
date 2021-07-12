namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class setting
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string business_name { get; set; }

        [StringLength(10)]
        public string money_unit { get; set; }

        public int? howmanyday_process { get; set; }

        /*
        [StringLength(250)]
        public string onesignal_id { get; set; }
        */
        [StringLength(50)]
        public string app_version { get; set; }

        public int? max_firm { get; set; }
    }
}
