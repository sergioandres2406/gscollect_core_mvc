using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GSCollect_MVC.Models;

public partial class GscollectContext : DbContext
{
    public GscollectContext()
    {
    }

    public GscollectContext(DbContextOptions<GscollectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppAccount> AppAccounts { get; set; }

    public virtual DbSet<AppPlan> AppPlans { get; set; }

    public virtual DbSet<AppPlanService> AppPlanServices { get; set; }

    public virtual DbSet<AppService> AppServices { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<CollectOrder> CollectOrders { get; set; }

    public virtual DbSet<CollectOrderLine> CollectOrderLines { get; set; }

    public virtual DbSet<CollectOrderLinesAmountPaidView> CollectOrderLinesAmountPaidViews { get; set; }

    public virtual DbSet<CollectOrderLinesView> CollectOrderLinesViews { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }

    public virtual DbSet<MenuCategory> MenuCategories { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonContact> PersonContacts { get; set; }

    public virtual DbSet<PersonCustomer> PersonCustomers { get; set; }

    public virtual DbSet<PersonCustomersView> PersonCustomersViews { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<SaleOrderLine> SaleOrderLines { get; set; }

    public virtual DbSet<SaleOrderLinesView> SaleOrderLinesViews { get; set; }

    public virtual DbSet<SaleOrderPayment> SaleOrderPayments { get; set; }

    public virtual DbSet<SaleOrderPaymentsView> SaleOrderPaymentsViews { get; set; }

    public virtual DbSet<SaleOrderProjectedPayment> SaleOrderProjectedPayments { get; set; }

    public virtual DbSet<SaleOrderStatus> SaleOrderStatuses { get; set; }

    public virtual DbSet<SalePaymentCollector> SalePaymentCollectors { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<SalesOrdersView> SalesOrdersViews { get; set; }

    public virtual DbSet<SalesPaymentCollectorCommissionView> SalesPaymentCollectorCommissionViews { get; set; }

    public virtual DbSet<SalesPerson> SalesPersons { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<TblSalesOrderExcelTemp> TblSalesOrderExcelTemps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=gscollectsqlserver.database.windows.net;Database=GSCollect;User ID=GSCollectAdmin;Password=Castlevania2618;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppAccount>(entity =>
        {
            entity.HasKey(e => e.AppAccountId).HasName("PK__appAccou__01E5425A8E480CB8");

            entity.ToTable("appAccounts", "Sales");

            entity.HasIndex(e => e.Code, "app_accounts_code").IsUnique();

            entity.HasIndex(e => e.Name, "app_accounts_name").IsUnique();

            entity.HasIndex(e => e.Status, "app_accounts_status");

            entity.Property(e => e.AppAccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appAccountId");
            entity.Property(e => e.AdministratorId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("administratorId");
            entity.Property(e => e.BillingDay)
                .HasDefaultValue(1)
                .HasColumnName("billingDay");
            entity.Property(e => e.BillingMode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("billingMode");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreditCardId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("creditCardId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.AppAccounts)
                .HasForeignKey(d => d.CreditCardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__appAccoun__credi__19DFD96B");
        });

        modelBuilder.Entity<AppPlan>(entity =>
        {
            entity.HasKey(e => e.AppPlanId).HasName("PK__appPlans__C845FD933FB5E3FD");

            entity.ToTable("appPlans", "Sales");

            entity.HasIndex(e => e.IsActive, "app_plans_is_active");

            entity.HasIndex(e => e.Name, "app_plans_name").IsUnique();

            entity.Property(e => e.AppPlanId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appPlanId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ExpirationDate).HasColumnName("expirationDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
        });

        modelBuilder.Entity<AppPlanService>(entity =>
        {
            entity.HasKey(e => e.AppPlanServiceId).HasName("PK__appPlanS__EA5848594702AA45");

            entity.ToTable("appPlanServices", "Sales");

            entity.HasIndex(e => new { e.AppPlanId, e.Name }, "app_plan_services_app_plan_id_name").IsUnique();

            entity.HasIndex(e => e.AppServiceId, "app_plan_services_app_service_id");

            entity.Property(e => e.AppPlanServiceId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appPlanServiceId");
            entity.Property(e => e.ActivationPrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("activationPrice");
            entity.Property(e => e.AppPlanId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appPlanId");
            entity.Property(e => e.AppServiceId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appServiceId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.MaxUnits).HasColumnName("maxUnits");
            entity.Property(e => e.MinUnits).HasColumnName("minUnits");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RecurringBasePrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("recurringBasePrice");
            entity.Property(e => e.RecurringUnitPrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("recurringUnitPrice");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

            entity.HasOne(d => d.AppPlan).WithMany(p => p.AppPlanServices)
                .HasForeignKey(d => d.AppPlanId)
                .HasConstraintName("FK__appPlanSe__appPl__1CBC4616");

            entity.HasOne(d => d.AppService).WithMany(p => p.AppPlanServices)
                .HasForeignKey(d => d.AppServiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__appPlanSe__appSe__1DB06A4F");
        });

        modelBuilder.Entity<AppService>(entity =>
        {
            entity.HasKey(e => e.AppServiceId).HasName("PK__appServi__AFFD238AFFA2D59F");

            entity.ToTable("appServices", "Sales");

            entity.HasIndex(e => e.IsActive, "app_services_is_active");

            entity.HasIndex(e => e.Name, "app_services_name").IsUnique();

            entity.Property(e => e.AppServiceId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appServiceId");
            entity.Property(e => e.ActivationPrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("activationPrice");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RecurringBasePrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("recurringBasePrice");
            entity.Property(e => e.RecurringUnitPrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("recurringUnitPrice");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
        });

        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.ToTable("BusinessUnits", "BusinessCore");

            entity.Property(e => e.BusinessUnitId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CollectOrder>(entity =>
        {
            entity.ToTable("CollectOrders", "Sales");

            entity.HasIndex(e => e.CollectDateFrom, "IX_CollectOrders_CollectDate").IsDescending();

            entity.HasIndex(e => e.CollectDateTo, "IX_CollectOrders_CollectDateTo").IsDescending();

            entity.HasIndex(e => e.DateProcessed, "IX_CollectOrders_DateProcessed").IsDescending();

            entity.HasIndex(e => e.PaymentCollectorId, "IX_CollectOrders_PaymentCollectorId");

            entity.HasIndex(e => e.Reference, "IX_CollectOrders_Reference")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.CollectDateFrom).HasColumnType("smalldatetime");
            entity.Property(e => e.CollectDateTo).HasColumnType("smalldatetime");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateProcessed).HasColumnType("smalldatetime");
            entity.Property(e => e.Reference).HasMaxLength(50);

            entity.HasOne(d => d.PaymentCollector).WithMany(p => p.CollectOrders)
                .HasForeignKey(d => d.PaymentCollectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectOrders_SalePaymentCollectors");
        });

        modelBuilder.Entity<CollectOrderLine>(entity =>
        {
            entity.ToTable("CollectOrderLines", "Sales");

            entity.HasIndex(e => e.CollectOrderId, "IX_CollectOrderLines_CollectOrderId").IsDescending();

            entity.HasIndex(e => e.DateProcessed, "IX_CollectOrderLines_DateProcessed").IsDescending();

            entity.HasIndex(e => e.Planned, "IX_CollectOrderLines_Planned").IsDescending();

            entity.HasIndex(e => e.SaleOrderProjectedPaymentId, "IX_CollectOrderLines_SaleOrderProjectedPaymentId").IsDescending();

            entity.HasIndex(e => e.CollectOrderId, "nci_wi_CollectOrderLines_06D837863864CE4382496E5121A66D5A");

            entity.Property(e => e.Amount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateProcessed).HasColumnType("smalldatetime");
            entity.Property(e => e.Planned).HasDefaultValue(true);

            entity.HasOne(d => d.CollectOrder).WithMany(p => p.CollectOrderLines)
                .HasForeignKey(d => d.CollectOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectOrderLines_CollectOrders");

            entity.HasOne(d => d.SaleOrderProjectedPayment).WithMany(p => p.CollectOrderLines)
                .HasForeignKey(d => d.SaleOrderProjectedPaymentId)
                .HasConstraintName("FK_CollectOrderLines_SaleOrderProjectedPayments");
        });

        modelBuilder.Entity<CollectOrderLinesAmountPaidView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CollectOrderLinesAmountPaidView", "Sales");

            entity.Property(e => e.AmountPaid).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<CollectOrderLinesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CollectOrderLinesView", "Sales");

            entity.Property(e => e.Amount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.CollectDateFrom).HasColumnType("smalldatetime");
            entity.Property(e => e.CollectDateTo).HasColumnType("smalldatetime");
            entity.Property(e => e.CollectOrderDateProcessed).HasColumnType("smalldatetime");
            entity.Property(e => e.DateCreated).HasColumnType("smalldatetime");
            entity.Property(e => e.DateProcessed).HasColumnType("smalldatetime");
            entity.Property(e => e.ProjectPaymentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Reference).HasMaxLength(50);
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.CreditCardId).HasName("PK__creditCa__99D323FCFFE51005");

            entity.ToTable("creditCards", "Sales");

            entity.Property(e => e.CreditCardId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("creditCardId");
            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(255)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Expiration)
                .HasMaxLength(255)
                .HasColumnName("expiration");
            entity.Property(e => e.Metadata)
                .HasMaxLength(4000)
                .HasColumnName("metadata");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .HasColumnName("postalCode");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .HasColumnName("state");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
        });

        modelBuilder.Entity<CustomerStatus>(entity =>
        {
            entity.ToTable("CustomerStatuses", "Customers");

            entity.Property(e => e.CustomerStatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuCategory>(entity =>
        {
            entity.ToTable("MenuCategories", "Infrastruture");

            entity.Property(e => e.MenuCategoryId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.ToTable("MenuItems", "Infrastruture");

            entity.Property(e => e.MenuItemId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MenuItemNavigation).WithOne(p => p.MenuItem)
                .HasForeignKey<MenuItem>(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuItems_MenuCategories");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Persons", "BusinessCore");

            entity.HasIndex(e => e.Address, "nci_wi_Persons_AEBC14129EBBA3C0467D84EFE7CC7667");

            entity.HasIndex(e => e.IdentifierNumber, "nci_wi_Persons_F737D7C6DAAA6505957AE184F4DA04F7");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(203)
                .HasComputedColumnSql("((((((rtrim([FirstName])+' ')+isnull(rtrim([MiddleName]),''))+' ')+rtrim([LastName]))+' ')+isnull(rtrim([SecondLastName]),''))", false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SecondLastName).HasMaxLength(50);
        });

        modelBuilder.Entity<PersonContact>(entity =>
        {
            entity.ToTable("PersonContacts", "BusinessCore");

            entity.Property(e => e.PersonContactId).ValueGeneratedNever();
            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.PersonContacts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonContacts_Contacts");
        });

        modelBuilder.Entity<PersonCustomer>(entity =>
        {
            entity.ToTable("PersonCustomers", "Customers");

            entity.HasIndex(e => e.PersonId, "nci_wi_PersonCustomers_3257712796C1E08CC93A73962892DD08");

            entity.HasOne(d => d.CustomerStatus).WithMany(p => p.PersonCustomers)
                .HasForeignKey(d => d.CustomerStatusId)
                .HasConstraintName("FK_PersonCustomers_CustomerStatuses");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonCustomers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonCustomers_Persons");
        });

        modelBuilder.Entity<PersonCustomersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PersonCustomersView", "Customers");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerStatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(203);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SecondLastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products", "Products");

            entity.HasIndex(e => e.Name, "IX_Products_Name").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DefaultPrice).HasColumnType("decimal(25, 5)");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductCategories");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategories", "Products");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SaleOrderLine>(entity =>
        {
            entity.ToTable("SaleOrderLines", "Sales");

            entity.HasIndex(e => e.ProductId, "IX_SaleOrderLines_ProductId").IsDescending();

            entity.HasIndex(e => e.SaleOrderId, "IX_SaleOrderLines_SaleOrderId").IsDescending();

            entity.Property(e => e.Amount)
                .HasComputedColumnSql("([Units]*[UnitPrice])", false)
                .HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(28, 5)");
            entity.Property(e => e.Units).HasColumnType("decimal(28, 5)");
            entity.Property(e => e.UnitsRemoved).HasColumnType("decimal(28, 5)");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrderLines_Products");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.SaleOrderLines)
                .HasForeignKey(d => d.SaleOrderId)
                .HasConstraintName("FK_SaleOrderLines_SalesOrders");
        });

        modelBuilder.Entity<SaleOrderLinesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SaleOrderLinesView", "Sales");

            entity.Property(e => e.Amount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Balance).HasColumnType("decimal(29, 2)");
            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Customer).HasMaxLength(203);
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CustomerAddress2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CustomerCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerComments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CustomerHomePhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustomerMobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustomerOfficePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateSold).HasColumnType("datetime");
            entity.Property(e => e.DefaultPrice).HasColumnType("decimal(25, 5)");
            entity.Property(e => e.PaymentDayComments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Period)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Product)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaleOrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SalePerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(28, 5)");
            entity.Property(e => e.Units).HasColumnType("decimal(28, 5)");
        });

        modelBuilder.Entity<SaleOrderPayment>(entity =>
        {
            entity.HasKey(e => e.SaleOrderPaymentId).HasName("PK_SaleOrderPeyments");

            entity.ToTable("SaleOrderPayments", "Sales");

            entity.HasIndex(e => e.CollectOrderLineId, "IX_SaleOrderPayments_CollectOrderLineId").IsDescending();

            entity.HasIndex(e => e.CreatedBy, "IX_SaleOrderPayments_CreatedBy").IsDescending();

            entity.HasIndex(e => e.PaymentCollectorId, "IX_SaleOrderPayments_PaymentCollectorId").IsDescending();

            entity.HasIndex(e => e.PaymentDate, "IX_SaleOrderPayments_PaymentDate").IsDescending();

            entity.HasIndex(e => e.SaleOrderProjectedPaymentId, "IX_SaleOrderPayments_SaleOrderProjectedPaymentId").IsDescending();

            entity.Property(e => e.Amount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DatePaid)
                .HasComputedColumnSql("(CONVERT([smalldatetime],(((CONVERT([varchar](2),datepart(month,[PaymentDate]),(0))+'/')+CONVERT([varchar](2),datepart(day,[PaymentDate]),(0)))+'/')+CONVERT([varchar](4),datepart(year,[paymentdate]),(0)),(0)))", false)
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.CollectOrderLine).WithMany(p => p.SaleOrderPayments)
                .HasForeignKey(d => d.CollectOrderLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_SaleOrderPayments_CollectOrderLines");

            entity.HasOne(d => d.PaymentCollector).WithMany(p => p.SaleOrderPayments)
                .HasForeignKey(d => d.PaymentCollectorId)
                .HasConstraintName("FK_SaleOrderPayments_SalePaymentCollectors");

            entity.HasOne(d => d.SaleOrderProjectedPayment).WithMany(p => p.SaleOrderPayments)
                .HasForeignKey(d => d.SaleOrderProjectedPaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrderPayments_SaleOrderProjectedPayments");
        });

        modelBuilder.Entity<SaleOrderPaymentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SaleOrderPaymentsView", "Sales");

            entity.Property(e => e.AmountPaid).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Balance).HasColumnType("decimal(29, 2)");
            entity.Property(e => e.Collector)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateSold).HasColumnType("datetime");
            entity.Property(e => e.DownPayment).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.FirstDateOfPayment).HasColumnType("smalldatetime");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PaymentDayComments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Period)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ProjectedPaymentAmount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.ProjectedPaymentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalUnits).HasColumnType("decimal(28, 5)");
            entity.Property(e => e.TotalUnitsRemoved).HasColumnType("decimal(28, 5)");
        });

        modelBuilder.Entity<SaleOrderProjectedPayment>(entity =>
        {
            entity.ToTable("SaleOrderProjectedPayments", "Sales");

            entity.HasIndex(e => e.PaymentDate, "IX_SaleOrderProjectedPayments_PaymentDate").IsDescending();

            entity.HasIndex(e => new { e.SequenceNumber, e.SaleOrderId }, "IX_SaleOrderProjectedPayments_SequenceNumber_SaleOrderId").IsUnique();

            entity.HasIndex(e => new { e.SaleOrderId, e.SaleOrderProjectedPaymentId }, "nci_wi_SaleOrderProjectedPayments_2BC60BE7DFEE65ABF42AA6E4F0D80AB6");

            entity.Property(e => e.Amount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.SaleOrderProjectedPayments)
                .HasForeignKey(d => d.SaleOrderId)
                .HasConstraintName("FK_SaleOrderProjectedPayments_SalesOrders");
        });

        modelBuilder.Entity<SaleOrderStatus>(entity =>
        {
            entity.ToTable("SaleOrderStatuses", "Sales");

            entity.Property(e => e.SaleOrderStatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalePaymentCollector>(entity =>
        {
            entity.ToTable("SalePaymentCollectors", "Sales");

            entity.HasIndex(e => e.Name, "IX_SalePaymentCollectors_Name").IsUnique();

            entity.Property(e => e.Commission).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.SaleOrderId);

            entity.ToTable("SalesOrders", "Sales");

            entity.HasIndex(e => e.CustomerId, "IX_SalesOrders_CustomerId").IsDescending();

            entity.HasIndex(e => e.DateSold, "IX_SalesOrders_DateSold").IsDescending();

            entity.HasIndex(e => e.SaleOrderNumber, "IX_SalesOrders_SaleOrderNumber").IsUnique();

            entity.HasIndex(e => e.SaleOrderStatusId, "IX_SalesOrders_SaleOrderStatusId").IsDescending();

            entity.HasIndex(e => e.SalesPersonId, "IX_SalesOrders_SalesPersonId").IsDescending();

            entity.Property(e => e.Balance)
                .HasComputedColumnSql("([TotalAmount]-[TotalPaid])", false)
                .HasColumnType("decimal(29, 2)");
            entity.Property(e => e.Comments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DateSold).HasColumnType("datetime");
            entity.Property(e => e.DownPayment).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.FirstDateOfPayment).HasColumnType("smalldatetime");
            entity.Property(e => e.NumberOfPayments).HasDefaultValue(1);
            entity.Property(e => e.PaymentAmount)
                .HasComputedColumnSql("([TotalAmount]/[numberofpayments])", false)
                .HasColumnType("decimal(38, 12)");
            entity.Property(e => e.PaymentDayComments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Period)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalPaid)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalUnits).HasColumnType("decimal(28, 5)");
            entity.Property(e => e.TotalUnitsRemoved).HasColumnType("decimal(28, 5)");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrders_PersonCustomers");

            entity.HasOne(d => d.SaleOrderStatus).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.SaleOrderStatusId)
                .HasConstraintName("FK_SalesOrders_SaleOrderStatuses");

            entity.HasOne(d => d.SalesPerson).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.SalesPersonId)
                .HasConstraintName("FK_SalesOrders_SalesPersons");
        });

        modelBuilder.Entity<SalesOrdersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SalesOrdersView", "Sales");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Balance).HasColumnType("decimal(29, 2)");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DateSold).HasColumnType("datetime");
            entity.Property(e => e.DownPayment).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.FirstDateOfPayment).HasColumnType("smalldatetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.PaymentDayComments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Period)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SalesPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SecondLastName).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalUnits).HasColumnType("decimal(28, 5)");
            entity.Property(e => e.TotalUnitsRemoved).HasColumnType("decimal(28, 5)");
        });

        modelBuilder.Entity<SalesPaymentCollectorCommissionView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SalesPaymentCollectorCommissionView", "Sales");

            entity.Property(e => e.AmountPaid).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Balance).HasColumnType("decimal(29, 2)");
            entity.Property(e => e.CommissionPercentage).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.DatePaid).HasColumnType("smalldatetime");
            entity.Property(e => e.DateSold).HasColumnType("datetime");
            entity.Property(e => e.PaymentCollector)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(28, 2)");
            entity.Property(e => e.TotalPaidBySaleOrder).HasColumnType("decimal(28, 2)");
        });

        modelBuilder.Entity<SalesPerson>(entity =>
        {
            entity.ToTable("SalesPersons", "Sales");

            entity.Property(e => e.Commission).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("PK__settings__097EE23C670DF49F");

            entity.ToTable("settings", "Sales");

            entity.Property(e => e.SettingId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("settingId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
        });

        modelBuilder.Entity<TblSalesOrderExcelTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblSalesOrderExcelTemp");

            entity.Property(e => e.Balance).HasColumnType("decimal(28, 2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "Security");

            entity.HasIndex(e => e.FullName, "IX_Users_FullName").IsUnique();

            entity.HasIndex(e => e.Password, "IX_Users_Password").IsUnique();

            entity.HasIndex(e => e.UserName, "IX_Users_UserName").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.ToTable("UserGroups", "Security");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
