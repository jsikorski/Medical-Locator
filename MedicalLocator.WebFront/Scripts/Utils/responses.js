responsesController = new ResponsesController();

function ResponsesController() {
    this.isResponseValid = function (response) {
        return response != "Failure";
    };
}