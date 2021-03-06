USE [duck]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_RECURRINGSCHEDULE]    Script Date: 09/05/2019 12:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[USP_INSERT_RECURRINGSCHEDULE]

	@Date Date = NULL 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Set @Date = isNull(@Date, getdate()) 

	

DECLARE @RC int
DECLARE @EmailAddress varchar(255)   
DECLARE @Time time(7)  
DECLARE @DuckFoodID int  
DECLARE @FeedLocationID int  
DECLARE @NumberOfDucks int  
DECLARE @FoodType varchar(50)  
DECLARE @AmountOfFood float 
DECLARE @IsRecurring int = 0 


-- TODO: Set parameter values here.

Select *, ROW_NUMBER () Over(Order by ID) RowNum  into #DuckFeedingRecuringData from DuckFeedingRecurring
where StartDate <= @Date

Declare @MaxRowNum int = (Select Max(RowNum) from #DuckFeedingRecuringData)
Declare @Start int = 1

while @Start <= @MaxRowNum
Begin

Select 
   @EmailAddress = EmailAddress
  ,@Time = Time 
  ,@DuckFoodID = DuckFoodID
  ,@FeedLocationID = FeedLocationID
  ,@NumberOfDucks = NumberOfDucks
  ,@FoodType = FoodType
  ,@AmountOfFood = AmountOfFood

 from #DuckFeedingRecuringData
where RowNum = @Start


EXECUTE @RC = [dbo].[USP_INSERT_DUCKFEEDING] 
   @EmailAddress
  ,@Time
  ,@DuckFoodID
  ,@FeedLocationID
  ,@NumberOfDucks
  ,@FoodType
  ,@AmountOfFood
  ,@Date
  ,@IsRecurring



set @Start = @Start + 1


End


DROP TABLE #DuckFeedingRecuringData


End
GO
