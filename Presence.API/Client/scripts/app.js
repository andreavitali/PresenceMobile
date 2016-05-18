var presenceMobile = angular.module('PresenceMobile', ['ionic'])

.run(function ($ionicPlatform, $ionicSideMenuDelegate) {
    $ionicPlatform.ready(function () {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard for form inputs)
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        }
        if (window.StatusBar) {
            StatusBar.styleDefault();
        }
        document.addEventListener('touchstart', function (event) {
            // workaround for Android
            if ($ionicSideMenuDelegate.isOpenLeft()) {
                event.preventDefault();
            }
        });
    });
})

.config(function ($stateProvider, $urlRouterProvider, $ionicConfigProvider) {

    // Ionic
    $ionicConfigProvider.backButton.previousTitleText(false).text('');

    // Routing
    $stateProvider
    .state('persons', {
        url: "/persons",
        templateUrl: "Client/templates/persons.html",
        controller: "PersonsCtrl"
    })
    .state('person_details', { // if you make this a child view of 'persons' the menu button will be hidden automatically
        url: "/persons/:id",
        templateUrl: "Client/templates/person_details.html",
        resolve: {
            person: function (PersonsSvc, $stateParams) {
                return PersonsSvc.get($stateParams.id);
            }
        },
        controller: "PersonDetailsCtrl"
    });
    
    $urlRouterProvider.otherwise("/persons");
})