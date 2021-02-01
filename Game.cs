using SnakeGame.Enums;
using SnakeGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeGame
{
    public class Game
    {

        public Snake Snake;
        public Berry Berry;
        public int Points { get; set; }
        public int PointsRecord { get; set; }
        public Size Resolution { get; set; }
        public Size ResolutionWithOffset
        {
            get
            {
                return new Size(Resolution.Width - 32, Resolution.Height - 58);
            }
        }
        private double Speed { get; set; }
        private DateTime DtLastMove { get; set; }
        private Direction Direction { get; set; }
        private Random random { get; set; }

        public void Load()
        {
            this.InitializeGame();
        }

        public void Unload()
        {

        }

        public void Update(TimeSpan gameTime)
        {
            DateTime dtNow = DateTime.Now;

            if (this.DtLastMove.AddSeconds(this.Speed) < dtNow)
            {
                this.Direction = this.Snake.GetDirection(this.Direction);

                if (this.Snake.ValidateNextMovement(this.Direction))
                {
                    this.Snake.Move(this.Direction);
                }
                else
                {
                    Console.WriteLine("Restarting the game...");
                    this.InitializeGame();
                }

                this.DtLastMove = dtNow;
            }

            this.SetDirection();
            this.EatBerry();
            this.SetGameSpeed();
        }

        public void Draw(Graphics gfx)
        {
            // Draw Background Color
            gfx.FillRectangle(new SolidBrush(Color.CornflowerBlue), new Rectangle(0, 0, Resolution.Width, Resolution.Height));

            Snake.Draw(gfx);
            Berry.Draw(gfx);
        }

        #region Private Methods

        private void InitializeGame()
        {
            this.SetRecord();

            this.Points = 0;
            this.random = new Random();
            this.Snake = new Snake(0, 0);
            this.Berry = new Berry();
            this.Berry.InstantiateBerryIfWasDestroyed();

            this.DtLastMove = DateTime.Now;
            this.Direction = Direction.Right;
            
            this.SetGameSpeed();
        }

        private void SetDirection()
        {
            if (((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0) ||
                ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0))
            {
                Direction = Direction.Right;
            }
            else if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0 ||
                ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0))
            {
                Direction = Direction.Left;
            }
            else if ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0 ||
                ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0))
            {
                Direction = Direction.Up;
            }
            else if ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0 ||
                ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0))
            {
                Direction = Direction.Down;
            }
        }

        private void SetGameSpeed()
        {
            if (this.Points > (Int32)GameStage.Insane)
                this.Speed = 0.04F;
            else if (this.Points > (Int32)GameStage.VeryHard)
                this.Speed = 0.06F;
            else if (this.Points > (Int32)GameStage.Hard)
                this.Speed = 0.08F;
            else if (this.Points > (Int32)GameStage.Medium)
                this.Speed = 0.1F;
            else if (this.Points > (Int32)GameStage.VeryEasy)
                this.Speed = 0.2F;
            else
                this.Speed = 0.3F;
        }

        private void SetRecord()
        {
            if (this.Points > this.PointsRecord)
            {
                this.PointsRecord = this.Points;
            }
        }

        private void EatBerry()
        {
            if (this.Snake[0].Location.X == this.Berry.Location.X &&
                this.Snake[0].Location.Y == this.Berry.Location.Y)
            {
                this.Points += this.Berry.Point;
                this.Berry.Destroy();
                this.Snake.NeedNewPiece = true;
                this.Berry.InstantiateBerryIfWasDestroyed();
            }
        }

        #endregion

    }
}
