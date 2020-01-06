CREATE TABLE uom(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'prd_uom',
	descr varchar(64) NOT NULL,
	date_created datetime default GETDATE(),
	active bit default 1
)
CREATE TABLE product_category(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'prd_categ',
	descr varchar(64) NOT NULL,
	date_created datetime default GETDATE(),
	active bit default 1
);
CREATE TABLE product_template(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'prd_tmp',
	product_category_id int NOT NULL,
	uom_id int,
	date_created datetime default GETDATE(),
	active bit default 1,

	FOREIGN KEY (product_category_id) REFERENCES product_category(id),
	FOREIGN KEY (uom_id) REFERENCES uom(id)
)
CREATE TABLE product_product(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'prd_prd',
	prd_template_id int NOT NULL,
	date_created datetime default GETDATE(),
	active bit default 1,

	FOREIGN KEY (prd_template_id) REFERENCES product_template(id)
)
