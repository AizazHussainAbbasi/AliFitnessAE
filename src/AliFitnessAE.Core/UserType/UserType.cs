using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AliFitnessAE.UserTypeCore
{
    [Table("UserType")]
    public class UserType : FullAuditedEntity
    {
        public const int MaxNameLength = 256;
        public const int MaxBodyLength = 64 * 1024; //64KB

        [Required]
        [StringLength(MaxNameLength)]
        public string UserTypeConst { get; set; }
        [Required]
        [StringLength(MaxNameLength)]
        public string UserTypeName { get; set; }
         
        public UserType()
        {
            CreationTime = Clock.Now;
        }

        public UserType(string userTypeConst, string userTypeName)
            : this()
        {
            UserTypeConst = userTypeConst;
            UserTypeName = userTypeName;
        }
    }
}
