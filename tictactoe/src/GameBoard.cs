using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictac
{
  
  /// <summary>
  /// Game board with square dimensions N
  /// Contains N*N cells and 2*N+2 lines
  /// </summary>
  public class GameBoard
  {

    private int gameSize = 3;
    private Dictionary<string, BoardCell> indexCells = new Dictionary<string, BoardCell>();
    private List<BoardLine> listLines = new List<BoardLine>();


    #region Initialization

    public GameBoard(int size) {
      gameSize = size;
      initialize();
    }

    // --- Build new board, initialize all objects
    private void initialize()
    {
      // Create all cells
      for (int x = 1; x <= gameSize; x++ )
      {
        for (int y = 1; y <= gameSize; y++)
        {
          var cell = new BoardCell(x, y);
          indexCells.Add(BoardCell.MakeKey(x,y), cell);
        }
      }

      // Create all lines
      var xline = new BoardLine("\\");
      var bline = new BoardLine("/");
      for (int x = 1; x <= gameSize; x++) {
        var vline = new BoardLine(String.Format("v{0}",x));
        var hline = new BoardLine(String.Format("h{0}",x));
        xline.AddCell(getCell(x, x));
        bline.AddCell(getCell(x, gameSize-x+1));
        for (int y = 1; y <= gameSize; y++)
        {
          vline.AddCell(getCell(x, y));
          hline.AddCell(getCell(y, x));
        }
        listLines.Add(vline);
        listLines.Add(hline);
      }
      listLines.Add(xline);
      listLines.Add(bline);
    }

    #endregion

    #region Public properties

    private bool gameOver = false;
    public bool GameOver { get { return gameOver; } }

    private int step = 0;
    public int Step { get { return step; } }

    #endregion

    #region Game intelligence

    /// <summary>
    /// This is the main method. Make your move by providing cell coordinate
    /// </summary>
    /// <param name="cellName">Format: {X}x{Y}</param>
    public void MakeMove(string cellName) {
      try
      {
        var pair = cellName.Split('x');
        if (pair.Length != 2) return;
        int X = Convert.ToInt32(pair[0]);
        int Y = Convert.ToInt32(pair[1]);

        var cell = getCell(X, Y);
        if (cell == null) return;
        if (!cell.isEmpty) return;

        // Process player's move
        cell.MarkX(); 
        step++;
        evaluateBoard();
        if (gameOver) return;

        // Process board's move
        var bestCell = getBestCell();
        if (bestCell == null) return;
        bestCell.MarkO(); step++;
        evaluateBoard();
      }
      catch {
        return; // in case of error, ignore the move
      }
    }

    // --- Find cell with maximum rank
    private BoardCell getBestCell()
    {
      BoardCell res = null;
      int max = 0;
      foreach (BoardCell cc in indexCells.Values) {
        if (cc.Rank > max) { res = cc; max = cc.Rank; }
      }
      return res;
    }

    // --- Recalculate ranks of all lines and cells
    private void evaluateBoard()
    {
      // Evaluate each line and arrange by rank
      foreach (BoardLine line in listLines)
      {
        line.UpdateRank();
        if (line.isWinner)
        {
          gameOver = true;
          return;
        }
      }
      foreach (BoardCell cc in indexCells.Values) cc.updateRank();
    }

    #endregion

    #region Service methods

    /// <summary>
    /// Get the status of the board cell
    /// </summary>
    /// <param name="X">Horizontal position</param>
    /// <param name="Y">Vertical position</param>
    /// <returns>Empty string - empty cell. 'X', 'O', 'XX', or 'OO'. Double means winning line </returns>
    public string GetCellStatus(int X, int Y) {
      var cell = getCell(X, Y);
      if (cell == null) return "Error";
      return cell.Status;
    }

    private BoardCell getCell(int X, int Y) {
      if (X < 1 || X > gameSize || Y < 1 || Y > gameSize) return null;
      return indexCells[BoardCell.MakeKey(X, Y)];
    }

    #endregion



  }
}
