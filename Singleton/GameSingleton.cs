using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Singleton
{
    public class GameSingleton
    {

        private static GameSingleton _instance;

        public static GameSingleton instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameSingleton();

                return _instance;
            }
        }

        public GameSingleton()
        {
            this.Game = new Game();
        }

        public Game Game;
    }
}
