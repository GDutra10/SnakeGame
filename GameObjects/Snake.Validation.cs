using SnakeGame.Constants;
using SnakeGame.Enums;
using SnakeGame.Singleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameObjects
{
    public partial class Snake
    {

        private PointF GetNextHeadPosition(Direction pDirection)
        {
            float x = this.FirstSnakePiece.Location.X;
            float y = this.FirstSnakePiece.Location.Y;

            switch (pDirection)
            {
                case Direction.Right:
                    x += GameObjectConstant.PixelSize;
                    break;
                case Direction.Left:
                    x -= GameObjectConstant.PixelSize;
                    break;
                case Direction.Up:
                    y -= GameObjectConstant.PixelSize;
                    break;
                case Direction.Down:
                    y += GameObjectConstant.PixelSize;
                    break;
                default:
                    break;
            }

            return new PointF(x, y);
        }

        public bool ValidateNextMovement(Direction pDirection)
        {
            return !this.ValidateIfTouchInSnakePiece(pDirection) && !this.ValidateIfTouchInBorder(pDirection);
        }

        private bool ValidateIfTouchInBorder(Direction pDirection)
        {
            PointF position = this.GetNextHeadPosition(pDirection);

            if (pDirection == Direction.Right && position.X > GameSingleton.instance.Game.ResolutionWithOffset.Width ||
                pDirection == Direction.Down && position.Y > GameSingleton.instance.Game.ResolutionWithOffset.Height ||
                pDirection == Direction.Left && position.X < 0 ||
                pDirection == Direction.Up && position.Y < 0)
                return true;

            return false;
        }

        private bool ValidateIfTouchInSnakePiece(Direction pDirection)
        {
            if (this.SecondSnakePiece != null)
            {
                PointF position = this.GetNextHeadPosition(pDirection);

                foreach (SnakePiece snakePiece in snakePieces)
                {
                    if (snakePiece.Location.X == position.X && snakePiece.Location.Y == position.Y)
                        return true;
                }
            }

            return false;
        }

    }
}
