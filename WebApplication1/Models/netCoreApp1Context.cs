using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace WebApplication1.Models
{
    public partial class netCoreApp1Context : DbContext
    {
        public netCoreApp1Context()
        {
        }

        public netCoreApp1Context(DbContextOptions<netCoreApp1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountInvoice> AccountInvoice { get; set; }
        public virtual DbSet<AccountInvoiceLine> AccountInvoiceLine { get; set; }
        public virtual DbSet<HrContract> HrContract { get; set; }
        public virtual DbSet<HrContractEmployeeRel> HrContractEmployeeRel { get; set; }
        public virtual DbSet<HrEmployee> HrEmployee { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductProduct> ProductProduct { get; set; }
        public virtual DbSet<ProductTemplate> ProductTemplate { get; set; }
        public virtual DbSet<ResCompany> ResCompany { get; set; }
        public virtual DbSet<ResGroup> ResGroup { get; set; }
        public virtual DbSet<ResGroupRule> ResGroupRule { get; set; }
        public virtual DbSet<ResGroupRuleRel> ResGroupRuleRel { get; set; }
        public virtual DbSet<ResPartner> ResPartner { get; set; }
        public virtual DbSet<ResUser> ResUser { get; set; }
        public virtual DbSet<SaleOrder> SaleOrder { get; set; }
        public virtual DbSet<SaleOrderLine> SaleOrderLine { get; set; }
        public virtual DbSet<SoLineInvLineRel> SoLineInvLineRel { get; set; }
        public virtual DbSet<SoLineInvoiceRel> SoLineInvoiceRel { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<Uom> Uom { get; set; }
        
        // 1 - Cargar nuevos modelos como DbSet.
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurencyRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SL1CSDN\\SQLEXPRESS;Database=netCoreApp1;User=sa;Password=admin");
            }
        }
        // 2 - Crear las entidades de los nuevos Modelos.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* ///EJEMPLO///
             * 
            modelBuilder.Entity<Currency>(entity =>
            {
              
                entity.ToTable("res_currency");
               
                entity.HasKey(c => c.Id);
                
                entity.Property(c => c.Id).HasColumnName("id");
                
                entity.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                });
             */


            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("res_currency");
                
                entity.HasKey(c => c.Id);
                
                entity.Property(c => c.Id).HasColumnName("id");

                entity.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(c => c.Active)
                .HasColumnName("active")
                .IsRequired()
                .HasDefaultValueSql("((1))");

                entity.Property(c => c.Code)
                .HasColumnName("code")
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false);

                entity.Property(c => c.Create_uid)
                .HasColumnName("create_uid")
                .IsRequired();
                entity.Property(c => c.Write_uid)
                .HasColumnName("write_uid")
                .IsRequired();
                entity.Property(c => c.Create_date)
                .HasColumnName("create_date")
                .IsRequired();
                entity.Property(c => c.Write_date)
                .HasColumnName("write_date")
                .IsRequired();

                entity.HasIndex(e => e.Name)
                .IsUnique();
            });
            modelBuilder.Entity<CurrencyRate>(entity =>
            {
                entity.ToTable("res_currency_rate");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id).HasColumnName("id");

                entity.Property(c => c.Date)
                .HasColumnName("name")
                .IsRequired()
                .HasDefaultValueSql("(getdate())")
                .IsUnicode(false);

                entity.Property(c => c.Ratio)
                .HasColumnName("ratio")
                .IsRequired()
                .IsUnicode(false);

                entity.Property(c => c.Active)
                .HasColumnName("active")
                .IsRequired()
                //set to true
                .HasDefaultValueSql("((1))");

                entity.Property(c => c.Create_uid)
                .HasColumnName("create_uid")
                .IsRequired();
                entity.Property(c => c.Write_uid)
                .HasColumnName("write_uid")
                .IsRequired();
                entity.Property(c => c.Create_date)
                .HasColumnName("create_date")
                .IsRequired();
                entity.Property(c => c.Write_date)
                .HasColumnName("write_date")
                .IsRequired();

                entity.HasIndex(e => e.Date)
                .IsUnique();

                entity.HasOne(cr => cr.Currency)
                    .WithMany(c => c.Ratios)
                    .HasForeignKey(cr => cr.Currency_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__res_currency_i__currency_rate__60A75C0F");
            });

            modelBuilder.Entity<AccountInvoice>(entity =>
            {
                entity.ToTable("account_invoice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SO')");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.AccountInvoice)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__account_i__order__60A75C0F");
            });

            modelBuilder.Entity<AccountInvoiceLine>(entity =>
            {
                entity.ToTable("account_invoice_line");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AmountTax)
                    .HasColumnName("amount_tax")
                    .HasColumnType("money");

                entity.Property(e => e.AmountTotal)
                    .HasColumnName("amount_total")
                    .HasColumnType("money");

                entity.Property(e => e.AmountUntaxed)
                    .HasColumnName("amount_untaxed")
                    .HasColumnType("money");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('INV_line')");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SoLineId).HasColumnName("so_line_id");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.AccountInvoiceLine)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__account_i__invoi__70DDC3D8");

                entity.HasOne(d => d.SoLine)
                    .WithMany(p => p.InverseSoLine)
                    .HasForeignKey(d => d.SoLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__account_i__so_li__71D1E811");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.AccountInvoiceLine)
                    .HasForeignKey(d => d.TaxId)
                    .HasConstraintName("FK__account_i__tax_i__72C60C4A");
            });

            modelBuilder.Entity<HrContract>(entity =>
            {
                entity.ToTable("hr_contract");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('contract_code')");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SueldoTotal)
                    .HasColumnName("sueldo_total")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<HrContractEmployeeRel>(entity =>
            {
                entity.ToTable("hr_contract_employee_rel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.HrContractEmployeeRel)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__hr_contra__contr__4F7CD00D");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HrContractEmployeeRel)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__hr_contra__emplo__5070F446");
            });

            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.ToTable("hr_employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartnerId).HasColumnName("partner_id");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.HrEmployee)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__hr_employ__contr__37A5467C");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.HrEmployee)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__hr_employ__partn__36B12243");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.AmountDiscount)
                    .HasColumnName("amount_discount")
                    .HasColumnType("money");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsCheck).HasColumnName("is_check");

                entity.Property(e => e.PaymentDescr)
                    .IsRequired()
                    .HasColumnName("payment_descr")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('payment')");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnName("descr")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('prd_categ')");
            });

            modelBuilder.Entity<ProductProduct>(entity =>
            {
                entity.ToTable("product_product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('prd_prd')");

                entity.Property(e => e.PrdTemplateId).HasColumnName("prd_template_id");

                entity.HasOne(d => d.PrdTemplate)
                    .WithMany(p => p.ProductProduct)
                    .HasForeignKey(d => d.PrdTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_p__prd_t__239E4DCF");
            });

            modelBuilder.Entity<ProductTemplate>(entity =>
            {
                entity.ToTable("product_template");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('prd_tmp')");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.UomId).HasColumnName("uom_id");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductTemplate)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_t__produ__1CF15040");

                entity.HasOne(d => d.Uom)
                    .WithMany(p => p.ProductTemplate)
                    .HasForeignKey(d => d.UomId)
                    .HasConstraintName("FK__product_t__uom_i__1DE57479");
            });

            modelBuilder.Entity<ResCompany>(entity =>
            {
                entity.ToTable("res_company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CCountry)
                    .IsRequired()
                    .HasColumnName("c_country")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CState)
                    .IsRequired()
                    .HasColumnName("c_state")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('res_company')");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasColumnName("phone2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vat)
                    .HasColumnName("vat")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResGroup>(entity =>
            {
                entity.ToTable("res_group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResGroupParentId).HasColumnName("res_group_parent_id");

                entity.HasOne(d => d.ResGroupParent)
                    .WithMany(p => p.InverseResGroupParent)
                    .HasForeignKey(d => d.ResGroupParentId)
                    .HasConstraintName("FK__res_group__res_g__46E78A0C");
            });

            modelBuilder.Entity<ResGroupRule>(entity =>
            {
                entity.ToTable("res_group_rule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Arch)
                    .HasColumnName("arch")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ResGroupRuleRel>(entity =>
            {
                entity.ToTable("res_group_rule_rel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ResGroupId).HasColumnName("res_group_id");

                entity.Property(e => e.ResRuleId).HasColumnName("res_rule_id");

                entity.HasOne(d => d.ResGroup)
                    .WithMany(p => p.ResGroupRuleRel)
                    .HasForeignKey(d => d.ResGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__res_group__res_g__4AB81AF0");

                entity.HasOne(d => d.ResRule)
                    .WithMany(p => p.ResGroupRuleRel)
                    .HasForeignKey(d => d.ResRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__res_group__res_r__4BAC3F29");
            });

            modelBuilder.Entity<ResPartner>(entity =>
            {
                entity.ToTable("res_partner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsCustomer).HasColumnName("is_customer");

                entity.Property(e => e.IsProvider).HasColumnName("is_provider");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('res_partner')");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vat)
                    .HasColumnName("vat")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResUser>(entity =>
            {
                entity.ToTable("res_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("is_admin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('res_user')");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ResUser)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__res_user__employ__3E52440B");
            });

            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.ToTable("sale_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SO')");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.SaleOrder)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sale_orde__payme__5AEE82B9");
            });

            modelBuilder.Entity<SaleOrderLine>(entity =>
            {
                entity.ToTable("sale_order_line");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AmountTax)
                    .HasColumnName("amount_tax")
                    .HasColumnType("money");

                entity.Property(e => e.AmountTotal)
                    .HasColumnName("amount_total")
                    .HasColumnType("money");

                entity.Property(e => e.AmountUntaxed)
                    .HasColumnName("amount_untaxed")
                    .HasColumnType("money");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Invoiced).HasColumnName("invoiced");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SO_line')");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.SaleOrderLine)
                    .HasForeignKey(d => d.TaxId)
                    .HasConstraintName("FK__sale_orde__tax_i__6B24EA82");
            });

            modelBuilder.Entity<SoLineInvLineRel>(entity =>
            {
                entity.ToTable("so_line_inv_line_rel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvLineId).HasColumnName("inv_line_id");

                entity.Property(e => e.SoLineId).HasColumnName("so_line_id");

                entity.HasOne(d => d.InvLine)
                    .WithMany(p => p.SoLineInvLineRel)
                    .HasForeignKey(d => d.InvLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__so_line_i__inv_l__7C4F7684");

                entity.HasOne(d => d.SoLine)
                    .WithMany(p => p.SoLineInvLineRel)
                    .HasForeignKey(d => d.SoLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__so_line_i__so_li__7B5B524B");
            });

            modelBuilder.Entity<SoLineInvoiceRel>(entity =>
            {
                entity.ToTable("so_line_invoice_rel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.SoId).HasColumnName("so_id");

                entity.HasOne(d => d.Inv)
                    .WithMany(p => p.SoLineInvoiceRel)
                    .HasForeignKey(d => d.InvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__so_line_i__inv_i__778AC167");

                entity.HasOne(d => d.So)
                    .WithMany(p => p.SoLineInvoiceRel)
                    .HasForeignKey(d => d.SoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__so_line_i__so_id__76969D2E");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("tax");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayDescr)
                    .HasColumnName("display_descr")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('tax')");
            });

            modelBuilder.Entity<Uom>(entity =>
            {
                entity.ToTable("uom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnName("descr")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('prd_uom')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
