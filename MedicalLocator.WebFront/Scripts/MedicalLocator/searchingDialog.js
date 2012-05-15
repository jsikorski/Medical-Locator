var searchingDialogManager = new SearchingDialogManager();

function SearchingDialogManager() {
    var medicalTypeComboBoxSelector = "#SearchData_CenterType";
    var searchFormSelector = "#search_form";
    var searchOptionsTabsSelector = "#search_options_tabs";
    var searchButtonSelector = "#search_button";
    var userLatitudeFieldSelector = "#SearchData_UserLatitude";
    var userLongitudeFieldSelector = "#SearchData_UserLongitude";

    var searchedAddressFieldId = "SearchData_SearchedAddress";
    var searchedLatitudeFieldId = "SearchData_SearchedLatitude";
    var searchedLongitudeFieldId = "SearchData_SearchedLongitude";

    var myLocationOptionValue = "MyLocation";
    var addressOptionValue = "Address";
    var coordinatesOptionValue = "Coordinates";

    var hideField = function (fieldId) {
        $("#" + fieldId).parent().hide();
    };

    var showField = function (fieldId) {
        $("#" + fieldId).parent().show("slow");
    };

    var getSelectedMedicalType = function () {
        return $(medicalTypeComboBoxSelector).children(":selected").val();
    };
    
    var updateFieldsVisibility = function () {
        var selectedMedicalType = getSelectedMedicalType();
        switch (selectedMedicalType) {
            case myLocationOptionValue:
                hideField(searchedAddressFieldId);
                hideField(searchedLatitudeFieldId);
                hideField(searchedLongitudeFieldId);
                break;
            case addressOptionValue:
                showField(searchedAddressFieldId);
                hideField(searchedLatitudeFieldId);
                hideField(searchedLongitudeFieldId);
                break;
            case coordinatesOptionValue:
                hideField(searchedAddressFieldId);
                showField(searchedLatitudeFieldId);
                showField(searchedLongitudeFieldId);
                break;
        }
    };

    var onSearchButtonClick = function () {
        if (!$(searchFormSelector).valid()) {
            return;
        }

        var searchingManager = new SearchingManager();
        searchingManager.search();
    };

    var initializeSearchButton = function() {
        var searchButton = $(searchButtonSelector);
        searchButton.button();
        searchButton.click(onSearchButtonClick);
    };

    var initializeGeneralTab = function () {
        $(medicalTypeComboBoxSelector).change(updateFieldsVisibility);
        updateFieldsVisibility();
    };

    this.myLocationOptionValue = myLocationOptionValue;
    this.addressOptionValue = addressOptionValue;
    this.coordinatesOptionValue = coordinatesOptionValue;

    this.getSelectedMedicalType = getSelectedMedicalType;

    this.initialize = function () {
        $(searchOptionsTabsSelector).tabs();
        initializeSearchButton();
        initializeGeneralTab();
    };

    this.submitDialogForm = function () {
        $(searchFormSelector).submit();
    };

    this.setUserCoordinates = function (latitude, longitude) {
        $(userLatitudeFieldSelector).val(latitude);
        $(userLongitudeFieldSelector).val(longitude);
    };
}

