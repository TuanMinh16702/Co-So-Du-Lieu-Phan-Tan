USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETIMPORT]    Script Date: 12/22/2024 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETIMPORT]
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT PN.SoPN, HH.MaHH ,TenHH ,NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), NV.MaNV ,HOTEN, K.TenKho, MaDDH, SoLuong, SoluongTon ,DonGia
		FROM PhieuNhap AS PN
		JOIN ChiTietPhieuNhap AS CTPN 
		ON PN.SoPN = CTPN.SoPN
		JOIN (SELECT MaKho, TenKho FROM Kho WHERE TrangThai = 1) AS K
		ON K.MaKho = PN.MaKhO
		JOIN (SELECT MaNV, HOTEN = HO +' ' + TEN FROM NHANVIEN) AS NV
		ON NV.MaNV = PN.MaNV
		JOIN HangHoa AS HH
		ON CTPN.MaHH = HH.MaHH
		WHERE PN.TrangThai = 1
	END
	ELSE
	BEGIN
		SELECT PN.SoPN, HH.MaHH ,TenHH ,NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), NV.MaNV ,HOTEN, K.TenKho, MaDDH, SoLuong, SoluongTon ,DonGia
		FROM  LINK2.QLVT.DBO.PhieuNhap AS PN
		JOIN  LINK2.QLVT.DBO.ChiTietPhieuNhap AS CTPN 
		ON PN.SoPN = CTPN.SoPN
		JOIN (SELECT MaKho, TenKho FROM  LINK2.QLVT.DBO.Kho WHERE TrangThai = 1) AS K
		ON K.MaKho = PN.MaKhO
		JOIN (SELECT MaNV, HOTEN = HO +' ' + TEN FROM  LINK2.QLVT.DBO.NHANVIEN) AS NV
		ON NV.MaNV = PN.MaNV
		JOIN HangHoa AS HH
		ON CTPN.MaHH = HH.MaHH
		WHERE PN.TrangThai = 1
	END
END