using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using AliFitnessAE.UserTypeCore;

namespace AliFitnessAE.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public UserType UserType { get; set; }
        public int? UserTypeId { get; set; } 
        public string MobileNumber { get; set; }
        public string LandLineNumber { get; set; }
        public string ZoomId { get; set; }
        public DateTime? DOB { get; set; } 
        public char? Gender { get; set; }
        public string ProfilePhotoPath { get; set; }

        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
