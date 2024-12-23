USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDBILL]    Script Date: 12/24/2024 12:01:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_ADDBILL]
	@SoHD char(10),
	@NgayLap date,
	@MaNV char(10),
	@MaKho char(10),
	@MaKh char(10)
	
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	

	INSERT INTO HoaDon(SOHD,NgayLap,MaNV,MAKH,MaKho)
	VALUES(@SoHD,@NgayLap,@MaNV,@MaKh,@MaKho)

	
END
COMMIT TRANSACTION