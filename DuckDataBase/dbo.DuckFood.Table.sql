USE [duck]
GO
/****** Object:  Table [dbo].[DuckFood]    Script Date: 09/05/2019 12:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuckFood](
	[FoodID] [int] IDENTITY(1,1) NOT NULL,
	[FoodName] [varchar](255) NULL
) ON [PRIMARY]
GO
