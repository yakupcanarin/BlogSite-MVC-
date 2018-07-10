function AddCategory() {
    Category = new Object();
    Category.CategoryName = $("#insert").val();
    Category.isActive = $("#IsActive").is(":checked");
    Category.User_ID = $("#userID").val();


    $.ajax({

        url: "/Category/Insert",
        data: Category,
        datatype: "JSON"
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                })
            }
            else {
                bootbox.alert(response.Message, function () {

                })
            }
        }
    })
}

function UpdateCategory() {
    Category = new Object();
    Category.ID = $("#id").val();
    Category.CategoryName = $("#update").val();
    Category.isActive = $("#IsActive").is(":checked");

    $.ajax({

        url: "/Category/Update",
        data: Category,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                Bootstrap.alert(response.Message, function () {
                    location.reload();
                })
            }
            else {
                Bootstrap.alert(response.Message, function () {

                })
            }
        }
    })
}

