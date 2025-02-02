USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[Xoa_Login]    Script Date: 12/24/2024 12:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Xoa_Login}
  @USRNAME VARCHAR(50)
AS
SET XACT_ABORT ON;
begin
      
		
		  DECLARE @LGNAME CHAR(10)
		  
		  SET @LGNAME = CAST((SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(TRIM(@USRNAME) AS NVARCHAR)) AS VARCHAR(50))
		  IF NOT EXISTS  (SELECT 1 FROM sys.database_principals WHERE name = @USRNAME AND type = 'S')
			BEGIN
			   UPDATE NhanVien
			   SET TrangThai = 0
			   WHERE MaNV = @USRNAME
				PRINT('')
				RETURN 1;
			END
		  ELSE IF NOT EXISTS (SELECT 1 FROM sys.sysusers WHERE SUSER_SNAME(sid) = @LGNAME)
			BEGIN
				 UPDATE NhanVien
				  SET TrangThai = 0
				  WHERE MaNV = @USRNAME
				-- Nếu login name tồn tại trong sys.sysusers
				-- Thực hiện các hành động khi login name tồn tại
				PRINT 'Login name tồn tại trong sys.sysusers.';
				RETURN 2;
			END
		  ELSE
			BEGIN
				  UPDATE NhanVien
				  SET TrangThai = 0
				  WHERE MaNV = @USRNAME
				  EXEC SP_DROPUSER @USRNAME
				  EXEC SP_DROPLOGIN @LGNAME
			END
		
RETURN 0;		
			  
end

