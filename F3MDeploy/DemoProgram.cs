using EasyConsole;
using F3MDeploy.Pages;

namespace F3MDeploy
{
    class DemoProgram : Program
    {
        public DemoProgram() : base("Main Program aqui", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new DeployPage(this));
            AddPage(new RollbackPage(this));

            SetPage<MainPage>();
        }
    }
}
