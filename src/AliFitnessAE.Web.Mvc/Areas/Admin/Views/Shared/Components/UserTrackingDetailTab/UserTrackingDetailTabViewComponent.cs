using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Common.Enum;
using AliFitnessAE.Crypto;
using AliFitnessAE.Dto;
using AliFitnessAE.Web.Areas.Admin.Models.Common;
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.UserTrackingChart;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart
{
    public class UserTrackingDetailTabViewComponent : AliFitnessAEViewComponent
    {
        private readonly IUserTrackingAppService _userTrackingAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly Helper _helper;
        private readonly ChartHelper _chartHelper;
        private readonly UserManager _userManager;

        public UserTrackingDetailTabViewComponent(IUserTrackingAppService userTrackingAppService,
             ILookupAppService lookupAppService ,
             UserManager userManager)

        {
            _userTrackingAppService = userTrackingAppService;
            _lookupAppService = lookupAppService;
            _helper = new Helper(lookupAppService);
            _chartHelper = new ChartHelper(userTrackingAppService, lookupAppService, _helper);
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(UserTrackingFilter model)
        {
            //Decrypt UserId
            model.UserId = Convert.ToInt32(CryptoEngine.DecryptString(model.UserIdEnyc));
            var userTrackingDtoList = _userTrackingAppService.GetAllUserTrackingList(model).OrderBy(x=>x.CreationTime); 
            var user = userTrackingDtoList.FirstOrDefault()?.User;
            //Scale  
            if (model.BodyPart == EnumUserTrackingBodyPart.Height)
                model.MeasurementScale.ScaleHeight.Find(x => x.Value == model.MeasurementScaleLKDId.ToString()).Selected = true;
            else if (model.BodyPart == EnumUserTrackingBodyPart.Weight)
                model.MeasurementScale.ScaleWeight.Find(x => x.Value == model.MeasurementScaleLKDId.ToString()).Selected = true;
            else
                model.MeasurementScale.ScaleOther.Find(x => x.Value == model.MeasurementScaleLKDId.ToString()).Selected = true;


            var result = new UserTrackingDetailTabViewModel()
            {
                User = user,
                BodyPart = model.BodyPart,
                MeasurementScale = model.MeasurementScale,
                Chart = GetChart(userTrackingDtoList, model),
                UserTrackingDetail = userTrackingDtoList.Select(p => new UserTrackingDetailVModel()
                {
                    Status = p.Status,
                    CreationTime = p.CreationTime,
                    BodyPartValueAndScale = GetBodyPartValueByEnum(p, model.BodyPart),
                    BodyPartProgress = ""
                }).ToList(), 
            };
            if (result.Chart != null)
                result.Chart.HtmlControlId = "divProfileChartId";
            return View(result);
        }
        private ChartJsVModel GetChart(IEnumerable<UserTrackingDto> userTrackingList, UserTrackingFilter filter)
        {
            var model = new UserTrackingChartViewModel()
            {
                BodyPart = filter.BodyPart,
                UserTrackingBodyPart = filter.BodyPart,
                MeasurementScaleLKDId = filter.MeasurementScaleLKDId,
                ChartType = filter.ChartType
            };
            return _chartHelper.LoadChart(userTrackingList, model);
        }
        private Tuple<decimal, string> GetBodyPartValueByEnum(UserTrackingDto data, EnumUserTrackingBodyPart bodyPart)
        {
            switch (bodyPart)
            {
                case EnumUserTrackingBodyPart.Height:
                    return Tuple.Create(data.Height, _lookupAppService.GetAllLookDetail(null, null, data.HeightLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.Weight:
                    return Tuple.Create(data.Weight, _lookupAppService.GetAllLookDetail(null, null, data.WeightLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.Hip:
                    return Tuple.Create(data.Hip, _lookupAppService.GetAllLookDetail(null, null, data.HipLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.BellyButtonWaist:
                    return Tuple.Create(data.BellyButtonWaist, _lookupAppService.GetAllLookDetail(null, null, data.BellyButtonWaistLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.HipBoneWaist:
                    return Tuple.Create(data.HipBoneWaist, _lookupAppService.GetAllLookDetail(null, null, data.HipBoneWaistLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.Chest:
                    return Tuple.Create(data.Chest, _lookupAppService.GetAllLookDetail(null, null, data.ChestLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.RightArm:
                    return Tuple.Create(data.RightArm, _lookupAppService.GetAllLookDetail(null, null, data.RightArmLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.LeftArm:
                    return Tuple.Create(data.LeftArm, _lookupAppService.GetAllLookDetail(null, null, data.LeftArmLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.RightThigh:
                    return Tuple.Create(data.RightThigh, _lookupAppService.GetAllLookDetail(null, null, data.RightThighLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.LeftThigh:
                    return Tuple.Create(data.LeftThigh, _lookupAppService.GetAllLookDetail(null, null, data.LeftThighLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.RightCalve:
                    return Tuple.Create(data.RightCalve, _lookupAppService.GetAllLookDetail(null, null, data.RightCalveLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.LeftCalve:
                    return Tuple.Create(data.LeftCalve, _lookupAppService.GetAllLookDetail(null, null, data.LeftCalveLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.RightForeArm:
                    return Tuple.Create(data.RightForeArm, _lookupAppService.GetAllLookDetail(null, null, data.RightForeArmLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                case EnumUserTrackingBodyPart.LeftForeArm:
                    return Tuple.Create(data.LeftForeArm, _lookupAppService.GetAllLookDetail(null, null, data.LeftForeArmLkdId).Result.Items.FirstOrDefault()?.LookUpDetailConst);
                default: return Tuple.Create((decimal)0, "");
            }
        }
    }
}