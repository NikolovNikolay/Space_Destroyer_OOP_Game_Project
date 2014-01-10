namespace SpaceDestroyerGame.GameObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class LifeGift : Gift
    {
        public LifeGift(Position position)
            : base(position, new char[,] { { '\u2665' } })
        {
            //this.body = new char[,] {{'\u2665'}};
        }

        public override void Move()
        {
            this.position.Row++;
        }

        public override void Collide(GameObject obj)
        {
            this.IsDestroyed = true;
        }
    }
}
