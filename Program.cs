using chess_console.board;
using chess_console.pieces;

namespace chess_console
{
    class Program
    {
        static void Main()
        {
            Board board = new Board(8, 8);

            board.putPiece(new Tower(board,Color.Black), new Position(0, 0));
            board.putPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.putPiece(new Tower(board, Color.Black), new Position(2, 4));

            Print.printBoard(board);

            Console.ReadLine();
        }
    }
}