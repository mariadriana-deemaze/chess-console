using board;

namespace game {
    class Game {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color player;
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public Game()
        {
            board = new Board(8, 8);
            turn = 1;
            player = Color.White;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            Init();
        }

        public void PlayTurn(Position origin, Position target) {
            Move(origin, target);
            turn++;
            ChangePlayer();
        }

        public void ChangePlayer() {
            if(player == Color.White) {
                player = Color.Black;
            } else {
                player = Color.White;
            }
        }
        
        public void Move(Position origin, Position target) {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementMovement();
            Piece capturedPiece = board.RemovePiece(target);
            board.PutPiece(piece, target);
            if(capturedPiece != null) {
                capturedPieces.Add(capturedPiece);
            }
        }

        public void ValidateOriginPosition(Position origin){
            if (board.Piece(origin) == null) {
                throw new BoardException("Not a valid origin position.");
            }

            if (board.Piece(origin).color != player) {
                throw new BoardException("Not this player's turn.");
            }

            if (!board.Piece(origin).HasPossibleMoves()) {
                throw new BoardException("No possible moves for this piece.");
            }
        }

        public void ValidateTargetPosition(Position origin, Position target) {
            if (!board.Piece(origin).CanMoveTo(target)) {
                throw new BoardException("Not a valid target position.");
            }
        }

        public void PutNewPiece(char column, int row, Piece piece) {
            board.PutPiece(piece, new ChessPosition(column, row).ToPosicion());
            pieces.Add(piece);
        }


        public HashSet<Piece> CapturedPieces(Color color) {
            HashSet<Piece> filtered = new HashSet<Piece>();  
            foreach (Piece piece in capturedPieces) {
                if(piece.color == color) {
                    filtered.Add(piece);
                }
            }
            return filtered;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> filtered = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.color == color)
                {
                    filtered.Add(piece);
                }
            }
            filtered.ExceptWith(CapturedPieces(color));
            return filtered;
        }

        private void Init()
        {
            PutNewPiece('c', 1, new Tower(board, Color.White));
            PutNewPiece('c', 2, new Tower(board, Color.White));
            PutNewPiece('d', 2, new Tower(board, Color.White));
            PutNewPiece('e', 2, new Tower(board, Color.White));
            PutNewPiece('e', 1, new Tower(board, Color.White));
            PutNewPiece('d', 1, new King(board, Color.White));

            PutNewPiece('c', 7, new Tower(board, Color.Black));
            PutNewPiece('c', 8, new Tower(board, Color.Black));
            PutNewPiece('d', 7, new Tower(board, Color.Black));
            PutNewPiece('e', 7, new Tower(board, Color.Black));
            PutNewPiece('e', 8, new Tower(board, Color.Black));
            PutNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
