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

    public Grid(int width, int height, Control control)
    {
      gridArray = new Node[width, height];

      for (int x = 0; x < gridArray.GetLength(0); x++)
      {
        for (int y = 0; y < gridArray.GetLength(1); y++)
        {
          int xLocation = x * 55; // 50 for the defaultsize + 5 for the spacing.
          int yLocation = y * 55;
          Node newNode = new Node(this, xLocation, yLocation);
          newNode.Parent = control;
          control.Controls.Add(newNode);
          gridArray[x, y] = newNode;
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
