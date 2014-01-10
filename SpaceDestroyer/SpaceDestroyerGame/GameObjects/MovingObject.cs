namespace SpaceDestroyerGame.GameObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class MovingObject : GameObject
    {
        public MovingObject(Position position, char[,] body) : base(position,body)
        {
        }

        public override void Move()
        {
        }
    }
}
