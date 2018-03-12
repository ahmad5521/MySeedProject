/// <reference path="jquery-2.1.0.intellisense.js" />
//Load Data in Table when documents is ready
var counter = 0;

$(document).ready(function () {    
    loadData();  
    $("#search").on("keyup", function () {
        var as = $("table tr").length;   
        var value = $(this).val();
        if (value != "") {
            //$('.tbody').empty;
            $("table tr").each(function (index) {
                if (index != 0) {
                    $row = $(this);
                    var string = "";
                    string = string + $row.find("td:nth-child(2)").text() + "  ";
                    string = string + $row.find("td:nth-child(3)").text() + "  ";
                    string = string + $row.find("td:nth-child(5)").text() + "  ";
                    string = string + $row.find("td:nth-child(6)").text() + "  ";
                    var a = string.indexOf(value);
                    if (string.indexOf(value) == -1) {
                        $(this).hide();                     
                    }
                    else {
                        $(this).show();
                    }                    
                }
            });
        }
        else {
            clientRefresh()          
        }
    })
});

//Load Data function
function loadData() {
    //INITIALIZ Controls//

    //i-check
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });    

    //start loading snapit
    $('#ibox1').children('.ibox-content').toggleClass('sk-loading');   
    //populate data table
    $.ajax({
        url: "/ConstComputation/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td class="center"  data-type="numeric">' + item.CompetitionID + '</td>';                
                html += '<td>' + item.competitionNo + '</td>';
                html += '<td>' + item.competitionNote + '</td>'; 
                var isChecked = '';
                if (item.competitionFragmented)
                    isChecked = 'checked'
                html += '<td align="right"><div class="icheckbox_square-green ' + isChecked + '" style="position: relative;"><input type="checkbox" ' + isChecked + ' id="competitionFragmented" style="position: absolute; opacity: 0;"></div></td>';  
                var statusLable = '';
                if (item.CompetitionStatusName == "جديد")
                    statusLable = "primary";
                else
                    statusLable = "danger";
                html += '<td><div><span class="label label-' + statusLable + '" style="font-family: DroidKufi-Regular;">' + item.CompetitionStatusName + '</span></div></td>';
                var date = new Date(parseInt(item.CompetitionAddedDate.substr(6)));
                html += '<td>' + date.toLocaleDateString() + '</td>';
                html += '<td>' + item.UserName + ' </td>';  
                html += '<td><div><div class="abcd" id="sparkline6"></div></div></td>';
                html += '<td><button onclick="clearTextBox(); getbyID(' + item.CompetitionID + ');" class="btn btn-primary btn-xs demo2">تعديل</button> <button class="btn btn-danger btn-xs demo4" onclick="clearTextBox(); Delele(' + item.CompetitionID +');">حذف</button></td>';
                html += '</tr>';                
            });  
            $(".table").find('tbody').remove();
            $(".table").find('tfoot').remove();
            $('.table').append('<tbody class="tbody">' + html + '</tbody><tfoot><tr class="footable-paging"><td colspan="9"><div class="footable-pagination-wrapper"><ul class="pagination pull-right"><li id="arrowFirst" class="footable-page-arrow disabled"><a data-page="first" href="#first">«</a></li><li class="footable-page-arrow disabled"><a data-page="prev" href="#prev">‹</a></li><li class="footable-page active"><a data-page="0" href="#">1</a></li><li class="footable-page"><a data-page="1" href="#">2</a></li><li class="footable-page-arrow"><a data-page="next" href="#next">›</a></li><li id="arrowLast" class="footable-page-arrow"><a data-page="last" href="#last">»</a></li></ul></div></td></tr></tfoot>');
            $('.table').footable({
                "paging": {
                    "enabled": true,
                    "limit": 8
                },
                "sorting": {
                    "enabled": true
                }
            });            
            $(".abcd").sparkline([13, 10], {
                type: 'pie',
                height: '25',
                sliceColors: ['#1ab394', '#F5F5F5']
            });
            clientRefresh()        
            $('#ibox1').children('.ibox-content').toggleClass('sk-loading'); $('#ibox1').addClass('bounce');           
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    
}

//function for adding record
function Add() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var isChecked;
    if ($("#competitionFragmentedMyModal").is(':checked'))
        isChecked = true;
    else
        isChecked = false;

    var constComputationObj = {
        competitionNo: $('#competitionNoMyModal').val(),
        competitionNote: $('#competitionNoteMyModal').val(),
        competitionFragmented: isChecked,
    };
    $.ajax({
        url: "/ConstComputation/Add",
        data: JSON.stringify(constComputationObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $("#myTable tbody tr:first").effect("highlight", {}, 3000);     
            $('#myModal').modal('hide');            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for updating record
function Update() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var isChecked;
    if ($("#competitionFragmentedMyModal").is(':checked'))
        isChecked = true;
    else
        isChecked = false;

    var constComputationObj = {
        CompetitionID: $('#CompetitionIDMyModal').val(),
        competitionNo: $('#competitionNoMyModal').val(),
        competitionNote: $('#competitionNoteMyModal').val(),
        competitionFragmented: isChecked,
    };
    $.ajax({
        url: "/ConstComputation/Update",
        data: JSON.stringify(constComputationObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            //location.reload();
            $('#myModal').modal('hide');
            $('#CompetitionIDMyModal').val("");
            $('#competitionNoMyModal').val("");
            $('#competitionNoteMyModal').val("");
            $('#competitionFragmentedMyModal').parent().removeClass("checked");
            $('#competitionFragmentedMyModal').prop('checked', false);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for Deleling record
function Delele(ID) {
    //sweet alert
    swal({
        title: "هل أنت متأكد من الحذف ؟",
        text: "لن تستطيع استرجاع البيانات المحذوفة !",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "نعم, استمر!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "/ConstComputation/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                if (result[0] == "ok") {
                    swal("تم الحذف !", result[1], "success");
                    //location.reload();
                    loadData();
                }
                else {
                    swal("خطأ!", result[1], "error");                    
                }
                
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        
    });
}

//function for get data By ID
function getbyID(constID) {
    $('#CompetitionIDMyModal').css('border-color', 'lightgrey');
    $('#competitionNoMyModal').css('border-color', 'lightgrey');
    $('#competitionNoteMyModal').css('border-color', 'lightgrey');
    $('#competitionFragmentedMyModal').css('border-color', 'lightgrey');
    $.ajax({
        url: "/ConstComputation/getbyID/" + constID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CompetitionIDMyModal').val(result.CompetitionID);
            $('#competitionNoMyModal').val(result.competitionNo);
            $('#competitionNoteMyModal').val(result.competitionNote);
            if (result.competitionFragmented == true) {
                $('#competitionFragmentedMyModal').parent().addClass("checked");
                $('#competitionFragmentedMyModal').prop('checked', true);
            }
            else {
                $('#competitionFragmentedMyModal').parent().removeClass("checked");
                $('#competitionFragmentedMyModal').prop('checked', false);
            }                
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for clear controls
function clearTextBox() {
    $('#search').val("");
    $('#CompetitionIDMyModal').val("");
    $('#competitionNoMyModal').val("");
    $('#competitionNoteMyModal').val("");
    $('#competitionFragmentedMyModal').parent().removeClass("checked");
    $('#competitionFragmentedMyModal').prop('checked', false);
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#competitionNoMyModal').css('border-color', 'lightgrey');
    $('#competitionNoteMyModal').css('border-color', 'lightgrey');
    $('#competitionFragmentedMyModal').css('border-color', 'lightgrey');

}

//function for client Refresh
function clientRefresh() {
    $("table tr").each(function (index) {
        $(this).show();
    });
    //if (counter == 0) {

    //    $('#selector').click();
    //    counter = counter + 1;
    //}
    $('#selector').click();
    $('#selector').click();
}


