namespace SpaceDestroyerGame.GameObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class Bullet : MovingObject
    {
        public Bullet(Position position)
            : base(position, new char[,] { { '|' } })
        {
        }

        public override void Move()
        {
            this.position.Row--;
        }

        public override void Collide(GameObject obj)
        {
            this.IsDestroyed = true;
        }
    }
}
