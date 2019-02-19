using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeSource;

namespace ResultContent.ViewModels
{
    public class ResultViewModel : BindableBase
    {
        private string _inputSql = "write sql";
        public string InputSql
        {
            get { return _inputSql; }
            set { SetProperty(ref _inputSql, value); }
        }

        private ObservableCollection<string> _nodeNames;
        public ObservableCollection<string> NodeNames
        {
            get { return _nodeNames; }
            set { SetProperty(ref _nodeNames, value); }
        }

        public ResultViewModel(IEventAggregator eventAggregator)
        {
            NodeNames = new ObservableCollection<string>();

            eventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(NodeNameReceived, ThreadOption.UIThread);
        }

        void NodeNameReceived(string name)
        {
            NodeNames.Add(name);
        }
    }
}
