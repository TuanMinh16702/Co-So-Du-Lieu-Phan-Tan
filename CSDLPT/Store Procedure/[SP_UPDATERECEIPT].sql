USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATERECEIPT]    Script Date: 12/24/2024 12:08:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_UPDATERECEIPT]
	@SoPN CHAR(10),
    @NgayLap date,
	@MaDDH char(10),
    @MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	UPDATE PhieuNhap
	SET NgayLap = @NgayLap, MaDDH = @MaDDH, MaKho = @MaKho
	WHERE SoPN = @SoPN

	UPDATE ChiTietPhieuNhap
	SET MaHH = @MaHH, SoLuong = @SoLuong, DonGia = @DonGia
	WHERE SoPN = @SoPN

END
COMMIT TRANSACTION