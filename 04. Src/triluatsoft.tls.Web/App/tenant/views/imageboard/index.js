
(function () {
    appModule.controller('tenant.views.imageboard.index', [
        '$scope', '$uibModal', 'abp.services.app.thread', 'FileUploader', 'abp.services.app.poster', '$stateParams', 'abp.services.app.user', '$timeout',
        function ($scope, $uibModal, theadService, fileUploader, posterService, $stateParams, user, $timeout) {

            var vm = this;
            vm.user = user;
            vm.thread = [];
            vm.TempPicSubIcon = {};
            //debugger;
            $.connection.hub.stop();
            var chatHub = $.connection.boardHub; // Get a reference to the hub
            //$.connection.hub.start().done(function () {
            //    //chatHub.client.listThread = function () {
            //    //    theadService.listAll({}).then(function (result) {
            //    //        vm.thread = result.data;
            //    //    })
            //    console.log('received message: ');

            //    //hubContext.Clients.all.hello(); // Send a message to the server

            //    //}
            //});

            chatHub.client.getMessage = function (message) { // Register for incoming messages
                console.log('received message: ' + message);
                console.log('Received');
            };

            chatHub.client.getThread = function () {
                theadService.listAll({}).then(function (result) {
                    vm.thread = result.data;
                });
            }
            function listAll() {
                theadService.listAll({}).then(function (result) {
                    vm.thread = result.data;
                });
            }

            $.connection.hub.start().done(function () {
                abp.event.on('abp.signalr.connected', function () { // Register to connect event
                    console.log('Sent');
                    chatHub.server.sendMessage("Hi everybody, I'm connected to the chat!"); // Send a message to the server
                });


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
                        chatHub.server.updateThread();
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
                                    chatHub.server.updateThread();
                                });
                            }
                        }
                    );

                };

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
                        chatHub.server.updateThread();
                    });

                };

            });
            listAll();
            abp.signalr.connect();

        }

    ]);
})();


