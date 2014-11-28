using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.View.Data
{
    public interface INode
    {
        string Header { get; set; }
        IEnumerable<INode> Nodes { get; set; }
        object Instance { get; set; }
    }
}
