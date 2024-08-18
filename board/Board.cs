namespace board {
    class Board {
        public int rows {  get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(Position position)
        {
            return pieces[position.row, position.column];
        }

        public void putPiece(Piece piece, Position position)
        {
            if (exists(position))
            {
                throw new BoardException("There's already a piece in that position.");
            }
            pieces[position.row, position.column] = piece;
            piece.position = position;
        }


        public bool exists(Position position) { 
            validatePosition(position);
            return piece(position) != null; 
        }

       
        public bool evalPositionValidity(Position position)
        {
            if(position.row < 0 || position.row >= rows || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position)
        {
            if(!evalPositionValidity(position))
            {
                throw new BoardException("Invalid position.");
            }
        }

         public Piece removePiece(Position position)
        {
            if(piece(position) != null)
            {
                return null;
            }

            Piece aux = piece(position);
            aux.position = null;
            pieces[position.row, position.column] = null;
            return aux;
        }
    }
}
