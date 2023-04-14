use DACN_To_Chuc_Thi
 
go
insert into phong_thi values(N'Phòng 1',20)
insert into phong_thi values(N'Phòng 2',20)
insert into phong_thi values(N'Phòng 3',20)

--go
--insert into sinh_vien values(N'19111',N'sv 1','2000/01/01',1,N'19dthe1',N'1',1)
--insert into sinh_vien values(N'19112',N'sv 4','2000/01/01',1,N'19dthe1',N'1',1)
--insert into sinh_vien values(N'19113',N'sv 3','2000/01/01',0,N'19dthe1',N'1',1)
--insert into sinh_vien values(N'19114',N'sv 2','2000/01/01',1,N'19dthe1',N'1',1)
--insert into sinh_vien values(N'19115',N'sv 5','2000/01/01',0,N'19dthe1',N'1',1)
--insert into sinh_vien values(N'19116',N'sv 5','1/1/2000',0,N'19dthe1',N'1',1)
 
go
insert into mon values(N'Tiếng Anh 1',3)
insert into mon values(N'Quốc phòng và an ninh 1',3)
insert into mon values(N'Cơ sở dữ liệu và quản trị cơ sở dữ liệu',3)
insert into mon values(N'Chủ nghĩa xã hội khoa học',3)
insert into mon values(N'Lịch sử Đảng Cộng sản Việt Nam',3)

go
insert into Nguoi_dung values (N'Nguyen van a','2000/01/01','2019/06/01',1,N'ax@gmail.com',N'1',1,N'0123456',N'')
--insert into Nguoi_dung values (N'Nguyen van b','2000/01/01','2019/06/01',1,N'bx@gmail.com',N'1',1,N'0123456',N'')
--insert into Nguoi_dung values (N'Nguyen van c','2000/01/01','2019/06/01',1,N'cx@gmail.com',N'1',1,N'0123456',N'') 

--go
--insert into khung_de_thi values(N'kd1',90,GETDATE(),1,1)
--insert into khung_de_thi values(N'kd2',50,GETDATE(),2,2)

go
create proc Account_Login
	@email Nvarchar(30) ,
	@mat_khau Nvarchar(200)
as
begin
	declare @count int
	declare @result bit
	select @count = COUNT(*) from Nguoi_dung where email= @email and mat_khau like @mat_khau
	if @count >0
		set @result=1
	else
		set @result=0

	select @result
end

--------------Mon hoc------------------

go
create proc them_mon
	@ten_mon Nvarchar(50),
	@stc Integer 
as
begin
	insert into mon values(@ten_mon , @stc )
end 

go
create proc get_all_subject
as
begin
	select * from mon  
end 

--go
--create proc them_monx 
--	@ten_mon Nvarchar(50),
--	@stc Integer 
--as
--begin
--	insert into mon values(@ten_mon , @stc )
--	DECLARE @check Int = CASE WHEN @@ROWCOUNT > 0 THEN SCOPE_IDENTITY() ELSE 0 END
--	select @check
--end

 -------------------------------------------------------
go
create proc get_subject_by_pagination 
	@page_number int,
	@show_number int
as
begin
	select * from mon 
	order by mon.id_mon
	offset (@page_number-1)*@show_number rows fetch next @show_number row only
end
 
go
create proc UpdateSubject 
	@id Integer,
	@ten_mon Nvarchar(50),
	@stc Integer
as
begin 
 update mon set ten_mon =@ten_mon, stc =@stc where id_mon=@id
end

------------------Student---------------------------
 
 go
create proc get_student_by_pagination 
	@page_number int,
	@show_number int
as
	begin
		select * from sinh_vien 
	order by sinh_vien.mssv
	offset (@page_number-1)*@show_number rows fetch next @show_number row only
end

go
create proc isExistedStudent 
	@mssv Nvarchar(20)
as 
begin
	declare @c int
	select @c= count(*) from sinh_vien where mssv like @mssv
	declare @res bit = case when @c>0 then 1 else 0 end
	select @res
end

go
create proc themSV
	@mssv  Nvarchar(20),
	@ho_ten Nvarchar(30),
	@ngay_sinh Datetime,
	@gioi_tinh Bit,
	@lop Nvarchar(15)
as
begin
	insert into sinh_vien values(@mssv,@ho_ten,@ngay_sinh,@gioi_tinh,@lop,N'1',1)
end

go
create proc UpdateStudent
	@mssv  Nvarchar(20),
	@ho_ten Nvarchar(30),
	@ngay_sinh Datetime,
	@gioi_tinh Bit,
	@lop Nvarchar(15)
as
begin
	update sinh_vien set ho_ten=@ho_ten,ngay_sinh=@ngay_sinh,gioi_tinh=@gioi_tinh,lop=@lop 
	where mssv like @mssv
end

go
create proc stuGetById
	@mssv  Nvarchar(20)
as
begin
	select * from sinh_vien where mssv like @mssv
end

go
create proc deleteStuById
	@mssv  Nvarchar(20)
as
begin
	delete sinh_vien where mssv like @mssv
end

-----------------------------------------Khung De thi-----------------------------------
go
create proc getSubjectName
	@id Integer
as
begin
	select b.ten_mon 
	from khung_de_thi as a,mon as b
	where a.id_mon=b.id_mon and
	a.id_mon=@id
end

go
create proc getAmountTestById
	@id_khung_de int
as
begin
	select count(*)
	from de_thi where id_khung_de=@id_khung_de
end

go
create proc AddFrameTest 
	@ten_khung_de Nvarchar(50) ,
	@thoi_luong_thi Integer , 
	@id_mon Integer 
as
begin
	insert into khung_de_thi values(@ten_khung_de,@thoi_luong_thi,GETDATE(),1,@id_mon)
end

go
create proc UpdateFrameTest 
	@id_khung integer,
	@ten_khung_de Nvarchar(50) ,
	@thoi_luong_thi Integer , 
	@id_mon Integer 
as
begin
	update khung_de_thi 
	set ten_khung_de= @ten_khung_de,
		thoi_luong_thi=@thoi_luong_thi,
		ngay_tao= GETDATE(),
		id_mon=@id_mon
	where id_khung_de=@id_khung
end

--------------------------------De thi------------------------------------
go
create proc getAllTestByIdFrame 
	@id_khung integer
as
begin
	select * from de_thi where id_khung_de=@id_khung
end

go
create proc getAmountQuestion
	@id_de integer
as
begin
	select COUNT(*)
	from Cau_hoi as a, bo_cau_hoi as b
	where a.id_bo_cau_hoi=b.id_bo_cau_hoi 
	and b.id_de_thi=@id_de
end

go
create proc themDeThi  
	@ma_de_thi Nvarchar(10), 
	@id_khung_de Integer
as
begin
	insert into de_thi values(@ma_de_thi,GETDATE(),@id_khung_de)
	select SCOPE_IDENTITY()
end
 
go
create proc themBoCauHoi 
	@ten_bo_cau_hoi Nvarchar(100),
	@id_de_thi Integer
as
begin
	insert into bo_cau_hoi values(@ten_bo_cau_hoi,@id_de_thi)
	select SCOPE_IDENTITY()
end
 
go
create proc themCauHoi 
	@noi_dung Nvarchar(500),
	@diem Float,
	@id_bo_cau_hoi Integer
as
begin
	insert into Cau_hoi values(@noi_dung,@diem,@id_bo_cau_hoi)
	select SCOPE_IDENTITY()
end
 
go
create proc themLuaChon 
	@noi_dung Nvarchar(100),
	@dung_hay_sai Bit,
	@id_cau_hoi Integer
as
begin
	insert into lua_chon values(@noi_dung,@dung_hay_sai,@id_cau_hoi) 
end

go
create proc isTestDeletable
	@id_de_thi Integer
as
begin
	declare @res bit
	declare @count int
	select @count = count(*) from phieu_du_thi where id_de_thi=@id_de_thi
	if @count = 0
		set @res=1
	else
		set @res=0

	select @res
end

go
create proc deleteTestById 
	@id_de_thi Integer
as
begin  
	delete lua_chon where id_cau_hoi in  
		(select a.id_cau_hoi from Cau_hoi as a,bo_cau_hoi as b where a.id_bo_cau_hoi=b.id_bo_cau_hoi and b.id_de_thi=@id_de_thi) 
	 
	delete Cau_hoi where id_bo_cau_hoi in 
		(select b.id_bo_cau_hoi from bo_cau_hoi as b where b.id_de_thi=@id_de_thi) 

	delete bo_cau_hoi where id_de_thi=@id_de_thi
	delete de_thi where id_de_thi=@id_de_thi
end
 
-----------------------------------------Review Test-------------------------------------------------
go
create proc getTestInfoById 
	@id_de int
as
begin
	select * from de_thi as a,khung_de_thi as b ,mon as c
	where a.id_khung_de=b.id_khung_de
	and b.id_mon=c.id_mon
	and a.id_de_thi=@id_de
end

go
create proc getTestGroupContentByIdTest 
	@id_de int
as
begin
	select * from bo_cau_hoi where id_de_thi=@id_de
end

go
create proc getListQuestionByIdGroupTest  
	@id_bo_cau_hoi int
as
begin
	select * from Cau_hoi where id_bo_cau_hoi=@id_bo_cau_hoi
end

go
create proc getListOptionByIdQuestion
	@id_cau_hoi int
as
begin
	select * from lua_chon where id_cau_hoi=@id_cau_hoi
end

-----------------------------------Danh Sách Học Phần---------------------------------------------

go
create proc kiemTraMonHocKhiNhapDsHp
	@id_mon int
as
begin
	declare @result bit
	declare @c int
	select @c=count(*) from mon where id_mon = @id_mon
	if @c >0
		set @result=1--hop le
	else
		set @result=0

	select @result
end

go
create proc kiemTraSvKhiNhapDsHp -- hop le la: k co mssv trong dshp hoac co ma da thi r
	@mssv Nvarchar(20),
	@id_mon int
as
begin
	declare @result bit
	declare @c int
	select @c=count(*) from sinh_vien as a, Thong_tin_hoc_phan as b
				where a.mssv = @mssv and a.mssv=b.mssv and b.id_mon=@id_mon
				and a.mssv in (select a.mssv from sinh_vien as a, Thong_tin_hoc_phan as b where a.mssv=b.mssv and b.id_mon=@id_mon and b.da_thi=0 or co_phieu_du_thi=0)
				
	declare @d int
	select @d=count(*) from sinh_vien as a where a.mssv like @mssv  
	if( @c >0 or @d=0)
		set @result=0 --k hop le
	else
		set @result=1

	select @result 
end

go
create proc themDsHp  
	@id_mon int,
	@mssv Nvarchar(20),
	@nhomhp int
as
begin
	insert into Thong_tin_hoc_phan values(@id_mon,@mssv,@nhomhp,0,0)
end

go
create proc layDsHocPhanBangIdMon 
	@id_mon int
as
begin
	select * from sinh_vien as a, Thong_tin_hoc_phan as b, mon as c
	where a.mssv=b.mssv and c.id_mon=b.id_mon and b.id_mon=@id_mon
end
-----------------------------------Tổ thi------------------------------

go
create proc laySoLuongThiSinhTheoTo
	@id_to_thi int
as
begin
	select count(*) from phieu_du_thi where id_to_thi=@id_to_thi
end

go
create proc layDanhSachToThiBangIdMon
	@id_mon int
as
begin
	select distinct a.id_to_thi, a.ten_to_thi,b.id_phong_thi,b.ten_phong_thi,a.ngay_thi,b.so_luong_may
	from to_thi as a,phong_thi as b,phieu_du_thi as c
	where a.id_to_thi=c.id_to_thi and b.id_phong_thi=c.id_phong_thi  and
	c.id_mon=@id_mon
end 
----------------------------------------Phòng thi--------------------------------------------------------

go
create proc UpdatePhongThi 
	@id_p int,
	@ten_p Nvarchar(20),
	@so_may int
as
begin
	update phong_thi set
		ten_phong_thi=@ten_p,so_luong_may= @so_may where id_phong_thi=@id_p
end 
 

----------------------------------------Thông tin tổ thi--------------------------------------------------------
go
create proc layThongTinToThiBangIdToThi 
	@id_to_thi int
as
begin
	select distinct sv.mssv,sv.ho_ten,m.id_mon,m.ten_mon,de.ma_de_thi,kd.thoi_luong_thi,tothi.id_to_thi,tothi.ten_to_thi
	from sinh_vien as sv,khung_de_thi as kd, de_thi as de, mon as m, phieu_du_thi as e, to_thi as tothi  
	where sv.mssv=e.mssv and 
	e.id_mon=m.id_mon and
	kd.id_khung_de=de.id_khung_de and
	de.id_de_thi=e.id_de_thi and 
	tothi.id_to_thi=e.id_to_thi and
	tothi.id_to_thi= @id_to_thi
end

-----------------------------------------Tổ chức thi------------------------------------------------------
go
create proc layDsMonCoDeThi
as
begin
	select m.id_mon,m.ten_mon, count(de.id_de_thi) as N'Số đề thi' from mon as m,khung_de_thi as k, de_thi as de
	where m.id_mon=k.id_mon and k.id_khung_de=de.id_khung_de 
	group by m.id_mon,m.ten_mon 
end

go
create proc layDsMonKhongCoDeThi
as
begin
	select a.id_mon ,a.ten_mon 
	from mon as a 
	where a.id_mon not in(select m.id_mon  
							from mon as m,khung_de_thi as k, de_thi as de 
							where m.id_mon=k.id_mon and k.id_khung_de=de.id_khung_de 
	group by m.id_mon,m.ten_mon 
	having count(de.id_de_thi)>0 )
end

go
create proc layDsHocPhanTheoIdMon 
	@id_mon int
as
begin
	select id_mon,mssv ,nhom_hoc_phan
	from Thong_tin_hoc_phan 
	where id_mon=@id_mon and mssv not in (select mssv from Thong_tin_hoc_phan where da_thi=1 or co_phieu_du_thi=1)
	order by nhom_hoc_phan asc
end

go
create proc layDsDeThiTheoIdMon 
	@id_mon int
as
begin
	select a.id_de_thi,b.id_mon 
	from de_thi as a,khung_de_thi as b 
	where a.id_khung_de=b.id_khung_de and b.id_mon=@id_mon 
end
 
---------------------------------------------Thi-------------------------------------------------------
go
create proc StudentLogin
	@mssv Nvarchar(20),
	@mat_khau Nvarchar(100)
as
begin
	declare @count int
	declare @result bit
	select @count = COUNT(*) from sinh_vien where mssv= @mssv and mat_khau like @mat_khau
	if @count >0
		set @result=1
	else
		set @result=0

	select @result
end

go
create proc demThongTinTrcKhiThiBangMssv  
	@mssv Nvarchar(20)
as
begin
	select distinct count(*)
	from phieu_du_thi as a,sinh_vien as b,de_thi as c,mon as d,to_thi as e,Thong_tin_hoc_phan as tt
	where a.mssv=b.mssv and a.id_de_thi=c.id_de_thi and a.id_mon=d.id_mon and a.id_to_thi=e.id_to_thi
	and tt.mssv=a.mssv and CONVERT(DATE, e.ngay_thi , 111)>=CONVERT(DATE, getdate(), 111) and CONVERT(DATE, e.ngay_thi , 111)<=CONVERT(DATE, getdate()+1, 111)
	and tt.da_thi=0 and tt.co_phieu_du_thi=1
	and a.mssv=@mssv
end


go
create proc layThongTinTrcKhiThiBangMssv  
	@mssv Nvarchar(20)
as
begin
	select distinct a.id_phieu_du_thi,a.id_mon,a.mssv,b.ho_ten,d.ten_mon,e.ngay_thi
	from phieu_du_thi as a,sinh_vien as b,de_thi as c,mon as d,to_thi as e,Thong_tin_hoc_phan as tt
	where a.mssv=b.mssv and a.id_de_thi=c.id_de_thi and a.id_mon=d.id_mon and a.id_to_thi=e.id_to_thi
	and tt.mssv=a.mssv and CONVERT(DATE, e.ngay_thi , 111)>=CONVERT(DATE, getdate(), 111) and CONVERT(DATE, e.ngay_thi , 111)<=CONVERT(DATE, getdate()+1, 111)
	and tt.da_thi=0 and tt.co_phieu_du_thi=1
	and a.mssv=@mssv
end

go
create proc layThongTinThiBangMssv   
	@mssv Nvarchar(20)
as
begin
	select distinct a.id_phieu_du_thi,a.id_mon, d.ten_mon,b.ho_ten,b.mssv,kd.thoi_luong_thi,e.ngay_thi,a.id_de_thi,c.ma_de_thi
	from phieu_du_thi as a,sinh_vien as b,khung_de_thi as kd ,de_thi as c,mon as d,to_thi as e
	where a.mssv=b.mssv and a.id_de_thi=c.id_de_thi and a.id_mon=d.id_mon and a.id_to_thi=e.id_to_thi
	and kd.id_khung_de=c.id_khung_de
	and a.mssv=@mssv
end

go
create proc layMaDeBangMssv 
	@mssv Nvarchar(20),
	@id_mon int
as 
begin 
	select distinct a.id_de_thi
	from phieu_du_thi as a, to_thi as b,Thong_tin_hoc_phan as c
	where a.id_to_thi=b.id_to_thi and a.mssv=c.mssv
	and CONVERT(DATE, b.ngay_thi , 111)>=CONVERT(DATE, getdate(), 111) and CONVERT(DATE, b.ngay_thi , 111)<=CONVERT(DATE, getdate()+1, 111)
	and b.trang_thai=0 and c.co_phieu_du_thi=1 and c.da_thi=0
	and a.mssv=@mssv and c.id_mon=@id_mon
end

go
create proc themBaiLam
	@id_phieu_du_thi int
as
begin
	insert into bai_lam values(GETDATE(),GETDATE()+1,@id_phieu_du_thi)
	select SCOPE_IDENTITY()
end

go
create proc them_kq
	@id_bai_lam int,
	@id_lc int
as
begin
	declare @r bit
	select @r= dung_hay_sai from lua_chon where id_lua_chon=@id_lc
	declare @d int
	if(@r=1)
		select @d=Cau_hoi.diem from  lua_chon,Cau_hoi where Cau_hoi.id_cau_hoi=lua_chon.id_cau_hoi and id_lua_chon=@id_lc
	else
		select @d=0
	insert into ket_qua values(@d,@id_lc,@id_bai_lam)
end

go
create proc checkcjd
	@id_bai_lm int,
	@id_lc_d int
as
begin
	select count(*)
	from ct_bai_lam where id_bai_lam=@id_bai_lm and id_lua_chon= @id_lc_d
end

go
create proc layDiem
	@id_bai_lm int
as
begin
	select sum(diem)
	from ket_qua as a 
	where a.id_bai_lam= @id_bai_lm
end
-----------------------------------------Ket qua thi-------------------------------------------------------
--go
--create proc a
--as
--begin
--insert into to_thi values(N'tổ 1',getdate(),0)
--insert into to_thi values(N'tổ 2',DATEADD("mi",45,getdate()),0)
--insert into to_thi values(N'tổ 3',getdate(),0)
--insert into to_thi values(N'tổ 4',getdate(),0)
--insert into to_thi values(N'tổ 5',getdate(),0)
--insert into phieu_du_thi values(0,0,1,1,1,1,N'19111')
--insert into phieu_du_thi values(0,0,1,1,2,1,N'19112')
--insert into phieu_du_thi values(0,0,1,1,1,1,N'19113')
--insert into phieu_du_thi values(0,0,1,1,2,1,N'19114')
--insert into phieu_du_thi values(0,0,1,1,1,1,N'19115')
--insert into phieu_du_thi values(0,0,1,1,2,1,N'19116')
--insert into phieu_du_thi values(0,0,1,1,1,1,N'19117')
--insert into phieu_du_thi values(0,0,1,1,2,1,N'19118')
--insert into phieu_du_thi values(0,0,1,1,1,1,N'19119')

--insert into phieu_du_thi values(0,0,2,2,2,2,N'19111')
--insert into phieu_du_thi values(0,0,2,2,1,2,N'19112')
--insert into phieu_du_thi values(0,0,2,2,3,2,N'19125')
--insert into phieu_du_thi values(0,0,2,2,2,2,N'19121')
--insert into phieu_du_thi values(0,0,2,2,1,2,N'19122')
--insert into phieu_du_thi values(0,0,2,2,3,2,N'19123')
--insert into phieu_du_thi values(0,0,2,2,2,2,N'19124') 
 
--update Thong_tin_hoc_phan set co_phieu_du_thi=1
--end
  
