USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhap]    Script Date: 12/24/2024 12:04:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_DangNhap]
	@TENLOGIN NVARCHAR( 100)
AS
	DECLARE @UID INT
	DECLARE @MANV NVARCHAR(100)
	SELECT @UID= uid , @MANV= NAME FROM sys.sysusers 
  	WHERE sid = SUSER_SID(@TENLOGIN)

	SELECT  MANV= @MANV, 
       		HOTEN = (SELECT HO+ ' '+TEN FROM dbo.NhanVien WHERE MANV=@MANV ), 
			NGAYSINH = (SELECT NgaySinh FROM dbo.NhanVien WHERE MANV=@MANV ),
			DIACHI = (SELECT DiaChi FROM dbo.NhanVien WHERE MANV=@MANV ),
			SODIENTHOAI = (SELECT SoDienThoai FROM dbo.NhanVien WHERE MANV=@MANV ),
			MACN = (SELECT MACN FROM CHINHANH),
			PHAI = (SELECT PHAI FROM dbo.NhanVien WHERE MANV=@MANV ),
       		TENNHOM=NAME
  	FROM sys.sysusers
    	WHERE UID = (SELECT groupuid FROM sys.sysmembers WHERE memberuid=@uid)
