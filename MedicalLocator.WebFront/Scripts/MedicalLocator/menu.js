function MenuManager() {

    var searchingManager = new SearchingManager();

    var onFindNearbyButtonClick = function () {
        searchingManager.findNearby();
    };

    var onSearchButtonClick = function () {
        $.ajax({
            url: "Searching/ShowSearchDialog",
            success: function (response) {
                dialogsManager.addDialogDiv();
                dialogsManager.placeContentIntoDialogDiv(response);
                $("#search_options_tabs").tabs();
                dialogsManager.initializeDialog("Search");
            }
        });
    };

    this.initializeFindNearbyButton = function (findNearbyButtonElement) {
        findNearbyButtonElement.click(onFindNearbyButtonClick);
    };

    this.initializeSearchButton = function (searchButtonElement) {
        searchButtonElement.click(onSearchButtonClick);
    };
}

$(function () {
    var menuManager = new MenuManager();

    var findNearbyButtonElement = $("#find_nearby_button");
    menuManager.initializeFindNearbyButton(findNearbyButtonElement);

    var searchButtonElement = $("#search_button");
    menuManager.initializeSearchButton(searchButtonElement);
});