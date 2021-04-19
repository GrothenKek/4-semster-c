
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2021 11:17:32
-- Generated from EDMX file: C:\Users\groth\source\repos\4-semster-c\Dag11\WebApplicationZipCodes\WebApplicationZipCodes\WebApplicationZipCodes\Models\zipcode.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ZipDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ZipSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZipSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ZipSet'
CREATE TABLE [dbo].[ZipSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ZipName] nvarchar(max)  NOT NULL,
    [ZipCode] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ZipSet'
ALTER TABLE [dbo].[ZipSet]
ADD CONSTRAINT [PK_ZipSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------