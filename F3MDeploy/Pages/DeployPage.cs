using EasyConsole;
using F3MDeploy.Repositories;

namespace F3MDeploy.Pages
{
    class DeployPage : MenuPage
    {
        public DeployPage(Program program)
            : base("Efetuar deploy", program, 
                  new Option("WTE", () => DeployRepository.DeployWTE()),
                  new Option("3J", () => program.NavigateTo<DeployPage>()))
        {
        }
    }
}
