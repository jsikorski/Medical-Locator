var searchingDialogManager = new SearchingDialogManager();

SearchingType = {
    myLocation: "MyLocation",
    address: "Address",
    coordinates : "Coordinates"
};

function SearchingDialogManager() {
    var searchingManager = new SearchingManager();
    
    var searchingTypeComboBoxSelector = "#SearchData_CenterType";
    var searchFormSelector = "#search_form";
    var searchOptionsTabsSelector = "#search_options_tabs";
    var searchButtonSelector = "#search_button";

    var searchedAddressFieldId = "SearchData_SearchedAddress";
    var searchedLatitudeFieldId = "SearchData_SearchedLatitude";
    var searchedLongitudeFieldId = "SearchData_SearchedLongitude";

    var hideField = function (fieldId) {
        $("#" + fieldId).parent().hide();
    };

    var showField = function (fieldId) {
        $("#" + fieldId).parent().show("slow");
    };

    var getSelectedSearchingType = function () {
        return $(searchingTypeComboBoxSelector).children(":selected").val();
    };
    
    var updateFieldsVisibility = function () {
        var selectedSearchingType = getSelectedSearchingType();
        switch (selectedSearchingType) {
            case SearchingType.myLocation:
                hideField(searchedAddressFieldId);
                hideField(searchedLatitudeFieldId);
                hideField(searchedLongitudeFieldId);
                break;
            case SearchingType.address:
                showField(searchedAddressFieldId);
                hideField(searchedLatitudeFieldId);
                hideField(searchedLongitudeFieldId);
                break;
            case SearchingType.coordinates:
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

        var selectedSearchingType = getSelectedSearchingType();
        if (selectedSearchingType == SearchingType.myLocation) {
            searchingManager.searchUsingUserLocation();
        } else {
            searchingManager.searchNotUsingUserLocation();
        }

    };

    var initializeSearchButton = function () {
        var searchButton = $(searchButtonSelector);
        searchButton.button();
        searchButton.click(onSearchButtonClick);
    };

    var initializeGeneralTab = function () {
        $(searchingTypeComboBoxSelector).change(updateFieldsVisibility);
        updateFieldsVisibility();
    };

    this.initialize = function () {
        $(searchOptionsTabsSelector).tabs();
        initializeSearchButton();
        initializeGeneralTab();
    };

    this.processSearchResponse = function (response) {
        searchingManager.processSearchResponse(response);

        if (responsesController.isResponseValid(response)) {
            dialogsManager.closeDialog();
        }
    };
}

