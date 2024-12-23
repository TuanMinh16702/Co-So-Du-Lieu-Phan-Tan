USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETERECEIPT]    Script Date: 12/24/2024 12:04:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_DELETERECEIPT]
	@SOPN CHAR(10)
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	UPDATE PhieuNhap
	SET TrangThai = 0
	WHERE SoPN = @SOPN
END
COMMIT TRANSACTION