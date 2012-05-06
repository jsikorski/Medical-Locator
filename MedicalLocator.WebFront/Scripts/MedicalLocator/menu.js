function MenuManager() {

    var searchingManager = new SearchingManager();

    var onFindNearbyClick = function () {
        searchingManager.findNearby();
    };

    this.initializeFindNearby = function(findNearbyElement) {
        findNearbyElement.click(onFindNearbyClick);
    };
}
