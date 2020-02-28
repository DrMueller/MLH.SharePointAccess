using Mmu.Mlh.SharePointAccess.Areas.BearerTokens.Services;
using Mmu.Mlh.SharePointAccess.Areas.BearerTokens.Services.Implementation;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Services;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Implementation;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Servants;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Servants.Implementation;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Services;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.SharePointAccess.Infrastructure.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            // BearerTokens
            For<IBearerTokenFactory>().Use<BearerTokenFactory>().Singleton();

            // Contexts
            For<ISpContextFactory>().Use<SpContextFactory>().Singleton();
            For<IClientContextFactory>().Use<ClientContextFactory>().Singleton();
            For<ISecurityInitializer>().Use<SecurityInitializer>().Singleton();

            // Environments
            For<ISpEnvironmentFactory>().Use<SpEnvironmentFactory>().Singleton();
        }
    }
}