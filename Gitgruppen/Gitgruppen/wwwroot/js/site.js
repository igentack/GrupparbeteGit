
 function showDetails() {

    $.ajax({

        type: "Get",

        url: "/ParkedVehicles/DetailsModal",

        success: function (result) {

            $("#IndexTable").html(result);

            $("#addDetailsModal").modal('show');

        }

    });
}