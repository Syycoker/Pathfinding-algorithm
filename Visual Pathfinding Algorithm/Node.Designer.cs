namespace Visual_Pathfinding_Algorithm
{
  partial class Node
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.NodeTypeTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // timer
      // 
      this.timer.Interval = 25;
      this.timer.Tick += new System.EventHandler(this.HandleTransformation);
      // 
      // NodeTypeTimer
      // 
      this.NodeTypeTimer.Tick += new System.EventHandler(this.NodeTypeTimer_Tick);
      // 
      // Node
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "Node";
      this.Click += new System.EventHandler(this.Node_Click);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Timer NodeTypeTimer;
  }
}
