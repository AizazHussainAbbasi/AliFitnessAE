using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService.Document;
using AliFitnessAE.AppService.TopicContent;
using AliFitnessAE.Web.Admin.Views;
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader
{
    public class DocumentUploaderViewComponent : AliFitnessAEViewComponent
    {
        private readonly IDocumentAppService _documentAppService;
        private readonly ILookupAppService _lookupAppService;

        public DocumentUploaderViewComponent(IDocumentAppService documentAppService,
            ILookupAppService lookupAppService)
        {
            _documentAppService = documentAppService;
            _lookupAppService = lookupAppService;
        }
        public async Task<IViewComponentResult> InvokeAsync(ViewComponentVModel model)
        {
            try
            {
                var userTrackingLKDId = (await _lookupAppService.GetAllLookDetail(null, model.Module)).Items.FirstOrDefault().Id;
                var businessDocumentList = (await _documentAppService.GetAllBusinessDocuments(null, userTrackingLKDId, null)).Items.ToList();

                foreach (var businessDoc in businessDocumentList)
                    businessDoc.BusinessDocumentAttachmentDto =   _documentAppService.GetAllBusinessDocumentAttachments(null, businessDoc.Id, model.BusinessEntityId).Result.Items.ToList();

                var documentModel = new DocumentUploaderViewModel()
                {
                    BusinessEntityId = model.BusinessEntityId,
                    DocumentList = businessDocumentList,
                    IsReadOnly = model.IsReadOnly
                };
                return View(documentModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
