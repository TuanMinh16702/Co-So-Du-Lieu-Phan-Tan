USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDWAREHOUSE]    Script Date: 12/24/2024 12:06:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GETNEWIDWAREHOUSE]
   
AS
BEGIN
	

    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    SELECT NewMaKho = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;

    
END