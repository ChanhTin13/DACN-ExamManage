  
//Load Data function
function LoadSelectSubject() {
    $.ajax({
        url: "/FrameTest/LoadSelectSubject",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) { 
                html += ' <option value="' + item.id_mon + '">' + item.ten_mon +'</option>'; 
            });
            if (jQuery.isEmptyObject(result) == false) {
                $('select#mon_thi').html(html);
            }
        },
        error: function () {
            alert("Gặp khi tai ds mon");
        }
    });
}