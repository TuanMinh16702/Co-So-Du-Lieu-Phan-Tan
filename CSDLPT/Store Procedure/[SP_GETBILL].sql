USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETBILL]    Script Date: 12/24/2024 12:05:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETBILL]
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT HD.SoHD, NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), HOTENNV, K.TenKho, TenKH, DonGia =  sum(DonGia) * sum(SoLuong)
		FROM HoaDon AS HD
		JOIN ChiTietHoaDon AS CTHD 
		ON HD.SoHD = CTHD.SoHD
		JOIN (SELECT MaKho, TenKho, TrangThai FROM Kho WHERE TRANGTHAI = 1) AS K
		ON K.MaKho = HD.MaKhO
		JOIN (SELECT MaNV, HOTENNV = HO +' ' + TEN FROM NHANVIEN) AS NV
		ON NV.MaNV = HD.MaNV
		JOIN HangHoa AS HH
		ON CTHD.MaHH = HH.MaHH
		JOIN (SELECT MaKH, TenKH FROM KhachHang) AS KH
		ON KH.MaKH = HD.MaKH 
		GROUP BY HD.SoHD, NgayLap , HOTENNV, K.TenKho, TenKH
	end
	ELSE
	BEGIN
		SELECT HD.SoHD, NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), HOTENNV, K.TenKho, TenKH, DonGia =  sum(DonGia) * sum(SoLuong)
		FROM  LINK2.QLVT.DBO.HoaDon AS HD
		JOIN  LINK2.QLVT.DBO.ChiTietHoaDon AS CTHD 
		ON HD.SoHD = CTHD.SoHD
		JOIN (SELECT MaKho, TenKho, TrangThai FROM  LINK2.QLVT.DBO.Kho WHERE TRANGTHAI = 1) AS K
		ON K.MaKho = HD.MaKhO
		JOIN (SELECT MaNV, HOTENNV = HO +' ' + TEN FROM  LINK2.QLVT.DBO.NHANVIEN) AS NV
		ON NV.MaNV = HD.MaNV
		JOIN  LINK2.QLVT.DBO.HangHoa AS HH
		ON CTHD.MaHH = HH.MaHH
		JOIN (SELECT MaKH, TenKH FROM  LINK2.QLVT.DBO.KhachHang) AS KH
		ON KH.MaKH = HD.MaKH 
		GROUP BY HD.SoHD, NgayLap , HOTENNV, K.TenKho, TenKH
	END
END