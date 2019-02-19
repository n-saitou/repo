using ResultContent.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ResultContent
{
    public class ResultContentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ResultContent", typeof(Result));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}