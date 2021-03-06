USE [duck]
GO
/****** Object:  Table [dbo].[DuckFeedingRecurring]    Script Date: 09/05/2019 12:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuckFeedingRecurring](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [varchar](255) NULL,
	[Time] [time](7) NULL,
	[DuckFoodID] [int] NULL,
	[FeedLocationID] [int] NULL,
	[NumberOfDucks] [int] NULL,
	[FoodType] [varchar](50) NULL,
	[AmountOfFood] [float] NULL,
	[StartDate] [date] NULL,
	[InsertedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DuckFeedingRecurring] ADD  DEFAULT (getdate()) FOR [StartDate]
GO
ALTER TABLE [dbo].[DuckFeedingRecurring] ADD  DEFAULT (getdate()) FOR [InsertedOn]
GO
ALTER TABLE [dbo].[DuckFeedingRecurring] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
