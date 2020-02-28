using Mmu.Mlh.SharePointAccess.Areas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Environments.Services
{
    internal interface ISpEnvironmentFactory
    {
        SpEnvironment Create(string relativeSubSitePath);
    }
}