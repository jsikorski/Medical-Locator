function MenuManager() {

    var searchingManager = new SearchingManager();

    var onFindNearbyClick = function () {
        searchingManager.findNearby();
    };

    this.initializeFindNearby = function (findNearbyElement) {
        findNearbyElement.click(onFindNearbyClick);
    };
}

$(function () {
    var menuManager = new MenuManager();

    var findNearby = $("#find_nearby");
    menuManager.initializeFindNearby(findNearby);
});