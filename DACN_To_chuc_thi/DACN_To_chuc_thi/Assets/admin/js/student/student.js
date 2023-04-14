$(document).ready(function () {
    loadData();
});

var ms = '';

const formats = ["d", "D", "f", "F", "g", "G", "m", "o", "r", "s", "t", "T", "u", "U", "Y"];
var culture =  CultureInfo.GetCultureInfo("de-DE")  ;
//Load Data function
function loadData() {
    $.ajax({
        url: "/Student/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
             
            $.each(result, function (key, item) {  
                html += '<tr>';
                html += '<td>' + item.mssv + '</td>';
                html += '<td>' + item.ho_ten + '</td>';
                html += '<td>' + item.lop + '</td>';
                html += '<td>' + item.ns + '</td>';
                html += '<td>' + (item.gioi_tinh == true?"Nam":"Nữ") + '</td>';
                html += '<td class="table-edit-btn-column"><a  onclick="openPopUp(); return getbyID(' + item.mssv + ');"> <svg id="icon-edit" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 icon"> <path stroke-linecap="round" stroke-linejoin="round" d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10" /> </svg>  </a></td > ';
                html += '<td class="table-delete-btn-column"><a  onclick="Delele(' + item.mssv + ');" > <svg id="icon-delete" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 icon"> <path stroke-linecap="round" stroke-linejoin="round" d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" /> </svg> </a></td > ';
                html += '</tr>';
            }); 
            if(jQuery.isEmptyObject(result)==false) {
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
            alert("Gặp lỗi khi tải dữ liệu");
        }
    });
}  
// get by id
function getbyID(id) {  
    ms = id;
    $.ajax({
        url: "/Student/getbyID/" + id, 
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) { 
            $('#ho_ten').val(result.ho_ten);
            $('#lop').val(result.lop);
            $('#ngay_sinh').val( result.ns );
            $('#gioi_tinh').val((result.gioi_tinh == true ? "Nam" : "Nữ"));
             
        },
        error: function () {
            alert("Gặp lỗi Khi lấy mssv: " + id);
        }
    });
    return false;
} 
//Update 
function Update() {
    var sex = 0;
    sex=$('#gioi_tinh').val() == "Nam" ? 1 : 0;
    var  Obj = {
        mssv: ms,
        ho_ten: $('#ho_ten').val(), 
        ngay_sinh: $('#ngay_sinh').val(),
        gioi_tinh: sex,
        lop: $('#lop').val(),
        mat_khau:1,
        tinh_trang:1,
    };
    $.ajax({
        url: "/Student/Update",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function () {
            loadData();
            $('#popup-add-container').removeClass('show-popup');
        },
        error: function () {
            alert("Gặp lỗi j rồi");
        }
    });
}

//Delete
function Delele(mssv) {
    var ans = confirm("Xóa ?");
    if (ans) {
        $.ajax({
            url: "/Student/Delete/" + mssv, 
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function () {
                loadData();
            },
            error: function () {
                alert("Gặp lỗi j rồi");
            }
        });
    } 
} 