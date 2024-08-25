using board;
using System.Runtime.ConstrainedExecution;

namespace game {
    class Game {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color player;
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;
        public bool inCheck { get; private set; }

        public Game()
        {
            board = new Board(8, 8);
            turn = 1;
            player = Color.White;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            inCheck = false;
            Init();
        }

        public void PlayTurn(Position origin, Position target) {
            Piece captured = Move(origin, target);
            
            if (IsInCheck(player)) {
                UndoMove(origin, target, captured);
                throw new BoardException("Cannot put yourself in check.");
            }

            if (IsInCheck(GetAdversaryPlayer(player))) {
                inCheck = true;
            } else {
                inCheck = false;
            }

            if (ValidateCheck(GetAdversaryPlayer(player))) {
                finished = true;
            } else { 
                turn++;
                ChangePlayer();
            }
           

        }

        public void ChangePlayer() {
            if(player == Color.White) {
                player = Color.Black;
            } else {
                player = Color.White;
            }
        }
        
        public Piece Move(Position origin, Position target) {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementMovement();
            Piece capturedPiece = board.RemovePiece(target);
            board.PutPiece(piece, target);
            if(capturedPiece != null) {
                capturedPieces.Add(capturedPiece);
            }
            return piece;
        }

        public void UndoMove(Position origin, Position target, Piece captured) {
            Piece piece = board.RemovePiece(target);
            piece.DecrementMovement();
            if (captured != null) {
                board.PutPiece(captured, target);
                capturedPieces.Remove(captured);
            }
            board.PutPiece(piece, origin);
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

        private Color GetAdversaryPlayer(Color color)
        {
            if(color == Color.White) {
                return Color.Black;
            } else {
                return Color.White;
            }
        }

        private Piece? GetKing(Color color)
        {
            foreach (Piece piece in InGamePieces(color))
            {
                if(piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece? king = GetKing(color) ?? throw new BoardException("Theres no King on the " +  color + " in board.");
            
            foreach (Piece piece in InGamePieces(GetAdversaryPlayer(color))) {
                bool[,] mat = piece.PossibleMoves();
                if (mat[king.position.row, king.position.column]) {
                    return true;
                }
            }
            return false;
        }


        public bool ValidateCheck(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in InGamePieces(color)) {
                bool[,] mat = piece.PossibleMoves();
                for(int i = 0; i < board.rows; i++) {
                    for (int j = 0; j < board.columns; j++) { 
                        if(mat[i, j])
                        {
                            Position origin = piece.position;
                            Position target = new Position(i, j);
                            Piece captured = Move(origin, target);
                            bool check = IsInCheck(color);
                            UndoMove(origin, target, captured);
                            if (!check) { 
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void Init()
        {
            PutNewPiece('a', 1, new Tower(board, Color.White));
            PutNewPiece('b', 1, new Knight(board, Color.White));
            PutNewPiece('c', 1, new Bishop(board, Color.White));
            PutNewPiece('d', 1, new Queen(board, Color.White));
            PutNewPiece('e', 1, new King(board, Color.White));
            PutNewPiece('f', 1, new Bishop(board, Color.White));
            PutNewPiece('g', 1, new Knight(board, Color.White));
            PutNewPiece('h', 1, new Tower(board, Color.White));
            PutNewPiece('a', 2, new Pawn(board, Color.White));
            PutNewPiece('b', 2, new Pawn(board, Color.White));
            PutNewPiece('c', 2, new Pawn(board, Color.White));
            PutNewPiece('d', 2, new Pawn(board, Color.White));
            PutNewPiece('e', 2, new Pawn(board, Color.White));
            PutNewPiece('f', 2, new Pawn(board, Color.White));
            PutNewPiece('g', 2, new Pawn(board, Color.White));
            PutNewPiece('h', 2, new Pawn(board, Color.White));

            PutNewPiece('a', 8, new Tower(board, Color.Black));
            PutNewPiece('b', 8, new Knight(board, Color.Black));
            PutNewPiece('c', 8, new Bishop(board, Color.Black));
            PutNewPiece('d', 8, new Queen(board, Color.Black));
            PutNewPiece('e', 8, new King(board, Color.Black));
            PutNewPiece('f', 8, new Bishop(board, Color.Black));
            PutNewPiece('g', 8, new Knight(board, Color.Black));
            PutNewPiece('h', 8, new Tower(board, Color.Black));
            PutNewPiece('a', 7, new Pawn(board, Color.Black));
            PutNewPiece('b', 7, new Pawn(board, Color.Black));
            PutNewPiece('c', 7, new Pawn(board, Color.Black));
            PutNewPiece('d', 7, new Pawn(board, Color.Black));
            PutNewPiece('e', 7, new Pawn(board, Color.Black));
            PutNewPiece('f', 7, new Pawn(board, Color.Black));
            PutNewPiece('g', 7, new Pawn(board, Color.Black));
            PutNewPiece('h', 7, new Pawn(board, Color.Black));
        }
    }
}
