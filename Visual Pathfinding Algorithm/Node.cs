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
  public partial class Node : UserControl
  {
    #region Node Attributes
    private string name = string.Empty;
    private LinkedList<Node> shortestPath = new LinkedList<Node>();
    private int distance = int.MaxValue;
    Dictionary<Node, int> adjacentNodes = new Dictionary<Node, int>();

    public NodeType Type { get; set; } = NodeType.NULL_NODE;
    #endregion

    #region Control Attributes
    Size ControlSize = new Size(50,50);
    Size ControlHoverSize = new Size(75, 75);
    Color DefaultColour = Color.White;
    Color HighlightedColour = Color.DodgerBlue;
    #endregion

    #region Constructors
    public Node()
    {
      InitializeComponent();
      UpdateControl();
      timer.Tick += HandleTransformation;
    }

    public Node(string name)
    {
      InitializeComponent();
      UpdateControl();
      timer.Tick += HandleTransformation;

      this.name = name;
    }
    #endregion

    #region Public
    public bool Enlarging = false;
    public bool Highlighted = false;
    public Point LastInteractionLocation;
    public void Highlight(bool highlighted = true)
    {
      BackColor = highlighted ? HighlightedColour : DefaultColour;
      Highlighted = highlighted;
    }

    public void addDestination(Node destination, int distance)
    {
      adjacentNodes.Add(destination, distance);
    }
    #endregion

    #region Private
    protected void UpdateControl()
    {
      Size = ControlSize;
      BackColor = DefaultColour;
      Cursor = Cursors.Hand;
      Location = LastInteractionLocation;
    }

    protected void HandleTransformation(object? sender, EventArgs e)
    {
      int locationTranslation = 13;
      int scale = 5;
      float lerpRate = 0.15f;

      if (Enlarging)
      {
        Location = new Point(LastInteractionLocation.X - locationTranslation, LastInteractionLocation.Y - locationTranslation);
        if (Size.Width < ControlHoverSize.Width)
        {
          Width += scale;
          Height += scale;
          BackColor = BackColor.Lerp(HighlightedColour, lerpRate);
        }
        else
        {
          timer.Stop();
          BackColor = HighlightedColour;
        }
        BringToFront();
      }
      else
      {
        Location = LastInteractionLocation;
        if (Size.Width > ControlSize.Width)
        {
          Width -= scale;
          Height -= scale;
          BackColor = BackColor.Lerp(DefaultColour, lerpRate);
        }
        else
        {
          timer.Stop();
          BackColor = DefaultColour;
        }
        SendToBack();
      }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);
      Enlarging = true;
      LastInteractionLocation = Location;
      timer.Start();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      Enlarging = false;
      timer.Start();
      UpdateControl();
    }
    #endregion

    private void Node_Click(object sender, EventArgs e)
    {
      if (Program.WrapperForm != null)
      {
        if (Program.WrapperForm.StartMode)
        {
          Type = NodeType.START_NODE;
          MessageBox.Show("Node is now a 'Starting' node.");
        }
        if (Program.WrapperForm.NullMode)
        {
          Type = NodeType.NULL_NODE;
          MessageBox.Show("Node is now an 'Empty' node.");
        }
        if (Program.WrapperForm.BlockMode)
        {
          Type = NodeType.BLOCKING_NODE;
          MessageBox.Show("Node is now a 'Blocking' node.");
        }
        if (Program.WrapperForm.EndMode)
        {
          Type = NodeType.END_NODE;
          MessageBox.Show("Node is now an 'Ending' node.");
        }

        Program.WrapperForm.ResetModes();
      }
    }

    private void NodeTypeTimer_Tick(object sender, EventArgs e)
    {
      switch (Type)
      {
        case NodeType.START_NODE:
          DefaultColour = Color.Green;
          return;

        case NodeType.NULL_NODE:
          DefaultColour = Color.White;
          return;

        case NodeType.BLOCKING_NODE:
          DefaultColour = Color.DarkGray;
          return;

        case NodeType.END_NODE:
          DefaultColour = Color.Red;
          return;
      }
    }
  }
}
