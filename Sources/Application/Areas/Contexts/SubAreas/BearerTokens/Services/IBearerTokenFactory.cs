using System.Threading.Tasks;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Models;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Services
{
    internal interface IBearerTokenFactory
    {
        Task<BearerToken> CreateAsync(SpEnvironment spEnvironment);
    }
}