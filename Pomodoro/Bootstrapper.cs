using Autofac;
using Prism.Autofac;
using Pomodoro.Views;
using System.Windows;

namespace Pomodoro
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
