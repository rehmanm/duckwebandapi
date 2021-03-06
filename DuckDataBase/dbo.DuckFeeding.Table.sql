USE [duck]
GO
/****** Object:  Table [dbo].[DuckFeeding]    Script Date: 09/05/2019 12:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuckFeeding](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [varchar](255) NULL,
	[Time] [time](7) NULL,
	[DuckFoodID] [int] NULL,
	[FeedLocationID] [int] NULL,
	[NumberOfDucks] [int] NULL,
	[FoodType] [varchar](50) NULL,
	[AmountOfFood] [float] NULL,
	[Date] [date] NULL,
	[InsertedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DuckFeeding] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[DuckFeeding] ADD  DEFAULT (getdate()) FOR [InsertedOn]
GO
ALTER TABLE [dbo].[DuckFeeding] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
