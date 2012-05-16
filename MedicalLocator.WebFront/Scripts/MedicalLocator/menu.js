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