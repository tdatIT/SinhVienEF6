
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2022 22:50:21
-- Generated from EDMX file: E:\Study Or Work\C#\StudentManagement\StudentManagement\StudentDAO.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuanLySinhVienEntityFramework];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Students1'
CREATE TABLE [dbo].[Students1] (
    [mssv] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [birthday] int  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [sex] int  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [mssv] in table 'Students1'
ALTER TABLE [dbo].[Students1]
ADD CONSTRAINT [PK_Students1]
    PRIMARY KEY CLUSTERED ([mssv] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------