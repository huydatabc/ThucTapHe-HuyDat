(function () {
    appModule.controller('common.views.welcome.index', [
        '$scope', '$stateParams',

        function ($scope, $stateParams) {
            var vm = this;
            vm.threadsave = $stateParams.id; 
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            //...
        }]);
})();