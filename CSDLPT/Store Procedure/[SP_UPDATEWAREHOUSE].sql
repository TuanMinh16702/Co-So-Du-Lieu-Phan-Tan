USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEWAREHOUSE]    Script Date: 12/24/2024 12:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_UPDATEWAREHOUSE]
	@MaKho INT,
    @TenKho NVARCHAR(100)
	
AS
BEGIN
	UPDATE KHO
	SET TenKho = @TenKho
	WHERE MaKho = @MaKho
END

