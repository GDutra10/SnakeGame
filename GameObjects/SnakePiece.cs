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
    public class SnakePiece : GameSprite
    {
        public Direction Direction { get; private set; }
        public PointF LastPosition { get; set; }

        public SnakePiece(PointF pLocation, Direction pDirection)
        {
            this.SpriteImage = Properties.Resources.snake;
            // Set sprite height & width in pixels
            this.Width = this.SpriteImage.Width;
            this.Height = this.SpriteImage.Height;
            // Set sprite coodinates
            this.Location = pLocation;
            this.LastPosition = pLocation;
            this.Direction = pDirection;
        }

        public PointF Move(Direction pDirection)
        {
            this.LastPosition = this.Location;
            this.Direction = pDirection;

            switch (this.Direction)
            {
                case Direction.Right:
                    this.Location = new PointF(this.Location.X + GameObjectConstant.PixelSize, this.Location.Y);
                    break;
                case Direction.Left:
                    this.Location = new PointF(this.Location.X - GameObjectConstant.PixelSize, this.Location.Y);
                    break;
                case Direction.Up:
                    this.Location = new PointF(this.Location.X, this.Location.Y - GameObjectConstant.PixelSize);
                    break;
                case Direction.Down:
                    this.Location = new PointF(this.Location.X, this.Location.Y + GameObjectConstant.PixelSize);
                    break;
                default:
                    break;
            }

            return LastPosition;
        }

        public void Move(PointF pPosition)
        {
            this.LastPosition = this.Location;
            this.Location = pPosition;
        }


    }
}
