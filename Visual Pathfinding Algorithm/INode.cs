using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Pathfinding_Algorithm
{
  public interface INode
  {
    public Node? Next { get; set; }
    public object? Data { get; set; }
  }
}
