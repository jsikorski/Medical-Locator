menuManager = {
    initializeFindNearby: function (findNearbyElement) {
        findNearbyElement.click(onFindNearbyClick);
    }
};

function onFindNearbyClick() {
    var searchingManager = new SearchingManager();
    searchingManager.findNearby();
}