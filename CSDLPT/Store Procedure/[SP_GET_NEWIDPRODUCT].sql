USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_NEWIDPRODUCT]    Script Date: 12/24/2024 12:05:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GET_NEWIDPRODUCT]
	@MaLH Char(10)
AS
BEGIN
	DECLARE @NewMaHH CHAR(10);

    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    --SELECT @NewMaHH = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;

	SELECT NewMaHH = Trim(@MaLH) + trim(cast((count(MaHH) + 1 )as CHAR))
	FROM HangHoa 
	WHERE Trim(MaLH) = Trim(@MaLH);

END