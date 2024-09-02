namespace board {
    abstract class Piece
    {
        public Position position {  get; set; }
        public Color color { get; protected set; }
        public int moves { get; protected set; }
        public Board board {  get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board; 
            this.color = color;
            this.moves = 0;
        }

        public bool HasPossibleMoves() {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < board.rows; i++) {
                for (int j = 0; j < board.columns; j++) {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void IncrementMovement() {
            moves++; 
        }

        public void DecrementMovement()
        {
            moves--;
        }

        public bool CanMoveTo(Position pos) {
            return PossibleMoves()[pos.row, pos.column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
