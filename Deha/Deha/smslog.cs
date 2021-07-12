namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smslog")]
    public partial class smslog
    {
        public int id { get; set; }

        public int? upload_sms { get; set; }

        public int? ref_user { get; set; }

        public DateTime? ref_date { get; set; }
    }
}
