USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKCUSTOMER]    Script Date: 12/24/2024 12:03:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_CHECKCUSTOMER]
 @SDT CHAR(10)
AS
BEGIN
	SELECT MaKH,TenKH, SoDienThoai, DiaChi
	FROM KhachHang
	WHERE SoDienThoai = @SDT
END