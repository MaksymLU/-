using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Chess
{
    public class Board
    {
        private int size;
        private List<Queen> queens;

        public Board(int size)
        {
            this.size = size;
            queens = new List<Queen>();
        }

        public void AddQueen(Queen queen)
        {
            queens.Add(queen);
        }

        public bool IsUnderAttack(int row, int col)
        {
            foreach (var queen in queens)
            {
                if (queen.Row == row || queen.Col == col || Math.Abs(queen.Row - row) == Math.Abs(queen.Col - col))
                {
                    return true;
                }
            }
            return false;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool queenExists = queens.Exists(q => q.Row == i && q.Col == j);
                    Console.Write(queenExists ? 'Q' : '■');
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
