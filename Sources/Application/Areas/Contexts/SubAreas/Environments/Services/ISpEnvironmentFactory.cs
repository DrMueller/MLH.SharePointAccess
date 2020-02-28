using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Services
{
    internal interface ISpEnvironmentFactory
    {
        SpEnvironment Create(string relativeSubSitePath);
    }
}