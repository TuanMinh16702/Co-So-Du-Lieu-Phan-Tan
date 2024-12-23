USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[GET_STAFFLIST]    Script Date: 12/24/2024 12:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[GET_STAFFLIST]
AS
BEGIN 
	SELECT MaNV, Ho, Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
	FROM NHANVIEN
	WHERE TrangThai = 1
END