USE [QLVT]
GO
/****** Object:  StoredProcedure [dbo].[KiemTraDonDatHang]    Script Date: 12/13/2024 10:51:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[KiemTraDonDatHang]
as
begin
		select ddh.MaDDH ,HH.MaHH,TenNCC , TenHH,
		   ctddh.SoLuong as Soluongnhan, 
		   Isnull(sum(ctpn.SoLuong),0) as Soluongnhap , 
		   soluongcannhap = ctddh.SoLuong -  Isnull(sum(ctpn.SoLuong),0), 
		   DonGia
	from (select MaDDH, TenNCC, TrangThai from DonDatHang, NhaCungCap WHERE DonDatHang.MaNCC = NhaCungCap.MaNCC AND TRANGTHAI = 1) as ddh
	join (select MaDDH, SoLuong, MaHH, DonGia from ChiTietDonDatHang) as ctddh
	on ctddh.MaDDH = ddh.MaDDH
	join (select MaHH, TenHH from HangHoa where TrangThai = 1) as HH 
	on ctddh.MaHH = HH.MaHH
	left join (select MaDDH, SoPN, MaKho,TrangThai from PhieuNhap WHERE TrangThai = 1) as pn
	on pn.MaDDH = ctddh.MaDDH
	left join (select SoPN, SoLuong from ChiTietPhieuNhap) as ctpn
	on ctpn.SoPN = pn.SoPN
	where  ctddh.SoLuong > ISNULL(ctpn.SoLuong, 0) or ctpn.SoLuong is null 
	group by ddh.MaDDH,ctddh.SoLuong,TenNCC , TenHH, DonGia, HH.MaHH
	Having ctddh.SoLuong -  Isnull(sum(ctpn.SoLuong),0) > 0
end