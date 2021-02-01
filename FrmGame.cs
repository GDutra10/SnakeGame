using SnakeGame.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class FrmGame : Form
    {
        Timer graphicsTimer;
        GameLoop gameLoop;

        public FrmGame()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            // Initialize graphicsTimer
            graphicsTimer = new Timer();
            graphicsTimer.Interval = 1000 / 120;
            graphicsTimer.Tick += GraphicsTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            // Initialize Game
            //myGame.Resolution = new Size(resolution.Width, resolution.Height);
            GameSingleton.instance.Game.Resolution = new Size(this.MaximumSize.Width, this.MaximumSize.Height);

            // Initialize & Start GameLoop
            gameLoop = new GameLoop(this);
            gameLoop.Load();
            gameLoop.Start();

            // Start Graphics Timer
            graphicsTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw game graphics on Form1
            gameLoop.Draw(e.Graphics);
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Form1 graphics
            Invalidate();
        }
    }
}
