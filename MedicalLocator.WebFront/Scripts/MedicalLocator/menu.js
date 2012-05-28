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

    var onLoginButtonClick = function () {
        
        $.ajax({
            url: "Logging/ShowLoginDialog",
            success: function (response) {
                dialogsManager.addDialogDiv();
                dialogsManager.placeContentIntoDialogDiv(response);
                dialogsManager.initializeDialog("Login");
            }
        });
    };

    var onLogoutButtonClick = function () {
        $.ajax({
            url: "Logging/Logout",
            success: function (response) {
                $("#login_block").show();
                $("#logout_block").hide();
            }
        });
    };
   
    this.initializeFindNearbyButton = function (findNearbyButtonElement) {
        findNearbyButtonElement.click(onFindNearbyButtonClick);
    };

    this.initializeSearchButton = function (searchButtonElement) {
        searchButtonElement.click(onSearchButtonClick);
    };

    this.initializeLoginButton = function (loginButtonElement) {
        loginButtonElement.click(onLoginButtonClick);
    };
    
    this.initializeLogoutButton = function (logoutButtonElement) {
        logoutButtonElement.click(onLogoutButtonClick);
    };
}