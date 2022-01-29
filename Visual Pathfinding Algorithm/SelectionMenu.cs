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
  public partial class SelectionMenu : Form
  {
    public bool StartMode { get; set; } = false;
    public bool NullMode { get; set; } = false;
    public bool BlockMode { get; set; } = false;
    public bool EndMode { get; set; } = false;

    public GraphDisplay? Graph { get; set; } = null;

    public SelectionMenu()
    {
      InitializeComponent();

      Graph = new GraphDisplay();
      Graph.TopLevel = false;
      Graph.Parent = Display.Panel2;
      Display.Panel2.Controls.Add(Graph);

      Graph.Show();

      Graph.Dock = DockStyle.Fill;
    }

    /// <summary>
    /// Explicitly Sets the 'choosing' mode back to normal.
    /// </summary>
    public void ResetModes()
    {
      StartMode = false;
      NullMode = false;
      BlockMode = false;
      EndMode = false;
    }

    #region Events
    private void StartNodeButton_Click(object sender, EventArgs e)
    {
      StartMode = true;
      NullMode = false;
      BlockMode = false;
      EndMode = false;

      StartNodeButton.Enabled = false;
    }

    private void SelectBlockNodeButton_Click(object sender, EventArgs e)
    {
      StartMode = false;
      NullMode = false;
      BlockMode = true;
      EndMode = false;
    }

    private void SelectNullNodeButton_Click(object sender, EventArgs e)
    {
      StartMode = false;
      NullMode = true;
      BlockMode = false;
      EndMode = false;
    }

    private void SelectEndNodeButton_Click(object sender, EventArgs e)
    {
      StartMode = false;
      NullMode = false;
      BlockMode = false;
      EndMode = true;

      SelectEndNodeButton.Enabled = false;
    }
    #endregion

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      if (Graph == null) { return; }

      Graph.ResetNodes();

      StartNodeButton.Enabled = true;
      SelectNullNodeButton.Enabled = true;
      SelectBlockNodeButton.Enabled = true;
      SelectEndNodeButton.Enabled = true;

      ResetModes();

      MessageBox.Show("Nodes have now been reset.");
    }
  }
}
