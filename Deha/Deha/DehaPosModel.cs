namespace Deha
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Core.EntityClient;

    public partial class DehaPosModel : DbContext
    {
        public DehaPosModel(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        /// <summary>
        /// Create a new EF6 dynamic data context using the specified provider connection string.
        /// </summary>
        /// <param name="providerConnectionString">Provider connection string to use. Usually a standart ADO.NET connection string.</param>
        /// <returns></returns>
        public static DehaPosModel Create(string providerConnectionString)
        {
            var entityBuilder = new EntityConnectionStringBuilder();

            // use your ADO.NET connection string
            entityBuilder.ProviderConnectionString = providerConnectionString;

            entityBuilder.Provider = "System.Data.SqlClient";

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/Database.DWH.DWModel.csdl|res://*/Database.DWH.DWModel.ssdl|res://*/Database.DWH.DWModel.msl";

            return new DehaPosModel(entityBuilder.ConnectionString);
        }

        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<orders_detail> orders_detail { get; set; }
        public virtual DbSet<printer_list> printer_list { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<received> receiveds { get; set; }
        public virtual DbSet<setting> settings { get; set; }
        public virtual DbSet<sms_template> sms_template { get; set; }
        public virtual DbSet<sms_users> sms_users { get; set; }
        public virtual DbSet<smslog> smslogs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<vehicle> vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<company>()
                .HasMany(e => e.receiveds)
                .WithOptional(e => e.company)
                .HasForeignKey(e => e.ref_company)
                .WillCascadeOnDelete();

            modelBuilder.Entity<customer>()
                .Property(e => e.balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.invoices)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.ref_customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<customer>()
                .HasMany(e => e.receiveds)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.ref_customer);

            modelBuilder.Entity<invoice>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<invoice>()
                .Property(e => e.collect)
                .HasPrecision(19, 4);

            modelBuilder.Entity<order>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<order>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<order>()
                .HasMany(e => e.orders_detail)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.ref_orders);

            modelBuilder.Entity<orders_detail>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<received>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.received)
                .HasForeignKey(e => e.ref_received);

            modelBuilder.Entity<user>()
                .HasMany(e => e.invoices)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.ref_user)
                .WillCascadeOnDelete();

            modelBuilder.Entity<user>()
                .HasMany(e => e.receiveds)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ref_user);

            modelBuilder.Entity<vehicle>()
                .HasMany(e => e.receiveds)
                .WithOptional(e => e.vehicle)
                .HasForeignKey(e => e.ref_vehicle);
        }
    }
}
