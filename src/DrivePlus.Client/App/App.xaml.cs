using System.Windows;
using DrivePlus.Client.ViewModel;
using DrivePlus.Client.View;

namespace DrivePlus.Client.App
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainViewModel = new MainViewModel();
            new MainWindow(mainViewModel).Show();
        }
    }
}
