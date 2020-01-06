
CREATE TABLE res_company(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'res_company',
	vat varchar(40) NULL,
	street varchar(50),
	street2 varchar(50),
	phone varchar(30),
	phone2 varchar(30),
	state_id int not null,
	country_id int not null,
	date_created datetime default GETDATE(),
	active bit default 1,

	FOREIGN KEY (state_id) REFERENCES res_state(id),
	FOREIGN KEY (country_id) REFERENCES res_country(id)
)
CREATE TABLE res_partner(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'res_partner',
	vat varchar(40) NULL,
	street varchar(50),
	is_customer bit,
	date_created datetime default GETDATE(),
	active bit default 1,

	FOREIGN KEY (product_category_id) REFERENCES product_category(id),
	FOREIGN KEY (uom_id) REFERENCES uom(id)
)