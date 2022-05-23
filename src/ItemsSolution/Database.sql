CREATE DATABASE IF NOT EXISTS MajorVillageDB;

USE MajorVillageDB;

CREATE TABLE IF NOT EXISTS TypeIdentification(
    Id varchar(36) primary key default uuid() not null,
    Name varchar(150) not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null
);

CREATE TABLE IF NOT EXISTS TypeUser(
    Id varchar(36) primary key default uuid() not null,
    Name varchar(150) not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null
);

CREATE TABLE IF NOT EXISTS User(
    Id varchar(36) primary key default uuid() not null,
    FirstName varchar(60) not null,
    Middlename varchar(60) null,
    LastName varchar(60) not null,
    SurName varchar(60) null,
    Identification varchar(16) not null,
    TypeIdentification  varchar(36) not null,
    Age integer not null, 
    BirthDate  DateTime not null,
    TypeUser varchar(36) not null,
    Email varchar(150) not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null
);

CREATE TABLE IF NOT EXISTS UserApplication (
    Id varchar(36) primary key default uuid() not null,
    UserName varchar(150) not null,
    UserId varchar(36) not null,
    Password varchar(300) not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null,
    Foreign Key(UserId) references User(Id)
);

CREATE TABLE IF NOT EXISTS ElectiveYear(
    Id varchar(36) primary key default uuid() not null,
    Year integer not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null
);


CREATE TABLE IF NOT EXISTS PermissionManager(
    Id varchar(36) primary key default uuid() not null,
    TypeUserId varchar(36) not null,
    Page varchar(50) not null,
    Allow boolean not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null,
    Foreign Key(TypeUserId) references TypeUser(Id)
);

CREATE TABLE IF NOT EXISTS PermissionAction(
    Id varchar(36) primary key default uuid() not null,
    PermissionManagerId varchar(36) not null,
    EditAllow boolean not null,
    CraeteAllow boolean not null, 
    UpdateAllow boolean not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null,
    Foreign Key(PermissionManagerId) references PermissionManager(Id)
);


INSERT INTO MajorVillageDB.TypeIdentification
(Id, Name, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
VALUES('551d4e76-38a0-4df4-848f-90ede4c76537', 'CC', '1b04fcbc-c0c4-437d-8a6b-c590b0da11f4', current_timestamp(), NULL, NULL),
('4d357ece-880a-45d8-851a-cac02bba5092', 'TI', '1b04fcbc-c0c4-437d-8a6b-c590b0da11f4', current_timestamp(), NULL, NULL);

INSERT INTO MajorVillageDB.TypeUser
(Id, Name, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
VALUES
('82f5a433-3c73-4e61-a177-5703114ba0ac', 'Admin', '1b04fcbc-c0c4-437d-8a6b-c590b0da11f4', current_timestamp(), NULL, NULL),
('cfbb1a1d-439e-42d0-a822-e07be28ec1aa', 'Student', '1b04fcbc-c0c4-437d-8a6b-c590b0da11f4', current_timestamp(), NULL, NULL),
('4536ea48-f042-4656-8e10-64605f00584f', 'Teacher', '1b04fcbc-c0c4-437d-8a6b-c590b0da11f4', current_timestamp(), NULL, NULL);

INSERT INTO MajorVillageDB.`User`
(Id, FirstName, Middlename, LastName, SurName, Identification, TypeIdentification, Age, BirthDate, TypeUser, Email, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
VALUES(uuid(), 'Oscar', NULL, 'Rojas', NULL, '111222333', '551d4e76-38a0-4df4-848f-90ede4c76537', 
30, '10-05-1992', '82f5a433-3c73-4e61-a177-5703114ba0ac',
'correo@correo.com', 'cb4fdac5-297e-4263-a09b-7dc2b0bc1b81', current_timestamp(), NULL, NULL);

INSERT INTO MajorVillageDB.UserApplication
(Id, UserName, UserId, Password, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
VALUES(uuid(), 'ojrojas', '5d6bc497-bd0c-11ec-8048-0242ac120002', 'Abc12345#', '2c44e001-b337-4bb7-82c3-187c0b147015', current_timestamp(), NULL, NULL);

INSERT INTO MajorVillageDB.PermissionManager
(Id,TypeUser,Page,Allow,CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)
VALUES
(uuid(),'82f5a433-3c73-4e61-a177-5703114ba0ac',"HomeComponent" '2c44e001-b337-4bb7-82c3-187c0b147015', current_timestamp(), NULL, NULL),
(uuid(),'cfbb1a1d-439e-42d0-a822-e07be28ec1aa',"HomeComponent" '2c44e001-b337-4bb7-82c3-187c0b147015', current_timestamp(), NULL, NULL),
(uuid(),'4536ea48-f042-4656-8e10-64605f00584f',"HomeComponent" '2c44e001-b337-4bb7-82c3-187c0b147015', current_timestamp(), NULL, NULL);






