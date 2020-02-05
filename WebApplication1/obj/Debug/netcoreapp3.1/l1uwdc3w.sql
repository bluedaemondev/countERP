IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Currency] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Active] bit NOT NULL,
    [Code] nvarchar(max) NULL,
    [Create_uid] int NOT NULL,
    [Write_uid] int NOT NULL,
    [Write_date] datetime2 NOT NULL,
    [Create_date] datetime2 NOT NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [hr_contract] (
    [id] int NOT NULL IDENTITY,
    [code] varchar(64) NOT NULL DEFAULT (('contract_code')),
    [sueldo_total] money NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_hr_contract] PRIMARY KEY ([id])
);

GO

CREATE TABLE [payment] (
    [id] int NOT NULL IDENTITY,
    [payment_descr] varchar(256) NOT NULL DEFAULT (('payment')),
    [amount] money NOT NULL,
    [amount_discount] money NULL,
    [is_check] bit NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_payment] PRIMARY KEY ([id])
);

GO

CREATE TABLE [product_category] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('prd_categ')),
    [descr] varchar(64) NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    [active] bit NULL DEFAULT (((1))),
    CONSTRAINT [PK_product_category] PRIMARY KEY ([id])
);

GO

CREATE TABLE [res_company] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('res_company')),
    [vat] varchar(40) NULL,
    [street] varchar(50) NULL,
    [street2] varchar(50) NULL,
    [phone] varchar(30) NULL,
    [phone2] varchar(30) NULL,
    [c_state] varchar(30) NOT NULL,
    [c_country] varchar(30) NOT NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_res_company] PRIMARY KEY ([id])
);

GO

CREATE TABLE [res_group] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(50) NULL,
    [res_group_parent_id] int NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_res_group] PRIMARY KEY ([id]),
    CONSTRAINT [FK__res_group__res_g__46E78A0C] FOREIGN KEY ([res_group_parent_id]) REFERENCES [res_group] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [res_group_rule] (
    [id] int NOT NULL IDENTITY,
    [code] varchar(64) NULL,
    [arch] varchar(256) NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_res_group_rule] PRIMARY KEY ([id])
);

GO

CREATE TABLE [res_partner] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('res_partner')),
    [vat] varchar(40) NULL,
    [street] varchar(50) NULL,
    [is_customer] bit NULL,
    [is_provider] bit NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_res_partner] PRIMARY KEY ([id])
);

GO

CREATE TABLE [tax] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(60) NOT NULL DEFAULT (('tax')),
    [display_descr] varchar(4) NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_tax] PRIMARY KEY ([id])
);

GO

CREATE TABLE [uom] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('prd_uom')),
    [descr] varchar(64) NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    [active] bit NULL DEFAULT (((1))),
    CONSTRAINT [PK_uom] PRIMARY KEY ([id])
);

GO

CREATE TABLE [CurrencyRate] (
    [Id] int NOT NULL IDENTITY,
    [CurrencyId] int NULL,
    [Date] nvarchar(max) NULL,
    [Ratio] decimal(18,2) NOT NULL,
    [Create_uid] int NOT NULL,
    [Write_uid] int NOT NULL,
    [Write_date] datetime2 NOT NULL,
    [Create_date] datetime2 NOT NULL,
    CONSTRAINT [PK_CurrencyRate] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CurrencyRate_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currency] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [sale_order] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('SO')),
    [state] varchar(30) NULL,
    [payment_id] int NOT NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_sale_order] PRIMARY KEY ([id]),
    CONSTRAINT [FK__sale_orde__payme__5AEE82B9] FOREIGN KEY ([payment_id]) REFERENCES [payment] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [res_group_rule_rel] (
    [id] int NOT NULL IDENTITY,
    [res_group_id] int NOT NULL,
    [res_rule_id] int NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_res_group_rule_rel] PRIMARY KEY ([id]),
    CONSTRAINT [FK__res_group__res_g__4AB81AF0] FOREIGN KEY ([res_group_id]) REFERENCES [res_group] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__res_group__res_r__4BAC3F29] FOREIGN KEY ([res_rule_id]) REFERENCES [res_group_rule] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [hr_employee] (
    [id] int NOT NULL IDENTITY,
    [partner_id] int NOT NULL,
    [contract_id] int NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_hr_employee] PRIMARY KEY ([id]),
    CONSTRAINT [FK__hr_employ__contr__37A5467C] FOREIGN KEY ([contract_id]) REFERENCES [hr_contract] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__hr_employ__partn__36B12243] FOREIGN KEY ([partner_id]) REFERENCES [res_partner] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [sale_order_line] (
    [id] int NOT NULL IDENTITY,
    [order_id] int NOT NULL,
    [name] varchar(256) NOT NULL DEFAULT (('SO_line')),
    [product_id] int NULL,
    [amount_untaxed] money NULL,
    [amount_tax] money NULL,
    [amount_total] money NULL,
    [tax_id] int NULL,
    [active] bit NULL DEFAULT (((1))),
    [invoiced] bit NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_sale_order_line] PRIMARY KEY ([id]),
    CONSTRAINT [FK__sale_orde__tax_i__6B24EA82] FOREIGN KEY ([tax_id]) REFERENCES [tax] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [product_template] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('prd_tmp')),
    [product_category_id] int NOT NULL,
    [uom_id] int NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    [active] bit NULL DEFAULT (((1))),
    CONSTRAINT [PK_product_template] PRIMARY KEY ([id]),
    CONSTRAINT [FK__product_t__produ__1CF15040] FOREIGN KEY ([product_category_id]) REFERENCES [product_category] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__product_t__uom_i__1DE57479] FOREIGN KEY ([uom_id]) REFERENCES [uom] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [account_invoice] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('SO')),
    [state] varchar(30) NULL,
    [order_id] int NOT NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_account_invoice] PRIMARY KEY ([id]),
    CONSTRAINT [FK__account_i__order__60A75C0F] FOREIGN KEY ([order_id]) REFERENCES [sale_order] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [hr_contract_employee_rel] (
    [id] int NOT NULL IDENTITY,
    [contract_id] int NOT NULL,
    [employee_id] int NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_hr_contract_employee_rel] PRIMARY KEY ([id]),
    CONSTRAINT [FK__hr_contra__contr__4F7CD00D] FOREIGN KEY ([contract_id]) REFERENCES [hr_contract] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__hr_contra__emplo__5070F446] FOREIGN KEY ([employee_id]) REFERENCES [hr_employee] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [res_user] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('res_user')),
    [employee_id] int NULL,
    [is_admin] bit NULL DEFAULT (((0))),
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_res_user] PRIMARY KEY ([id]),
    CONSTRAINT [FK__res_user__employ__3E52440B] FOREIGN KEY ([employee_id]) REFERENCES [hr_employee] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [product_product] (
    [id] int NOT NULL IDENTITY,
    [name] varchar(256) NOT NULL DEFAULT (('prd_prd')),
    [prd_template_id] int NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    [active] bit NULL DEFAULT (((1))),
    [currencyId] int NULL,
    [Create_uid] int NOT NULL,
    [Write_uid] int NOT NULL,
    [Write_date] datetime2 NOT NULL,
    CONSTRAINT [PK_product_product] PRIMARY KEY ([id]),
    CONSTRAINT [FK__product_p__prd_t__239E4DCF] FOREIGN KEY ([prd_template_id]) REFERENCES [product_template] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_product_product_Currency_currencyId] FOREIGN KEY ([currencyId]) REFERENCES [Currency] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [account_invoice_line] (
    [id] int NOT NULL IDENTITY,
    [invoice_id] int NOT NULL,
    [so_line_id] int NOT NULL,
    [name] varchar(256) NOT NULL DEFAULT (('INV_line')),
    [product_id] int NULL,
    [amount_untaxed] money NULL,
    [amount_tax] money NULL,
    [amount_total] money NULL,
    [tax_id] int NULL,
    [active] bit NULL DEFAULT (((1))),
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_account_invoice_line] PRIMARY KEY ([id]),
    CONSTRAINT [FK__account_i__invoi__70DDC3D8] FOREIGN KEY ([invoice_id]) REFERENCES [account_invoice] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__account_i__so_li__71D1E811] FOREIGN KEY ([so_line_id]) REFERENCES [account_invoice_line] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__account_i__tax_i__72C60C4A] FOREIGN KEY ([tax_id]) REFERENCES [tax] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [so_line_invoice_rel] (
    [id] int NOT NULL IDENTITY,
    [so_id] int NOT NULL,
    [inv_id] int NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_so_line_invoice_rel] PRIMARY KEY ([id]),
    CONSTRAINT [FK__so_line_i__inv_i__778AC167] FOREIGN KEY ([inv_id]) REFERENCES [account_invoice] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__so_line_i__so_id__76969D2E] FOREIGN KEY ([so_id]) REFERENCES [sale_order] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [so_line_inv_line_rel] (
    [id] int NOT NULL IDENTITY,
    [so_line_id] int NOT NULL,
    [inv_line_id] int NOT NULL,
    [date_created] datetime NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_so_line_inv_line_rel] PRIMARY KEY ([id]),
    CONSTRAINT [FK__so_line_i__inv_l__7C4F7684] FOREIGN KEY ([inv_line_id]) REFERENCES [account_invoice_line] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__so_line_i__so_li__7B5B524B] FOREIGN KEY ([so_line_id]) REFERENCES [sale_order_line] ([id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_account_invoice_order_id] ON [account_invoice] ([order_id]);

GO

CREATE INDEX [IX_account_invoice_line_invoice_id] ON [account_invoice_line] ([invoice_id]);

GO

CREATE INDEX [IX_account_invoice_line_so_line_id] ON [account_invoice_line] ([so_line_id]);

GO

CREATE INDEX [IX_account_invoice_line_tax_id] ON [account_invoice_line] ([tax_id]);

GO

CREATE INDEX [IX_CurrencyRate_CurrencyId] ON [CurrencyRate] ([CurrencyId]);

GO

CREATE INDEX [IX_hr_contract_employee_rel_contract_id] ON [hr_contract_employee_rel] ([contract_id]);

GO

CREATE INDEX [IX_hr_contract_employee_rel_employee_id] ON [hr_contract_employee_rel] ([employee_id]);

GO

CREATE INDEX [IX_hr_employee_contract_id] ON [hr_employee] ([contract_id]);

GO

CREATE INDEX [IX_hr_employee_partner_id] ON [hr_employee] ([partner_id]);

GO

CREATE INDEX [IX_product_product_prd_template_id] ON [product_product] ([prd_template_id]);

GO

CREATE INDEX [IX_product_product_currencyId] ON [product_product] ([currencyId]);

GO

CREATE INDEX [IX_product_template_product_category_id] ON [product_template] ([product_category_id]);

GO

CREATE INDEX [IX_product_template_uom_id] ON [product_template] ([uom_id]);

GO

CREATE INDEX [IX_res_group_res_group_parent_id] ON [res_group] ([res_group_parent_id]);

GO

CREATE INDEX [IX_res_group_rule_rel_res_group_id] ON [res_group_rule_rel] ([res_group_id]);

GO

CREATE INDEX [IX_res_group_rule_rel_res_rule_id] ON [res_group_rule_rel] ([res_rule_id]);

GO

CREATE INDEX [IX_res_user_employee_id] ON [res_user] ([employee_id]);

GO

CREATE INDEX [IX_sale_order_payment_id] ON [sale_order] ([payment_id]);

GO

CREATE INDEX [IX_sale_order_line_tax_id] ON [sale_order_line] ([tax_id]);

GO

CREATE INDEX [IX_so_line_inv_line_rel_inv_line_id] ON [so_line_inv_line_rel] ([inv_line_id]);

GO

CREATE INDEX [IX_so_line_inv_line_rel_so_line_id] ON [so_line_inv_line_rel] ([so_line_id]);

GO

CREATE INDEX [IX_so_line_invoice_rel_inv_id] ON [so_line_invoice_rel] ([inv_id]);

GO

CREATE INDEX [IX_so_line_invoice_rel_so_id] ON [so_line_invoice_rel] ([so_id]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200125044632_init', N'3.1.0');

GO

