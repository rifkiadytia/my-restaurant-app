
$(document).ready(function () {
    //jQueryUI method to create dialog box
    $("#assignRoleForm").dialog({
        autoOpen: false,
        modal: true,
        width: 450,
        title: "Assign Role"
    });

});

$(".btnAssignRole").button().click(function () {
    // Get the Id if selected training and assign in selectedId variable    
    var selectedId = $(this).parents().children('input[type="hidden"]').attr('value');
    $.ajax({
	// Call EditPartialView action method
        url: "/Account/AssignRole",
        data: { id: selectedId },
        type: 'Get',
        success: function (msg) {
            $("#assignRoleForm").dialog("open");
            $("#assignRoleForm").empty().append(msg);
			},
        error: function () {
            alert("something seems wrong");
        }
    });
});


