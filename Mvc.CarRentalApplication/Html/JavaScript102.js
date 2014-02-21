$(function () {

    var vm = {

        Name: ko.observable(null),
        MyArray: ko.observableArray([]),
        Sum: ko.observable(null)        
        
    };

    vm.Total = ko.computed(function () {

        var localArray = [];

        for (var i = 0; i <= 1000000000000000000000000000; i++) {

            localArray.push(i);
        };

    });

    if(true){

        var testArray = [];
      
        for(var i = 0;i<=200000000000;i++){
          
        testArray.push(i);
        }

        chunk(testArray, findSum);
    }

    function chunk(array, findSum) {

        var items = array.concat();//clone the array

        setTimeout(function () {

            var item = items.shift();
            findSum.call(item);

        }, 100);

        //at the end,return the 
        return vm.Sum(vm.MyArray().length);
    }

    function findSum(item) {
        
        vm.MyArray().push(item);
    }

    ko.applyBindings(vm, $('#tbl').get(0));
    

});