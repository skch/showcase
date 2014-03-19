namespace tictac
{
  partial class FormGame
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnStart = new System.Windows.Forms.ToolStripButton();
      this.stepLabel = new System.Windows.Forms.ToolStripLabel();
      this.toolSize = new System.Windows.Forms.ToolStripComboBox();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.stepLabel,
            this.toolSize});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(535, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnStart
      // 
      this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
      this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(47, 22);
      this.btnStart.Text = "Restart";
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // stepLabel
      // 
      this.stepLabel.AutoSize = false;
      this.stepLabel.Name = "stepLabel";
      this.stepLabel.Size = new System.Drawing.Size(80, 22);
      this.stepLabel.Text = "New Game";
      // 
      // toolSize
      // 
      this.toolSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.toolSize.Items.AddRange(new object[] {
            "3",
            "4"});
      this.toolSize.Name = "toolSize";
      this.toolSize.Size = new System.Drawing.Size(75, 25);
      this.toolSize.SelectedIndexChanged += new System.EventHandler(this.toolSize_SelectedIndexChanged);
      // 
      // mainPanel
      // 
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(0, 25);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(535, 458);
      this.mainPanel.TabIndex = 3;
      // 
      // FormGame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(535, 483);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.toolStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FormGame";
      this.Text = "Tic-Tac-Toe";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnStart;
    private System.Windows.Forms.Panel mainPanel;
    private System.Windows.Forms.ToolStripLabel stepLabel;
    private System.Windows.Forms.ToolStripComboBox toolSize;
  }
}

