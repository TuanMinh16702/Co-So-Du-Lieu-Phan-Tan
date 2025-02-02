USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETSTAFFLIST]    Script Date: 12/24/2024 12:07:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETSTAFFLIST]
	@MACN_CBX CHAR(4)
AS
BEGIN 
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT MaNV, HOTEN = Ho +' ' + Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
		FROM NHANVIEN
		WHERE TrangThai = 1
	END
	ELSE
	BEGIN
		SELECT MaNV, HOTEN = Ho +' ' + Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
		FROM  LINK2.QLVT.DBO.NHANVIEN
		WHERE TrangThai = 1
	END
END