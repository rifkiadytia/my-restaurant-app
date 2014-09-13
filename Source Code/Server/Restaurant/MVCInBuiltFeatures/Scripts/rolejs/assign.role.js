
$(document).ready(function (e) {
    $("#btnAssign").click(function () {
       
        var hasData = false;
        var selected = [];
        $('div#allAssignItem input[type=checkbox]').each(function () {
            if ($(this).prop('checked')) {
                var itemAssign = { Name: $(this).attr('value'), IdUsr: $(this).attr('userId') };
                selected.push(itemAssign);
                hasData =true;
            }
        });
        if(!hasData)
            return;
        var assignRoleSend = JSON.stringify(selected);
        $.ajax({
            type: 'POST',
            url: '/Account/AssignRole',
            data: assignRoleSend,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.dataSc == "1") {
                    alert(data.dataMsg);
                    $("#assignRoleForm").dialog("close");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Status error code : ' + xhr.status);
            },
            async: true,
            processData: false
        });
    });

});



