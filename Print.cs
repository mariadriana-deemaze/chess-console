using board;
using game;
using System;
using System.Drawing;

namespace chess_console {
    internal class Print
    {

        public static void PrintTurn(Game game) {
            PrintBoard(game.board);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turn: " + game.turn);

            if (!game.finished) { 
                Console.WriteLine(game.player + "'s turn.");
                if (game.inCheck) {
                    Console.WriteLine("IN CHECK!");
                }
            } else
            {
                Console.WriteLine("Checkmate.");
                Console.WriteLine("Winner: " + game.player);
            }

        }

        public static void PrintBoard(Board board) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    PrintPiece(board.Piece(i, j)); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
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
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
            Console.BackgroundColor = originalBackground;
        }

        
        public static void PrintPiece(Piece piece) {

            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if(piece.color == board.Color.White) {
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

        public static void PrintCapturedPieces(Game game) {
            Console.WriteLine(string.Concat(Enumerable.Repeat("# ", game.board.columns + 1)));
            Console.WriteLine();
            Console.WriteLine("Captured pieces");
            Console.Write("White's: ");
            PrintGroup(game.CapturedPieces(board.Color.White));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(); 
            Console.Write("Black's: ");
            PrintGroup(game.CapturedPieces(board.Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(string.Concat(Enumerable.Repeat("- ", game.board.columns + 1)));
        }

        public static void PrintGroup(HashSet<Piece> group) {
            Console.Write("[");
            foreach (Piece piece in group) {
                Console.Write(piece + " ");
            }
            Console.Write("]  ");
        }

        public static ChessPosition ReadPosition() {
            string command = Console.ReadLine();
            char column = command[0];
            int row = int.Parse(command[1] + "");
            return new ChessPosition(column, row);
         }
    }
}
