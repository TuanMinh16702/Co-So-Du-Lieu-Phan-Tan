﻿CREATE PROCEDURE [dbo].[sp_HoatDongNhanVien]
@MANV char(10),
@LOAI nvarchar(4),
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


EXEC sp_HoatDongNhanVien 'NV1', 'XUAT', '01-01-2009','01-01-2025'
EXEC sp_HoatDongNhanVien 'NV1', 'NHAP', '01-01-2009','01-01-2025'