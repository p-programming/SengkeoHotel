USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_Room]    Script Date: 13/06/2019 16:30:47 ******/
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