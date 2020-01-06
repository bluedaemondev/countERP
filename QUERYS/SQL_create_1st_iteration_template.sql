CREATE TABLE res_company(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'res_company',
	vat varchar(40) NULL,
	street varchar(50),
	street2 varchar(50),
	phone varchar(30),
	phone2 varchar(30),
	c_state varchar(30) not null,
	c_country varchar(30) not null,
	active bit default 1,
	date_created datetime default GETDATE(),
)

CREATE TABLE res_partner(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'res_partner',
	vat varchar(40) NULL,
	street varchar(50),
	is_customer bit,
	is_provider bit,
	active bit default 1,
	date_created datetime default GETDATE(),
)

CREATE TABLE hr_contract(
	id INT PRIMARY KEY IDENTITY(1,1),
	code varchar(64) NOT NULL default 'contract_code',
	sueldo_total money,
	active bit default 1,
	date_created datetime default GETDATE(),
)

CREATE TABLE hr_employee(
	id INT PRIMARY KEY IDENTITY(1,1),
	--name varchar(256) NOT NULL default 'res_partner',
	partner_id int not null,
	contract_id int,
	active bit default 1,
	date_created datetime default GETDATE(),
	FOREIGN KEY (partner_id) REFERENCES res_partner(id),
	FOREIGN KEY (contract_id) REFERENCES hr_contract(id)
)

CREATE TABLE res_user(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(256) NOT NULL default 'res_user',
	employee_id int,
	is_admin bit default 0,
	active bit default 1,
	date_created datetime default GETDATE(),
	FOREIGN KEY (employee_id) REFERENCES hr_employee(id),
)

CREATE TABLE res_group_rule(
	id INT PRIMARY KEY IDENTITY(1,1),
	code varchar(64),
	arch varchar(256),
	active bit default 1,
	date_created datetime default GETDATE(),
)

CREATE TABLE res_group(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(50),
	res_group_parent_id int,
	active bit default 1,
	date_created datetime default GETDATE(),
	FOREIGN KEY (res_group_parent_id) REFERENCES res_group(id),
)

CREATE TABLE res_group_rule_rel(
	id INT PRIMARY KEY IDENTITY(1,1),
	res_group_id int NOT NULL,
	res_rule_id int NOT NULL,
	date_created datetime default GETDATE(),
	FOREIGN KEY (res_group_id) REFERENCES res_group(id),
	FOREIGN KEY (res_rule_id) REFERENCES res_group_rule(id)
)

CREATE TABLE hr_contract_employee_rel(
	id INT PRIMARY KEY IDENTITY(1,1),
	contract_id int NOT NULL,
	employee_id int NOT NULL,
	date_created datetime default GETDATE(),
	FOREIGN KEY (contract_id) REFERENCES hr_contract(id),
	FOREIGN KEY (employee_id) REFERENCES hr_employee(id)
)
