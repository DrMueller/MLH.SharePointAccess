using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Services;

namespace Mmu.Mlh.SharePointAccess.TestConsole.Areas.Commands
{
    public class GetList : IConsoleCommand
    {
        private readonly ISpContextFactory _spContextFactory;
        public string Description { get; } = "Get a List";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public GetList(ISpContextFactory spContextFactory)
        {
            _spContextFactory = spContextFactory;
        }

        public async Task ExecuteAsync()
        {
            var spContext = await _spContextFactory.CreateAsync("sites/ac");
        }
    }
}