USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien2]    Script Date: 12/24/2024 12:07:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_HoatDongNhanVien2]
@MANV Char(10),
@DATEFROM DATE,
@DATETO DATE,
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
		BEGIN
			SELECT FORMAT(PN.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'NHAP' AS LOAI,
					PN.NgayLap, 
					PN.SoPN AS MAPHIEU,
					TenHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						 SoPN,
						 TENKHO = ( SELECT TENKHO FROM Kho WHERE PN.MAKHO = Kho.MAKHO )
				  FROM PhieuNhap AS PN
				  WHERE NgayLap BETWEEN @DATEFROM AND @DATETO AND MANV = @MANV ) AS  PN,
				  ChiTietPhieuNhap AS CTPN,
				  (SELECT MAHH, TENHH FROM HangHoa ) VT
				  WHERE PN.SoPN =CTPN.SoPN
				  AND VT.MaHH = CTPN.MaHH   
			UNION ALL
			SELECT FORMAT(HD.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'XUAT' AS LOAI,
					HD.NgayLap, 
					HD.SoHD AS MAPHIEU,
					TENHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						SoHD,
						TENKHO = ( SELECT TENKHO FROM Kho WHERE HD.MAKHO = Kho.MAKHO )
					FROM HoaDon AS HD
					WHERE NgayLap BETWEEN @DATEFROM AND @DATETO 
					AND MANV = @MANV ) AS HD,
					ChiTietHoaDon AS CTHD,
					(SELECT MAHH, TENHH FROM HangHoa ) AS HH
					WHERE HD.SoHD =CTHD.SOHD
					AND HH.MaHH = CTHD.MaHH
			ORDER BY NGAYLAP, MAPHIEU, TENHH
		END
	ELSE
		BEGIN
			SELECT FORMAT(PN.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'NHAP' AS LOAI,
					PN.NgayLap, 
					PN.SoPN AS MAPHIEU,
					TenHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						 SoPN,
						 TENKHO = ( SELECT TENKHO FROM  LINK2.QLVT.DBO.Kho WHERE PN.MAKHO = Kho.MAKHO )
				  FROM  LINK2.QLVT.DBO.PhieuNhap AS PN
				  WHERE NgayLap BETWEEN @DATEFROM AND @DATETO AND MANV = @MANV ) AS  PN,
				  LINK2.QLVT.DBO.ChiTietPhieuNhap AS CTPN,
				  (SELECT MAHH, TENHH FROM HangHoa ) VT
				  WHERE PN.SoPN =CTPN.SoPN
				  AND VT.MaHH = CTPN.MaHH   
			UNION ALL
			SELECT FORMAT(HD.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'XUAT' AS LOAI,
					HD.NgayLap, 
					HD.SoHD AS MAPHIEU,
					TENHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						SoHD,
						TENKHO = ( SELECT TENKHO FROM  LINK2.QLVT.DBO.Kho WHERE HD.MAKHO = Kho.MAKHO )
					FROM  LINK2.QLVT.DBO.HoaDon AS HD
					WHERE NgayLap BETWEEN @DATEFROM AND @DATETO 
					AND MANV = @MANV ) AS HD,
					 LINK2.QLVT.DBO.ChiTietHoaDon AS CTHD,
					(SELECT MAHH, TENHH FROM HangHoa ) AS HH
					WHERE HD.SoHD =CTHD.SOHD
					AND HH.MaHH = CTHD.MaHH
			ORDER BY NGAYLAP, MAPHIEU, TENHH
		END
END