USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_CardType]    Script Date: 05/06/2019 10:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[New_CardType]
As
BEGIN
declare @MaxNo int, @No nvarchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(CardTypeID,5)as int)),0) + 1 From CardType;
	select  '00' +RIGHT ('0'+ CAST(@MaxNo As int),5);
	END