using Acme.SimpleTaskApp.Common;
using AliFitnessAE.AppService;
using AliFitnessAE.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliFitnessAE.Common
{
    public class Helper
    {
        private readonly ILookupAppService _lookupAppService;
        private readonly double CmToFeetMultiplier = 0.0328;//*
        private readonly double CmToInchMultiplier = 0.3937;
        private readonly double InchesToCMMultiplier = 2.54;
        private readonly double InchesToFeetDivider = 12;
        private readonly double FeetToCmMultiplier = 30.48;
        private readonly double KgToLbMultiplier = 2.205;
        private readonly double LbToKgMultiplier = 0.45359237;
        
       
        public Helper(ILookupAppService lookupAppService)
        {
            _lookupAppService = lookupAppService;
        }
        public decimal ConvertToTargetScale(decimal value, int currentScaleLkdId, int targetScaleLkdId)
        {
            var currentScaleLkd = _lookupAppService.GetAllLookDetail(null, null, currentScaleLkdId).Result.Items.FirstOrDefault();
            var targetScaleLkd = _lookupAppService.GetAllLookDetail(null, null, targetScaleLkdId).Result.Items.FirstOrDefault();
            if (currentScaleLkd != null)
            {
                switch (currentScaleLkd.LookUpDetailConst)
                {
                    case LookUpDetailConst.Cm:
                        switch (targetScaleLkd.LookUpDetailConst)
                        {
                            case LookUpDetailConst.Feet:
                                var valueInFeet = Math.Round(Convert.ToDecimal(CmToFeetMultiplier) * value, 1);
                                return valueInFeet;
                            case LookUpDetailConst.Inches:
                                var valueInInch = Math.Round(Convert.ToDecimal(CmToInchMultiplier) * value, 1);
                                return valueInInch;
                            default:
                                return value;
                        }
                    case LookUpDetailConst.Inches:
                        switch (targetScaleLkd.LookUpDetailConst)
                        {
                            case LookUpDetailConst.Cm:
                                var valueInCm = Math.Round(Convert.ToDecimal(InchesToCMMultiplier) * value, 1);
                                return valueInCm;
                            case LookUpDetailConst.Feet:
                                var valueInFeet = Math.Round((value / Convert.ToDecimal(InchesToFeetDivider)), 1);
                                return valueInFeet;
                            default:
                                return value;
                        }
                    case LookUpDetailConst.Feet:
                        switch (targetScaleLkd.LookUpDetailConst)
                        {
                            case LookUpDetailConst.Cm:
                                var valueInCm = Math.Round(Convert.ToDecimal(FeetToCmMultiplier) * value, 1);
                                return valueInCm;
                            case LookUpDetailConst.Inches:
                                var valueInInches = Math.Round(Convert.ToDecimal(InchesToFeetDivider) * value, 1);
                                return valueInInches;
                            default:
                                return value;
                        }
                    case LookUpDetailConst.Kg:
                        switch (targetScaleLkd.LookUpDetailConst)
                        {
                            case LookUpDetailConst.Lb:
                                var valueInLb = Math.Round(Convert.ToDecimal(KgToLbMultiplier) * value, 1);
                                return valueInLb; 
                            default:
                                return value;
                        }
                    case LookUpDetailConst.Lb:
                        switch (targetScaleLkd.LookUpDetailConst)
                        {
                            case LookUpDetailConst.Kg:
                                var valueInKg = Math.Round(Convert.ToDecimal(LbToKgMultiplier) * value, 1);
                                return valueInKg;
                            default:
                                return value;
                        }
                        //END :Inner Switch : CM 

                } //End Outer Switch
            }

            return 0;
        }
    }
}
