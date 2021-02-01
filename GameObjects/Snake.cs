using SnakeGame.Constants;
using SnakeGame.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameObjects
{
    public partial class Snake : List<SnakePiece>
    {
        public bool NeedNewPiece { get; set; }
        private SnakePiece FirstSnakePiece
        {
            get
            {
                return this.snakePieces[0];
            }
        }

        private SnakePiece SecondSnakePiece
        {
            get
            {
                return (this.snakePieces.Count <= 1) ? null : this.snakePieces[1];
            }
        }

        public Snake(float x, float y)
        {
            this.Add(new SnakePiece(new PointF(x, y), Direction.Right));
        }

        private List<SnakePiece> snakePieces
        {
            get
            {
                return this;
            }
        }

        public Direction GetDirection(Direction pDirection)
        {
            if (((FirstSnakePiece.Direction == Direction.Right && pDirection == Direction.Left) ||
                (FirstSnakePiece.Direction == Direction.Left && pDirection == Direction.Right) ||
                (FirstSnakePiece.Direction == Direction.Up && pDirection == Direction.Down) ||
                (FirstSnakePiece.Direction == Direction.Down && pDirection == Direction.Up)) 
                && this.SecondSnakePiece != null)
                return FirstSnakePiece.Direction;

            return pDirection;
        }

        public void Move(Direction pDirection)
        {
            PointF position = this.FirstSnakePiece.Move(pDirection);

            for (int i = 1; i < this.Count; i++)
            {
                SnakePiece snakePiece = this.snakePieces[i];
                snakePiece.Move(position);
                position = snakePiece.LastPosition;
            }

            if (this.NeedNewPiece)
            {
                AddPiece(position);
            }
        }

        public void AddPiece(PointF pPosition)
        {
            this.NeedNewPiece = false;
            this.Add(new SnakePiece(pPosition, Direction.Right));
        }

        public void Draw(Graphics gfx)
        {
            foreach (SnakePiece snakePiece in this)
            {
                snakePiece.Draw(gfx);
            }
        }

    }
}
