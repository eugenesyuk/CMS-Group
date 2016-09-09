
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/28/2013 15:29:36
-- Generated from EDMX file: C:\Users\coirius\Projects\CMS Group\CMS Group Website\DB\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [cmgroupwebsitedb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BlogPostAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [FK_BlogPostAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogPostLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [FK_BlogPostLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogPostComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [FK_BlogPostComments];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogPostCommentAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [FK_BlogPostCommentAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteMenuLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SiteMenus] DROP CONSTRAINT [FK_SiteMenuLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteSliderLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SIteSliders] DROP CONSTRAINT [FK_SiteSliderLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteMenuSiteMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SiteMenus] DROP CONSTRAINT [FK_SiteMenuSiteMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_PageLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pages] DROP CONSTRAINT [FK_PageLanguage];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[BlogPosts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogPosts];
GO
IF OBJECT_ID(N'[dbo].[BlogComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogComments];
GO
IF OBJECT_ID(N'[dbo].[SiteMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiteMenus];
GO
IF OBJECT_ID(N'[dbo].[SIteSliders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SIteSliders];
GO
IF OBJECT_ID(N'[dbo].[Pages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pages];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(3)  NOT NULL,
    [IconUrl] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BlogPosts'
CREATE TABLE [dbo].[BlogPosts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Author] int  NOT NULL,
    [Language] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'BlogComments'
CREATE TABLE [dbo].[BlogComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [Content] nvarchar(max)  NOT NULL,
    [PostId] int  NOT NULL,
    [Author] int  NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'SiteMenus'
CREATE TABLE [dbo].[SiteMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Parent] int  NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Language] int  NOT NULL,
    [Order] smallint  NOT NULL
);
GO

-- Creating table 'SIteSliders'
CREATE TABLE [dbo].[SIteSliders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [Order] smallint  NOT NULL,
    [Language] int  NOT NULL
);
GO

-- Creating table 'Pages'
CREATE TABLE [dbo].[Pages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Language] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogPosts'
ALTER TABLE [dbo].[BlogPosts]
ADD CONSTRAINT [PK_BlogPosts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogComments'
ALTER TABLE [dbo].[BlogComments]
ADD CONSTRAINT [PK_BlogComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SiteMenus'
ALTER TABLE [dbo].[SiteMenus]
ADD CONSTRAINT [PK_SiteMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SIteSliders'
ALTER TABLE [dbo].[SIteSliders]
ADD CONSTRAINT [PK_SIteSliders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [PK_Pages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Author] in table 'BlogPosts'
ALTER TABLE [dbo].[BlogPosts]
ADD CONSTRAINT [FK_BlogPostAuthor]
    FOREIGN KEY ([Author])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogPostAuthor'
CREATE INDEX [IX_FK_BlogPostAuthor]
ON [dbo].[BlogPosts]
    ([Author]);
GO

-- Creating foreign key on [Language] in table 'BlogPosts'
ALTER TABLE [dbo].[BlogPosts]
ADD CONSTRAINT [FK_BlogPostLanguage]
    FOREIGN KEY ([Language])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogPostLanguage'
CREATE INDEX [IX_FK_BlogPostLanguage]
ON [dbo].[BlogPosts]
    ([Language]);
GO

-- Creating foreign key on [PostId] in table 'BlogComments'
ALTER TABLE [dbo].[BlogComments]
ADD CONSTRAINT [FK_BlogPostComments]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[BlogPosts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogPostComments'
CREATE INDEX [IX_FK_BlogPostComments]
ON [dbo].[BlogComments]
    ([PostId]);
GO

-- Creating foreign key on [Author] in table 'BlogComments'
ALTER TABLE [dbo].[BlogComments]
ADD CONSTRAINT [FK_BlogPostCommentAuthor]
    FOREIGN KEY ([Author])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogPostCommentAuthor'
CREATE INDEX [IX_FK_BlogPostCommentAuthor]
ON [dbo].[BlogComments]
    ([Author]);
GO

-- Creating foreign key on [Language] in table 'SiteMenus'
ALTER TABLE [dbo].[SiteMenus]
ADD CONSTRAINT [FK_SiteMenuLanguage]
    FOREIGN KEY ([Language])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteMenuLanguage'
CREATE INDEX [IX_FK_SiteMenuLanguage]
ON [dbo].[SiteMenus]
    ([Language]);
GO

-- Creating foreign key on [Language] in table 'SIteSliders'
ALTER TABLE [dbo].[SIteSliders]
ADD CONSTRAINT [FK_SiteSliderLanguage]
    FOREIGN KEY ([Language])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteSliderLanguage'
CREATE INDEX [IX_FK_SiteSliderLanguage]
ON [dbo].[SIteSliders]
    ([Language]);
GO

-- Creating foreign key on [Parent] in table 'SiteMenus'
ALTER TABLE [dbo].[SiteMenus]
ADD CONSTRAINT [FK_SiteMenuSiteMenu]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[SiteMenus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteMenuSiteMenu'
CREATE INDEX [IX_FK_SiteMenuSiteMenu]
ON [dbo].[SiteMenus]
    ([Parent]);
GO

-- Creating foreign key on [Language] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [FK_PageLanguage]
    FOREIGN KEY ([Language])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PageLanguage'
CREATE INDEX [IX_FK_PageLanguage]
ON [dbo].[Pages]
    ([Language]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------