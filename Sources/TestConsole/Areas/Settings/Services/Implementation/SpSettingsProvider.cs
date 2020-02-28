using System;
using System.IO;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;
using Mmu.Mlh.SettingsProvisioning.Areas.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Dtos;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services;

namespace Mmu.Mlh.SharePointAccess.TestConsole.Areas.Settings.Services.Implementation
{
    public class SpSettingsProvider : ISpSettingsProvider
    {
        public SpSettingsDto Settings { get; }

        public SpSettingsProvider(ISettingsFactory settingsFactory)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new SettingsConfiguration(
                "AppSettings",
                environmentName,
                GetCodeBasePath(),
                "Apps/SharePointAccess");

            Settings = settingsFactory.CreateSettings<SpSettingsDto>(config);
        }

        private static string GetCodeBasePath()
        {
            var codeBase = typeof(SpSettingsProvider).Assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = Path.GetDirectoryName(result);

            return result;
        }
    }
}