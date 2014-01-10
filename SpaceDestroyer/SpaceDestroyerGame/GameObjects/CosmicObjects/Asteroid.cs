namespace SpaceDestroyerGame.GameObjects.CosmicObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class Asteroid : CosmicObject
    {
        public Asteroid(Position position, char[,] body) : base(position, body)
        {           
        }

        public override void Collide(GameObject obj)
        {
            this.IsDestroyed = true;
        }
    }
}
