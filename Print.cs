using board;

namespace chess_console {
    internal class Print
    {
        public static void printBoard(Board board) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.piece(new Position(i, j)) == null) {
                        Console.Write("- ");
                    }
                    else
                    {
                        Print.printPiece(board.piece(new Position(i, j)));
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece) {
            if(piece.color == Color.White) {
                Console.Write(piece);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
