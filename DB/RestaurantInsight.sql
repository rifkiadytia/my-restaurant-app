USE [RestaurantInsight]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [bigint] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](50) NOT NULL,
	[PermissionDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgChart]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgChart](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NOT NULL,
	[ReportingTo] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategoryMaster]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategoryMaster](
	[FoodCatID] [bigint] IDENTITY(1,1) NOT NULL,
	[FoodCatName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FoodCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[FoodCatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FoodCategoryMaster] ON
INSERT [dbo].[FoodCategoryMaster] ([FoodCatID], [FoodCatName]) VALUES (1, N'Đồ ăn')
INSERT [dbo].[FoodCategoryMaster] ([FoodCatID], [FoodCatName]) VALUES (6, N'Nước uống')
INSERT [dbo].[FoodCategoryMaster] ([FoodCatID], [FoodCatName]) VALUES (7, N'Khác ...')
SET IDENTITY_INSERT [dbo].[FoodCategoryMaster] OFF
/****** Object:  Table [dbo].[SessionStructure]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionStructure](
	[SessionID] [bigint] NOT NULL,
	[SessionBelongTo] [bigint] NOT NULL,
 CONSTRAINT [PK_SessionStructure] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC,
	[SessionBelongTo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (41, 41)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (42, 42)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (43, 43)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (44, 44)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (45, 45)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (46, 45)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (46, 46)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (47, 42)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (47, 47)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (48, 42)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (48, 47)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (48, 48)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (49, 43)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (49, 49)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (50, 43)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (50, 49)
INSERT [dbo].[SessionStructure] ([SessionID], [SessionBelongTo]) VALUES (50, 50)
/****** Object:  Table [dbo].[SessionMaster]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionMaster](
	[SessionID] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionName] [nvarchar](50) NULL,
	[SessionLevel] [int] NULL,
	[SessionBelongto] [bigint] NULL,
 CONSTRAINT [PK_SessionMaster] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SessionMaster] ON
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (40, N'Restaurant', NULL, -1)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (41, N'Session 01', NULL, 40)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (42, N'Session 02', NULL, 40)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (43, N'Session 03', NULL, 40)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (44, N'Session 04', NULL, 40)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (45, N'Layer 01 -S01', NULL, 41)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (46, N'Part 01 -L01- S01', NULL, 45)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (47, N'Layer 01 -S02', NULL, 42)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (48, N'Part 01 -L01- S02', NULL, 47)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (49, N'Layer 01 -S03', NULL, 43)
INSERT [dbo].[SessionMaster] ([SessionID], [SessionName], [SessionLevel], [SessionBelongto]) VALUES (50, N'Part 01 -L01- S03', NULL, 49)
SET IDENTITY_INSERT [dbo].[SessionMaster] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription]) VALUES (1, N'ADMIN', N'admin role')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription]) VALUES (2, N'ROLE 1', N'role 01')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription]) VALUES (5, N'ROLE 2', N'test add role')
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription]) VALUES (7, N'ROLE 3', N'update role 3')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[PositionMaster]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionMaster](
	[PositionID] [bigint] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
	[PositionLevel] [int] NOT NULL,
 CONSTRAINT [PK_PositionMaster] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PositionMaster] ON
INSERT [dbo].[PositionMaster] ([PositionID], [PositionName], [PositionLevel]) VALUES (1, N'Controller', 1)
INSERT [dbo].[PositionMaster] ([PositionID], [PositionName], [PositionLevel]) VALUES (2, N'Manager', 2)
SET IDENTITY_INSERT [dbo].[PositionMaster] OFF
/****** Object:  Table [dbo].[PermissionRole]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionRole](
	[PermissionID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodMaster]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodMaster](
	[FoodID] [bigint] IDENTITY(1,1) NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
	[FoodDescription] [nvarchar](200) NULL,
	[Price] [int] NOT NULL,
	[Image] [nvarchar](100) NULL,
	[FoodCatID] [bigint] NOT NULL,
	[FinishingTime] [int] NOT NULL,
 CONSTRAINT [PK_FoodMaster] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FoodMaster] ON
INSERT [dbo].[FoodMaster] ([FoodID], [FoodName], [FoodDescription], [Price], [Image], [FoodCatID], [FinishingTime]) VALUES (7, N'Cá chẽm chưng tương', N'update description . . tex', 20000, N'20141019_ca61cf4a-0d9a-4b0d-8d23-5782b39e4c86image02.jpg', 6, 2)
INSERT [dbo].[FoodMaster] ([FoodID], [FoodName], [FoodDescription], [Price], [Image], [FoodCatID], [FinishingTime]) VALUES (8, N'Cái CC', N'des...', 12, N'20141012_12dc7f0f-3238-4c0e-ad4a-36b451fe6c28images.jpg', 6, 3)
SET IDENTITY_INSERT [dbo].[FoodMaster] OFF
/****** Object:  Table [dbo].[UserInfo]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Usercode] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [datetime] NULL,
	[Address] [nvarchar](200) NULL,
	[Image] [nvarchar](100) NULL,
	[Mobile] [nchar](10) NULL,
	[Password] [nvarchar](256) NOT NULL,
	[PositionID] [bigint] NULL,
	[ReportingTo] [bigint] NOT NULL,
	[IsFirstTime] [bit] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([ID], [Usercode], [Username], [Gender], [DOB], [Address], [Image], [Mobile], [Password], [PositionID], [ReportingTo], [IsFirstTime]) VALUES (35, N'CON-001', N'user01', 1, CAST(0x0000A3B000000000 AS DateTime), N'Nguyễn Trãi', NULL, N'0936543xxx', N'$2a$10$a7BSoBu8dKV3/FJNGRGx2uGsO2aFa.g2uNkusnJXda.Gyq33o/b66', 1, 0, 1)
INSERT [dbo].[UserInfo] ([ID], [Usercode], [Username], [Gender], [DOB], [Address], [Image], [Mobile], [Password], [PositionID], [ReportingTo], [IsFirstTime]) VALUES (36, N'CON-002', N'user02', 0, CAST(0x0000A3B600000000 AS DateTime), N'Nguyễn Văn Cừ', N'20140921_31cd9278-af12-4fea-8fa5-e08ff833b0f2.jpg', N'0911543722', N'$2a$10$wezFxzvuAy7ObrxJEV1Cdu8O/77.Q05q1zkJ6/IbyROx80QZ2wvt6', 1, 0, 1)
INSERT [dbo].[UserInfo] ([ID], [Usercode], [Username], [Gender], [DOB], [Address], [Image], [Mobile], [Password], [PositionID], [ReportingTo], [IsFirstTime]) VALUES (37, N'MAN-001', N'admin01', 0, CAST(0x0000A3B600000000 AS DateTime), N'An Dương Vương', NULL, N'0937543744', N'$2a$10$IZp9tNqaYlDgYLQQWIUaB.I5VKVsMcQkFo/EdJ.PGcY22l0avmaYO', 2, 0, 1)
INSERT [dbo].[UserInfo] ([ID], [Usercode], [Username], [Gender], [DOB], [Address], [Image], [Mobile], [Password], [PositionID], [ReportingTo], [IsFirstTime]) VALUES (38, N'MAN-002', N'admin02', 0, CAST(0x0000A3A900000000 AS DateTime), N'Lý Thái Tổ', NULL, N'0935543755', N'$2a$10$OC5CGKC9c3A2addA2W8maeNGBYk7hsTqGy0d/j4PWZHfXeUwBFRQ2', 2, 0, 1)
INSERT [dbo].[UserInfo] ([ID], [Usercode], [Username], [Gender], [DOB], [Address], [Image], [Mobile], [Password], [PositionID], [ReportingTo], [IsFirstTime]) VALUES (39, N'CON-003', N'user01', 0, CAST(0x0000A3C000000000 AS DateTime), N'Test', NULL, N'0935456543', N'$2a$10$MvtHG.MuXGA3PhoeJ0kNbuOirsUYQ365l0GJtO28reGVLsmTIfYoq', 1, 0, 1)
INSERT [dbo].[UserInfo] ([ID], [Usercode], [Username], [Gender], [DOB], [Address], [Image], [Mobile], [Password], [PositionID], [ReportingTo], [IsFirstTime]) VALUES (40, N'CON-004', N'dddd', 0, CAST(0x0000A3C300000000 AS DateTime), N'dgfdg', NULL, N'097867567 ', N'$2a$10$2g7tJaYN4If7XrMJqXDydemmuSiMhG9LHgs5vpZzeCqqSiZtgkSoO', 1, 0, 1)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  Table [dbo].[TableMaster]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableMaster](
	[TableID] [bigint] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[SessionID] [bigint] NOT NULL,
	[IsReserve] [bit] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TableMaster] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TableMaster] ON
INSERT [dbo].[TableMaster] ([TableID], [TableName], [SessionID], [IsReserve], [Type]) VALUES (14, N'Table 01', 40, 0, N'Vip')
INSERT [dbo].[TableMaster] ([TableID], [TableName], [SessionID], [IsReserve], [Type]) VALUES (15, N'Table 01', 41, 0, N'Normal')
INSERT [dbo].[TableMaster] ([TableID], [TableName], [SessionID], [IsReserve], [Type]) VALUES (16, N'Test session 01', 44, 0, N'Normal')
SET IDENTITY_INSERT [dbo].[TableMaster] OFF
/****** Object:  Table [dbo].[UserRole]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (36, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (36, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (40, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (40, 5)
/****** Object:  Table [dbo].[OrderMaster]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMaster](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/19/2014 22:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [bigint] NOT NULL,
	[FoodID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_FoodMaster_FoodCat]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[FoodMaster]  WITH CHECK ADD  CONSTRAINT [FK_FoodMaster_FoodCat] FOREIGN KEY([FoodCatID])
REFERENCES [dbo].[FoodCategoryMaster] ([FoodCatID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodMaster] CHECK CONSTRAINT [FK_FoodMaster_FoodCat]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Food]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Food] FOREIGN KEY([FoodID])
REFERENCES [dbo].[FoodMaster] ([FoodID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Food]
GO
/****** Object:  ForeignKey [FK_OrderDetails_OrderMaster]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_OrderMaster] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderMaster] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrderMaster]
GO
/****** Object:  ForeignKey [FK_OrderMaster_Table]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[OrderMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderMaster_Table] FOREIGN KEY([TableID])
REFERENCES [dbo].[TableMaster] ([TableID])
GO
ALTER TABLE [dbo].[OrderMaster] CHECK CONSTRAINT [FK_OrderMaster_Table]
GO
/****** Object:  ForeignKey [FK_OrderMaster_User]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[OrderMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderMaster_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[OrderMaster] CHECK CONSTRAINT [FK_OrderMaster_User]
GO
/****** Object:  ForeignKey [FK_PermissionRole_Permission]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[PermissionRole]  WITH CHECK ADD  CONSTRAINT [FK_PermissionRole_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[PermissionRole] CHECK CONSTRAINT [FK_PermissionRole_Permission]
GO
/****** Object:  ForeignKey [FK_PermissionRole_Role]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[PermissionRole]  WITH CHECK ADD  CONSTRAINT [FK_PermissionRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[PermissionRole] CHECK CONSTRAINT [FK_PermissionRole_Role]
GO
/****** Object:  ForeignKey [FK_TableMaster_Session]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[TableMaster]  WITH CHECK ADD  CONSTRAINT [FK_TableMaster_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionMaster] ([SessionID])
GO
ALTER TABLE [dbo].[TableMaster] CHECK CONSTRAINT [FK_TableMaster_Session]
GO
/****** Object:  ForeignKey [FK_UserInfo_Position]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Position] FOREIGN KEY([PositionID])
REFERENCES [dbo].[PositionMaster] ([PositionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_Position]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_UserRole_User]    Script Date: 10/19/2014 22:19:14 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
