using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService;
using AliFitnessAE.Common;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Dto;
using AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliFitnessAE.Web.Areas.Admin.Models.Common
{
    public class ChartHelper : AliFitnessAEAppServiceBase
    {
        private readonly IUserTrackingAppService _userTrackingAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly Helper _helper;
        public ChartHelper(IUserTrackingAppService userTrackingAppService,
             ILookupAppService lookupAppService,
             Helper helper)
        {
            _userTrackingAppService = userTrackingAppService;
            _lookupAppService = lookupAppService;
            _helper = helper;
        }
        public ChartJsVModel LoadChart(IEnumerable<UserTrackingDto> userTrackingList, UserTrackingChartViewModel model)
        {
            var resultList = LoadUserTrackingData(userTrackingList, model);
            var lebels = resultList.list.Select(x => x.date.ToShortDateString());
            var data = resultList.list.Select(x => x.count);
            //  var _chartHelper = new ChartHelper(_userTrackingAppService, _lookupAppService, _helper);
            var chartJsonString = LoadChartJsonString();
            var chart = JsonConvert.DeserializeObject<ChartJs>(chartJsonString);
            if (!String.IsNullOrEmpty(model.ChartType))
                chart.type = model.ChartType;
            chart.data.labels = lebels.ToList();
            chart.data.datasets.First().data = data.ToList();
            chart.data.datasets.First().label = resultList.scaleText;
            var chartModel = new ChartJsVModel
            {
                HtmlControlId = model.HtmlControlId,
                Chart = chart,
                ChartJson = JsonConvert.SerializeObject(chart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                })
            };
            return chartModel;
        }
        private UserTrackingChartOutPutVModel LoadUserTrackingData(IEnumerable<UserTrackingDto> userTrackingList, UserTrackingChartViewModel model)
        {
            //var userTrackingList = _userTrackingAppService.GetAllUserTrackingList(new PagedResultRequestExtDto() { UserId = model.UserId, FromDate = model.FromDate, ToDate = model.ToDate }).OrderBy(x => x.CreationTime);
            //var _chartHelper = new ChartHelper(_userTrackingAppService, _lookupAppService, _helper);
            var result = GetUserTrackingChartData(userTrackingList, model.UserTrackingBodyPart, model.MeasurementScaleLKDId);
            return result;
        }
        private UserTrackingChartOutPutVModel GetUserTrackingChartData(IEnumerable<UserTrackingDto> userTrackingList, EnumUserTrackingBodyPart bodyPart, int Id)
        {
            var resultList = new UserTrackingChartOutPutVModel();
            var targetScaleLkd = _lookupAppService.GetAllLookDetail(null, null, Id).Result.Items.FirstOrDefault();

            switch (bodyPart)
            {
                case EnumUserTrackingBodyPart.Height:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.Height, x.HeightLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("Height"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.Height = item.count;
                        userTracking.HeightLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.Weight:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.Weight, x.WeightLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("Weight"), targetScaleLkd.LookUpDetailConst);
                    var a = L("Weight");
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.Weight = item.count;
                        userTracking.WeightLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.Hip:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.Hip, x.HipLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("Hip"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.Hip = item.count;
                        userTracking.HipLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.BellyButtonWaist:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.BellyButtonWaist, x.BellyButtonWaistLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("BellyButtonWaist"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.BellyButtonWaist = item.count;
                        userTracking.BellyButtonWaistLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.HipBoneWaist:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.HipBoneWaist, x.HipBoneWaistLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("HipBoneWaist"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.HipBoneWaist = item.count;
                        userTracking.HipBoneWaistLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.Chest:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.Chest, x.ChestLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("Chest"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.Chest = item.count;
                        userTracking.ChestLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.RightArm:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.RightArm, x.RightArmLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("RightArm"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.RightArm = item.count;
                        userTracking.RightForeArmLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.LeftArm:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.LeftArm, x.LeftArmLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("LeftArm"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.LeftArm = item.count;
                        userTracking.LeftForeArmLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.RightThigh:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.RightThigh, x.RightThighLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("RightThigh"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.RightThigh = item.count;
                        userTracking.RightThighLkdId = targetScaleLkd.Id;
                    }
                    break;
                case EnumUserTrackingBodyPart.LeftThigh:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.LeftThigh, x.LeftThighLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("LeftThigh"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.LeftThigh = item.count;
                        userTracking.LeftThighLkdId = targetScaleLkd.Id;
                    }
                    break; 
                case EnumUserTrackingBodyPart.RightCalve:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.RightCalve, x.RightCalveLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("RightCalve"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.RightCalve = item.count;
                        userTracking.RightCalveLkdId = targetScaleLkd.Id;
                    }
                    break; 
                case EnumUserTrackingBodyPart.LeftCalve:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.LeftCalve, x.LeftCalveLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("LeftCalve"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.LeftCalve = item.count;
                        userTracking.LeftCalveLkdId = targetScaleLkd.Id;
                    } 
                    break;
                case EnumUserTrackingBodyPart.RightForeArm:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.RightForeArm, x.RightForeArmLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("RightForeArm"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.RightForeArm = item.count;
                        userTracking.RightForeArmLkdId = targetScaleLkd.Id;
                    }
                    break; 
                case EnumUserTrackingBodyPart.LeftForeArm:
                    resultList.list = userTrackingList.Select(x => new UserTrackingMeasurementListVModel { id = x.Id, count = _helper.ConvertToTargetScale(x.LeftForeArm, x.LeftForeArmLkdId, targetScaleLkd.Id), date = x.CreationTime }).ToList();
                    resultList.scaleText = String.Format("{0} in {1}", L("LeftForeArm"), targetScaleLkd.LookUpDetailConst);
                    foreach (var item in resultList.list)
                    {
                        var userTracking = userTrackingList.Where(x => x.Id == item.id).First();
                        userTracking.LeftForeArm = item.count;
                        userTracking.LeftForeArmLkdId = targetScaleLkd.Id;
                    }
                    break; 
            }
            return resultList;
        }
        private string LoadChartJsonString()
        {
            return @"
            {
                type: 'line',
                responsive: true,
                data:
                {
                    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
                    datasets: [{
                        label: '# of Votes',
                        data: [12, 19, 3, 5, 2, 3],
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        borderColor: 'rgba(255,99,132,1)',
                        borderWidth: 2
                    }]
                },
                options:
                {
                    scales:
                    {
                        yAxes: [{
                            ticks:
                            {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            }";
        }
    }
}
