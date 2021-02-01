using SnakeGame.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Helper;
using System.Drawing;

namespace SnakeGame.GameObjects
{
    public class Berry : GameSprite
    {
        public int Point { get; private set; }

        public Berry()
        {
            this.SpriteImage = Properties.Resources.berry;
            // Set sprite height & width in pixels
            this.Width = this.SpriteImage.Width;
            this.Height = this.SpriteImage.Height;
            this.Location = new PointF(-50, -50);
            this.Point = 100;
            this.WasDestroyed = true;
        }

        public void InstantiateBerryIfWasDestroyed()
        {
            if (this.WasDestroyed)
            {
                this.Width = this.SpriteImage.Width;
                this.Height = this.SpriteImage.Height;
                this.Location = new PointF(RandomHelper.GetRandomBy(16, GameSingleton.instance.Game.ResolutionWithOffset.Width),
                                            RandomHelper.GetRandomBy(16, GameSingleton.instance.Game.ResolutionWithOffset.Height));

                this.WasDestroyed = false;
            }
        }

    }
}
