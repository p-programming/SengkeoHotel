USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_RoomType]    Script Date: 12/06/2019 13:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[New_RoomType]
As
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(RoomTypeID,5)as int)),0) + 1 From RoomType;
	select  'RT' +RIGHT ('00'+ CAST(@MaxNo As varchar),5);
	END