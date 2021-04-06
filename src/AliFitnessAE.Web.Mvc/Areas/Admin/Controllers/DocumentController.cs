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

namespace AliFitnessAE.Web.Admin.Controllers
{
    [Area("Admin")]
    public class DocumentController : AliFitnessAEControllerBase
    {
        private readonly IDocumentAppService _documentAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentController(IDocumentAppService documentAppService,
             ILookupAppService lookupAppService,
             IWebHostEnvironment webHostEnvironment)
        {
            _documentAppService = documentAppService;
            _lookupAppService = lookupAppService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<AjaxResponse> Upload(UploadVModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                if (!string.IsNullOrEmpty(uniqueFileName))
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
                        FilePath = uniqueFileName,
                        FileName = System.IO.Path.GetFileNameWithoutExtension(model.Image.FileName),
                        FileExt = System.IO.Path.GetExtension(model.Image.FileName),
                        Order = 0
                    };
                    var attachment = await _documentAppService.CreateBusinessDocumentAttachment(businessDocumentAttachmentDto);
                    if (attachment.Id > 0)
                        return new AjaxResponse() { Success = true, Result = attachment };
                    else
                        return new AjaxResponse(new ErrorInfo() { Message = "AttachmentNotAdded" });
                }
            }
            return new AjaxResponse(new ErrorInfo() { Message = "Errors" });
        }
        [HttpPost]
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
        private string UploadedFile(UploadVModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
