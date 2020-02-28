using Microsoft.SharePoint.Client;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Models.Implementation
{
    internal class SpContext : ISpContext
    {
        private readonly ClientContext _clientContext;

        public SpContext(ClientContext clientContext)
        {
            _clientContext = clientContext;
        }
    }
}