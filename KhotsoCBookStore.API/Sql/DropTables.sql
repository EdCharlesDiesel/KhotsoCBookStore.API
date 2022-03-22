-- Drop a table called '_' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[__EFMigrationsHistory]', 'U') IS NOT NULL
DROP TABLE [dbo].[__EFMigrationsHistory]
GO

IF OBJECT_ID('[dbo].[WishListItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[WishListItems]
GO

IF OBJECT_ID('[dbo].[WishLists]', 'U') IS NOT NULL
DROP TABLE [dbo].[WishLists]
GO

IF OBJECT_ID('[dbo].[ProductSubscriptionItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductSubscriptionItems]
GO

IF OBJECT_ID('[dbo].[ProductSubscriptions]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductSubscriptions]
GO

IF OBJECT_ID('[dbo].[Orders]', 'U') IS NOT NULL
DROP TABLE [dbo].[Orders]
GO

IF OBJECT_ID('[dbo].[OrderItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[OrderItems]
GO

IF OBJECT_ID('[dbo].[Authors]', 'U') IS NOT NULL
DROP TABLE [dbo].[Authors]
GO

IF OBJECT_ID('[dbo].[Publishers]', 'U') IS NOT NULL
DROP TABLE [dbo].[Publishers]
GO

IF OBJECT_ID('[dbo].[Promotions]', 'U') IS NOT NULL
DROP TABLE [dbo].[Promotions]
GO

IF OBJECT_ID('[dbo].[CartItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[CartItems]
GO

IF OBJECT_ID('[dbo].[Cart]', 'U') IS NOT NULL
DROP TABLE [dbo].[Cart]
GO

IF OBJECT_ID('[dbo].[Categories]', 'U') IS NOT NULL
DROP TABLE [dbo].[Categories]
GO

IF OBJECT_ID('[dbo].[Books]', 'U') IS NOT NULL
DROP TABLE [dbo].[Books]
GO

IF OBJECT_ID('[dbo].[UserMasters]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserMasters]
GO

IF OBJECT_ID('[dbo].[CustomerOrderDetails]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserTypes]
GO

IF OBJECT_ID('[dbo].[Customers]', 'U') IS NOT NULL
DROP TABLE [dbo].[Customers]
GO

-- IF OBJECT_ID('[dbo].[Employees]', 'U') IS NOT NULL
-- DROP TABLE [dbo].[Employees]
-- GO



IF OBJECT_ID('[dbo].[UserMaster]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserMaster]
GO

IF OBJECT_ID('[dbo].[Authors]', 'U') IS NOT NULL
DROP TABLE [dbo].[Authors]
GO



IF OBJECT_ID('[dbo].[Customers]', 'U') IS NOT NULL
DROP TABLE [dbo].[Customers]
GO



