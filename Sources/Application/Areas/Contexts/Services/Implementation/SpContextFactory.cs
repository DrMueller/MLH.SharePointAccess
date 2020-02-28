using System.Threading.Tasks;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Models;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Models.Implementation;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Servants;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Services;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Implementation
{
    internal class SpContextFactory : ISpContextFactory
    {
        private readonly IClientContextFactory _clientContectFactory;
        private readonly ISpEnvironmentFactory _spEnvironmentFactory;

        public SpContextFactory(
            ISpEnvironmentFactory spEnvironmentFactory,
            IClientContextFactory clientContectFactory)
        {
            _spEnvironmentFactory = spEnvironmentFactory;
            _clientContectFactory = clientContectFactory;
        }

        public async Task<ISpContext> CreateAsync(string relativeSubSitePath)
        {
            var spEnvironment = _spEnvironmentFactory.Create(relativeSubSitePath);
            var clientContext = await _clientContectFactory.CreateAsync(spEnvironment);

            var collList = clientContext.Web.Lists.GetByTitle("Presentations");

            clientContext.Load(collList);
            clientContext.ExecuteQuery();

            var spContext = new SpContext(clientContext);

            return spContext;
        }
    }
}