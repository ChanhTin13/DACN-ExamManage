/*
Created		9/29/2022
Modified		11/26/2022
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2000 
*/

USE MASTER
GO
IF EXISTS (SELECT NAME FROM SYS.DATABASES WHERE NAME= N'DACN_To_Chuc_Thi')
DROP DATABASE DACN_To_Chuc_Thi

GO 
create database DACN_To_Chuc_Thi
go
use DACN_To_Chuc_Thi
 
go
Create table [to_thi]
(
	[id_to_thi] Integer Identity NOT NULL,
	[ten_to_thi] Nvarchar(30) NOT NULL, UNIQUE ([ten_to_thi]),
	[ngay_thi] Datetime NOT NULL,
	trang_thai bit,
Primary Key ([id_to_thi])
) 

go
Create table [mon]
(
	[id_mon] Integer Identity NOT NULL,
	[ten_mon] Nvarchar(50) NOT NULL, UNIQUE ([ten_mon]),
	[stc] Integer NOT NULL,
Primary Key ([id_mon])
) 
go

Create table [Nguoi_dung]
(
	[id_nguoi_dung] Integer Identity NOT NULL,
	[ho_ten] Nvarchar(50) NOT NULL,
	[ngay_sinh] Datetime NOT NULL,
	[ngay_vao_lam] Datetime NOT NULL,
	[gioi_tinh] Bit NOT NULL,
	[email] Nvarchar(30) NOT NULL,
	[mat_khau] Nvarchar(200) NOT NULL,
	[tinh_trang] Bit NOT NULL,
	[sdt] Nvarchar(15) NOT NULL,
	[cmnd] Nvarchar(30) NOT NULL,
Primary Key ([id_nguoi_dung])
) 
go

Create table [Cau_hoi]
(
	[id_cau_hoi] Integer Identity NOT NULL,
	[noi_dung] Nvarchar(500) NOT NULL,
	[diem] Float NOT NULL,
	[id_bo_cau_hoi] Integer NOT NULL,
Primary Key ([id_cau_hoi])
) 
go

Create table [ket_qua]
(
	[id_ket_qua] Integer Identity NOT NULL,
	[diem] Integer NOT NULL,
	[id_lua_chon] Integer NOT NULL,
	[id_bai_lam] Integer NOT NULL,
Primary Key ([id_ket_qua])
) 
go

Create table [bai_lam]
(
	[id_bai_lam] Integer Identity NOT NULL,
	[gio_lam] Datetime NOT NULL,
	[gio_nop] Datetime NOT NULL,
	[id_phieu_du_thi] Integer NOT NULL,
Primary Key ([id_bai_lam])
) 
go

Create table [phong_thi]
(
	[id_phong_thi] Integer Identity NOT NULL,
	[ten_phong_thi] Nvarchar(20) NOT NULL,
	[so_luong_may] Integer NOT NULL,
Primary Key ([id_phong_thi])
) 
go

Create table [phieu_du_thi]
(
	[id_phieu_du_thi] Integer Identity NOT NULL,
	[het_gio] Bit NOT NULL,
	[da_thi] Bit NOT NULL,
	[id_phong_thi] Integer NOT NULL,
	[id_to_thi] Integer NOT NULL,
	[id_de_thi] Integer NOT NULL,
	[id_mon] Integer NOT NULL,
	[mssv] Nvarchar(20) NOT NULL,
Primary Key ([id_phieu_du_thi])
) 
go

Create table [sinh_vien]
(
	[mssv] Nvarchar(20) NOT NULL, UNIQUE ([mssv]),
	[ho_ten] Nvarchar(30) NOT NULL,
	[ngay_sinh] Datetime NOT NULL,
	[gioi_tinh] Bit NOT NULL,
	[lop] Nvarchar(15) NOT NULL,
	[mat_khau] Nvarchar(100) NOT NULL,
	[tinh_trang] Bit NOT NULL,
Primary Key ([mssv])
) 
go

Create table [lua_chon]
(
	[id_lua_chon] Integer Identity NOT NULL,
	[noi_dung] Nvarchar(100) NOT NULL,
	[dung_hay_sai] Bit NOT NULL,
	[id_cau_hoi] Integer NOT NULL,
Primary Key ([id_lua_chon])
) 
go

Create table [de_thi]
(
	[id_de_thi] Integer Identity NOT NULL,
	[ma_de_thi] Nvarchar(10) NOT NULL,
	[ngay_tao] Datetime NOT NULL,
	[id_khung_de] Integer NOT NULL,
Primary Key ([id_de_thi])
) 
go

Create table [ct_bai_lam]
(
	[id_bai_lam] Integer NOT NULL,
	[id_lua_chon] Integer NOT NULL,
Primary Key ([id_bai_lam],[id_lua_chon])
) 
go

Create table [Thong_tin_hoc_phan]
(
	[id_mon] Integer NOT NULL,
	[mssv] Nvarchar(20) NOT NULL,
	[nhom_hoc_phan] Integer NOT NULL,
	[co_phieu_du_thi] Bit NOT NULL,
	[da_thi] Bit NOT NULL,
Primary Key ([id_mon],[mssv])
) 
go

Create table [khung_de_thi]
(
	[id_khung_de] Integer Identity NOT NULL,
	[ten_khung_de] Nvarchar(50) NOT NULL,
	[thoi_luong_thi] Integer NOT NULL,
	[ngay_tao] Datetime NOT NULL,
	[id_nguoi_dung] Integer NOT NULL,
	[id_mon] Integer NOT NULL,
Primary Key ([id_khung_de])
) 
go

Create table [bo_cau_hoi]
(
	[id_bo_cau_hoi] Integer Identity NOT NULL,
	[ten_bo_cau_hoi] Nvarchar(100) NOT NULL,
	[id_de_thi] Integer NOT NULL,
Primary Key ([id_bo_cau_hoi])
) 
go


Alter table [phieu_du_thi] add  foreign key([id_to_thi]) references [to_thi] ([id_to_thi])  on update no action on delete no action 
go
Alter table [Thong_tin_hoc_phan] add  foreign key([id_mon]) references [mon] ([id_mon])  on update no action on delete no action 
go
Alter table [khung_de_thi] add  foreign key([id_mon]) references [mon] ([id_mon])  on update no action on delete no action 
go
Alter table [khung_de_thi] add  foreign key([id_nguoi_dung]) references [Nguoi_dung] ([id_nguoi_dung])  on update no action on delete no action 
go
Alter table [lua_chon] add  foreign key([id_cau_hoi]) references [Cau_hoi] ([id_cau_hoi])  on update no action on delete no action 
go
Alter table [ct_bai_lam] add  foreign key([id_bai_lam]) references [bai_lam] ([id_bai_lam])  on update no action on delete no action 
go
Alter table [phieu_du_thi] add  foreign key([id_phong_thi]) references [phong_thi] ([id_phong_thi])  on update no action on delete no action 
go
Alter table [bai_lam] add  foreign key([id_phieu_du_thi]) references [phieu_du_thi] ([id_phieu_du_thi])  on update no action on delete no action 
go
Alter table [Thong_tin_hoc_phan] add  foreign key([mssv]) references [sinh_vien] ([mssv])  on update no action on delete no action 
go
Alter table [ct_bai_lam] add  foreign key([id_lua_chon]) references [lua_chon] ([id_lua_chon])  on update no action on delete no action 
go
Alter table [phieu_du_thi] add  foreign key([id_de_thi]) references [de_thi] ([id_de_thi])  on update no action on delete no action 
go
Alter table [bo_cau_hoi] add  foreign key([id_de_thi]) references [de_thi] ([id_de_thi])  on update no action on delete no action 
go
Alter table [ket_qua] add  foreign key([id_bai_lam],[id_lua_chon]) references [ct_bai_lam] ([id_bai_lam],[id_lua_chon])  on update no action on delete no action 
go
Alter table [phieu_du_thi] add  foreign key([id_mon],[mssv]) references [Thong_tin_hoc_phan] ([id_mon],[mssv])  on update no action on delete no action 
go
Alter table [de_thi] add  foreign key([id_khung_de]) references [khung_de_thi] ([id_khung_de])  on update no action on delete no action 
go
Alter table [Cau_hoi] add  foreign key([id_bo_cau_hoi]) references [bo_cau_hoi] ([id_bo_cau_hoi])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */


