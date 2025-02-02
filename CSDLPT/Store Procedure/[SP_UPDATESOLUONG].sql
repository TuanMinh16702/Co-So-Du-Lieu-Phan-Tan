USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATESOLUONG]    Script Date: 12/24/2024 12:08:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_UPDATESOLUONG]
	@MAHH CHAR(10),
	@MAKHO CHAR(10),
	@SOLUONG INT
AS
BEGIN

	WHILE (@SOLUONG > 0)
	BEGIN
		-- Cập nhật từng dòng một
		WITH CTE AS		(
			SELECT TOP 1
                CTPN.MaHH, CTPN.SoPN, CTPN.SoluongTon
            FROM ChiTietPhieuNhap AS CTPN
            FULL JOIN PhieuNhap AS PN ON PN.SoPN = CTPN.SoPN
            JOIN KHO ON KHO.MaKho = PN.MaKho
            JOIN HangHoa AS HH ON HH.MaHH = CTPN.MaHH
            WHERE CTPN.MaHH = @MAHH 
				  AND Kho.MaKho = @MAKHO 
                  AND Kho.TrangThai = 1 
                  AND HH.TrangThai = 1 
                  AND CTPN.SoluongTon > 0
            ORDER BY CTPN.SoluongTon DESC
		)
		UPDATE CTE
        SET SoluongTon = SoluongTon - 1


		SET @SOLUONG = @SOLUONG - 1; 
        -- Giảm số lượng cần trừ (tổng số cần cập nhật)

        
        -- Thoát vòng lặp nếu không còn dòng nào để trừ
        
	END
END


