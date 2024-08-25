using board;
using game;

namespace chess_console {
    internal class Print
    {

        public static void printBoard(Board board) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    printPiece(board.Piece(i, j)); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }

        public static void printBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alternateBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if (possibleMoves[i, j]) {
                        Console.BackgroundColor = alternateBackground;
                    } else {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
            Console.BackgroundColor = originalBackground;
        }

        
        public static void printPiece(Piece piece) {

            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if(piece.color == Color.White) {
                    Console.Write(piece);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadPosition() {
            string command = Console.ReadLine();
            char column = command[0];
            int row = int.Parse(command[1] + "");
            return new ChessPosition(column, row);
         }
    }
}
