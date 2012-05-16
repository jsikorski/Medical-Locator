jQuery.validator.addMethod("checkage",
    function(value, element, param) {
        alert("Checkage");
        return true;
        var currDate = param;
        var sdoc = currDate.split('-');
        var dobDate = value;
        var sdob = dobDate.split('-');
        //pass year,month,date in new Date object.
        var vDOB = new Date(sdob[2], sdob[1], sdob[0]);
        var vDOC = new Date(sdoc[2], sdoc[1], sdoc[0]);
        //getAge user define function to calculate age.
        var vYrs = getAge(vDOB, vDOC);
        var result = false;
        if (vYrs >= 18 && vYrs <= 30) {
            result = true;
        }
        return result;
    });

jQuery.validator.addMethod("hello",
    function(value, element, param) {
        alert("Hello");
        return false;
    });

jQuery.validator.unobtrusive.adapters.add("checkage", ["param", "param1"], function(options) {
    alert("Is OK");
    options.rules["checkage"] = options.params.param;
    options.rules["hello"] = options.params.param;
    options.messages["hello"] = options.message;
});

function getAge(oldDate, currDate) {
    return currDate.getFullYear() - oldDate.getFullYear();
}