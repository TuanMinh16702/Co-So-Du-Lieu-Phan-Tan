USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCTTYPE]    Script Date: 12/24/2024 12:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETPRODUCTTYPE] 
AS
BEGIN
	SELECT MaLH, TenLH
	FROM LoaiHang
END