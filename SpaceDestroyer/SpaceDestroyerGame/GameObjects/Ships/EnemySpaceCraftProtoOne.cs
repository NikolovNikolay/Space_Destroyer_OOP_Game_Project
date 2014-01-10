namespace SpaceDestroyerGame.Ships
{
    using SpaceDestroyerGame.GameObjects;
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class EnemySpaceCraftProtoOne : EnemySpaceCraft
    {
        public EnemySpaceCraftProtoOne(Position position)
            : base(position)
        {
            this.body = new char[,]
            { 
                { '\\',' ', '/' },
                { '_', 'V', '_' },
                { '-', '|', '-' },
                { ' ', 'V', ' ' }
            };
            this.HitPoints = 0;
        }

        public override void Move()
        {
            this.position.Row++;

            //if(this.position.Row > Console.BufferHeight)
            //{
            //    this.isDestroyed = true;
            //}
        }

        public override void Collide(GameObject obj)
        {
            this.HitPoints--;
            if (this.HitPoints <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
