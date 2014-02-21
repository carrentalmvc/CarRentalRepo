var CarRental = CarRental || {};
CarRental.RegisterViewModel = CarRental.RegisterViewModel || {};
var RegisterDialog = RegisterDialog || {};
RegisterDialog.ModalEvents = (function () {
    $("#registerLink").click(function () {
        openDialog();
    });

    var openDialog = function () {

        $("#registerDiv").dialog("open");
    };

    $("#registerDiv").dialog(
            {
                autoOpen: false,
                height: 400,
                width: 350,
                modal: true,
                title: "Create New User",
                buttons: {

                    "Register": CarRental.RegisterViewModel.Create.Register,

                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                }

            });
})();
