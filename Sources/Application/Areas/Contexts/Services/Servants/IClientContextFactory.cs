using System;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Mmu.Mlh.SharePointAccess.Areas.Environments.Models;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.Services.Servants
{
    internal interface IClientContextFactory
    {
        Task<ClientContext> CreateAsync(SpEnvironment spEnvironment);
    }
}