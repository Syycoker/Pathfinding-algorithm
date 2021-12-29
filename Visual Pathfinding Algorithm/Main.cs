namespace Visual_Pathfinding_Algorithm
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
      AddNodes();

      //Algorithms.UseLine();
    }

    #region Methods
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