using System;
using System.Collections.Generic;
using System.Text;

namespace AliFitnessAE.Dto
{
    public class UpdateTrackingStatusRequest
    {
        public int Id { get; set; }
        public bool IsApprove { get; set; }
    }
}
