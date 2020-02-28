using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Services.Implementation
{
    internal class SpEnvironmentFactory : ISpEnvironmentFactory
    {
        private readonly ISpSettingsProvider _spSettingsProvider;

        public SpEnvironmentFactory(ISpSettingsProvider spSettingsProvider)
        {
            _spSettingsProvider = spSettingsProvider;
        }

        public SpEnvironment Create(string relativeSubSitePath)
        {
            var settings = _spSettingsProvider.Settings;

            return new SpEnvironment(
                settings.TenantId,
                settings.BaseUrl,
                relativeSubSitePath);
        }
    }
}