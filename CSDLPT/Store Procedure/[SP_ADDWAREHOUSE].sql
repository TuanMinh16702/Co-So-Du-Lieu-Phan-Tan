USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDWAREHOUSE]    Script Date: 12/24/2024 12:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_ADDWAREHOUSE]
    @TenKho NVARCHAR(100)
	
AS
BEGIN
	DECLARE @NewMaKho INT;
	DECLARE @MaCN Char(10);
    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    SELECT @NewMaKho = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;
	SELECT @MaCN = MaCN FROM ChiNhanh
    -- Chèn vào bảng với mã kho mới
    INSERT INTO Kho (MaKho, TenKho, MaCN, TrangThai)
    VALUES (@NewMaKho, @TenKho, @MaCN, 1);
END