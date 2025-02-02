USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEORDER]    Script Date: 12/24/2024 12:08:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_UPDATEORDER]
	@MaDDH CHAR(10),
    @NgayLap date,
	@MaNCC char(10),
    @MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	UPDATE DonDatHang
	SET NgayLap = @NgayLap, MaNCC = @MaNCC, MaKho = @MaKho
	WHERE MaDDH = @MaDDH

	UPDATE ChiTietDonDatHang
	SET MaHH = @MaHH, SoLuong = @SoLuong, DonGia = @DonGia
	WHERE MaDDH = @MaDDH

END
COMMIT TRANSACTION