using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services
{
    public interface IClientContextFactory
    {
        Task<ClientContext> CreateAsync(string relativeSubSitePath);
    }
}