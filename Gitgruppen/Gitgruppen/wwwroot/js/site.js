
 function showDetatails() {

    $.ajax({

        type: "Get",

        url: "/ParkedVehicles/Create",

        success: function (result) {

            $("#kruxTable").html(result);

            $("#addkrux").modal('show');

        }

    });
}