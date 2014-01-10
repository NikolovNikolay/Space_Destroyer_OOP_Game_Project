namespace SpaceDestroyerGame.GameObjects.CosmicObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class Star : CosmicObject
    {
        public Star(Position position, char[,] body) : base(position,body)
        {
        }

        public override void Move()
        {
            this.GetPosition.Row++;
        }
    }
}
