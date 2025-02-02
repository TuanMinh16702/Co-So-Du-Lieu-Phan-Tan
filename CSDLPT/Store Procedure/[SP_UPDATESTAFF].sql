USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATESTAFF]    Script Date: 12/24/2024 12:08:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_UPDATESTAFF]
	@MaNV CHAR(10),
    @Ho NVARCHAR(50),
	@Ten nvarchar(50),
    @NgaySinh date,
	@DiaCHi Nvarchar(100),
	@SoDienThoai char(10),
	@Phai nvarchar(3)
AS
BEGIN
	UPDATE NhanVien
	SET Phai = @Phai, Ho = @Ho, Ten = @Ten, NgaySinh = @NgaySinh, DiaChi = @DiaCHi, SoDienThoai = @SoDienThoai, TrangThai = 1
	WHERE MaNV = @MaNV

END