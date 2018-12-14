
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2018 10:02:22
-- Generated from EDMX file: C:\Users\bshaw\source\repos\DevBuildAssessments\Assessment7\StillWorkingThatList_BlakeShaw\StillWorkingThatList_BlakeShaw\Models\BlakePartyDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlakePartyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Dish_Guest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dish] DROP CONSTRAINT [FK_Dish_Guest];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dish];
GO
IF OBJECT_ID(N'[dbo].[Guest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Guest];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dishes'
CREATE TABLE [dbo].[Dishes] (
    [DishId] int IDENTITY(1,1) NOT NULL,
    [PersonName] nvarchar(50)  NULL,
    [PhoneNumber] nvarchar(24)  NULL,
    [DishName] nvarchar(50)  NULL,
    [DishDescription] nvarchar(100)  NULL,
    [Catagory] nvarchar(20)  NULL,
    [GuestId] int  NULL
);
GO

-- Creating table 'Guests'
CREATE TABLE [dbo].[Guests] (
    [GuestId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [AttendanceDate] datetime  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Guest1] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DishId] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [PK_Dishes]
    PRIMARY KEY CLUSTERED ([DishId] ASC);
GO

-- Creating primary key on [GuestId] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [PK_Guests]
    PRIMARY KEY CLUSTERED ([GuestId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GuestId] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [FK_Dish_Guest]
    FOREIGN KEY ([GuestId])
    REFERENCES [dbo].[Guests]
        ([GuestId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dish_Guest'
CREATE INDEX [IX_FK_Dish_Guest]
ON [dbo].[Dishes]
    ([GuestId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------