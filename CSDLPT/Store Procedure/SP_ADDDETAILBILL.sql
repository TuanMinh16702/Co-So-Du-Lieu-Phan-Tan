USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDDETAILBILL]    Script Date: 12/24/2024 12:02:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_ADDDETAILBILL]
	@SoHD INT,
	@MaHH char(10),
	@MaKho char(10),
	@SoLuong int,
	@DonGia float
	
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWSOLUONG INT
	

	INSERT INTO ChiTietHoaDon(SoHD,MaHH,SoLuong,DonGia)
	VALUES(@SoHD,@MaHH,@SoLuong,@DonGia)

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
COMMIT TRANSACTION