USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_ExpendType]    Script Date: 08/06/2019 0:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[New_ExpendType]
As
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(ExpendTypeID,5)as int)),0) + 1 From ExpendType;
	select  'EPT' +RIGHT ('00'+ CAST(@MaxNo As varchar),5);
	END