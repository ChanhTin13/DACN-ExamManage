$(document).ready(function () { 
});


function layThongTinThi() {
    $.ajax({
        url: "/Thi/ThongTinThi",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("#ten_mon_thi").html(result.ten_mon);

            $("#hoten").html(result.ho_ten);
            $("#mssv").html(result.mssv);
            $("#thoi_gian").html(result.thoi_luong_thi);
            $("#ngay_thi").html(result.ngay_thi_str);
            $("#gio_bd").html(result.gio_bd);
            $("#gio_kt").html(result.gio_kt);
            $("#ma_de_thi").html(result.ma_de_thi);
            $("#so_cau").html(result.so_cau);

        },
        error: function () {
            alert("Loi lay thong tin thi");
        }
    });
}