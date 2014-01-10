namespace SpaceDestroyerGame.Ships
{
    using SpaceDestroyerGame.GameObjects;
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public abstract class SpaceCraft : MovingObject
    {
        public int HitPoints { get; set; }

        public SpaceCraft(Position position, char[,] body)
            : base(position, body)
        {
        }

        public override void Move()
        {
        }
    }
}
