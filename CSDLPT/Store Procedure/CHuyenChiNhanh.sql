CREATE PROCEDURE sp_ChuyenChiNhanh 
	@MANV char(10), 
	@MACN nchar(10),
	@NGAYCHUYEN DATE
AS
DECLARE @LGNAME VARCHAR(50)
DECLARE @USERNAME VARCHAR(50)
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN
	BEGIN DISTRIBUTED TRAN
		DECLARE @HONV NVARCHAR(40)
		DECLARE @TENNV NVARCHAR(10)
		DECLARE @DIACHINV NVARCHAR(100)
		DECLARE @NGAYSINHNV DATE
		DECLARE @PHAI NVARCHAR(3)	
		DECLARE @SODIENTHOAI CHAR(10)
		-- Lưu lại thông tin nhân viên cần chuyển chi nhánh để làm điều kiện kiểm tra
		SELECT @HONV = HO, @TENNV = TEN, @DIACHINV = DIACHI, @NGAYSINHNV = NGAYSINH, @SODIENTHOAI = SoDienThoai, @PHAI = Phai FROM NhanVien WHERE MANV = @MANV
		-- Kiểm tra xem bên Site chuyển tới đã có dữ liệu nhân viên đó chưa. Nếu có rồi thì đổi trạng thái, chưa thì thêm vào
		IF EXISTS(select MANV
				from LINK2.QLVT.dbo.NhanVien
				where HO = @HONV and TEN = @TENNV and DIACHI = @DIACHINV
				and NGAYSINH = @NGAYSINHNV )
		BEGIN
				UPDATE LINK2.QLVT.dbo.NhanVien
				SET TrangThai = 0
				WHERE MANV = (	select MANV
								from LINK2.QLVT.dbo.NhanVien
								where HO = @HONV and TEN = @TENNV and DIACHI = @DIACHINV
										and NGAYSINH = @NGAYSINHNV AND SoDienThoai = @SODIENTHOAI AND PHAI = @PHAI )
		END
		ELSE
		-- nếu chưa tồn tại thì thêm mới hoàn toàn vào chi nhánh mới với MANV sẽ là MANV lớn nhất hiện tại + 1
		BEGIN
			DECLARE @NEWMaNV CHAR(10)
			SET @NEWMaNV = (SELECT CONCAT('NV' ,COUNT(MaNV) + 1) FROM LINK0.QLVT.dbo.NhanVien)
			DECLARE @NEWMACN CHAR(10)
			SET @NEWMACN = (SELECT MACN FROM LINK0.QLVT.dbo.ChiNhanh)
			INSERT INTO LINK2.QLVT.dbo.NhanVien (MANV, HO, TEN, DIACHI, NGAYSINH, SoDienThoai, Phai ,TrangThai)
			VALUES (@NEWMaNV, @HONV, @TENNV, @DIACHINV, @NGAYSINHNV, @SODIENTHOAI ,@PHAI, 1)
			INSERT INTO LINK2.QLVT.dbo.ChiTietNhanVien(MACN, MANV, NGAYCHUYEN)
			VALUES(@NEWMACN, @NEWMaNV, @NGAYCHUYEN)
		END
		-- Đổi trạng thái xóa đối với tài khoản cũ ở site hiện tại
		UPDATE dbo.NhanVien
		SET TrangThai = 0
		WHERE MANV = @MANV
	COMMIT TRAN;
		-- sp_droplogin và sp_dropuser không thể được thực thi trong một giao tác do người dùng định nghĩa
		-- Kiểm tra xem Nhân viên đã có login chưa. Có thì xóa
		IF EXISTS(SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR))
		BEGIN
			SET @LGNAME = CAST((SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR)) AS VARCHAR(50))
			SET @USERNAME = CAST(@MANV AS VARCHAR(50))
			EXEC SP_DROPUSER @USERNAME;
			EXEC SP_DROPLOGIN @LGNAME;
		END	
END
