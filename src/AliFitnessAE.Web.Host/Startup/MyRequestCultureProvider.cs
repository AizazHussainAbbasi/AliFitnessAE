using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliFitnessAE.Localization
{
    //Fot Testing purpose
    public class MyRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var result = new ProviderCultureResult(culture: (StringSegment)"en-US");
            return Task.FromResult(result);
        }
    }
}
