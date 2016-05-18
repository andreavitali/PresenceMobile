// ==========================================================================
// Controllers
// ==========================================================================

presenceMobile.controller('PersonsCtrl', function ($scope, $ionicLoading, $ionicPopup, PersonsSvc) {
    $ionicLoading.show({
        template: 'Loading...'
    });
    PersonsSvc.list().then(function (result) {
        $scope.persons = result.data;
        //$ionicLoading.hide();
    }, function (error) {
        //$ionicLoading.hide();
        $ionicPopup.alert({
            template: 'Login error'
        });
    }).finally(function () {
        $ionicLoading.hide();
    });;
});

presenceMobile.controller('PersonDetailsCtrl', function ($scope, person) {
    $scope.person = person.data;
});

// ==========================================================================
// Directives
// ==========================================================================

presenceMobile.directive('ionCollapsibleItem', function () {
    return {
        restrict: 'E',
        replace: true,
        transclude: true,
        scope: {
            itemTitle: '@'
        },
        template: '<div class="ion-collapsible-item"><div class="item item-icon-right ion-collapsible-item-header" ng-click="toggleCollapsibleItem()">{{itemTitle}}\
            <i class="icon icon-accessory" ng-class="isOpened ? \'ion-chevron-up\' : \'ion-chevron-down\'"></i></div>\
            <div class="ion-collapsible-item-content" ng-show="isOpened" ng-transclude></div></div>',
        link: function (scope, elem, attrs) {
            scope.isOpened = false;
            scope.toggleCollapsibleItem = function () {
                scope.isOpened = !scope.isOpened;
            };
        }
    }
});
