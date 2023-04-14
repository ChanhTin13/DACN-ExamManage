$(document).ready(function () {
    layThongTinThi();

    layDsCauHoi();
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


var list_ch = [];
let list_lc = "";
function layDsCauHoi() { 
    $.ajax({
        url: "/Thi/layListIdCauHoi/",
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                list_ch.push(item);
            }); 
        },
        error: function () {
            alert("Gặp lỗi Khi lấy ds cau hoi");
        }
    }); 
    
}

function LayDsLuaChon() {  
    list_lc = "";
    for(var i = 1; i <= list_ch.length; i++) { 
        var x = 0;
        var selected = $("input[type='radio'][name='" + list_ch[i] + "']:checked");
        if (selected.length > 0) { 
            x = selected.attr('id');
            list_lc +=   x.toString() + "_";
        }
    } 
}

function ChamThi() { 
    LayDsLuaChon();

    var Obj = {
        id: 1,
        nd: list_lc,
    }
    $.ajax({
        url: "/Thi/ChamThi",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { 
            //list_lc = " "; 
        },
        error: function (e) {
            //alert(e.responseText);
            //console.log(list_lc)
        }
    });
}
