using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.board
{
    internal class Board
    {
        public int rows {  get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece (int row, int column) { 
            return pieces[row, column]; 
        }

        public void putPiece(Piece piece, Position position)
        {
            pieces[position.row, position.column] = piece;
            piece.position = position;
        }
    }
}
