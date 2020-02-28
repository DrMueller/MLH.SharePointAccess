using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Servants;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Services;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Implementation
{
    internal class SpContextFactory : IClientContextFactory
    {
        private readonly ISecurityInitializer _securityInitializer;
        private readonly ISpEnvironmentFactory _spEnvironmentFactory;

        public SpContextFactory(
            ISpEnvironmentFactory spEnvironmentFactory,
            ISecurityInitializer securityInitializer)
        {
            _spEnvironmentFactory = spEnvironmentFactory;
            _securityInitializer = securityInitializer;
        }

        public async Task<ClientContext> CreateAsync(string relativeSubSitePath)
        {
            var spEnvironment = _spEnvironmentFactory.Create(relativeSubSitePath);
            var clientContext = new ClientContext(spEnvironment.FullContextUrl)
            {
                AuthenticationMode = ClientAuthenticationMode.Anonymous,
                FormDigestHandlingEnabled = false
            };

            await _securityInitializer.InitializeSecurityAsync(spEnvironment, clientContext);
            return clientContext;
        }
    }
}