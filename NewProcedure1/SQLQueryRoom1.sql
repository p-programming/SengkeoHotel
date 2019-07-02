USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_ExpendType]    Script Date: 11/06/2019 23:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE New_Room
As
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(RoomID,5)as int)),0) + 1 From Room;
	select  'R' +RIGHT ('00'+ CAST(@MaxNo As varchar),5);
	END