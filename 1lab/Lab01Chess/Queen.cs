using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Chess
{
    public class Queen
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Queen(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
