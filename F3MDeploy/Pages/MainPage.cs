using EasyConsole;

namespace F3MDeploy.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(Program program)
             : base("Escolha a operação desejada.", program,
                   new Option("Deploy", () => program.NavigateTo<DeployPage>()),
                   new Option("Rollback", () => program.NavigateTo<RollbackPage>()))
        {
        }
    }
}
