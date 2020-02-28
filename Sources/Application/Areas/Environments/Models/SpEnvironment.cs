using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.SharePointAccess.Areas.Environments.Models
{
    internal class SpEnvironment
    {
        private const string SharePointPrincipal = "00000003-0000-0ff1-ce00-000000000000";
        public Uri FullContextUrl { get; }
        public string RelativeSubSitePath { get; }
        public string ResourceIdentifier { get; }
        public Guid TenantId { get; }

        public SpEnvironment(
            Guid tenantId,
            Uri baseUrl,
            string relativeSubSitePath = null)
        {
            Guard.ValueNotDefault(() => tenantId);
            Guard.ObjectNotNull(() => baseUrl);

            TenantId = tenantId;
            RelativeSubSitePath = relativeSubSitePath ?? string.Empty;

            FullContextUrl = new Uri(baseUrl, RelativeSubSitePath);
            ResourceIdentifier = $"{SharePointPrincipal}/{baseUrl.Host}@{TenantId}";
        }
    }
}