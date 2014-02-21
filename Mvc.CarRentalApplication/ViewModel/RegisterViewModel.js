var CarRental = CarRental || {};
CarRental.RegisterViewModel = function () {

    function Create() {

        var urlString = "/Register/Register",
            username = $("#UserName").val(),
            password = $("#Password").val(),
            email = $("#Email").val(),
            confirmPassword = $("#ConfirmPassword").val();

        var callProxy = (function (viewModel) {

            var token = $("input[name='__RequestVerificationToken']").val();
            //Rennish: For som ereason $().serialize() throws an invalid JSON Primitive error on the server side
            //var data = { UserName: $("#UserName").val(), Password: $("#Password").val(), Email: $("#Email").val() };
            var jsonData = ko.mapping.toJSON(viewModel);
            var headers = {};
            headers['__RequestVerificationToken'] = token;
            $.ajax({

                cache: false,
                dataType: 'json',
                type: 'POST',
                headers: headers,
                data: jsonData,
                contentType: 'application/json;charset=utf-8',
                url: '/Register/Register',
                success: function (data, textStatus, jqXHR) {
                    alert('Success got called back with : ' + data.Message);

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('An error occurred : ' + errorThrown);
                }

            })
        })();

        var registerUser = (function () {
            var viewModel = {

                UserName: ko.observable(username),
                Password: ko.observable(password),
                Email: ko.observable(email),
                ConfirmPassword: ko.observable(confirmPassword)
            };
            if (viewModel.Password() === viewModel.ConfirmPassword()){
                callProxy(viewModel);
            }

           
        })();

        return {
            Register: registerUser

        }
    }

    return {

        Create: Create

    };


};