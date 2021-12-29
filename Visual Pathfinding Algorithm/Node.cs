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
    }

    public Node(Node next, object data)
    {
      InitializeComponent();
      UpdateControl();

      Next = next;
      Data = data;
    }
    #endregion

    #region Public
    public bool Highlighted = false;
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
      timer.Tick += HandleTransformation;
    }

    private void HandleTransformation(object? sender, EventArgs e)
    {
      int scale = 5;

      if (Enlarging)
      {
        if (Size.Width < ControlHoverSize.Width)
        {
          Width += scale;
          Height += scale;
        }
        else
        {
          timer.Stop();
          BackColor = HighlightedColour;
        }
      }
      else
      {
        if (Size.Width > ControlSize.Width)
        {
          Width -= scale;
          Height -= scale;
        }
        else
        {
          timer.Stop();
          BackColor = DefaultColour;
        }
      }
    }
    public bool Enlarging = false;
    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);
      Enlarging = true;
      timer.Start();
    }
    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      Enlarging = false;
      timer.Start();
    }
    #endregion

    #region Interface
    public Node? Next { get; set; }
    public object? Data { get; set; }
    #endregion
  }
}
