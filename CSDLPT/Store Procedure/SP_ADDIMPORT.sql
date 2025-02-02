USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDIMPORT]    Script Date: 12/24/2024 12:02:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_ADDIMPORT]
	@NgayLap date,
	@MaNV char(10),
	@MaDDH char(10),
	@MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWMAPN CHAR(10)
	SET @NEWMAPN = (SELECT CONCAT('PN' ,COUNT(SoPN) + 1) FROM LINK0.QLVT.DBO.PHIEUNHAP)

	INSERT INTO PhieuNhap(SOPN,NgayLap,MaDDH,MaNV,MaKho,TrangThai)
	VALUES(@NEWMAPN,@NgayLap,@MaDDH,@MaNV,@MaKho,1)

	INSERT INTO ChiTietPhieuNhap(SoPN,MaHH,SoLuong,SoluongTon,DonGia)
	VALUES(@NEWMAPN,@MaHH,@SoLuong,@SoLuong,@DonGia)
END
COMMIT TRANSACTION