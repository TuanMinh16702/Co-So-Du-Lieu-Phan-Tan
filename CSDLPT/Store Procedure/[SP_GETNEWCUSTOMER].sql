USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWCUSTOMER]    Script Date: 12/24/2024 12:05:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETNEWCUSTOMER]
	@TenKH nvarchar(100),
	@DiaChi nvarchar(100),
	@SoDienThoai char(10)
	
AS

BEGIN
	DECLARE @NEWMAHD CHAR(10)
	SET @NEWMAHD = (SELECT COUNT(MaKH) + 1 FROM LINK0.QLVT.DBO.KhachHang)

	DECLARE @Macn CHAR(10)
	SET @Macn = (SELECT MaCN  FROM ChiNhanh)
	
	INSERT INTO KhachHang(MaKH,TenKH,DiaChi,SoDienThoai,MaCN)
	VALUES(@NEWMAHD, @TenKH, @DiaChi, @SoDienThoai ,@Macn)
END