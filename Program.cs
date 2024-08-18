using game;

namespace chess_console {
    class Program
    {
        static void Main()
        {
            try { 
                Game game = new Game();
                Print.printBoard(game.board);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            Console.ReadLine();
        }
    }
}