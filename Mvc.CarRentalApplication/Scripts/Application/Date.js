$(function () {

    var today = moment().format('LLL');

    var vm = {

        Today: ko.observable(today)
    };

    if (vm && window.console) {
        console.log('View model is present');
    }


    ko.applyBindings(vm,$("#datediv").get(0));

});