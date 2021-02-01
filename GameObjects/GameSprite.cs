using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameObjects
{
    public class GameSprite
    {
        public Bitmap SpriteImage { get; set; }
        public PointF Location { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool WasDestroyed { get; set; }

        public GameSprite()
        {
        }

        public void Draw(Graphics gfx)
        {
            // Draw sprite image on screen
            if (!this.WasDestroyed)
            {
                gfx.DrawImage(SpriteImage, new RectangleF(Location.X, Location.Y, Width, Height));
            }
        }

        public void Destroy()
        {
            this.Width = -50;
            this.Height = -50;
            this.WasDestroyed = true;
        }
    }
}
