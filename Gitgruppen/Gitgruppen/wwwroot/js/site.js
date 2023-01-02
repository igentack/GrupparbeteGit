
 function showDetatails() {

    $.ajax({

        type: "Get",

        url: "/ParkedVehicles/DetailsModal",

        success: function (result) {

            $("#ModalTable").html(result);

            $("#addDetailsModal").modal('show');

        }

    });
}