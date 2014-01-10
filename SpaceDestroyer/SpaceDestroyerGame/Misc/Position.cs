namespace SpaceDestroyerGame.Misc
{
    using System;
    using System.Linq;

    public class Position
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
