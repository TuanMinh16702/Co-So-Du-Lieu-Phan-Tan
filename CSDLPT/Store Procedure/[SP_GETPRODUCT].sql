USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCT]    Script Date: 12/24/2024 12:06:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETPRODUCT]
AS
BEGIN
	
		SELECT MaHH, TenHH, DonViTinh ,LH.TenLH
		FROM HangHoa AS HH WITH (INDEX(IX_TenHangHoa)) , (SELECT MALH, TenLH FROM LOAIHANG) AS LH  
		WHERE HH.MaLH = LH.MaLH AND TrangThai = 1
		
END

