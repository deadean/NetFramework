using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.View.Data
{
    public class Node:INode
    {
        public string Header
        {
            get;
            set;
        }

        public IEnumerable<INode> Nodes
        {
            get;
            set;
        }


        public object Instance
        {
            get;
            set;
        }
    }
}
