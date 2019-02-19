using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TreeSource.Models;

namespace TreeSource.ViewModels
{
    public class TreeViewModel : BindableBase
    {
        private ObservableCollection<Node> _nodeList;
        public ObservableCollection<Node> NodeList
        {
            get { return _nodeList; }
            set { SetProperty(ref _nodeList, value); }
        }

        public DelegateCommand<Node> DoubleClickCommand { get; private set; }

        public TreeViewModel(IEventAggregator eventAggregator)
        {
            NodeList = new ObservableCollection<Node>();
            var root = new Node("Item 1");
            root.Children.Add(new Node("Item 1-1"));
            root.Children.Add(new Node("Item 1-2"));

            NodeList.Add(root);

            DoubleClickCommand = new DelegateCommand<Node>(
                node => eventAggregator.GetEvent<PubSubEvent<string>>().Publish(node.Name));

            eventAggregator.GetEvent<PubSubEvent>().Subscribe(Refresh);

        }

        private void Refresh()
        {
            NodeList = new ObservableCollection<Node>();
            var root = new Node("Item ★");
            root.Children.Add(new Node("Item ★-1"));
            root.Children.Add(new Node("Item ★-2"));
            NodeList.Add(root);
        }

    }
}
