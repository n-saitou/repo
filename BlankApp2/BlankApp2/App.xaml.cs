using BlankApp2.Connection;
using BlankApp2.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace BlankApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            var font = new System.Windows.Media.FontFamily("游ゴシック体");
            var style = new Style(typeof(Window));
            style.Setters.Add(new Setter(Window.FontFamilyProperty, font));

            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(style));
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TreeSource.TreeSourceModule>();
            moduleCatalog.AddModule<ResultContent.ResultContentModule>();
        }

    }
}
