USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDRECEIPT]    Script Date: 12/24/2024 12:02:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_ADDRECEIPT]
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWSOPN CHAR(10)
	SET @NEWSOPN= (SELECT CONCAT('DDH' ,COUNT(SOPN) + 1) FROM LINK0.QLVT.DBO.PHIEUNHAP)
END
COMMIT TRANSACTION