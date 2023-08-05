using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.DBContext;

public partial class DbecommerceContext : DbContext
{
    public DbecommerceContext()
    {
    }

    public DbecommerceContext(DbContextOptions<DbecommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07AD9905A6");

            entity.ToTable("Category");

            entity.Property(e => e.DateBegin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Product__09889210F7671344");

            entity.ToTable("Product");

            entity.Property(e => e.DateBegin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OfertPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Product__IdCateg__4CA06362");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC0711745AB5");

            entity.ToTable("Sale");

            entity.Property(e => e.DateBegin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK__Sale__IdSale__534D60F1");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SaleDeta__3214EC0792B918BA");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__SaleDetai__IdPro__5812160E");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK__SaleDetai__IdSal__571DF1D5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC072F853A0B");

            entity.Property(e => e.DateBegind)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LasName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
