using TreeSource.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace TreeSource
{
    public class TreeSourceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("NaviTree", typeof(Tree));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}