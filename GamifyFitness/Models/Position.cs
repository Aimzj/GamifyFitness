namespace GamifyFitness.Models
{
    public class Position
    {
        public int x {get; set;}
        public int y {get; set;}

        public Position()
        {
            x = 0;
            y = 0;
        }

        public Position(int xInput, int yInput)
        {
            x = xInput;
            y = yInput;
        }
    }
}