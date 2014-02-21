//This is used to

$(function () {

    var vmm = {

        Data: ko.observableArray([])
    };

    var viewModel = [{

        FirstName: "Rennish",
        LastName: "Joseph",
        Username: "Chase\\Nathappan",
        Zip: 32225

    },

 {

     FirstName: "Anu",
     LastName: "John",
     Username: "Chase\\Anupama",
     Zip: 32226

 },
 {

     FirstName: "Nehamma",
     LastName: "Jesus",
     Username: "Rennish Joseph Tharappel",
     Zip: 32204

 }
    ];

    var getName = function (users) {
        var modUsers,
            newUserName;

        if (!!users && users.length > 0) {

            modUsers = $.map(users, function (element) {

                if (!!element.Username && element.Username.indexOf("\\") !== -1) {

                    newUserName = element.Username.substring(element.Username.indexOf("\\") + 1);
                    element.Username = newUserName;
                    return element;
                }
                else {
                    return element;
                }

            });

            if (modUsers && modUsers.length > 0) {

                return modUsers;
            }

        }
    };
    var newVm = getName(viewModel);
    ko.applyBindings(vmm.Data(newVm));

});