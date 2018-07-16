(function () {
    appModule.controller('tenant.views.imageboard.addreply', [
        '$scope', '$uibModalInstance', 'abp.services.app.reply', '$stateParams', 'person', 'FileUploader', 'abp.services.app.user', 
        function ($scope, $uibModalInstance, replyService, stateParams, person, fileUploader, user) {
            var vm = this;
            vm.person = person;
            vm.saving = false;
            vm.thread = {};
            vm.test = {};
            vm.id = stateParams.id;
            vm.fileExtension = "";
            vm.save = function ()
            {
                vm.saving = true;
                vm.thread.threadId = vm.id;
                vm.thread.mediaPath = vm.TempPicSubIcon;
                vm.thread.fileExtension = vm.fileExtension;
                vm.thread.creatorId = vm.user.id;
                vm.thread.posterName = vm.user.fullName;
                if (person != '')
                {
                    replyService.update(vm.thread).then(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                } else
                {
                    vm.thread.mediaPath = vm.TempPicSubIcon;
                    vm.thread.fileExtension = vm.fileExtension;
                    replyService.create(vm.thread).then(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }


            };
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
            user.getFullNameUserId({ id: 0 }).then(function (result) {
                vm.user = result.data;
            });

            if (person != '') {
                replyService.getReplyById({ id: person }).then(function (result) {
                    debugger;
                    vm.thread = result.data;

                });
            }


            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();