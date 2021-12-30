using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Pathfinding_Algorithm
{
  public class Graph
  {
    private HashSet<Node> nodes = new HashSet<Node>();

    public void addNode(Node nodeA)
    {
      nodes.Add(nodeA);
    }
  }
}
