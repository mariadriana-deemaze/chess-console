namespace board {
    class Board {
        public int rows {  get; set; }
        public int columns { get; set; }
        public Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }


        public Piece Piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece Piece(Position pos)
        {
            return pieces[pos.row, pos.column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (Exists(pos))
            {
                throw new BoardException("There's already a piece in that position.");
            }
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }


        public bool Exists(Position position) { 
            ValidatePosition(position);
            return Piece(position) != null; 
        }

       
        public bool EvalPositionValidity(Position position)
        {
            if(position.row < 0 || position.row >= rows || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if(!EvalPositionValidity(position))
            {
                throw new BoardException("Invalid position.");
            }
        }

         public Piece RemovePiece(Position position)
        {
            if(Piece(position) == null) {
                return null;
            }
            Piece aux = Piece(position);
            aux.position = null;
            pieces[position.row, position.column] = null;
            return aux;
        }
    }
}
