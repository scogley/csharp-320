USE [Formula1]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 1/29/2017 11:54:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_driver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CircuitName] [nvarchar](50) NULL,
	[DriverName] [nvarchar](50) NOT NULL,
	[TeamName] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Points] [nvarchar](1000) NULL,
    [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Formula1_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Formula1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO