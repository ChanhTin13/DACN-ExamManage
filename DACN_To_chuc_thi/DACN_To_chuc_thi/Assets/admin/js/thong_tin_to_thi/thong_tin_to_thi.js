
$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "/thong_tin_to_thi/List" ,
        type: "get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.mssv + '</td>';
                html += '<td>' + item.ho_ten + '</td>';
                html += '<td>' + item.ten_mon + '</td>';
                html += '<td>' + item.ma_de + '</td>';
                html += '<td>' + item.thoi_luong_thi + '</td>';
                html += '</tr>';
            });
            if (jQuery.isEmptyObject(result) == false) {
                $('tbody').html(html);
            }
            else {
                html = '';
                html += '<tr>';
                html += '<td colspan="5" style="text-align: center;font-weight: bold;">Không có dữ liệu</td>';
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
 