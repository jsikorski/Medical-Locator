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

    var objectsTabsSelector = "#tabs-2";

    var generalTabIndex = 0;
    var objectsTabIndex = 1;

    var medicalTypesValidationDivSelector = "#medical_types_validation_div";
    var medicalTypeCheckBoxSelector = ".medical_type_checkbox";

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

    var updateMedicalTypesValidation = function () {
        if (!isAnyMedicalTypeSelected()) {
            showMedicalTypesValidationError();
        } else {
            hideMedicalTypesValidationError();
        }
    };

    var activateTab = function (tabIndex) {
        $(searchOptionsTabsSelector).tabs({ selected: tabIndex });        
    };

    var activateGeneralTab = function () {
        activateTab(generalTabIndex);
    };

    var activateObjectsTab = function () {
        activateTab(objectsTabIndex);
    };

    var isAnyMedicalTypeSelected = function () {
        var numberOfCheckedMedicalTypes = $(objectsTabsSelector).find("input[type=checkbox]:checked").length;
        if (numberOfCheckedMedicalTypes > 0) {
            return true;
        }
        return false;
    };

    var isSearchFormValid = function () {
        return $(searchFormSelector).valid();
    };

    var showMedicalTypesValidationError = function () {
        $(medicalTypesValidationDivSelector).attr("class", "validation-summary-errors");
    };

    var hideMedicalTypesValidationError = function () {
        $(medicalTypesValidationDivSelector).attr("class", "validation-summary-valid");
    };

    var onSearchButtonClick = function () {
        if (!isSearchFormValid()) {
            activateGeneralTab();
            return;
        }

        if (!isAnyMedicalTypeSelected()) {
            updateMedicalTypesValidation();
            activateObjectsTab();
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

    var initializeObjectsTab = function () {
        $(medicalTypeCheckBoxSelector).change(updateMedicalTypesValidation);
    };

    this.initialize = function () {
        $(searchOptionsTabsSelector).tabs();
        initializeSearchButton();
        initializeGeneralTab();
        initializeObjectsTab();
    };

    this.processSearchResponse = function (response) {
        searchingManager.processSearchResponse(response);

        if (responsesController.isResponseValid(response)) {
            dialogsManager.closeDialog();
        }
    };
}

