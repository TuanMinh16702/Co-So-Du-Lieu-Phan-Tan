Create Proc KiemTraDonDatHang
as
begin
	select ddh.MaDDH, ctddh.SoLuong as Soluongnhan, Isnull(sum(ctpn.SoLuong),0) as Soluongnhap , soluongcannhap = ctddh.SoLuong -  Isnull(sum(ctpn.SoLuong),0)
	from (select MaDDH from DonDatHang) as ddh
	join (select MaDDH, SoLuong from ChiTietDonDatHang) as ctddh
	on ctddh.MaDDH = ddh.MaDDH
	left join (select MaDDH, SoPN, MaKho from PhieuNhap) as pn
	on pn.MaDDH = ctddh.MaDDH
	left join (select SoPN, SoLuong from ChiTietPhieuNhap) as ctpn
	on ctpn.SoPN = pn.SoPN
	where  ctddh.SoLuong > ctpn.SoLuong or ctpn.SoLuong is null
	group by ddh.MaDDH,ctddh.SoLuong
end