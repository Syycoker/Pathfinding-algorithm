using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Pathfinding_Algorithm
{
  public class Grid
  {
    private Node[,] gridArray;

    public Grid(int width, int height)
    {
      gridArray = new Node[width, height];

      for (int x = 0; x < gridArray.GetLength(0); x++)
      {
        for (int y = 0; y < gridArray.GetLength(1); y++)
        {
          gridArray[x, y] = new Node(this, x, y);
        }
      }
    }

    public Node GetGridObject(int x, int y)
    {
      return gridArray[x, y];
    }

    public int GetWidth()
    {
      return gridArray.GetLength(0);
    }

    public int GetHeight()
    {
      return gridArray.GetLength(1);
    }

  }
}
