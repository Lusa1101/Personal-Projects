create database BusinessManager;


/*
Start from here
*/
create table Product_Subcategory(
Subcategory_id varchar(4) unique not null,
Category_id varchar(3) not null,
Name varchar(30),
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Subcategory_id),
Foreign Key(category_id) references Product_Category
);

create table Product_Category(
Category_id varchar(3) unique not null,
Name varchar(30) not null,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Category_id)
);

create table product(
Product_id varchar(6) unique not null,
Name varchar(30) not null,
Description varchar(100),
Subcategory_id varchar(4) not null,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Product_id),
Foreign Key (Subcategory_id) references Product_Subcategory
);

create table Product_Image(
Product_id varchar(6) unique not null,
Image Image not null,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Product_Id),
Foreign Key(Product_id) references Product
);

create table Stock(
Stock_id int unique not null,
Product_id varchar(6) not null,
Cost_per_unit smallmoney,
Total_units smallint,
Unit_price smallmoney,
IsAvailable bit,
NeedsPackaging bit,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Stock_id),
Foreign Key(Product_id) references Product
);
exec sp_rename 'Stock.NeedsPackaging', 'Needs_Packaging', 'COLUMN';
exec sp_rename 'Stock.IsAvailable', 'Is_available', 'COLUMN';

create table Stock_Receipt(
Stock_id int unique not null,
Image image,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Stock_id),
Foreign Key(Stock_id) references Stock
);

create table Invoice(
Invoice_id int unique not null,
Customer_id int,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Invoice_id)
);

create table Invoice_line(
Line_id int unique not null,
Invoice_id int not null,
Stock_id int not null,
Quantity int,
Discount smallmoney,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Line_id),
Foreign Key(Invoice_id) references Invoice,
Foreign Key(Stock_id) references Stock
);

create table Expense(
Expense_id int unique not null,
Type varchar(30),
Name varchar(30) not null,
Amount smallmoney,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Expense_id)
);

create table Package(
Package_id char(4) unique not null,
Name varchar(30) not null,
Size varchar(15) not null,
Cost smallmoney,
Quantity int,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Package_id)
);

create table Packaging(
Packaging_id char(6) unique not null,
Package_id char(4) not null,
Stock_id int not null,
Quantity int,
Unit_price smallmoney,
DateCreated Date Default Convert(Date, GetDate()),
Primary Key(Packaging_id),
Foreign Key(Package_id) references Package
);

create table Essential(
essential_id int not null,
Name varchar(30) not null,
);



/*
Testing
*/

Select * from product_category;
Select category_id, name from Product_Category Order By category_id;

select * from product_subcategory;