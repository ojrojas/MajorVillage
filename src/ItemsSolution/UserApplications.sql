CREATE DATABASE IF NOT EXISTS MajorVillageDB;

USE MajorVillageDB;

CREATE TABLE IF NOT EXISTS UserApplication (
    Id varchar(36) primary key default uuid() not null,
    UserName varchar(150) not null,
    Password varchar(300) not null,
    CreatedBy varchar(36) not null,
    CreatedOn Timestamp not null,
    ModifiedBy varchar(36) null,
    ModifiedOn Timestamp null
)