using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Pathfinding_Algorithm
{
  public partial class MainMenu : Form
  {
    public bool StartMode { get; set; } = false;
    public bool NullMode { get; set; } = false;
    public bool BlockMode { get; set; } = false;
    public bool EndMode { get; set; } = false;

    public Node StartNode { get; set; }
    public Node EndNode { get; set; }

    public GraphDisplay? Graph { get; set; } = null;

    public MainMenu()
    {
      InitializeComponent();

      Graph = new GraphDisplay(10,10); // Instantiate a grid of 10 x 10.
      Graph.TopLevel = false;
      Graph.Parent = Display.Panel2;
      Display.Panel2.Controls.Add(Graph);

      Graph.Show();

      Graph.Dock = DockStyle.Fill;
    }

    /// <summary>
    /// Explicitly Sets the 'choosing' mode back to normal.
    /// </summary>
    public void ResetNodes()
    {
      StartMode = false;
      NullMode = false;
      BlockMode = false;
      EndMode = false;
    }

    #region Events
    private void HandleStartNodeSelection(object sender, EventArgs e)
    {
      StartMode = true;
      NullMode = false;
      BlockMode = false;
      EndMode = false;

      StartNodeButton.Enabled = false;
    }

    private void HandleBlockNodeSelection(object sender, EventArgs e)
    {
      StartMode = false;
      NullMode = false;
      BlockMode = true;
      EndMode = false;
    }

    private void HandleNullNodeSelection(object sender, EventArgs e)
    {
      StartMode = false;
      NullMode = true;
      BlockMode = false;
      EndMode = false;
    }

    private void HandleEndNodeSelection(object sender, EventArgs e)
    {
      StartMode = false;
      NullMode = false;
      BlockMode = false;
      EndMode = true;

      SelectEndNodeButton.Enabled = false;
    }
    #endregion

    private void HandleRefresh(object sender, EventArgs e)
    {
      if (Graph == null) { return; }

      StartNodeButton.Enabled = true;
      SelectNullNodeButton.Enabled = true;
      SelectBlockNodeButton.Enabled = true;
      SelectEndNodeButton.Enabled = true;

      ResetNodes();

      MessageBox.Show("Nodes have now been reset.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Calculates the path the 'startNode' needs to taketo reach the 'endNode' if it's possible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleVisualisation(object sender, EventArgs e)
    {
      try
      {
        if (Graph is null) { throw new Exception("Please initialise a Graph."); }
        if (StartNode is null || StartNode.Type != NodeType.START) { throw new Exception("Pick a valid 'Start Node' (Green) or 'Refresh'."); }
        if (EndNode is null || EndNode.Type != NodeType.END) { throw new Exception("Pick a valid 'End Node' (Green) or 'Refresh'."); }

        Graph.FindPath(StartNode.x, StartNode.y, EndNode.x, EndNode.y);

        StartNodeButton.Enabled = false;
        SelectNullNodeButton.Enabled = false;
        SelectBlockNodeButton.Enabled = false;
        SelectEndNodeButton.Enabled = false;

        // now using the 'e' argument, we'll simulate a user on enter event, but slowly
      }
      catch (Exception eArgs)
      {
        MessageBox.Show(eArgs.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
