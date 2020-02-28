using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services.Servants
{
    internal interface ISecurityInitializer
    {
        Task InitializeSecurityAsync(SpEnvironment spEnvironment, ClientContext clientContext);
    }
}