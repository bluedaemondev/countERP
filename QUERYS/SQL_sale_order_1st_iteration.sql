CREATE TABLE payment(
	id INT PRIMARY KEY IDENTITY(1,1),
	payment_descr varchar(256) NOT NULL default 'payment',
	amount money NOT NULL,
	amount_discount money,
	is_check bit,
	active bit default 1,
	date_created datetime default GETDATE()
)
CREATE TABLE sale_order(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'SO',
	state varchar(30),
	payment_id int NOT NULL,
	active bit default 1,
	date_created datetime default GETDATE(),

	FOREIGN KEY (payment_id) REFERENCES payment(id)
)
CREATE TABLE account_invoice(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'SO',
	state varchar(30),
	order_id int NOT NULL,
	active bit default 1,
	date_created datetime default GETDATE(),

	FOREIGN KEY (order_id) REFERENCES sale_order(id)
)
CREATE TABLE tax(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(60) NOT NULL default 'tax',
	display_descr varchar(4),
	active bit default 1,
	date_created datetime default GETDATE()
)
CREATE TABLE sale_order_line(
	id INT PRIMARY KEY IDENTITY(1,1),
	order_id int not null,
	name varchar(256) NOT NULL default 'SO_line',
	product_id int,
	amount_untaxed money,
	amount_tax money,
	amount_total money,
	tax_id int,
	active bit default 1,
	invoiced bit,
	
	date_created datetime default GETDATE(),
	FOREIGN KEY (tax_id) REFERENCES tax(id)
)
CREATE TABLE account_invoice_line(
	id INT PRIMARY KEY IDENTITY(1,1),
	invoice_id int not null,
	so_line_id int not null,
	name varchar(256) NOT NULL default 'INV_line',
	product_id int,
	amount_untaxed money,
	amount_tax money,
	amount_total money,
	tax_id int,
	active bit default 1,
	date_created datetime default GETDATE(),
	FOREIGN KEY (invoice_id) REFERENCES account_invoice(id),
	FOREIGN KEY (so_line_id) REFERENCES account_invoice_line(id),
	FOREIGN KEY (tax_id) REFERENCES tax(id)
)
CREATE TABLE so_line_invoice_rel(
	id INT PRIMARY KEY IDENTITY(1,1),
	so_id int NOT NULL,
	inv_id int NOT NULL,
	date_created datetime default GETDATE(),
	FOREIGN KEY (so_id) REFERENCES sale_order(id),
	FOREIGN KEY (inv_id) REFERENCES account_invoice(id)
)
CREATE TABLE so_line_inv_line_rel(
	id INT PRIMARY KEY IDENTITY(1,1),
	so_line_id int NOT NULL,
	inv_line_id int NOT NULL,
	date_created datetime default GETDATE(),
	FOREIGN KEY (so_line_id) REFERENCES sale_order_line(id),
	FOREIGN KEY (inv_line_id) REFERENCES account_invoice_line(id)
)