USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietSoLuongTriGiaHangHoaNhapXuat]    Script Date: 12/24/2024 12:03:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ChiTietSoLuongTriGiaHangHoaNhapXuat]
@MACN_CBX CHAR(4),
@TYPE NVARCHAR(4),
@DATEFROM DATETIME,
@DATETO DATETIME
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN != @MACN_CBX)
	BEGIN
		IF(@TYPE = 'NHAP')--NHAP
		BEGIN
				SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
				FROM
					( SELECT NgayLap,SoPN 
						FROM LINK2.QLVT.DBO.PhieuNhap
						WHERE NgayLap BETWEEN @DATEFROM AND @DATETO   ) AS PHIEU,
					( SELECT TenHH ,MaHH FROM HangHoa ) HH,
					( SELECT SoLuong, DonGia, SoPN, MaHH FROM LINK2.QLVT.DBO.ChiTietPhieuNhap) AS CT
				WHERE PHIEU.SoPN = CT.SoPN
				AND HH.MaHH = CT.MaHH
				GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
				ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END

		ELSE--@TYPE = 'XUAT'
		BEGIN
					SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
					FROM
						( SELECT NgayLap,SoHD
							FROM LINK2.QLVT.DBO.HoaDon
							WHERE NgayLap BETWEEN @DATEFROM AND @DATETO   ) AS PHIEU,
						( SELECT TenHH,MaHH FROM HangHoa ) AS HH,
						( SELECT SoLuong, DonGia, SoHD, MaHH FROM LINK2.QLVT.DBO.ChiTietHoaDon) AS CT
					WHERE PHIEU.SoHD = CT.SoHD
					AND HH.MaHH = CT.MaHH
					GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
					ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END
	END

	ELSE -- CHI NHANH & USER
	BEGIN
		IF(@TYPE = 'NHAP')
		BEGIN
				SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
				FROM
					( SELECT NgayLap,SoPN 
						FROM PhieuNhap
						WHERE NgayLap BETWEEN @DATEFROM  AND @DATETO ) AS PHIEU,
					( SELECT TenHH , MaHH FROM HangHoa ) AS HH,
					( SELECT SoLuong, DonGia, SoPN ,MaHH FROM ChiTietPhieuNhap) CT
				WHERE PHIEU.SoPN = CT.SoPN
				AND HH.MaHH = CT.MaHH
				GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
				ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END
		ELSE -- @LOAI = 'XUAT'
		BEGIN
					SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
					FROM
						( SELECT NgayLap,SoHD
							FROM HoaDon
							WHERE NgayLap BETWEEN @DATEFROM AND @DATETO   ) AS PHIEU,
						( SELECT TenHH,MaHH FROM HangHoa ) AS HH,
						( SELECT SoLuong, DonGia, SoHD, MaHH FROM ChiTietHoaDon) AS CT
					WHERE PHIEU.SoHD = CT.SoHD
					AND HH.MaHH = CT.MaHH
					GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
					ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END
	END
END