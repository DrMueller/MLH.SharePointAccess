using Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Implementation;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Servants;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Servants.Implementation;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Services;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Services.Implementation;
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
            For<IClientContextFactory>().Use<SpContextFactory>().Singleton();
            For<ISecurityInitializer>().Use<SecurityInitializer>().Singleton();
        }
    }
}