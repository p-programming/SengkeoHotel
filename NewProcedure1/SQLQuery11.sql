USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_CardType]    Script Date: 05/06/2019 11:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[New_CardType]
As
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(CardTypeID,5)as int)),0) + 1 From CardType;
	select  'CT' +RIGHT ('000'+ CAST(@MaxNo As varchar),5);
	END