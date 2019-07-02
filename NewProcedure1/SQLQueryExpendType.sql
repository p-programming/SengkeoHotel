USE [ProjectSengKeo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE New_ExpendType
As
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(CardTypeID,5)as int)),0) + 1 From CardType;
	select  'EPT' +RIGHT ('00'+ CAST(@MaxNo As varchar),5);
	END