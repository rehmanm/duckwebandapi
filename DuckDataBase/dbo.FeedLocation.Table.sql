USE [duck]
GO
/****** Object:  Table [dbo].[FeedLocation]    Script Date: 09/05/2019 12:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedLocation](
	[FeedLocationID] [int] IDENTITY(1,1) NOT NULL,
	[FeedLocationName] [varchar](255) NULL
) ON [PRIMARY]
GO
