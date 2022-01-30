﻿namespace Visual_Pathfinding_Algorithm
{
  partial class SelectionMenu
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Display = new System.Windows.Forms.SplitContainer();
      this.SelectEndNodeButton = new System.Windows.Forms.Button();
      this.SelectNullNodeButton = new System.Windows.Forms.Button();
      this.SelectBlockNodeButton = new System.Windows.Forms.Button();
      this.StartNodeButton = new System.Windows.Forms.Button();
      this.RefreshButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.Display)).BeginInit();
      this.Display.Panel1.SuspendLayout();
      this.Display.SuspendLayout();
      this.SuspendLayout();
      // 
      // Display
      // 
      this.Display.Cursor = System.Windows.Forms.Cursors.VSplit;
      this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Display.Location = new System.Drawing.Point(0, 0);
      this.Display.Name = "Display";
      // 
      // Display.Panel1
      // 
      this.Display.Panel1.Controls.Add(this.RefreshButton);
      this.Display.Panel1.Controls.Add(this.SelectEndNodeButton);
      this.Display.Panel1.Controls.Add(this.SelectNullNodeButton);
      this.Display.Panel1.Controls.Add(this.SelectBlockNodeButton);
      this.Display.Panel1.Controls.Add(this.StartNodeButton);
      this.Display.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
      // 
      // Display.Panel2
      // 
      this.Display.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.Display.Size = new System.Drawing.Size(800, 521);
      this.Display.SplitterDistance = 266;
      this.Display.TabIndex = 0;
      // 
      // SelectEndNodeButton
      // 
      this.SelectEndNodeButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.SelectEndNodeButton.Location = new System.Drawing.Point(0, 69);
      this.SelectEndNodeButton.Name = "SelectEndNodeButton";
      this.SelectEndNodeButton.Size = new System.Drawing.Size(266, 23);
      this.SelectEndNodeButton.TabIndex = 3;
      this.SelectEndNodeButton.Text = "Select End Node";
      this.SelectEndNodeButton.UseVisualStyleBackColor = true;
      this.SelectEndNodeButton.Click += new System.EventHandler(this.SelectEndNodeButton_Click);
      // 
      // SelectNullNodeButton
      // 
      this.SelectNullNodeButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.SelectNullNodeButton.Location = new System.Drawing.Point(0, 46);
      this.SelectNullNodeButton.Name = "SelectNullNodeButton";
      this.SelectNullNodeButton.Size = new System.Drawing.Size(266, 23);
      this.SelectNullNodeButton.TabIndex = 2;
      this.SelectNullNodeButton.Text = "Select Null Node";
      this.SelectNullNodeButton.UseVisualStyleBackColor = true;
      this.SelectNullNodeButton.Click += new System.EventHandler(this.SelectNullNodeButton_Click);
      // 
      // SelectBlockNodeButton
      // 
      this.SelectBlockNodeButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.SelectBlockNodeButton.Location = new System.Drawing.Point(0, 23);
      this.SelectBlockNodeButton.Name = "SelectBlockNodeButton";
      this.SelectBlockNodeButton.Size = new System.Drawing.Size(266, 23);
      this.SelectBlockNodeButton.TabIndex = 1;
      this.SelectBlockNodeButton.Text = "Select Block Node";
      this.SelectBlockNodeButton.UseVisualStyleBackColor = true;
      this.SelectBlockNodeButton.Click += new System.EventHandler(this.SelectBlockNodeButton_Click);
      // 
      // StartNodeButton
      // 
      this.StartNodeButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.StartNodeButton.Location = new System.Drawing.Point(0, 0);
      this.StartNodeButton.Name = "StartNodeButton";
      this.StartNodeButton.Size = new System.Drawing.Size(266, 23);
      this.StartNodeButton.TabIndex = 0;
      this.StartNodeButton.Text = "Select Start Node";
      this.StartNodeButton.UseVisualStyleBackColor = true;
      this.StartNodeButton.Click += new System.EventHandler(this.StartNodeButton_Click);
      // 
      // RefreshButton
      // 
      this.RefreshButton.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.RefreshButton.Location = new System.Drawing.Point(0, 498);
      this.RefreshButton.Name = "RefreshButton";
      this.RefreshButton.Size = new System.Drawing.Size(266, 23);
      this.RefreshButton.TabIndex = 4;
      this.RefreshButton.Text = "Refresh";
      this.RefreshButton.UseVisualStyleBackColor = true;
      this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
      // 
      // SelectionMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 521);
      this.Controls.Add(this.Display);
      this.Name = "SelectionMenu";
      this.Text = "SelectionMenu";
      this.Display.Panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.Display)).EndInit();
      this.Display.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private SplitContainer Display;
    private Button SelectEndNodeButton;
    private Button SelectNullNodeButton;
    private Button SelectBlockNodeButton;
    private Button StartNodeButton;
    private Button RefreshButton;
  }
}