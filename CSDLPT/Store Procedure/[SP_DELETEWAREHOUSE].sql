USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETEWAREHOUSE]    Script Date: 12/24/2024 12:04:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_DELETEWAREHOUSE]
	@MaKho CHAR(10)
AS
BEGIN
	UPDATE Kho
	SET TrangThai = 0
	WHERE MaKho = @MaKho
END