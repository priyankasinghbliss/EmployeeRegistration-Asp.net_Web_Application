create database DBEmployeeRegistration
use DBEmployeeRegistration

--create table Employee
--(
--ID int primary key identity
--,Employee_Code varchar(50)
--,First_Name varchar(50)
--,Last_Name varchar(50)
--,Gender int
--,DOB date
--,Mobile_No bigint
--,Email_ID varchar(50)
--,Address varchar(50)
--,City int
--,State int
--,Country int
--,Department int
--,Designation int
--,Salary decimal(10,2)
--,Created_On datetime
--,Modified_On datetime
--)

--sp_rename 'Employee.DOB','Age'
--alter table Employee alter column Age int
--alter table Employee add Age int
--alter table Employee drop Age

--truncate table Employee
--drop table Employee

create table Employee
(
ID int primary key identity
,Employee_Code varchar(50)
,First_Name varchar(50)
,Last_Name varchar(50)
,Gender int
,Age int
,Address varchar(50)
,City int
,State int
,Country int
,Department int
,Designation int
,Salary decimal(10,2)
,Mobile_No bigint
,Email_ID varchar(50)
,Password varchar(50)
,Created_On datetime
,Modified_On datetime
)

--alter table Employee add Password varchar(50)

select * from Employee
--drop table Employee

create table tblGender
(
GenderID int primary key identity
,GenderName varchar(20)
)

alter table tblGender add Status int default 0

insert into tblGender (GenderName) values ('Male'),('Female'),('Others')

select * from tblGender

create table tblCountry
(
CountryID int primary key identity
,CountryName varchar(50)
)

alter table tblCountry add Status int default 0

insert into tblCountry (CountryName) values ('India'),('Afghanistan'),('Bangladesh'),('Bhutan'),('China'),('Maldives'),('Myanmar'),('Nepal'),('Pakistan'),('Sri Lanka')

select * from tblCountry

create table tblState
(
StateID int primary key identity
,CountryID int
,StateName varchar(50)
)

alter table tblState add Status int default 0

insert into tblState (CountryID,StateName) values (1,'Uttar Pradesh'),(1,'Bihar'),(1,'Kerala')
insert into tblState (CountryID,StateName) values (2,'Kabul'),(2,'Kunar'),(2,'Herat')
insert into tblState (CountryID,StateName) values (3,'Dhaka'),(3,'Rangpur'),(3,'Khulna')
insert into tblState (CountryID,StateName) values (4,'Paro'),(4,'Thimphu'),(4,'Trongsa')
insert into tblState (CountryID,StateName) values (5,'Guizhou'),(5,'Qinghai'),(5,'Jiangxi')
insert into tblState (CountryID,StateName) values (6,'Rasdhoo'),(6,'Nilandhoo'),(6,'Villingili')
insert into tblState (CountryID,StateName) values (7,'Chin State'),(7,'Kachin State'),(7,'Mon State')
insert into tblState (CountryID,StateName) values (8,'Karnali Pradesh'),(8,'Bagmati Pradesh'),(8,'Lumbini Pradesh')
insert into tblState (CountryID,StateName) values (9,'Sindh'),(9,'Balochistan'),(9,'Gilgit-Baltistan')
insert into tblState (CountryID,StateName) values (10,'Uva'),(10,'Sabaragamuwa'),(10,'North Sri Lanka')

select * from tblState

create table tblCity
(
CityID int primary key identity
,StateID int
,CityName varchar(50)
)

alter table tblCity add Status int default 0

insert into tblCity (StateID, CityName) values (1,'Prayagraj'),(1,'Lucknow'),(1,'Noida')
insert into tblCity (StateID, CityName) values (2,'Patna'),(2,'Gaya'),(2,'Muzaffarpur')
insert into tblCity (StateID, CityName) values (3,'Kochi'),(3,'Thiruvananthapuram'),(3,'Kozhikode')
insert into tblCity (StateID, CityName) values (4,'Kabul_1'),(4,'Kabul_2'),(4,'Kabul_3')
insert into tblCity (StateID, CityName) values (5,'Kunar_1'),(5,'Kunar_2'),(5,'Kunar_3')
insert into tblCity (StateID, CityName) values (6,'Herat_1'),(6,'Herat_2'),(6,'Herat_3')
insert into tblCity (StateID, CityName) values (7,'Dhaka_1'),(7,'Dhaka_2'),(7,'Dhaka_3')
insert into tblCity (StateID, CityName) values (8,'Rangpur_1'),(8,'Rangpur_2'),(8,'Rangpur_3')
insert into tblCity (StateID, CityName) values (9,'Khulna_1'),(9,'Khulna_2'),(9,'Khulna_3')
insert into tblCity (StateID, CityName) values (10,'Paro_1'),(10,'Paro_2'),(10,'Paro_3')
insert into tblCity (StateID, CityName) values (11,'Thimphu_1'),(11,'Thimphu_2'),(11,'Thimphu_3')
insert into tblCity (StateID, CityName) values (12,'Trongsa_1'),(12,'Trongsa_2'),(12,'Trongsa_3')
insert into tblCity (StateID, CityName) values (13,'Anshun'),(13,'Guiyang'),(13,'Zunyi')
insert into tblCity (StateID, CityName) values (14,'Yushu'),(14,'Golmud'),(14,'Xining')
insert into tblCity (StateID, CityName) values (15,'Nanchang'),(15,'Jiujiang'),(15,'Ganzhou')
insert into tblCity values (16,''),(16,''),(16,'')
insert into tblCity values (17,''),(17,''),(17,'')
insert into tblCity values (18,''),(18,''),(18,'')
insert into tblCity values (19,''),(19,''),(19,'')
insert into tblCity values (20,''),(20,''),(20,'')
insert into tblCity values (21,''),(21,''),(21,'')
insert into tblCity values (22,''),(22,''),(22,'')
insert into tblCity values (23,''),(23,''),(23,'')
insert into tblCity values (24,''),(24,''),(24,'')
insert into tblCity values (25,''),(25,''),(25,'')
insert into tblCity values (26,''),(26,''),(26,'')
insert into tblCity values (27,''),(27,''),(27,'')
insert into tblCity values (28,''),(28,''),(28,'')
insert into tblCity values (29,''),(29,''),(29,'')
insert into tblCity values (30,''),(30,''),(30,'')

select * from tblCity

create table tblDepartment
(
DepartmentID int primary key identity
,DepartmentName varchar(50)
)

alter table tblDepartment add Status int default 0

insert into tblDepartment (DepartmentName) values ('General Management'),('Marketing'),('Operations'),('Finance'),('Sales'),('Human Resource'),('Purchase')

select * from tblDepartment

create table tblDesignation
(
DesignationID int primary key identity
,DepartmentID int
,DesignationName varchar(50)
)

alter table tblDesignation add Status int default 0

insert into tblDesignation (DepartmentID, DesignationName) values (1,'Chief General Manager (CGM)'),(1,'Deputy General Manager'),(1,'Faculty General Manager'),(1,'Assistant General Manager'),(1,'Associate General Manager')
insert into tblDesignation (DepartmentID, DesignationName) values (2,'Chief marketing officer (CMO)'),(2,'Creative director'),(2,'Marketing manager'),(2,'Product marketing manager'),(2,'Digital marketing manager'),(2,'Communications manager'),(2,'Content marketing specialist')
insert into tblDesignation (DepartmentID, DesignationName) values (3,'Chief Operating Officer (COO)'),(3,'Director of Operations'),(3,'Director of International Operations'),(3,'Account Operations Manager'),(3,'Operations Manager')
insert into tblDesignation (DepartmentID, DesignationName) values (4,'Chief Financial Officer (CFO)'),(4,'Director of Finance'),(4,'Financial Analyst'),(4,'Financial Advisor'),(4,'Payroll Manager'),(4,'Treasurer'),(4,'Finance Assistant'),(4,'Finance Intern'),(4,'Accounts Clerks')
insert into tblDesignation (DepartmentID, DesignationName) values (5,'National Sales Director'),(5,'National Sales Director'),(5,'Sales Manager'),(5,'Inside Sales Representative'),(5,'Outside Sales Representative'),(5,'Sales Assistant'),(5,'Sales Engineer'),(5,'Wholesale and Manufacturing Sales'),(5,'Retail Sales')
insert into tblDesignation (DepartmentID, DesignationName) values (6,'Director of human resources'),(6,'Human resources assistant'),(6,'Recruitment coordinator'),(6,'Recruiter'),(6,'Employee relations manager'),(6,'Human resources manager'),(6,'Labour relations specialist')
insert into tblDesignation (DepartmentID, DesignationName) values (7,'Purchasing Manager'),(7,'Purchase Assistant'),(7,'Procurement Specialist')

select * from tblDesignation

select * from Employee join tblGender on Gender=GenderID join tblCountry on Country=CountryID join tblState on State=StateID join tblCity on City=CityID join tblDepartment on Department=DepartmentID join tblDesignation on Designation=DesignationID

create table tblMarital_Status
(
MSID int primary key identity
,MSName varchar(50)
,Status int default 0
)

select * from tblMarital_Status

create table tblBlood_Group
(
BGID int primary key identity
,BGName varchar(50)
,Status int default 0
)

--insert into tblBlood_Group values ('A+')

select * from tblBlood_Group

--create procedure Employee_Insert
--@Employee_Code varchar(50)
--,@First_Name varchar(50)
--,@Last_Name varchar(50)
--,@Gender int
--,@Age int
--,@Mobile_No bigint
--,@Email_ID varchar(50)
--,@Address varchar(50)
--,@City int
--,@State int
--,@Country int
--,@Department int
--,@Designation int
--,@Salary decimal(10,2)
--,@Created_On datetime
--,@Modified_On datetime
--as
--begin
--	insert into Employee (Employee_Code,First_Name,Last_Name,Gender,Age,Mobile_No,Email_ID,Address,City,State,Country,Department,Designation,Salary,Created_On,Modified_On) values (@Employee_Code, @First_Name, @Last_Name, @Gender, @Age, @Mobile_No, @Email_ID, @Address, @City, @State, @Country, @Department, @Designation, @Salary, @Created_On, @Modified_On)
--end


--create procedure Employee_Update
--@ID int
--,@Employee_Code varchar(50)
--,@First_Name varchar(50)
--,@Last_Name varchar(50)
--,@Gender int
--,@Age int
--,@Mobile_No bigint
--,@Email_ID varchar(50)
--,@Address varchar(50)
--,@City int
--,@State int
--,@Country int
--,@Department int
--,@Designation int
--,@Salary decimal(10,2)
--,@Modified_On datetime
--as 
--begin
--	update Employee set Employee_Code=@Employee_Code,First_Name=@First_Name,Last_Name=@Last_Name,Gender=@Gender,Age=@Age,Mobile_No=@Mobile_No,Email_ID=@Email_ID,Address=@Address,City=@City,State=@State,Country=@Country,Department=@Department,Designation=@Designation,Salary=@Salary,Modified_On=@Modified_On where ID=@ID
--end


--create procedure Employee_Delete
--@ID int
--as
--begin
--	delete from Employee where ID =@ID
--end


--create procedure Employee_Edit
--@ID int
--as
--begin
--	select * from Employee where ID=@ID
--end


--create procedure Employee_Join
--as
--begin
--	select * from Employee 
--	join tblGender on Gender=GenderID 
--	join tblCountry on Country=CountryID 
--	join tblState on State=StateID 
--	join tblCity on City=CityID 
--	join tblDepartment on Department=DepartmentID 
--	join tblDesignation on Designation=DesignationID
--end


--create procedure Employee_Gender
--as
--begin
--	select * from tblGender
--end


--create procedure Employee_Country
--as
--begin
--	select * from tblCountry
--end


--create procedure Employee_State
--@CountryID int
--as
--begin
--	select * from tblState where CountryID=@CountryID
--end


--create procedure Employee_City
--@StateID int
--as
--begin
--	select * from tblCity where StateID=@StateID
--end


--create procedure Employee_Department
--as
--begin
--	select * from tblDepartment
--end


--create procedure Employee_Designation
--@DepartmentID int
--as
--begin
--	select * from tblDesignation where DepartmentID=@DepartmentID
--end



create procedure EmployeeProcedure
@action varchar(50)=null
,@ID int=0
,@Employee_Code varchar(50)=null
,@First_Name varchar(50)=null
,@Last_Name varchar(50)=null
,@Gender int=0
,@Age int=0
,@Address varchar(50)=null
,@City int=0
,@State int=0
,@Country int=0
,@Department int=0
,@Designation int=0
,@Salary decimal(10,2)=0
,@Mobile_No bigint=0
,@Email_ID varchar(50)=null
,@Password varchar(50)=null
,@CountryID int=0
,@StateID int=0
,@DepartmentID int=0
,@NewPassword varchar(50)=null
,@CurrentPassword varchar(50)=null
,@EmpID int =0
,@Name varchar(100)=null
,@MaritalStatus int=0
,@BloodGroup int=0
,@DOB date=null
,@Joining_Date date=null 
,@Image varchar(100)=null
,@Status int=0
,@MSID int=0
,@MSName varchar(50)=null
,@BGID int=0
,@BGName varchar(50)=null
,@CountryName varchar(50)=null
,@GenderID int=0
,@GenderName varchar(50)=null
,@DepartmentName varchar(50)=null
,@StateName varchar(50)=null
,@CityID int=0
,@CityName varchar(50)=null
,@DesignationID int=0
,@DesignationName varchar(50)=null
,@Search varchar(50)=null
--Date or datetime=null 
as
begin
	if(@action = 'Insert')
		begin
			 insert into Employee(Employee_Code,First_Name,Last_Name,Gender,Age,Address,City,State,Country,Department,Designation,Salary,Mobile_No,Email_ID,Password, Created_On,Modified_On) values (@Employee_Code, @First_Name, @Last_Name, @Gender, @Age, @Address, @City, @State, @Country, @Department, @Designation, @Salary, @Mobile_No, @Email_ID,@Password, GETDATE(), GETDATE())
		end
		else if(@action = 'Update')
		begin
			update Employee set Employee_Code=@Employee_Code,First_Name=@First_Name,Last_Name=@Last_Name,Gender=@Gender,Age=@Age,Address=@Address,City=@City,State=@State,Country=@Country,Department=@Department,Designation=@Designation,Salary=@Salary,Mobile_No=@Mobile_No,Email_ID=@Email_ID,Password=@Password,Modified_On=GETDATE() where ID=@ID
		end
		else if(@action = 'Delete')
		begin
			delete from Employee where ID =@ID
		end
		else if(@action = 'Edit')
		begin
			select * from Employee where ID=@ID
		end
		else if(@action = 'Join')
		begin
			select * from Employee 
			join tblGender on Gender=GenderID 
			join tblCountry on Country=CountryID 
			join tblState on State=StateID 
			join tblCity on City=CityID 
			join tblDepartment on Department=DepartmentID 
			join tblDesignation on Designation=DesignationID
		end
		else if(@action = 'Gender')
		begin
			select * from tblGender where Status=0
		end
		else if(@action = 'Country')
		begin
			select * from tblCountry where Status=0
		end
		else if(@action = 'State')
		begin
			select * from tblState where CountryID=@CountryID and Status=0
		end
		else if(@action = 'City')
		begin
			select * from tblCity where StateID=@StateID and Status=0
		end
		else if(@action = 'Department')
		begin
			select * from tblDepartment where Status=0
		end
		else if(@action = 'Designation')
		begin
			select * from tblDesignation where DepartmentID=@DepartmentID and Status=0
		end
		else if(@action = 'MaritalStatus')
		begin
			select * from tblMarital_Status where Status=0
		end
		else if(@action = 'BloodGroup')
		begin
			select * from tblBlood_Group where Status=0
		end
		else if(@action = 'Login')
		begin
			select * from Employee where Email_ID=@Email_ID and Password=@Password
		end
		else if(@action = 'Joinone')
		begin
			select * from Employee 
			join tblGender on Gender=GenderID 
			join tblCountry on Country=CountryID 
			join tblState on State=StateID 
			join tblCity on City=CityID 
			join tblDepartment on Department=DepartmentID 
			join tblDesignation on Designation=DesignationID
			where ID=@ID
		end
		else if(@action = 'ChangePassword')
		begin
			update Employee set Password=@NewPassword where Id=@ID and Password=@CurrentPassword
		end
		else if(@action = 'InsertProfile')
		begin
			insert into Employee_Profile(Name,Gender,DOB,Marital_Status,Blood_Group,Joining_Date,Image,Created_On,Modified_On) values (@Name,@Gender,@DOB,@MaritalStatus,@BloodGroup,@Joining_Date,@Image,GETDATE(),GETDATE())
		end
		else if(@action = 'UpdateProfile')
		begin
			update Employee_Profile set Name=@Name,Gender=@Gender,DOB=@DOB,Marital_Status=@MaritalStatus,Blood_Group=@BloodGroup,Joining_Date=@Joining_Date,Image=@Image,Modified_On=GETDATE() where EmpID=@EmpID
		end
		else if(@action = 'DeleteProfile')
		begin
			update Employee_Profile set Status=1 where EmpID=@EmpID
		end
		else if(@action = 'EditProfile')
		begin
			select *,convert(varchar(50), DOB,23) as Dateofbirth,convert(varchar(50), Joining_Date,23) as Joindate from Employee_Profile where EmpID=@EmpID
		end
		else if(@action = 'JoinProfile')
		begin
			--select *,convert(varchar(50), DOB,106) as Dateofbirth,convert(varchar(50), Joining_Date,106) as Joindate,convert(varchar(50), Created_On,113) as DateCreated,convert(varchar(50), Modified_On,113) as DateModified from Employee_Profile 
			--join tblGender on Gender=GenderID 
			--join tblMarital_Status on Marital_Status=MSID 
			--join tblBlood_Group on Blood_Group=BGID
			--where Employee_Profile.Status=0
			select 
			Employee_Profile.EmpID
			,Employee_Profile.Name
			,Employee_Profile.Gender
			,Employee_Profile.Marital_Status
			,Employee_Profile.Blood_Group
			,Employee_Profile.Image
			,Employee_Profile.Status
			,convert(varchar(50), DOB,106) as Dateofbirth,
			convert(varchar(50), Joining_Date,106) as Joindate,
			convert(varchar(50), Created_On,113) as DateCreated,
			convert(varchar(50), Modified_On,113) as DateModified 
			,tblGender.GenderName
			,tblMarital_Status.MSName
			,tblBlood_Group.BGName
			from Employee_Profile 
			join tblGender on Gender=GenderID 
			join tblMarital_Status on Marital_Status=MSID 
			join tblBlood_Group on Blood_Group=BGID
			where Employee_Profile.Status=0
		end
		else if(@action = 'MSInsert')
		begin
			insert into tblMarital_Status(MSName) values(@MSName)
		end
		else if(@action = 'MSUpdate')
		begin
			update tblMarital_Status set MSName=@MSName where MSID=@MSID
		end
		else if(@action = 'MSEdit')
		begin
			select * from tblMarital_Status where MSID=@MSID
		end
		else if(@action = 'StatusMS')
		begin
			declare @m int
			select @m=Status from tblMarital_Status where MSID=@MSID
			if(@m=0)
				begin
					update tblMarital_Status set Status=1 where MSID=@MSID
				end
			else
				begin
					update tblMarital_Status set Status=0 where MSID=@MSID
				end
		end
		else if(@action = 'MSShow')
		begin
			select * from tblMarital_Status
		end
		else if(@action = 'BGInsert')
		begin
			insert into tblBlood_Group(BGName) values(@BGName)
		end
		else if(@action = 'BGUpdate')
		begin
			update tblBlood_Group set BGName=@BGName where BGID=@BGID
		end
		else if(@action = 'BGEdit')
		begin
			select * from tblBlood_Group where BGID=@BGID
		end
		else if(@action = 'StatusBG')
		begin
			declare @b int
			select @b=Status from tblBlood_Group where BGID=@BGID
			if(@b=0)
				begin
					update tblBlood_Group set Status=1 where BGID=@BGID
				end
			else
				begin
					update tblBlood_Group set Status=0 where BGID=@BGID
				end
		end
		else if(@action = 'BGShow')
		begin
			select * from tblBlood_Group
		end
		else if(@action = 'CountryInsert')
		begin
			insert into tblCountry(CountryName) values(@CountryName)
		end
		else if(@action = 'CountryUpdate')
		begin
			update tblCountry set CountryName=@CountryName where CountryID=@CountryID
		end
		else if(@action = 'CountryEdit')
		begin
			select * from tblCountry where CountryID=@CountryID
		end
		else if(@action = 'StatusCountry')
		begin
			declare @c int
			select @c=Status from tblCountry where CountryID=@CountryID
			if(@c=0)
				begin
					update tblCountry set Status=1 where CountryID=@CountryID
				end
			else
				begin
					update tblCountry set Status=0 where CountryID=@CountryID
				end
		end
		else if(@action = 'CountryShow')
		begin
			select * from tblCountry
		end
		else if(@action = 'GenderInsert')
		begin
			insert into tblGender(GenderName) values(@GenderName)
		end
		else if(@action = 'GenderUpdate')
		begin
			update tblGender set GenderName=@GenderName where GenderID=@GenderID
		end
		else if(@action = 'GenderEdit')
		begin
			select * from tblGender where GenderID=@GenderID
		end
		else if(@action = 'StatusGender')
		begin
			declare @g int
			select @g=Status from tblGender where GenderID=@GenderID
			if(@g=0)
				begin
					update tblGender set Status=1 where GenderID=@GenderID
				end
			else
				begin
					update tblGender set Status=0 where GenderID=@GenderID
				end
		end
		else if(@action = 'GenderShow')
		begin
			select * from tblGender
		end
		else if(@action = 'DepartmentInsert')
		begin
			insert into tblDepartment(DepartmentName) values(@DepartmentName)
		end
		else if(@action = 'DepartmentUpdate')
		begin
			update tblDepartment set DepartmentName=@DepartmentName where DepartmentID=@DepartmentID
		end
		else if(@action = 'DepartmentEdit')
		begin
			select * from tblDepartment where DepartmentID=@DepartmentID
		end
		else if(@action = 'StatusDepartment')
		begin
			declare @d int
			select @d=Status from tblDepartment where DepartmentID=@DepartmentID
			if(@d=0)
				begin
					update tblDepartment set Status=1 where DepartmentID=@DepartmentID
				end
			else
				begin
					update tblDepartment set Status=0 where DepartmentID=@DepartmentID
				end
		end
		else if(@action = 'DepartmentShow')
		begin
			select * from tblDepartment
		end
		else if(@action = 'StateInsert')
		begin
			insert into tblState(CountryID,StateName) values(@CountryID,@StateName)
		end
		else if(@action = 'StateUpdate')
		begin
			update tblState set CountryID=@CountryID, StateName=@StateName where StateID=@StateID
		end
		else if(@action = 'StateEdit')
		begin
			select * from tblState where StateID=@StateID
		end
		else if(@action = 'StatusState')
		begin
			declare @s int
			select @s=Status from tblState where StateID=@StateID
			if(@s=0)
				begin
					update tblState set Status=1 where StateID=@StateID
				end
			else
				begin
					update tblState set Status=0 where StateID=@StateID
				end
		end
		else if(@action = 'StateJoin')
		begin
			select * from tblState join tblCountry on tblState.CountryID=tblCountry.CountryID 
		end
		else if(@action = 'StateShow')
		begin
			select * from tblState
		end
		else if(@action = 'CityInsert')
		begin
			insert into tblCity(StateID,CityName) values(@StateID,@CityName)
		end
		else if(@action = 'CityUpdate')
		begin
			update tblCity set StateID=@StateID, CityName=@CityName where CityID=@CityID
		end
		else if(@action = 'CityEdit')
		begin
			select * from tblCity where CityID=@CityID
		end
		else if(@action = 'StatusCity')
		begin
			declare @cc int
			select @cc=Status from tblCity where CityID=@CityID
			if(@cc=0)
				begin
					update tblCity set Status=1 where CityID=@CityID
				end
			else
				begin
					update tblCity set Status=0 where CityID=@CityID
				end
		end
		else if(@action = 'CityJoin')
		begin
			select * from tblCity join tblState on tblCity.StateID=tblState.StateID join tblCountry on tblState.CountryID=tblCountry.CountryID 
		end
		else if(@action = 'DesignationInsert')
		begin
			insert into tblDesignation(DepartmentID,DesignationName) values(@DepartmentID,@DesignationName)
		end
		else if(@action = 'DesignationUpdate')
		begin
			update tblDesignation set DepartmentID=@DepartmentID, DesignationName=@DesignationName where DesignationID=@DesignationID
		end
		else if(@action = 'DesignationEdit')
		begin
			select * from tblDesignation where DesignationID=@DesignationID
		end
		else if(@action = 'StatusDesignation')
		begin
			declare @dd int
			select @dd=Status from tblDesignation where DesignationID=@DesignationID
			if(@dd=0)
				begin
					update tblDesignation set Status=1 where DesignationID=@DesignationID
				end
			else
				begin
					update tblDesignation set Status=0 where DesignationID=@DesignationID
				end
		end
		else if(@action = 'DesignationShow')
		begin
			select * from tblDesignation join tblDepartment on tblDesignation.DepartmentID=tblDepartment.DepartmentID
		end
		else if(@action = 'Search')
		begin
			select *,convert(varchar(50), DOB,106) as Dateofbirth,convert(varchar(50), Joining_Date,106) as Joindate,convert(varchar(50), Created_On,113) as DateCreated,convert(varchar(50), Modified_On,113) as DateModified from Employee_Profile join tblGender on Gender = GenderID join tblMarital_Status on Marital_Status = MSID join tblBlood_Group on Blood_Group = BGID where Name like @Search+'%' and Employee_Profile.Status=0
		end
end


--else if(@action = 'StateJoin')
--begin
--	select * from tblState join tblCountry on CountryID=Country_ID
--end



sp_helptext EmployeeProcedure
--exec EmployeeProcedure @Action ='StatusMS'
--exec EmployeeProcedure @Action ='JoinProfile', @MSID=2
--drop procedure EmployeeProcedure


create table Employee_Profile
(
EmpID int primary key identity
,Name varchar(100)
,Gender int
,DOB date
,Marital_Status int
,Blood_Group int
,Joining_Date date
,Image varchar(100)
,Status int default 0
,Created_On datetime
,Modified_On datetime
)

sp_rename 'Employee_Profile.PStatus','Status'

select * from Employee_Profile
--drop table Employee_Profile




select *,convert(varchar(50), DOB,106) as Dateofbirth,convert(varchar(50), Joining_Date,106) as Joindate,convert(varchar(50), Created_On,113) as DateCreated,convert(varchar(50), Modified_On,113) as DateModified from Employee_Profile 
			join tblGender on Gender=GenderID 
			join tblMarital_Status on Marital_Status=MSID 
			join tblBlood_Group on Blood_Group=BGID
			where Employee_Profile.Status=0





select * from Employee_Profile join tblGender on Gender = GenderID join tblMarital_Status on Marital_Status = MSID join tblBlood_Group on Blood_Group = BGID where Name like 'aka%' and Employee_Profile.Status=0














--SELECT 
--e.ID
--,e.Employee_Code
--,e.First_Name
--,e.Last_Name
--,e.Gender
--,Convert(date,e.DOB,108) AS DOB
--,e.Mobile_No
--,e.Email_ID
--,e.Address
--,e.City
--,e.State
--,e.Country
--,e.Department
--,e.Designation
--,e.Salary
--FROM Employee e
--JOIN tblGender tg ON e.Gender = tg.GenderID
--JOIN tblCountry tc ON e.Country = tc.CountryID
--JOIN tblState ts ON e.STATE = ts.StateID
--JOIN tblCity ct ON e.City = ct.CityID
--JOIN tblDepartment td ON e.Department = td.DepartmentID
--JOIN tblDesignation dg ON e.Designation = dg.DesignationID
--WHERE e.id = 1


--SELECT e.ID ,e.Employee_Code ,e.First_Name ,e.Last_Name ,e.Gender ,Convert(date,e.DOB,108) AS DOB ,e.Mobile_No ,e.Email_ID ,e.Address ,e.City ,e.State ,e.Country ,e.Department ,e.Designation ,e.Salary   FROM Employee e WHERE e.ID='" + e.CommandArgument + "'


--select * from tblMarital_Status

--declare @m int
--Declare @MSID int=2
--			select @m=Status from tblMarital_Status where MSID=@MSID
--			if(@m=0)
--				begin
--					update tblMarital_Status set Status=1 where MSID=@MSID
--				end
--			else if(@m=1)
--				begin
--					update tblMarital_Status set Status=0 where MSID=@MSID
--				end