using board;

namespace game {
    class King : Piece
    {

        public King(Board board, Color color):base(board, color){}

        public override string ToString()
        {
            return "♔";
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
            
            // Above
            pos.DefineValues(position.row - 1, position.column);
            if(board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // NE
            pos.DefineValues(position.row - 1, position.column + 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // Right
            pos.DefineValues(position.row, position.column + 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // SE
            pos.DefineValues(position.row + 1, position.column + 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // Below
            pos.DefineValues(position.row + 1, position.column);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // SO
            pos.DefineValues(position.row + 1, position.column - 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // Left
            pos.DefineValues(position.row, position.column - 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // NO
            pos.DefineValues(position.row - 1, position.column - 1);
            if (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
