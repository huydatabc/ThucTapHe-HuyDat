(function () {
    appModule.controller('tenant.views.imageboard.modal', [
        '$scope', '$uibModalInstance', 'abp.services.app.thread', 'person', 'FileUploader', 'abp.services.app.user',
        function ($scope, $uibModalInstance, threadService, person, fileUploader,user) {
            var vm = this;
            vm.person = person;
            vm.saving = false;
            vm.thread = {};
            vm.user = {};
            vm.save = function ()
            {
               // vm.thread.mediaPath = vm. //todo chuyen ham up hinh qua day
                vm.saving = true;
                vm.thread.id = vm.person;
                vm.thread.creatorId = vm.user.id;
                vm.thread.posterName = vm.user.fullName;
                if (person != '') {
                    debugger;
                    threadService.update(vm.thread).then(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        chatHub.server.updateThread();
                        vm.saving = false;
                    });
                } else {
                    vm.thread.mediaPath = vm.TempPicSubIcon;
                    vm.thread.fileExtension = vm.fileExtension;
                    threadService.create(vm.thread).then(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        chatHub.server.updateThread();
                        vm.saving = false;
                    });
                }
            };

            user.getFullNameUserId({ id: 0 }).then(function (result) {
                vm.user = result.data;
            });

            if (person != '') {
                threadService.getThreadById({ id: person }).then(function (result) {
                    vm.thread = result.data;

                });
            }

            vm.imageUpload = new fileUploader({
                url: abp.appPath + 'File/UploadFile',
                headers:
                    {
                        "X-XSRF-TOKEN": abp.security.antiForgery.getToken()
                    },
                autoUpload: true,
                filters: [{
                    name: 'fileFilter',
                    fn: function (item, options) {
                        //File type check
                        var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                        if ('|jpg|jpeg|png|ico|gif|webm|mp4|'.indexOf(type) === -1) {
                            abp.message.warn(app.localize('ProfilePicture_Warn_FileType'));
                            return false;
                        }

                        return true;
                    }
                }]
            });
            debugger;
            vm.imageUpload.onSuccessItem = function (fileItem, response, status, headers) {
                if (response.success) {
                    vm.TempPicSubIcon = "/Temp/media/" + response.result.fileName;
                    vm.fileExtension = response.result.extension;

                } else {
                    abp.message.error(response.error.message);
                }
            };
            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();