

$(document).ready(function () {
    LoadSelectSubject();
    //var so = -1;
    //loadData(so);
});

var id_mon;
function changeOption() {
    id_mon = document.getElementById("subject-select").value;
    //loadData(id_mon);
}
function LoadSelectSubject() {
    $.ajax({
        url: "/ExamResult/LoadSelectSubject",
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