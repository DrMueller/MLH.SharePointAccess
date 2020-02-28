using System;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Dtos
{
    public class SpSecuritySettingsDto
    {
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }
        public SecurityType SecurityType { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}