USE [ProjectSengKeo]
GO
/****** Object:  StoredProcedure [dbo].[New_Customer]    Script Date: 05/06/2019 12:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[New_Customer]
AS
BEGIN
declare @MaxNo int, @No varchar(50);
	SELECT @MaxNo = ISNULL(MAX(cast(RIGHT(CustomerID,5)as int)),0) + 1 From Customer;
	select  '' +RIGHT (''+ CAST(@MaxNo As varchar),5);
	END