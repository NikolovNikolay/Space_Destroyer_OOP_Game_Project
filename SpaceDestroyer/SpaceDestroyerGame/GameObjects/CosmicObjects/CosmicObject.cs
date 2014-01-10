namespace SpaceDestroyerGame.GameObjects.CosmicObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class CosmicObject : MovingObject
    {
        public CosmicObject(Position position, char[,] body)
            : base(position, body)
        {
        }

        public override void Move()
        {
        }
    }
}
