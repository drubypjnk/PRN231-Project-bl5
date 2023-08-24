using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BussinessObject.Models
{
    public partial class PRN231_BL5Context : DbContext
    {
        public PRN231_BL5Context()
        {
        }

        public PRN231_BL5Context(DbContextOptions<PRN231_BL5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderType> OrderTypes { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductVariant> ProductVariants { get; set; } = null!;
        public virtual DbSet<ProductVariantsSubPositionRelation> ProductVariantsSubPositionRelations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sku> Skus { get; set; } = null!;
        public virtual DbSet<SubPosition> SubPositions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=PRN231_BL5;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__Activity__096AA2E95C3844B5");

                entity.ToTable("Activity");

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("history_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity.user_id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category__positi__4222D4EF");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId)
                    .ValueGeneratedNever()
                    .HasColumnName("note_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notes.create_by");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notes.order_id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.OrderTypeId).HasColumnName("order_type_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order.order_type_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order.user_id");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_detail");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_detail.order_id");

                entity.HasOne(d => d.ProductVariant)
                    .WithMany()
                    .HasForeignKey(d => d.ProductVariantId)
                    .HasConstraintName("FK_Order_detail.product_variant_id");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("Order_Type");

                entity.Property(e => e.OrderTypeId).HasColumnName("order_type_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasIndex(e => e.Address, "Positions_UN")
                    .IsUnique();

                entity.Property(e => e.PositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("position_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AvailSeat).HasColumnName("avail_seat");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.Seat).HasColumnName("seat");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.Img)
                    .HasColumnType("text")
                    .HasColumnName("img");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product.category_id");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.ToTable("Product_variants");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("text")
                    .HasColumnName("create_by");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quality).HasColumnName("quality");

                entity.Property(e => e.SkuId).HasColumnName("sku_id");

                entity.Property(e => e.UnitInOrder).HasColumnName("unit_in_order");

                entity.Property(e => e.UnitInStock).HasColumnName("unit_in_stock");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_variants.product_id");

                entity.HasOne(d => d.Sku)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.SkuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_v__sku_i__49C3F6B7");
            });

            modelBuilder.Entity<ProductVariantsSubPositionRelation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_variants_sub_position_relation");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.SubPositionId).HasColumnName("sub_position_id");

                entity.HasOne(d => d.ProductVariant)
                    .WithMany()
                    .HasForeignKey(d => d.ProductVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_variants_sub_position_relation.product_variant_id");

                entity.HasOne(d => d.SubPosition)
                    .WithMany()
                    .HasForeignKey(d => d.SubPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_variants_sub_position_relation.sub_position_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolesUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RolesUsers_Users"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RolesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RolesUsers_Roles"),
                        j =>
                        {
                            j.HasKey("RolesId", "UserId");

                            j.ToTable("RolesUsers");

                            j.IndexerProperty<int>("RolesId").HasColumnName("RolesID");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        });
            });

            modelBuilder.Entity<Sku>(entity =>
            {
                entity.Property(e => e.SkuId).HasColumnName("sku_id");

                entity.Property(e => e.ApproveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approve_date");

                entity.Property(e => e.CreateBy)
                    .HasColumnType("text")
                    .HasColumnName("create_by");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<SubPosition>(entity =>
            {
                entity.ToTable("Sub_position");

                entity.Property(e => e.SubPositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("sub_position_id");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.AvailSeat).HasColumnName("avail_seat");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.Seat).HasColumnName("seat");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.SubPositions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sub_position.position_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Avatar)
                    .HasColumnType("text")
                    .HasColumnName("avatar");

                entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasColumnType("text")
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsPrivate).HasColumnName("is_private");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
