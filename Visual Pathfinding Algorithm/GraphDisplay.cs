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
          endNode.Type = NodeType.START;
          // We've Reached the final node
          return CalculatePath(endNode);
        }

        openList.Remove(currentNode);
        closedList.Add(currentNode);

        foreach (Node neighbourNode in GetNeighbourList(currentNode))
        {
          if (closedList.Contains(neighbourNode)) { continue; }

          if (neighbourNode.Type == NodeType.BLOCK)
          {
            closedList.Add(neighbourNode);
            continue;
          }
          int tentativeGCost = currentNode.gCost + CalculateDistance(currentNode, neighbourNode);
          if (tentativeGCost < neighbourNode.gCost)
          {
            neighbourNode.cameFromNode = currentNode;
            neighbourNode.gCost = tentativeGCost;
            neighbourNode.hCost = CalculateDistance(neighbourNode, endNode);
            neighbourNode.CalculateFCost();

            if (!openList.Contains(neighbourNode))
            {
              neighbourNode.Type = NodeType.VALID;
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
      if (currentNode.x - 1 >= 0)
      {
        nList.Add(GetNode(currentNode.x - 1, currentNode.y));
        if (currentNode.y - 1 >= 0) { nList.Add(GetNode(currentNode.x - 1, currentNode.y - 1)); }
        if (currentNode.y + 1 < grid.GetHeight()) { nList.Add(GetNode(currentNode.x - 1, currentNode.y + 1)); }
      }
      if (currentNode.x + 1 < grid.GetWidth())
      {
        nList.Add(GetNode(currentNode.x + 1, currentNode.y));
        if (currentNode.y - 1 >= 0) { nList.Add(GetNode(currentNode.x + 1, currentNode.y - 1)); }
        if (currentNode.y + 1 < grid.GetHeight()) { nList.Add(GetNode(currentNode.x + 1, currentNode.y + 1)); }
      }
      if (currentNode.y - 1 >= 0) { nList.Add(GetNode(currentNode.x, currentNode.y - 1)); }
      if (currentNode.y + 1 < grid.GetHeight()) { nList.Add(GetNode(currentNode.x, currentNode.y + 1)); }

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
        currentNode.Type = NodeType.FINISHED;
      }
      path.Reverse();

      return path;
    }

    private int CalculateDistance(Node a, Node b)
    {
      int xDistance = Math.Abs(a.x - b.x);
      int yDistance = Math.Abs(a.y - b.y);
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