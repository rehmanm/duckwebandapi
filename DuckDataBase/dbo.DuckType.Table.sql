USE [duck]
GO
/****** Object:  Table [dbo].[DuckType]    Script Date: 09/05/2019 12:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuckType](
	[DuckTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DuckTypeName] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
