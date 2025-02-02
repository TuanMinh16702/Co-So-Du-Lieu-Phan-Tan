USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_DonHangKhongPhieuNhap]    Script Date: 12/24/2024 12:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DonHangKhongPhieuNhap]
@MACN_CBX CHAR(4)
AS
BEGIN
DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT DH.MaDDH, 
			   DH.NgayLap, 
			   TenNCC, 
			   HOTEN,
			   TenHH,
			   SOLUONG,
			   DONGIA = FORMAT(DONGIA,'N0')
		FROM 
			(SELECT MaDDH, NgayLap, TrangThai,NCC.TenNCC, HOTEN = (SELECT HOTEN = HO + ' ' + TEN 
														 FROM NhanVien 
														 WHERE DDH.MaNV = NhanVien.MANV) 
			 FROM DonDatHang AS DDH , NhaCungCap AS NCC WHERE DDH.MaNCC = NCC.MaNCC) AS DH,
			 (SELECT MaDDH, MAHH,SOLUONG,DONGIA FROM ChiTietDonDatHang ) AS CTDDH,
			 (SELECT TENHH, MAHH FROM HangHoa ) HH
			WHERE CTDDH.MaDDH = DH.MaDDH
			AND HH.MAHH = CTDDH.MAHH
			AND DH.MaDDH NOT IN (SELECT MaDDH FROM PhieuNhap)
			AND TrangThai = 1
	end
	ELSE
	BEGIN
		SELECT DH.MaDDH, 
			   DH.NgayLap, 
			   TenNCC, 
			   HOTEN,
			   TenHH,
			   SOLUONG,
			   FORMAT(DONGIA,'N0')
		FROM 
			(SELECT MaDDH, NgayLap, TrangThai,NCC.TenNCC, HOTEN = (SELECT HOTEN = HO + ' ' + TEN 
														 FROM  LINK2.QLVT.DBO.NhanVien 
														 WHERE DDH.MaNV = NhanVien.MANV) 
			 FROM  LINK2.QLVT.DBO.DonDatHang AS DDH , NhaCungCap AS NCC WHERE DDH.MaNCC = NCC.MaNCC) AS DH,
			 (SELECT MaDDH, MAHH,SOLUONG,DONGIA FROM  LINK2.QLVT.DBO.ChiTietDonDatHang ) AS CTDDH,
			 (SELECT TENHH, MAHH FROM HangHoa ) HH
			WHERE CTDDH.MaDDH = DH.MaDDH
			AND HH.MAHH = CTDDH.MAHH
			AND DH.MaDDH NOT IN (SELECT MaDDH FROM  LINK2.QLVT.DBO.PhieuNhap)
			AND TrangThai = 1
	END
END