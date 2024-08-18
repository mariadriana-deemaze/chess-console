using board;

namespace game {
    class Game {
        public Board board { get; private set; }
        public int turn;
        public Color player;

        public Game()
        {
            board = new Board(8, 8);
            turn = 1;
            player = Color.White;
            init();
        }

        public void move(Position origin, Position target) {
            Piece piece = board.removePiece(origin);
            piece.incrementMovement();
            Piece captured = board.removePiece(target);
            board.putPiece(piece, target);
        }

        private void init()
        {
            board.putPiece(
              new Tower(board, Color.White), 
              new ChessPosition('c', 1).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.White),
              new ChessPosition('c', 2).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.White),
              new ChessPosition('d', 2).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.White),
              new ChessPosition('e', 2).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.White),
              new ChessPosition('e', 1).ToPosicion()
            );
            board.putPiece(
              new King(board, Color.White),
              new ChessPosition('d', 1).ToPosicion()
            );

            board.putPiece(
              new Tower(board, Color.Black),
              new ChessPosition('c', 7).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.Black),
              new ChessPosition('c', 8).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.Black),
              new ChessPosition('d', 7).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.Black),
              new ChessPosition('e', 7).ToPosicion()
            );
            board.putPiece(
              new Tower(board, Color.Black),
              new ChessPosition('e', 8).ToPosicion()
            );
            board.putPiece(
              new King(board, Color.Black),
              new ChessPosition('d', 8).ToPosicion()
            );
        }
    }
}
