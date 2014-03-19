using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictac
{

  /// <summary>
  /// Board Cell represent a single cell on the board
  /// </summary>
  public class BoardCell
  {
    #region Static methods
    public static string LABEL_X = "X";
    public static string LABEL_O = "O";

    public static string MakeKey(int x, int y)
    {
      return String.Format("{0}x{1}", x, y);
    }

    #endregion

    private string Name = "";
    private List<BoardLine> listLines = new List<BoardLine>();

    public BoardCell(int x, int y)
    {
      Name = MakeKey(x, y);
    }

    public override string ToString()
    {
      return String.Format("{0}: {1} cell", Name, Rank);
    }

    #region Public properties

    public int Rank = 0;

    private string status = "";
    public string Status
    {
      get { return status; }
    }

    public bool hasX
    {
      get { return status.StartsWith(LABEL_X); }
    }

    public bool hasO
    {
      get { return status.StartsWith(LABEL_O); }
    }

    public bool isEmpty
    {
      get { return String.IsNullOrEmpty(status); }
    }

    #endregion

    #region Operating the cell
    public void MarkX()
    {
      status = LABEL_X;
    }

    public void MarkO()
    {
      status = LABEL_O;
    }

    public void AddLine(BoardLine pline)
    {
      listLines.Add(pline);
    }

    public void MarkWinner()
    {
      // The winner cells have status 'XX' instead of 'X'
      status += status;
    }

    // --- Cell rank is a sum of ranks of all lines it belongs to
    public void updateRank()
    {
      Rank = 0;
      foreach (BoardLine line in listLines) {
        if (line.IsAvailable && isEmpty) Rank += line.Rank;
      }
    }

    #endregion
  }
}
