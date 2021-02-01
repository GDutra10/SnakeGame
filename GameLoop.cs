using SnakeGame.Singleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameLoop
    {
        private FrmGame frmGame;

        public GameLoop(FrmGame pForm)
        {
            this.frmGame = pForm;
        }

        /// <summary>
        /// Status of GameLoop
        /// </summary>
        public bool Running { get; private set; }

        public void Load()
        {
        }

        /// <summary>
        /// Start GameLoop
        /// </summary>
        public async void Start()
        {
            if (GameSingleton.instance.Game == null)
                throw new ArgumentException("Game not loaded!");

            // Load game content
            GameSingleton.instance.Game.Load();

            // Set gameloop state
            Running = true;

            // Set previous game time
            DateTime _previousGameTime = DateTime.Now;

            while (Running)
            {
                this.frmGame.Text = $"Snake Game - Points: {GameSingleton.instance.Game.Points} - Record: {GameSingleton.instance.Game.PointsRecord}";

                // Calculate the time elapsed since the last game loop cycle
                TimeSpan GameTime = DateTime.Now - _previousGameTime;
                // Update the current previous game time
                _previousGameTime = _previousGameTime + GameTime;
                // Update the game
                GameSingleton.instance.Game.Update(GameTime);
                // Update Game at 60fps
                await Task.Delay(8);
            }
        }

        /// <summary>
        /// Stop GameLoop
        /// </summary>
        public void Stop()
        {
            Running = false;
            GameSingleton.instance.Game?.Unload();
        }

        /// <summary>
        /// Draw Game Graphics
        /// </summary>
        public void Draw(Graphics gfx)
        {
            GameSingleton.instance.Game.Draw(gfx);
        }
    }
}
