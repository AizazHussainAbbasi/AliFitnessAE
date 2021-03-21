using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService;
using AliFitnessAE.Common;
using AliFitnessAE.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart
{
    public class UserTrackingChartViewComponent : AliFitnessAEViewComponent
    {
        private readonly IUserTrackingAppService _userTrackingAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly Helper _helper;
        private readonly ChartHelper _chartHelper;
        public UserTrackingChartViewComponent(IUserTrackingAppService userTrackingAppService,
             ILookupAppService lookupAppService)
        {
            _userTrackingAppService = userTrackingAppService;
            _lookupAppService = lookupAppService;
            _helper = new Helper(lookupAppService);
            _chartHelper = new ChartHelper(userTrackingAppService, lookupAppService, _helper);
        }

        public async Task<IViewComponentResult> InvokeAsync(UserTrackingChartViewModel model)
        {
            if (!model.UserId.HasValue)
                model.UserId = (int)AbpSession.UserId.Value;
            var userTrackingList = _userTrackingAppService.GetAllUserTrackingList(new PagedResultRequestExtDto() { UserId = model.UserId, FromDate = model.FromDate, ToDate = model.ToDate }).OrderBy(x => x.CreationTime);
            var chartVModel = _chartHelper.LoadChart(userTrackingList, model);
            return View(chartVModel);
        }

        //private UserTrackingChartOutPutVModel LoadUserTrackingData(IOrderedEnumerable<UserTrackingDto> userTrackingList, UserTrackingChartViewModel model)
        //{
        //    //var userTrackingList = _userTrackingAppService.GetAllUserTrackingList(new PagedResultRequestExtDto() { UserId = model.UserId, FromDate = model.FromDate, ToDate = model.ToDate }).OrderBy(x => x.CreationTime);
        //    //var _chartHelper = new ChartHelper(_userTrackingAppService, _lookupAppService, _helper);
        //    var result = _chartHelper.GetUserTrackingChartData(userTrackingList, model.UserTrackingBodyPart, model.MeasurementScaleLKDId);
        //    return result;
        //}
        //public UserTrackingChartOutPutVModel GetUserTrackingChartData(IEnumerable<UserTrackingDto> userTrackingList, EnumUserTrackingBodyPart bodyPart, int Id)
        //{
        //    var resultList = new UserTrackingChartOutPutVModel();
        //    var targetScaleLkd = _lookupAppService.GetAllLookDetail(null, null, Id).Result.Items.FirstOrDefault();

        //    switch (bodyPart)
        //    {
        //        case EnumUserTrackingBodyPart.Height:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.Height, x.HeightLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("Height"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.Weight:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.Weight, x.WeightLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("Weight"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.Hip:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.Hip, x.HipLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("Hip"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.BellyButtonWaist:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.BellyButtonWaist, x.BellyButtonWaistLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("BellyButtonWaist"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.HipBoneWaist:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.HipBoneWaist, x.HipBoneWaistLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("HipBoneWaist"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.Chest:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.Chest, x.ChestLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("Chest"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.RightArm:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.RightArm, x.RightArmLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("RightArm"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.LeftArm:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.LeftArm, x.LeftArmLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("LeftArm"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.RightThigh:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.RightThigh, x.RightThighLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("RightThigh"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.LeftThigh:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.LeftThigh, x.LeftThighLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("LeftThigh"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.RightCalve:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.RightCalve, x.RightCalveLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("RightCalve"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.LeftCalve:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.LeftCalve, x.LeftCalveLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("LeftCalve"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.RightForeArm:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.RightForeArm, x.RightForeArmLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("RightForeArm"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //        case EnumUserTrackingBodyPart.LeftForeArm:
        //            resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { count = _helper.ConvertToTargetScale(x.LeftForeArm, x.LeftForeArmLkdId,targetScaleLkd.Id), date = x.CreationTime }).ToList();
        //            resultList.scaleText = String.Format("{0} in {1}", L("LeftForeArm"), targetScaleLkd.LookUpDetailConst);
        //            break;
        //    }
        //    return resultList;
        //}
        //private string LoadChartJsonString()
        //{
        //    return @"
        //    {
        //        type: 'line',
        //        responsive: true,
        //        data:
        //        {
        //            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
        //            datasets: [{
        //                label: '# of Votes',
        //                data: [12, 19, 3, 5, 2, 3],
        //                backgroundColor: 'rgba(255, 99, 132, 0.2)',
        //                borderColor: 'rgba(255,99,132,1)',
        //                borderWidth: 2
        //            }]
        //        },
        //        options:
        //        {
        //            scales:
        //            {
        //                yAxes: [{
        //                    ticks:
        //                    {
        //                        beginAtZero: true
        //                    }
        //                }]
        //            }
        //        }
        //    }";
        //}
    }
}