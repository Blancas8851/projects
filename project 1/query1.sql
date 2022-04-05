create table userstable (
usesrid int not null identity primary key,
username varchar(40),
password varchar(40),
f_name varchar(40)

)
create table customerTable(
cust_ID int not null primary key identity(100 , 1),
f_name varchar(50) not null,
L_name varchar(50) not null,
address varchar(70) not null,
state varchar (30) not null,
city varchar (50) not null,
country varchar (30) not null
)

 

 --ALTER TABLE customerTable
--ADD city varchar (50) not null;
create table productTable(
product_Id int not null primary key identity(1, 1),
P_name varchar(50) not null,
product_desc text,
P_qty int,
P_cost float(30)

)
create table orders(
order_id int primary key not null identity(100,1),
cust_id int foreign key references customerTable(cust_ID),
product_id int foreign key references productTable(product_Id),
order_date date
)


insert into productTable values(
'steack taco', 'Tacos made with a hand made corn tortilla and seasoned grilled steak',123,5.50)
select * from productTable;