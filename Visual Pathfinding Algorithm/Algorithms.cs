using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Pathfinding_Algorithm
{
  public static class Algorithms
  {
    public static List<Node?> Nodes { get; set; } = new();

    public static void UseDjikstras()
    {
      
    }

    public static void UseAStar()
    {
      
    }

    public static Node? AppendNodes(List<Node?> nodes)
    {
      try
      {
        if (nodes is null) { throw new Exception("Nodes are Null."); }

        Node? curr = nodes[0];

        for (int i = 0; i < nodes.Count; i++)
        {
          if (i + 1 <= nodes.Count)
          {
            curr.Next = nodes[i + 1];
          }
        }

        foreach (Node? node in nodes)
        {
          
        }

        return curr;
      }
      catch
      {
        return null;
      }
    }

    public static void UseLine()
    {
      try
      {
        if (Nodes is null || Nodes.Count == 0) { throw new Exception(); }
        Node? nodes = AppendNodes(Nodes);

        Node? currNode = nodes;
        currNode.Highlight(true);
        currNode = currNode.Next;

        while (currNode != null)
        {
          currNode.Highlight(true);
          currNode = currNode.Next;
        }
      }
      catch
      {

      }
    }
  }
}
