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
  public partial class Node : UserControl, INode
  {
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

    public Node(Node next, object data)
    {
      InitializeComponent();
      UpdateControl();
      timer.Tick += HandleTransformation;

      Next = next;
      Data = data;
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
    #endregion

    #region Private
    private void UpdateControl()
    {
      Size = ControlSize;
      BackColor = DefaultColour;
      Cursor = Cursors.Hand;
      Location = LastInteractionLocation;
    }

    private void HandleTransformation(object? sender, EventArgs e)
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

    #region Interface
    public Node? Next { get; set; }
    public object? Data { get; set; }
    #endregion
  }
}
