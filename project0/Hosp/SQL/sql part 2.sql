create table Pat(
Patient_id int  Primary key identity NOT NULL,
P_name varchar(32) not null,
P_last_name	varchar(32) not null,
Date_enter date,
Date_leave date,
ailement varchar(255)

)


create table User_table(

users_id int primary key identity NOT NULL,
user_N	varchar(32) NOT NULL,
user_pass varchar(32)	NOT NULL,
is_admin bit
)


drop table User_table;
insert into  User_table values( 'Jorge','Jorge90',1);
select * from User_table;
select is_admin from User_table where user_n = 'Jorge' and user_pass = 'Jorge90';

select * from User_table;
select * from Pat;
SELECT * FROM Pat WHERE ailement like  '%cold';
column