(function () {
    appModule.controller('tenant.views.imageboard.index', [
        '$scope', '$uibModal', 'abp.services.app.thread', 'FileUploader', 'abp.services.app.poster', '$stateParams', 'abp.services.app.user',
        function ($scope, $uibModal, theadService, fileUploader, posterService, $stateParams,user) {
            var vm = this;
            vm.user = user;
            vm.thread = [];
            vm.TempPicSubIcon = {};
            function getThread() {
                theadService.listAll({}).then(function (result) {
                    vm.thread = result.data;
                });
            }
            user.getFullNameUserId({ id: 0 }).then(function (result) {
                vm.user = result.data;
            });
            vm.openmodal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/tenant/views/imageboard/modal.cshtml',
                    controller: 'tenant.views.imageboard.modal as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getThread();
                });
            };
            vm.delete = function (id) {
                abp.message.confirm(
                    'Thread will be deleted.',
                    'Are you sure?',
                    function (isConfirmed) {
                        if (isConfirmed) {
                            //...delete user

                            theadService.delete({ id: id }).then(function (result) {
                                getThread();
                            });
                        }
                    }
                );

            };
            debugger;

            vm.edit = function (person) {
                debugger
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/tenant/views/imageboard/modal.cshtml',
                    controller: 'tenant.views.imageboard.modal as vm',
                    backdrop: 'static',
                    resolve: {
                        person: function () {
                            return person;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    getThread();
                });
            };

            getThread(); //endof

        }

    ]);
})();


