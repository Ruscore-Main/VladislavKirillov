
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2022 20:55:34
-- Generated from EDMX file: D:\3 курс 2 семестр\MONEY\VladislavKirillov1\VladislavKirillov1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\RUSLAN\DOCUMENTS\VLADKIRILLOV.MDF];
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

-- Creating table 'DirectorSet'
CREATE TABLE [dbo].[DirectorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Patronimyc] nvarchar(max)  NOT NULL,
    [Post] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeeSet'
CREATE TABLE [dbo].[EmployeeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Patronymic] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ShopId] int  NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [Difficulty] nvarchar(max)  NOT NULL,
    [PreparationTime] int  NOT NULL,
    [Amount] int  NOT NULL,
    [WorkListId] int  NULL
);
GO

-- Creating table 'WorkListSet'
CREATE TABLE [dbo].[WorkListSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotalProductionTime] int  NOT NULL,
    [Employee_Id] int  NULL
);
GO

-- Creating table 'ShopSet'
CREATE TABLE [dbo].[ShopSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DirectorSet'
ALTER TABLE [dbo].[DirectorSet]
ADD CONSTRAINT [PK_DirectorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkListSet'
ALTER TABLE [dbo].[WorkListSet]
ADD CONSTRAINT [PK_WorkListSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopSet'
ALTER TABLE [dbo].[ShopSet]
ADD CONSTRAINT [PK_ShopSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Employee_Id] in table 'WorkListSet'
ALTER TABLE [dbo].[WorkListSet]
ADD CONSTRAINT [FK_EmployeeWorkList]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeWorkList'
CREATE INDEX [IX_FK_EmployeeWorkList]
ON [dbo].[WorkListSet]
    ([Employee_Id]);
GO

-- Creating foreign key on [WorkListId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_WorkListProduct]
    FOREIGN KEY ([WorkListId])
    REFERENCES [dbo].[WorkListSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkListProduct'
CREATE INDEX [IX_FK_WorkListProduct]
ON [dbo].[ProductSet]
    ([WorkListId]);
GO

-- Creating foreign key on [ShopId] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [FK_EmployeeShop]
    FOREIGN KEY ([ShopId])
    REFERENCES [dbo].[ShopSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeShop'
CREATE INDEX [IX_FK_EmployeeShop]
ON [dbo].[EmployeeSet]
    ([ShopId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------