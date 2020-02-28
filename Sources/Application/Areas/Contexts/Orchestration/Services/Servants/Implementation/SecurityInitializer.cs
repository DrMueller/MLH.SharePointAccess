using System.Security;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Services;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Dtos;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Servants.Implementation
{
    internal class SecurityInitializer : ISecurityInitializer
    {
        private readonly IBearerTokenFactory _bearerTokenFactory;
        private readonly ISpSettingsProvider _spSettingsProvider;

        public SecurityInitializer(
            IBearerTokenFactory bearerTokenFactory,
            ISpSettingsProvider spSettingsProvider)
        {
            _bearerTokenFactory = bearerTokenFactory;
            _spSettingsProvider = spSettingsProvider;
        }

        public async Task InitializeSecurityAsync(SpEnvironment spEnvironment, ClientContext clientContext)
        {
            var securitySettings = _spSettingsProvider.Settings.Security;

            if (securitySettings.SecurityType == SecurityType.Credentials)
            {
                InitializeCredentialsSecurity(securitySettings, clientContext);
            }
            else
            {
                await InitializeTokenSecurityAsync(spEnvironment, clientContext);
            }
        }

        private static void InitializeCredentialsSecurity(
            SpSecuritySettingsDto securitySettings,
            ClientRuntimeContext clientContext)
        {
            var secString = new SecureString();
            securitySettings.UserPassword.ForEach(c => secString.AppendChar(c));

            clientContext.Credentials = new SharePointOnlineCredentials(
                securitySettings.UserName,
                secString);
        }

        private async Task InitializeTokenSecurityAsync(
            SpEnvironment spEnvironment,
            ClientRuntimeContext clientContext)
        {
            var bearerToken = await _bearerTokenFactory.CreateAsync(spEnvironment);
            clientContext.ExecutingWebRequest +=
                (_, request) => request.WebRequestExecutor.RequestHeaders["Authorization"] =
                    "Bearer " + bearerToken.AccessToken;
        }
    }
}