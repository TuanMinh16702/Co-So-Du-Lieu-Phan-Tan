USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_LapDonDatHang]    Script Date: 12/24/2024 12:08:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_LapDonDatHang]
    @MaDDH char(10),
    @NgayLap DATE,
    @MaNV char(50),
    @MaNCC char(50),
    @MaKho char(50),
	@SoLuong int,
	@DonGia float,
	@MaHH char(10)
AS
BEGIN
    -- Bắt đầu transaction
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Thực hiện chèn dữ liệu vào bảng DonDatHang
        INSERT INTO DonDatHang (MaDDH, NgayLap, MaNV, MaNCC, MaKho)
        VALUES (@MaDDH, @NgayLap, @MaNV, @MaNCC, @MaKho);
        
		INSERT INTO ChiTietDonDatHang (MaDDH, MaHH, SoLuong, DonGia)
		VALUES (@MaDDH, @MaHH, @SoLuong, @DonGia);
        -- Nếu thành công, commit transaction
        COMMIT TRANSACTION;
        
        -- Thông báo thành công
        PRINT 'Đơn đặt hàng đã được tạo thành công.';
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback transaction
        ROLLBACK TRANSACTION;
        
        -- Bắt lỗi và trả về thông báo lỗi
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
