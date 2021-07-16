using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AliFitnessAE.Authorization;
using AliFitnessAE.Controllers;
using AliFitnessAE.Roles;
using AliFitnessAE.Web.Models.Admin.Roles;
using AliFitnessAE.AppService.TopicContent;
using AliFitnessAE.TopicContent.Dto;
using AliFitnessAE.AppService.Document;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using AliFitnessAE.Document.Dto;
using Abp.Web.Models;
using System.Linq;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Users;
using AliFitnessAE.Crypto;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [AbpMvcAuthorize]
    [Area("Admin")]
    public class DocumentController : AliFitnessAEControllerBase
    {
        private readonly IDocumentAppService _documentAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;

        public DocumentController(IDocumentAppService documentAppService,
             ILookupAppService lookupAppService,
             IWebHostEnvironment webHostEnvironment,
             IUserAppService userAppService,
             UserManager userManager
             )
        {
            _documentAppService = documentAppService;
            _lookupAppService = lookupAppService;
            _webHostEnvironment = webHostEnvironment;
            _userAppService = userAppService;
            _userManager = userManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<AjaxResponse> Upload(UploadVModel model)
        {
            if (ModelState.IsValid)
            {
                string profilePhotoPath = string.Empty;
                string fileUrl = UploadedFile(model, out profilePhotoPath);
                if (!string.IsNullOrEmpty(fileUrl))
                {
                    //Delete Old
                    if (model.IsDeleteOld)
                    {
                        var oldAttachmentList = (await _documentAppService.GetAllBusinessDocumentAttachments(null, model.BusinessDocumentId, model.BusinessEntityId)).Items;
                        foreach (var oldAttachment in oldAttachmentList)
                        {
                            await _documentAppService.DeleteBusinessDocumentAttachment(new BusinessDocumentAttachmentDto() { Id = oldAttachment.Id });
                        }
                    }

                    var businessDocumentAttachmentDto = new BusinessDocumentAttachmentDto()
                    {
                        BusinessDocumentId = model.BusinessDocumentId,
                        BusinessEntityId = model.BusinessEntityId,
                        FilePath = fileUrl,
                        FileName = System.IO.Path.GetFileNameWithoutExtension(model.Image.FileName),
                        FileExt = System.IO.Path.GetExtension(model.Image.FileName),
                        Order = 0
                    };
                    var attachment = await _documentAppService.CreateBusinessDocumentAttachment(businessDocumentAttachmentDto);
                    if (attachment.Id > 0)
                    {
                        if (!string.IsNullOrEmpty(profilePhotoPath))//Profile Photo
                        {
                            ChangeProfilePhotoDto changeProfilePhotoDto = new ChangeProfilePhotoDto() { Id = model.BusinessEntityId, ProfilePhotoPath = businessDocumentAttachmentDto.Id.ToString() };
                            await _userAppService.UpdateProfilePhoto(changeProfilePhotoDto);
                        }
                        return new AjaxResponse() { Success = true, Result = attachment };
                    }
                    else
                        return new AjaxResponse(new ErrorInfo() { Message = "AttachmentNotAdded" });
                }
            }
            return new AjaxResponse(new ErrorInfo() { Message = "Errors" });
        }
        [HttpGet]
        public async Task<ActionResult> Get(string picEnyc)
        {
            var id = Convert.ToInt32(CryptoEngine.DecryptString(picEnyc)); 
            var attachmentList = await _documentAppService.GetAllBusinessDocumentAttachments(id, null, null);
            if (attachmentList.Items.Count > 0)
            {
                var attachment = attachmentList.Items.First();
                var contentType = string.Empty;
                var fileExt = attachment.FileExt.ToLower();
                switch (fileExt)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        contentType = "image/png";
                        break;

                }
                return PhysicalFile(attachment.FilePath, contentType);
            }
            return null;
        }
        public async Task<AjaxResponse> Delete([FromBody]DeleteVModel model)
        {
            var businessDocumentAttachmentDto = new BusinessDocumentAttachmentDto()
            {
                Id = model.AttachmentId,
                BusinessEntityId = model.BusinessEntityId,
                BusinessDocumentId = model.BusinessDocumentId
            };
            var result = await _documentAppService.DeleteBusinessDocumentAttachment(businessDocumentAttachmentDto);
            return new AjaxResponse() { Success = result };
        }

        private string UploadedFile(UploadVModel model, out string modulePhotoUrl)
        {
            modulePhotoUrl = string.Empty;
            string filePath = string.Empty;
            var user = _userManager.GetUserById(AbpSession.UserId.Value);
            var rootImagesFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Images");

            if (model.Image != null)
            {
                string subFolder = string.Empty;
                var businessDocument = _documentAppService.GetAllBusinessDocuments(model.BusinessDocumentId, null, null).Result.Items.FirstOrDefault();
                var module = _lookupAppService.GetAllLookDetail(null, null, businessDocument.BusinessEntityLKDId).Result.Items.FirstOrDefault();
                if (module != null)
                {
                    if (module.LookUpDetailConst.Equals(LookUpDetailConst.PersonalDetail))
                    {
                        subFolder = "profile";
                    }
                    else if (module.LookUpDetailConst.Equals(LookUpDetailConst.PhotoTracking))
                    {
                        subFolder = "tracking";
                        //subFolder = string.Format("{0}/{1}", "tracking", user.FullName);
                    }
                }

                var subModuleFolder = Path.Combine(rootImagesFolder, subFolder); 
                //Module Folder
                bool subModuleFolderExists = System.IO.Directory.Exists(subModuleFolder); 
                if (!subModuleFolderExists)
                    System.IO.Directory.CreateDirectory(subModuleFolder);
                //User Folder
                var userFolder = Path.Combine(subModuleFolder, user.UserName); 
                bool userFolderExists = System.IO.Directory.Exists(userFolder);
                if (!userFolderExists)
                    System.IO.Directory.CreateDirectory(userFolder);

               
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                filePath = Path.Combine(userFolder, uniqueFileName);

                //Update user ProfilePath in User table
                if (module != null)
                {
                    if (module.LookUpDetailConst.Equals(LookUpDetailConst.PersonalDetail))
                    {
                        modulePhotoUrl = Path.Combine(userFolder, uniqueFileName);
                    }
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return filePath;
        }
    }
}
