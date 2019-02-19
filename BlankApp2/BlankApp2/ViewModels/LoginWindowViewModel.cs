using BlankApp2.Connection;
using BlankApp2.Models;
using BlankApp2.Notifications;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace BlankApp2.ViewModels
{
    public class LoginWindowViewModel : BindableBase, IInteractionRequestAware
    {

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private ObservableCollection<Session> _sessions;
        public ObservableCollection<Session> Sessions
        {
            get { return _sessions; }
            set { SetProperty(ref _sessions, value); }
        }

        public DelegateCommand<object> LoginCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand<Session> MouseClickCommand { get; private set; }

        private IUnityContainer _container;

        public LoginWindowViewModel(IUnityContainer container)
        {
            LoginCommand = new DelegateCommand<object>(LoginInteraction);
            CancelCommand = new DelegateCommand(CancelInteraction);
            MouseClickCommand = new DelegateCommand<Session>(s => MessageBox.Show(s.HostName));

            Sessions = new ObservableCollection<Session>();

            Sessions.Add(new Session() { Name = "aiueo1", HostName = "host1" });
            Sessions.Add(new Session() { Name = "aiueo2", HostName = "host2" });
            Sessions.Add(new Session() { Name = "aiueo3", HostName = "host3" });
            Sessions.Add(new Session() { Name = "aiueo4", HostName = "host4" });


            _container = container;

        }

        void LoginInteraction(object obj)
        {

            // Since PasswordBox can not be bound, it gets it from an object
            string password = (obj as PasswordBox)?.Password;


            DataConnection conn = new DataConnection();
            conn.UserName = "test user";


            _container.RegisterInstance<IDataConnection>(conn);


            _notification.Confirmed = true;
            FinishInteraction?.Invoke();
        }

        void CancelInteraction()
        {
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }

        public Action FinishInteraction { get; set; }

        private ILoginNotification _notification;

        public INotification Notification
        {
            get { return _notification; }
            set { SetProperty(ref _notification, (ILoginNotification)value); }
        }
    }
}
