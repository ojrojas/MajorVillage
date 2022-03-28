CREATE DATABASE IF NOT EXISTS MajorVillageDB;

USE MajorVillageDB;

CREATE TABLE IF NOT EXISTS Student (
    Id varchar(36) primary key default uuid() not null,
    FirstName varchar(50) not null,
    MiddleName varchar(50) null,
    LastName varchar(50) not null,
    Identification nvarchar(15) not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null
)