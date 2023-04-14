
$(document).ready(function () {
    LoadSelectSubject(); 
    var so = -1;
    loadData(so);
});

var id_mon;
function changeOption() {
    id_mon = document.getElementById("subject-select").value; 
    loadData(id_mon); 
}
//Load Data function
function loadData(id) {
    $.ajax({
        url: "/DsHocPhan/List/"+id,
        type: "get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.mssv + '</td>';
                html += '<td>' + item.ho_ten + '</td>';
                html += '<td>' + (item.gioi_tinh == true ? "Nam" : "Nữ" )+ '</td>';
                html += '<td>' + item.lop + '</td>';
                html += '<td>' + item.nhom_hoc_phan + '</td>';
                html += '<td>' + (item.da_thi == true ? "Đã thi" : "Chưa thi") + '</td>';
                html += '<td>' + (item.co_phieu_du_thi == true ? "Đã có" : "Chưa") + '</td>';
                html += '</tr>';
            });
            if (jQuery.isEmptyObject(result) == false) {
                $('tbody').html(html);
            }
            else {
                html = '';
                html += '<tr>';
                html += '<td colspan="7" style="text-align: center;font-weight: bold;">Không có dữ liệu</td>';
                html += '</tr>'; 
                $('tbody').html(html);
            }
            $('#so_luong_kq').html(Object.keys(result).length);
        },
        error: function () {
            alert("Gặp lỗi khi tai du lieu");
        }
    });
}
 

function LoadSelectSubject() {
    $.ajax({
        url: "/DsHocPhan/LoadSelectSubject",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += ' <option value="' + item.id_mon + '">' + item.ten_mon + '</option>';
            });
            if (jQuery.isEmptyObject(result) == false) {
                $('select#subject-select').html(html);
            }
        },
        error: function () {
            alert("Gặp khi tai ds mon");
        }
    });
}