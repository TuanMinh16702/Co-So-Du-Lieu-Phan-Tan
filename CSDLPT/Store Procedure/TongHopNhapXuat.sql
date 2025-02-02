USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_TongHopNhapXuat]    Script Date: 11/16/2024 2:23:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_TongHopNhapXuat]
@FromDate DATETIME,
@ToDate DATETIME
AS
BEGIN
	--------------------phieu xuat--------------------------
	SELECT PN.NgayLap,
			NHAP = SUM (CTPN.DONGIA * CTPN.SOLUONG),
			TYLENHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG) / (SELECT SUM(DONGIA * SOLUONG)
						FROM ChiTietPhieuNhap  )) INTO #PHIEUNHAPTABLE
	FROM PhieuNhap AS PN,
		ChiTietPhieuNhap AS CTPN
	WHERE PN.SoPN = CTPN.SoPN
	AND PN.NgayLap BETWEEN @FromDate AND @ToDate
	GROUP BY PN.NgayLap
	
	--------------------phieu xuat--------------------------
	SELECT HD.NgayLap,
			XUAT = SUM (CTHD.DONGIA * CTHD.SOLUONG),
			TYLEXUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)/ (SELECT SUM(DONGIA * SOLUONG)
						FROM ChiTietHoaDon )) INTO #HOADONTABLE
	FROM HoaDon AS HD,
		ChiTietHoaDon AS CTHD
	WHERE HD.SoHD = CTHD.SoHD
	AND HD.NgayLap BETWEEN @FromDate AND @ToDate
	GROUP BY HD.NgayLap
	-----------------------TONG HOP--------------------------------------
	SELECT 
		ISNULL(CONVERT(varchar,FORMAT(PN.NgayLap, 'dd-MM-yyyy'), 11), CONVERT(varchar, FORMAT(HD.NgayLap, 'dd-MM-yyyy'), 11)) AS NGAY,
		ISNULL(PN.NHAP, 0) AS NHAP,
		ISNULL(PN.TYLENHAP,0) TILENHAP,
		ISNULL(HD.XUAT,0) XUAT,
		ISNULL(HD.TYLEXUAT,0) AS TILEXUAT
	FROM #PHIEUNHAPTABLE AS PN 
	FULL JOIN #HOADONTABLE AS HD
	ON PN.NgayLap = HD.NgayLap
	UNION 
	--------------------Dòng tổng---------------------------------------
    SELECT 
        N'Tổng cộng' AS NGAY,
        SUM(ISNULL(PN.NHAP, 0)) AS NHAP,
        NULL AS TILENHAP,  -- Không hiển thị tỷ lệ nhập trong dòng tổng cộng
        SUM(ISNULL(HD.XUAT, 0)) AS XUAT,
        NULL AS TILEXUAT  -- Không hiển thị tỷ lệ xuất trong dòng tổng cộng
    FROM #PHIEUNHAPTABLE AS PN 
    FULL JOIN #HOADONTABLE AS HD
    ON PN.NgayLap = HD.NgayLap;
	
	
END