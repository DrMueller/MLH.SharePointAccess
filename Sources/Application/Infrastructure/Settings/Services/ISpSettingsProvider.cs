using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Dtos;

namespace Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services
{
    public interface ISpSettingsProvider
    {
        SpSettingsDto Settings { get; }
    }
}