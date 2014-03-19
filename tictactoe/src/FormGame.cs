using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictac
{
  public partial class FormGame : Form
  {
    public FormGame()
    {
      InitializeComponent();
    }

    public int gameSize = 3;
    GameBoard board;

    #region Reset board, initial setup

    // Set shape size and position
    private void setShape(Control ctx, int X, int Y)
    {
      int W = mainPanel.Width / gameSize;
      int H = mainPanel.Height / gameSize;
      ctx.Location = new System.Drawing.Point((X - 1) * W, (Y - 1) * H);
      ctx.Size = new System.Drawing.Size(W, H);
    }

    // Add text to display the result
    private void addText(int X, int Y)
    {
      var ctxt = new System.Windows.Forms.Label();
      setShape(ctxt, X, Y);
      ctxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      ctxt.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      ctxt.Name = "T" + BoardCell.MakeKey(X, Y);
      ctxt.TabIndex = 1;
      ctxt.Text = "X";
      ctxt.Visible = false;
      ctxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      mainPanel.Controls.Add(ctxt);
    }

    // Add button for user to press
    private void addButton(int X, int Y)
    {
      var btn = new System.Windows.Forms.Button();
      setShape(btn, X, Y);
      btn.Name = "B" + BoardCell.MakeKey(X, Y);
      btn.TabIndex = 0;
      btn.Text = "";
      // btn.UseVisualStyleBackColor = true;
      btn.Click += new System.EventHandler(this.btnCell_Click);
      mainPanel.Controls.Add(btn);
    }

    // Start game from scratch, rebuild the entire form
    private void resetBoard()
    {
      board = new GameBoard(gameSize);

      // Dynamically build all controls on the 'mainPanel'
      this.mainPanel.Controls.Clear();
      for (int x = 1; x <= gameSize; x++)
      {
        for (int y = 1; y <= gameSize; y++)
        {
          addText(x, y);
          addButton(x, y);
        }
      }
    }


    #endregion

    #region Play the game (events)

    // Change status of the cell
    private void setCellStatus(int X, int Y, string st)
    {
      // Get cell controls by name
      var key = BoardCell.MakeKey(X, Y);
      var btn = mainPanel.Controls["B" + key];
      var txt = mainPanel.Controls["T" + key];

      // If game is over, then no more clicking
      if (board.GameOver) btn.Enabled = false;

      if (String.IsNullOrEmpty(st))
      {
        // Empty status means empty cell - you can click
        btn.Visible = true;
        txt.Visible = false;
      }
      else
      {
        // Cell is occupied, hide button, update cell text
        btn.Visible = false;
        txt.Text = st.Substring(0, 1);
        txt.Visible = true;
        if (st.Length > 1)
        {
          txt.ForeColor = Color.Red;
          txt.Font = new Font(txt.Font, FontStyle.Bold);
        }
      }

    }

    // Update status of one cell
    private void updateOneCell(int X, int Y)
    {
      var st = board.GetCellStatus(X, Y);
      setCellStatus(X, Y, st);
    }

    // --- Update status of every control on the form
    private void updateBoard()
    {
      for (int x = 1; x <= gameSize; x++)
      {
        for (int y = 1; y <= gameSize; y++)
        {
          updateOneCell(x, y);
        }
      }
      if (board.GameOver) stepLabel.Text = "Game Over"; else
      stepLabel.Text = String.Format("{0}", board.Step);
    }

    #endregion


    // --- When user click any cell this method is called
    private void btnCell_Click(object sender, EventArgs e)
    {
      if (sender is Button) {
        string name = (sender as Control).Name;
        name = name.Substring(1, name.Length-1);
        board.MakeMove(name);
        updateBoard();
      }
      
    }

    // --- Reset the board when reset button is clicked
    private void btnStart_Click(object sender, EventArgs e)
    {
      resetBoard();
    }

    // --- Reset the board when form is created
    private void Form1_Load(object sender, EventArgs e)
    {
      toolSize.SelectedIndex = 0;
      resetBoard();
    }

    // --- Reset the board when dimension changed
    private void toolSize_SelectedIndexChanged(object sender, EventArgs e)
    {
      gameSize = Convert.ToInt32(toolSize.Text);
      resetBoard();
    }


  }
}
