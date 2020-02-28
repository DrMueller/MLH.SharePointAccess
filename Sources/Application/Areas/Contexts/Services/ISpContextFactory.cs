using System.Threading.Tasks;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Services
{
    public interface ISpContextFactory
    {
        Task<ISpContext> CreateAsync(string relativeSubSitePath);
    }
}