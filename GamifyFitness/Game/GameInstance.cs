using GamifyFitness.Models;

namespace GamifyFitness.Game
{
    public enum GameState{
        Standby,
        Running,
        Starting,
        Resetting,
        Disabled
    }
    public class GameInstance
    {
        public GameState currentGameState;
        public Player player;
        public Obstacle obstacle;

        public GameInstance()
        {
            Restart();
            SetToStandyBy();
            player = new Player();
            obstacle = new Obstacle();
        }

        public void Restart()
        {
            currentGameState = GameState.Resetting;
            ResetGameObjectPositions();
            SetToStandyBy();
        }

        public void SetToStandyBy()
        {
            currentGameState = GameState.Standby;
        }

        public void StartGame()
        {
            if(currentGameState == GameState.Standby)
            {
                currentGameState = GameState.Running;
            }
        }

        private void ResetGameObjectPositions()
        {
            if(player != null)
            {
                player.ResetPosition();
            }
        }
    }
}