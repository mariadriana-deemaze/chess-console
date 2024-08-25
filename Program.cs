using board;
using game;

namespace chess_console {
    class Program
    {
        static void Main()
        {
            try { 
                Game game = new Game();

                while (!game.finished)
                {

                    try {
                        Console.Clear();
                        Print.printBoard(game.board);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + game.turn);
                        Console.WriteLine(game.player + "'s turn.");

                        Console.Write("Type origin position: ");
                        Position origin = Print.ReadPosition().ToPosicion();
                        game.ValidateOriginPosition(origin);


                        bool[,] possibleMoves = game.board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Print.printBoard(game.board, possibleMoves);
                        Console.WriteLine();

                        Console.Write("Type target position: ");
                        Position target = Print.ReadPosition().ToPosicion();
                        game.ValidateTargetPosition(origin, target);

                        game.PlayTurn(origin, target);

                    } catch (BoardException ex) {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                   
                }

            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            Console.ReadLine();
        }
    }
}