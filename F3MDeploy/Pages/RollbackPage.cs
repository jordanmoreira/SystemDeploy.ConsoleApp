using EasyConsole;

namespace F3MDeploy.Pages
{
    class RollbackPage : MenuPage
    {
        public RollbackPage(Program program)
            : base("Efetuar rollback", program,
                  new Option("WTE", () => program.NavigateTo<DeployPage>()),
                  new Option("3J", () => program.NavigateTo<DeployPage>()))
        {
        }
    }
}
