(function () {
    jQuery.validator.addMethod('mustbe', function (value, element, params) {
        var testValue = params['propertyvalue'];
        var condition = params['condition'];
        if ((condition == '0') && (value != testValue))
            return true;
        if ((condition == '1') && (value == testValue))
            return true;
        return false;
    });
    var setValidationValues = function (options, ruleName, value) {
        options.rules[ruleName] = value;
        if (options.message) {
            options.messages[ruleName] = options.message;
        }
    };
    var $Unob = $.validator.unobtrusive;
    $Unob.adapters.add("mustbe", ["propertyvalue", "condition"], function (options) {
        var value = {
            propertyvalue: options.params.propertyvalue,
            condition: options.params.condition
        };
        setValidationValues(options, "mustbe", value);
    });

})();

//(function ($) {
//    $.validator.addMethod("notequalto", function (value, element, params) {

//        return false;
//        alert("Hello");

//        if (!this.optional(element)) {
//            var otherProp = $('#' + params);
//            return (otherProp.val() != value);
//        }
//        return true;
//    });
//    $.validator.unobtrusive.adapters.addSingleVal("notequalto", "otherproperty");
//} (jQuery));
