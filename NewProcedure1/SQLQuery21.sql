USE [ProjectSengKeo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE New_RoomTypes
As
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(RoomTypeID,5)as int)),0) + 1 From RoomType;
	select  'RTS' +RIGHT ('00'+ CAST(@MaxNo As varchar),5);
	END