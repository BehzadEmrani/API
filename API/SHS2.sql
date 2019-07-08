
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/03/2019 09:14:11
-- Generated from EDMX file: C:\Users\Seemorgh-129\Source\Repos\BehzadEmrani\API\API\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SHS2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ServerComponent_Server_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServerComponent] DROP CONSTRAINT [FK_ServerComponent_Server_ID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ServerComponent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServerComponent];
GO
IF OBJECT_ID(N'[dbo].[Servers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servers];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ServerComponent'
CREATE TABLE [dbo].[ServerComponent] (
    [ServerComponent_ID] bigint IDENTITY(1,1) NOT NULL,
    [Server_ID] int  NOT NULL,
    [ComponentName] char(40)  NOT NULL,
    [Component_ID] int  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'Servers'
CREATE TABLE [dbo].[Servers] (
    [Server_ID] int IDENTITY(1,1) NOT NULL,
    [Name] char(20)  NOT NULL,
    [SerialNumber] char(30)  NOT NULL,
    [DatePurchased] char(10)  NOT NULL,
    [TechSupportNo] char(20)  NOT NULL,
    [MakeModel] char(20)  NOT NULL,
    [AssetTagNumber] char(10)  NOT NULL,
    [WarrantyExpirationDate] char(10)  NOT NULL,
    [Active] bit  NOT NULL,
    [RegisterDate] char(10)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [User_ID] bigint IDENTITY(1,1) NOT NULL,
    [Name] char(20)  NOT NULL,
    [Pass] char(64)  NOT NULL,
    [Role2] smallint  NOT NULL,
    [Role1] smallint  NOT NULL,
    [Active] bit  NOT NULL,
    [Person_ID] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ServerComponent_ID] in table 'ServerComponent'
ALTER TABLE [dbo].[ServerComponent]
ADD CONSTRAINT [PK_ServerComponent]
    PRIMARY KEY CLUSTERED ([ServerComponent_ID] ASC);
GO

-- Creating primary key on [Server_ID] in table 'Servers'
ALTER TABLE [dbo].[Servers]
ADD CONSTRAINT [PK_Servers]
    PRIMARY KEY CLUSTERED ([Server_ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [User_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([User_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Server_ID] in table 'ServerComponent'
ALTER TABLE [dbo].[ServerComponent]
ADD CONSTRAINT [FK_ServerComponent_Server_ID]
    FOREIGN KEY ([Server_ID])
    REFERENCES [dbo].[Servers]
        ([Server_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServerComponent_Server_ID'
CREATE INDEX [IX_FK_ServerComponent_Server_ID]
ON [dbo].[ServerComponent]
    ([Server_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------