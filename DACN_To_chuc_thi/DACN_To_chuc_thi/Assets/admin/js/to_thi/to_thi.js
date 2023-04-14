
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
        url: "/ToThi/List/" + id,
        type: "get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ten_to_thi + '</td>';
                html += '<td>' + item.so_thi_sinh + '</td>';
                html += '<td>' +  item.ten_phong + '</td>';
                html += '<td>' + item.so_ghe + '</td>';
                html += '<td>' + item.ngay_thi_str + '</td>';
                html += '<td class="table-delete-btn-column"><a href="/Admin/thong_tin_to_thi/Index/?id=' + item.id_to_thi +'" > <svg id="icon-delete" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 icon"> <path stroke-linecap="round" stroke-linejoin="round" d="M8.25 6.75h12M8.25 12h12m-12 5.25h12M3.75 6.75h.007v.008H3.75V6.75zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0zM3.75 12h.007v.008H3.75V12zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0zm-.375 5.25h.007v.008H3.75v-.008zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z" /> </svg> </a></td > ';
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
        url: "/ToThi/LoadSelectSubject",
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