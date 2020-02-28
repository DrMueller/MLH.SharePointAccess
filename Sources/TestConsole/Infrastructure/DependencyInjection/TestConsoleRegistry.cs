using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services;
using Mmu.Mlh.SharePointAccess.TestConsole.Areas.Settings.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.SharePointAccess.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestConsoleRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();

                    scanner.WithDefaultConventions();
                });

            For<ISpSettingsProvider>().Use<SpSettingsProvider>().Singleton();
        }
    }
}