using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.OptifySoft
{
    public class DatabaseContext : DbContext, IApplicationDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        // 3.1 Core System
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<MenuPermission> MenuPermissions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        // 3.2 CRM Module
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }

        // 3.3 Sales Module
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        // 3.4 Purchase & Vendors
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        //public DbSet<GoodsReceived> GoodsReceived { get; set; }

        // 3.5 Inventory / Stock
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

        // 3.6 Accounts & Finance
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        //public DbSet<Expense> Expenses { get; set; }

        // 3.7 HR & Staff
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        //public DbSet<Leave> Leaves { get; set; }

        // 3.8 Project / Service
       // public DbSet<Job> Jobs { get; set; }
        //public DbSet<JobAssignment> JobAssignments { get; set; }
       // public DbSet<ServiceReport> ServiceReports { get; set; }

        // 3.9 Tenant & Audit
        public DbSet<TenantSetting> TenantSettings { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        // SaveChangesAsync
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        // OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PostgreSQL best practice: lowercase table names
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());
            }

            // Composite key example
            modelBuilder.Entity<RolePermission>()
                .HasKey(x => new { x.RoleId, x.PermissionId, x.TenantId });
            // Explicit primary key for AuditLog
            modelBuilder.Entity<AuditLog>()
                .HasKey(x => x.AuditId);
            modelBuilder.Entity<Attendance>().HasKey(x => x.AttendanceId);
            modelBuilder.Entity<Employee>().HasKey(x => x.EmployeeId);
            modelBuilder.Entity<Account>().HasKey(x => x.AccountId);
            modelBuilder.Entity<Payment>().HasKey(x => x.PaymentId);
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
            modelBuilder.Entity<Warehouse>().HasKey(x => x.WarehouseId);
            modelBuilder.Entity<StockTransaction>().HasKey(x => x.TransactionId);
            modelBuilder.Entity<Vendor>().HasKey(x => x.VendorId);
            modelBuilder.Entity<PurchaseOrder>().HasKey(x => x.POId);
            modelBuilder.Entity<PurchaseOrderItem>().HasKey(x => x.POItemId);
            modelBuilder.Entity<Quotation>().HasKey(x => x.QuotationId);
            modelBuilder.Entity<QuotationItem>().HasKey(x => x.QuotationItemId);
            modelBuilder.Entity<SalesOrder>().HasKey(x => x.SaleOrderId);
            modelBuilder.Entity<Invoice>().HasKey(x => x.InvoiceId);
            modelBuilder.Entity<InvoiceItem>().HasKey(x => x.InvoiceItemId);
            modelBuilder.Entity<Customer>().HasKey(x => x.CustomerId);
            modelBuilder.Entity<Lead>().HasKey(x => x.LeadId);
            modelBuilder.Entity<FollowUp>().HasKey(x => x.FollowUpId);
            modelBuilder.Entity<RolePermission>().HasKey(x => x.RolePermissionId);
            modelBuilder.Entity<MenuPermission>().HasKey(x => x.MenuPermissionId);
            modelBuilder.Entity<Permission>().HasKey(x => x.PermissionId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<Role>().HasKey(x => x.RoleId);
            modelBuilder.Entity<TenantSetting>().HasKey(x => x.TenantId);
        }
    }
}
