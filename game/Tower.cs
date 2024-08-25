using board;

namespace game {
    class Tower : Piece
    {

        public Tower(Board board, Color color):base(board, color){}

        public override string ToString()
        {
            return "♖";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            
            Position pos = new Position(0, 0);

            // Above
            pos.DefineValues(position.row - 1, position.column);
            while (board.EvalPositionValidity(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.row = pos.row - 1;
            }

            // Below
            pos.DefineValues(position.row + 1, position.column);
            while (board.EvalPositionValidity(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.row = pos.row + 1;
            }

            // Right
            pos.DefineValues(position.row, position.column + 1);
            while (board.EvalPositionValidity(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // Left
            pos.DefineValues(position.row, position.column - 1 );
            while (board.EvalPositionValidity(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
