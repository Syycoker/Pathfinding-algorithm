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
    public Grid? Grid;
    public NodeType Type { get; set; } = NodeType.NULL;
    private int x;
    private int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public Node? cameFromNode;
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
    }

    public Node(Grid grid, int x, int y)
    {
      InitializeComponent();
      UpdateControl();
      Grid = grid;
      this.x = x;
      this.y = y;

      Location = new Point(x ,y);
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

    public void CalculateFCost()
    {
      fCost = gCost + hCost;
    }
    #endregion
    #region Private

    public override string ToString()
    {
      return x + "," + y;
    }
    protected void UpdateControl()
    {
      Size = ControlSize;
      BackColor = DefaultColour;
      Cursor = Cursors.Hand;
      Location = new Point(x, y);
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
    #region Events
    private void Node_Click(object sender, EventArgs e)
    {
      if (Program.WrapperForm != null)
      {
        if (Program.WrapperForm.StartMode)
        {
          Type = NodeType.START;
        }
        if (Program.WrapperForm.NullMode)
        {
          Type = NodeType.NULL;
        }
        if (Program.WrapperForm.BlockMode)
        {
          Type = NodeType.BLOCK;
        }
        if (Program.WrapperForm.EndMode)
        {
          Type = NodeType.END;
        }

        Program.WrapperForm.ResetModes();
      }
    }

    private void NodeTypeTimer_Tick(object sender, EventArgs e)
    {
      switch (Type)
      {
        case NodeType.START:
          DefaultColour = Color.Green;
          return;

        case NodeType.NULL:
          DefaultColour = Color.White;
          return;

        case NodeType.BLOCK:
          DefaultColour = Color.DarkGray;
          return;

        case NodeType.END:
          DefaultColour = Color.Red;
          return;
      }
    }
    #endregion
  }
}
