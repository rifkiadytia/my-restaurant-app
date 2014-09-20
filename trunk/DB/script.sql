USE [RestaurantInsight]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [bigint] NOT NULL,
	[PermissionName] [nvarchar](50) NOT NULL,
	[PermissionDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgChart]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgChart](
	[UserID] [bigint] NOT NULL,
	[ParentID] [bigint] NOT NULL,
	[ReportingTo] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategoryMaster]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategoryMaster](
	[FoodCatID] [bigint] NOT NULL,
	[FoodCatName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FoodCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[FoodCatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionStructure]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionStructure](
	[SessionID] [bigint] NOT NULL,
	[SessionParent] [bigint] NOT NULL,
	[SessionBelongTo] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionMaster]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionMaster](
	[SessionID] [bigint] NOT NULL,
	[SessionName] [nvarchar](50) NULL,
	[SessionLevel] [int] NULL,
	[SessionBelongto] [bigint] NULL,
 CONSTRAINT [PK_SessionMaster] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [bigint] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionMaster]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionMaster](
	[PositionID] [bigint] NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
	[PositionLevel] [int] NOT NULL,
 CONSTRAINT [PK_PositionMaster] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionRole]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionRole](
	[PermissionID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodMaster]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodMaster](
	[FoodID] [bigint] NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
	[FoodDescription] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[Image] [nvarchar](50) NOT NULL,
	[FoodCatID] [bigint] NOT NULL,
	[FinishingTime] [int] NOT NULL,
 CONSTRAINT [PK_FoodMaster] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[ID] [bigint] NOT NULL,
	[Usercode] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [datetime] NULL,
	[Address] [nvarchar](200) NULL,
	[Mobile] [nchar](10) NULL,
	[Password] [nvarchar](100) NOT NULL,
	[PositionID] [bigint] NULL,
	[ReportingTo] [bigint] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableMaster]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableMaster](
	[TableID] [bigint] NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[SessionID] [bigint] NOT NULL,
 CONSTRAINT [PK_TableMaster] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderMaster]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMaster](
	[OrderID] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[OrderTime] [datetime] NOT NULL,
	[TableID] [bigint] NOT NULL,
 CONSTRAINT [PK_OrderMaster] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 09/20/2014 09:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [nvarchar](50) NOT NULL,
	[FoodID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_FoodMaster_FoodCat]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[FoodMaster]  WITH CHECK ADD  CONSTRAINT [FK_FoodMaster_FoodCat] FOREIGN KEY([FoodCatID])
REFERENCES [dbo].[FoodCategoryMaster] ([FoodCatID])
GO
ALTER TABLE [dbo].[FoodMaster] CHECK CONSTRAINT [FK_FoodMaster_FoodCat]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Food]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Food] FOREIGN KEY([FoodID])
REFERENCES [dbo].[FoodMaster] ([FoodID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Food]
GO
/****** Object:  ForeignKey [FK_OrderDetails_OrderMaster]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_OrderMaster] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderMaster] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrderMaster]
GO
/****** Object:  ForeignKey [FK_OrderMaster_Table]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[OrderMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderMaster_Table] FOREIGN KEY([TableID])
REFERENCES [dbo].[TableMaster] ([TableID])
GO
ALTER TABLE [dbo].[OrderMaster] CHECK CONSTRAINT [FK_OrderMaster_Table]
GO
/****** Object:  ForeignKey [FK_OrderMaster_User]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[OrderMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderMaster_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[OrderMaster] CHECK CONSTRAINT [FK_OrderMaster_User]
GO
/****** Object:  ForeignKey [FK_PermissionRole_Permission]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[PermissionRole]  WITH CHECK ADD  CONSTRAINT [FK_PermissionRole_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[PermissionRole] CHECK CONSTRAINT [FK_PermissionRole_Permission]
GO
/****** Object:  ForeignKey [FK_PermissionRole_Role]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[PermissionRole]  WITH CHECK ADD  CONSTRAINT [FK_PermissionRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[PermissionRole] CHECK CONSTRAINT [FK_PermissionRole_Role]
GO
/****** Object:  ForeignKey [FK_TableMaster_Session]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[TableMaster]  WITH CHECK ADD  CONSTRAINT [FK_TableMaster_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionMaster] ([SessionID])
GO
ALTER TABLE [dbo].[TableMaster] CHECK CONSTRAINT [FK_TableMaster_Session]
GO
/****** Object:  ForeignKey [FK_UserInfo_Position]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Position] FOREIGN KEY([PositionID])
REFERENCES [dbo].[PositionMaster] ([PositionID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_Position]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_UserRole_User]    Script Date: 09/20/2014 09:28:00 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
