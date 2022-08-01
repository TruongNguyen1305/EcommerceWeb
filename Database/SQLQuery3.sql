create database EcommerceShop

CREATE TABLE Accounts
(
	AccountID	int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	Phone		varchar(12),
	Email		nvarchar(50),
	Password	nvarchar(50),
	Salt		nvarchar(6),
	Active		bit NOT NULL,
	FullName	nvarchar(150),
	RoleID		int,
	LastLogin	datetime,
	CreateDate	datetime,
	CONSTRAINT 	fk_roleid	FOREIGN KEY (RoleID) 
				REFERENCES Roles(RoleID) ON DELETE CASCADE
)

CREATE TABLE Categories
(
	CatID		int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	CatName		nvarchar(250),
	Description	nvarchar(MAX),
	Password	nvarchar(50),
	ParentID	int,
	Levels		int,
	Ordering	int,
	Published	bit NOT NULL,
	Thumb		nvarchar(250),
	Title		nvarchar(250),
	Alias		nvarchar(250),
	MetaDesc	nvarchar(250),
	MetaKey		nvarchar(250),
	Cover		nvarchar(255),
	SchemaMarkup	nvarchar(MAX),
)

CREATE TABLE Customers
(
	CustomerID	int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	FullName	nvarchar(255),
	Birthday	datetime,
	Avatar		nvarchar(255),
	Address		nvarchar(255),
	Email		nchar(150),
	Phone		varchar(12),
	LocationID	int,
	District	int,
	Ward		int,
	CreateDate	datetime,
	Password	nvarchar(50),
	Salt		nchar(8),
	LastLogin	datetime,
	Active		bit,
)

select * from Customers
delete from Customers where CustomerID = 17

alter table Customers add constraint fk_locationId_customer	FOREIGN KEY (LocationID) 
				REFERENCES Locations(LocationID) ON DELETE CASCADE

alter table Products add constraint fk_catId_products	FOREIGN KEY (CatID) 
				REFERENCES Categories(CatID) ON DELETE CASCADE

CREATE TABLE Locations
(
	LocationID	int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name		nvarchar(100),
	Type		nvarchar(20),
	Slug		nvarchar(100),
	NameWithType		nvarchar(255),
	PathWithType		nvarchar(255),
	ParentCode	int,
	Levels		int
)

CREATE TABLE Orders
(
	OrderID		int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	CustomerID	int,
	OrderDate	datetime,
	ShipDate	datetime,
	TransactStatusID	int,
	Deleted		bit,
	Paid		bit,
	PaymentDate	datetime,
	PaymentID	int,
	Note		nvarchar(MAX),
	CONSTRAINT 	fk_TransactStatusID_Oder	FOREIGN KEY (TransactStatusID) 
				REFERENCES TransactStatus(TransactStatusID) ON DELETE set null,
	CONSTRAINT 	fk_CustomerID_Order	FOREIGN KEY (CustomerID)
				REFERENCES Customers(CustomerID) ON DELETE CASCADE

)

alter table Orders
alter column Paid bit not null;

CREATE TABLE OrderDetails
(
	OrderDetailID	int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	OrderID			int,
	ProductID		int,
	OrderNumber		int,
	Quantity		int,
	Discount		int,
	Total			int,
	ShipDate		datetime,
	CONSTRAINT 	fk_OrderID_OrderDetail	FOREIGN KEY (OrderID) 
				REFERENCES Orders(OrderID) ON DELETE cascade
)

alter table OrderDetails add constraint fk_productId_orderdetail FOREIGN KEY (ProductID) 
				REFERENCES Products(ProductID) ON DELETE CASCADE

select* from OrderDetails
select* from Orders


CREATE TABLE Pages
(
	PageID	int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	PageName		nvarchar(250),
	Contents		nvarchar(MAX),
	Thumb			nvarchar(250),
	Published		bit NOT NULL,
	Title			nvarchar(250),
	MetaDesc		nvarchar(250),
	MetaKey			nvarchar(250),
	Alias			nvarchar(250),
	CreateAt		datetime,
	Ordering		int,
)

CREATE TABLE Products
(
	ProductID	int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	ProductName		nvarchar(255) NOT NULL,
	ShortDesc		nvarchar(255),
	Description		nvarchar(MAX),
	CatID			int,
	Price			int,
	Discount		int,
	Thumb			nvarchar(255),
	Video			nvarchar(255),
	DateCreated		datetime,
	DateModified	datetime,
	BestSellers		bit not null,
	HomeFlag		bit not null,
	Active			bit not null,
	Tags			nvarchar(MAX),
	Title			nvarchar(255),
	Alias			nvarchar(255),
	MetaDesc		nvarchar(255),
	MetaKey			nvarchar(255),
	UnitslnStock	int
)

CREATE TABLE TransactStatus
(
	TransactStatusID int primary key not null IDENTITY(1,1),
	Status			 nvarchar(50),
	Description		 nvarchar(MAX)
)

CREATE TABLE Roles
(
	RoleID		int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	RoleName	nvarchar(50),
	Description nvarchar(50)
)

CREATE TABLE Shippers
(
	ShipperID	int Primary key not null identity(1,1),
	ShipperName	nvarchar(150),
	Phone		nchar(10),
	Company		nvarchar(150),
	ShipDate	datetime
)

insert into Roles(RoleName, Description) values('Admin', 'Admin')
insert into Roles(RoleName, Description) values('Staff', 'Nhân viên')
select * from Roles


insert into Categories (CatName, Published) values ('Mobile Phone', 1)
insert into Categories (CatName, Published) values ('Laptop', 1)
insert into Categories (CatName, Published) values ('Ipad', 1)
select * from Categories

CREATE TABLE Categories
(
	CatID		int		PRIMARY KEY NOT NULL IDENTITY(1,1),
	CatName		nvarchar(250),
	Description	nvarchar(MAX),
	Password	nvarchar(50),
	ParentID	int,
	Levels		int,
	Ordering	int,
	Published	bit NOT NULL,
	Thumb		nvarchar(250),
	Title		nvarchar(250),
	Alias		nvarchar(250),
	MetaDesc	nvarchar(250),
	MetaKey		nvarchar(250),
	Cover		nvarchar(255),
	SchemaMarkup	nvarchar(MAX),
)

insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone 7 plus', 1, 6000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone 8 plus', 1, 8000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Iphone X', 1, 10000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('ASUS TUF', 2, 20000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('ACER NITRO 5', 2, 21000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Macbook pro', 2, 30000000, 10,1,1,1)
insert into Products (ProductName, CatID, Price, UnitslnStock, BestSellers, HomeFlag, Active) values ('Dell Alienware', 2, 30000000, 10,1,1,1)
select * from Products
update Products set Thumb = 'macbook-pro.jpg' where ProductName = 'ASUS TUF'

insert into TransactStatus (Status, Description) values (N'Chờ lấy hàng',N'Đã xác nhận và đang soạn hàng')
insert into TransactStatus (Status, Description) values (N'Chờ xác nhận',N'Đang xác nhận với người mua')
insert into TransactStatus (Status, Description) values (N'Đang giao',N'Đơn hàng đang được giao tới người mua')
insert into TransactStatus (Status, Description) values (N'Đã giao thành công',N'Đơn hàng đã được giao tới người mua')
insert into TransactStatus (Status, Description) values (N'Đã hủy',N'Đơn hàng đã được hủy thành công')
insert into TransactStatus (Status, Description) values (N'Trả hàng',N'Đơn hàng đã được trả thành công')



select * from TransactStatus
select * from Orders
select * from OrderDetails
delete from TransactStatus
delete from OrderDetails
delete from Orders
SET IDENTITY_INSERT TransactStatus ON
