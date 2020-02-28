using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.Orchestration.Services;

namespace Mmu.Mlh.SharePointAccess.TestConsole.Areas.Commands
{
    public class GetList : IConsoleCommand
    {
        private readonly IClientContextFactory _clientContextFactory;
        private readonly IConsoleWriter _consoleWriter;
        public string Description { get; } = "Get a List";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public GetList(
            IConsoleWriter consoleWriter,
            IClientContextFactory clientContextFactory)
        {
            _consoleWriter = consoleWriter;
            _clientContextFactory = clientContextFactory;
        }

        public async Task ExecuteAsync()
        {
            var context = await _clientContextFactory.CreateAsync("sites/ac");
            _consoleWriter.WriteLine(context.ToString());

            // https://www.c-sharpcorner.com/blogs/create-a-publishing-page-in-sharepoint-2013-using-csom
        }
    }
}