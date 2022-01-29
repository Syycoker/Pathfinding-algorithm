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

      grid = new Grid(width, height);
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
      }
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