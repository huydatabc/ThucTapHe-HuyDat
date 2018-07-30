(function () {
    appModule.controller('tenant.views.imageboard.thread', [
        '$scope', '$uibModal', 'abp.services.app.thread', 'abp.services.app.poster', 'abp.services.app.reply', '$stateParams', 'abp.services.app.user',
        function ($scope, $uibModal, theadService, posterService, replyService, $stateParams, user) {
            var vm = this;

            vm.post = [];
            $.connection.hub.stop();
            var replyHub = $.connection.replyHub;

            function getThread() {
                theadService.listAll({}).then(function (result) {
                    vm.thread = result.data;
                });
            }

            function listAll() {
                replyService.getReplyByThreadId({ threadId: $stateParams.id }).then(function (result) {
                    vm.post = result.data;
                });
            }

            replyHub.client.getReply = function () {
                replyService.getReplyByThreadId({ threadId: $stateParams.id }).then(function (result) {
                    vm.post = result.data;
                });
            }

            $.connection.hub.start().done(function () {
                abp.event.on('abp.signalr.connected', function () { // Register to connect event
                    console.log('Received');

                });

                vm.openreply = function () {
                    debugger;
                    var modalInstance = $uibModal.open({
                        templateUrl: '~/App/tenant/views/imageboard/addreply.cshtml',
                        controller: 'tenant.views.imageboard.addreply as vm',
                        backdrop: 'static'
                    });

                    modalInstance.result.then(function () {
                        getReply();
                    });
                };
                vm.delete = function (id) {
                    abp.message.confirm(
                        'This reply will be deleted.',
                        'Are you sure?',
                        function (isConfirmed) {
                            if (isConfirmed) {
                                //...delete user
                                replyService.delete({ id: id }).then(function (result) {

                                    replyHub.server.updateReply();
                                });
                            }
                        }
                    );

                };
                vm.edit = function (person) {
                    var modalInstance = $uibModal.open({
                        templateUrl: '~/App/tenant/views/imageboard/addreply.cshtml',
                        controller: 'tenant.views.imageboard.addreply as vm',
                        backdrop: 'static',
                        resolve: {
                            person: function () {
                                return person;
                            }
                        }
                    });

                    modalInstance.result.then(function () {
                        replyHub.server.updateReply();
                    });
                };
                user.getFullNameUserId({ id: 0 }).then(function (result) {
                    vm.user = result.data;
                });

            });
            listAll();
            abp.signalr.connect();

        }
    ]);
})();