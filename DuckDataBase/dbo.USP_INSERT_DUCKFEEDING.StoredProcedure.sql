USE [duck]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_DUCKFEEDING]    Script Date: 09/05/2019 12:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_INSERT_DUCKFEEDING]
	-- Add the parameters for the stored procedure here
	@EmailAddress varchar(255),
	@Time Time,
	@DuckFoodID  [int] ,
	@FeedLocationID  int ,
	@NumberOfDucks [int] ,
	@FoodType [varchar](50),
	@AmountOfFood [float] ,
	@Date Date = NULL,
	@IsRecurring int NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Set @Date = isNull(@Date, getdate())
	set @IsRecurring = isNull(@isRecurring, 0)

	Declare @Response int = 1
	Select 
	@EmailAddress EmailAddress
           ,@Time Time
           ,@DuckFoodID DuckFoodID
           ,@FeedLocationID FeedLocationID
           ,@NumberOfDucks NumberOfDucks
           ,@FoodType FoodType
           ,@AmountOfFood AmountOfFood
           ,@Date Date into #DuckFeedingData
		    
	Merge DuckFeeding as T
	using #DuckFeedingData s
	on (t.EmailAddress = s.EmailAddress and t.Time = s.Time and t.Date = s.Date)
	When Not Matched Then
INSERT  
           ([EmailAddress]
           ,[Time]
           ,[DuckFoodID]
           ,[FeedLocationID]
           ,[NumberOfDucks]
           ,[FoodType]
           ,[AmountOfFood]
           ,[Date])
     VALUES
           (S.EmailAddress
           ,S.Time
           ,S.DuckFoodID
           ,S.FeedLocationID
           ,S.NumberOfDucks
           ,S.FoodType
           ,S.AmountOfFood
           ,S.Date)

		   WHEN MATCHED THEN   
        UPDATE SET T.DuckFoodID =  S.DuckFoodID
           ,T.FeedLocationID = S.FeedLocationID
           ,T.NumberOfDucks = S.NumberOfDucks
           ,T.FoodType = S.FoodType
           ,T.AmountOfFood = S.AmountOfFood, 
		   UpdatedOn = getdate() ;

		   set @Response = 1

		   if @IsRecurring = 1
		   Begin 

		   

	Merge DuckFeedingRecurring as T
	using #DuckFeedingData s
	on (t.EmailAddress = s.EmailAddress and t.Time = s.Time and t.StartDate = s.Date)
	When Not Matched Then
INSERT  
           ([EmailAddress]
           ,[Time]
           ,[DuckFoodID]
           ,[FeedLocationID]
           ,[NumberOfDucks]
           ,[FoodType]
           ,[AmountOfFood]
           ,[StartDate])
     VALUES
           (S.EmailAddress
           ,S.Time
           ,S.DuckFoodID
           ,S.FeedLocationID
           ,S.NumberOfDucks
           ,S.FoodType
           ,S.AmountOfFood
           ,S.Date)

		   WHEN MATCHED THEN   
        UPDATE SET T.DuckFoodID =  S.DuckFoodID
           ,T.FeedLocationID = S.FeedLocationID
           ,T.NumberOfDucks = S.NumberOfDucks
           ,T.FoodType = S.FoodType
           ,T.AmountOfFood = S.AmountOfFood, 
		   UpdatedOn = getdate() ;

		   set @Response = 2

		   End

		  Select @Response

		  Drop table #DuckFeedingData
End
GO
