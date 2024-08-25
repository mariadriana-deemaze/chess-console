using board;
using System.Runtime.ConstrainedExecution;

namespace game
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) {}

        public override string ToString()
        {
            return "♙";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        private bool HasEnemy(Position position)
        {
            Piece piece = board.Piece(position);
            return piece != null && piece.color != color;
        }

        private bool IsFree(Position position)
        {
            return board.Piece(position) != null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.DefineValues(position.row - 1, position.column);
                if (board.EvalPositionValidity(pos) && canMove(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.DefineValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (board.EvalPositionValidity(p2) && IsFree(p2) && board.EvalPositionValidity(pos) && IsFree(pos) && moves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.DefineValues(position.row - 1, position.column - 1);
                if (board.EvalPositionValidity(pos) && HasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.DefineValues(position.row - 1, position.column + 1);
                if (board.EvalPositionValidity(pos) && HasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }
            else
            {
                pos.DefineValues(position.row + 1, position.column);
                if (board.EvalPositionValidity(pos) && canMove(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.DefineValues(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (board.EvalPositionValidity(p2) && IsFree(p2) && board.EvalPositionValidity(pos) && IsFree(pos) && moves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.DefineValues(position.row + 1, position.column - 1);
                if (board.EvalPositionValidity(pos) && HasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                pos.DefineValues(position.row + 1, position.column + 1);
                if (board.EvalPositionValidity(pos) && HasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }

            return mat;
        }
    }
}
