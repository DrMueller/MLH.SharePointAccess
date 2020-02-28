using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Servants.Implementation
{
    internal class ClientContextFactory : IClientContextFactory
    {
        private readonly ISecurityInitializer _securityInitializer;

        public ClientContextFactory(ISecurityInitializer securityInitializer)
        {
            _securityInitializer = securityInitializer;
        }

        public async Task<ClientContext> CreateAsync(SpEnvironment spEnvironment)
        {
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