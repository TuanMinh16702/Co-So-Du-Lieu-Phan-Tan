USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_TongHopNhapXuat]    Script Date: 12/24/2024 12:08:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_TongHopNhapXuat]
@MACN_CBX CHAR(4),
@FromDate DATETIME,
@ToDate DATETIME
AS
BEGIN
	DECLARE @MACN CHAR(4)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		--------------------phieu xuat--------------------------
		SELECT PN.NgayLap,
				NHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG)),
				TYLENHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG) / (SELECT SUM(DONGIA * SOLUONG)
							FROM ChiTietPhieuNhap  , PhieuNhap WHERE ChiTietPhieuNhap.SoPN = PhieuNhap.SoPN
							AND PhieuNhap.NgayLap BETWEEN @FromDate AND @ToDate   )) INTO #PHIEUNHAPTABLE
		FROM PhieuNhap AS PN,
			ChiTietPhieuNhap AS CTPN
		WHERE PN.SoPN = CTPN.SoPN
		AND PN.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY PN.NgayLap
	
		--------------------phieu xuat--------------------------
		SELECT HD.NgayLap,
				XUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)),
				TYLEXUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)/ (SELECT SUM(DONGIA * SOLUONG)
							FROM ChiTietHoaDon , HOADON WHERE ChiTietHoaDon.SoHD = HOADON.SoHD
							AND HOADON.NgayLap BETWEEN @FromDate AND @ToDate )) INTO #HOADONTABLE
		FROM HoaDon AS HD,
			ChiTietHoaDon AS CTHD
		WHERE HD.SoHD = CTHD.SoHD
		AND HD.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY HD.NgayLap
		-----------------------TONG HOP--------------------------------------
		SELECT 
			ISNULL(CONVERT(varchar,FORMAT(PN.NgayLap, 'dd-MM-yyyy'), 11), CONVERT(varchar, FORMAT(HD.NgayLap, 'dd-MM-yyyy'), 11)) AS NGAY,
			(ISNULL(PN.NHAP, 0)) AS NHAP,
			ISNULL(PN.TYLENHAP,0) TILENHAP,
			(ISNULL(HD.XUAT,0)) XUAT,
			ISNULL(HD.TYLEXUAT,0) AS TILEXUAT
		FROM #PHIEUNHAPTABLE AS PN 
		FULL JOIN #HOADONTABLE AS HD
		ON PN.NgayLap = HD.NgayLap
	END
	
	ELSE
	BEGIN 
		--------------------phieu xuat--------------------------
		SELECT PN.NgayLap,
				NHAP =(SUM (CTPN.DONGIA * CTPN.SOLUONG)),
				TYLENHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG) / (SELECT SUM(DONGIA * SOLUONG)
							FROM LINK2.QLVT.DBO.ChiTietPhieuNhap  , LINK2.QLVT.DBO.PhieuNhap WHERE ChiTietPhieuNhap.SoPN = PhieuNhap.SoPN
							AND PhieuNhap.NgayLap BETWEEN @FromDate AND @ToDate   )) INTO #PHIEUNHAPTABLE2
		FROM LINK2.QLVT.DBO.PhieuNhap AS PN,
			LINK2.QLVT.DBO.ChiTietPhieuNhap AS CTPN
		WHERE PN.SoPN = CTPN.SoPN
		AND PN.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY PN.NgayLap
	
		--------------------phieu xuat--------------------------
		SELECT HD.NgayLap,
				XUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)),
				TYLEXUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)/ (SELECT SUM(DONGIA * SOLUONG)
							FROM LINK2.QLVT.DBO.ChiTietHoaDon , LINK2.QLVT.DBO.HOADON WHERE ChiTietHoaDon.SoHD = HOADON.SoHD
							AND HOADON.NgayLap BETWEEN @FromDate AND @ToDate )) INTO #HOADONTABLE2
		FROM LINK2.QLVT.DBO.HoaDon AS HD,
			LINK2.QLVT.DBO.ChiTietHoaDon AS CTHD
		WHERE HD.SoHD = CTHD.SoHD
		AND HD.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY HD.NgayLap
		-----------------------TONG HOP--------------------------------------
		SELECT 
			ISNULL(CONVERT(varchar,FORMAT(PN.NgayLap, 'dd-MM-yyyy'), 11), CONVERT(varchar, FORMAT(HD.NgayLap, 'dd-MM-yyyy'), 11)) AS NGAY,
			(ISNULL(PN.NHAP, 0)) AS NHAP,
			ISNULL(PN.TYLENHAP,0) TILENHAP,
			(ISNULL(HD.XUAT,0)) XUAT,
			ISNULL(HD.TYLEXUAT,0) AS TILEXUAT
		FROM #PHIEUNHAPTABLE2 AS PN 
		FULL JOIN #HOADONTABLE2 AS HD
		ON PN.NgayLap = HD.NgayLap
	END
	
END