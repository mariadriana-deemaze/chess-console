using board;

namespace game {
    class Bishop : Piece
    {

        public Bishop(Board board, Color color):base(board, color){}

        public override string ToString()
        {
            return "♗";
        }


        private bool CanMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // NO
            pos.DefineValues(position.row - 1, position.column - 1);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.DefineValues(position.row + 1, position.column + 1);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row - 1, pos.column + 1);
            }

            // SE
            pos.DefineValues(position.row + 1, position.column + 1);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row + 1, pos.column + 1);
            }

            // SO
            pos.DefineValues(position.row + 1, position.column - 1);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
