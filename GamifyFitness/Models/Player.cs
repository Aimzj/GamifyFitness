namespace GamifyFitness.Models
{
    public class Player
    {
        public bool isJumping {get; set;}
        public bool canJump {get; set;}
        public Position currentPosition {get; set;}
        public Position startingPosition {get; set;}

        public Player()
        {
            //currentPosition = startingPosition;
            canJump = true;
            isJumping = false;
        }

        public void ResetPosition()
        {
            //currentPosition = startingPosition;
            //Cut all animation
        }
    }
}