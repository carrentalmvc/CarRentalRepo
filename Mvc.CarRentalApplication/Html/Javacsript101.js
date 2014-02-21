var myNS = myNS || {};
myNS.Rennish = (function () {   

    function create() {
        var _person = ["Rennish", "Neha", "Nathan", "Anu"],
            name = "Rennih";

        var today = (function () {

            return moment().format('L');

        })();

        var isPersonAvailable = (function () {

            if (_person && _person.length) {
                return true;
            }
            else
                return false;

        })();


        var checkForLetter = (function () {

            if (name.toLowerCase().indexOf("Renn") !== -1) {
                console.log("Name starts with 'R' ");
            }

        });

        var checkInput = function (value) {

            var valuetype = typeof value;

        }

        return {

            getToday: today,
            IsPersonAvailable: isPersonAvailable,
            NameStartsWithR: checkForLetter

        };

    }

    return {

        Create : create
    };


})();

if (window.console && myNS.Rennish) {

     var result = myNS.Rennish.Create().getToday;
     var namestart = result.NameStartsWithR;

    console.log('Haha... ' + myNS.Rennish.Create());
}

