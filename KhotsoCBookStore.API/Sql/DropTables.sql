-- Drop a table called '_' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[__EFMigrationsHistory]', 'U') IS NOT NULL
DROP TABLE [dbo].[__EFMigrationsHistory]
GO

IF OBJECT_ID('[dbo].[Books]', 'U') IS NOT NULL
DROP TABLE [dbo].[Books]
GO

IF OBJECT_ID('[dbo].[CartItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[CartItems]
GO

IF OBJECT_ID('[dbo].[Categories]', 'U') IS NOT NULL
DROP TABLE [dbo].[Categories]
GO

IF OBJECT_ID('[dbo].[Carts]', 'U') IS NOT NULL
DROP TABLE [dbo].[Carts]
GO

IF OBJECT_ID('[dbo].[CustomerOrderDetails]', 'U') IS NOT NULL
DROP TABLE [dbo].[CustomerOrderDetails]
GO

IF OBJECT_ID('[dbo].[CustomerOrders]', 'U') IS NOT NULL
DROP TABLE [dbo].[CustomerOrders]
GO

IF OBJECT_ID('[dbo].[Employees]', 'U') IS NOT NULL
DROP TABLE [dbo].[Employees]
GO

IF OBJECT_ID('[dbo].[ProductSubscriptions]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductSubscriptions]
GO

IF OBJECT_ID('[dbo].[ProductSubscriptionItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductSubscriptionItems]
GO

IF OBJECT_ID('[dbo].[UserMaster]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserMaster]
GO

IF OBJECT_ID('[dbo].[UserType]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserType]
GO

IF OBJECT_ID('[dbo].[WishLists]', 'U') IS NOT NULL
DROP TABLE [dbo].[WishLists]
GO

IF OBJECT_ID('[dbo].[WishListItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[WishListItems]
GO

