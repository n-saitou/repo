using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSource.Models
{
    public class Node
    {
        public string Name { get; }
        public ObservableCollection<Node> Children { get; set; }

        public Node(string name)
        {
            Name = name;
            Children = new ObservableCollection<Node>();
        }

    }
}
