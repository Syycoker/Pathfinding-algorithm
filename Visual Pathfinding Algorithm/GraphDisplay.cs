namespace Visual_Pathfinding_Algorithm
{
  public partial class GraphDisplay : Form
  {

    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private Grid grid;
    private List<Node>? openList;
    private List<Node>? closedList;

    public GraphDisplay(int width, int height)
    {
      InitializeComponent();

      grid = new Grid(width, height, this);
    }

    public List<Node> FindPath(int startX, int startY, int endX, int endY)
    {
      Node startNode = grid.GetGridObject(startX, startY);
      Node endNode = grid.GetGridObject(endX, endY);

      openList = new List<Node> { startNode };
      closedList = new List<Node>();

      for (int x = 0; x < grid.GetWidth(); x++)
      {
        for (int y = 0; y < grid.GetHeight(); y++)
        {
          Node pathNode = grid.GetGridObject(x, y);
          pathNode.gCost = int.MaxValue;
          pathNode.CalculateFCost();
          pathNode.cameFromNode = null;
        }
      }

      startNode.gCost = 0;
      startNode.hCost = CalculateDistance(startNode, endNode);
      startNode.CalculateFCost();

      while (openList.Count > 0)
      {
        Node currentNode = GetLowestCostNode(openList);

        if (currentNode == endNode)
        {
          // We've Reached the final node
          return CalculatePath(endNode);
        }

        openList.Remove(currentNode);
        closedList.Add(currentNode);

        foreach (Node neighbourNode in GetNeighbourList(currentNode))
        {
          if (closedList.Contains(neighbourNode)) { continue; }
          int tentativeGCost = currentNode.gCost + CalculateDistance(currentNode, neighbourNode);
          if (tentativeGCost < neighbourNode.gCost)
          {
            neighbourNode.cameFromNode = currentNode;
            neighbourNode.gCost = tentativeGCost;
            neighbourNode.hCost = CalculateDistance(neighbourNode, endNode);
            neighbourNode.CalculateFCost();

            if (!openList.Contains(neighbourNode))
            {
              openList.Add(neighbourNode);
            }
          }
        }
      }
      // Out of nodes in the openList
      return null;
    }

    /// <summary>
    /// Gets all the neighbouring nodes, provided that they're within the grid's boundaries.
    /// </summary>
    /// <param name="currentNode"></param>
    /// <returns></returns>
    private List<Node> GetNeighbourList(Node currentNode)
    {
      List<Node> nList = new();
      if (currentNode.Location.X - 1 >= 0)
      {
        nList.Add(GetNode(currentNode.Location.X - 1, currentNode.Location.Y));
        if (currentNode.Location.Y - 1 >= 0) { nList.Add(GetNode(currentNode.Location.X - 1, currentNode.Location.Y - 1)); }
        if (currentNode.Location.Y + 1 < grid.GetHeight()) { nList.Add(GetNode(currentNode.Location.X - 1, currentNode.Location.Y + 1)); }
      }
      if (currentNode.Location.X + 1 < grid.GetWidth())
      {
        nList.Add(GetNode(currentNode.Location.X + 1, currentNode.Location.Y));
        if (currentNode.Location.Y - 1 >= 0) { nList.Add(GetNode(currentNode.Location.X + 1, currentNode.Location.Y - 1)); }
        if (currentNode.Location.Y + 1 < grid.GetHeight()) { nList.Add(GetNode(currentNode.Location.X + 1, currentNode.Location.Y + 1)); }
      }
      if (currentNode.Location.Y - 1 >= 0) { nList.Add(GetNode(currentNode.Location.X, currentNode.Location.Y - 1)); }
      if (currentNode.Location.Y + 1 < grid.GetHeight()) { nList.Add(GetNode(currentNode.Location.X, currentNode.Location.Y + 1)); }

      return nList;
    }

    private Node GetNode(int x, int y)
    {
      return grid.GetGridObject(x, y);
    }

    private List<Node> CalculatePath(Node endNode)
    {
      List<Node> path = new List<Node>();
      path.Add(endNode);
      Node currentNode = endNode;
      while (currentNode.cameFromNode != null)
      {
        path.Add(currentNode.cameFromNode);
        currentNode = currentNode.cameFromNode;
      }
      path.Reverse();
      return path;
    }

    private int CalculateDistance(Node a, Node b)
    {
      int xDistance = Math.Abs(a.Location.X - b.Location.X);
      int yDistance = Math.Abs(a.Location.Y - b.Location.Y);
      int remaining = Math.Abs(xDistance - yDistance);
      return MOVE_DIAGONAL_COST * Math.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    private Node GetLowestCostNode(List<Node> pathNodeList)
    {
      Node lowestFCostNode = pathNodeList[0];

      for (int i = 1; i < pathNodeList.Count; i++)
      {
        if (pathNodeList[i].fCost < lowestFCostNode.fCost)
        {
          lowestFCostNode = pathNodeList[i];
        }
      }

      return lowestFCostNode;
    }
  }
}