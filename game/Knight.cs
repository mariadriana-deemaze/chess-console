using board;

namespace game {
    class Knight : Piece
    {

        public Knight(Board board, Color color):base(board, color){}

        public override string ToString()
        {
            return "♘";
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

            pos.DefineValues(position.row - 1, position.column + 2);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.DefineValues(position.row - 2, position.column - 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.DefineValues(position.row - 2, position.column + 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.DefineValues(position.row - 1, position.column + 2);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.DefineValues(position.row + 1, position.column + 2);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            
            pos.DefineValues(position.row + 2, position.column + 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.DefineValues(position.row + 2, position.column - 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.DefineValues(position.row + 1, position.column - 2);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
