using System;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Dtos
{
    public class SpSettingsDto
    {
        public Uri BaseUrl { get; set; }
        public SpSecuritySettingsDto Security { get; set; }
        public Guid TenantId { get; set; }
    }
}