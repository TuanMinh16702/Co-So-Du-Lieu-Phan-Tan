USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDPRODUCT]    Script Date: 12/24/2024 12:02:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_ADDPRODUCT]
    @TenHH NVARCHAR(100),
	@DonViTinh nvarchar(20),
	@MaLH Char(10)
AS
BEGIN
	DECLARE @NewMaHH CHAR(10);

    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    --SELECT @NewMaHH = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;

	SELECT @NewMaHH =  Trim(@MaLH) + TRIM(cast((count(MaHH) + 1 )as CHAR))
	FROM HangHoa 
	WHERE TRIM(MaLH) =  Trim(@MaLH);

    -- Chèn vào bảng với mã kho mới
    INSERT INTO HANGHOA (MaHH, TenHH, DonViTinh, MaLH, TrangThai)
    VALUES (@NewMaHH, @TenHH, @DonViTinh ,@MaLH, 1);
END