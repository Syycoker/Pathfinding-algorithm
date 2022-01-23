namespace Visual_Pathfinding_Algorithm
{
  public partial class GraphDisplay : Form
  {
    public GraphDisplay()
    {
      InitializeComponent();
      AddNodes();

      //Algorithms.UseLine();
    }

    #region Public
    /// <summary>
    /// Explicitly sets all the nodes in the 'graph' back to it's null state.
    /// </summary>
    public void ResetNodes()
    {
      foreach (Node node in Controls)
      {
        node.Type = NodeType.NULL_NODE;
      }
    }
    #endregion

    #region Private
    /// <summary>
    /// Displays a group of nodes as a grid for representational purposes.
    /// </summary>
    /// <param name="numOfNodes"></param>
    private void AddNodes(int numOfNodes = 10)
    {
      int nodeXPos = 0;
      int nodeYPos = 0;

      // Truncation occurs here, maybe float?
      int xStep = Width / numOfNodes;
      int yStep = Height / numOfNodes;

      while (nodeYPos < Height)
      {
        while (nodeXPos < Width)
        {
          Node node = new Node();
          Controls.Add(node);
          node.Parent = this;
          node.Location = new Point(nodeXPos, nodeYPos);
          nodeXPos += xStep;

          Algorithms.Nodes.Add(node);
        }
        nodeXPos = 0;
        nodeYPos += yStep;
      }
    }
    #endregion
  }
}