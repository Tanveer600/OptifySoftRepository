using Microsoft.EntityFrameworkCore;
using Domain.OptifySoft.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptifySoft.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        // ===== Core =====
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<Permission> Permissions { get; }
        DbSet<MenuPermission> MenuPermissions { get; }
        DbSet<Menu> Menus { get; }
        DbSet<RolePermission> RolePermissions { get; }

        // ===== CRM =====
        DbSet<Customer> Customers { get; }
        DbSet<Lead> Leads { get; }
        DbSet<FollowUp> FollowUps { get; }

        // ===== Sales =====
        DbSet<Quotation> Quotations { get; }
        DbSet<QuotationItem> QuotationItems { get; }
        DbSet<SalesOrder> SalesOrders { get; }
        DbSet<Invoice> Invoices { get; }
        DbSet<InvoiceItem> InvoiceItems { get; }

        // ===== Purchase & Vendors =====
        DbSet<Vendor> Vendors { get; }
        DbSet<PurchaseOrder> PurchaseOrders { get; }
        DbSet<PurchaseOrderItem> PurchaseOrderItems { get; }
        //DbSet<GoodsReceived> GoodsReceived { get; }

        // ===== Inventory / Stock =====
        DbSet<Product> Products { get; }
        DbSet<Warehouse> Warehouses { get; }
        DbSet<StockTransaction> StockTransactions { get; }

        // ===== Accounts & Finance =====
        DbSet<Account> Accounts { get; }
        DbSet<Payment> Payments { get; }
       // DbSet<Expense> Expenses { get; }

        // ===== HR & Staff =====
        DbSet<Employee> Employees { get; }
        DbSet<Attendance> Attendances { get; }
       // DbSet<Leave> Leaves { get; }

        // ===== Project / Service =====
        //DbSet<Job> Jobs { get; }
        //DbSet<JobAssignment> JobAssignments { get; }
        //DbSet<ServiceReport> ServiceReports { get; }

        // ===== Tenant & Audit =====
        DbSet<TenantSetting> TenantSettings { get; }
        DbSet<AuditLog> AuditLogs { get; }
        DbSet<Branch> Branches { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
