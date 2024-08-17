using chess_console.board;

namespace chess_console.pieces
{
    internal class Tower : Piece
    {

        public Tower(Board board, Color color):base(board, color){}

        public override string ToString()
        {
            return "♖";
        }
    }
}
