USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCTINWAREHOUSE]    Script Date: 12/24/2024 12:06:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETPRODUCTINWAREHOUSE]
	@MAHH CHAR(10)
AS
BEGIN
	SELECT ctpn.MaHH, KHO.MaKho ,TenKho , SOLUONG =  SUM(SoluongTon), DonGia
	FROM PhieuNhap AS PN JOIN ChiTietPhieuNhap AS CTPN
	ON PN.SoPN = CTPN.SoPN
	JOIN KHO 
	ON KHO.MaKho = PN.MaKho
	JOIN HangHoa
	ON HangHoa.MaHH = CTPN.MaHH
	WHERE CTPN.MaHH = @MAHH AND Kho.TrangThai = 1 AND HangHoa.TrangThai = 1 AND PN.TrangThai = 1
	GROUP BY ctpn.MaHH, TENKHO, DonGia, kho.MaKho
	
END