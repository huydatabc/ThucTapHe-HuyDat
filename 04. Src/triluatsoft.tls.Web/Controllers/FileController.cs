using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.UI;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using triluatsoft.tls.Dto;

namespace triluatsoft.tls.Web.Controllers
{
    public class FileController : tlsControllerBase
    {
        private readonly IAppFolders _appFolders;

        public FileController(IAppFolders appFolders)
        {
            _appFolders = appFolders;
        }

        [AbpMvcAuthorize]
        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, file.FileToken);
            if (!System.IO.File.Exists(filePath))
            {
                throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            System.IO.File.Delete(filePath);
            return File(fileBytes, file.FileType, file.FileName);
        }
        public JsonResult UploadFile()
        {
            try
            {
                //Check input
                if (Request.Files.Count <= 0 || Request.Files[0] == null)
                {
                    throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
                }
                string extension = "";
                var file = Request.Files[0];

                if (file.ContentLength > 999999999) //5MB.
                {
                    if (file.ContentLength > 999999999)
                    {
                        throw new UserFriendlyException(L("ProfilePicture_Warn_SizeLimit"));
                    }
                    else
                    {
                        var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/media/"), file.FileName);

                        if (extension == ".jpeg" || extension == ".jpg" || extension == ".JPEG" || extension == ".JPG" || extension == ".webm" || extension == ".WEBM")
                        {
                            file.SaveAs(tempFilePath);
                            //FileHelper.DeleteIfExists(tempFilePath);
                        }
                        else
                        {
                            tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/media/"), file.FileName);
                            file.SaveAs(tempFilePath);
                        }
                    }
                }
                else
                {
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/media/"), file.FileName);
                    extension = Path.GetExtension(tempFilePath);
                    file.SaveAs(tempFilePath);
                }

                //Save file

                return Json(new AjaxResponse(new { fileName = file.FileName, size = file.ContentLength, extension }));
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
}