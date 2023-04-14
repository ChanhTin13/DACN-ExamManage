﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DACN_To_chuc_thi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DACN_To_Chuc_ThiEntities : DbContext
    {
        public DACN_To_Chuc_ThiEntities()
            : base("name=DACN_To_Chuc_ThiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bai_lam> bai_lam { get; set; }
        public virtual DbSet<bo_cau_hoi> bo_cau_hoi { get; set; }
        public virtual DbSet<Cau_hoi> Cau_hoi { get; set; }
        public virtual DbSet<ct_bai_lam> ct_bai_lam { get; set; }
        public virtual DbSet<de_thi> de_thi { get; set; }
        public virtual DbSet<ket_qua> ket_qua { get; set; }
        public virtual DbSet<khung_de_thi> khung_de_thi { get; set; }
        public virtual DbSet<lua_chon> lua_chon { get; set; }
        public virtual DbSet<Nguoi_dung> Nguoi_dung { get; set; }
        public virtual DbSet<phieu_du_thi> phieu_du_thi { get; set; }
        public virtual DbSet<phong_thi> phong_thi { get; set; }
        public virtual DbSet<sinh_vien> sinh_vien { get; set; }
        public virtual DbSet<Thong_tin_hoc_phan> Thong_tin_hoc_phan { get; set; }
        public virtual DbSet<to_thi> to_thi { get; set; }
        public virtual DbSet<mon> mons { get; set; }
    
        public virtual ObjectResult<Nullable<bool>> Account_Login(string email, string mat_khau)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var mat_khauParameter = mat_khau != null ?
                new ObjectParameter("mat_khau", mat_khau) :
                new ObjectParameter("mat_khau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("Account_Login", emailParameter, mat_khauParameter);
        }
    
        public virtual int AddFrameTest(string ten_khung_de, Nullable<int> thoi_luong_thi, Nullable<int> id_mon)
        {
            var ten_khung_deParameter = ten_khung_de != null ?
                new ObjectParameter("ten_khung_de", ten_khung_de) :
                new ObjectParameter("ten_khung_de", typeof(string));
    
            var thoi_luong_thiParameter = thoi_luong_thi.HasValue ?
                new ObjectParameter("thoi_luong_thi", thoi_luong_thi) :
                new ObjectParameter("thoi_luong_thi", typeof(int));
    
            var id_monParameter = id_mon.HasValue ?
                new ObjectParameter("id_mon", id_mon) :
                new ObjectParameter("id_mon", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddFrameTest", ten_khung_deParameter, thoi_luong_thiParameter, id_monParameter);
        }
    
        public virtual int deleteStuById(string mssv)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteStuById", mssvParameter);
        }
    
        public virtual int deleteTestById(Nullable<int> id_de_thi)
        {
            var id_de_thiParameter = id_de_thi.HasValue ?
                new ObjectParameter("id_de_thi", id_de_thi) :
                new ObjectParameter("id_de_thi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteTestById", id_de_thiParameter);
        }
    
        public virtual ObjectResult<get_all_subject_Result> get_all_subject()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_all_subject_Result>("get_all_subject");
        }
    
        public virtual ObjectResult<get_student_by_pagination_Result> get_student_by_pagination(Nullable<int> page_number, Nullable<int> show_number)
        {
            var page_numberParameter = page_number.HasValue ?
                new ObjectParameter("page_number", page_number) :
                new ObjectParameter("page_number", typeof(int));
    
            var show_numberParameter = show_number.HasValue ?
                new ObjectParameter("show_number", show_number) :
                new ObjectParameter("show_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_student_by_pagination_Result>("get_student_by_pagination", page_numberParameter, show_numberParameter);
        }
    
        public virtual ObjectResult<get_subject_by_pagination_Result> get_subject_by_pagination(Nullable<int> page_number, Nullable<int> show_number)
        {
            var page_numberParameter = page_number.HasValue ?
                new ObjectParameter("page_number", page_number) :
                new ObjectParameter("page_number", typeof(int));
    
            var show_numberParameter = show_number.HasValue ?
                new ObjectParameter("show_number", show_number) :
                new ObjectParameter("show_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_subject_by_pagination_Result>("get_subject_by_pagination", page_numberParameter, show_numberParameter);
        }
    
        public virtual ObjectResult<getAllTestByIdFrame_Result> getAllTestByIdFrame(Nullable<int> id_khung)
        {
            var id_khungParameter = id_khung.HasValue ?
                new ObjectParameter("id_khung", id_khung) :
                new ObjectParameter("id_khung", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllTestByIdFrame_Result>("getAllTestByIdFrame", id_khungParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getAmountQuestion(Nullable<int> id_de)
        {
            var id_deParameter = id_de.HasValue ?
                new ObjectParameter("id_de", id_de) :
                new ObjectParameter("id_de", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getAmountQuestion", id_deParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getAmountTestById(Nullable<int> id_khung_de)
        {
            var id_khung_deParameter = id_khung_de.HasValue ?
                new ObjectParameter("id_khung_de", id_khung_de) :
                new ObjectParameter("id_khung_de", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getAmountTestById", id_khung_deParameter);
        }
    
        public virtual ObjectResult<getListOptionByIdQuestion_Result> getListOptionByIdQuestion(Nullable<int> id_cau_hoi)
        {
            var id_cau_hoiParameter = id_cau_hoi.HasValue ?
                new ObjectParameter("id_cau_hoi", id_cau_hoi) :
                new ObjectParameter("id_cau_hoi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getListOptionByIdQuestion_Result>("getListOptionByIdQuestion", id_cau_hoiParameter);
        }
    
        public virtual ObjectResult<getListQuestionByIdGroupTest_Result> getListQuestionByIdGroupTest(Nullable<int> id_bo_cau_hoi)
        {
            var id_bo_cau_hoiParameter = id_bo_cau_hoi.HasValue ?
                new ObjectParameter("id_bo_cau_hoi", id_bo_cau_hoi) :
                new ObjectParameter("id_bo_cau_hoi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getListQuestionByIdGroupTest_Result>("getListQuestionByIdGroupTest", id_bo_cau_hoiParameter);
        }
    
        public virtual ObjectResult<string> getSubjectName(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getSubjectName", idParameter);
        }
    
        public virtual ObjectResult<getTestGroupContentByIdTest_Result> getTestGroupContentByIdTest(Nullable<int> id_de)
        {
            var id_deParameter = id_de.HasValue ?
                new ObjectParameter("id_de", id_de) :
                new ObjectParameter("id_de", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTestGroupContentByIdTest_Result>("getTestGroupContentByIdTest", id_deParameter);
        }
    
        public virtual ObjectResult<getTestInfoById_Result> getTestInfoById(Nullable<int> id_de)
        {
            var id_deParameter = id_de.HasValue ?
                new ObjectParameter("id_de", id_de) :
                new ObjectParameter("id_de", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTestInfoById_Result>("getTestInfoById", id_deParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> isExistedStudent(string mssv)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("isExistedStudent", mssvParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> isTestDeletable(Nullable<int> id_de_thi)
        {
            var id_de_thiParameter = id_de_thi.HasValue ?
                new ObjectParameter("id_de_thi", id_de_thi) :
                new ObjectParameter("id_de_thi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("isTestDeletable", id_de_thiParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> kiemTraMonHocKhiNhapDsHp(Nullable<int> id_mon)
        {
            var id_monParameter = id_mon.HasValue ?
                new ObjectParameter("id_mon", id_mon) :
                new ObjectParameter("id_mon", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("kiemTraMonHocKhiNhapDsHp", id_monParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> kiemTraSvKhiNhapDsHp(string mssv, Nullable<int> id_mon)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            var id_monParameter = id_mon.HasValue ?
                new ObjectParameter("id_mon", id_mon) :
                new ObjectParameter("id_mon", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("kiemTraSvKhiNhapDsHp", mssvParameter, id_monParameter);
        }
    
        public virtual ObjectResult<stuGetById_Result> stuGetById(string mssv)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<stuGetById_Result>("stuGetById", mssvParameter);
        }
    
        public virtual int them_mon(string ten_mon, Nullable<int> stc)
        {
            var ten_monParameter = ten_mon != null ?
                new ObjectParameter("ten_mon", ten_mon) :
                new ObjectParameter("ten_mon", typeof(string));
    
            var stcParameter = stc.HasValue ?
                new ObjectParameter("stc", stc) :
                new ObjectParameter("stc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("them_mon", ten_monParameter, stcParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> themBoCauHoi(string ten_bo_cau_hoi, Nullable<int> id_de_thi)
        {
            var ten_bo_cau_hoiParameter = ten_bo_cau_hoi != null ?
                new ObjectParameter("ten_bo_cau_hoi", ten_bo_cau_hoi) :
                new ObjectParameter("ten_bo_cau_hoi", typeof(string));
    
            var id_de_thiParameter = id_de_thi.HasValue ?
                new ObjectParameter("id_de_thi", id_de_thi) :
                new ObjectParameter("id_de_thi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("themBoCauHoi", ten_bo_cau_hoiParameter, id_de_thiParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> themCauHoi(string noi_dung, Nullable<double> diem, Nullable<int> id_bo_cau_hoi)
        {
            var noi_dungParameter = noi_dung != null ?
                new ObjectParameter("noi_dung", noi_dung) :
                new ObjectParameter("noi_dung", typeof(string));
    
            var diemParameter = diem.HasValue ?
                new ObjectParameter("diem", diem) :
                new ObjectParameter("diem", typeof(double));
    
            var id_bo_cau_hoiParameter = id_bo_cau_hoi.HasValue ?
                new ObjectParameter("id_bo_cau_hoi", id_bo_cau_hoi) :
                new ObjectParameter("id_bo_cau_hoi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("themCauHoi", noi_dungParameter, diemParameter, id_bo_cau_hoiParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> themDeThi(string ma_de_thi, Nullable<int> id_khung_de)
        {
            var ma_de_thiParameter = ma_de_thi != null ?
                new ObjectParameter("ma_de_thi", ma_de_thi) :
                new ObjectParameter("ma_de_thi", typeof(string));
    
            var id_khung_deParameter = id_khung_de.HasValue ?
                new ObjectParameter("id_khung_de", id_khung_de) :
                new ObjectParameter("id_khung_de", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("themDeThi", ma_de_thiParameter, id_khung_deParameter);
        }
    
        public virtual int themDsHp(Nullable<int> id_mon, string mssv, Nullable<int> nhomhp)
        {
            var id_monParameter = id_mon.HasValue ?
                new ObjectParameter("id_mon", id_mon) :
                new ObjectParameter("id_mon", typeof(int));
    
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            var nhomhpParameter = nhomhp.HasValue ?
                new ObjectParameter("nhomhp", nhomhp) :
                new ObjectParameter("nhomhp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themDsHp", id_monParameter, mssvParameter, nhomhpParameter);
        }
    
        public virtual int themLuaChon(string noi_dung, Nullable<bool> dung_hay_sai, Nullable<int> id_cau_hoi)
        {
            var noi_dungParameter = noi_dung != null ?
                new ObjectParameter("noi_dung", noi_dung) :
                new ObjectParameter("noi_dung", typeof(string));
    
            var dung_hay_saiParameter = dung_hay_sai.HasValue ?
                new ObjectParameter("dung_hay_sai", dung_hay_sai) :
                new ObjectParameter("dung_hay_sai", typeof(bool));
    
            var id_cau_hoiParameter = id_cau_hoi.HasValue ?
                new ObjectParameter("id_cau_hoi", id_cau_hoi) :
                new ObjectParameter("id_cau_hoi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themLuaChon", noi_dungParameter, dung_hay_saiParameter, id_cau_hoiParameter);
        }
    
        public virtual int themSV(string mssv, string ho_ten, Nullable<System.DateTime> ngay_sinh, Nullable<bool> gioi_tinh, string lop)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            var ho_tenParameter = ho_ten != null ?
                new ObjectParameter("ho_ten", ho_ten) :
                new ObjectParameter("ho_ten", typeof(string));
    
            var ngay_sinhParameter = ngay_sinh.HasValue ?
                new ObjectParameter("ngay_sinh", ngay_sinh) :
                new ObjectParameter("ngay_sinh", typeof(System.DateTime));
    
            var gioi_tinhParameter = gioi_tinh.HasValue ?
                new ObjectParameter("gioi_tinh", gioi_tinh) :
                new ObjectParameter("gioi_tinh", typeof(bool));
    
            var lopParameter = lop != null ?
                new ObjectParameter("lop", lop) :
                new ObjectParameter("lop", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("themSV", mssvParameter, ho_tenParameter, ngay_sinhParameter, gioi_tinhParameter, lopParameter);
        }
    
        public virtual int UpdateFrameTest(Nullable<int> id_khung, string ten_khung_de, Nullable<int> thoi_luong_thi, Nullable<int> id_mon)
        {
            var id_khungParameter = id_khung.HasValue ?
                new ObjectParameter("id_khung", id_khung) :
                new ObjectParameter("id_khung", typeof(int));
    
            var ten_khung_deParameter = ten_khung_de != null ?
                new ObjectParameter("ten_khung_de", ten_khung_de) :
                new ObjectParameter("ten_khung_de", typeof(string));
    
            var thoi_luong_thiParameter = thoi_luong_thi.HasValue ?
                new ObjectParameter("thoi_luong_thi", thoi_luong_thi) :
                new ObjectParameter("thoi_luong_thi", typeof(int));
    
            var id_monParameter = id_mon.HasValue ?
                new ObjectParameter("id_mon", id_mon) :
                new ObjectParameter("id_mon", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateFrameTest", id_khungParameter, ten_khung_deParameter, thoi_luong_thiParameter, id_monParameter);
        }
    
        public virtual int UpdateStudent(string mssv, string ho_ten, Nullable<System.DateTime> ngay_sinh, Nullable<bool> gioi_tinh, string lop)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            var ho_tenParameter = ho_ten != null ?
                new ObjectParameter("ho_ten", ho_ten) :
                new ObjectParameter("ho_ten", typeof(string));
    
            var ngay_sinhParameter = ngay_sinh.HasValue ?
                new ObjectParameter("ngay_sinh", ngay_sinh) :
                new ObjectParameter("ngay_sinh", typeof(System.DateTime));
    
            var gioi_tinhParameter = gioi_tinh.HasValue ?
                new ObjectParameter("gioi_tinh", gioi_tinh) :
                new ObjectParameter("gioi_tinh", typeof(bool));
    
            var lopParameter = lop != null ?
                new ObjectParameter("lop", lop) :
                new ObjectParameter("lop", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateStudent", mssvParameter, ho_tenParameter, ngay_sinhParameter, gioi_tinhParameter, lopParameter);
        }
    
        public virtual int UpdateSubject(Nullable<int> id, string ten_mon, Nullable<int> stc)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var ten_monParameter = ten_mon != null ?
                new ObjectParameter("ten_mon", ten_mon) :
                new ObjectParameter("ten_mon", typeof(string));
    
            var stcParameter = stc.HasValue ?
                new ObjectParameter("stc", stc) :
                new ObjectParameter("stc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateSubject", idParameter, ten_monParameter, stcParameter);
        }
    
        public virtual ObjectResult<layThongTinTrcKhiThiBangMssv_Result> layThongTinTrcKhiThiBangMssv(string mssv)
        {
            var mssvParameter = mssv != null ?
                new ObjectParameter("mssv", mssv) :
                new ObjectParameter("mssv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<layThongTinTrcKhiThiBangMssv_Result>("layThongTinTrcKhiThiBangMssv", mssvParameter);
        }
    }
}
