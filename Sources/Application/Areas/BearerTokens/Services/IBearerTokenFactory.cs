using System.Threading.Tasks;
using Mmu.Mlh.SharePointAccess.Areas.BearerTokens.Models;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.BearerTokens.Services
{
    internal interface IBearerTokenFactory
    {
        Task<BearerToken> CreateAsync(SpEnvironment spEnvironment);
    }
}