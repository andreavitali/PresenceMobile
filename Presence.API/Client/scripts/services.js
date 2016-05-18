// ==========================================================================
// Services
// ==========================================================================

presenceMobile.factory('PersonsSvc', function ($http) {
    var personsSvc = {};

    personsSvc.list = function () {
        return $http.get("/api/persons");
    };

    personsSvc.get = function (id) {
        return $http.get("/api/persons/" + id);
    };

    return personsSvc;
});
