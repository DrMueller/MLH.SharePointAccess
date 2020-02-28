using System.Security;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.SharePointAccess.Areas.BearerTokens.Services;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Servants.Implementation
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
                var secString = new SecureString();
                securitySettings.UserPassword.ForEach(c => secString.AppendChar(c));

                clientContext.Credentials = new SharePointOnlineCredentials(
                    securitySettings.UserName,
                    secString);
            }
            else
            {
                var bearerToken = await _bearerTokenFactory.CreateAsync(spEnvironment);
                clientContext.ExecutingWebRequest +=
                    (_, request) => request.WebRequestExecutor.RequestHeaders["Authorization"] =
                        "Bearer " + bearerToken.AccessToken;
            }
        }
    }
}