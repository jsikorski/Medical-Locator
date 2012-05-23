(function ($) {
    function getElementNameBase(element) {
        var nameParts = $(element).attr("name").split(".");
        var nameBase = "";
        var lastIndex = nameParts.length - 1;
        for (var i = 0; i < lastIndex; i++) {
            nameBase += nameParts[i];

            if (i != lastIndex) {
                nameBase += ".";
            }
        }
        return nameBase;
    }

    $.validator.addMethod("requiredifpropertyequal", function (value, element, params) {
        var elementNameBase = getElementNameBase(element);
        var fullPropertyName = elementNameBase + params.propertyname;
        var currentPropertyValue = $("[name='" + fullPropertyName + "']").val();

        if (currentPropertyValue == params.propertyvalue) {
            var isValid = value != null && value.length > 0;
            return isValid;
        }

        return true;
    });

    $.validator.unobtrusive.adapters.add("requiredifpropertyequal", ["propertyname", "propertyvalue"], function (options) {
        options.rules["requiredifpropertyequal"] = options.params;
        options.messages["requiredifpropertyequal"] = options.message;
    });

} (jQuery));