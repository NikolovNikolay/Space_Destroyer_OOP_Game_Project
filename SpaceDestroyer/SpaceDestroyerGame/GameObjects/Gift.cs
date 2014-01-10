namespace SpaceDestroyerGame.GameObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public abstract class Gift : MovingObject
    {
        public Gift(Position position, char[,] body) : base(position, body)
        {           
        }
    }
}