USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien]    Script Date: 12/24/2024 12:07:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_HoatDongNhanVien]
@MANV Char(10),
@LOAI NVARCHAR(4),
@DATEFROM DATE,
@DATETO DATE
AS
BEGIN
	IF( @LOAI = 'NHAP')
	BEGIN
		SELECT FORMAT(PN.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
				PN.NgayLap, 
				PN.SoPN AS MAPHIEU,
				TenHH, 
				TENKHO, 
				SOLUONG,
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
		      ORDER BY NgayLap, MAPHIEU, TenHH
	END

	ELSE
	BEGIN
		SELECT FORMAT(HD.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
				HD.NgayLap, 
				HD.SoHD AS MAPHIEU,
				TENHH, 
				TENKHO, 
				SOLUONG,
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
END