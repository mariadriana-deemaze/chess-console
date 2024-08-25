using board;

namespace game {
    class Queen : Piece
    {

        public Queen(Board board, Color color):base(board, color){}

        public override string ToString()
        {
            return "♕";
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
            
            // Left
            pos.DefineValues(position.row, position.column - 1);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row, pos.column - 1);
            }

            // Right
            pos.DefineValues(position.row, position.column + 1);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row, pos.column + 1);
            }

            // Up
            pos.DefineValues(position.row - 1, position.column);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row - 1, pos.column);
            }

            // Down
            pos.DefineValues(position.row + 1, position.column);
            while (board.EvalPositionValidity(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.row + 1, pos.column);
            }

            // N0
            pos.DefineValues(position.row - 1, position.column -1);
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
            pos.DefineValues(position.row - 1, position.column + 1);
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
