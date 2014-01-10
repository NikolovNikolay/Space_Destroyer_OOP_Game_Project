namespace SpaceDestroyerGame.GameObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class PlayerBullet : Bullet
    {
        public PlayerBullet(Position position)
            : base(position)
        {
            this.body = new char[,] { { '|' } };
        }

        public override void Move()
        {
            this.position.Row--;
        }
    }
}
