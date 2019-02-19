using BlankApp2.Connection;
using BlankApp2.Notifications;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System.Windows;
using Unity;

namespace BlankApp2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public InteractionRequest<ILoginNotification> LoginNotificationRequest { get; set; }
        public DelegateCommand LoginNotificationCommand { get; private set; }

        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        public MainWindowViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            LoginNotificationRequest = new InteractionRequest<ILoginNotification>();
            LoginNotificationCommand = new DelegateCommand(RaiseLoginInteraction);

            _container = container;
            _eventAggregator = eventAggregator;
        }

        void RaiseLoginInteraction()
        {
            LoginNotificationRequest.Raise(new LoginNotification { Title = "Login" }, r =>
            {
                if (r.Confirmed)
                {
                    _eventAggregator.GetEvent<PubSubEvent>().Publish();
                }
            });
        }

    }
}
