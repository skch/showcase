using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictac
{
  /// <summary>
  /// Board line is line of board cells that may win the game
  /// </summary>
  public class BoardLine
  {

    private List<BoardCell> listCells = new List<BoardCell>();
    private string Name = "";

    public BoardLine(string aname) {
      Name = aname;
    }

    public override string ToString()
    {
      return String.Format("{0}: {1} line", Name, Rank);
    }

    #region Public properties

    public int Rank;

    public bool isWinner = false;

    private bool isAvailable = true;
    public bool IsAvailable { get { return isAvailable; } }
    #endregion

    #region Service methods

    // --- Add cell to the line
    public void AddCell(BoardCell cc) {
      listCells.Add(cc);
      cc.AddLine(this);
    }

    // --- Recalculate rank of the line
    public void UpdateRank()
    {
      int xcount = 0;
      int ocount = 0;
      foreach (BoardCell cc in listCells) {
        if (cc.hasX) xcount++;
        if (cc.hasO) ocount++;
      }

      isAvailable = true;
      if (xcount == listCells.Count || ocount == listCells.Count) markLineWinner();
      if (xcount > 0 && ocount > 0) { Rank = 0; isAvailable = false; } // This line never wins
      if (xcount == 0) Rank = ocount+1; else Rank = xcount+1;
      
    }

    // --- Mark every cell of this line as a winner
    private void markLineWinner()
    {
      foreach (BoardCell cc in listCells) cc.MarkWinner();
      isWinner = true;
    }

    #endregion

  }
}
