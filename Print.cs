using chess_console.board;

namespace chess_console
{
    internal class Print
    {
        public static void printBoard(Board board) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
